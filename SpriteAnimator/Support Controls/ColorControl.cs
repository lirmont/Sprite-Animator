using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tao.OpenGl;
using System.IO;

#pragma warning disable
namespace ColorControl
{
	public partial class ColorControl : Form
	{
		/*
		 * Re-draw viewports based on milliseconds.
		 */
		public int targetMilliseconds = 20, targetMS = 143;
		public int startMilliseconds = 0, currentMilliseconds = 0;
		private System.Threading.Timer scheduleRedraw;
		private bool forceRedraw = false;

		// Set a variable to allow internal updates without spawning events.
		bool ignoreTextChanges = false;
		bool ignoreAnyFutureRequests = false;

		public bool DialogClosing
		{
			get { return ignoreAnyFutureRequests; }
			set { ignoreAnyFutureRequests = value; }
		}

		// Help file.
		string helpTemporaryFile = null;

		// Color comparison feature.
		Color? previousColor = null;

		public Color? PreviousColor
		{
			get { return previousColor; }
			set {
				previousColor = value;
				if (previousColor != null)
				{
					// Recalculate color distance.
					updateColorDifference();
					//
					colorComparisonFlowLayoutPanel.BackColor = previousColor.Value;
					colorDisplayPanel.Height = (int)Math.Ceiling((colorComparisonFlowLayoutPanel.Height - SystemInformation.Border3DSize.Height * 2) / 2.0);
					colorDifferenceTableLayoutPanel.Visible = true;
				}
				else
				{
					colorDisplayPanel.Height = colorComparisonFlowLayoutPanel.Height - SystemInformation.Border3DSize.Height * 2;
					colorDifferenceTableLayoutPanel.Visible = false;
				}
			}
		}

		public Color Color
		{
			get
			{
				RGB rgb = new HSV(HueDegree, SaturationZeroToOne, ValueZeroToOne);
				return Color.FromArgb(255, rgb.Red, rgb.Green, rgb.Blue);
			}
			set
			{
				setPickedColorByColor(value, doNotIgnoreType: true);
			}
		}

		public enum Mode { DontCare = 0, ColorSelect = 1, Palette = 2 };

		private Mode mode = Mode.DontCare;

		public Mode SelectedMode
		{
			get { return mode; }
			set {
				mode = value;
				if (mode == Mode.ColorSelect)
					simpleOpenGlControl.ContextMenuStrip = colorSelectContextMenuStrip;
				else if (mode == Mode.Palette)
					simpleOpenGlControl.ContextMenuStrip = storedColorsContextMenuStrip;
			}
		}

		public ColorControl()
		{
			InitializeComponent();
			//
			simpleOpenGlControl.MouseWheel += new MouseEventHandler(simpleOpenGlControl_MouseWheel);
			// Color comparsion set up.
			setPickedColorByColor((PreviousColor != null) ? new RGB(PreviousColor.Value) : (RGB)new HSV(0, 1, 1), doNotIgnoreType: true);
			// Palette mode settings.
			createSteppingContextMenu();
			// Mode select.
			SelectedMode = (mode == Mode.DontCare) ? Mode.ColorSelect : mode;
		}

		Color? getLowestLabColorInList(List<Color> list)
		{
			Color? lowestColor = null;
			CIELab? lowestLabColor = null;
			foreach (Color color in list)
			{
				CIELab thisColor = new RGB(color);
				if (lowestColor == null || thisColor.L < lowestLabColor.Value.L)
				{
					lowestColor = color;
					lowestLabColor = thisColor;
				}
			}
			return lowestColor;
		}

		public void colorListToPalette(List<Color> list)
		{
			if (list.Count == 0)
				return;
			//
			List<Color> availableColorList = new List<Color>();
			Color? lowestColor = getLowestLabColorInList(list);
			// Compile list of colors available to be added.
			foreach (Color color in list)
				if (color != lowestColor.Value)
					availableColorList.Add(color);
			//
			List<PalettedColor> replacementList = new List<PalettedColor>();
			if (lowestColor != null)
			{
				Stack<PalettedColor> stack = new Stack<PalettedColor>();
				PalettedColor theLowestColor = new PalettedColor(lowestColor.Value);
				stack.Push(theLowestColor);
				int iterations = 0;
				while (stack.Count > 0)
				{
					iterations++;
					PalettedColor current = stack.Pop();
					HSV thisHSVColor = new RGB(current.Color);
					CIELab thisLabColor = new RGB(current.Color);
					//
					double? lowestColorDifference = null;
					List<double> differenceList = new List<double>();
					foreach (Color availableColor in availableColorList)
					{
						CIELab availableLabColor = new RGB(availableColor);
						double thisDifference = SupportFunctions.ColorDifference(thisLabColor, availableLabColor);
						differenceList.Add(thisDifference);
						if (lowestColorDifference == null || thisDifference < lowestColorDifference.Value)
							lowestColorDifference = thisDifference;
					}
					//
					if (lowestColorDifference != null)
					{
						// Add all the colors that are around X% different from the current color as children.
						Stack<int> usedIndices = new Stack<int>();
						int index = 0;
						foreach (double difference in differenceList)
						{
							Color thisPotentialChildColor = availableColorList[index];
							HSV thisPotentialChildHSVColor = new RGB(thisPotentialChildColor);
							double acceptableDifference = 0.25;
							double hueDifference = Math.Abs(thisPotentialChildHSVColor.Hue - thisHSVColor.Hue);
							// Complement hueDifference if necessary (ex: 360 - 0 should result in 0, rather than 360).
							if (hueDifference > 180)
								hueDifference = 360 - hueDifference;
							//
							double lDifference = ((CIELab)thisPotentialChildHSVColor).L - thisLabColor.L;
							//
							bool hueMatched = (0 <= hueDifference && hueDifference < 36);
							bool lightnessIsIncreasing = (0 <= lDifference && lDifference <= 50);
							bool colorsAreNotMoreThanXDifferent = lowestColorDifference.Value < 65;
							bool colorsAreNearLowestDifference = lowestColorDifference.Value * (1 - acceptableDifference) < difference && difference < lowestColorDifference.Value * (1 + acceptableDifference);
							bool matched = (current.Parent == null) ? lightnessIsIncreasing && colorsAreNotMoreThanXDifferent && colorsAreNearLowestDifference : hueMatched && lightnessIsIncreasing && colorsAreNotMoreThanXDifferent && colorsAreNearLowestDifference;
							//
							if (matched)
							{
								usedIndices.Push(index);
								PalettedColor thisChildPalettedColor = current.addColorAsChild(thisPotentialChildColor, PaletteLayoutEngine);
								stack.Push(thisChildPalettedColor);
							}
							index++;
						}
						// Clear used colors from available colors.
						foreach (int usedIndex in usedIndices)
							availableColorList.RemoveAt(usedIndex);
					}
					// Add the paletted color as a top-level color if it has no parent.
					if (current.Parent == null)
						replacementList.Add(current);
					// If the colors are too different as to probably be unrelated, start the stack over.
					if (stack.Count == 0 && availableColorList.Count > 0)
					{
						Color? nextLowestColor = getLowestLabColorInList(availableColorList);
						if (nextLowestColor != null)
						{
							stack.Push(new PalettedColor(nextLowestColor.Value));
							availableColorList.Remove(nextLowestColor.Value);
						}
					}
				}
			}
			// Finally, replace the list.
			PalettedColors = replacementList;
		}

		void simpleOpenGlControl_MouseWheel(object sender, MouseEventArgs e)
		{
			if (mode == Mode.ColorSelect)
				colorSelectMode_MouseWheel(sender, e);
			else if (mode == Mode.Palette)
				paletteMode_MouseWheel(sender, e);
		}

		private void ColorControl_FormClosing(object sender, FormClosingEventArgs e)
		{
			ignoreAnyFutureRequests = true;
		}

		private void ColorControl_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Delete the help file's temporary file, if it exists.
			if (helpTemporaryFile != null && File.Exists(helpTemporaryFile))
			{
				try
				{
					// Catch failure to delete.
					File.Delete(helpTemporaryFile);
				}
				catch (Exception) { }
			}
		}

		private void SimpleOpenGlControlDraw(ColorControl m)
		{
			try
			{
				if (!m.ignoreAnyFutureRequests && !m.IsDisposed && !m.simpleOpenGlControl.IsDisposed)
					m.Invoke((MethodInvoker)delegate
					{
						m.simpleOpenGlControl.Draw();
					});
			}
			catch (Exception e) { }
		}

		private void ColorControl_Load(object sender, EventArgs e)
		{
			simpleOpenGlControl.InitializeContexts();
		}

		// Drawing Context handlers.
		private void simpleOpenGlControl_Load(object sender, EventArgs e)
		{
			simpleOpenGlControl.MakeCurrent();
			Gl.glPixelStorei(Gl.GL_PACK_ALIGNMENT, 1);
			simpleOpenGlControl_Resize(simpleOpenGlControl, null);
			loadFeatureTimers();
		}

		private void loadFeatureTimers()
		{
			// Thread: Redraw the display area at an interval of target-ms.
			scheduleRedraw = new System.Threading.Timer(delegate(object data)
			{
				currentMilliseconds = Environment.TickCount & Int32.MaxValue;
				if (targetMilliseconds <= currentMilliseconds - startMilliseconds || forceRedraw)
					simpleOpenGlControl.Invalidate();
			}, "Redrawing Render Control", targetMilliseconds, targetMilliseconds);
			currentMilliseconds = Environment.TickCount & Int32.MaxValue;
			startMilliseconds = currentMilliseconds - targetMilliseconds;
		}

		private void simpleOpenGlControl_Resize(object sender, EventArgs e)
		{
			Tao.Platform.Windows.SimpleOpenGlControl control = sender as Tao.Platform.Windows.SimpleOpenGlControl;
			// Resize drawing components.
			colorSelectMode_Resize(sender, e);
			// Resize drawing.
			Gl.glViewport(0, 0, control.Width, control.Height);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Gl.glClearColor(this.BackColor.R / 255.0f, this.BackColor.G / 255.0f, this.BackColor.B / 255.0f, 0);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
		}

		private void simpleOpenGlControl_Paint(object sender, PaintEventArgs e)
		{
			simpleOpenGlControl_Resize(simpleOpenGlControl, null);
			//
			Gl.glEnable(Gl.GL_BLEND);
			SupportFunctions.setBlendMode("default");
			Gl.glLineWidth(1f);
			Gl.glDisable(Gl.GL_DEPTH_TEST);
			// Draw it.
			simpleOpenGlControl_Draw();
		}

		private void simpleOpenGlControl_Draw()
		{
			if (SelectedMode == Mode.ColorSelect)
				colorSelectMode_Draw();
			else if (SelectedMode == Mode.Palette)
				paletteMode_Draw();
		}

		private void simpleOpenGlControl_MouseDown(object sender, MouseEventArgs e)
		{
			if (SelectedMode == Mode.ColorSelect)
				colorSelectMode_MouseDown(e);
			else if (SelectedMode == Mode.Palette)
				paletteMode_MouseDown(e);
		}

		private void simpleOpenGlControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (SelectedMode == Mode.ColorSelect)
				colorSelectMode_MouseMove(e);
			else if (SelectedMode == Mode.Palette)
				paletteMode_MouseMove(e);
		}

		private void simpleOpenGlControl_MouseUp(object sender, MouseEventArgs e)
		{
			if (SelectedMode == Mode.ColorSelect)
				colorSelectMode_MouseUp();
			else if (SelectedMode == Mode.Palette)
				paletteMode_MouseUp();
		}

		// Buttons Panel handlers.
		private void colorDisplayPanel_BackColorChanged(object sender, EventArgs e)
		{
			updateColorDifference();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			ignoreAnyFutureRequests = true;
			this.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			ignoreAnyFutureRequests = true;
			this.Close();
		}

		private void helpButton_Click(object sender, EventArgs e)
		{
			// If there is no temporary file name on record, create one.
			if (helpTemporaryFile == null)
				helpTemporaryFile = Path.GetTempFileName() + ".chm";
			// If the temporary file does not exist, create it.
			if (!File.Exists(helpTemporaryFile))
				File.WriteAllBytes(helpTemporaryFile, SpriteAnimator.Properties.Resources.ColorControlDocumentation);
			// Finally, load the help file.
			if (File.Exists(helpTemporaryFile))
				Help.ShowHelp(this, helpTemporaryFile);
			else
				MessageBox.Show("Error: Could not load help file.");
		}

		private void colorSelectContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			PalettedColor.Handler action = (PalettedColor.Handler)delegate()
			{
				if (autoCompareOnStoreToolStripMenuItem.Checked)
					PreviousColor = Color;
			};
			storeColorToPaletteToolStripMenuItem.DropDown.Items.Clear();
			//
			ToolStripMenuItem item = new ToolStripMenuItem("Add as Top-Level Color");
			item.Click += new EventHandler(delegate(object s, EventArgs es)
			{
				PalettedColors.Add(new PalettedColor(Color));
				action.DynamicInvoke();
			});
			storeColorToPaletteToolStripMenuItem.DropDown.Items.Add(item);
			//
			if (PalettedColors.Count > 0)
				foreach (PalettedColor color in PalettedColors)
					storeColorToPaletteToolStripMenuItem.DropDown.Items.Add(color.generateToolStripMenuItem(Color, engine: PaletteLayoutEngine, action: action));
		}

		private void genericStepColorSpaceToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			List<ToolStripMenuItem> listOfColorSpaceSteppingModes = new List<ToolStripMenuItem> { stepHSVToolStripMenuItem, stepRGBToolStripMenuItem, stepXYZToolStripMenuItem, stepLabToolStripMenuItem };
			//
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			if (item.Checked)
			{
				foreach (ToolStripMenuItem sibling in listOfColorSpaceSteppingModes)
				{
					if (sibling != item && sibling.Checked == true)
						sibling.Checked = false;
				}
			}
			//
			if (listOfColorSpaceSteppingModes.TrueForAll(menuItem => menuItem.Checked == false))
				stepLabToolStripMenuItem.Checked = true;
		}
	}
}
