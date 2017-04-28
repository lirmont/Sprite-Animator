using System;
using System.Drawing;
using Tao.OpenGl;
using System.Windows.Forms;

#pragma warning disable
namespace ColorControl
{
	public static class SupportFunctions
	{
		public static void ComposeNumericallyGroupedContextMenus(int[] items, System.Windows.Forms.ContextMenuStrip stripToHoldGroups, System.EventHandler handler, int sizePerGroup = 10)
		{
			if (items.Length > 0)
			{
				// Determine amount of items that fit into N groups (where N is the size per group; ex: 10 groups of 10 objects).
				int sizeSquared = sizePerGroup * sizePerGroup;
				// Scale the list based on size.
				if (items.Length > sizeSquared)
					sizePerGroup *= 1 + items.Length / (sizeSquared + 1);
				//
				sizePerGroup = Math.Min(40, sizePerGroup);
				// Count how many menu item lists will be needed to house the frame assets.
				int createXMenuItemLists = (items.Length / sizePerGroup) + Math.Min(items.Length % sizePerGroup, 1);
				for (int cursorInList = 0; cursorInList < createXMenuItemLists; cursorInList++)
				{
					int startInclusive = Math.Min(cursorInList * sizePerGroup, items.Length - 1);
					int endNonInclusive = ((cursorInList + 1) * sizePerGroup <= items.Length) ? (cursorInList + 1) * sizePerGroup : items.Length;
					ToolStripMenuItem t = new ToolStripMenuItem(string.Format("{0} - {1}", items[startInclusive], items[endNonInclusive - 1]));
					for (int startI = startInclusive; startI < endNonInclusive; startI++)
					{
						ToolStripMenuItem item = new ToolStripMenuItem(string.Format("{0}", items[startI]), null, handler);
						item.Tag = items[startI];
						t.DropDownItems.Add(item);
					}
					stripToHoldGroups.Items.Add(t);
				}
			}
		}

		public static T Clamp<T>(T value, T min, T max) where T : System.IComparable<T>
		{
			T result = value;
			if (value.CompareTo(max) > 0)
				result = max;
			if (value.CompareTo(min) < 0)
				result = min;
			return result;
		}

		/// <summary>
		/// Loads a default projection matrix, transforming it into a virtual 2d drawing context. Must be closed by either the pop_projection_matrix or by Gl.glPopMatrix().
		/// </summary>
		/// <param name="left">Left edge. Typically zero.</param>
		/// <param name="right">Right edge. Typically the width of the control.</param>
		/// <param name="bottom">Bottom edge. Typically the height of the control.</param>
		/// <param name="top">Top edge. Typically zero.</param>
		/// <param name="near">Negative depth. Typically negative two times the frame width.</param>
		/// <param name="far">Positive depth. Typically two times the frame width.</param>
		public static void pushScreenCoordinateMatrix(int left, int right, int bottom, int top, int near = -1, int far = 1)
		{
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glPushMatrix();
			{
				Gl.glLoadIdentity();
				Gl.glOrtho(left, right, bottom, top, near, far);
			}
		}

		/// <summary>
		/// Pops the projection matrix made by the pushScreenCoordinateMatrix function. Synonymous with Gl.glPopMatrix().
		/// </summary>
		public static void pop_projection_matrix()
		{
			Gl.glPopMatrix();
		}

		public static void glPushColor(Color color)
		{
			Gl.glColor4d(color.R / 255.0, color.G / 255.0, color.B / 255.0, color.A / 255.0);
		}

		public static void glPushColor(Color? color)
		{
			if (color == null)
				color = Color.White;
			Gl.glColor4d(color.Value.R / 255.0, color.Value.G / 255.0, color.Value.B / 255.0, color.Value.A / 255.0);
		}

		/// <summary>
		/// Sets the color blending function for use with Gl.GL_BLEND. Intentionally does not try to use features past OpenGL 1.1.
		/// </summary>
		/// <param name="blend">Abstracted name of blending mode.</param>
		public static void setBlendMode(string blend = "overwrite")
		{
			// ex: Red = (Red-Incoming * Red-Incoming Blend Factor +  Red-Existing * Red-Existing Blend Factor)
			switch (blend)
			{
				case "multiply":
					// Target * Blend
					Gl.glBlendFunc(Gl.GL_DST_COLOR, Gl.GL_ZERO);
					break;
				default:
					Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
					Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
					break;
			}
		}

		/// <summary>
		/// Draw something resembling a circle within an OpenGL context.
		/// </summary>
		/// <param name="k"></param>
		/// <param name="r"></param>
		/// <param name="h"></param>
		/// <param name="outline"></param>
		/// <param name="fill"></param>
		public static void drawCircle(double k = 0.0, double r = 1.1, double h = 0.0, Color? outline = null, Color? fill = null)
		{
			int vertexCount = 80;
			if (outline == null)
				outline = outline ?? Color.FromArgb(255, 223, 228, 237);
			Color clearArea = Color.Black;
			Gl.glPushAttrib(Gl.GL_CURRENT_BIT);
			{
				Gl.glLineWidth(1);
				SupportFunctions.setBlendMode("line");
				Shapes.Point circle = new Shapes.Point(0, 0);
				if (outline != null)
				{
					circle = new Shapes.Point(0, 0);
					Gl.glColor4d(outline.Value.R / 255.0, outline.Value.G / 255.0, outline.Value.B / 255.0, outline.Value.A / 255.0);
					Gl.glBegin(Gl.GL_LINE_STRIP);
					{
						for (int i = 0; i < vertexCount + 1; i++)
						{
							double currentLocation = (2 * Math.PI / (float)vertexCount) * i;
							circle.x = r * Math.Cos(currentLocation) - h;
							circle.y = r * Math.Sin(currentLocation) + k;
							Gl.glVertex3d(circle.x + k, circle.y - h, 0f);
						}
					}
					Gl.glEnd();
				}
			}
		}

		/// <summary>
		/// Determines if the given point is inside the polygon
		/// </summary>
		/// <param name="polygon">the vertices of polygon</param>
		/// <param name="testPoint">the given point</param>
		/// <returns>true if the point is inside the polygon; otherwise, false</returns>
		public static bool PointIsInPolygon(Shapes.Point[] polygon, Shapes.Point testPoint)
		{
			bool result = false;
			int j = polygon.Length - 1;
			for (int i = 0; i < polygon.Length; i++)
			{
				if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
				{
					if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
					{
						result = !result;
					}
				}
				j = i;
			}
			return result;
		}

		public static bool PointInRectangle(RectangleF rectangle, Shapes.Point point)
		{
			return SupportFunctions.PointIsInPolygon(new Shapes.Point[] { 
				new Shapes.Point(rectangle.Left, rectangle.Top),
				new Shapes.Point(rectangle.Right, rectangle.Top),
				new Shapes.Point(rectangle.Right, rectangle.Bottom),
				new Shapes.Point(rectangle.Left, rectangle.Bottom)
			}, point);
		}

		/// <summary>
		/// Returns the color difference (distance) between a sample color CIELab(2) and a reference color CIELab(1) in accordance with CIE 2000 algorithm.
		/// </summary>
		/// <param name="lab1">CIELab reference color.</param>
		/// <param name="lab2">CIELab sample color.</param>
		/// <returns>Color difference.</returns>
		public static float ColorDifference(CIELab lab1, CIELab lab2)
		{
			double p25 = Math.Pow(25, 7);

			double C1 = Math.Sqrt(lab1.A * lab1.A + lab1.B * lab1.B);
			double C2 = Math.Sqrt(lab2.A * lab2.A + lab2.B * lab2.B);
			double avgC = (C1 + C2) / 2F;

			double powAvgC = Math.Pow(avgC, 7);
			double G = (1 - Math.Sqrt(powAvgC / (powAvgC + p25))) / 2D;

			double a_1 = lab1.A * (1 + G);
			double a_2 = lab2.A * (1 + G);

			double C_1 = Math.Sqrt(a_1 * a_1 + lab1.B * lab1.B);
			double C_2 = Math.Sqrt(a_2 * a_2 + lab2.B * lab2.B);
			double avgC_ = (C_1 + C_2) / 2D;

			double h1 = (Atan(lab1.B, a_1) >= 0 ? Atan(lab1.B, a_1) : Atan(lab1.B, a_1) + 360F);
			double h2 = (Atan(lab2.B, a_2) >= 0 ? Atan(lab2.B, a_2) : Atan(lab2.B, a_2) + 360F);

			double H = (h1 - h2 > 180D ? (h1 + h2 + 360F) / 2D : (h1 + h2) / 2D);

			double T = 1;
			T -= 0.17 * Cos(H - 30);
			T += 0.24 * Cos(2 * H);
			T += 0.32 * Cos(3 * H + 6);
			T -= 0.20 * Cos(4 * H - 63);

			double deltah = 0;
			if (h2 - h1 <= 180)
				deltah = h2 - h1;
			else if (h2 <= h1)
				deltah = h2 - h1 + 360;
			else
				deltah = h2 - h1 - 360;

			double avgL = (lab1.L + lab2.L) / 2F;
			double deltaL_ = lab2.L - lab1.L;
			double deltaC_ = C_2 - C_1;
			double deltaH_ = 2 * Math.Sqrt(C_1 * C_2) * Sin(deltah / 2);

			double SL = 1 + (0.015 * Math.Pow(avgL - 50, 2)) / Math.Sqrt(20 + Math.Pow(avgL - 50, 2));
			double SC = 1 + 0.045 * avgC_;
			double SH = 1 + 0.015 * avgC_ * T;

			double exp = Math.Pow((H - 275) / 25, 2);
			double teta = Math.Pow(30, -exp);

			double RC = 2D * Math.Sqrt(Math.Pow(avgC_, 7) / (Math.Pow(avgC_, 7) + p25));
			double RT = -RC * Sin(2 * teta);

			double deltaE = 0;
			deltaE = Math.Pow(deltaL_ / SL, 2);
			deltaE += Math.Pow(deltaC_ / SC, 2);
			deltaE += Math.Pow(deltaH_ / SH, 2);
			deltaE += RT * (deltaC_ / SC) * (deltaH_ / SH);
			deltaE = Math.Sqrt(deltaE);

			return (float)deltaE;
		}

		/// <summary>
		/// Returns the angle in degree whose tangent is the quotient of the two specified numbers.
		/// </summary>
		/// <param name="y">The y coordinate of a point.</param>
		/// <param name="x">The x coordinate of a point.</param>
		/// <returns>Angle in degree.</returns>
		private static double Atan(double y, double x)
		{
			return Math.Atan2(y, x) * 180D / Math.PI;
		}

		/// <summary>
		/// Returns the cosine of the specified angle in degree.
		/// </summary>
		/// <param name="d">Angle in degree</param>
		/// <returns>Cosine of the specified angle.</returns>
		private static double Cos(double d)
		{
			return Math.Cos(d * Math.PI / 180);
		}

		/// <summary>
		/// Returns the sine of the specified angle in degree.
		/// </summary>
		/// <param name="d">Angle in degree</param>
		/// <returns>Sine of the specified angle.</returns>
		private static double Sin(double d)
		{
			return Math.Sin(d * Math.PI / 180);
		}
	}
}
