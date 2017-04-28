using System.Collections.Generic;
using System.Drawing;
using Tao.OpenGl;
using Tao.Platform.Windows;
using System.Windows.Forms;

#pragma warning disable
namespace SpriteAnimator.SupportClasses
{
	public class LegacyOpenGLRenderer : Renderer
	{
		SimpleOpenGlControl control;
		private bool doNotInitialize;
		bool useFBO = true;
		//
		Size frameBufferTextureSize = new Size(1, 1);
		int frameBufferObject = -1;
		int renderBufferObject = 0;
		int frameBufferColorTexture = 0;
		int depthImageFormat = Gl.GL_DEPTH_COMPONENT, depthFormat = Gl.GL_DEPTH_COMPONENT;

		public bool DoNotInitialize
		{
			get { return doNotInitialize; }
			set { doNotInitialize = value; }
		}

		public bool Initialized {
			get
			{
				return control != null;
			}
		}

		private double HalfWidth
		{
			get { return frameBufferTextureSize.Width / 2.0; }
		}

		private double HalfHeight
		{
			get { return frameBufferTextureSize.Height / 2.0; }
		}

		public LegacyOpenGLRenderer()
			: base("Legacy OpenGL 3.0", "WGL", "Uninitialized", requiresReloadOnSamplingChange: true)
		{
		}

		public void InitializeRendererOnControl(SimpleOpenGlControl control)
		{
			this.control = control;
			// TODO: Figure out why this is failing.
			if (Initialized && control.ParentForm != null && control.ParentForm.IsHandleCreated)
			{
				try
				{
					control.ParentForm.Invoke((MethodInvoker)delegate()
					{
						control.MakeCurrent();
						Version = Gl.glGetString(Gl.GL_VERSION);
						TechnologyName = Gl.glGetString(Gl.GL_RENDERER);
						// Check version of OpenGL by number. Concern is to plan around opengl32.dll (which is Windows' fallback implementation of OpenGL 1.1).
						int major, minor;
						OpenTKSupportFunctions.getCompatibleMajorMinorVersion(out major, out minor);
						if (major < 3)
							useFBO = false;
						// Create the frame buffer object. NOTE: Will be pass-through if useFBO is false.
						createFBO();
					});
				}
				catch { }
			}
			DoNotInitialize = true;
		}

		private void createFBO()
		{
			if (Initialized && useFBO)
			{
				//
				Gl.ReloadFunctions();
				try
				{
					// Create frame buffer.
					Gl.glGenFramebuffersEXT(1, out frameBufferObject);
					// Bind frame buffer object for setup.
					Gl.glBindFramebufferEXT(Gl.GL_DRAW_FRAMEBUFFER_EXT, frameBufferObject);
					// Generate render buffer to store depth and stencil features.
					Gl.glGenRenderbuffersEXT(1, out renderBufferObject);
					// Create the color texture and depth + stencil buffer for the frame buffer object.
					createOrResizeFBOTextures(frameBufferTextureSize.Width, frameBufferTextureSize.Height);
					// Re-bind (because createOrResizeFBOTextures unbinds).
					Gl.glBindFramebufferEXT(Gl.GL_DRAW_FRAMEBUFFER_EXT, frameBufferObject);
					// Attach the color texture to the frame buffer object.
					Gl.glFramebufferTexture2DEXT(Gl.GL_DRAW_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_TEXTURE_2D, frameBufferColorTexture, 0);
					// Attach the depth component to the shared render buffer.
					Gl.glFramebufferRenderbufferEXT(Gl.GL_DRAW_FRAMEBUFFER_EXT, Gl.GL_DEPTH_ATTACHMENT_EXT, Gl.GL_RENDERBUFFER_EXT, renderBufferObject);
					// Attach the stencil component to the shared render buffer.
					Gl.glFramebufferRenderbufferEXT(Gl.GL_DRAW_FRAMEBUFFER_EXT, Gl.GL_STENCIL_ATTACHMENT_EXT, Gl.GL_RENDERBUFFER_EXT, renderBufferObject);
					// Check to make sure that the FBO is drawable.
					useFBO = SupportFunctions.isFrameBufferComplete(frameBufferObject);
					// Disable rendering into the FBO.
					Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, 0);
				}
				catch {
					useFBO = false;
				}
			}
		}

		private void createOrResizeFBOTextures(int width, int height)
		{
			frameBufferTextureSize = new Size(width, height);
			if (Initialized && useFBO)
			{
				control.ParentForm.Invoke((MethodInvoker)delegate()
				{
					control.MakeCurrent();
					// Recreate the textures with appropriate size.
					SupportFunctions.createOrRecreateTexture(frameBufferTextureSize.Width, frameBufferTextureSize.Height, ref frameBufferColorTexture, textureFilter: Gl.GL_LINEAR);
					// Bind frame buffer object for setup.
					Gl.glBindFramebufferEXT(Gl.GL_DRAW_FRAMEBUFFER_EXT, frameBufferObject);
					// Bind the render buffer to resize appropriately.
					Gl.glBindRenderbufferEXT(Gl.GL_RENDERBUFFER_EXT, renderBufferObject);
					// Resize the render buffer.
					Gl.glRenderbufferStorageEXT(Gl.GL_RENDERBUFFER_EXT, Gl.GL_DEPTH_STENCIL_EXT, frameBufferTextureSize.Width, frameBufferTextureSize.Height);
					// Unbind the render buffer.
					Gl.glBindRenderbufferEXT(Gl.GL_RENDERBUFFER_EXT, 0);
					// Attach the color texture to the frame buffer object.
					Gl.glFramebufferTexture2DEXT(Gl.GL_DRAW_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_TEXTURE_2D, frameBufferColorTexture, 0);
					// Attach the depth+stencil buffer to the frame buffer object.
					Gl.glFramebufferRenderbufferEXT(Gl.GL_DRAW_FRAMEBUFFER_EXT, Gl.GL_DEPTH_ATTACHMENT_EXT, Gl.GL_RENDERBUFFER_EXT, renderBufferObject);
					Gl.glFramebufferRenderbufferEXT(Gl.GL_DRAW_FRAMEBUFFER_EXT, Gl.GL_STENCIL_ATTACHMENT_EXT, Gl.GL_RENDERBUFFER_EXT, renderBufferObject);
					// Disable rendering into the FBO.
					Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, 0);
				});
			}
		}

		private void resizeFBOTextures(Size size)
		{
			createOrResizeFBOTextures(size.Width, size.Height);
		}

		private Bitmap drawToFBOAndReturnScreenshot(int thisCompositeFrameId, Format format, Dictionary<int, ImageDescription> namedAttachments, ImageDescription image)
		{
			Bitmap bmp = null;
			//
			if (Initialized && useFBO)
			{
				control.ParentForm.Invoke((MethodInvoker)delegate()
				{
					control.MakeCurrent();
					//
					Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, frameBufferObject);
					// Prepare main viewport (also, section necessary for windows dialog).
					Gl.glViewport(0, 0, frameBufferTextureSize.Width, frameBufferTextureSize.Height);
					// Clear background to transparency.
					Gl.glClearColor(0, 0, 0, 1);
					// Clear depth to white.
					Gl.glClearDepth(1.0);
					//
					Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
					// Set features.
					Gl.glEnable(Gl.GL_LINE_SMOOTH);
					Gl.glEnable(Gl.GL_DEPTH_TEST);
					Gl.glEnable(Gl.GL_STENCIL_TEST);
					Gl.glDepthFunc(Gl.GL_LEQUAL);
					// Set orthogonal projection.
					SupportFunctions.pushScreenCoordinateMatrix(0, frameBufferTextureSize.Width, frameBufferTextureSize.Height, 0, near: -frameBufferTextureSize.Width * 2, far: frameBufferTextureSize.Width * 2);
					{
						drawImage(thisCompositeFrameId, format, namedAttachments, image);
					}
					SupportFunctions.pop_projection_matrix();
					Gl.glDisable(Gl.GL_STENCIL_TEST);
					//
					Gl.glFlush();
					// Take screenshot.
					bmp = GrabScreenshot();
					// Disable rendering into the FBO.
					Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, 0);
				});
			}
			if (bmp == null)
				bmp = new Bitmap(frameBufferTextureSize.Width, frameBufferTextureSize.Height);
			return bmp;
		}

		// Returns a System.Drawing.Bitmap with the contents of the current framebuffer
		private Bitmap GrabScreenshot(string value = "fbo")
		{
			Bitmap bmp = new Bitmap(frameBufferTextureSize.Width, frameBufferTextureSize.Height);
			System.Drawing.Imaging.BitmapData data;
			switch(value)
			{
				case "color":
					data = bmp.LockBits(new Rectangle(Point.Empty, frameBufferTextureSize), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
					Gl.glBindTexture(Gl.GL_TEXTURE_2D, frameBufferColorTexture);
					Gl.glGetTexImage(Gl.GL_TEXTURE_2D, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, data.Scan0);
					bmp.UnlockBits(data);
					break;
				case "fbo":
				default:
					data = bmp.LockBits(new Rectangle(Point.Empty, frameBufferTextureSize), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
					Gl.glReadPixels(0, 0, frameBufferTextureSize.Width, frameBufferTextureSize.Height, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, data.Scan0);
					bmp.UnlockBits(data);
					break;
			}
			return bmp;
		}

		public override System.Drawing.Bitmap renderCompositeFrameToBitmap(Rectangle backBufferRectangle, int thisCompositeFrameId, Format format, Dictionary<int, ImageDescription> namedAttachments, ImageDescription image)
		{
			if (backBufferRectangle.Width != frameBufferTextureSize.Width || backBufferRectangle.Height != frameBufferTextureSize.Height)
				resizeFBOTextures(backBufferRectangle.Size);
			//
			return drawToFBOAndReturnScreenshot(thisCompositeFrameId, format, namedAttachments, image);
		}

		private void drawImage(int thisCompositeFrameId, Format format, Dictionary<int, ImageDescription> namedAttachments, ImageDescription image)
		{
			List<Shapes.FrameCall> calls = format.CompositeFrames[thisCompositeFrameId];
			List<RenderableFrameCall> loadedFrames = new List<RenderableFrameCall>();
			foreach (Shapes.FrameCall call in calls)
				loadedFrames.Add(new RenderableFrameCall(call, format));
			// Draw all frame calls.
			Gl.glPushMatrix();
			{
				// Draw optionally transparent sprite geometry (re: draw frame calls).
				Gl.glEnable(Gl.GL_BLEND);
				{
					Gl.glScaled(1, -1, 1);
					Gl.glTranslated(0, -frameBufferTextureSize.Height, 0);
					for (int i = 0; i < loadedFrames.Count; i++)
					{
						Gl.glTranslated(0, 0, 0.001);
						// Push the image to the context if it hasn't been pushed yet.
						if (image.PushToContext == false)
							image.PushToContext = true;
						loadedFrames[i].glRender(image.ContextId, namedAttachments, format);
					}
				}
				Gl.glDisable(Gl.GL_BLEND);
			}
			Gl.glPopMatrix();
		}
	}
}
