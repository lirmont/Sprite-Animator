using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Tao.OpenGl;
using SpriteAnimator.SupportClasses;

#pragma warning disable
namespace SpriteAnimator
{
	public partial class AddOrEditFrame : Form
	{
		private Color backgroundColor = Color.Black;
		private int targetMilliseconds = 20;
		private int startMilliseconds = 0, currentMilliseconds = 0;
		private System.Threading.Timer scheduleRedraw;
		private bool forceRedraw = false;
		private double scaleX = 1, scaleY = 1, scaleZ = 1;
		private double gutterX = 0, gutterY = 0;

		// Image
		public int loadedImageSlot = -1;
		private Bitmap loadedImageDescriptor;
		private BitmapData loadedImageData;
		private IntPtr rawFilePointer;
		private byte[] ali;
		public int rawW = 0, rawH = 0, rawStride = 0;
		private string loadedImageFileName = "";

		// Cursor
		private int cursorDeltaX = 0, cursorDeltaY = 0;
		private int cursorLastX = 0, cursorLastY = 0;

		// Box Select
		private bool boxDragging = false;
		private int boxX = 0, boxY = 0;
		private double boxW = 0, boxH = 0;

		// Storage
		private int id = 1, s = 0, t = 0, w = 0, h = 0;

		public int Id
		{
			get
			{
				double d = 0;
				int i = 0;
				if (idMaskedTextBox.Text.Trim() != "")
				{
					double.TryParse(idMaskedTextBox.Text, out d);
					i = (int)Math.Round(d);
				}
				return i;
			}
			set { idMaskedTextBox.Text = value.ToString(); id = value; }
		}

		public int W
		{
			get
			{
				double d = 0;
				int i = 0;
				if (wMaskedTextBox.Text.Trim() != "")
				{
					double.TryParse(wMaskedTextBox.Text, out d);
					i = (int)Math.Round(d);
				}
				return i;
			}
			set { wMaskedTextBox.Text = value.ToString(); w = value; }
		}

		public int H
		{
			get
			{
				double d = 0;
				int i = 0;
				if (hMaskedTextBox.Text.Trim() != "")
				{
					double.TryParse(hMaskedTextBox.Text, out d);
					i = (int)Math.Round(d);
				}
				return i;
			}
			set { hMaskedTextBox.Text = value.ToString(); h = value; }
		}

		public int S
		{
			get
			{
				double d = 0;
				int i = 0;
				if (sMaskedTextBox.Text.Trim() != "")
				{
					double.TryParse(sMaskedTextBox.Text, out d);
					i = (int)Math.Round(d);
				}
				return i;
			}
			set { sMaskedTextBox.Text = value.ToString(); s = value; }
		}

		public int T
		{
			get
			{
				double d = 0;
				int i = 0;
				if (tMaskedTextBox.Text.Trim() != "")
				{
					double.TryParse(tMaskedTextBox.Text, out d);
					i = (int)Math.Round(d);
				}
				return i;
			}
			set { tMaskedTextBox.Text = value.ToString(); t = value; }
		}

		/*
		 * Image-Related
		 */
		public string LoadedImage
		{
			get { return loadedImageFileName; }
			set { loadedImageFileName = value; }
		}

		public int ImageWidth
		{
			get { return rawW; }
			set
			{
				rawW = value;
				imageWidthLabel.Text = value.ToString();
			}
		}

		public int ImageHeight
		{
			get { return rawH; }
			set
			{
				rawH = value;
				imageHeightLabel.Text = value.ToString();
			}
		}

		public double HalfWidth
		{
			get { return ImageWidth / 2.0; }
		}

		public double HalfHeight
		{
			get { return ImageHeight / 2.0; }
		}

		/*
		 * Cursor-Related
		 */
		private int CursorX
		{
			get { return Cursor.Position.X - this.simpleOpenGlControl.PointToScreen(new Point(0, 0)).X; }
		}

		private int CursorY
		{
			get { return Cursor.Position.Y - this.simpleOpenGlControl.PointToScreen(new Point(0, 0)).Y; }
		}

		private int CursorDeltaY
		{
			get { return cursorDeltaY; }
			set { cursorDeltaY = value; }
		}

		private int CursorDeltaX
		{
			get { return cursorDeltaX; }
			set { cursorDeltaX = value; }
		}

		private int CursorLastY
		{
			get { return cursorLastY; }
			set { cursorLastY = value; }
		}

		private int CursorLastX
		{
			get { return cursorLastX; }
			set { cursorLastX = value; }
		}
		
		/*
		 * Box Select
		 */
		public int BoxX
		{
			get { return boxX; }
			set { sMaskedTextBox.Text = value.ToString(); boxX = value; }
		}

		public int BoxY
		{
			get { return boxY; }
			set { tMaskedTextBox.Text = value.ToString(); boxY = value; }
		}

		public double BoxW
		{
			get { return boxW; }
			set
			{
				int i = (int)Math.Round(value);
				wMaskedTextBox.Text = i.ToString();
				boxW = value;
			}
		}

		public double BoxH
		{
			get { return boxH; }
			set
			{
				int i = (int)Math.Round(value);
				hMaskedTextBox.Text = i.ToString();
				boxH = value;
			}
		}

		/*
		 * Main Form
		 */
		public AddOrEditFrame()
		{
			InitializeComponent();
			simpleOpenGlControl.InitializeContexts();
			#region Scheduled re-draw and last write scan tasks.
			scheduleRedraw = new System.Threading.Timer(delegate(object data)
			{
				currentMilliseconds = Environment.TickCount & Int32.MaxValue;
				if (targetMilliseconds <= currentMilliseconds - startMilliseconds || forceRedraw)
					simpleOpenGlControl.Draw();
			}, "Redrawing Render Control", targetMilliseconds, targetMilliseconds);
			#endregion
			simpleOpenGlControl_Resize(null, null);
			Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
		}

		private void simpleOpenGlControl_Resize(object sender, EventArgs e)
		{
			if (simpleOpenGlControl.Width == ImageWidth && simpleOpenGlControl.Height == ImageHeight)
				gutterX = gutterY = 0;
			else if (simpleOpenGlControl.Width >= ImageWidth
				 && (this.Height - System.Windows.Forms.SystemInformation.CaptionHeight) <= ImageHeight)
			{
				gutterX = (int)((simpleOpenGlControl.Width - scaleX * ImageWidth) / 2.0);
				gutterY = 0;
			}
			else
			{
				gutterX = (int)((simpleOpenGlControl.Width - scaleX * ImageWidth) / 2.0);
				gutterY = (int)((simpleOpenGlControl.Height - scaleY * ImageHeight) / 2.0);
			}
		}

		private void simpleOpenGlControl_Paint(object sender, PaintEventArgs e)
		{
			Gl.glViewport(0, 0, simpleOpenGlControl.Width, simpleOpenGlControl.Height);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Glu.gluPerspective(45.0f, ((float)(simpleOpenGlControl.Width) / (float)(simpleOpenGlControl.Height)), 0.1f, 2.0f);
			Gl.glClearColor(backgroundColor.R / 255f, backgroundColor.G / 255f, backgroundColor.B / 255f, 0f);
			Gl.glEnable(Gl.GL_LINE_SMOOTH);
			Gl.glEnable(Gl.GL_BLEND);
			Gl.glEnable(Gl.GL_DEPTH_TEST);
			Gl.glDepthFunc(Gl.GL_LEQUAL);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
			SupportFunctions.pushScreenCoordinateMatrix(0, simpleOpenGlControl.Width, simpleOpenGlControl.Height, 0);
			{
				simpleOpenGlControl_Draw();
			}
			SupportFunctions.pop_projection_matrix();
		}

		private void simpleOpenGlControl_Draw()
		{
			Gl.glColor3d(1, 1, 1);
			Gl.glDisable(Gl.GL_CULL_FACE);
			Gl.glPushMatrix();
			{
				Gl.glTranslated(gutterX, gutterY, 0);
				Gl.glScaled(scaleX, scaleY, scaleZ);
				// Draw image.
				SupportFunctions.render(0, ImageWidth, ImageHeight, 0, textureId: loadedImageSlot);
				// Draw yellow frame with border around pixel quadrilateral.
				SupportFunctions.render(S, S + W, T + H, T, color: Color.FromArgb(255, 255, 0), blendMode: "line", drawingMode: Gl.GL_LINE_LOOP, lineWidth: 2f);
				SupportFunctions.render(S, S + W, T + H, T, color: Color.FromArgb(255 / 4, 255, 255, 0));
				// Draw bounding box around image.
				Gl.glTranslated(HalfWidth, HalfHeight, 0);
				SupportFunctions.DrawBoundingBox(HalfWidth, HalfHeight);
			}
			Gl.glPopMatrix();
			// Cursor.
			if (!boxDragging)
				SupportFunctions.DrawNoActionAvailableCursor(CursorX, CursorY);
		}

		private void simpleOpenGlControl_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
			double numberOfPixelsToMove = (numberOfTextLinesToMove * (1.0 / 6.0));
			//
			if (scaleX + numberOfPixelsToMove > 1)
				scaleX += numberOfPixelsToMove;
			else
				scaleX = 1;
			//
			if (scaleY + numberOfPixelsToMove > 1)
				scaleY += numberOfPixelsToMove;
			else
				scaleY = 1;
			//
			simpleOpenGlControl_Resize(sender, e);
		}

		private void simpleOpenGlControl_MouseMove(object sender, MouseEventArgs e)
		{
			CursorDeltaX = CursorX - CursorLastX;
			CursorDeltaY = CursorY - CursorLastY;
			CursorLastX = e.X;
			CursorLastY = e.Y;
			if (e.Button == MouseButtons.Middle)
			{
				double minorDx = CursorDeltaX / 1;
				double minorDy = CursorDeltaY / 1;
				gutterX += minorDx;
				gutterY += minorDy;
				return;
			}
			if (e.Button == MouseButtons.Left)
			{
				if (!boxDragging)
				{
					boxDragging = true;
					BoxX = (int)(CursorX / scaleX - gutterX / scaleX);
					BoxY = (int)(CursorY / scaleY - gutterY / scaleY);
					BoxW = 0;
					BoxH = 0;
				}
				BoxW += CursorDeltaX / scaleX;
				BoxH += CursorDeltaY / scaleY;
			}
		}

		private void simpleOpenGlControl_Load(object sender, EventArgs e)
		{
			if (loadedImageFileName != "" && File.Exists(loadedImageFileName))
			{
				loadedImageDescriptor = (Bitmap)Image.FromFile(LoadedImage);
				using (Bitmap bm2 = loadedImageDescriptor)
				{
					ImageWidth = bm2.Width;
					ImageHeight = bm2.Height;
					Rectangle rect2 = new Rectangle(0, 0, bm2.Width, bm2.Height);
					#region Get the color of a background pixel.
					Color backColor = bm2.GetPixel(1, 1);
					backgroundColor = backColor;
					if (System.IO.Path.GetExtension(loadedImageFileName) != ".png")
						bm2.MakeTransparent(backgroundColor);
					#endregion
					BitmapData bm2Data = bm2.LockBits(rect2, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
					try
					{
						IntPtr bm2Ptr = bm2Data.Scan0;
						rawStride = bm2Data.Stride;
						ali = new byte[Math.Abs(bm2Data.Stride) * bm2.Height];
						Marshal.Copy(bm2Ptr, ali, 0, ali.Length);
					}
					finally
					{
						bm2.UnlockBits(bm2Data); //Lock End
					}
				}
				#region Pin byte array to make pointer available to data.
				rawFilePointer = GCHandle.Alloc(ali, GCHandleType.Pinned).AddrOfPinnedObject();
				ali = new byte[0];
				#endregion
				loadedImageDescriptor = new Bitmap(ImageWidth, ImageHeight, rawStride, PixelFormat.Format32bppArgb, rawFilePointer);
				loadedImageData = loadedImageDescriptor.LockBits(new Rectangle(0, 0, loadedImageDescriptor.Width, loadedImageDescriptor.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
				SupportFunctions.createTexture(loadedImageData.Width, loadedImageData.Height, ref loadedImageSlot, imageByteOrder: Gl.GL_RGB, byteOrder: Gl.GL_BGR, imageData: loadedImageData.Scan0);
				// Resize.
				this.Size = new Size(462 + ImageWidth, 109 + ImageHeight);
			}
		}

		private void simpleOpenGlControl_MouseUp(object sender, MouseEventArgs e)
		{
			boxDragging = false;
		}

		private void simpleOpenGlControl_MouseEnter(object sender, EventArgs e)
		{
			simpleOpenGlControl.Focus();
		}

		private void magnifyButton_Click(object sender, EventArgs e)
		{
			scaleX += 1;
			scaleY += 1;
			simpleOpenGlControl_Resize(sender, e);
		}

		private void minifyButton_Click(object sender, EventArgs e)
		{
			if (scaleX > 1)
				scaleX -= 1;
			if (scaleY > 1)
				scaleY -= 1;
			simpleOpenGlControl_Resize(sender, e);
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
