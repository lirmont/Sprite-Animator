using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;
using System.Xml;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using SpriteAnimator.SupportClasses;

#pragma warning disable
namespace SpriteAnimator
{
	public partial class EditSelectedFrame : Form
	{
		private Main parent = null;
		private delegate void DrawingHandler();
		private List<Input> inputInterface = new List<Input>();

		/*
		 * Image on-save variables.
		 */
		private List<int> compositeFramesToUpdateOnImageSave = null;

		public List<int> CompositeFramesToUpdateOnImageSave
		{
			get {
				if (compositeFramesToUpdateOnImageSave == null)
				{
					List<int> compositeFramesToLoad = new List<int>();
					foreach (int key in this.parent.Format.CompositeFrames.Keys)
					{
						bool found = false;
						foreach (RenderableFrameCall call in LoadedFrames)
						{
							foreach (Shapes.FrameCall frameCall in this.parent.Format.CompositeFrames[key])
							{
								if (frameCall.id == call.id.ToString() && !compositeFramesToLoad.Contains(key))
								{
									compositeFramesToLoad.Add(key);
									found = true;
									continue;
								}
							}
							// Get out if this composite frame is already included.
							if (found)
								continue;
						}
					}
					compositeFramesToUpdateOnImageSave = compositeFramesToLoad;
				}
				return compositeFramesToUpdateOnImageSave;
			}
			set { compositeFramesToUpdateOnImageSave = value; }
		}

		/*
		 * Mode Enumeration
		 */
		enum Modes { DontCare = 0, Translation = 1, Eraser = 2, Paint = 4 };
		private Modes activeMode = Modes.DontCare;

		private Modes ActiveMode
		{
			get { return activeMode; }
			set 
			{
				activeMode = value;
				if (activeMode == Modes.Translation) {
					sceneTreeView.Enabled = true;
					eraseModeButton.Checked = false;
					paintModeButton.Checked = false;
					//
					this.parent.setAutoUpdate(true, m: this.parent);
				}
				else if (activeMode == Modes.Eraser || activeMode == Modes.Paint)
				{
					//
					if (activeMode == Modes.Eraser)
					{
						sceneTreeView.Enabled = false;
						eraseModeButton.Checked = true;
						paintModeButton.Checked = false;
					}
					else if (activeMode == Modes.Paint)
					{
						sceneTreeView.Enabled = false;
						eraseModeButton.Checked = false;
						paintModeButton.Checked = true;
					}
					//
					this.parent.setAutoUpdate(false, m: this.parent);
				}
			}
		}

		/*
		 * Paint/Eraser support variables.
		 */
		private Color? PaintColor
		{
			get
			{
				if (ActiveMode == Modes.Paint)
					return paintColorSwatchPanel.BackColor;
				else if (ActiveMode == Modes.Eraser)
					return Color.Transparent;
				else
					return null;
			}
			set {
				if (value != null)
					paintColorSwatchPanel.BackColor = value.Value;
			}
		}

		/*
		 * Sprite Format
		 */
		private List<Sound> usedSoundList = new List<Sound>();

		public List<Sound> UsedSoundList
		{
			get { return usedSoundList; }
			set
			{
				usedSoundList = value;
				foreach (Sound s in value)
				{
					removeSoundContextMenuStrip.Items.Add(s.name);
					for (int i = 0; i < addSoundContextMenuStrip.Items.Count; i++)
						if (addSoundContextMenuStrip.Items[i].Text == s.name)
							addSoundContextMenuStrip.Items[i].Enabled = false;
				}
			}
		}

		private void CreateSoundsContextMenu()
		{
			addSoundContextMenuStrip.Items.Clear();
			foreach (Sound s in parent.Format.AvailableSounds)
				addSoundContextMenuStrip.Items.Add(s.name);
		}

		private Color backgroundColor = Color.Black;

		/*
		 * TreeView Convenience Accessors
		 */
		TreeNodeCollection Frames
		{
			get
			{
				return sceneTreeView.Nodes[2].Nodes;
			}
			set { }
		}

		/*
		 * Re-drawing 
		 */
		private int targetMilliseconds = 20;
		private int startMilliseconds = 0, currentMilliseconds = 0;
		private System.Threading.Timer scheduleRedraw;
		private bool forceRedraw = false;

		/*
		 * Drawing
		 */
		private double scaleX = 1, scaleY = 1, scaleZ = 1;
		private double gutterX = 0, gutterY = 0;
		private double sceneRotationX = 0, sceneRotationY = 0, sceneRotationZ = 0;
		private int frameWidth = 0, frameHeight = 0;
		private double halfWidth = 0, halfHeight = 0;
		private bool useNoSampling = false;
		private int thisFrame = 1;
		private double[] currentProjectionMatrix = new double[16], currentModelviewMatrix = new double[16];
		private int[] currentViewportMatrix = new int[4];

		//
		private List<RenderableFrameCall> loadedFrames = new List<RenderableFrameCall>();

		public List<RenderableFrameCall> LoadedFrames
		{
			get { return loadedFrames; }
			set {
				List<int> oldList = DistinctLoadedFrameIds;
				loadedFrames = value;
				List<int> newList = DistinctLoadedFrameIds;
				if (!SupportFunctions.IntegerValueListEquals(oldList, newList))
					CompositeFramesToUpdateOnImageSave = null;
			}
		}

		public List<int> DistinctLoadedFrameIds {
			get {
				List<int> thisList = new List<int>();
				if (loadedFrames != null)
				{
					foreach (RenderableFrameCall call in loadedFrames)
					{
						if (!thisList.Contains(call.id))
							thisList.Add(call.id);
					}
				}
				thisList.Sort();
				return thisList;
			}
		}

		/*
		 * Current Action Translation/Rotation/Scale.
		 */
		private double currentActionRotationChange = 0;
		private double currentActionScaleChangeX = 0, currentActionScaleChangeY = 0;
		private double currentActionOffsetChangeX = 0, currentActionOffsetChangeY = 0, currentActionOffsetChangeZ = 0;
		private Point currentActionCursorStartingPoint = new Point(0, 0);

		/*
		 * Mouse
		 */
		private int CursorX
		{
			get
			{
				return Cursor.Position.X - this.simpleOpenGlControl.PointToScreen(new Point(0, 0)).X;
			}
		}

		private int CursorY
		{
			get
			{
				return Cursor.Position.Y - this.simpleOpenGlControl.PointToScreen(new Point(0, 0)).Y;
			}
		}

		private int cursorDeltaX = 0, cursorDeltaY = 0;

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

		private int cursorLastX = 0, cursorLastY = 0;

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
		private Point boxSelectStart, boxSelectEnd;
		private bool boxSelecting = false;

		/*
		 * Translation
		 */
		private bool scalingActive = false, rotationZActive = false, grabbingActive = false, draggingGrabActive = false;

		public bool DraggingGrabActive
		{
			get { return draggingGrabActive; }
			set
			{
				// If new motion is happening, get rid of the stored motion.
				if (value)
					resetStoredActionMotion();
				// Set dragging grab state.
				draggingGrabActive = value;
			}
		}

		public bool GrabbingActive
		{
			get { return grabbingActive; }
			set {
				// If new motion is happening, get rid of the stored motion.
				if (value)
					resetStoredActionMotion();
				// Set grabbing state.
				grabbingActive = value;
			}
		}

		public bool RotationZActive
		{
			get { return rotationZActive; }
			set {
				// If new motion is happening, get rid of the stored motion.
				if (value)
					resetStoredActionMotion();
				// Set rotating state.
				rotationZActive = value;
			}
		}

		public bool ScalingActive
		{
			get { return scalingActive; }
			set {
				// If new motion is happening, get rid of the stored motion.
				if (value)
					resetStoredActionMotion();
				// Set scaling state.
				scalingActive = value;
			}
		}

		/*
		 * Menuing
		 */
		private ToolStripMenuItem lastBlendModeToolStripMenuItem;

		/*
		 * Support Methods for Common Input Actions
		 */
		private bool TranslationInProgress
		{
			get
			{
				return (ScalingActive || RotationZActive || GrabbingActive || DraggingGrabActive);
			}
			set
			{
				DraggingGrabActive = value;
				ScalingActive = value;
				RotationZActive = value;
				GrabbingActive = value;
			}
		}

		private bool AtLeastOneFrameIsSelected
		{
			get
			{
				RenderableFrameCall aSelectedFrame = LoadedFrames.Find(item => item.selected == true);
				return (aSelectedFrame != null) ? true : false;
			}
		}

		private bool SomeSelectedFrameHasRotation
		{
			get {
				bool hasRotation = false;
				LoadedFrames.ForEach(delegate(RenderableFrameCall q)
				{
					if (q.selected && q.rotationZ != 0)
						hasRotation = true;
				});
				return hasRotation;
			}
		}

		private bool SomeSelectedFrameHasTween
		{
			get
			{
				bool hasTween = false;
				LoadedFrames.ForEach(delegate(RenderableFrameCall q)
				{
					if (q.selected && q.tween != "0")
						hasTween = true;
				});
				return hasTween;
			}
		}

		private Shapes.Tween SomeSelectedTween
		{
			get
			{
				Shapes.Tween foundTween = null;
				LoadedFrames.ForEach(delegate(RenderableFrameCall q)
				{
					if (q.selected && q.tween != "0")
					{
						Shapes.Tween thisTween = parent.Format.AvailableTweenList.Find(item => item.id == q.tween);
						if (thisTween != null)
						{
							if (foundTween == null)
								foundTween = thisTween;
							else if (foundTween.FrameLength < thisTween.FrameLength)
								foundTween = thisTween;
						}
					}
				});
				return foundTween;
			}
		}

		private bool SomeSelectedFrameHasNamedAttachmentPoint
		{
			get
			{
				bool hasNamedAttachmentPoint = false;
				LoadedFrames.ForEach(delegate(RenderableFrameCall q)
				{
					if (q.selected && q.namedAttachmentPointId != 0)
						hasNamedAttachmentPoint = true;
				});
				return hasNamedAttachmentPoint;
			}
		}

		private bool SomeSelectedFrameHasScaling
		{
			get
			{
				bool hasScale = false;
				LoadedFrames.ForEach(delegate(RenderableFrameCall q)
				{
					if (q.selected)
					{
						if (q.scaleX != 1 || q.scaleY != 1)
							hasScale = true;
					}
				});
				return hasScale;
			}
		}

		private bool SomeSelectedFrameHasAnOverridenColor
		{
			get
			{
				bool hasOverridenColor = false;
				LoadedFrames.ForEach(delegate(RenderableFrameCall q)
				{
					if (q.selected)
					{
						if (!q.NoColorAtFrameCall)
							hasOverridenColor = true;
					}
				});
				return hasOverridenColor;
			}
		}

		/*
		 * Form
		 */
		public EditSelectedFrame(Main m = null, int copyFromFrame = 0)
		{
			this.parent = m;
			// Prepare the form.
			InitializeComponent();
			simpleOpenGlControl.InitializeContexts();
			// Add input handlers.
			populateInputInterface();
			// Set the drawing overrides.
			sceneTreeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
			sceneTreeView.DrawNode += new DrawTreeNodeEventHandler(sceneTreeView_DrawNode);
			//
			simpleOpenGlControl.PreviewKeyDown += EditSelectedFrame_PreviewKeyDown;
			// Initialize box select.
			boxSelectStart = new Point(0, 0);
			boxSelectEnd = new Point(0, 0);
			// Set active mode.
			if (ActiveMode == Modes.DontCare)
				ActiveMode = Modes.Translation;
			// Set color.
			PaintColor = Palette.MostUsedColor;
			// Set the default menu item for the last used blend mode.
			lastBlendModeToolStripMenuItem = overwriteToolStripMenuItem;
			//
			if (this.parent != null && this.parent.loadedFormat != "")
			{
				// Select "FORMAT" attributes (target, base, frame).
				useNoSampling = this.parent.Format.UseNoSampling;
				frameHeight = this.parent.Format.FrameHeight;
				frameWidth = this.parent.Format.FrameWidth;
				this.Width += (frameWidth - simpleOpenGlControl.Width);
				this.Refresh();
				// Create menu items for available frames.
				CreateSoundsContextMenu();
				CreateAddNewFrameContextMenu();
				CreateChangeSelectedFrameContextMenu();
				CreateChangeNamedAttachmentPointContextMenu();
				CreateChangeSelectedTweenContextMenu();
				CreateChangeOverriddenColorContextMenu();
				// Get all the frame calls out of the specified composite frame.
				copyFromFrame = (copyFromFrame > 0) ? copyFromFrame : this.parent.CurrentCompositeFrame;
				LoadedFrames = this.parent.Format.GetRenderableFrameCallsForCompositeFrameId(copyFromFrame);
				LoadedFrames.Reverse();
				// Finally, reload the tree view with the appropriate data.
				compileTreeView();
			}
			// Create convenience variables for dimensions.
			halfWidth = frameWidth / 2.0;
			halfHeight = frameHeight / 2.0;
		}

		/*
		 * Input
		 */
		#region Translation Mode Input Handlers
		private void adjustXTranslationByValue(double value)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					q.OffsetX += value;
			});
			currentActionOffsetChangeX += value;
		}

		private void adjustYTranslationByValue(double value)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					q.OffsetY += value;
			});
			currentActionOffsetChangeY += value;
		}

		private void adjustZTranslationByValue(double value)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					q.OffsetZ += value;
			});
			currentActionOffsetChangeZ += value;
		}

		private void adjustXScalingByValue(double value)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					q.scaleX += value;
			});
			currentActionScaleChangeX += value;
		}

		private void adjustYScalingByValue(double value)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					q.scaleY += value;
			});
			currentActionScaleChangeY += value;
		}

		private void adjustZRotationByValue(double value)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					q.rotationZ += value;
			});
			currentActionRotationChange += value;
		}

		private void hoverSelectOrUpdateTranslationOnMouseMove(Input i)
		{
			// Hover-select at X, Y
			if (!TranslationInProgress)
			{
				bool somethingWasHoverSelected = false;
				LoadedFrames.ForEach(delegate(RenderableFrameCall q)
				{
					q.hoverSelected = frameIsBeneathCursor(q);
					if (q.hoverSelected)
						somethingWasHoverSelected = true;
				});
				//
				this.Cursor = (somethingWasHoverSelected) ? System.Windows.Forms.Cursors.Hand : System.Windows.Forms.Cursors.Arrow;
			}
			else
			{
				if (RotationZActive)
					updateRotationOfSelectedFramesFromCursor();
				if (ScalingActive)
					updateScaleOfSelectedFramesFromCursor();
				if (GrabbingActive)
					updatePositionOfSelectedFramesFromCursor();
			}
		}

		private void selectDeselectOrDragFramesWithLeftClick(Input i)
		{
			// Select at X, Y.
			bool selectedSomething = false;
			//
			if (i.isActive() &&
				!LoadedFrames.Exists(new Predicate<RenderableFrameCall>(alreadySelectedAndBeneathCursor)) &&
				!i.firstFireHandled)
			{
				bool startState = AtLeastOneFrameIsSelected;
				selectFirstFrameBeneathCursorAndDeselectOthers();
				bool endState = AtLeastOneFrameIsSelected;
				if (startState != endState)
					selectedSomething = true;
			}
			// Move all frames selected by scalar values cursor delta-x and cursor delta-y.
			bool draggingStateChanged = false;
			if (i.isDragging())
			{
				if (!i.firstFireHandled && !DraggingGrabActive)
				{
					draggingStateChanged = true;
					DraggingGrabActive = true;
				}
				//
				if (DraggingGrabActive)
					updatePositionOfSelectedFramesFromCursor();
			}
			if (selectedSomething || draggingStateChanged)
				i.firstFireHandled = true;
			// Cleanup.
			if (!i.isActive())
			{
				DraggingGrabActive = false;
				resetStoredActionMotion();
				i.deactivate();
			}
		}

		private void endBoxSelectOrTranslationOrSelectionOnUnhandledLeftClick(Input i)
		{
			if (!i.firstFireHandled)
			{
				if (boxSelecting)
				{
					boxSelectEnd = new Point(CursorX, CursorY);
					// Rewrite the two coordinates to be a positive domain/range box.
					Rectangle box = SupportFunctions.NormalizeBox(ref boxSelectStart, ref boxSelectEnd);
					// Mark the selecting process as finished.
					boxSelecting = false;
					// Prepare to find something to show data for.
					bool foundFirst = false;
					// Check for selection from box-select.
					LoadedFrames.ForEach(delegate(RenderableFrameCall q)
					{
						if (frameIsContainedInRectangle(box, q))
						{
							selectFrame(q);
							if (!foundFirst)
							{
								displayDataForFrame(q);
								foundFirst = true;
							}
						}
					});
				}
				else if (TranslationInProgress && !DraggingGrabActive)
					TranslationInProgress = false;
				else
					selectFirstFrameBeneathCursorAndDeselectOthers();
			}
			else if (DraggingGrabActive)
				DraggingGrabActive = false;
		}

		private void showPreviewAreaContextMenuAtCursorOnUnhandledRightClick(Input i)
		{
			previewAreaContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
		}

		private void selectOrUnselectAllFramesOnA(Input i)
		{
			if (i.isActive() && i.firstResponseNotHandledByThisYet())
			{
				if (LoadedFrames.TrueForAll(item => item.selected))
					unselectAllFrames();
				else
					selectAllFrames();
			}
		}

		private void startBoxSelectOnB(Input i)
		{
			if (i.isActive() && !TranslationInProgress && i.firstResponseNotHandledByThisYet())
			{
				boxSelectEnd = boxSelectStart = new Point(CursorX, CursorY);
				boxSelecting = true;
			}
		}

		private void startScaleOnS(Input i)
		{
			if (i.isActive() && i.firstResponseNotHandledByThisYet() && AtLeastOneFrameIsSelected && !TranslationInProgress)
				ScalingActive = true;
		}

		private void startRotationOnR(Input i)
		{
			if (i.isActive() && i.firstResponseNotHandledByThisYet() && AtLeastOneFrameIsSelected && !TranslationInProgress)
				RotationZActive = true;
		}

		private void startGrabbingOnG(Input i)
		{
			if (i.isActive() && i.firstResponseNotHandledByThisYet() && AtLeastOneFrameIsSelected && !TranslationInProgress)
				GrabbingActive = true;
		}

		private void undoTranslationsOnEscape(Input i)
		{
			if (i.isActive() && i.firstResponseNotHandledByThisYet() && TranslationInProgress)
			{
				bool wasDragging = DraggingGrabActive;
				// Reset the frame call's location.
				LoadedFrames.ForEach(delegate(RenderableFrameCall q)
				{
					if (q.selected)
					{
						q.rotationZ -= currentActionRotationChange;
						q.scaleX -= currentActionScaleChangeX;
						q.scaleY -= currentActionScaleChangeY;
						q.bound.X -= currentActionOffsetChangeX;
						q.bound.Y -= currentActionOffsetChangeY;
						q.OffsetZ -= currentActionOffsetChangeZ;
					}
				});
				//
				TranslationInProgress = false;
				// Quit listening for the release if this was a dragging operation.
				if (wasDragging)
				{
					Input leftClick = inputInterface.Find(item => item.signature == MouseButtons.Left.ToString() && item.type == Input.InputType.Mouse);
					leftClick.deactivate();
					draggingGrabActive = false;
				}
			}
		}
		#endregion

		#region Paint and Eraser mode input handlers.
		private void paintActiveColorOrEraseWithLeftClick(Input i)
		{
			//
			i.firstFireHandled = true;
			// Try to paint to texture.
			foreach (RenderableFrameCall q in LoadedFrames)
			{
				if (q.selected)
				{
					Shapes.Point pixel = getPixelOfTextureBeneathCursor(q);
					if (pixel != null)
					{
						// Get bitmap of loaded image.
						using (Bitmap existingBitmap = this.parent.loadedImageDescription.Bitmap)
						{
							// Draw pixel.
							existingBitmap.SetPixel((int)Math.Round(pixel.X), (int)Math.Round(pixel.Y), PaintColor.Value);
							// Re-upload.
							this.parent.loadedImageDescription.replaceWithBitmap(existingBitmap);
						}
						loadedImageNeedsToBeSaved = true;
					}
				}
			}
			// Cleanup.
			if (!i.isActive())
			{
				i.deactivate();
			}
		}

		private volatile bool loadedImageNeedsToBeSaved = false;
		private volatile bool savingThreadAlreadyActive = false;
		private void saveLoadedImageOnHandledLeftClick(Input i)
		{
			if (i.firstFireHandled)
			{
				if (loadedImageNeedsToBeSaved && !savingThreadAlreadyActive)
				{
					savingThreadAlreadyActive = true;
					Thread savingThread = new Thread(new ThreadStart(delegate()
					{
						// Save image out.
						this.parent.loadedImageDescription.Save();
						this.parent.loadedImageLastWrite = DateTime.Now;
						// Reload composite frames as necessary.
						this.parent.loadCompositeFrames(formHandle: this.parent, loadCompositeFramesInList: CompositeFramesToUpdateOnImageSave.ToArray(), noOverwriteStartEndFrames: true);
						//
						loadedImageNeedsToBeSaved = false;
						savingThreadAlreadyActive = false;
					}));
					savingThread.Name = "Image Save";
					savingThread.Start();
				}
			}
		}

		private void paintOrEraserOnEscape(Input i)
		{
			//
			i.firstFireHandled = true;
			//
			ActiveMode = Modes.Translation;
			// Cleanup.
			if (!i.isActive())
				i.deactivate();
		}
		#endregion

		#region Mode-aware or global input handlers.
		private void finallyUpdateDisplayedData(Input i)
		{
			if (AtLeastOneFrameIsSelected)
				displayDataForFrame(LoadedFrames.FindLast(item => item.selected));
		}

		private void modeAwareOnUp(Input i)
		{
			if (ActiveMode == Modes.Translation)
			{
				if (!simpleOpenGlControl.Focused)
					simpleOpenGlControl.Focus();
				//
				if (RotationZActive)
					adjustZRotationByValue(-1);
				else if (ScalingActive)
					adjustYScalingByValue(0.1);
				else // TranslationInProgress
					adjustYTranslationByValue(-1);
			}
		}

		private void modeAwareOnDown(Input i)
		{
			if (ActiveMode == Modes.Translation)
			{
				if (!simpleOpenGlControl.Focused)
					simpleOpenGlControl.Focus();
				//
				if (RotationZActive)
					adjustZRotationByValue(1);
				else if (ScalingActive)
					adjustYScalingByValue(-0.1);
				else // TranslationInProgress
					adjustYTranslationByValue(1);
			}
		}

		private void modeAwareOnLeft(Input i)
		{
			if (ActiveMode == Modes.Translation)
			{
				if (!simpleOpenGlControl.Focused)
					simpleOpenGlControl.Focus();
				//
				if (RotationZActive)
					adjustZRotationByValue(-1);
				else if (ScalingActive)
					adjustXScalingByValue(-0.1);
				else // TranslationInProgress
					adjustXTranslationByValue(-1);
			}
		}

		private void modeAwareOnRight(Input i)
		{
			if (ActiveMode == Modes.Translation)
			{
				if (!simpleOpenGlControl.Focused)
					simpleOpenGlControl.Focus();
				//
				if (RotationZActive)
					adjustZRotationByValue(1);
				else if (ScalingActive)
					adjustXScalingByValue(0.1);
				else // TranslationInProgress
					adjustXTranslationByValue(1);
			}
		}

		private void panWithMiddleMouseButton(Input i)
		{
			// Adjust gutter to move canvas.
			if (i.isDragging())
			{
				i.firstResponseNotHandledByThisYet();
				double minorDx = CursorDeltaX / 1;
				double minorDy = CursorDeltaY / 1;
				gutterX += minorDx;
				gutterY += minorDy;
			}
		}

		private void modeAwareOnMouseMove(Input i)
		{
			if (ActiveMode == Modes.Translation)
				hoverSelectOrUpdateTranslationOnMouseMove(i);
		}

		private void modeAwareOnLeftClickOrDrag(Input i)
		{
			if (ActiveMode == Modes.Translation)
				selectDeselectOrDragFramesWithLeftClick(i);
			else if (ActiveMode == Modes.Paint || ActiveMode == Modes.Eraser)
				paintActiveColorOrEraseWithLeftClick(i);
		}

		private void modeAwareOnLeftClickFinish(Input i)
		{
			if (ActiveMode == Modes.Translation)
				endBoxSelectOrTranslationOrSelectionOnUnhandledLeftClick(i);
			if (ActiveMode == Modes.Paint || ActiveMode == Modes.Eraser)
				saveLoadedImageOnHandledLeftClick(i);
		}

		private void modeAwareOnRightClickFinish(Input i)
		{
			if (ActiveMode == Modes.Translation)
				showPreviewAreaContextMenuAtCursorOnUnhandledRightClick(i);
		}

		private void modeAwareOnA(Input i)
		{
			if (ActiveMode == Modes.Translation)
				selectOrUnselectAllFramesOnA(i);
		}

		private void modeAwareOnB(Input i)
		{
			if (ActiveMode == Modes.Translation)
				startBoxSelectOnB(i);
		}

		private void modeAwareOnS(Input i)
		{
			if (ActiveMode == Modes.Translation)
				startScaleOnS(i);
		}

		private void modeAwareOnR(Input i)
		{
			if (ActiveMode == Modes.Translation)
				startRotationOnR(i);
		}

		private void modeAwareOnG(Input i)
		{
			if (ActiveMode == Modes.Translation)
				startGrabbingOnG(i);
		}

		private void modeAwareOnEscape(Input i)
		{
			if (ActiveMode == Modes.Translation)
				undoTranslationsOnEscape(i);
			else if (ActiveMode == Modes.Paint || ActiveMode == Modes.Eraser)
				paintOrEraserOnEscape(i);
		}

		private void modeAwareOnEnter(Input i)
		{
			if (ActiveMode == Modes.Translation)
			{
				if (TranslationInProgress)
					TranslationInProgress = false;
				if (ScalingActive)
					ScalingActive = false;
				if (RotationZActive)
					RotationZActive = false;
			}
		}
		#endregion

		#region Shared functionality for input handlers.
		private void resetStoredActionMotion()
		{
			currentActionRotationChange = 0;
			currentActionScaleChangeX = 0;
			currentActionScaleChangeY = 0;
			currentActionOffsetChangeX = 0;
			currentActionOffsetChangeY = 0;
			currentActionOffsetChangeZ = 0;
			currentActionCursorStartingPoint = Cursor.Position;
		}

		private TreeNode nodeOfFrameInTreeView(RenderableFrameCall q)
		{
			int index = Frames.Count - LoadedFrames.IndexOf(q) - 1;
			return Frames[index];
		}

		private void selectFrame(RenderableFrameCall q)
		{
			q.selected = true;
			nodeOfFrameInTreeView(q).Checked = true;
		}

		private void deselectFrame(RenderableFrameCall q)
		{
			q.selected = false;
			nodeOfFrameInTreeView(q).Checked = false;
		}

		private bool frameIsContainedInRectangle(Rectangle r, RenderableFrameCall q)
		{
			// Create a hit box out of the box select polygon.
			Shapes.Point[] hitBox = new Shapes.Point[] {
				new Shapes.Point(r.X, r.Y),
				new Shapes.Point(r.X + r.Width, r.Y),
				new Shapes.Point(r.X + r.Width, r.Y + r.Height),
				new Shapes.Point(r.X, r.Y + r.Height)
			};
			// Project the center point of the frame call into the window space.
			Shapes.Point thisCenter = q.Center;
			Glu.gluProject(thisCenter.X, thisCenter.Y, thisCenter.Z, currentModelviewMatrix, currentProjectionMatrix, currentViewportMatrix, out thisCenter.X, out thisCenter.Y, out thisCenter.Z);
			// Determine if the point is contained in the polygon.
			return SupportFunctions.PointIsInPolygon(hitBox, thisCenter);
		}

		private Shapes.Point getPixelOfTextureBeneathCursor(RenderableFrameCall q)
		{
			Shapes.Point cursor = new Shapes.Point(CursorX, CursorY);
			Shapes.Point[] hitBox = getHitBoxOfRenderableFrameCall(q);
			// Perform hit test.
			if (SupportFunctions.PointIsInPolygon(hitBox, cursor))
			{
				// Find two-dimensional delta, delta: width of hitbox, height of hitbox.
				Shapes.Point delta = hitBox[2] - hitBox[0];
				// Find significant portion of cursor coordinate, thisCursor: cursor - lesser boundary of hitbox (hitBox[0]).
				Shapes.Point thisCursor = cursor - hitBox[0];
				// Find ratio, represented as percentage, percent: thisCursor / delta.
				Shapes.Point percent = thisCursor / delta;
				// Find local pixel coordinates, s and t: percent.X * frame call width (and) percent.Y * frame call height.
				double s = (percent.X * delta.X) / scaleX;
				if (q.flipX)
					s = q.Width - s;
				double t = (percent.Y * delta.Y) / scaleY;
				// Find global pixel coordinates, actualS and actualT: frame call s + s (and) frame call t + t
				double actualS = (q.flipX) ? (int)Math.Floor(parent.Format.BaseWidth * q.S + s) : (int)Math.Floor(parent.Format.BaseWidth * q.s + s);
				double actualT = (int)Math.Floor(parent.Format.BaseHeight * q.t + t);
				// Return the pixel location.
				return new Shapes.Point(actualS, actualT);
			}
			return null;
		}

		private bool frameIsBeneathCursor(RenderableFrameCall q)
		{
			Shapes.Point cursor = new Shapes.Point(CursorX, CursorY);
			Shapes.Point[] hitBox = getHitBoxOfRenderableFrameCall(q);
			// Determine if the cursor is contained in the window space hit box.
			return SupportFunctions.PointIsInPolygon(hitBox, cursor);
		}

		private Shapes.Point[] getHitBoxOfRenderableFrameCall(RenderableFrameCall q)
		{
			Shapes.Point[] hitBox = getHitBoxOfRenderableFrameCallInLocalCoordinates(q);
			// Calculate center point.
			Shapes.Point center = getCenterPoint(hitBox);
			// Project all the points of the frame call's boundaries into the window space.
			for (int i = 0; i < hitBox.Length; i++)
			{
				Shapes.Point thisPoint = hitBox[i];
				// Rotate around center point by rotation.
				if (q.rotationZ != 0)
					thisPoint = rotatePoint(thisPoint, center, q.rotationZ);
				// Project the points.
				Glu.gluProject(thisPoint.X, thisPoint.Y, thisPoint.Z, currentModelviewMatrix, currentProjectionMatrix, currentViewportMatrix, out thisPoint.X, out thisPoint.Y, out thisPoint.Z);
				// Reverse Y.
				thisPoint.Y = simpleOpenGlControl.Height - thisPoint.Y;
				// Update hitbox.
				hitBox[i] = thisPoint;
			}
			return hitBox;
		}

		private static Shapes.Point[] getHitBoxOfRenderableFrameCallInLocalCoordinates(RenderableFrameCall q)
		{
			// Create 1st point with respect to scale.
			double x = q.offsetFromTweenX + q.bound.X + (q.bound.Width / 2.0) - (q.bound.Width * q.scaleX) / 2.0;
			double y = q.offsetFromTweenY + q.bound.Y + (q.bound.Height / 2.0) - (q.bound.Height * q.scaleY) / 2.0;
			double z = q.offsetFromTweenZ + q.OffsetZ;
			// Create 2nd point with respect to scale.
			double x2 = q.offsetFromTweenX + q.bound.X + q.bound.Width - (q.bound.Width / 2.0) + (q.bound.Width * q.scaleX) / 2.0;
			double y2 = q.offsetFromTweenY + q.bound.Y + q.bound.Height - (q.bound.Height / 2.0) + (q.bound.Height * q.scaleY) / 2.0;
			// Create hit box.
			Shapes.Point[] hitBox = new Shapes.Point[] {
				new Shapes.Point(x, y, z),
				new Shapes.Point(x2, y, z),
				new Shapes.Point(x2, y2, z),
				new Shapes.Point(x, y2, z)
			};
			return hitBox;
		}

		private Shapes.Point getCenterPoint(Shapes.Point[] points)
		{
			Shapes.Point minimumPoint = new Shapes.Point(10000);
			Shapes.Point maximumPoint = new Shapes.Point(-10000);
			foreach (Shapes.Point point in points)
			{
				// Source lowest values.
				if (point.X < minimumPoint.X)
					minimumPoint.X = point.X;
				if (point.Y < minimumPoint.Y)
					minimumPoint.Y = point.Y;
				if (point.Z < minimumPoint.Z)
					minimumPoint.Z = point.Z;
				// Source highest values.
				if (point.X > maximumPoint.X)
					maximumPoint.X = point.X;
				if (point.Y > maximumPoint.Y)
					maximumPoint.Y = point.Y;
				if (point.Z > maximumPoint.Z)
					maximumPoint.Z = point.Z;
			}
			Shapes.Point difference = maximumPoint - minimumPoint;
			return new Shapes.Point(X: minimumPoint.X + difference.X / 2.0, Y: maximumPoint.Y - difference.Y / 2.0, Z: minimumPoint.Z + difference.Z / 2.0);
		}

		private Shapes.Point rotatePoint(Shapes.Point pointToRotate, Shapes.Point centerPoint, double angleInDegrees)
		{
			double angleInRadians = angleInDegrees * (Math.PI / 180.0);
			double cosTheta = Math.Cos(angleInRadians);
			double sinTheta = Math.Sin(angleInRadians);
			Shapes.Point difference = pointToRotate - centerPoint;
			return new Shapes.Point
			(
				X: (cosTheta * difference.X - sinTheta * difference.Y + centerPoint.X),
				Y: (sinTheta * difference.X + cosTheta * difference.Y + centerPoint.Y),
				Z: pointToRotate.Z
			);
		}

		private bool alreadySelectedAndBeneathCursor(RenderableFrameCall q)
		{
			return frameIsBeneathCursor(q) && q.selected;
		}

		private void eraseDisplayedData()
		{
			displayDataForFrame(null);
		}

		private void displayDataForFrame(RenderableFrameCall q = null)
		{
			if (q != null)
			{
				offsetXValueLabel.Text = string.Format("{0}", (int)q.bound.X);
				offsetYValueLabel.Text = string.Format("{0}", (int)q.bound.Y);
				offsetZValueLabel.Text = string.Format("{0}", (int)q.OffsetZ);
				offsetIdValueLabel.Text = string.Format("{0}", q.id);
			}
			else
			{
				offsetXValueLabel.Text = string.Format("{0}", 0);
				offsetYValueLabel.Text = string.Format("{0}", 0);
				offsetZValueLabel.Text = string.Format("{0}", 0);
				offsetIdValueLabel.Text = string.Format("{0}", "");
			}
		}

		private void updatePositionOfSelectedFramesFromCursor()
		{
			double scaledCursorDeltaX = CursorDeltaX / scaleX;
			double scaledCursorDeltaY = CursorDeltaY / scaleY;
			// X component.
			double pXofY = scaledCursorDeltaX * (90 + (2 * sceneRotationY + 90)) / 180.0;
			double minorDx = pXofY;
			// Y component.
			double pYofX = scaledCursorDeltaY * (90 + (90 + 2 * sceneRotationX)) / 180.0;
			double minorDy = pYofX;
			// Z component.
			double pZofY = scaledCursorDeltaX * (90 + (-90 + 2 * sceneRotationY)) / 180.0;
			double pZofX = scaledCursorDeltaY * (90 + (-90 - 2 * sceneRotationX)) / 180.0;
			double minorDz = pZofY + pZofX;
			//Console.WriteLine("{0}: {1} + {2}", new object[] { minorDz, pZofX, pZofY });
			// Prepare to find something to show data for.
			bool shownFirst = false;
			// Perform the translation.
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
				{
					//
					q.OffsetX += minorDx;
					q.OffsetY += minorDy;
					q.OffsetZ += minorDz;
					//
					if (!shownFirst)
					{
						displayDataForFrame(q);
						shownFirst = true;
					}
				}
			});
			// Store the changes for reference.
			currentActionOffsetChangeX += minorDx;
			currentActionOffsetChangeY += minorDy;
			currentActionOffsetChangeZ += minorDz;
		}

		private void updateRotationOfSelectedFramesFromCursor()
		{
			double minorDx = CursorDeltaX / 1.0;
			double minorDy = CursorDeltaY / 1.0;
			double parity = (minorDx + minorDy > 0) ? 1 : -1;
			double value = parity * 3.0;
			// Perform the rotation.
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					q.rotationZ += value;
			});
			// Store the changes for reference.
			currentActionRotationChange += value;
		}

		private void updateScaleOfSelectedFramesFromCursor()
		{
			double minorDx = CursorDeltaX / 25.0;
			double minorDy = CursorDeltaY / 25.0;
			// Perform the scale.
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
				{
					q.scaleX += minorDx;
					q.scaleY += minorDy;
				}
			});
			// Store the changes for reference.
			currentActionScaleChangeX += minorDx;
			currentActionScaleChangeY += minorDy;
		}

		private void selectAllFrames()
		{
			bool shownFirst = false;
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				selectFrame(q);
				if (!shownFirst)
				{
					displayDataForFrame(q);
					shownFirst = true;
				}
			});
		}

		private void unselectAllFrames()
		{
			eraseDisplayedData();
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				deselectFrame(q);
			});
		}

		private bool selectFirstFrameBeneathCursorAndDeselectOthers()
		{
			bool foundFirst = false;
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (!foundFirst && frameIsBeneathCursor(q))
				{
					foundFirst = true;
					selectFrame(q);
					displayDataForFrame(q);
				}
				else
					deselectFrame(q);
			});
			return foundFirst;
		}
		#endregion

		private void populateInputInterface()
		{
			// Handle mouse movement.
			inputInterface.AddRange(new List<Input>{
				new Input(MouseButtons.None, handler: modeAwareOnMouseMove),
				new Input(MouseButtons.Middle, handler: panWithMiddleMouseButton),
				new Input(MouseButtons.Left, handler: modeAwareOnLeftClickOrDrag, finallyHandler: modeAwareOnLeftClickFinish),
				new Input(MouseButtons.Right, finallyHandler: modeAwareOnRightClickFinish),
				new Input(Keys.A, handler: modeAwareOnA),
				new Input(Keys.B, handler: modeAwareOnB),
				new Input(Keys.S, handler: modeAwareOnS),
				new Input(Keys.R, handler: modeAwareOnR),
				new Input(Keys.G, handler: modeAwareOnG),
				new Input(Keys.Escape, handler: modeAwareOnEscape),
				new Input(Keys.NumPad1, handler: delegate(Input i) {
					sceneRotationX = sceneRotationY = sceneRotationZ = 0;
				}),
				new Input(Keys.NumPad6, handler: delegate(Input i) {
					sceneRotationY -= 15;
				}),
				new Input(Keys.NumPad4, handler: delegate(Input i) {
					sceneRotationY += 15;
				}),
				new Input(Keys.NumPad8, handler: delegate(Input i) {
					sceneRotationX -= 15;
				}),
				new Input(Keys.NumPad2, handler: delegate(Input i) {
					sceneRotationX += 15;
				}),
				new Input(Keys.Up, handler: modeAwareOnUp, finallyHandler: finallyUpdateDisplayedData),
				new Input(Keys.Down, handler: modeAwareOnDown, finallyHandler: finallyUpdateDisplayedData),
				new Input(Keys.Left, handler: modeAwareOnLeft, finallyHandler: finallyUpdateDisplayedData),
				new Input(Keys.Right, handler: modeAwareOnRight, finallyHandler: finallyUpdateDisplayedData),
				new Input(Keys.Enter, handler: modeAwareOnEnter),
				new Input(Keys.Delete, handler: delegate(Input i) {
					removeSelectedFrames();
				})
			});
		}

		#region EditSelectedFrame Form Events
		private void EditSelectedFrame_Load(object sender, EventArgs e)
		{
			if (!Properties.Settings.Default.currentFrameCallPanelIsOpenESF)
				currentFrameCallButtonPanel_Click(currentFrameCallButtonPanel, null);
			if (!Properties.Settings.Default.scenePanelIsOpenESF)
				sceneButtonPanel_Click(sceneButtonPanel, null);
			if (!Properties.Settings.Default.informationPanelIsOpenESF)
				hideShowInformationPanel_Click(hideShowInformationPanelButton, null);
		}

		private static List<Keys> inputKeys = new List<Keys> { Keys.Up, Keys.Down, Keys.Left, Keys.Right };
		private void EditSelectedFrame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (inputKeys.Contains(e.KeyCode))
				e.IsInputKey = true;
		}

		private static List<Keys> keysOnlyAvailableInKeyDown = new List<Keys> { Keys.Escape, Keys.Enter, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9, Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Delete };
		private void EditSelectedFrame_KeyDown(object sender, KeyEventArgs e)
		{
			if (keysOnlyAvailableInKeyDown.Contains(e.KeyCode))
			{
				Input foundInput = inputInterface.Find(item => item.signature == string.Format("{0}-key", e.KeyCode));
				if (foundInput != null)
				{
					foundInput.activate();
					if (foundInput.handler != null)
						foundInput.handler(foundInput);
					foundInput.deactivate();
				}
			}
		}

		private void EditSelectedFrame_KeyPress(object sender, KeyPressEventArgs e)
		{
			Input foundInput = inputInterface.Find(item => item.signature == string.Format("{0}-key", Char.ToLower(e.KeyChar)) || item.signature == string.Format("{0}-key", Char.ToUpper(e.KeyChar)));
			if (foundInput != null)
			{
				foundInput.activate();
				if (foundInput.handler != null)
					foundInput.handler(foundInput);
				foundInput.deactivate();
			}
		}

		private void EditSelectedFrame_FormClosing(object sender, FormClosingEventArgs e)
		{
			sceneTreeView.Nodes.Clear();
			//
			this.parent.setAutoUpdate(true, m: this.parent);
		}
		#endregion

		#region Drawing Area Events
		private void simpleOpenGlControl_Load(object sender, EventArgs e)
		{
			//
			simpleOpenGlControl.MakeCurrent();
			// Run the resize event manually.
			simpleOpenGlControl_Resize(null, null);
			// Pick the pixel storage type.
			Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
			// Load timers that update features.
			loadFeatureTimers();
		}

		private void unloadFeatureTimers()
		{
			if (scheduleRedraw != null)
			{
				scheduleRedraw.Dispose();
				scheduleRedraw = null;
			}
		}

		private void loadFeatureTimers()
		{
			// Schedule the re-draw task.
			scheduleRedraw = new System.Threading.Timer(delegate(object data)
			{
				currentMilliseconds = Environment.TickCount & Int32.MaxValue;
				if (targetMilliseconds <= currentMilliseconds - startMilliseconds || forceRedraw)
					simpleOpenGlControl.Draw();
			}, "Redrawing Render Control", targetMilliseconds, targetMilliseconds);
		}

		private void simpleOpenGlControl_Paint(object sender, PaintEventArgs e)
		{
			// Set drawing viewport up.
			Gl.glViewport(0, 0, simpleOpenGlControl.Width, simpleOpenGlControl.Height);
			Gl.glClearColor(backgroundColor.R / 255f, backgroundColor.G / 255f, backgroundColor.B / 255f, 0f);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
			// Set features.
			Gl.glEnable(Gl.GL_LINE_SMOOTH);
			Gl.glEnable(Gl.GL_DEPTH_TEST);
			Gl.glDepthFunc(Gl.GL_LEQUAL);
			// Set orthogonal projection.
			SupportFunctions.pushScreenCoordinateMatrix(0, simpleOpenGlControl.Width, simpleOpenGlControl.Height, 0, near: -frameWidth * 2, far: frameWidth * 2);
			{
				// Set blend mode.
				SupportFunctions.setBlendMode("overwrite");
				// Draw everything.
				drawDelegate(drawEverything);
				// Draw dashed box-select lines.
				if (boxSelecting)
					SupportFunctions.DrawBoxSelect(boxSelectStart, boxSelectEnd, depth: frameWidth * 2 - 0.002);
				Gl.glEnable(Gl.GL_BLEND);
				// Draw red cursor if nothing is found beneath cursor.
				if (ActiveMode == Modes.Translation && this.Cursor != System.Windows.Forms.Cursors.Hand && Cursor.Current != null)
					SupportFunctions.DrawNoActionAvailableCursor(CursorX, CursorY, frameWidth * 2 - 0.001);
				else if (ActiveMode == Modes.Paint)
					SupportFunctions.DrawPaintingCursor(CursorX, CursorY, color: PaintColor, halfWidth: 1 * scaleX / 2.0, halfHeight: 1 * scaleY / 2.0, depth: frameWidth - 0.001);
				else if (ActiveMode == Modes.Eraser)
					SupportFunctions.DrawPaintingCursor(CursorX, CursorY, color: backgroundColor, halfWidth: 1 * scaleX / 2.0, halfHeight: 1 * scaleY / 2.0, depth: frameWidth - 0.001);
				Gl.glDisable(Gl.GL_BLEND);
			}
			SupportFunctions.pop_projection_matrix();
			// Push everything out to be drawn.
			Gl.glFlush();
		}

		private void simpleOpenGlControl_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
			double numberOfPixelsToMove = (numberOfTextLinesToMove * (1.0 / 6.0));
			double previousScaleX = scaleX, previousScaleY = scaleY;
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
			simpleOpenGlControl_MouseMove(sender, new MouseEventArgs(MouseButtons.None, 0, e.X, e.Y, e.Delta));
		}

		private void simpleOpenGlControl_MouseClick(object sender, MouseEventArgs e)
		{
			Input foundInput = inputInterface.Find(item => item.signature == string.Format("{0}", e.Button));
			if (foundInput != null && !foundInput.isDragging())
				foundInput.deactivate();
		}

		private void simpleOpenGlControl_MouseMove(object sender, MouseEventArgs e)
		{
			CursorDeltaX = CursorX - CursorLastX;
			CursorDeltaY = CursorY - CursorLastY;
			if (e != null)
			{
				CursorLastX = e.X;
				CursorLastY = e.Y;
			}
			MouseButtons btns = (e != null) ? e.Button : MouseButtons.None;
			//
			if (boxSelecting)
				boxSelectEnd = new Point(CursorX, CursorY);
			//
			Input foundInput = inputInterface.Find(item => item.signature == string.Format("{0}", btns));
			if (foundInput != null && foundInput.handler != null)
				foundInput.handler(foundInput);
		}

		private void simpleOpenGlControl_MouseDown(object sender, MouseEventArgs e)
		{
			Input foundInput = inputInterface.Find(item => item.signature == string.Format("{0}", e.Button));
			if (foundInput != null)
			{
				foundInput.activate();
				// TODO: Figure out why the following consideration is necessary to avoid the first click from being ignored.
				if (ActiveMode == Modes.Paint || ActiveMode == Modes.Eraser)
					if (foundInput.handler != null)
						foundInput.handler(foundInput);
			}
		}

		private void simpleOpenGlControl_MouseUp(object sender, MouseEventArgs e)
		{
			Input foundInput = inputInterface.Find(item => item.signature == string.Format("{0}", e.Button));
			if (foundInput != null)
				foundInput.deactivate();
		}

		private void simpleOpenGlControl_Resize(object sender, EventArgs e)
		{
			gutterX = (int)((simpleOpenGlControl.Width - scaleX * frameWidth) / 2.0);
			gutterY = (int)((simpleOpenGlControl.Height - scaleY * frameHeight) / 2.0);
		}
		#endregion

		#region Drawing Area Functions
		private void drawDelegate(DrawingHandler function)
		{
			Gl.glColor4d(1, 1, 1, 1);
			Gl.glDisable(Gl.GL_CULL_FACE);
			Gl.glPushMatrix();
			{
				// Move into the dead center of the screen.
				Gl.glTranslated(gutterX + scaleX * halfWidth, gutterY + scaleY * halfHeight, 0);
				Gl.glScaled(scaleX, scaleY, scaleZ);
				// Rotate the scene.
				Gl.glRotated(sceneRotationX, 1, 0, 0);
				Gl.glRotated(sceneRotationY, 0, 1, 0);
				Gl.glRotated(sceneRotationZ, 0, 0, 1);
				// Draw delegate.
				function();
			}
			Gl.glPopMatrix();
		}

		private void drawEverything()
		{
			// Draw bounding box.
			SupportFunctions.DrawBoundingBox(halfWidth, halfHeight, halfDepth: halfWidth);
			// Frame calls.
			Gl.glPushMatrix();
			{
				Gl.glTranslated(-halfWidth, -halfHeight, 0);
				// Copy out the current matrices for use later.
				Gl.glGetDoublev(Gl.GL_PROJECTION_MATRIX, currentProjectionMatrix);
				Gl.glGetDoublev(Gl.GL_MODELVIEW_MATRIX, currentModelviewMatrix);
				Gl.glGetIntegerv(Gl.GL_VIEWPORT, currentViewportMatrix);
				// Draw format-specific guide lines.
				if (drawGuidesToolStripMenuItem.Checked)
					SupportFunctions.DrawGuideLines(frameWidth, frameHeight, parent.Format.Guides);
				// During translation, hover select the items.
				if (ActiveMode == Modes.Translation)
				{
					// Draw opaque hover select lines.
					Gl.glPushMatrix();
					{
						for (int i = LoadedFrames.Count - 1; i >= 0; i--)
						{
							Gl.glTranslated(0, 0, 0.001);
							LoadedFrames[i].glRenderHoverSelect();
							// Debug selection hit-box.
							if (false)
								debugHitBox(i);
						}
					}
					Gl.glPopMatrix();
				}
				// Draw optionally transparent sprite geometry (re: draw frame calls).
				Gl.glEnable(Gl.GL_BLEND);
				{
					Gl.glPushMatrix();
					{
						if (parent.loadedImageDescription.ContextId == 0)
							parent.loadedImageDescription.PushToContext = true;
						for (int i = LoadedFrames.Count - 1; i >= 0; i--)
						{
							Gl.glTranslated(0, 0, 0.001);
							if (ActiveMode == Modes.Translation)
								LoadedFrames[i].glRender(parent.loadedImageDescription.ContextId, parent.namedAttachments, parent.Format, renderPath: drawMotionTweenToolStripMenuItem.Checked, renderPoints: drawPointsInTweenToolStripMenuItem.Checked, renderDistance: drawDistanceFromTweenToolStripMenuItem.Checked, useNoSampling: useNoSampling, textureScale: parent.loadedImageDescription.TextureScale);
							else if (ActiveMode == Modes.Paint || ActiveMode == Modes.Eraser)
								LoadedFrames[i].glRender(parent.loadedImageDescription.ContextId, parent.namedAttachments, parent.Format, renderPath: drawMotionTweenToolStripMenuItem.Checked, renderPoints: drawPointsInTweenToolStripMenuItem.Checked, renderDistance: drawDistanceFromTweenToolStripMenuItem.Checked, useNoSampling: useNoSampling, treatSelectionAsPaintable: true, textureScale: parent.loadedImageDescription.TextureScale);
						}
					}
					Gl.glPopMatrix();
				}
				Gl.glDisable(Gl.GL_BLEND);
			}
			Gl.glPopMatrix();
		}

		private void debugHitBox(int i)
		{
			Gl.glEnable(Gl.GL_BLEND);
			Gl.glPushMatrix();
			{
				Gl.glTranslated(0, 0, 1);
				Shapes.Point[] hitBox = getHitBoxOfRenderableFrameCallInLocalCoordinates(LoadedFrames[i]);
				Gl.glColor4d(0.5, 0.5, 0.5, 0.7);
				Gl.glBegin(Gl.GL_QUADS);
				foreach (Shapes.Point p in hitBox)
				{
					Gl.glVertex3d(p.X, p.Y, p.Z);
				}
				Gl.glEnd();
				Gl.glTranslated(0, 0, 1);
				// 
				Shapes.Point center = getCenterPoint(hitBox);
				Gl.glColor4d(1, 1, 1, 1);
				Gl.glPointSize(5f);
				Gl.glBegin(Gl.GL_POINTS);
				foreach (Shapes.Point p in hitBox)
				{
					Gl.glVertex3d(center.X, center.Y, center.Z);
				}
				Gl.glEnd();
			}
			Gl.glPopMatrix();
			Gl.glPushMatrix();
			{
				Gl.glTranslated(0, 0, 1);
				Shapes.Point[] hitBox = getHitBoxOfRenderableFrameCall(LoadedFrames[i]);
				Gl.glColor4d(1, 0, 0, 0.5);
				Gl.glBegin(Gl.GL_QUADS);
				foreach (Shapes.Point p in hitBox)
				{
					Gl.glVertex3d(p.X, p.Y, p.Z);
				}
				Gl.glEnd();
			}
			Gl.glPopMatrix();
			Gl.glDisable(Gl.GL_BLEND);
		}
		#endregion

		#region Drawing Area Context Menu Creation.
		private void CreateAddNewFrameContextMenu()
		{
			addNewFrameMenuItem.DropDownItems.Clear();
			SupportFunctions.ComposeNumericallyGroupedContextMenus(
				parent.Format.AvailableFrameListAsArray,
				addNewFrameFromAvailableFrameGroupsContextMenuStrip,
				delegate(object sender, EventArgs e)
				{
					Shapes.Frame delegateFrame = ((ToolStripItem)sender).Tag as Shapes.Frame;
					if (delegateFrame != null)
					{
						LoadedFrames.Insert(0,
							new RenderableFrameCall(
								id: delegateFrame.id,
								bound: new Shapes.Rect(0, 0, delegateFrame.w, delegateFrame.h),
								s: ((double)delegateFrame.s / (double)parent.loadedImageDescription.Width),
								t: ((double)delegateFrame.t / (double)parent.loadedImageDescription.Height),
								S: ((double)(delegateFrame.s + delegateFrame.w) / (double)parent.loadedImageDescription.Width),
								T: ((double)(delegateFrame.t + delegateFrame.h) / (double)parent.loadedImageDescription.Height),
								flipX: false,
								offsetFromTweenX: 0,
								offsetFromTweenY: 0,
								tween: "0",
								frameInTween: 0,
								blendMode: lastBlendModeToolStripMenuItem.Text,
								selected: true
							)
						);
						compileTreeView();
					}
				}
			);
		}

		private void CreateChangeSelectedFrameContextMenu()
		{
			SupportFunctions.ComposeNumericallyGroupedContextMenus(
				parent.Format.AvailableFrameListAsArray,
				changeSelectedFrameFromAvailableFrameGroupsContextMenuStrip,
				delegate(object sender, EventArgs e)
				{
					Shapes.Frame delegateFrame = ((ToolStripItem)sender).Tag as Shapes.Frame;
					if (delegateFrame != null)
					{
						LoadedFrames.ForEach(delegate(RenderableFrameCall q)
						{
							if (q.selected)
							{
								q.id = delegateFrame.id;
								q.bound = new Shapes.Rect(q.bound.X, q.bound.Y, delegateFrame.w, delegateFrame.h);
								q.s = ((double)delegateFrame.s / (double)parent.loadedImageDescription.Width);
								q.t = ((double)delegateFrame.t / (double)parent.loadedImageDescription.Height);
								q.S = ((double)(delegateFrame.s + delegateFrame.w) / (double)parent.loadedImageDescription.Width);
								q.T = ((double)(delegateFrame.t + delegateFrame.h) / (double)parent.loadedImageDescription.Height);
							}
						});
						compileTreeView();
					}
				}
			);
		}

		private void CreateChangeNamedAttachmentPointContextMenu()
		{
			// Add Named Attachment Points to Context Menu
			SupportFunctions.ComposeNumericallyGroupedContextMenus(
				parent.Format.AvailableNamedAttachmentPointsListAsArray,
				changeNamedAttachmentPointContextMenuStrip,
				delegate(object sender, EventArgs e)
				{
					ToolStripMenuItem thisItem = (ToolStripMenuItem)sender;
					Shapes.NamedAttachmentPoint point = thisItem.Tag as Shapes.NamedAttachmentPoint;
					LoadedFrames.ForEach(delegate(RenderableFrameCall q)
					{
						if (q.selected)
							q.namedAttachmentPointId = point.id;
					});
					compileTreeView();
				}
			);
		}

		private void CreateChangeSelectedTweenContextMenu()
		{
			// Add Motion Tweens to Context Menu
			parent.Format.AvailableTweenList.ForEach(delegate(Shapes.Tween tw)
			{
				ToolStripMenuItem tweenItem = new ToolStripMenuItem(tw.id);
				for (int i = 1; i <= tw.FrameLength; i++)
				{
					tweenItem.DropDownItems.Add(string.Format("{0}", i), null, delegate(object sender, EventArgs e)
					{
						// Run through all frame calls in this composite frame.
						LoadedFrames.ForEach(delegate(RenderableFrameCall q)
						{
							// Only work on the ones that are actually selected.
							if (q.selected)
							{
								// Get the tween identifier.
								string tweenId = ((ToolStripMenuItem)sender).OwnerItem.Text;
								// Apply it to the frame call.
								q.tween = tweenId;
								q.frameInTween = int.Parse(((ToolStripMenuItem)sender).Text);
								Shapes.Tween tweenToAdd = parent.Format.AvailableTweenList.Find(item => item.id == tweenId);
								if (tweenToAdd != null && q.NoColorAtFrameCall)
								{
									if (tweenToAdd.HasColorComponent)
										q.color = tweenToAdd.colorFromFrame(q.frameInTween);
									Shapes.Point p = tweenToAdd.XYZFromFrame(q.frameInTween);
									// Add tween offset.
									q.offsetFromTweenX = (int)p.X;
									q.offsetFromTweenY = (int)p.Y;
									q.offsetFromTweenZ = (int)p.Z;
									// Rewrite regular offset.
									q.bound.X = -q.bound.Width / 2;
									q.bound.Y = -q.bound.Height / 2;
								}
							}
						});
						compileTreeView();
					});
				}
				changeSelectedTweenContextMenuStrip.Items.Add(tweenItem);
			});
		}

		private void ComposeMotionTrailContextMenus()
		{
			// Create motion trail drop downs.
			ContextMenuStrip instance = new ContextMenuStrip();
			instance.RenderMode = ToolStripRenderMode.System;
			List<IdentificationProperty> availableIds = new List<IdentificationProperty>();
			for (int i = 0; i <= SomeSelectedTween.FrameLength; i++)
				availableIds.Add(new Shapes.FrameInTween(i));
			SupportFunctions.ComposeNumericallyGroupedContextMenus(
				availableIds.ToArray(),
				instance,
				delegate(object thisSender, EventArgs args)
				{
					ToolStripMenuItem thisItem = (ToolStripMenuItem)thisSender;
					Shapes.NamedAttachmentPoint point = thisItem.Tag as Shapes.NamedAttachmentPoint;
					LoadedFrames.ForEach(delegate(RenderableFrameCall q)
					{
						if (q.selected)
						{
							q.motionTrailType = "instance";
							q.motionTrailFramesInTween = int.Parse(thisItem.Text);
						}
					});
					compileTreeView();
				}
			);
			instanceToolStripMenuItem.DropDown = instance;
			//
			ContextMenuStrip instancefill = new ContextMenuStrip();
			instancefill.RenderMode = ToolStripRenderMode.System;
			SupportFunctions.ComposeNumericallyGroupedContextMenus(
				availableIds.ToArray(),
				instancefill,
				delegate(object thisSender, EventArgs args)
				{
					ToolStripMenuItem thisItem = (ToolStripMenuItem)thisSender;
					Shapes.NamedAttachmentPoint point = thisItem.Tag as Shapes.NamedAttachmentPoint;
					LoadedFrames.ForEach(delegate(RenderableFrameCall q)
					{
						if (q.selected)
						{
							q.motionTrailType = "instance-fill";
							q.motionTrailFramesInTween = int.Parse(thisItem.Text);
						}
					});
					compileTreeView();
				}
			);
			instancefillToolStripMenuItem.DropDown = instancefill;
		}

		private void CreateChangeOverriddenColorContextMenu()
		{
			// Add Motion Tweens to Context Menu
			parent.Format.AvailableColorList.ForEach(delegate(Shapes.Color c)
			{
				ToolStripMenuItem colorItem = new ToolStripMenuItem(c.name);
				colorItem.Tag = c;
				colorItem.Click += new EventHandler(delegate(object control, EventArgs e) {
					LoadedFrames.ForEach(delegate(RenderableFrameCall q)
					{
						if (q.selected)
						{
							ToolStripMenuItem thisItem = (ToolStripMenuItem)control;
							if (thisItem != null && thisItem.Tag is Shapes.Color)
							{
								Shapes.Color thisColor = (Shapes.Color)thisItem.Tag;
								if (thisColor != null) {
									q.color = thisColor.color;
									q.colorName = thisColor.name;
								}
							}
						}
					});
					compileTreeView();
				});
				overrideColorContextMenuStrip.Items.Add(colorItem);
			});
		}
		#endregion

		#region Drawing Area Context Menu Functions
		private void previewAreaContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			bool thereIsASelection = AtLeastOneFrameIsSelected;
			// Adding functions.
			addSoundToolStripMenuItem.Enabled = (addSoundContextMenuStrip.Items.Count > 0 && thereIsASelection) ? true : false;
			// Ordering functions.
			sendBackwardToolStripMenuItem.Enabled = (thereIsASelection) ? true : false;
			copyInPlaceToolStripMenuItem.Enabled = (thereIsASelection) ? true : false;
			bringForwardToolStripMenuItem.Enabled = (thereIsASelection) ? true : false;
			// Manipulation functions.
			changeSelectedFrameMenuItem.Enabled = thereIsASelection;
			changeSelectedNamedAttachmentPointToolStripMenuItem.Enabled = (this.parent.Format.AvailableNamedAttachmentPointsList.Count > 0 && thereIsASelection) ? true : false;
			changeSelectedOrientationMenuItem.Enabled = thereIsASelection;
			changeSelectedBlendingMenuItem.Enabled = thereIsASelection;
			changeSelectedTweenMenuItem.Enabled = (changeSelectedTweenContextMenuStrip.Items.Count > 0 && thereIsASelection) ? true : false;
			changeMotionTrailToolStripMenuItem.Enabled = (thereIsASelection && SomeSelectedFrameHasTween) ? true : false;
			if (changeMotionTrailToolStripMenuItem.Enabled)
				ComposeMotionTrailContextMenus();
			changeOverrideColorToolStripMenuItem.Enabled = (overrideColorContextMenuStrip.Items.Count > 0 && thereIsASelection) ? true : false;
			//
			// Removal functions.
			removeSelectedFrameMenuItem.Enabled = thereIsASelection;
			removeSoundToolStripMenuItem.Enabled = (removeSoundContextMenuStrip.Items.Count > 0 && thereIsASelection) ? true : false;
			// Clearing functions.
			clearScalingMenuItem.Enabled = SomeSelectedFrameHasScaling;
			clearRotationMenuItem.Enabled = SomeSelectedFrameHasRotation;
			clearSelectedTweenMenuItem.Enabled = SomeSelectedFrameHasTween;
			clearSelectedNamedAttachmentPointToolStripMenuItem.Enabled = SomeSelectedFrameHasNamedAttachmentPoint;
			clearOverrideColorToolStripMenuItem.Enabled = SomeSelectedFrameHasAnOverridenColor;
		}

		private void saveFrameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int writeThisFrame = (this.parent.advanceRows * this.parent.columns) + (this.parent.advanceColumns + 1);
			if (this.parent != null && this.parent.loadedFormat != "")
			{
				if (File.Exists(this.parent.Format.Path("sprite.xml")))
				{
					List<string> sounds = new List<string>();
					for (int i = 0; i < removeSoundContextMenuStrip.Items.Count; i++)
						sounds.Add(removeSoundContextMenuStrip.Items[i].Text);
					// Save the quads to the file.
					SupportFunctions.SaveQuadListToCompositeFrameXML(
						baseLocation: this.parent.baseLocation,
						format: this.parent.loadedFormat,
						writeThisFrame: writeThisFrame,
						loadedFrames: LoadedFrames,
						sounds: sounds
					);
					//
					Thread saveFrame = new Thread(new ThreadStart(delegate()
					{
						this.parent.Format.LoadOrReloadCompositeFrame(writeThisFrame, reloadRoot: true);
						this.parent.loadCompositeFrames(this.parent, new int[] { writeThisFrame }, noOverwriteStartEndFrames: true);
					}));
					saveFrame.Name = string.Format("Save Frame: {0}", writeThisFrame);
					saveFrame.Start();
				}
			}
		}

		private void defaultBlendMenuItem_Click(object sender, EventArgs e)
		{
			lastBlendModeToolStripMenuItem.Checked = false;
			switch (((ToolStripMenuItem)sender).Text)
			{
				case "lighten":
					lightenToolStripMenuItem.Checked = true;
					lastBlendModeToolStripMenuItem = lightenToolStripMenuItem;
					break;
				case "linear-burn":
					linearBurnToolStripMenuItem.Checked = true;
					lastBlendModeToolStripMenuItem = linearBurnToolStripMenuItem;
					break;
				case "linear-dodge":
					linearDodgeToolStripMenuItem.Checked = true;
					lastBlendModeToolStripMenuItem = linearDodgeToolStripMenuItem;
					break;
				case "color-burn":
					colorBurnToolStripMenuItem.Checked = true;
					lastBlendModeToolStripMenuItem = colorBurnToolStripMenuItem;
					break;
				case "color-dodge":
					colorDodgeToolStripMenuItem.Checked = true;
					lastBlendModeToolStripMenuItem = colorDodgeToolStripMenuItem;
					break;
				case "darken":
					darkenToolStripMenuItem.Checked = true;
					lastBlendModeToolStripMenuItem = darkenToolStripMenuItem;
					break;
				case "screen":
					screenToolStripMenuItem.Checked = true;
					lastBlendModeToolStripMenuItem = screenToolStripMenuItem;
					break;
				case "multiply":
					multiplyToolStripMenuItem.Checked = true;
					lastBlendModeToolStripMenuItem = multiplyToolStripMenuItem;
					break;
				case "overwrite":
				default:
					overwriteToolStripMenuItem.Checked = true;
					lastBlendModeToolStripMenuItem = overwriteToolStripMenuItem;
					break;
			}
		}

		private void removeSelectedFrameMenuItem_Click(object sender, EventArgs e)
		{
			removeSelectedFrames();
		}

		private void removeSelectedFrames()
		{
			for (int i = LoadedFrames.Count - 1; i >= 0; i--)
			{
				if (LoadedFrames[i].selected || LoadedFrames[i].hoverSelected)
					LoadedFrames.RemoveAt(i);
			}
			compileTreeView();
		}

		private void normalMenuItem_Click(object sender, EventArgs e)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected && q.flipX == true)
				{
					double s = q.s;
					q.s = q.S;
					q.S = s;
					q.flipX = false;
				}
			});
			compileTreeView();
		}

		private void reversedMenuItem_Click(object sender, EventArgs e)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected && q.flipX == false)
				{
					double s = q.s;
					q.s = q.S;
					q.S = s;
					q.flipX = true;
				}
			});
			compileTreeView();
		}

		private void changeSelectedBlendModeMenuItem_Click(object sender, EventArgs e)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					q.blendMode = ((ToolStripMenuItem)sender).Text;
			});
			compileTreeView();
		}

		private void clearScalingMenuItem_Click(object sender, EventArgs e)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					q.scaleY = q.scaleX = 1;
			});
			compileTreeView();
		}

		private void clearRotationMenuItem_Click(object sender, EventArgs e)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					q.rotationZ = 0;
			});
			compileTreeView();
		}

		private void clearSelectedTweenMenuItem_Click(object sender, EventArgs e)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
				{
					q.OffsetX += q.offsetFromTweenX;
					q.OffsetY += q.offsetFromTweenY;
					q.OffsetZ += q.offsetFromTweenZ;
					q.offsetFromTweenX = 0;
					q.offsetFromTweenY = 0;
					q.offsetFromTweenZ = 0;
					q.tween = "0";
					q.frameInTween = 0;
					q.motionTrailType = "instance";
					q.motionTrailFramesInTween = 0;
				}
			});
			compileTreeView();
		}

		private void clearOverrideColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Remove color on selected calls.
			foreach (RenderableFrameCall call in LoadedFrames)
			{
				if (call.selected && !call.NoColorAtFrameCall)
					call.clearOverriddenColor(parent.Format);
			}
		}

		private void addSoundContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (removeSoundContextMenuStrip.Items.Find(e.ClickedItem.Text, false).Length == 0)
			{
				removeSoundContextMenuStrip.Items.Add(e.ClickedItem.Text);
				e.ClickedItem.Enabled = false;
			}
		}

		private void removeSoundContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			for (int i = 0; i < addSoundContextMenuStrip.Items.Count; i++)
				if (addSoundContextMenuStrip.Items[i].Text == e.ClickedItem.Text)
					addSoundContextMenuStrip.Items[i].Enabled = true;
			for (int i = removeSoundContextMenuStrip.Items.Count; i > 0; i--)
				if (removeSoundContextMenuStrip.Items[i - 1].Text == e.ClickedItem.Text)
					removeSoundContextMenuStrip.Items.RemoveAt(i - 1);
		}

		private void clearSelectedNamedAttachmentPointToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					q.namedAttachmentPointId = 0;
			});
			compileTreeView();
		}

		private void bringForwardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Prepare to store the currently selected items' indices.
			List<int> selectedIndices = new List<int>();
			// Iterate over all the frame calls, storing the indices.
			int i = 0;
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					selectedIndices.Add(i);
				i++;
			});
			// Prepare to store the resulting indices.
			List<int> resultIndices = new List<int>();
			// Iterate over the selected items' indices specifically, swapping the item with its predecessor in the list.
			foreach (int index in selectedIndices)
			{
				// If the selected item isn't at the top of the list and the index below it isn't protected, perform the swap.
				if (index > 0 && !resultIndices.Contains(index - 1))
				{
					RenderableFrameCall tmp = LoadedFrames[index];
					LoadedFrames[index] = LoadedFrames[index - 1];
					LoadedFrames[index - 1] = tmp;
					// Protect selected indices.
					resultIndices.Add(index - 1);
				}
				else
					resultIndices.Add(index);
			}
			// Update the frame display.
			compileTreeView();
		}

		private void copyInPlaceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<RenderableFrameCall> replacementList = new List<RenderableFrameCall>();
			// Iterate over all the frame calls, duplicating selected objects.
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				// Add once always.
				replacementList.Add(q);
				// If selected, add twice.
				if (q.selected)
					replacementList.Add(new RenderableFrameCall(q));
			});
			// Replace it.
			LoadedFrames = replacementList;
			// Update the frame display.
			compileTreeView();
		}

		private void sendBackwardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Prepare to store the currently selected items' indices.
			List<int> selectedIndices = new List<int>();
			// Iterate over all the frame calls, storing the indices.
			int i = 0;
			LoadedFrames.ForEach(delegate(RenderableFrameCall q)
			{
				if (q.selected)
					selectedIndices.Add(i);
				i++;
			});
			selectedIndices.Reverse();
			// Prepare to store the resulting indices.
			List<int> resultIndices = new List<int>();
			// Iterate over the selected items' indices specifically, swapping the item with its successor in the list.
			foreach (int index in selectedIndices)
			{
				// If the selected item isn't at the top of the list and the index below it isn't protected, perform the swap.
				if (index < LoadedFrames.Count - 1 && !resultIndices.Contains(index + 1))
				{
					RenderableFrameCall tmp = LoadedFrames[index];
					LoadedFrames[index] = LoadedFrames[index + 1];
					LoadedFrames[index + 1] = tmp;
					// Protect selected indices.
					resultIndices.Add(index + 1);
				}
				else
					resultIndices.Add(index);
			}
			// Update the frame display.
			compileTreeView();
		}
		#endregion

		#region Tool-Related Events
		private void scaleUp_Click(object sender, EventArgs e)
		{
			scaleX += 1;
			scaleY += 1;
			simpleOpenGlControl_Resize(sender, e);
		}

		private void scaleDown_Click(object sender, EventArgs e)
		{
			if (scaleX > 1)
				scaleX -= 1;
			if (scaleY > 1)
				scaleY -= 1;
			simpleOpenGlControl_Resize(sender, e);
		}

		private void eraseModeButton_Click(object sender, EventArgs e)
		{
			ActiveMode = (eraseModeButton.Checked) ? Modes.Eraser : Modes.Translation;
		}

		private void paintModeButton_Click(object sender, EventArgs e)
		{
			ActiveMode = (paintModeButton.Checked) ? Modes.Paint : Modes.Translation;
		}

		ColorControl.ColorControl paintColorDialog = null;
		private void paintColorSwatchPanel_Click(object sender, EventArgs e)
		{
			// Create.
			if (paintColorDialog == null)
			{
				paintColorDialog = new ColorControl.ColorControl();
				paintColorDialog.Color = paintColorSwatchPanel.BackColor;
			}
			// Setup.
			if (paintColorDialog.SelectedMode == ColorControl.ColorControl.Mode.DontCare)
				paintColorDialog.SelectedMode = ColorControl.ColorControl.Mode.Palette;
			//
			Dictionary<string, List<ColorControl.PalettedColor>> palettes = this.parent.StoredPalettes;
			string file = this.parent.loadedImageDescription.Filename;
			if (palettes.ContainsKey(file))
			{
				List<ColorControl.PalettedColor> list = palettes[file];
				paintColorDialog.PalettedColors = list;
			}
			else
			{
				List<Color> list = new List<Color>();
				foreach (Color color in Palette.colorsInPalette)
					list.Add(color);
				paintColorDialog.colorListToPalette(list);
			}
			// Give priority.
			this.parent.unloadDrawingFeatureTimers();
			unloadFeatureTimers();
			// Show.
			if (paintColorDialog.ShowDialog() == DialogResult.OK)
				paintColorSwatchPanel.BackColor = paintColorDialog.Color;
			// Yield priority.
			this.parent.loadFeatureTimers(this.parent);
			loadFeatureTimers();
		}
		#endregion

		#region Information Panel Events
		private void hideShowInformationPanel_Click(object sender, EventArgs e)
		{
			if (hideShowInformationPanelButton.Text == "►")
			{
				hideShowInformationPanelButton.Text = "◄";
				informationTableLayoutPanel.Hide();
				Properties.Settings.Default.informationPanelIsOpenESF = false;
			}
			else
			{
				hideShowInformationPanelButton.Text = "►";
				informationTableLayoutPanel.Show();
				Properties.Settings.Default.informationPanelIsOpenESF = true;
			}
			simpleOpenGlControl.Focus();
			Properties.Settings.Default.Save();
		}

		private void currentFrameCallButtonPanel_Click(object sender, EventArgs e)
		{
			if (currentFrameCallContainerPanel.Visible)
			{
				currentFrameCallContainerPanel.Hide();
				Properties.Settings.Default.currentFrameCallPanelIsOpenESF = false;
			}
			else
			{
				currentFrameCallContainerPanel.Show();
				currentFrameCallContainerPanel.Height = (scenePanel.Visible) ? 105 : informationTableLayoutPanel.Height - 20 * 2;
				Properties.Settings.Default.currentFrameCallPanelIsOpenESF = true;
			}
			Properties.Settings.Default.Save();
		}

		private void sceneButtonPanel_Click(object sender, EventArgs e)
		{
			if (scenePanel.Visible)
			{
				scenePanel.Hide();
				currentFrameCallContainerPanel.Height = (currentFrameCallContainerPanel.Visible) ? informationTableLayoutPanel.Height - 20 * 2 : 105;
				Properties.Settings.Default.scenePanelIsOpenESF = false;
			}
			else
			{
				scenePanel.Show();
				currentFrameCallContainerPanel.Height = 105;
				Properties.Settings.Default.scenePanelIsOpenESF = true;
			}
			Properties.Settings.Default.Save();
		}
		#endregion

		#region Tree View
		private void sceneTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
		{
			Color backColor, foreColor;
			if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
			{
				backColor = SystemColors.Highlight;
				foreColor = SystemColors.HighlightText;
			}
			else if ((e.State & TreeNodeStates.Hot) == TreeNodeStates.Hot)
			{
				backColor = SystemColors.HotTrack;
				foreColor = SystemColors.HighlightText;
			}
			else
			{
				backColor = e.Node.BackColor;
				foreColor = e.Node.ForeColor;
			}

			using (SolidBrush brush = new SolidBrush(backColor))
			{
				int offset = 18, offsetRight = 3;
				if (e.Node.Level == 2)
				{
					offset = 19;
					offsetRight = 4;
				}
				e.Graphics.FillRectangle(brush, new Rectangle(e.Node.Bounds.X - offset, e.Node.Bounds.Y + 1, sceneTreeView.Width - e.Node.Bounds.X - offsetRight, e.Node.Bounds.Height - 1));
			}

			// Regular Text
			TextRenderer.DrawText(e.Graphics, e.Node.Text, sceneTreeView.Font, new Rectangle(e.Node.Bounds.X, e.Node.Bounds.Y, e.Node.Bounds.Width, e.Node.Bounds.Height), foreColor, backColor);

			// Tag Text
			if (e.Node.Tag != null)
			{
				Font tagFont = new Font("Helvetica", 8, FontStyle.Bold);
				int tagWidth = (int)e.Graphics.MeasureString(e.Node.Tag.ToString(), tagFont).Width + 6;
				TextRenderer.DrawText(e.Graphics, e.Node.Tag.ToString(), tagFont, new Rectangle(170, e.Node.Bounds.Y, tagWidth, e.Node.Bounds.Height), foreColor, backColor);
			}

			if (e.Node.SelectedImageIndex >= 0 && sceneTreeView.ImageList != null && sceneTreeView.ImageList.Images.Count > e.Node.SelectedImageIndex)
			{
				Point p = e.Node.Bounds.Location;
				p.Offset(-19, 0);
				e.Graphics.DrawImage(sceneTreeView.ImageList.Images[e.Node.SelectedImageIndex], p);
			}

			if ((e.State & TreeNodeStates.Focused) == TreeNodeStates.Focused)
			{
				int offset = 18, offsetRight = 3;
				if (e.Node.Level == 2)
				{
					offset = 19;
					offsetRight = 4;
				}
				ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(e.Node.Bounds.X - offset, e.Node.Bounds.Y, sceneTreeView.Width - e.Node.Bounds.X - offsetRight, e.Node.Bounds.Height), foreColor, backColor);
			}
		}

		private bool internalSceneTreeViewCheck = false;
		private void sceneTreeView_AfterCheck(object sender, TreeViewEventArgs e)
		{
			TreeNode parentNode = e.Node.Parent;
			if (parentNode != null && parentNode.Text == "Frame Calls")
			{
				// Select the frame's quad.
				int index = LoadedFrames.Count - (e.Node.Index + 1);
				if (index >= 0 && index < LoadedFrames.Count)
					LoadedFrames[index].selected = e.Node.Checked;
				// Keep the parent appropriately checked or unchecked.
				bool everythingIsChecked = true;
				foreach (TreeNode n in parentNode.Nodes)
					everythingIsChecked = (n.Checked) ? everythingIsChecked : false;
				// Do the updates in a non-reactive programming state (i.e. ignore the subsequent AfterCheck event that must happen based on this process).
				internalSceneTreeViewCheck = true;
				{
					if (everythingIsChecked && !parentNode.Checked)
						parentNode.Checked = true;
					else if (!everythingIsChecked && parentNode.Checked)
						parentNode.Checked = false;
				}
				internalSceneTreeViewCheck = false;
			}
			else if (e.Node.Text == "Frame Calls" && internalSceneTreeViewCheck == false)
			{
				bool targetCheckState = e.Node.Checked;
				foreach (TreeNode n in e.Node.Nodes)
					if (n.Checked != targetCheckState)
						n.Checked = targetCheckState;
			}
		}

		private void sceneTreeView_Leave(object sender, EventArgs e)
		{
			sceneTreeView.SelectedNode = null;
			sceneTreeView.Refresh();
		}

		private void compileTreeView()
		{
			// Clear out the tree view.
			sceneTreeView.Nodes.Clear();
			// Fill the tree view with the same items.
			sceneTreeView.Nodes.AddRange(
				SupportFunctions.consumeListOfDictionaryNodes(
					new List<Dictionary<string, object>> {
						new Dictionary<string, object> {
							{"name", "Available Colors"},
							{"icon", 1},
							{"children", SupportFunctions.compileListOfDictionaryNodesRepresentingColorList(parent.Format.AvailableColorList)}
						},
						new Dictionary<string, object> {
							{"name", "Available Tweens"},
							{"icon", 0},
							{"children", SupportFunctions.compileListOfDictionaryNodesRepresentingTweenList(parent.Format.AvailableTweenList)}
						},
						new Dictionary<string, object> {
							{"name", "Frame Calls"},
							{"icon", 6},
							{"children", SupportFunctions.compileListOfDictionaryNodesRepresentingFrameCalls(LoadedFrames, this.parent.Format.AvailableNamedAttachmentPointsList, parent.Format.AvailableTweenList)}
						}
					}
				)
			);
			// Reselect since everything gets destroyed and remade.
			internalSceneTreeViewCheck = true;
			{
				int i = 0;
				foreach (TreeNode n in sceneTreeView.Nodes[2].Nodes)
				{
					n.Checked = LoadedFrames[LoadedFrames.Count - 1 - i].selected;
					i++;
				}
			}
			internalSceneTreeViewCheck = false;
			// Expand the frames node to show a list of ordered frames.
			sceneTreeView.Nodes[2].Expand();
		}
		#endregion
	}
}
