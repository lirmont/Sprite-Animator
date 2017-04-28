using System;
using System.Collections.Generic;
using System.Drawing;
using Tao.OpenGl;

#pragma warning disable
namespace ColorControl
{
	public abstract class LayoutEngine
	{
		double startingDegree = 0;
		double majorIncrement = 1, minorIncrementDivisor = 2;

		public double StartingDegree
		{
			get { return startingDegree; }
			set { startingDegree = value; }
		}

		public LayoutEngine(double startingDegree, double majorIncrement, double minorIncrementDivisor)
		{
			this.startingDegree = startingDegree;
			this.majorIncrement = majorIncrement;
			this.minorIncrementDivisor = minorIncrementDivisor;
		}

		private double angleOfColor(PalettedColor color)
		{
			if (color.Parent != null)
			{
				foreach (double angle in color.Parent.Children.Keys)
				{
					PalettedColor childColor = color.Parent.Children[angle];
					if (color == childColor)
						return angle;
				}
			}
			return startingDegree;
		}

		public double GetNextAvailableDegree(PalettedColor color)
		{
			double foundDegree = angleOfColor(color);
			double runningDegreeDelta = 0;
			while (color.Children.ContainsKey(foundDegree) || (color.ReverseDegree != null && color.ReverseDegree.Value == foundDegree))
			{
				int rotations = (int)(runningDegreeDelta / 360.0);
				double divisor = (rotations < 1) ? 1.0 : minorIncrementDivisor * rotations;
				double thisIncrement = majorIncrement / divisor;
				// If the degree hasn't made it full circle yet, use the major increment. Otherwise, use the minor increment to help prevent repeat degrees.
				foundDegree += thisIncrement;
				// Clamp the values between -360 and 360.
				if (foundDegree >= 360 || foundDegree <= -360)
					foundDegree = foundDegree % 360;
				// Advance the iteration count (used for positional awareness).
				runningDegreeDelta += thisIncrement;
				// If there has been exactly one revolution, then offset the function to begin using minor increments instead.
				if (runningDegreeDelta == 360) {
					double firstMinorIncrement = majorIncrement / minorIncrementDivisor;
					foundDegree = startingDegree - firstMinorIncrement;
					runningDegreeDelta += firstMinorIncrement;
				}
			}
			return foundDegree;
		}

		public virtual List<PointF> getPointsFromCount(int count, int width, int height)
		{
			int thisCount = (count % 2 == 0) ? count : count - 1;
			List<PointF> points = new List<PointF>();
			int halfIndex = (int)Math.Floor(count / 2.0);
			// Following that, generate pairs.
			if (count > 1)
			{
				int secondaryIndex = 0;
				for (int i = 1; i <= thisCount; i++)
				{
					if (i <= thisCount / 2.0)
					{
						float modifier = (float)Math.Ceiling(i / 4.0);
						float x = -1 * modifier;
						float y = 1 * modifier;
						if (i % 4 == 0)
							points.Add(new PointF(y, y));
						else if (i % 3 == 0)
							points.Add(new PointF(x, x));
						else if (i % 2 == 0)
							points.Add(new PointF(y, x));
						else
							points.Add(new PointF(x, y));
					}
					else
					{
						int sPlusOne = secondaryIndex + 1;
						if (halfIndex < 2)
							points.Add(new PointF(points[secondaryIndex].Y, points[secondaryIndex].X));
						else if (halfIndex < 3)
						{
							if (sPlusOne % 2 == 0)
								points.Add(new PointF(-1 * points[secondaryIndex].X, points[secondaryIndex].Y));
							else
								points.Add(new PointF(points[secondaryIndex].Y, -1 * points[secondaryIndex].X));
						}
						else
						{
							if (sPlusOne % 3 == 0 || sPlusOne % 2 == 0)
								points.Add(new PointF(-1 * points[secondaryIndex].X, points[secondaryIndex].Y + 1));
							else
								points.Add(new PointF(-1 * points[secondaryIndex].X, points[secondaryIndex].Y));
						}
						secondaryIndex++;
					}
				}
			}
			// If this is an odd iteration, add unity as the first point.
			if (count > 0 && count % 2 != 0)
				points.Insert(0, new PointF(0, 0));
			//
			return points;
		}

		public virtual void glRender(List<PalettedColor> palettedColors, int width, int height, bool colorPickingMode = false)
		{
			int numericIndex = 1;
			List<PointF> points = getPointsFromCount(palettedColors.Count, width, height);
			for (int i = 0; i < palettedColors.Count; i++)
			{
				PalettedColor color = palettedColors[i];
				Gl.glPushMatrix();
				{
					Gl.glTranslated(width / 4.0 * points[i].X, -height / 4.0 * points[i].Y, 0);
					unitRender(color, ref numericIndex, colorPickingMode: colorPickingMode);
				}
				Gl.glPopMatrix();
			}
		}

		public virtual void unitRender(PalettedColor thisColor, ref int iteration, bool colorPickingMode = false)
		{
			Gl.glPushMatrix();
			{
				Gl.glScaled(thisColor.Size.Width, thisColor.Size.Height, 1);
				Gl.glBegin(Gl.GL_QUADS);
				{
					if (colorPickingMode)
						SupportFunctions.glPushColor(Color.FromArgb(-1 * iteration));
					else if (thisColor.IsSelected || thisColor.IsHoverSelected)
						SupportFunctions.glPushColor(Color.Yellow);
					else
						SupportFunctions.glPushColor(thisColor.Color);
					Gl.glVertex2d(-0.5, 0.5);
					Gl.glVertex2d(0.5, 0.5);
					Gl.glVertex2d(0.5, -0.5);
					Gl.glVertex2d(-0.5, -0.5);
				}
				Gl.glEnd();
			}
			Gl.glPopMatrix();
			iteration++;
			//
			if (thisColor.Children.Count > 0)
				foreach (double angle in thisColor.Children.Keys)
				{
					PalettedColor childColor = thisColor.Children[angle];
					Gl.glRotated(angle, 0, 0, -1);
					double d = 0;
					if (angle % 45 == 0 && angle % 90 != 0)
					{
						double a = Math.Pow((thisColor.Size.Width + childColor.Size.Width) / 2.0, 2);
						double b = Math.Pow((thisColor.Size.Height + childColor.Size.Height) / 2.0, 2);
						d = Math.Sqrt(a + b);
					}
					else
						d = (thisColor.Size.Width + childColor.Size.Width) / 2.0;
					//
					Gl.glTranslated(d, 0, 0);
					Gl.glRotated(angle, 0, 0, 1);
					unitRender(childColor, ref iteration, colorPickingMode: colorPickingMode);
					// Undo translation. Due to the sheer amount of geometry involved, push/pop matrix features will be insufficient. So, simulate the glPopMatrix functionality here.
					Gl.glRotated(angle, 0, 0, -1);
					Gl.glTranslated(-d, 0, 0);
					Gl.glRotated(angle, 0, 0, 1);
				}
		}

		public virtual PalettedColor resolveColor(List<PalettedColor> palettedColors, Color pickedColor)
		{
			int numericIndex = 1;
			PalettedColor foundColor = null;
			for (int i = 0; i < palettedColors.Count; i++)
			{
				if (foundColor == null)
				{
					PalettedColor color = palettedColors[i];
					foundColor = unitResolveColor(color, pickedColor, ref numericIndex);
				}
			}
			return foundColor;
		}

		// Color.FromArgb(int): -1 to -16777216; white to black.
		public virtual PalettedColor unitResolveColor(PalettedColor thisColor, Color pickedColor, ref int iteration)
		{
			Color thisIdentificationColor = Color.FromArgb(-1 * iteration);
			if (thisIdentificationColor.ToArgb() == pickedColor.ToArgb())
				return thisColor;
			//
			iteration++;
			//
			if (thisColor.Children.Count > 0)
				foreach (double angle in thisColor.Children.Keys)
				{
					PalettedColor childColor = thisColor.Children[angle];
					PalettedColor foundColor = unitResolveColor(childColor, pickedColor, ref iteration);
					if (foundColor != null)
						return foundColor;
				}
			return null;
		}
	}
}