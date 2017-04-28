using System;
using System.Collections.Generic;
using System.Drawing;
using Tao.OpenGl;

#pragma warning disable
namespace SpriteAnimator
{
	partial class SupportFunctions
	{
		public static void DrawBoundingBox(double halfWidth = 100, double halfHeight = 100, double halfDepth = 0, Color? border = null, Color? rearBorder = null)
		{
			// Get a color for the actual border.
			if (border == null)
				border = Color.White;
			// Get a color for the rear border.
			if (rearBorder == null)
				rearBorder = Color.FromArgb(255 / 4, 255 / 4, 255 / 4);
			// Draw border.
			SupportFunctions.render(-halfWidth, halfWidth, halfHeight, -halfHeight, depth: halfDepth, color: border, blendMode: "line", drawingMode: Gl.GL_LINE_LOOP, lineWidth: 2f);
			// If there's a depth component, create the outlines of a cube.
			if (halfDepth != 0)
			{
				// Right.
				SupportFunctions.render(halfWidth, halfWidth, halfHeight, -halfHeight, depth: -halfDepth, depthChange: halfDepth * 2, colors: new Color[] { rearBorder.Value, border.Value, border.Value, rearBorder.Value }, blendMode: "line", drawingMode: Gl.GL_LINE_LOOP, lineWidth: 2f);
				// Left.
				SupportFunctions.render(-halfWidth, -halfWidth, halfHeight, -halfHeight, depth: -halfDepth, depthChange: halfDepth * 2, colors: new Color[] { rearBorder.Value, border.Value, border.Value, rearBorder.Value }, blendMode: "line", drawingMode: Gl.GL_LINE_LOOP, lineWidth: 2f);
				// Backward.
				SupportFunctions.render(-halfWidth, halfWidth, halfHeight, -halfHeight, depth: -halfDepth, color: rearBorder, blendMode: "line", drawingMode: Gl.GL_LINE_LOOP, lineWidth: 2f);
			}
		}

		public static void DrawGuideLines(double frameWidth = 100, double frameHeight = 100, List<Shapes.Guide> guides = null, System.Drawing.Color? color = null)
		{
			if (guides != null)
			{
				// Set default color: blue.
				if (color == null)
					color = Color.FromArgb(255, 0, 0, 255);
				// Perform the drawing.
				Gl.glPushMatrix();
				{
					Gl.glLineWidth(1.5f);
					SupportFunctions.setBlendMode("line");
					Gl.glColor4d(color.Value.R / 255.0, color.Value.G / 255.0, color.Value.B / 255.0, .5);
					Gl.glBegin(Gl.GL_LINES);
					{
						guides.ForEach(delegate(Shapes.Guide g)
						{
							if (g.type == Shapes.Guide.GuideType.Horizontal)
							{
								Gl.glVertex2d(0, g.position);
								Gl.glVertex2d(frameWidth, g.position);
							}
							else if (g.type == Shapes.Guide.GuideType.Vertical)
							{
								Gl.glVertex2d(g.position, 0);
								Gl.glVertex2d(g.position, frameHeight);
							}
						});
					}
					Gl.glEnd();
				}
				Gl.glPopMatrix();
			}
		}

		public static void DrawNoActionAvailableCursor(double CursorX, double CursorY, double depth = 0)
		{
			Gl.glPushMatrix();
			{
				Gl.glLineWidth(2);
				SupportFunctions.setBlendMode("line");
				Gl.glColor3d(1, 0, 0);
				Gl.glTranslated(CursorX, CursorY, depth);
				Gl.glBegin(Gl.GL_LINES);
				{
					Gl.glVertex2d(-10, -10);
					Gl.glVertex2d(10, 10);

					Gl.glVertex2d(10, -10);
					Gl.glVertex2d(-10, 10);
				}
				Gl.glEnd();
			}
			Gl.glPopMatrix();
		}

		public static void DrawPaintingCursor(double CursorX, double CursorY, double halfWidth = 100, double halfHeight = 100, double depth = 0, Color? color = null, int mode = Gl.GL_QUADS, float lineWidth = 0.1f)
		{
			if (color != null)
			{
				Gl.glPushMatrix();
				{
					Gl.glTranslated(CursorX, CursorY, depth);
					SupportFunctions.render(-halfWidth, halfWidth, halfHeight, -halfHeight, depth: depth, color: color.Value, drawingMode: mode, lineWidth: lineWidth);
				}
				Gl.glPopMatrix();
			}
		}

		public static void DrawBoxSelect(System.Drawing.Point boxSelectStart, System.Drawing.Point boxSelectEnd, double depth = 0)
		{
			Gl.glPushMatrix();
			{
				Gl.glLineWidth(2);
				Gl.glTranslated(0, 0, depth);
				Gl.glPushAttrib(Gl.GL_LINE_BIT);
				{
					Gl.glEnable(Gl.GL_LINE_STIPPLE);
					Gl.glLineStipple(3, 0xAAAA);
					SupportFunctions.setBlendMode("line");
					Gl.glColor3d(.4, .4, .4);
					Gl.glBegin(Gl.GL_LINE_LOOP);
					{
						Gl.glVertex2d(boxSelectStart.X, boxSelectStart.Y);
						Gl.glVertex2d(boxSelectEnd.X, boxSelectStart.Y);

						Gl.glVertex2d(boxSelectEnd.X, boxSelectEnd.Y);
						Gl.glVertex2d(boxSelectStart.X, boxSelectEnd.Y);
					}
					Gl.glEnd();
					Gl.glDisable(Gl.GL_LINE_STIPPLE);
				}
				Gl.glPopAttrib();
			}
			Gl.glPopMatrix();
		}

		public static void DrawText(string text, SupportClasses.ImageDescription[] characters, Size area, int rows, int columns, int advanceRows, int advanceColumns, Color color)
		{
			char[] cstring = text.ToCharArray();
			text = new string(cstring);
			int paddingLeft = 5;
			int curLetter = 1;
			double totalWidth = 0;
			bool firstEntry = true;
			foreach (char c in text)
			{
				int index = (int)Char.GetNumericValue(c);
				double rcawRight = -characters[index].SignificantWidth;
				double rcaw = rcawRight - characters[index].SignificantWidth * 2;
				totalWidth += characters[index].SignificantWidth;
				if (!firstEntry)
					totalWidth += paddingLeft;
				else
					firstEntry = !firstEntry;
			}
			Gl.glPushMatrix();
			{
				Gl.glTranslated(
					(
							  area.Width
						* (
							  (advanceColumns + 1)
							/ (double)columns
						   )
					) - totalWidth - paddingLeft, 0, 0);
				
				foreach (char c in text)
				{
					int index = (int)Char.GetNumericValue(c);
					//
					double bottom = -characters[index].SignificantHeight + area.Height * ((advanceRows + 1) / (double)rows);
					double top = bottom - characters[index].SignificantHeight * 2;
					double right = characters[index].SignificantWidth;
					double left = right - characters[index].SignificantWidth * 2;
					//
					SupportFunctions.render(left, right, bottom, top, color: color, textureId: characters[index].ContextId, textureScale: characters[index].TextureScale);
					//
					curLetter++;
					Gl.glTranslated(characters[index].SignificantWidth + paddingLeft, 0, 0);
				}
			}
			Gl.glPopMatrix();
		}
	}
}
