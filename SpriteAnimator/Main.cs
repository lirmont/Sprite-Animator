using OpenTK.Audio;
using SpriteAnimator.SupportClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Tao.OpenGl;

#pragma warning disable
namespace SpriteAnimator
{
    public partial class Main : Form
	{
		/*
		 * OpenGL Management
		 */
		public OpenGLConfiguration oglConfiguration = new OpenGLConfiguration();

		/*
		 * Window Management
		 */
		public Credits creditsWindow = null;
		public AvailableFormats availableFormatsWindow = null;
		public AvailableAttachments availableAttachmentsWindow = null;
		public ImageViewerOGL previewWindow = null;
		public string baseLocation = "";
		bool threadNeedsToDie = false;
		List<Renderer> renderers = new List<Renderer>();
		public LegacyOpenGLRenderer openGLRenderer = new LegacyOpenGLRenderer();
		public Renderer renderer = null;

		/*
		 * Preview Window Management
		 */
		public bool previewWindowPopOut = false;

		/*
		 * Optional: Load file from command-line argument.
		 */
		private bool launchedLoadFileAtStartupThread = false;
		private bool mainWindowHasBeenLoaded = false, previewWindowHasBeenShown = false;

		/*
		 * Re-draw viewports based on milliseconds.
		 */
		public int targetMilliseconds = 20, targetMS = 143;
		public int startMilliseconds = 0, currentMilliseconds = 0;
		private System.Threading.Timer scheduleRedraw, scanFileChanges, scanFormatFileChanges;
		private bool forceRedraw = false;

		/*
		 * Loaded image support variables.
		 */
		public Color backgroundColor = Color.Black;
		public ImageDescription loadedImageDescription = new ImageDescription(0, makeBackgroundTransparent: true, pushToContext: false);
		public DateTime loadedImageLastWrite, loadedFormatLastWrite;
		public ImageDescription backgroundImageDescription = null;
		public ImageDescription[] numberImageDescriptions = new ImageDescription[10];

		/*
		 * Named attachment-related; external images.
		 */
		public List<Shapes.NamedAttachmentPoint> availableNamedAttachmentPointsList = new List<Shapes.NamedAttachmentPoint>();
		public Dictionary<int, ImageDescription> namedAttachments = new Dictionary<int, ImageDescription>();

		/*
		 * Sound-related.
		 */
		public AudioContext AC;
		public List<List<Sound>> compositeFrameSoundCues = new List<List<Sound>>();

		/*
		 * Loaded Set
		 */
		public LinkedList<int> previousSet = new LinkedList<int>(), loadedSet = new LinkedList<int>(), nextSet = new LinkedList<int>();
		public System.Collections.IEnumerator previousEnumerator, enumerator, nextEnumerator;

		/*
		 * Loaded page support variables.
		 */
		public int loadedPageRows = 1, loadedPageColumns = 1;
		private int frameWidth = 0, frameHeight = 0;
		public List<ImageDescription> compositeFramePointers = new List<ImageDescription>(), backBufferCompositeFramePointers = new List<ImageDescription>();

		/*
		 * Loaded format support variables.
		 */
		public string loadedFormat = "";
		private SupportClasses.Format format = null;

		/*
		 * Overlaid drawing description.
		 */
		public int rows = 4;
		public int columns = 14;
		public int boxWidth = 0;
		public int boxHeight = 0;

		/*
		 * Animation support variables.
		 */
		public int advanceColumns = 0;
		public int advanceRows = 0;
		public int subCurrentAnimationFrame = 1;

		public SupportClasses.Format Format
		{
			get { return format; }
			set
			{
				format = value;
				setNoSampling(value.UseNoSampling, m: this, suppressEvent: true);
				//
				targetMS = value.TargetMS;
				//
				loadedPageRows = value.TargetRows;
				loadedPageColumns = value.TargetColumns;
			}
		}

		public int CurrentCompositeFrame
		{
			get
			{
				return advanceRows * columns + advanceColumns + 1;
			}
		}

		public int PreviousCompositeFrame
		{
			get
			{
				int id = CurrentCompositeFrame - 1;
				return (id > 0) ? id : TotalCompositeFrames;
			}
		}

		public int TotalCompositeFrames
		{
			get
			{
				return loadedPageRows * loadedPageColumns;
			}
		}

		bool suppressNoSamplingRedraw = false;
		public int Sampling
		{
			get
			{
				return (useNoSamplingCheckBox.Checked) ? Gl.GL_NEAREST : Gl.GL_LINEAR;
			}
		}

		public Size BackBufferSize
		{
			get
			{
				if (format != null)
					return new Size(format.FrameWidth, format.FrameHeight);
				else
				{
					int width = loadedImageDescription.Width / loadedPageColumns;
					int height = loadedImageDescription.Height / loadedPageRows;
					return new Size(width, height);
				}
			}
		}

		public Size ContextSize
		{
			get
			{
				Size thisSize = BackBufferSize;
				thisSize = new Size(loadedPageColumns * thisSize.Width, loadedPageRows * thisSize.Height);
				return thisSize;
			}
		}

		public Double OnLoadZoom
		{
			get
			{
				return (format != null) ? format.OnLoadZoom : 1.00;
			}
		}

		public Color BackgroundColor
		{
			get { return backgroundColor; }
			set { backgroundColor = value; }
		}

		public Dictionary<string, List<ColorControl.PalettedColor>> StoredPalettes
		{
			get
			{
				Dictionary<string, List<ColorControl.PalettedColor>> cast = new Dictionary<string, List<ColorControl.PalettedColor>>();
				System.Collections.Hashtable thisHashtable = Properties.Settings.Default.storedPalettes ?? new System.Collections.Hashtable();
				foreach (object key in thisHashtable)
					cast.Add(key as string, thisHashtable[key] as List<ColorControl.PalettedColor>);
				return cast;
			}
			set
			{
				Dictionary<string, List<ColorControl.PalettedColor>> existing = value;
				System.Collections.Hashtable replacement = new System.Collections.Hashtable();
				foreach (string existingKey in existing.Keys)
				{
					List<ColorControl.PalettedColor> existingValue = existing[existingKey];
					replacement.Add(existingKey, existingValue);
				}
				Properties.Settings.Default.storedPalettes = replacement;
				Properties.Settings.Default.Save();
			}
		}

		public bool CreditsWindowOpen {
			get {
				return !(creditsWindow == null || creditsWindow.Visible == false);
			}
		}

		/*
		 * Aspect Ratio
		 */
		#region Override for WndProc; Ratio Locking.
		bool _lockRatio = false;
		[
		Description("When true the aspect ratio of the control is locked"),
		Category("Behavior")
		]
		public bool LockRatio
		{
			get { return _lockRatio; }
			set { _lockRatio = value; }
		}

		const int WM_SIZING = 0x214;
		const int WMSZ_LEFT = 1;
		const int WMSZ_RIGHT = 2;
		const int WMSZ_TOP = 3;
		const int WMSZ_BOTTOM = 6;

		private double constrictWidthToIncrement;
		private double constrictHeightToIncrement;

		double heightRatio = 1, widthRatio = 1;
		protected override void WndProc(ref Message m)
		{
			Point p = Cursor.Position;
			bool pChanged = false;
			if (this._lockRatio && loadedImageDescription.Filename != "")
			{
				if (m.Msg == WM_SIZING)
				{
					RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
					int res = m.WParam.ToInt32();
					Control control = this;
					Rectangle formRectangle = new Rectangle(0, 0, control.Width - RenderControl.Width, control.Height - RenderControl.Height);
					int width = rc.Bottom - rc.Top;
					int height = rc.Right - rc.Left;
					int significantWidth = width - formRectangle.Width;
					int significantHeight = height - formRectangle.Height;
					int insignificantHeight = height - RenderControl.Height;
					int insignificantWidth = width - RenderControl.Width;
					if (res == WMSZ_LEFT || res == WMSZ_RIGHT)
					{
						//Left or right resize -> adjust height (bottom)
						rc.Bottom = rc.Top + insignificantHeight + (int)(heightRatio * significantWidth / widthRatio);
					}
					else if (res == WMSZ_TOP || res == WMSZ_BOTTOM)
					{
						//Up or down resize -> adjust width (right)
						rc.Right = rc.Left + insignificantWidth + (int)(widthRatio * significantHeight / heightRatio);
					}
					else if (res == WMSZ_RIGHT + WMSZ_BOTTOM)
					{
						//Lower-right corner resize -> adjust height (could have been width)
						int addition = insignificantHeight + (int)(heightRatio * significantWidth / widthRatio);
						int change = (rc.Top + addition) - rc.Bottom;
						rc.Bottom = rc.Top + addition;
						p.Offset(new Point(0, change));
					}
					else if (res == WMSZ_LEFT + WMSZ_TOP)
					{
						//Upper-left corner -> adjust width (could have been height)
						int addition = -insignificantWidth - (int)(widthRatio * significantHeight / heightRatio);
						int change = (rc.Right + addition) - rc.Left;
						rc.Left = rc.Right + addition;
						p.Offset(new Point(change, 0));
					}
					Marshal.StructureToPtr(rc, m.LParam, true);
				}
			}
			if (p != Cursor.Position)
				Cursor.Position = p;
			base.WndProc(ref m);
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}
		#endregion

		float heightOfDisplayBody = 306f;
		float heightOfAnimationBody = 178f;
		float heightOfAnimationBodyWithoutNamedAnimations = 101f;
		float heightOfSubdivisionBody = 77f;
		float heightPad = (int)(SystemFonts.DefaultFont.SizeInPoints / 8.25f * 6f);

		public Main()
		{
			baseLocation = SupportFunctions.GetBaseLocation();
			this.OnFirstRenderControlFinish += new EventHandler(Main_OnFirstRenderControlFinish);
			Main m = this;
			// Form initialization.
			InitializeComponent();
			// Color.
			colorSwatch.BackColor = Properties.Settings.Default.rawOverlayColor;
			// Measure values for collapsible toolbar bodies.
			heightOfDisplayBody = heightPad + yOfControl(animationButtonPanel) - yOfControl(displayTableLayoutPanel);
			heightOfAnimationBody = heightPad + yOfControl(subdivisionButtonPanel) - yOfControl(animationTableLayoutPanel);
			heightOfAnimationBodyWithoutNamedAnimations = heightOfAnimationBody - (yOfControl(startFrameLabel) - yOfControl(animateByNamedSetRadioButton));
			heightOfSubdivisionBody = heightPad + (yOfControl(numberMaxCells) + numberMaxCells.ClientRectangle.Height) - yOfControl(subdivisionTableLayoutPanel);
			// Set height of animation body (only one showing at start) to measured height.
			float oldHeight = optionsTableLayoutPanel.RowStyles[3].Height;
			float deltaHeight = heightOfAnimationBodyWithoutNamedAnimations - oldHeight;
			optionsTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, heightOfAnimationBodyWithoutNamedAnimations);
			optionsTableLayoutPanel.Height += (int)deltaHeight;
			animationTableLayoutPanel.Height = (int)heightOfAnimationBodyWithoutNamedAnimations;
		}

		private int yOfControl(Control control)
		{
			return control.FindForm().PointToClient(control.Parent.PointToScreen(control.Location)).Y;
		}

		private void RenderControl_Load(object sender, EventArgs e)
		{
			// Get version.
			int major, minor;
			OpenTKSupportFunctions.getCompatibleMajorMinorVersion(out major, out minor);
			oglConfiguration.setMajorMinorVersion(major, minor);
			// Get texture size.
			int textureSize;
			Gl.glEnable(Gl.GL_TEXTURE_2D);
			Gl.glGetIntegerv(Gl.GL_MAX_TEXTURE_SIZE, out textureSize);
			Gl.glDisable(Gl.GL_TEXTURE_2D);
			oglConfiguration.MaximumTextureSize = textureSize;
			// Force power of two. Disable the OpenGL frame renderer.
			if (major < 3)
			{
				ImageDescription.ForcePowerOfTwoDimensions = true;
				openGLRenderer.DoNotInitialize = true;
			}
		}

		void Main_OnFirstRenderControlFinish(object sender, EventArgs e)
		{
			//
			Application.DoEvents();
			// To deal with an error during initialization (possibly because of optimizations), initialize the renderer at the last possible moment.
			Tao.Platform.Windows.SimpleOpenGlControl control = (Tao.Platform.Windows.SimpleOpenGlControl)sender;
			if (control != null && !openGLRenderer.DoNotInitialize)
				openGLRenderer.InitializeRendererOnControl(control);
			if (!openGLRenderer.Initialized)
				openGLRenderer.DoNotInitialize = true;
		}

		public bool ignoreAnyFutureRequests = false;
		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			setStatus("Closing.", this);
			//
			ignoreAnyFutureRequests = true;
			targetMilliseconds = int.MaxValue;
			unloadDrawingFeatureTimers();
			//
			this.Enabled = false;
			previewWindow.Enabled = false;
			previewWindow.ImageViewerOGL_Closing();
		}

		private void Main_Shown(object sender, EventArgs e)
		{
			loadMainWindow();
			// Update list of composite frames to animate through.
			updateSetList();
			// Create the preview window after the entry conditions are figured out.
			previewWindow = new ImageViewerOGL(this);
			previewWindow.Shown += new EventHandler(previewWindow_Shown);
			previewWindow.setWindowToDefaultSize();
			previewWindow.Show(this);
			layoutOverlays();
			// Enable valid features, and start drawing.
			setStatus("Ready.", this);
			startupServices_OnShown(sender);
		}

		public void startupServices_OnShown(object sender)
		{
			Main m = sender as Main;
			m.Invoke((MethodInvoker)delegate()
			{
				loadImageToolStripMenuItem.Enabled = true;
				formatsToolStripMenuItem.Enabled = true;
				availableFormatsToolStripMenuItem.Enabled = true;
				constructedPaletteToolStripMenuItem.Enabled = true;
				availableAttachmentsToolStripMenuItem.Enabled = true;
			});
			loadFeatureTimers(m);
			// Once the main form is loaded, check for arguments.
			string[] arguments = Environment.GetCommandLineArgs();
			// If the program was launched with more than just its own name as an argument, check to see if it's a filename.
			if (arguments.Length >= 2)
			{
				string potentialFilename = arguments[1];
				// If the program was launched with a valid filename argument, start loading it up.
				if (File.Exists(potentialFilename))
					loadFileAtStartup(filename: potentialFilename, sender: sender, handle: this);
			}
		}

		public void unloadDrawingFeatureTimers()
		{
			if (scheduleRedraw != null)
			{
				scheduleRedraw.Dispose();
				scheduleRedraw = null;
			}
			if (scanFileChanges != null)
			{
				scanFileChanges.Dispose();
				scanFileChanges = null;
			}
			if (scanFormatFileChanges != null)
			{
				scanFormatFileChanges.Dispose();
				scanFormatFileChanges = null;
			}
			if (previewWindow != null && !previewWindow.IsDisposed)
				previewWindow.unloadFeatureTimers();
		}

		public void loadFeatureTimers(Main m)
        {
			// Thread: Redraw the display area at an interval of target-ms.
			scheduleRedraw = new System.Threading.Timer(delegate(object data)
			{
				performScheduledRedraw(m);
			}, "Redrawing Render Control", targetMilliseconds, targetMilliseconds);
			// Thread: Scan for image changes.
			scanFileChanges = new System.Threading.Timer(delegate(object data)
			{
				if (loadedImageDescription.Filename != "")
				{
					DateTime testValue = loadedImageDescription.LastWrite;
					if (testValue > loadedImageLastWrite)
					{
						if (autoUpdateYesOrNo.Checked)
						{
							loadedImageLastWrite = testValue;
							Thread reloadImageFileThread = new Thread(new ThreadStart(delegate()
							{
								loadImageForDisplay(loadedImageDescription.Filename, formHandle: m, noOverwriteStartEndFrames: true);
							}));
							reloadImageFileThread.Name = string.Format("Reload Image File: {0}", loadedImageDescription.Filename);
							reloadImageFileThread.Start();
						}
						else
							setStatus("Image Has Been Altered (" + testValue.ToString() + "); Turn on Auto-Update Feature to Retrieve.", m);
					}
				}
			}, "Scanning For File Changes", 900, 900);
			// Thread: Scan for Format File Changes.
			scanFormatFileChanges = new System.Threading.Timer(delegate(object data)
			{
				if (loadedFormat != "" && loadedImageDescription.Filename != "" && autoUpdateOnFormatChange.Checked)
				{
					DateTime testValue = format.LastWrite;
					if (testValue > loadedFormatLastWrite)
					{
						setStatus("Reloading format document.", m);
						Thread reloadFormatThread = new Thread(new ThreadStart(delegate()
						{
							loadOrReloadFormat();
							loadImageForDisplay(loadedImageDescription.Filename, formHandle: m, noOverwriteStartEndFrames: true);
						}));
						reloadFormatThread.Name = string.Format("Reload Format File: {0}", loadedFormat);
						reloadFormatThread.Start();
					}
				}
			}, "Scanning For Format File Changes", 900, 900);
			//
			currentMilliseconds = Environment.TickCount & Int32.MaxValue;
			startMilliseconds = currentMilliseconds - targetMilliseconds;
			//
			previewWindow.loadFeatureTimers(this, previewWindow);
		}

		public int refreshAfter = 0;
		public int refreshCooldown = 1000;
		public int currentStartAnimationMilliseconds = 0;
		private void performScheduledRedraw(Main m)
		{
			currentMilliseconds = Environment.TickCount & Int32.MaxValue;
			if (!CreditsWindowOpen)
			{
				bool animating = true; 
				// Tell the redraw thread to yield if drawing is going to be slow.
				if (oglConfiguration.MajorVersion <= 1)
				{
					animating = animationYesOrNo.Checked || forceRedraw;
					if (previewWindow.hitStoppingPoint || !animating)
					{
						// Refresh at end of every animation for 5 seconds.
						if (animating)
							startMilliseconds += refreshCooldown;
						Application.DoEvents();
						previewWindow.hitStoppingPoint = false;
					}
				}
				// Draw the images.
				if (loadedImageDescription.Filename != "" && animating)
					if (targetMilliseconds <= currentMilliseconds - startMilliseconds || forceRedraw)
					{
						if (targetMS <= currentMilliseconds - currentStartAnimationMilliseconds)
						{
							m.previewWindow.simpleOpenGlControlDraw(previewWindow);
							currentStartAnimationMilliseconds = currentMilliseconds;
						}
						RenderControlDraw(m);
						forceRedraw = false;
						startMilliseconds = currentMilliseconds;
					}
			}
		}

		void previewWindow_Shown(object sender, EventArgs e)
		{
			previewWindowHasBeenShown = true;
		}

		private void loadFileAtStartup(string filename, object sender, Main handle)
		{
			WaitHandle waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
			new System.Threading.Timer(delegate(object thisSender)
			{
				if (loadedFormat == "" && mainWindowHasBeenLoaded && previewWindowHasBeenShown)
				{
					if (!launchedLoadFileAtStartupThread)
					{
						launchedLoadFileAtStartupThread = true;
						setStatus("Loading format document.", handle);
						Thread loadFileAtStartupThread = new Thread(new ThreadStart(delegate()
						{
							loadOrReloadFormat();
							loadImageForDisplay(filename, sender: sender, formHandle: handle);
						}));
						loadFileAtStartupThread.Name = string.Format("Load File at Startup: {0}", filename);
						loadFileAtStartupThread.Start();
					}
				}
				else if (loadedFormat != "")
				{
					// End the task.
					System.Threading.Timer thisTimer = thisSender as System.Threading.Timer;
					if (thisTimer != null)
						thisTimer.Dispose(waitHandle);
				}
			}, "Open File After Forms Load", 0, 1);
		}

		public void layoutOverlays()
		{
			Point alignToWindow = bottomPanel.PointToScreen(new Point(0, 0));
			if (previewWindow != null)
			{
				if (!previewWindowPopOut)
				{
					previewWindow.setLocation(alignToWindow.X - 2, alignToWindow.Y, previewWindow);
					optionsPanel.Location = new Point(optionsPanel.Location.X, previewWindow.Height + 3);
					optionsPanel.Height = renderControlPanel.Height - previewWindow.Height;
				}
				else
				{
					optionsPanel.Location = new Point(optionsPanel.Location.X, 0);
					optionsPanel.Height = renderControlPanel.Height;
				}
			}
		}

		private void Form_Load(object sender, EventArgs e)
		{
		}

		private void loadMainWindow()
		{
			// Finish initializing form items.
			animationButtonPanel_MouseDoubleClick(null, new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
			RenderControl.InitializeContexts();
			RenderControl.MakeCurrent();
			Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
			// Image loading.
			loadOpenGLImageAssets();
			// Audio Context creation.
			try
			{
				AC = new AudioContext();
				SupportFunctions.soundDisabled = false;
			}
			catch (AudioException) { }
			//
			resizeForm();
			layoutOverlays();
			//
			renderers.Add(new SoftwareRenderer());
			if (!openGLRenderer.DoNotInitialize)
				renderers.Add(openGLRenderer);
			//
			Renderer potentialRenderer = renderers.Find(item => item.Name == Properties.Settings.Default.rendererNameString);
			// If a renderer is specified, try to use it. Otherwise, default to software.
			renderer = (potentialRenderer != null) ? potentialRenderer : renderers[0];
			// Add the items.
			foreach (Renderer availableRenderer in renderers)
				rendererToolStripComboBox.Items.Add(availableRenderer.Name);
			if (renderer != null)
				rendererToolStripComboBox.SelectedIndex = renderers.FindIndex(item => item != null && item.Name == renderer.Name);
			rendererToolStripComboBox.SelectedIndexChanged += new EventHandler(rendererToolStripComboBox_SelectedIndexChanged);
			//
			mainWindowHasBeenLoaded = true;
		}

		void rendererToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Renderer oldRenderer = renderer;
			renderer = renderers[rendererToolStripComboBox.SelectedIndex];
			// Save setting.
			Properties.Settings.Default.rendererNameString = renderer.Name;
			Properties.Settings.Default.Save();
			// Reload.
			if (oldRenderer.Name != renderer.Name && !loadedImageDescription.IsPlaceholder)
			{
				Thread rendererHasChangedThread = new Thread(new ThreadStart(delegate()
				{
					loadCompositeFrames(this, noOverwriteStartEndFrames: true);
				}));
				rendererHasChangedThread.Name = "Renderer Has Changed";
				rendererHasChangedThread.Start();
			}
			// Return focus to the main display area.
			RenderControl.Focus();
		}

		private void loadOpenGLImageAssets()
		{
			// Load transparent background image asset.
			backgroundImageDescription = new ImageDescription(10, (Bitmap)Properties.Resources.ResourceManager.GetObject("transparent_background"), repeat: true);
			// Load numbered image assets: iterate over 0 through 9 to load numbers.
			for (int i = 0; i < 10; i++)
			{
				Bitmap number = (Bitmap)Properties.Resources.ResourceManager.GetObject("_" + i);
				number.MakeTransparent(Color.Black);
				numberImageDescriptions[i] = new ImageDescription(i, number);
			}
		}

		private void resizeForm(Main m = null)
		{
			if (!loadedImageDescription.IsPlaceholder)
			{
				if (loadedImageDescription.Filename != "")
				{
					int zW = (int)(ContextSize.Width * OnLoadZoom), zH = (int)(ContextSize.Height * OnLoadZoom);
					// Attempt to limit changes to application dimensions by checking size.
					if (zW != RenderControl.Width || zH != RenderControl.Height)
					{
						if (m == null)
						{
							this.Width = (this.Width - RenderControl.Width) + zW;
							this.Height = (this.Height - RenderControl.Height) + zH;
						}
						else
							setDimensions((m.Width - m.RenderControl.Width) + zW, (m.Height - m.RenderControl.Height) + zH, m);
					}
					if (keepAspectRatioYesOrNo.Checked)
					{
						_lockRatio = true;
						int gcd = SupportFunctions.GCD(RenderControl.Height, RenderControl.Width);
						widthRatio = RenderControl.Width / gcd;
						heightRatio = RenderControl.Height / gcd;
					}
				}
			}
		}

		#region Keyboard controls.
		/*
		 * Placeholders
		 */
		private void Main_KeyUp(object sender, KeyEventArgs e) { }
		private void Main_KeyDown(object sender, KeyEventArgs e) { }
		private void RenderControl_KeyDown(object sender, KeyEventArgs e) { }
		private void RenderControl_KeyPress(object sender, KeyPressEventArgs e) { }

		private void RenderControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			var left = (e.KeyCode == Keys.Left) ? true : false;
			var right = (e.KeyCode == Keys.Right) ? true : false;
			var up = (e.KeyCode == Keys.Up) ? true : false;
			var down = (e.KeyCode == Keys.Down) ? true : false;

			if (left)
			{
				if (advanceColumns > 0)
					advanceColumns -= 1;
				else
					advanceColumns = columns - 1;
				forceRedraw = true;
			}
			if (right)
			{
				if (advanceColumns < columns - 1)
					advanceColumns += 1;
				else
					advanceColumns = 0;
				forceRedraw = true;
			}
			if (up)
			{
				if (advanceRows > 0)
					advanceRows -= 1;
				else
					advanceRows = rows - 1;
				forceRedraw = true;
			}
			if (down)
			{
				if (advanceRows < rows - 1)
					advanceRows += 1;
				else
					advanceRows = 0;
				forceRedraw = true;
			}
		}
		#endregion

		private void RenderControl_Resize(object sender, EventArgs e)
		{
			Application.DoEvents();
			//
			if (this.WindowState == FormWindowState.Maximized)
				keepAspectRatioYesOrNo.Checked = false;
			Gl.glViewport(0, 0, RenderControl.Width, RenderControl.Height);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Glu.gluPerspective(45.0f, ((float)(RenderControl.Width) / (float)(RenderControl.Height)), 0.1f, 2.0f);
			Gl.glClearColor(backgroundColor.R / 255f, backgroundColor.G / 255f, backgroundColor.B / 255f, backgroundColor.A / 255f);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
		}

		public event EventHandler OnFirstRenderControlFinish;

		public void FirstRenderControlFinish(Tao.Platform.Windows.SimpleOpenGlControl control)
		{
			if (OnFirstRenderControlFinish == null) return;
			OnFirstRenderControlFinish(control, null);
		}

		private void RenderControl_Paint(object sender, PaintEventArgs e)
		{
			// Framebuffers >= 3.0
			if (oglConfiguration.NewFrameBuffersAreSupported)
				SupportFunctions.BindDefaultFrameBuffer();
			// Prepare main viewport (also, section necessary for windows dialog).
			Gl.glViewport(0, 0, RenderControl.Width, RenderControl.Height);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Glu.gluPerspective(45.0f, ((float)(RenderControl.Width) / (float)(RenderControl.Height)), 0.1f, 2.0f);
			Gl.glClearColor(backgroundColor.R / 255f, backgroundColor.G / 255f, backgroundColor.B / 255f, backgroundColor.A / 255f);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			Gl.glEnable(Gl.GL_BLEND);
			Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
			Gl.glDisable(Gl.GL_DEPTH_TEST);
			// Draw it.
			RenderControl_Draw();
			// If the OpenGL Renderer needs to be initialized, send out the event that OK's it.
			if (!openGLRenderer.DoNotInitialize)
			{
				Tao.Platform.Windows.SimpleOpenGlControl control = (Tao.Platform.Windows.SimpleOpenGlControl)sender;
				FirstRenderControlFinish(control);
			}
		}

		private void RenderControl_Draw()
		{
			//
			Gl.glPushAttrib(Gl.GL_CURRENT_BIT);
			if (loadedImageDescription.Filename != "")
			{
				SupportFunctions.pushScreenCoordinateMatrix(0, RenderControl.Width, RenderControl.Height, 0);
				{
					// Draw background image.
					if (transparentBackgroundYesOrNo.Checked)
						SupportFunctions.render(0, RenderControl.Width, RenderControl.Height, 0, S: RenderControl.Width / backgroundImageDescription.Width, T: RenderControl.Height / backgroundImageDescription.Height, textureId: backgroundImageDescription.ContextId, textureScale: backgroundImageDescription.TextureScale);
					// Draw raw image.
					if (compositeFramePointers.Count > 1)
					{
						// For each composite frame, draw generated image and sound image.
						for (int i = 0; i < compositeFramePointers.Count; i++)
						{
							int thisAdvanceRows = i / columns, thisAdvanceColumns = i % columns;
							double rcah = RenderControl.Height * (thisAdvanceRows / (double)rows), rcahBottom = RenderControl.Height * ((thisAdvanceRows + 1) / (double)rows);
							double rcaw = RenderControl.Width * (thisAdvanceColumns / (double)columns), rcawRight = RenderControl.Width * ((thisAdvanceColumns + 1) / (double)columns);
							// Push to the context if it hasn't already been pushed.
							if (compositeFramePointers[i].PushToContext == false)
								compositeFramePointers[i].PushToContext = true;
							//
							SupportFunctions.render(rcaw, rcawRight, rcahBottom, rcah, textureId: compositeFramePointers[i].ContextId, textureScale: compositeFramePointers[i].TextureScale);
							// Draw sound.
							if (showAudioWaveForm.Checked)
							{
								for (int cue = 0; cue < Math.Min(i + 1, compositeFrameSoundCues.Count); cue++)
								{
									double waveSize = 10;
									if (rcahBottom - rcah >= waveSize)
									{
										if (compositeFrameSoundCues[cue].Count > 0)
										{
											foreach (Sound soundCue in compositeFrameSoundCues[cue])
											{
												double unit = ((double)animationTargetMS.Value) / (soundCue.lengthInSeconds * 1000);
												double secondsRemaining = soundCue.lengthInSeconds - ((double)animationTargetMS.Value / 1000.0 * (i - cue));
												double msRemaining = Math.Min((double)animationTargetMS.Value, secondsRemaining * 1000);
												double percent = msRemaining / (double)animationTargetMS.Value;
												if (secondsRemaining > 0)
												{
													if (!soundCue.pushedToContext && soundCue.waveFormData.Width > 0 && soundCue.waveFormData.Height > 0)
													{
														BitmapData c = soundCue.waveFormData.LockBits(new Rectangle(0, 0, soundCue.waveFormData.Width, soundCue.waveFormData.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
														SupportFunctions.createTexture(soundCue.waveFormData.Width, soundCue.waveFormData.Height, ref soundCue.waveForm, textureFilter: Sampling, imageData: c.Scan0);
														soundCue.pushToContext();
													}
													//
													double s = (i - cue) * unit, S = ((i - cue) + 1) * unit;
													SupportFunctions.render(rcaw, rcaw + (rcawRight - rcaw) * percent, rcahBottom, rcahBottom - waveSize, color: soundCue.color, s: s, S: S, textureId: soundCue.waveForm);
												}
											}
										}
									}
								}
							}
						}
					}
					else if (compositeFramePointers.Count == 1)
					{
						double rcah = 0, rcahBottom = RenderControl.Height;
						double rcaw = 0, rcawRight = RenderControl.Width;
						if (compositeFramePointers[0].PushToContext == false)
							compositeFramePointers[0].PushToContext = true;
						SupportFunctions.render(rcaw, rcawRight, rcahBottom, rcah, textureId: compositeFramePointers[0].ContextId, textureScale: compositeFramePointers[0].TextureScale);
					}
					// Draw frame number.
					if (drawFrameNumberYesOrNo.Checked)
					{
						string numberString = (advanceRows * columns + (advanceColumns + 1)).ToString();
						RenderControl.MakeCurrent();
						SupportFunctions.DrawText(numberString, numberImageDescriptions, RenderControl.Size, rows, columns, advanceRows, advanceColumns, Properties.Settings.Default.rawOverlayColor);
					}
					// Draw frame.
					if (drawFrameYesOrNo.Checked)
					{
						double rcah = RenderControl.Height * (advanceRows / (double)rows), rcahBottom = RenderControl.Height * ((advanceRows + 1) / (double)rows);
						double rcaw = RenderControl.Width * (advanceColumns / (double)columns), rcawRight = RenderControl.Width * ((advanceColumns + 1) / (double)columns);
						//
						SupportFunctions.render(rcaw, rcawRight, rcahBottom, rcah, color: Properties.Settings.Default.rawOverlayColor, drawingMode: Gl.GL_LINE_LOOP, lineWidth: (float)lineWidth.Value);
					}
				}
				SupportFunctions.pop_projection_matrix();
			}
			Gl.glPopAttrib();
			// Delete older textures.
			if (imageDescriptionsToClear.Count > 0)
			{
				for (int i = 0; i < imageDescriptionsToClear.Count; i++)
				{
					ImageDescription description = imageDescriptionsToClear[i];
					if (!compositeFramePointers.Exists(item => item.ContextId == description.ContextId))
						if (Gl.glIsTexture(description.ContextId) == Gl.GL_TRUE)
						{
							Gl.glDeleteTextures(1, new int[] { description.ContextId });
							description.Dispose();
						}
				}
				imageDescriptionsToClear.Clear();
			}
		}

		private void animationTargetMS_ValueChanged(object sender, EventArgs e)
		{
			// Set target milliseconds (animation).
			if (animationTargetMS != null && animationTargetMS.Value != null)
				targetMS = (int)animationTargetMS.Value;
			// Reset re-draw tasks.
			scheduleRedraw = new System.Threading.Timer(delegate(object data)
			{
				performScheduledRedraw(this);
			}, "Redrawing Render Control", targetMilliseconds, targetMilliseconds);
		}

		public void reloadCompositeFramesWithTheGivenNamedAttachmentPointId(int id)
		{
			List<int> compositeFramesToLoad = new List<int>();
			foreach (int key in format.CompositeFramesWithNamedAttachments.Keys)
				if (format.CompositeFramesWithNamedAttachments[key].Contains(id))
					compositeFramesToLoad.Add(key);
			// Load composite frames.
			if (compositeFramesToLoad.Count > 0)
			{
				loadCompositeFrames(formHandle: this, loadCompositeFramesInList: compositeFramesToLoad.ToArray(), noOverwriteStartEndFrames: true);
			}
		}

		List<ImageDescription> imageDescriptionsToClear = new List<ImageDescription>();
		private void loadImageForDisplay(string file, object sender = null, Main formHandle = null, bool noOverwriteStartEndFrames = false, int[] loadRange = null)
		{
			//
			bool focusOnDrawingAreaAfter = (loadedImageDescription.Filename == "") ? true : false;
			if (File.Exists(file))
			{
				_lockRatio = false;
				setTitle("Sprite Animator - " + file, formHandle);
				#region Detect organizational type.
				string previousLoadedFormat = loadedFormat;
				loadedFormat = file.Split('.')[1];
				if (loadedFormat == System.IO.Path.GetExtension(file))
					loadedFormat = "";
				else
				{
					string xmlPath = SupportFunctions.Combine(baseLocation, "formats", loadedFormat, "sprite.xml");
					if (File.Exists(xmlPath))
					{
						// Clear out certain named attachments if format has changed to new format. Otherwise, just wipe out the points (rather than the images associated with them).
						if (loadedFormat != previousLoadedFormat)
						{
							availableNamedAttachmentPointsList.Clear();
							clearNamedAttachmentPoints();
						}
						else
							availableNamedAttachmentPointsList.Clear();
						// Load format.
						loadOrReloadFormat();
						// Load the image (because the composite frame renderer will need it).
						loadImageFromFile(file);
						// Load all composite frames.
						loadCompositeFrames(formHandle: formHandle, noOverwriteStartEndFrames: noOverwriteStartEndFrames, loadCompositeFramesInList: loadRange);
					}
					else
						loadedFormat = ""; // Fail to load format; use raw.
				}
				// Use raw image.
				if (loadedFormat == "")
				{
					format = null;
					//
					loadImageFromFile(file);
					//
					SetEditLoadedFrameEnabled(formHandle, false);
					backBufferCompositeFramePointers = new List<ImageDescription> { loadedImageDescription };
					loadedPageColumns = (int)numberColumns.Value;
					loadedPageRows = (int)numberRows.Value;
					frameWidth = BackBufferSize.Width;
					frameHeight = BackBufferSize.Height;
					// TODO: Possibly remove/dispose textures before updating.
					foreach (ImageDescription oldDescription in compositeFramePointers)
						imageDescriptionsToClear.Add(oldDescription);
					// Hide/clear animation by named set.
					this.Invoke((MethodInvoker)delegate { updateSetList(noOverwriteStartEndFrames); });
					//
					compositeFramePointers = backBufferCompositeFramePointers;
					// Set file loaded message in status.
					setStatus(String.Format("Image Loaded ({0})", new object[] { loadedImageLastWrite }), formHandle);
				}
				else
					SetEditLoadedFrameEnabled(formHandle, true);
				#endregion
				// Re-calculate individual box width.
				boxWidth = loadedImageDescription.Width / loadedPageColumns;
				boxHeight = loadedImageDescription.Height / loadedPageRows;
				setMaxCells(loadedPageColumns * loadedPageRows, formHandle);
				setRows(loadedPageRows, formHandle);
				setColumns(loadedPageColumns, formHandle);
				// Run colors.
				SupportFunctions.RunColorsForConstructedPalette(file);
				// Resize window.
				resizeMainFormByAndSetAspectIncrements(formHandle, noOverwriteStartEndFrames);
			}
			if (focusOnDrawingAreaAfter)
				FocusOnRenderControl(this);
		}

		private void loadImageFromFile(string file)
		{
			//
			loadedImageLastWrite = DateTime.Now;
			loadedImageDescription.Filename = file;
			loadedImageDescription.IsPlaceholder = false;
			loadedImageDescription.PushToContext = false;
			loadedImageDescription.MakeBackgroundTransparent = (format != null) ? true : false;
			loadedImageDescription.resetBackgroundColor();
			//
			backgroundColor = loadedImageDescription.BackgroundColor;
			loadedImageDescription.replaceWithBitmap(file);
		}

		private void resizeMainFormByAndSetAspectIncrements(Main formHandle, bool noOverwriteStartEndFrames)
		{
			// Find safe increments for keep aspect ratio.
			double baseAspect = Math.Round((double)loadedImageDescription.Height / (double)loadedImageDescription.Width, 2);
			constrictWidthToIncrement = baseAspect;
			while (constrictWidthToIncrement % 1.0 > 0.000001)
				constrictWidthToIncrement += baseAspect;
			baseAspect = Math.Round((double)loadedImageDescription.Width / (double)loadedImageDescription.Height, 2);
			constrictHeightToIncrement = baseAspect;
			while (constrictHeightToIncrement % 1.0 > 0.000001)
				constrictHeightToIncrement += baseAspect;
			// Resize form.
			if (!noOverwriteStartEndFrames)
				resizeForm(m: formHandle);
		}

		#region Thread-safe Windows Form alteration functions.
		public void setAutoUpdate(bool autoUpdate, Main m = null)
		{
			if (m != null)
			{
				m.Invoke((MethodInvoker)delegate()
				{
					m.autoUpdateYesOrNo.Checked = autoUpdate;
				});
			}
		}

		private void setNoSampling(bool useNoSampling, Main m = null, bool suppressEvent = false)
		{
			if (m != null && m.IsHandleCreated)
			{
				m.Invoke((MethodInvoker)delegate()
				{
					suppressNoSamplingRedraw = suppressEvent;
					{
						m.useNoSamplingCheckBox.Checked = useNoSampling;
						m.forceRedraw = true;
					}
					suppressNoSamplingRedraw = false;
				});
			}
		}

		private void SetEditLoadedFrameEnabled(Main m, bool value)
		{
			try
			{
				if (m != null && m.IsHandleCreated)
				{
					m.Invoke((MethodInvoker)delegate
					{
						m.editLoadedFormatToolStripMenuItem.Enabled = value;
					});
				}
			}
			catch (Exception e) { }
		}

		private void RenderControlDraw(Main m)
		{
			try
			{
				if (!m.ignoreAnyFutureRequests && !m.IsDisposed && !m.RenderControl.IsDisposed)
					m.Invoke((MethodInvoker)delegate
					{
						m.RenderControl.Draw();
					});
			}
			catch (Exception e) { }
		}

		private void FocusOnRenderControl(Main m)
		{
			if (!threadNeedsToDie)
			{
				try
				{
					if (m != null && m.IsHandleCreated)
					{
						m.Invoke((MethodInvoker)delegate
						{
							m.RenderControl.Focus();
						});
					}
				}
				catch (Exception e) { }
			}
		}

		private void makeRenderControlCurrent(Main m)
		{
			if (!threadNeedsToDie)
			{
				if (m != null && m.IsHandleCreated)
				{
					m.Invoke((MethodInvoker)delegate
					{
						m.RenderControl.MakeCurrent();
					});
				}
			}
		}

		private void setTargetMS(int s, Main m)
		{
			if (!threadNeedsToDie)
			{
				s = (s > 1) ? s : 1;
				if (m != null && m.IsHandleCreated)
				{
					m.Invoke((MethodInvoker)delegate
					{
						m.animationTargetMS.Value = s;
					});
				}
			}
		}

		private void setDimensions(int w, int h, Main m)
		{
			if (m != null && !threadNeedsToDie && m.IsHandleCreated)
			{
				m.Invoke((MethodInvoker)delegate
				{
					m.Width = w;
					m.Height = h;
				});
			}
		}

		public void setStatus(string s, Main m)
		{
			if (m != null && !threadNeedsToDie && m.IsHandleCreated)
			{
				try
				{
					m.Invoke((MethodInvoker)delegate
					{
						m.toolStripStatusLabel.Text = s;
					});
				}
				catch
				{
					threadNeedsToDie = true;
				}
			}
		}

		private void setEndFrame(int i, Main m)
		{
			if (m != null && !threadNeedsToDie && m.IsHandleCreated)
			{
				m.Invoke((MethodInvoker)delegate
				{
					if (i > m.animationTargetEndFrame.Maximum)
					{
						m.animationTargetEndFrame.Maximum = i;
						m.animationTargetEndFrame.Value = i;
					}
					else
						m.animationTargetEndFrame.Value = i;
				});
			}
		}

		private void setStartFrame(int i, Main m)
		{
			if (m != null && !threadNeedsToDie && m.IsHandleCreated)
			{
				m.Invoke((MethodInvoker)delegate
				{
					m.animationTargetStartFrame.Value = i;
				});
			}
		}

		private void setRows(int i, Main m)
		{
			if (m != null && !threadNeedsToDie && m.IsHandleCreated)
			{
				m.Invoke((MethodInvoker)delegate
				{
					m.numberRows.Value = i;
				});
			}
		}

		private void setColumns(int i, Main m)
		{
			if (m != null && !threadNeedsToDie && m.IsHandleCreated)
			{
				m.Invoke((MethodInvoker)delegate
				{
					m.numberColumns.Value = i;
				});
			}
		}

		public int getRows()
		{
			return (int)this.numberRows.Value;
		}

		public int getColumns()
		{
			return (int)this.numberColumns.Value;
		}

		private void setMaxCells(int i, Main m)
		{
			if (m != null && !threadNeedsToDie && m.IsHandleCreated)
			{
				m.Invoke((MethodInvoker)delegate
				{
					m.numberMaxCells.Value = i;
				});
			}
		}

		private void setTitle(string s, Main m)
		{
			if (m != null && !threadNeedsToDie && m.IsHandleCreated)
			{
				m.Invoke((MethodInvoker)delegate
				{
					m.Text = s;
				});
			}
		}

		public void loadImageAsNamedAttachment(int id = 0, Bitmap bitmap = null, Main m = null, bool reloadCompositeFrames = false)
		{
			if (!threadNeedsToDie && m != null && m.IsHandleCreated)
			{
				m.Invoke((MethodInvoker)delegate
				{
					m.RenderControl.MakeCurrent();
					//
					ImageDescription thisDescription = new ImageDescription(id, bitmap);
					//
					if (!m.namedAttachments.ContainsKey(thisDescription.Id))
						m.namedAttachments.Add(thisDescription.Id, thisDescription);
					else
						m.namedAttachments[id] = thisDescription;
					//
					if (reloadCompositeFrames)
						m.reloadCompositeFramesWithTheGivenNamedAttachmentPointId(id);
				});
			}
		}

		private void launchLoadSpriteSheetOpenFileDialog(Main m, object sender, EventArgs e)
		{
			// Invoke the call to the preview window and open file dialog controls on the GUI thread.
			try
			{
				if (m != null && m.IsHandleCreated)
				{
					m.Invoke((MethodInvoker)delegate
					{
						// Get initial directory.
						if (Properties.Settings.Default.spriteDirectory != "")
							m.spriteSheetOpenFileDialog.InitialDirectory = Properties.Settings.Default.spriteDirectory;
						// Get result of dialog.
						DialogResult d;
						if (oglConfiguration.MajorVersion >= 3)
							d = m.spriteSheetOpenFileDialog.ShowDialog(m.previewWindow);
						else
							d = m.spriteSheetOpenFileDialog.ShowDialog();
						//
						if (d == DialogResult.OK)
						{
							Properties.Settings.Default.spriteDirectory = Path.GetDirectoryName(spriteSheetOpenFileDialog.FileName);
							Properties.Settings.Default.Save();
							// Launch the update.
							Thread loadImageForDisplayThread = new Thread(new ThreadStart(delegate()
							{
								loadImageForDisplay(spriteSheetOpenFileDialog.FileName, sender: sender, formHandle: m);
							}));
							loadImageForDisplayThread.Name = "Load Image for Display";
							loadImageForDisplayThread.Start();
						}
					});
				}
			}
			catch (Exception exception) { }
		}
		#endregion

		private void recalculateOpenFileDialogFilter(Main m = null)
		{
			string defaultFormatCompilationString = "Compiling file formats...{0}";
			string numericalString = "{0}/{1}";
			setStatus(string.Format(defaultFormatCompilationString, new string[] { "" }), m);
			List<string[]> availableTypes = new List<string[]> { new string[] { "", "Images" } };
			List<string> availableFormatsByName = SupportFunctions.GetAvailableFormats(baseLocation);
			// Prepare to update the status.
			int formatCount = availableFormatsByName.Count;
			int i = 1;
			//
			if (formatCount > 0)
			{
				foreach (string formatExtension in availableFormatsByName)
				{
					// Update the status.
					string thisNumericalString = string.Format(numericalString, new object[] { i++, formatCount });
					setStatus(string.Format(defaultFormatCompilationString, thisNumericalString), m);
					string name = SupportFunctions.GetNameFromSpriteFormatXMLDocument(baseLocation, formatExtension);
					availableTypes.Add(new string[] { formatExtension, name });
				}
			}
			setStatus("Ready.", m);
			//
			List<string> fileTypes = new List<string> { "*{0}.bmp", "*{1}.png" };
			string defaultString = "{0} ({1})|{2}";
			List<string> filterLines = new List<string>();
			foreach (string[] typeArray in availableTypes)
			{
				string type = (typeArray[0].Length > 0) ? "." + typeArray[0] : "", name = typeArray[1];
				string nameString = (name.Length > 0) ? name + " " : "";
				string extensions = string.Format(string.Join(", ", fileTypes.ToArray()), new object[] { type, type });
				string filters = string.Format(string.Join(";", fileTypes.ToArray()), new object[] { type, type });
				string thisLine = string.Format(defaultString, new object[] { nameString, extensions, filters });
				filterLines.Add(thisLine);
			}
			spriteSheetOpenFileDialog.Filter = string.Join("|", filterLines.ToArray());
		}

		private void loadImageContextMenuButton_Click(object sender, EventArgs e)
		{
			// 
			Main m = this;
			Thread loadImageFileDialogThread = new Thread(new ThreadStart(delegate()
			{
				// Get all types (note: bottlenecks the process).
				recalculateOpenFileDialogFilter(m);
				// Launch the open file dialog.
				launchLoadSpriteSheetOpenFileDialog(m, sender, e);
			}));
			loadImageFileDialogThread.Name = "Load Image File Dialog";
			loadImageFileDialogThread.Start();
		}

		private void keepAspectRatioYesOrNo_CheckedChanged(object sender, EventArgs e)
		{
			_lockRatio = (!keepAspectRatioYesOrNo.Checked) ? false : true;
		}

		private void numberRows_ValueChanged(object sender, EventArgs e)
		{
			rows = (int)numberRows.Value;
			numberMaxCells.Value = rows * columns;
		}

		private void numberColumns_ValueChanged(object sender, EventArgs e)
		{
			columns = (int)numberColumns.Value;
			numberMaxCells.Value = rows * columns;
		}

		private void numberMaxCells_ValueChanged(object sender, EventArgs e)
		{
			animationTargetStartFrame.Value = (animationTargetStartFrame.Value > numberMaxCells.Value) ? numberMaxCells.Value : animationTargetStartFrame.Value;
			animationTargetEndFrame.Value = (animationTargetEndFrame.Value > numberMaxCells.Value) ? numberMaxCells.Value : animationTargetEndFrame.Value;
			animationTargetStartFrame.Maximum = animationTargetEndFrame.Maximum = numberMaxCells.Value;
			if (compositeFramePointers != null && compositeFramePointers.Count == 1)
			{
				boxWidth = frameWidth = compositeFramePointers[0].Width / (int)numberColumns.Value;
				boxHeight = frameHeight = compositeFramePointers[0].Height / (int)numberRows.Value;
			}
			updateLoadedSet();
		}

		private void animateByRangeRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			// If animation is already on and animate by range is selected, switch to format's target MS (may be different before this change because of named set variances).
			if (animationYesOrNo.Checked && animateByRangeRadioButton.Checked)
				animationTargetMS.Value = targetMS;
			//
			updateLoadedSet();
		}

		private void animateByNamedSetRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			updateLoadedSet();
		}

		private void namedSetComboBox_SelectionChanged(object sender, EventArgs e)
		{
			updateLoadedSet();
		}

		private void animationTargetStartFrame_ValueChanged(object sender, EventArgs e)
		{
			updateLoadedSet();
		}

		private void animationTargetEndFrame_ValueChanged(object sender, EventArgs e)
		{
			updateLoadedSet();
		}

		private void animationYesOrNo_CheckedChanged(object sender, EventArgs e)
		{
			updateLoadedSet();
		}

		private void updateLoadedSet()
		{
			// Clear out the list of composite frames to draw as an animation.
			previousSet.Clear();
			loadedSet.Clear();
			nextSet.Clear();
			//
			LinkedList<int> previousList = new LinkedList<int>(), list = new LinkedList<int>(), nextList = new LinkedList<int>();
			// If the named set is available, use that.
			if (animateByNamedSetRadioButton.Checked && namedSetComboBox.Text != "")
			{
				int namedSetIndex = namedSetComboBox.SelectedIndex;
				if (namedSetIndex <= -1)
					namedSetIndex = namedSetComboBox.FindString(namedSetComboBox.Text);
				//
				if (namedSetIndex >= 0 && namedSetIndex < format.CompositeFrameSetList.Count)
				{
					foreach (Shapes.CompositeFrameCall call in format.CompositeFrameSetList[namedSetIndex].compositeFrameCalls)
					{
						int id = int.Parse(call.id);
						previousList.AddLast(id);
						list.AddLast(id);
						nextList.AddLast(id);
					}
				}
			}
			// Otherwise, use the start and end frames as references.
			else
			{
				if (animationTargetStartFrame.Value <= (int)animationTargetEndFrame.Value)
					for (int i = (int)animationTargetStartFrame.Value; i <= (int)animationTargetEndFrame.Value; i++)
					{
						previousList.AddLast(i);
						list.AddLast(i);
						nextList.AddLast(i);
					}
				else
					for (int i = (int)animationTargetStartFrame.Value; i >= (int)animationTargetEndFrame.Value; i--)
					{
						previousList.AddLast(i);
						list.AddLast(i);
						nextList.AddLast(i);
					}
			}
			// Previous.
			int last = previousList.Last.Value;
			previousList.RemoveLast();
			previousList.AddFirst(last);
			previousSet = previousList;
			// Current.
			loadedSet = list;
			// Next.
			int first = nextList.First.Value;
			nextList.RemoveFirst();
			nextList.AddLast(first);
			nextSet = nextList;
			// Update the enumerator (used with the preview window and export feature).
			previousEnumerator = previousSet.GetEnumerator();
			enumerator = loadedSet.GetEnumerator();
			nextEnumerator = nextSet.GetEnumerator();
			// Handle animate by named set.
			if (animationYesOrNo.Checked)
			{
				if (animateByNamedSetRadioButton.Checked)
				{
					// Attempt to get the index (occasionally fails).
					int namedSetIndex = namedSetComboBox.SelectedIndex;
					if (namedSetIndex <= -1)
						namedSetIndex = namedSetComboBox.FindString(namedSetComboBox.Text);
					if (namedSetIndex >= 0 && namedSetIndex < format.CompositeFrameSetList.Count)
						animationTargetMS.Value = (format.CompositeFrameSetList[namedSetIndex].targetMS != null) ? format.CompositeFrameSetList[namedSetIndex].targetMS.Value : targetMS;
				}
			}
		}

		ColorControl.ColorControl rawOverlayColorDialog = null;
		private void frameOverlayColorSwatch_Click(object sender, EventArgs e)
		{
			if (rawOverlayColorDialog == null)
				rawOverlayColorDialog = new ColorControl.ColorControl();
			//
			rawOverlayColorDialog.Color = Properties.Settings.Default.rawOverlayColor;
			rawOverlayColorDialog.PreviousColor = Properties.Settings.Default.rawOverlayColor;
			//
			unloadDrawingFeatureTimers();
			//
			if (rawOverlayColorDialog.ShowDialog() == DialogResult.OK)
			{
				colorSwatch.BackColor = rawOverlayColorDialog.Color;
				Properties.Settings.Default.rawOverlayColor = colorSwatch.BackColor;
				Properties.Settings.Default.Save();
			}
			//
			loadFeatureTimers(this);
			forceRedraw = true;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void exportActiveFramesAsGIFToolStripMenuItem_Click(object sender, EventArgs e, int size)
		{
			string path = SupportFunctions.Combine(baseLocation,  @"ImageMagick-6.7.2");
			if (loadedImageDescription.Filename != "")
			{
				string resizeFilter = (Sampling == Gl.GL_NEAREST) ? "Point" : "Cubic";
				string temporaryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
				Directory.CreateDirectory(temporaryPath);
				if (Directory.Exists(temporaryPath))
				{
					#region Copy out frames.
					try
					{
						if (compositeFramePointers.Count > 1)
						{
							int r = 0;
							System.Collections.IEnumerator exportEnumerator = enumerator;
							exportEnumerator.Reset();
							while (exportEnumerator.MoveNext())
							{
								int i = (int)exportEnumerator.Current - 1;
								Bitmap image = compositeFramePointers[i].SignificantBitmap;
								string file = string.Format("spanim-{0}-{1:000}", new object[] { Path.GetFileNameWithoutExtension(loadedImageDescription.Filename), r });
								string fileAndExtension = string.Format("spanim-{0}-{1:000}{2}", new object[] { Path.GetFileNameWithoutExtension(loadedImageDescription.Filename), r, Path.GetExtension(loadedImageDescription.Filename) });
								string fileExtensionAndPath = Path.Combine(temporaryPath, fileAndExtension);
								string outputFileExtensionAndPath = Path.Combine(temporaryPath, string.Format("{0}.gif", file));
								try
								{
									image.Save(fileExtensionAndPath);
								}
								finally
								{
									string arguments = string.Format(@"""{0}"" -filter {3} -resize {1}% ""{2}""", fileExtensionAndPath, size, outputFileExtensionAndPath, resizeFilter);
									var startInfo = new ProcessStartInfo
									{
										Arguments = arguments,
										FileName = SupportFunctions.Combine(path, "convert.exe"),
										UseShellExecute = false,
										CreateNoWindow = true
									};
									Process.Start(startInfo).WaitForExit();
								}
								r++;
							}
						}
						else if (compositeFramePointers.Count == 1)
						{
							using (Bitmap bm2 = compositeFramePointers[0].SignificantBitmap)
							{
								Rectangle rect2 = new Rectangle(0, 0, bm2.Width, bm2.Height);
								System.Drawing.Imaging.ColorPalette cp = bm2.Palette;
								BitmapData bm2Data = bm2.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
								int r = 0;
								for (int i = (int)animationTargetStartFrame.Value - 1; i < (int)animationTargetEndFrame.Value; i++)
								{
									int exportAdvanceRows = i / (int)numberColumns.Value;
									int exportAdvanceColumns = i % (int)numberColumns.Value;
									Bitmap image = bm2.Clone(new Rectangle(exportAdvanceColumns * frameWidth, exportAdvanceRows * frameHeight, frameWidth, frameHeight), bm2.PixelFormat);
									string file = string.Format("spanim-{0}-{1:000}", new object[] { Path.GetFileNameWithoutExtension(loadedImageDescription.Filename), r });
									string fileAndExtension = string.Format("spanim-{0}-{1:000}{2}", new object[] { Path.GetFileNameWithoutExtension(loadedImageDescription.Filename), r, Path.GetExtension(loadedImageDescription.Filename) });
									string fileExtensionAndPath = Path.Combine(temporaryPath, fileAndExtension);
									string outputFileExtensionAndPath = Path.Combine(temporaryPath, string.Format("{0}.gif", file));
									try
									{
										image.Save(fileExtensionAndPath);
									}
									finally
									{
										string arguments = string.Format(@"""{0}"" -filter {3} -resize {1}% ""{2}""", fileExtensionAndPath, size, outputFileExtensionAndPath, resizeFilter);
										var startInfo = new ProcessStartInfo
										{
											Arguments = arguments,
											FileName = SupportFunctions.Combine(path, "convert.exe"),
											UseShellExecute = false,
											CreateNoWindow = true
										};
										Process.Start(startInfo).WaitForExit();
									}
									r++;
								}
							}
						}
					}
					finally
					{
						try
						{
							string tail = (int)animationTargetStartFrame.Value + "-" + (int)animationTargetEndFrame.Value;
							// Handle animate by named set.
							if (animateByNamedSetRadioButton.Checked)
							{
								// Attempt to get the index (occasionally fails).
								int namedSetIndex = namedSetComboBox.SelectedIndex;
								if (namedSetIndex <= -1)
									namedSetIndex = namedSetComboBox.FindString(namedSetComboBox.Text);
								tail = System.Text.RegularExpressions.Regex.Replace(format.CompositeFrameSetList[namedSetIndex].name, @"[.<>:""\/|?*]", "-");
							}
							string inputMask = Path.Combine(temporaryPath, "spanim-" + System.IO.Path.GetFileNameWithoutExtension(loadedImageDescription.Filename) + "-*.gif");
							string outputFile = System.IO.Path.GetFileNameWithoutExtension(loadedImageDescription.Filename) + "-animation-" + size + "-" + tail + ".gif";
							string arguments = string.Format(@"-dispose 2 -delay {0} -loop 0 ""{1}"" ""{2}""", (int)animationTargetMS.Value / 10, inputMask, Path.Combine(Path.GetDirectoryName(loadedImageDescription.Filename), outputFile));
							var startInfo = new ProcessStartInfo
							{
								Arguments = arguments,
								FileName = SupportFunctions.Combine(path, "convert.exe"),
								UseShellExecute = false,
								CreateNoWindow = true
							};
							Process.Start(startInfo).WaitForExit();
						}
						finally
						{
							System.IO.Directory.Delete(temporaryPath, true);
						}
					}
					#endregion
				}
				else
					setStatus("EXPORT ERROR: Could not create a temporary folder during export to GIF format.", this);
			}
		}

		private void customPercentToolStripTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			// Allow navigation keyboard arrows.
			switch (e.KeyCode)
			{
				case Keys.Up:
				case Keys.Down:
				case Keys.Left:
				case Keys.Right:
				case Keys.PageUp:
				case Keys.PageDown:
					e.SuppressKeyPress = false;
					return;
				default:
					break;
			}
			// Block non-number characters.
			char currentKey = (char)e.KeyCode;
			bool modifier = e.Control || e.Alt || e.Shift;
			bool nonNumber = char.IsLetter(currentKey) || char.IsSymbol(currentKey) || char.IsWhiteSpace(currentKey) || char.IsPunctuation(currentKey);
			if (!modifier && nonNumber)
				e.SuppressKeyPress = true;
			// Handle pasted Text.
			if (e.Control && e.KeyCode == Keys.V)
			{
				// Preview paste data (removing non-number characters).
				string pasteText = Clipboard.GetText();
				string strippedText = "";
				for (int i = 0; i < pasteText.Length; i++)
					if (char.IsDigit(pasteText[i]))
						strippedText += pasteText[i].ToString();
				//
				if (strippedText != pasteText)
				{
					// There were non-numbers in the pasted text.
					e.SuppressKeyPress = true;
					// OPTIONAL: Manually insert text stripped of non-numbers.
					TextBox me = (TextBox)sender;
					int start = me.SelectionStart;
					string newTxt = me.Text;
					newTxt = newTxt.Remove(me.SelectionStart, me.SelectionLength); //remove highlighted text
					newTxt = newTxt.Insert(me.SelectionStart, strippedText); //paste
					me.Text = newTxt;
					me.SelectionStart = start + strippedText.Length;
				}
				else
					e.SuppressKeyPress = false;
			}
		}

		private void exportAnimationAtCustomPercentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.DoEvents();
			//
			exportActiveFramesAsGIFToolStripMenuItem_Click(sender, e, int.Parse(customPercentToolStripTextBox.Text));
		}

		private void exportAnimationAt100PercentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.DoEvents();
			//
			exportActiveFramesAsGIFToolStripMenuItem_Click(sender, e, 100);
		}

		private void exportAnimationAt200PercentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.DoEvents();
			//
			exportActiveFramesAsGIFToolStripMenuItem_Click(sender, e, 200);
		}

		private void constructedPaletteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.DoEvents();
			//
			new Palette(pixelCount: loadedImageDescription.Width * loadedImageDescription.Height, backgroundColor: backgroundColor).Show(previewWindow);
		}

		private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (oglConfiguration.MajorVersion >= 2)
				Application.DoEvents();
			//
			if (creditsWindow == null)
			{
				creditsWindow = new Credits(this);
				creditsWindow.Show(previewWindow);
				//
				Application.DoEvents();
			}
			else
				creditsWindow.Focus();
		}

		private void availableFormatsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.DoEvents();
			//
			if (availableFormatsWindow == null)
			{
				availableFormatsWindow = new AvailableFormats(this);
				availableFormatsWindow.Show(previewWindow);
			}
			else availableFormatsWindow.Focus();
		}

		private void RenderControl_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
				previewAreaContextMenuStrip.Show(Cursor.Position);
		}

		EditSelectedFrame esf = null;
		private void editSelectedFrameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.DoEvents();
			//
			esf = new EditSelectedFrame(this);
			int index = CurrentCompositeFrame - 1;
			if (compositeFrameSoundCues.Count > index)
				esf.UsedSoundList = compositeFrameSoundCues[index];
			esf.Show(previewWindow);
		}

		private void Main_FormClosed(object sender, FormClosedEventArgs e)
		{
		}

		private void usePreviousFrameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.DoEvents();
			//
			new EditSelectedFrame(this, PreviousCompositeFrame).Show();
		}

		private void clearNamedAttachmentPoints()
		{
			foreach (int key in namedAttachments.Keys)
			{
				ImageDescription desc = namedAttachments[key];
				if (desc.ContextId > 0)
					Gl.glDeleteTextures(1, new int[] { desc.ContextId });
			}
			namedAttachments.Clear();
		}

		private void signalAvailableAttachmentsWindowToUpdate()
		{
			if (availableAttachmentsWindow != null)
				availableAttachmentsWindow.UpdateDataSource(availableAttachmentsWindow);
		}

		public void loadCompositeFrames(Main formHandle = null, int[] loadCompositeFramesInList = null, bool noOverwriteStartEndFrames = false)
		{
			if (format != null)
			{
				lock (format)
				{
					bool usedBlendModeEffect = false;
					List<int> loadSelectedFrames = new List<int>();
					backBufferCompositeFramePointers = new List<ImageDescription>();
					Rectangle backBufferRectangle = new Rectangle(Point.Empty, BackBufferSize);
					// Decide which frames are to be loaded/reloaded.
					if (loadCompositeFramesInList == null)
					{
						for (int i = 1; i <= format.TargetRows * format.TargetColumns; i++)
						{
							loadSelectedFrames.Add(i);
							backBufferCompositeFramePointers.Add(new ImageDescription(i, sampling: Sampling, pushToContext: false));
						}
					}
					else
					{
						backBufferCompositeFramePointers = compositeFramePointers;
						loadSelectedFrames = new List<int>();
						for (int i = 0; i < loadCompositeFramesInList.Length; i++)
						{
							int id = loadCompositeFramesInList[i];
							loadSelectedFrames.Add(id);
						}
					}
					this.Invoke((MethodInvoker)delegate { updateSetList(noOverwriteStartEndFrames); });
					// Selectively load all named attachment points for edit format feature.
					List<Shapes.NamedAttachmentPoint> pointsInFormat = format.AvailableNamedAttachmentPointsList;
					pointsInFormat.ForEach(delegate(Shapes.NamedAttachmentPoint point)
					{
						// Update the data store.
						Shapes.NamedAttachmentPoint existingPoint = availableNamedAttachmentPointsList.Find(item => item != null && item.id == point.id);
						if (existingPoint != null)
							existingPoint = point;
						else
						{
							availableNamedAttachmentPointsList.Add(point);
							// Store a placeholder for the image only if nothing is already stored (cache gets cleared on loading a different format).
							if (!namedAttachments.ContainsKey(point.id))
								loadImageAsNamedAttachment(id: point.id, m: formHandle);
						}
					});
					// Update after everything is loaded.
					signalAvailableAttachmentsWindowToUpdate();
					// Load all sounds.
					compositeFrameSoundCues.Clear();
					foreach (Sound s in format.AvailableSounds)
					{
						List<int> usedInCompositeFrames = format.CompositeFramesBySoundName[s.name];
						// If the sound is actually used, then initialize it to be played. Otherwise, just save its description.
						if (usedInCompositeFrames.Count > 0)
						{
							string soundPath = SupportFunctions.Combine(baseLocation, "formats", loadedFormat, s.filename);
							int imageWidth = Math.Min(4096, oglConfiguration.MaximumTextureSize);
							SupportFunctions.generateSoundBuffers(name: s.name, filename: soundPath, colorName: s.colorName, color: s.color, imageWidth: imageWidth, handler: delegate(bool success, Sound thisSound)
							{
								// Add the sound to be used.
								if (success)
								{
									//int index = format.AvailableSounds.FindIndex(item => item.name == thisSound.name);
									usedInCompositeFrames.ForEach(delegate(int frame)
									{
										if (compositeFrameSoundCues.Count < frame + 1)
											for (int i = compositeFrameSoundCues.Count; i < frame + 1; i++)
												compositeFrameSoundCues.Add(new List<Sound>());
										if (compositeFrameSoundCues.Count > frame && frame >= 0)
											compositeFrameSoundCues[frame].Add(thisSound);
									});
								}
							});
						}
					}
					// Iterate over all composite frame slots.
					for (int i = 0; i < format.TargetRows; i++)
					{
						for (int r = 1; r <= format.TargetColumns; r++)
						{
							// Get the composite frame id of the slot.
							int thisCompositeFrameId = i * format.TargetColumns + r;
							// If there's a composite frame for with the associated id.
							if (loadSelectedFrames.Exists(item => item.Equals(thisCompositeFrameId)))
							{
								int indexInArray = thisCompositeFrameId - 1;
								if (compositeFramePointers.Count > indexInArray)
									imageDescriptionsToClear.Add(compositeFramePointers[indexInArray]);
								// Try to ignore work on a thread that should have been disposed properly.
								if (!threadNeedsToDie)
								{
									//
									setStatus(String.Format("Compiling frame: {0}/{1}.", new object[] { thisCompositeFrameId, TotalCompositeFrames }), formHandle);
									// Get composited image.
									Bitmap backBuffer = renderer.renderCompositeFrameToBitmap(backBufferRectangle, thisCompositeFrameId, format, namedAttachments, loadedImageDescription);
									// Works:
									try
									{
										// Don't immediately push the image to the context (the context/right place in the pipeline won't be reliably accessible in a thread).
										backBufferCompositeFramePointers[indexInArray].PushToContext = false;
										backBufferCompositeFramePointers[indexInArray].BackgroundColor = loadedImageDescription.BackgroundColor;
										backBufferCompositeFramePointers[indexInArray].MakeBackgroundTransparent = true;
										backBufferCompositeFramePointers[indexInArray].replaceWithBitmap(bitmap: backBuffer);
									}
									catch (Exception) { }
								}
							}
						}
					}
					// Update interface after load complete.
					updateAnimationRelatedControls(formHandle, noOverwriteStartEndFrames);
					// Update data related to size and memory locations.
					frameWidth = BackBufferSize.Width;
					frameHeight = BackBufferSize.Height;
					// TODO: Perhaps old textures need to be disposed/removed from the graphics context.
					compositeFramePointers = backBufferCompositeFramePointers;
					string sizeWarning = determineSizeWarnings(loadedImageDescription, Format);
					// Set file loaded message in status.
					if (sizeWarning != null)
						setStatus(String.Format("Image Loaded ({0}, {1})", new object[] { loadedImageLastWrite, sizeWarning }), formHandle);
					else
						setStatus(String.Format("Image Loaded ({0})", new object[] { loadedImageLastWrite }), formHandle);
				}
			}
		}

		private string determineSizeWarnings(ImageDescription image, SupportClasses.Format format)
		{
			if (format.BaseWidth != image.SignificantWidth || format.BaseHeight != image.SignificantHeight)
				return "WARNING: Loaded image has different dimensions than the format.";
			return null;
		}

		private void loadOrReloadFormat()
		{
			// Set file loading message in status.
			setStatus("Parsing sprite description file...", this);
			// Read in format file (XML).
			this.Format = new SupportClasses.Format(loadedFormat);
			loadedFormatLastWrite = format.LastWrite;
		}

		private void updateAnimationRelatedControls(Main formHandle, bool noOverwriteStartEndFrames)
		{
			if (!noOverwriteStartEndFrames)
			{
				setEndFrame(format.TargetEnd, formHandle);
				setStartFrame(format.TargetStart, formHandle);
				setTargetMS(targetMS, formHandle);
			}
		}

		private void updateSetList(bool noOverwriteStartEndFrames = false)
		{
			if (format != null && format.CompositeFrameSetList.Count > 0)
			{
				namedSetComboBox.Items.Clear();
				foreach (Shapes.CompositeFrameSet item in format.CompositeFrameSetList)
					namedSetComboBox.Items.Add(item.name);
				animateByRangeRadioButton.Enabled = true;
				animateByNamedSetRadioButton.Enabled = true;
				namedSetComboBox.Enabled = true;
				if (!noOverwriteStartEndFrames)
				{
					namedSetComboBox.SelectedItem = namedSetComboBox.Items[0];
					animateByNamedSetRadioButton.Focus();
					animateByNamedSetRadioButton.Checked = true;
					animateByRangeRadioButton.Checked = false;
				}
				animateByRangeRadioButton.Show();
				animateByNamedSetRadioButton.Show();
				namedSetComboBox.Show();
				if ((int)optionsTableLayoutPanel.RowStyles[3].Height != 175)
				{
					optionsTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, 175F);
					animationTableLayoutPanel.Height = (int)optionsTableLayoutPanel.RowStyles[3].Height;
					resetTableHeight();
				}
			}
			else
			{
				animateByRangeRadioButton.Enabled = false;
				animateByNamedSetRadioButton.Enabled = false;
				animateByRangeRadioButton.Checked = true;
				animateByNamedSetRadioButton.Checked = false;
				namedSetComboBox.Enabled = false;
				animateByRangeRadioButton.Hide();
				animateByNamedSetRadioButton.Hide();
				namedSetComboBox.Hide();
				if ((int)optionsTableLayoutPanel.RowStyles[3].Height != 102)
				{
					optionsTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, 102F);
					animationTableLayoutPanel.Height -= (int)optionsTableLayoutPanel.RowStyles[3].Height;
					resetTableHeight();
				}
			}
		}

		private void resetTableHeight()
		{
			int total = 1;
			for (int i = 0; i < optionsTableLayoutPanel.RowStyles.Count - 1; i++)
				total += (int)optionsTableLayoutPanel.RowStyles[i].Height;
			optionsTableLayoutPanel.Height = total;
		}

		private void Main_Move(object sender, EventArgs e)
		{
			layoutOverlays();
		}

		private void Main_Activated(object sender, EventArgs e)
		{
			this.Invalidate();
		}

		private void beginNewFormatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AddOrEditFormat(this).Show(previewWindow);
		}

		private void editLoadedFormatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AddOrEditFormat(this, editLoaded: true, returnUpdateOnChangeTo: autoUpdateOnFormatChange.Checked).Show(previewWindow);
			autoUpdateOnFormatChange.Checked = true;
		}

		private void useNoSamplingCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (!suppressNoSamplingRedraw)
			{
				// Set the sampling for each composite frame if the renderer does not require a reset. Otherwise, re-do the images for each composite frame.
				if (!renderer.RequiresReloadOnSamplingChange)
				{
					for (int i = 0; i < compositeFramePointers.Count; i++)
						compositeFramePointers[i].Sampling = Sampling;
				}
				else
				{
					Thread samplingHasChangedThread = new Thread(new ThreadStart(delegate()
					{
						loadCompositeFrames(this, noOverwriteStartEndFrames: true);
					}));
					samplingHasChangedThread.Name = "Sampling Has Changed";
					samplingHasChangedThread.Start();
				}
			}
			forceRedraw = true;
		}

		#region Button Panel Functions
		private void displaySettingsButtonPanel_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				displayButtonPanel.numberOfClicks = 0;
				displayButtonPanel.lastClick = Environment.TickCount & Int32.MaxValue;
				System.Timers.Timer t = new System.Timers.Timer(200);
				t.Elapsed += new System.Timers.ElapsedEventHandler(delegate(object nsender, System.Timers.ElapsedEventArgs ne)
				{
					if (displayButtonPanel.numberOfClicks < 2)
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleDisplaySettingsButtonPanelClick(true);
						});
					}
					else
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleDisplaySettingsButtonPanelClick(false);
						});
					}
					t.Enabled = false;
				});
				t.Enabled = true;
			}
		}

		public void handleDisplaySettingsButtonPanelClick(bool fire)
		{
			if (fire)
			{
				if (optionsTableLayoutPanel.RowStyles[1].Height > 0)
				{
					optionsTableLayoutPanel.Height -= (int)optionsTableLayoutPanel.RowStyles[1].Height;
					optionsTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
				}
				else
				{
					optionsTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, heightOfDisplayBody);
					optionsTableLayoutPanel.Height += (int)optionsTableLayoutPanel.RowStyles[1].Height;
				}
			}
		}

		private void displaySettingsButtonPanel_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				displayButtonPanel.numberOfClicks = 2;
				optionsTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, heightOfDisplayBody);
				optionsTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
				optionsTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Absolute, 0F);
				optionsTableLayoutPanel.Height = (int)optionsTableLayoutPanel.RowStyles[1].Height + getButtonPanelHeaderHeights();
			}
		}

		private int getButtonPanelHeaderHeights()
		{
			return displayButtonPanel.Height + animationButtonPanel.Height + subdivisionButtonPanel.Height;
		}

		private void animationButtonPanel_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				animationButtonPanel.numberOfClicks = 0;
				System.Timers.Timer t = new System.Timers.Timer(200);
				t.Elapsed += new System.Timers.ElapsedEventHandler(delegate(object nsender, System.Timers.ElapsedEventArgs ne)
				{
					if (animationButtonPanel.numberOfClicks < 2)
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleAnimationButtonPanelClick(true);
						});
					}
					else
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleAnimationButtonPanelClick(false);
						});
					}
					t.Enabled = false;
				});
				t.Enabled = true;
			}
		}

		public void handleAnimationButtonPanelClick(bool fire)
		{
			if (fire)
			{
				bool thereAreNamedCompositeFrameSets = (bool)(format != null && format.CompositeFrameSetList.Count > 0);
				if (optionsTableLayoutPanel.RowStyles[3].Height > 0)
				{
					optionsTableLayoutPanel.Height -= (int)optionsTableLayoutPanel.RowStyles[3].Height;
					optionsTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
				}
				else
				{
					if (thereAreNamedCompositeFrameSets)
					{
						optionsTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, heightOfAnimationBody);
						optionsTableLayoutPanel.Height += (int)optionsTableLayoutPanel.RowStyles[3].Height;
						animationTableLayoutPanel.Height = (int)optionsTableLayoutPanel.RowStyles[3].Height;
					}
					else
					{
						optionsTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, heightOfAnimationBodyWithoutNamedAnimations);
						optionsTableLayoutPanel.Height += (int)optionsTableLayoutPanel.RowStyles[3].Height;
						animationTableLayoutPanel.Height = (int)optionsTableLayoutPanel.RowStyles[3].Height;
					}
				}
			}
		}

		private void animationButtonPanel_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				animationButtonPanel.numberOfClicks = 2;
				optionsTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
				optionsTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Absolute, 0F);
				if (format != null && format.CompositeFrameSetList.Count > 0)
				{
					optionsTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, heightOfAnimationBody);
					animationTableLayoutPanel.Height = (int)optionsTableLayoutPanel.RowStyles[3].Height;
					optionsTableLayoutPanel.Height = (int)optionsTableLayoutPanel.RowStyles[3].Height + getButtonPanelHeaderHeights();
				}
				else
				{
					optionsTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, heightOfAnimationBodyWithoutNamedAnimations);
					optionsTableLayoutPanel.Height = (int)optionsTableLayoutPanel.RowStyles[3].Height + getButtonPanelHeaderHeights();
					animationTableLayoutPanel.Height = (int)optionsTableLayoutPanel.RowStyles[3].Height;
				}
			}
		}

		private void subdivisionButtonPanel_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				subdivisionButtonPanel.numberOfClicks = 0;
				subdivisionButtonPanel.lastClick = Environment.TickCount & Int32.MaxValue;
				System.Timers.Timer t = new System.Timers.Timer(200);
				t.Elapsed += new System.Timers.ElapsedEventHandler(delegate(object nsender, System.Timers.ElapsedEventArgs ne)
				{
					if (subdivisionButtonPanel.numberOfClicks < 2)
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleSubdivisionButtonPanelClick(true);
						});
					}
					else
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleSubdivisionButtonPanelClick(false);
						});
					}
					t.Enabled = false;
				});
				t.Enabled = true;
			}
		}

		public void handleSubdivisionButtonPanelClick(bool fire)
		{
			if (fire)
			{
				if (optionsTableLayoutPanel.RowStyles[5].Height > 0)
				{
					optionsTableLayoutPanel.Height -= (int)optionsTableLayoutPanel.RowStyles[5].Height;
					optionsTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Absolute, 0F);
				}
				else
				{
					optionsTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Absolute, heightOfSubdivisionBody);
					optionsTableLayoutPanel.Height += (int)optionsTableLayoutPanel.RowStyles[5].Height;
				}
			}
		}

		private void subdivisionButtonPanel_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				subdivisionButtonPanel.numberOfClicks = 2;
				optionsTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
				optionsTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
				optionsTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Absolute, heightOfSubdivisionBody);
				optionsTableLayoutPanel.Height = (int)optionsTableLayoutPanel.RowStyles[5].Height + getButtonPanelHeaderHeights();
			}
		}
		#endregion

		private void flipFrameHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (loadedFormat != "")
			{
				int copyFromFrame = advanceRows * columns + advanceColumns + 1;
				List<RenderableFrameCall> list = format.GetRenderableFrameCallsForCompositeFrameId(copyFromFrame);
				foreach (RenderableFrameCall q in list)
				{
					int newX = (int)(frameWidth - q.bound.X - q.bound.Width);
					q.bound = new Shapes.Rect(x: newX, y: q.bound.Y, width: q.bound.Width, height: q.bound.Height);
					q.flipX = !q.flipX;
				}
				list.Reverse();
				//
				if (list.Count > 0)
				{
					SupportFunctions.SaveQuadListToCompositeFrameXML(baseLocation: baseLocation, format: loadedFormat, writeThisFrame: copyFromFrame, loadedFrames: list);
					//
					format.LoadOrReloadCompositeFrame(copyFromFrame, reloadRoot: true);
					//
					Thread flipFrameHorizontallyThread = new Thread(new ThreadStart(delegate()
					{
						this.loadCompositeFrames(this, new int[] { copyFromFrame }, true);
					}));
					flipFrameHorizontallyThread.Name = "Flip Frame Horizontally";
					flipFrameHorizontallyThread.Start();
				}
			}
		}

		private void availableAttachmentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (availableAttachmentsWindow == null)
				availableAttachmentsWindow = new AvailableAttachments(this);
			availableAttachmentsWindow.Show(previewWindow);
			availableAttachmentsWindow.Focus();
		}

		private void previewAreaContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			bool enableOptions = (loadedFormat != "") ? true : false;
			editSelectedFrameToolStripMenuItem.Enabled = enableOptions;
			usePreviousFrameToolStripMenuItem.Enabled = enableOptions;
			flipFrameHorizontallyToolStripMenuItem.Enabled = enableOptions;
		}

		private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			// If there's image, it can be exported.
			bool enableOptions = (loadedImageLastWrite != DateTime.MinValue) ? true : false;
			exportActiveFramesAsGIFToolStripMenuItem.Enabled = enableOptions;
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Help.ShowHelp(previewWindow, "Documentation.chm");
		}

		private void ghost_CheckedChanged(object sender, EventArgs e) {
			forceRedraw = true;
		}

		private void drawFrameNumberYesOrNo_CheckedChanged(object sender, EventArgs e)
		{
			forceRedraw = true;
		}

		private void transparentBackgroundYesOrNo_CheckedChanged(object sender, EventArgs e)
		{
			forceRedraw = true;
		}

		private void drawFrameYesOrNo_CheckedChanged(object sender, EventArgs e)
		{
			forceRedraw = true;
		}

		private void showAudioWaveForm_CheckedChanged(object sender, EventArgs e)
		{
			forceRedraw = true;
		}
	}
}
