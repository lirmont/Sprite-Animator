using System;
using System.Collections.Generic;
using System.Drawing;
using Tao.OpenGl;
using OpenTK;

#pragma warning disable
namespace SpriteAnimator
{
	partial class SupportFunctions
	{
		/// <summary>
		/// Context-safe frame buffer extension call.
		/// </summary>
		public static void BindFrameBuffer(uint frameBufferId = 0)
		{
			try
			{
				Gl.glBindFramebufferEXT(Gl.GL_DRAW_FRAMEBUFFER_EXT, frameBufferId);
			}
			catch (Exception) { }
		}

		/// <summary>
		/// Context-safe frame buffer reseting extension call.
		/// </summary>
		public static void BindDefaultFrameBuffer()
		{
			BindFrameBuffer(frameBufferId: 0);
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
			// Push to projection matrix.
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glPushMatrix();
			{
				Gl.glLoadIdentity();
				Gl.glOrtho(left, right, bottom, top, near, far);
				// Push to modelview matrix.
				Gl.glMatrixMode(Gl.GL_MODELVIEW);
				Gl.glPushMatrix();
				{
					Gl.glLoadIdentity();
				}
			}
		}

		/// <summary>
		/// Pops the projection matrix made by the pushScreenCoordinateMatrix function. Synonymous with switching to the projection matrix and calling Gl.glPopMatrix().
		/// </summary>
		public static void pop_projection_matrix()
		{
			// Pop from modelview matrix.
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glPopMatrix();
			// Pop from projection matrix.
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glPopMatrix();
		}

		public static void compileShader(int shader, string source)
		{
			Gl.glShaderSource(shader, 1, new string[] { source }, new int[] { source.Length });
			Gl.glCompileShader(shader);
		}

		/// <summary>
		/// Checks whether or not a specified framebuffer object is usable.
		/// </summary>
		/// <param name="fbo">The integer returned by a call to the Gl.glGenFramebuffersEXT function.</param>
		/// <returns>Returns a boolean value indicating the state of a given framebuffer object.</returns>
		public static bool isFrameBufferComplete(int fbo)
		{
			switch (Gl.glCheckFramebufferStatusEXT(Gl.GL_FRAMEBUFFER_EXT))
			{
				case Gl.GL_FRAMEBUFFER_COMPLETE_EXT:
					return true;
				default:
					return false;
			}
		}

		/// <summary>
		/// Creates and initializes an OpenGL texture.
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="textureId"></param>
		/// <param name="imageByteOrder"></param>
		/// <param name="byteOrder"></param>
		/// <param name="byteType"></param>
		/// <param name="textureFilter"></param>
		/// <param name="textureRepeat"></param>
		/// <param name="imageData"></param>
		public static void createTexture(int width, int height, ref int textureId, int imageByteOrder = Gl.GL_RGBA, int byteOrder = Gl.GL_BGRA, int byteType = Gl.GL_UNSIGNED_BYTE, int textureFilter = Gl.GL_NEAREST, int textureRepeat = Gl.GL_CLAMP, IntPtr? imageData = null)
		{
			//
			if (imageData == null)
				imageData = IntPtr.Zero;
			//
			if (textureId <= 0)
			{
				int thisTexture;
				Gl.glGenTextures(1, out thisTexture);
				textureId = thisTexture;
			}
			//
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
			Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, imageByteOrder, width, height, 0, byteOrder, byteType, imageData.Value);
			Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, textureFilter);
			Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, textureFilter);
			Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, textureRepeat);
			Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, textureRepeat);
		}

		public static void createOrRecreateTexture(int width, int height, ref int textureId, int imageByteOrder = Gl.GL_RGBA, int byteOrder = Gl.GL_BGRA, int byteType = Gl.GL_UNSIGNED_BYTE, int textureFilter = Gl.GL_NEAREST, int textureRepeat = Gl.GL_CLAMP, IntPtr? imageData = null)
		{
			// Delete the existing texture if there's something there.
			if (textureId > 0)
				Gl.glDeleteTextures(1, ref textureId);
			// Push the image into the context.
			createTexture(width, height, ref textureId, imageByteOrder, byteOrder, byteType, textureFilter, textureRepeat, imageData);
		}

		public static void glGetError(string prefix = null)
		{
			int errorNumber = Gl.glGetError();
			if (prefix != null)
				Console.Write(prefix + " ");
			switch (errorNumber)
			{
				case Gl.GL_INVALID_ENUM:
					Console.WriteLine("OpenGL ERROR: GLenum argument out of range.");
					return;
				case Gl.GL_INVALID_VALUE:
					Console.WriteLine("OpenGL ERROR: Numeric argument out of range.");
					return;
				case Gl.GL_INVALID_OPERATION:
					Console.WriteLine("OpenGL ERROR: Operation illegal in current state.");
					return;
				case Gl.GL_STACK_OVERFLOW:
					Console.WriteLine("OpenGL ERROR: Function would cause a stack overflow.");
					return;
				case Gl.GL_STACK_UNDERFLOW:
					Console.WriteLine("OpenGL ERROR: Function would cause a stack underflow.");
					return;
				case Gl.GL_OUT_OF_MEMORY:
					Console.WriteLine("OpenGL ERROR: Not enough memory left to execute function.");
					return;
				case 0:
					Console.WriteLine("No error.");
					return;
			}
		}

		/// <summary>
		/// Render a four-point shape with optional color, texture, and depth.
		/// </summary>
		/// <param name="left">Left edge. Typically negative.</param>
		/// <param name="right">Right edge. Typically positive.</param>
		/// <param name="bottom">Bottom edge. Typically negative.</param>
		/// <param name="top">Top edge. Typically positive.</param>
		/// <param name="depth">Screen depth. Postive is into the screen; negative is back from the screen.</param>
		/// <param name="depthChange">Screen depth change.</param>
		/// <param name="points">List of Shapes.Point objects that represent the polygon.</param>
		/// <param name="s">Left edge of texture. Typically 0.</param>
		/// <param name="t">Top edge of texture. Typically 0.</param>
		/// <param name="S">Right edge of texture. Typically 1.</param>
		/// <param name="T">Bottom edge of texture. Typically 1.</param>
		/// <param name="textureId">OpenGL texture ID.</param>
		/// <param name="textureCoordinates">List of Shapes.Point objects, matched with the provided points.</param>
		/// <param name="color">Single System.Drawing.Color to draw the polygon as.</param>
		/// <param name="colors">List of System.Drawing.Color objects, matched with provided points.</param>
		/// <param name="blendMode">String representation of the blending mode. Default: "overwrite".</param>
		/// <param name="drawingMode">OpenGL drawing mode. Default: Gl.GL_QUADS.</param>
		/// <param name="lineWidth">Line width, for use with line-related drawing modes.</param>
		public static void render(double left = 0, double right = 0, double bottom = 0, double top = 0, double depth = 0, double depthChange = 0, List<Shapes.Point> points = null, double s = 0, double t = 0, double S = 1, double T = 1, int textureId = 0, List<Shapes.Point> textureCoordinates = null, Color? color = null, Color[] colors = null, string blendMode = "overwrite", int drawingMode = Gl.GL_QUADS, float lineWidth = 1, int overrideFilter = 0, Vector2d? textureScale = null)
		{
			// Assemble the 4 points that will be used.
			if (points == null)
			{
				points = new List<Shapes.Point> {
					new Shapes.Point(left, top, depth),
					new Shapes.Point(right, top, depth + depthChange),
					new Shapes.Point(right, bottom, depth + depthChange),
					new Shapes.Point(left, bottom, depth),
				};
			}
			// If there are things to draw, do so.
			if (points.Count > 0)
			{
				List<Shapes.Color> colorList = new List<Shapes.Color>();
				// Assemble the 4 colors that will be used.
				if (colors == null)
				{
					if (color == null)
						color = Color.White;
					// Initialize the color array to only include the default color.
					colors = new Color[4] { color.Value, color.Value, color.Value, color.Value };
					colorList = new List<Shapes.Color> {
						new Shapes.Color(color: color),
						new Shapes.Color(color: color),
						new Shapes.Color(color: color),
						new Shapes.Color(color: color)
					};
				}
				else
				{
					foreach (Color c in colors)
						colorList.Add(new Shapes.Color(color: c));
				}
				// Assemble the 4 texture coordinates that will be used.
				if (textureCoordinates == null)
					textureCoordinates = new List<Shapes.Point> {
						new Shapes.Point(s, t),
						new Shapes.Point(S, t),
						new Shapes.Point(S, T),
						new Shapes.Point(s, T)
					};
				// Apply texture scale if provided. NOTE: Meant to deal with padding from forced power of two formats.
				if (textureScale != null && textureCoordinates != null) {
					foreach (Shapes.Point point in textureCoordinates) {
						point.X *= textureScale.Value.X;
						point.Y *= textureScale.Value.Y;
					}
				}
				// If there's a texture, enable the texturing feature.
				if (textureId > 0)
					Gl.glEnable(Gl.GL_TEXTURE_2D);
				// If the mode is line-related, set the line width.
				if (drawingMode == Gl.GL_LINE_LOOP || drawingMode == Gl.GL_LINES)
					Gl.glLineWidth(lineWidth);
				// Bind the texture regardless (zero is equivalent to unbinding).
				Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
				if (overrideFilter != 0)
				{
					Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, overrideFilter);
					Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, overrideFilter);
				}
				// Set the blend mode.
				SupportFunctions.setBlendMode(blendMode);
				// Render the primitive.
				Gl.glBegin(drawingMode);
				{
					for (int i = 0; i < points.Count; i++)
					{
						textureCoordinates[i].RenderAsTextureCoordinate();
						colorList[i].Render();
						points[i].Render();
					}
				}
				Gl.glEnd();
				// Disable the texturing feature.
				Gl.glDisable(Gl.GL_TEXTURE_2D);
			}
		}

		/// <summary>
		/// Sets the color blending function for use with Gl.GL_BLEND.
		/// </summary>
		/// <param name="blend">Abstracted name of blending mode (ex: overwrite, darken, multiply, etc).</param>
		/// <param name="configuration">Which API features are available to this function.</param>
		public static void setBlendMode(string blend = "overwrite", OpenGLConfiguration configuration = null)
		{
			configuration = configuration ?? new OpenGLConfiguration();
			bool hasBlendEquationSeparate = configuration.SeparateBlendingEquationsAreSupported;
			bool hasBlendEquation = configuration.BlendingEquationsAreSupported;
			bool hasBlendFuncSeparate = configuration.SeparateBlendingFunctionsAreSupported;
			// TODO: Consider blending alpha separately for correct result in frame buffer.
			try
			{
				if (hasBlendEquationSeparate)
					Gl.glBlendEquationSeparate(Gl.GL_FUNC_ADD, Gl.GL_FUNC_ADD);
			}
			catch (Exception)
			{
				try
				{
					if (hasBlendEquation)
						Gl.glBlendEquation(Gl.GL_FUNC_ADD);
				}
				catch (Exception) { }
			}
			// ex: Red = (Red-Incoming * Red-Incoming Blend Factor +  Red-Existing * Red-Existing Blend Factor)
			switch (blend)
			{
				case "darken":
				case "darken-ignore-alpha":
					// Red-Incoming: 1-Existing.R; 
					// Red-Destination: 1-Incoming.R;
					try
					{
						if (hasBlendFuncSeparate)
							Gl.glBlendFuncSeparate(Gl.GL_ONE_MINUS_DST_COLOR, Gl.GL_ONE_MINUS_SRC_COLOR, Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_ALPHA);
						else
							Gl.glBlendFunc(Gl.GL_ONE_MINUS_DST_COLOR, Gl.GL_ONE_MINUS_SRC_COLOR);
					}
					catch (Exception) {
						Gl.glBlendFunc(Gl.GL_ONE_MINUS_DST_COLOR, Gl.GL_ONE_MINUS_SRC_COLOR);
					}
					break;
				case "difference":
				case "difference-ignore-alpha":
					// Red-Incoming: Existing.R; 
					// Red-Destination: Incoming.R;
					try {
						if (hasBlendEquationSeparate && hasBlendFuncSeparate)
						{
							Gl.glBlendEquationSeparate(Gl.GL_FUNC_REVERSE_SUBTRACT, Gl.GL_FUNC_ADD);
							Gl.glBlendFuncSeparate(Gl.GL_ONE, Gl.GL_ONE, Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_ALPHA);
						}
						else {
							if (hasBlendEquation)
								Gl.glBlendEquation(Gl.GL_FUNC_REVERSE_SUBTRACT);
							Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE);
						}
					}
					catch (Exception)
					{
						try
						{
							Gl.glBlendEquation(Gl.GL_FUNC_REVERSE_SUBTRACT);
						}
						catch (Exception) { }
						Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE);
					}
					break;
				case "multiply":
				case "multiply-ignore-alpha":
					// Target * Blend
					try
					{
						if (hasBlendFuncSeparate)
							Gl.glBlendFuncSeparate(Gl.GL_DST_COLOR, Gl.GL_ZERO, Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_ALPHA);
					}
					catch (Exception)
					{
						Gl.glBlendFunc(Gl.GL_DST_COLOR, Gl.GL_ZERO);
					}
					break;
				case "color-burn":
				case "color-burn-ignore-alpha":
					try
					{
						if (hasBlendFuncSeparate)
							Gl.glBlendFuncSeparate(Gl.GL_ZERO, Gl.GL_ONE_MINUS_SRC_COLOR, Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_ALPHA);
					}
					catch (Exception)
					{
						Gl.glBlendFunc(Gl.GL_ZERO, Gl.GL_ONE_MINUS_SRC_COLOR);
					}
					break;
				case "linear-burn":
				case "linear-burn-ignore-alpha":
					try
					{
						if (hasBlendFuncSeparate)
							Gl.glBlendFuncSeparate(Gl.GL_ZERO, Gl.GL_SRC_COLOR, Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_ALPHA);
					}
					catch (Exception)
					{
						Gl.glBlendFunc(Gl.GL_ZERO, Gl.GL_SRC_COLOR);
					}
					break;
				case "lighten":
				case "lighten-ignore-alpha":
					try
					{
						if (hasBlendEquationSeparate && hasBlendFuncSeparate)
						{
							Gl.glBlendEquationSeparate(Gl.GL_MAX, Gl.GL_FUNC_ADD);
							Gl.glBlendFuncSeparate(Gl.GL_SRC_COLOR, Gl.GL_DST_COLOR, Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_ALPHA);
						}
						else {
							if (hasBlendEquation)
								Gl.glBlendEquation(Gl.GL_MAX);
							Gl.glBlendFunc(Gl.GL_SRC_COLOR, Gl.GL_DST_COLOR);
						}
					}
					catch (Exception) {
						try
						{
							Gl.glBlendEquation(Gl.GL_MAX);
						}
						catch (Exception) { }
						Gl.glBlendFunc(Gl.GL_SRC_COLOR, Gl.GL_DST_COLOR);
					}
					break;
				case "color-dodge":
				case "color-dodge-ignore-alpha":
					try
					{
						if (hasBlendEquationSeparate && hasBlendFuncSeparate)
						{
							Gl.glBlendEquationSeparate(Gl.GL_FUNC_ADD, Gl.GL_FUNC_ADD);
							Gl.glBlendFuncSeparate(Gl.GL_ONE, Gl.GL_ONE, Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_ALPHA);
						}
						else
							Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE);
					}
					catch (Exception)
					{
						Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE);
					}
					break;
				case "linear-dodge":
				case "linear-dodge-ignore-alpha":
					try
					{
						if (hasBlendFuncSeparate)
							Gl.glBlendFuncSeparate(Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_COLOR, Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_ALPHA);
						else
							Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_COLOR);
					}
					catch (Exception)
					{
						Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_COLOR);
					}
					break;
				case "screen":
				case "screen-ignore-alpha":
					break;
				#region Porter-Duff
				case "Clear":
					Gl.glBlendFunc(Gl.GL_ZERO, Gl.GL_ZERO);
					break;
				case "Src":
					Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ZERO);
					break;
				case "SrcOver":
					Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_ALPHA);
					break;
				case "DstOver":
					Gl.glBlendFunc(Gl.GL_ONE_MINUS_DST_ALPHA, Gl.GL_ONE);
					break;
				case "SrcIn":
					Gl.glBlendFunc(Gl.GL_DST_ALPHA, Gl.GL_ZERO);
					break;
				case "DstIn":
					Gl.glBlendFunc(Gl.GL_ZERO, Gl.GL_SRC_ALPHA);
					break;
				case "SrcOut":
					Gl.glBlendFunc(Gl.GL_ONE_MINUS_DST_ALPHA, Gl.GL_ZERO);
					break;
				case "DstOut":
					Gl.glBlendFunc(Gl.GL_ZERO, Gl.GL_ONE_MINUS_SRC_ALPHA);
					break;
				case "Dst":
					Gl.glBlendFunc(Gl.GL_ZERO, Gl.GL_ONE);
					break;
				case "SrcAtop":
					Gl.glBlendFunc(Gl.GL_DST_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
					break;
				case "DstAtop":
					Gl.glBlendFunc(Gl.GL_ONE_MINUS_DST_ALPHA, Gl.GL_SRC_ALPHA);
					break;
				case "AlphaXor":
					Gl.glBlendFunc(Gl.GL_ONE_MINUS_DST_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
					break;
				#endregion
				default:
					{
						try
						{
							if (hasBlendFuncSeparate)
								Gl.glBlendFuncSeparate(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA, Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
							else
								Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
						}
						catch (Exception)
						{
							Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
						}
						//
						Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
					}
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
			int vertexCount = 32;
			if (outline == null)
				outline = outline ?? Color.FromArgb(255, 223, 228, 237);
			if (fill == null)
				fill = fill ?? Color.FromArgb(50, 65, 86, 107);
			Color clearArea = Color.Black;
			Gl.glLineWidth(2 + (float)r / 3.0f);
			Gl.glPushAttrib(Gl.GL_CURRENT_BIT);
			{
				SupportFunctions.setBlendMode("line");
				Shapes.Point circle = new Shapes.Point(0, 0);
				Gl.glColor4d(clearArea.R / 255.0, clearArea.G / 255.0, clearArea.B / 255.0, clearArea.A / 255.0);
				Gl.glBegin(Gl.GL_POLYGON);
				for (int i = 0; i < vertexCount; i++)
				{
					circle.x = r * Math.Cos(i) - h;
					circle.y = r * Math.Sin(i) + k;
					Gl.glVertex3d(circle.x + k, circle.y - h, 0f);

					circle.x = r * Math.Cos(i + 0.1) - h;
					circle.y = r * Math.Sin(i + 0.1) + k;
					Gl.glVertex3d(circle.x + k, circle.y - h, 0f);
				}
				Gl.glEnd();
				circle = new Shapes.Point(0, 0);
				Gl.glColor4d(fill.Value.R / 255.0, fill.Value.G / 255.0, fill.Value.B / 255.0, fill.Value.A / 255.0);
				Gl.glBegin(Gl.GL_POLYGON);
				for (int i = 0; i < vertexCount; i++)
				{
					circle.x = r * Math.Cos(i) - h;
					circle.y = r * Math.Sin(i) + k;
					Gl.glVertex3d(circle.x + k, circle.y - h, 0f);

					circle.x = r * Math.Cos(i + 0.1) - h;
					circle.y = r * Math.Sin(i + 0.1) + k;
					Gl.glVertex3d(circle.x + k, circle.y - h, 0f);
				}
				Gl.glEnd();
				circle = new Shapes.Point(0, 0);
				Gl.glColor4d(outline.Value.R / 255.0, outline.Value.G / 255.0, outline.Value.B / 255.0, outline.Value.A / 255.0);
				Gl.glBegin(Gl.GL_LINE_STRIP);
				for (int i = 0; i < vertexCount; i++)
				{
					circle.x = r * Math.Cos(i) - h;
					circle.y = r * Math.Sin(i) + k;
					Gl.glVertex3d(circle.x + k, circle.y - h, 0f);

					circle.x = r * Math.Cos(i + 0.1) - h;
					circle.y = r * Math.Sin(i + 0.1) + k;
					Gl.glVertex3d(circle.x + k, circle.y - h, 0f);
				}
				Gl.glEnd();
			}
		}
	}
}
