using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Tao.OpenGl;

#pragma warning disable
namespace ColorControl
{
	public partial class ColorControl : Form
	{
		bool SomePalettedColorIsSelected
		{
			get
			{
				if (PalettedColors.Count > 0)
					foreach (PalettedColor color in PalettedColors)
						if (color.IsSelected || color.IsHoverSelected || color.HasAChildThatIsSelected || color.HasAChildThatIsHoverSelected)
							return true;
				return false;
			}
		}

		LayoutEngine engine = new SquareLayoutEngine();

		public LayoutEngine PaletteLayoutEngine
		{
			get { return engine; }
			set { engine = value; }
		}

		List<PalettedColor> palettedColors = new List<PalettedColor>();

		public List<PalettedColor> PalettedColors
		{
			get { return palettedColors; }
			set { palettedColors = value; }
		}

		//
		Shapes.Point previousCursorLocation = new Shapes.Point(0, 0);

		public Shapes.Point PreviousCursorLocation
		{
			get { return previousCursorLocation; }
			set { previousCursorLocation = value; }
		}

		Shapes.Point paletteGutter = new Shapes.Point(0, 0);

		public Shapes.Point PaletteGutter
		{
			get { return paletteGutter; }
			set { paletteGutter = value; }
		}

		private PalettedColor SelectedStoredColor
		{
			get
			{
				PalettedColor foundColor = null;
				if (PalettedColors.Count > 0)
					foreach (PalettedColor color in PalettedColors)
					{
						if (foundColor == null)
							foundColor = color.selectedColor();
					}
				return foundColor;
			}
		}

		// Drawing.
		private void paletteMode_Draw(bool colorPicking = false)
		{
			if (colorPicking)
				Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			//
			Gl.glPushAttrib(Gl.GL_CURRENT_BIT);
			{
				Gl.glPushMatrix();
				{
					// Push a pixel projection to draw cursors and 1px borders.
					SupportFunctions.pushScreenCoordinateMatrix(ProjectionBoxScreenCoordinates.Left, ProjectionBoxScreenCoordinates.Right, ProjectionBoxScreenCoordinates.Bottom, ProjectionBoxScreenCoordinates.Top);
					{
						Gl.glTranslated(PaletteGutter.X + ProjectionBoxScreenCoordinates.Left + ProjectionBoxScreenCoordinates.Width / 2.0, PaletteGutter.Y + ProjectionBoxScreenCoordinates.Bottom - ProjectionBoxScreenCoordinates.Height / 2.0, PaletteGutter.Z);
						Gl.glScaled(PaletteZoomFactor, PaletteZoomFactor, 1.0);
						// TODO: Layout.
						PaletteLayoutEngine.glRender(palettedColors, ProjectionBoxScreenCoordinates.Width, ProjectionBoxScreenCoordinates.Height, colorPickingMode: colorPicking);
					}
					SupportFunctions.pop_projection_matrix();
				}
				Gl.glPopMatrix();
			}
			Gl.glPopAttrib();
			//
			if (colorPicking)
				Gl.glFinish();
		}

		private void paletteMode_MouseMove(MouseEventArgs e)
		{
			Shapes.Point point = new Shapes.Point(e.X + simpleOpenGlControl.Location.X, e.Y + simpleOpenGlControl.Location.Y);
			PalettedColor color = getPixelAtPoint(point);
			if (e.Button == MouseButtons.None)
			{
				palettedColors.ForEach(delegate(PalettedColor thisColor)
				{
					thisColor.unHoverSelectColors();
				});
				if (color != null)
					color.IsHoverSelected = true;
			}
			else if (e.Button == MouseButtons.Middle)
			{
				Shapes.Point delta = point - PreviousCursorLocation;
				PaletteGutter += delta;
			}
			PreviousCursorLocation = point;
		}

		private void paletteMode_MouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Shapes.Point point = new Shapes.Point(e.X + simpleOpenGlControl.Location.X, e.Y + simpleOpenGlControl.Location.Y);
				//
				PalettedColor color = getPixelAtPoint(point);
				palettedColors.ForEach(delegate(PalettedColor thisColor)
				{
					thisColor.unselectColors();
				});
				if (color != null)
				{
					color.IsSelected = true;
					if (automaticallyUseSelectedColorAsActiveColorToolStripMenuItem.Checked)
						setPickedColorByColor(color.Color);
				}
			}
		}

		private void paletteMode_MouseUp() { }

		private double paletteZoomFactor = 1.0;

		public double PaletteZoomFactor
		{
			get { return paletteZoomFactor; }
			set {
				if (value > 0.045)
					paletteZoomFactor = value;
				else
					paletteZoomFactor = 0.05;
			}
		}

		void paletteMode_MouseWheel(object sender, MouseEventArgs e)
		{
			PaletteZoomFactor += e.Delta / 1000.0;
		}

		private void switchToColorSelectModeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectedMode = Mode.ColorSelect;
		}

		private PalettedColor getPixelAtPoint(Shapes.Point point)
		{
			int drawBuffer = Gl.GL_BACK;
			Gl.glGetIntegerv(Gl.GL_DRAW_BUFFER, out drawBuffer);
			//
			Gl.glDrawBuffer(Gl.GL_AUX0);
			Gl.glReadBuffer(Gl.GL_AUX0);
			//
			paletteMode_Draw(colorPicking: true);
			// Read pixel from back buffer at mouse pos.
			byte[] pixel = new byte[4];
			int[] viewport = new int[4];
			// Flip Y-axis (Windows <-> OpenGL)
			Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);
			Gl.glReadPixels((int)point.x, (int)(simpleOpenGlControl.Location.Y + viewport[3] - point.y), 1, 1, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixel);
			Color colorAtPoint = Color.FromArgb(pixel[3], pixel[0], pixel[1], pixel[2]);
			//
			Gl.glDrawBuffer(drawBuffer);
			Gl.glReadBuffer(drawBuffer);
			//
			return PaletteLayoutEngine.resolveColor(palettedColors, colorAtPoint);
		}

		// Context menu related.
		private void storedColorsContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			removeStoredColorToolStripMenuItem.Enabled = SomePalettedColorIsSelected;
			replaceStoredColorWithActiveColorToolStripMenuItem.Enabled = SomePalettedColorIsSelected;
			useStoredColorAsActiveColorToolStripMenuItem.Enabled = SomePalettedColorIsSelected;
			useStoredColorForComparisonToolStripMenuItem.Enabled = SomePalettedColorIsSelected;
			stepToActiveColorFromStoredColorToolStripMenuItem.Enabled = SomePalettedColorIsSelected;
		}

		private void removeStoredColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < PalettedColors.Count; i++)
			{
				PalettedColor color = palettedColors[i];
				if (color.IsSelected || color.IsHoverSelected)
					palettedColors.RemoveAt(i);
				else if (color.HasAChildThatIsSelected || color.HasAChildThatIsHoverSelected)
					color.removeSelectedColors();
			}
		}

		private void replaceStoredColorWithActiveColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (PalettedColors.Count > 0)
				foreach (PalettedColor color in PalettedColors)
					color.replaceSelectedWithColor(Color);
		}

		private void useStoredColorForComparisonToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SelectedStoredColor != null)
				PreviousColor = SelectedStoredColor.Color;
		}

		private void useStoredColorAsActiveColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SelectedStoredColor != null)
				setPickedColorByColor(new RGB(SelectedStoredColor.Color), doNotIgnoreType: true);
		}

		private void createSteppingContextMenu()
		{
			//
			List<int> list = new List<int>();
			for (int i = 1; i <= 100; i++)
				list.Add(i);
			SupportFunctions.ComposeNumericallyGroupedContextMenus(list.ToArray(), steppingContextMenuStrip, delegate(object sender, EventArgs e)
			{
				ToolStripMenuItem item = sender as ToolStripMenuItem;
				int stepCount = (int)item.Tag;
				if (SelectedStoredColor != null)
				{
					if (stepXYZToolStripMenuItem.Checked)
					{
						CIEXYZ start = new RGB(SelectedStoredColor.Color);
						CIEXYZ end = new RGB(Color);
						double deltaX = (end.X - start.X) / (double)stepCount;
						double deltaY = (end.Y - start.Y) / (double)stepCount;
						double deltaZ = (end.Z - start.Z) / (double)stepCount;
						PalettedColor previousSteppedColor = SelectedStoredColor;
						for (int i = 1; i <= stepCount; i++)
						{
							CIEXYZ next = new CIEXYZ(start.X + i * deltaX, start.Y + i * deltaY, start.Z + i * deltaZ);
							PalettedColor steppedColor = new PalettedColor((RGB)next);
							previousSteppedColor.addColorAsChild(steppedColor, PaletteLayoutEngine);
							previousSteppedColor = steppedColor;
						}
					}
					else if (stepRGBToolStripMenuItem.Checked)
					{
						Color start = SelectedStoredColor.Color;
						Color end = Color;
						double deltaX = (end.R - start.R) / (double)stepCount;
						double deltaY = (end.G - start.G) / (double)stepCount;
						double deltaZ = (end.B - start.B) / (double)stepCount;
						PalettedColor previousSteppedColor = SelectedStoredColor;
						for (int i = 1; i <= stepCount; i++)
						{
							Color next = Color.FromArgb(255, (int)(start.R + i * deltaX), (int)(start.G + i * deltaY), (int)(start.B + i * deltaZ));
							PalettedColor steppedColor = new PalettedColor(next);
							previousSteppedColor.addColorAsChild(steppedColor, PaletteLayoutEngine);
							previousSteppedColor = steppedColor;
						}
					}
					else if (stepHSVToolStripMenuItem.Checked)
					{
						HSV start = new RGB(SelectedStoredColor.Color);
						HSV end = new RGB(Color);
						double deltaX = (end.Hue - start.Hue) / (double)stepCount;
						double deltaY = (end.Saturation - start.Saturation) / (double)stepCount;
						double deltaZ = (end.Value - start.Value) / (double)stepCount;
						PalettedColor previousSteppedColor = SelectedStoredColor;
						for (int i = 1; i <= stepCount; i++)
						{
							HSV next = new HSV(start.Hue + i * deltaX, start.Saturation + i * deltaY, start.Value + i * deltaZ);
							PalettedColor steppedColor = new PalettedColor((RGB)next);
							previousSteppedColor.addColorAsChild(steppedColor, PaletteLayoutEngine);
							previousSteppedColor = steppedColor;
						}
					}
					else if (stepLabToolStripMenuItem.Checked)
					{
						CIELab start = new RGB(SelectedStoredColor.Color);
						CIELab end = new RGB(Color);
						double deltaX = (end.L - start.L) / (double)stepCount;
						double deltaY = (end.A - start.A) / (double)stepCount;
						double deltaZ = (end.B - start.B) / (double)stepCount;
						PalettedColor previousSteppedColor = SelectedStoredColor;
						for (int i = 1; i <= stepCount; i++)
						{
							CIELab next = new CIELab(start.L + i * deltaX, start.A + i * deltaY, start.B + i * deltaZ);
							PalettedColor steppedColor = new PalettedColor((RGB)next);
							previousSteppedColor.addColorAsChild(steppedColor, PaletteLayoutEngine);
							previousSteppedColor = steppedColor;
						}
					}
				}
			});
		}
	}
}