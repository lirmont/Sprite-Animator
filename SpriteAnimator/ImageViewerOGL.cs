using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Threading;
using Tao.OpenGl;
using OpenTK.Graphics.OpenGL;
using System.Security.Permissions;

#pragma warning disable 618, 612
namespace SpriteAnimator
{
	public partial class ImageViewerOGL : Form
	{
		private Main parent = null;

		/*
		 * Dragging Variables
		 */
		private bool isDragging = false;
		private Point storedFormLocation, storedMouseLocation;

		/*
		 * Deactivation/Reactivation Handler Variables
		 */
		public bool deactivated = false, lostFocus = false;

		private System.Threading.Timer scheduleRedraw;
		private int startMilliseconds = 0, currentMilliseconds = 0;
		private bool forceRedraw = false;

		public ImageViewerOGL(Main m)
		{
			this.parent = m;
			InitializeComponent();
			ImageViewerOGL thisViewer = this;
			loadFeatureTimers(m, thisViewer);
		}

		private bool ignoreAnyFutureRequests = false;
		private void ImageViewerOGL_FormClosing(object sender, FormClosingEventArgs e)
		{
			ImageViewerOGL_Closing();
			this.Dispose();
		}

		public void ImageViewerOGL_Closing()
		{
			ignoreAnyFutureRequests = true;
			unloadFeatureTimers();
		}

		public void unloadFeatureTimers()
		{
			if (scheduleRedraw != null)
			{
				scheduleRedraw.Dispose();
				scheduleRedraw = null;
			}
		}

		public void loadFeatureTimers(Main m, ImageViewerOGL thisViewer)
		{
			scheduleRedraw = new System.Threading.Timer(delegate(object data)
			{
				currentMilliseconds = Environment.TickCount & Int32.MaxValue;
				if (false && !m.CreditsWindowOpen)
				{
					// Tell the redraw thread to yield if drawing is going to be slow.
					if (m.oglConfiguration.MajorVersion <= 1)
					{
						if (hitStoppingPoint)
						{
							// Refresh when the main drawing thread refreshes..
							startMilliseconds += m.refreshCooldown;
						}
					}
					// Draw the image.
					if (m.loadedImageDescription.Filename != "" && !m.ignoreAnyFutureRequests)
						if (m.animationTargetMS.Value <= currentMilliseconds - startMilliseconds || forceRedraw)
							simpleOpenGlControlDraw(thisViewer);
				}
			}, "Redrawing Preview Control", m.targetMilliseconds, m.targetMilliseconds);
			startMilliseconds = currentMilliseconds - (int)m.animationTargetMS.Value;
		}

		private void subRenderControl_Paint(object sender, PaintEventArgs e)
		{
			simpleOpenGlControl.MakeCurrent();
			Main m = this.parent;
			#region Prepare secondary viewport (also, section necessary for windows dialog)
			Gl.glViewport(0, 0, simpleOpenGlControl.Width, simpleOpenGlControl.Height);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Glu.gluPerspective(45.0f, ((float)(simpleOpenGlControl.Width) / (float)(simpleOpenGlControl.Height)), 0.1f, 2.0f);
			Gl.glClearColor(m.BackgroundColor.R / 255f, m.BackgroundColor.G / 255f, m.BackgroundColor.B / 255f, m.BackgroundColor.A / 255f);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			#endregion
			subRenderControl_Draw();
		}

		public void simpleOpenGlControlDraw(ImageViewerOGL m)
		{
			try
			{
				if (!m.IsDisposed && !m.Disposing)
					m.Invoke((MethodInvoker)delegate
					{
						if (!m.ignoreAnyFutureRequests && !m.simpleOpenGlControl.IsDisposed && !m.simpleOpenGlControl.Disposing)
							m.simpleOpenGlControl.Invalidate();
					});
			}
			catch (Exception) { }
		}

		private List<Shapes.Point> getTextureCoordinatesForBackgroundImage(int frameIndex)
		{
			bool useFrozenBackground = useFrozenBackgroundToolStripMenuItem.Checked;
			double frameTextureCoverageWidth = (double)this.parent.RenderControl.Width / (double)this.parent.columns / (double)this.parent.backgroundImageDescription.Width;
			double frameTextureCoverageHeight = (double)this.parent.RenderControl.Height / (double)this.parent.rows / (double)this.parent.backgroundImageDescription.Height;
			double rowTarget = (useFrozenBackground) ? 0 : frameIndex / this.parent.columns;
			double columnTarget = (useFrozenBackground) ? 0 : frameIndex - (rowTarget * this.parent.columns);
			double s = frameTextureCoverageWidth * columnTarget, S = frameTextureCoverageWidth * (columnTarget + 1);
			double t = frameTextureCoverageHeight * rowTarget, T = frameTextureCoverageHeight * (rowTarget + 1);
			return new List<Shapes.Point> {
				new Shapes.Point(s, t),
				new Shapes.Point(S, t),
				new Shapes.Point(S, T),
				new Shapes.Point(s, T)
			};
		}

		public bool hitStoppingPoint = false;
		private void subRenderControl_Draw()
		{
			Main m = this.parent;
			// Prepare default placeholders to support drawing and ghosting.
			int thisFrameIndex = -1, previousFrameIndex = -1, nextFrameIndex = -1;
			//
			Gl.glPushAttrib(Gl.GL_CURRENT_BIT);
			{
				Gl.glPushMatrix();
				{
					if (m.loadedImageDescription.Filename != "" && m.enumerator != null && m.previousEnumerator != null && m.nextEnumerator != null)
					{
						SupportFunctions.pushScreenCoordinateMatrix(0, simpleOpenGlControl.Width, simpleOpenGlControl.Height, 0);
						{
							if (scheduleRedraw != null && m.animationYesOrNo.Checked)
							{
								#region Advance animation token if needed.
								bool result = m.enumerator.MoveNext();
								m.nextEnumerator.MoveNext();
								m.previousEnumerator.MoveNext();
								if (!result)
								{
									m.previousEnumerator.Reset();
									m.previousEnumerator.MoveNext();
									m.enumerator.Reset();
									m.enumerator.MoveNext();
									m.nextEnumerator.Reset();
									m.nextEnumerator.MoveNext();
									hitStoppingPoint = true;
								}
								m.subCurrentAnimationFrame = (int)m.enumerator.Current;
								// Support audio.
								if (!m.ignoreAudio.Checked && m.compositeFrameSoundCues.Count > m.subCurrentAnimationFrame - 1)
									foreach (Sound a in m.compositeFrameSoundCues[m.subCurrentAnimationFrame - 1])
										a.Play();
								#endregion
								#region Main frame Advancement if necessary.
								int curAnimRow = m.subCurrentAnimationFrame / m.columns;
								int curAnimCol = m.subCurrentAnimationFrame % m.columns - 1;
								if (m.subCurrentAnimationFrame % m.columns == 0)
								{
									curAnimCol = m.columns - 1;
									curAnimRow -= 1;
								}
								m.advanceRows = curAnimRow;
								m.advanceColumns = curAnimCol;
								#endregion
								// Support ghosting in sequence.
								previousFrameIndex = (int)m.previousEnumerator.Current - 1;
								thisFrameIndex = (int)m.enumerator.Current - 1;
								nextFrameIndex = (int)m.nextEnumerator.Current - 1;
							}
							else
							{
								// Rewrite ghosted frames to include positionally adjacent frames (rather than sequentially adjacent frames) if the sequence is no longer being animated.
								thisFrameIndex = m.advanceRows * m.columns + m.advanceColumns;
								previousFrameIndex = (thisFrameIndex == 0) ? (int)m.numberMaxCells.Value - 1 : thisFrameIndex - 1;
								nextFrameIndex = (thisFrameIndex == (int)m.numberMaxCells.Value - 1) ? 0 : thisFrameIndex + 1;
							}
							// Draw background image.
							if (m.transparentBackgroundYesOrNo.Checked)
							{
								// Draw the quadrilateral that resembles the composite frame from the main drawing context.
								SupportFunctions.render(0, simpleOpenGlControl.Width, simpleOpenGlControl.Height, 0, textureCoordinates: getTextureCoordinatesForBackgroundImage(thisFrameIndex), textureId: m.backgroundImageDescription.ContextId, textureScale: m.backgroundImageDescription.TextureScale);
							}
							// Draw current composite frame on left-hand side of screen.
							if (m.compositeFramePointers.Count > 1 && m.compositeFramePointers.Count >= (m.advanceRows * m.columns + m.advanceColumns))
							{
								SupportFunctions.render(0, simpleOpenGlControl.Width, simpleOpenGlControl.Height, 0, textureId: m.compositeFramePointers[thisFrameIndex].ContextId, textureScale: m.compositeFramePointers[thisFrameIndex].TextureScale);
							}
							else if (m.compositeFramePointers.Count == 1)
							{
								double rcah = (m.advanceRows / (double)m.rows), rcahBottom = ((m.advanceRows + 1) / (double)m.rows);
								double rcaw = (m.advanceColumns / (double)m.columns), rcawRight = ((m.advanceColumns + 1) / (double)m.columns);
								SupportFunctions.render(0, simpleOpenGlControl.Width, simpleOpenGlControl.Height, 0, s: rcaw, t: rcah, S: rcawRight, T: rcahBottom, textureId: m.compositeFramePointers[0].ContextId, textureScale: m.compositeFramePointers[0].TextureScale);
							}
							Color fadedColor = Color.FromArgb((int)(255 * .3), Color.White);
							// Draw previous composite frame over existing image on left-hand of screen.
							Gl.glEnable(Gl.GL_BLEND);
							Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
							// Draw previous frame
							if (m.ghostPreviousYesOrNo.Checked)
							{
								int previousAdvanceRows = m.advanceRows, previousAdvanceColumns = m.advanceColumns;
								previousAdvanceRows = previousFrameIndex / m.columns;
								previousAdvanceColumns = previousFrameIndex % m.columns;
								if (m.compositeFramePointers.Count > 1)
									SupportFunctions.render(0, simpleOpenGlControl.Width, simpleOpenGlControl.Height, 0, textureId: m.compositeFramePointers[previousFrameIndex].ContextId, color: fadedColor, textureScale: m.compositeFramePointers[thisFrameIndex].TextureScale);
								else if (m.compositeFramePointers.Count == 1)
								{
									double rcahPre = (previousAdvanceRows / (double)m.rows), rcahBottomPre = ((previousAdvanceRows + 1) / (double)m.rows);
									double rcawPre = (previousAdvanceColumns / (double)m.columns), rcawRightPre = ((previousAdvanceColumns + 1) / (double)m.columns);
									SupportFunctions.render(0, simpleOpenGlControl.Width, simpleOpenGlControl.Height, 0, s: rcawPre, t: rcahPre, S: rcawRightPre, T: rcahBottomPre, textureId: m.compositeFramePointers[0].ContextId, color: fadedColor, textureScale: m.compositeFramePointers[0].TextureScale);
								}
							}
							// Draw next composite frame over existing image on left-hand of screen.
							if (m.ghostNextYesOrNo.Checked)
							{
								int nextAdvanceRows = m.advanceRows, nextAdvanceColumns = m.advanceColumns;
								nextAdvanceRows = nextFrameIndex / m.columns;
								nextAdvanceColumns = nextFrameIndex % m.columns;
								if (m.compositeFramePointers.Count > 1)
									SupportFunctions.render(0, simpleOpenGlControl.Width, simpleOpenGlControl.Height, 0, textureId: m.compositeFramePointers[nextFrameIndex].ContextId, color: fadedColor, textureScale: m.compositeFramePointers[thisFrameIndex].TextureScale);
								else if (m.compositeFramePointers.Count == 1)
								{
									double rcahNext = (nextAdvanceRows / (double)m.rows), rcahBottomNext = ((nextAdvanceRows + 1) / (double)m.rows);
									double rcawNext = (nextAdvanceColumns / (double)m.columns), rcawRightNext = ((nextAdvanceColumns + 1) / (double)m.columns);
									SupportFunctions.render(0, simpleOpenGlControl.Width, simpleOpenGlControl.Height, 0, s: rcawNext, t: rcahNext, S: rcawRightNext, T: rcahBottomNext, textureId: m.compositeFramePointers[0].ContextId, color: fadedColor, textureScale: m.compositeFramePointers[0].TextureScale);
								}
							}
						}
						SupportFunctions.pop_projection_matrix();
					}
				}
				Gl.glPopMatrix();
			}
			Gl.glPopAttrib();
			forceRedraw = false;
			startMilliseconds = currentMilliseconds;
		}

		private void simpleOpenGlControl_Click(object sender, EventArgs e)
		{
			storedFormLocation = new Point(this.Location.X, this.Location.Y);
		}

		private void simpleOpenGlControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (isDragging && e.Button == MouseButtons.Left && this.parent.previewWindowPopOut)
			{
				this.Left += e.X - storedMouseLocation.X;
				this.Top += e.Y - storedMouseLocation.Y;
			}
		}

		private void simpleOpenGlControl_MouseDown(object sender, MouseEventArgs e)
		{
			isDragging = true;
			storedMouseLocation = new Point(e.X, e.Y);
		}

		private void simpleOpenGlControl_MouseUp(object sender, MouseEventArgs e)
		{
			isDragging = false;
		}

		private void ImageViewer_Deactivate(object sender, EventArgs e)
		{
			lostFocus = true;
			deactivated = true;
		}

		public void setLocation(int x, int y, ImageViewerOGL m)
		{
			try
			{
				if (m != null && m.Disposing != true)
				{
					m.Invoke((MethodInvoker)delegate
					{
						m.Location = new Point(x, y);
					});
				}
			}
			catch (Exception) { }
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.parent.previewWindowPopOut = !this.parent.previewWindowPopOut;
			if (!this.parent.previewWindowPopOut)
			{
				this.FormBorderStyle = FormBorderStyle.None;
				resizeToolStripMenuItem.Checked = false;
				setWindowToDefaultSize();
			}
			this.parent.layoutOverlays();
		}

		private void simpleOpenGlControl_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
				optionsContextMenuStrip.Show(Cursor.Position);
		}

		private void setToFrameSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormBorderStyle previousStyle = this.FormBorderStyle;
			if (this.FormBorderStyle == FormBorderStyle.SizableToolWindow)
				this.FormBorderStyle = FormBorderStyle.None;
			this.Size = this.parent.BackBufferSize;
			this.FormBorderStyle = previousStyle;
		}

		private void setToDefaultSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			setWindowToDefaultSize();
		}

		public void setWindowToDefaultSize()
		{
			FormBorderStyle previousStyle = this.FormBorderStyle;
			if (this.FormBorderStyle == FormBorderStyle.SizableToolWindow)
				this.FormBorderStyle = FormBorderStyle.None;
			this.Size = new Size(200, 196);
			this.FormBorderStyle = previousStyle;
		}

		private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.FormBorderStyle = (resizeToolStripMenuItem.Checked) ? FormBorderStyle.SizableToolWindow : FormBorderStyle.None;
		}

		private void ImageViewerOGL_Activated(object sender, EventArgs e)
		{
			deactivated = false;
		}

		private void setToScaledSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormBorderStyle previousStyle = this.FormBorderStyle;
			if (this.FormBorderStyle == FormBorderStyle.SizableToolWindow)
				this.FormBorderStyle = FormBorderStyle.None;
			this.Size = new Size((int)((double)this.parent.RenderControl.Width / (double)this.parent.getColumns()), (int)((double)this.parent.RenderControl.Height / (double)this.parent.getRows()));
			this.FormBorderStyle = previousStyle;
		}

		private void ImageViewerOGL_SizeChanged(object sender, EventArgs e)
		{
			if (this.Width < 40 || this.Height < 40)
				cGrip = 4;
			else
				cGrip = 16;
		}

		// Grip size
		private int cGrip = 16;

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			switch (m.Msg)
			{
				case 0x84: //WM_NCHITTEST
					Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
					pos = this.PointToClient(pos);
					var result = (HitTest)m.Result.ToInt32();
					if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
					{
						m.Result = new IntPtr((int)HitTest.BottomRight);
						return;
					}
					else if (pos.X <= cGrip && pos.Y >= this.ClientSize.Height - cGrip)
					{
						m.Result = new IntPtr((int)HitTest.BottomLeft);
						return;
					}
					else if (pos.X <= cGrip && pos.Y <= cGrip)
					{
						m.Result = new IntPtr((int)HitTest.TopLeft);
						return;
					}
					else if (pos.X >= this.ClientSize.Width - cGrip && pos.Y <= cGrip)
					{
						m.Result = new IntPtr((int)HitTest.TopRight);
						return;
					}
					else if (pos.X >= this.ClientSize.Width - cGrip && pos.Y > cGrip && pos.Y < this.ClientSize.Height - cGrip)
					{
						m.Result = new IntPtr((int)HitTest.Right);
						return;
					}
					else if (pos.X <= this.ClientSize.Width - cGrip && pos.Y > cGrip && pos.Y < this.ClientSize.Height - cGrip)
					{
						m.Result = new IntPtr((int)HitTest.Left);
						return;
					}
					else if (pos.X > cGrip && pos.X < this.ClientSize.Width - cGrip && pos.Y <= cGrip)
					{
						m.Result = new IntPtr((int)HitTest.Top);
						return;
					}
					else if (pos.X > cGrip && pos.X < this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
					{
						m.Result = new IntPtr((int)HitTest.Bottom);
						return;
					}
					break;
			}
		}
		enum HitTest
		{
			Caption = 2,
			Transparent = -1,
			Nowhere = 0,
			Client = 1,
			Left = 10,
			Right = 11,
			Top = 12,
			TopLeft = 13,
			TopRight = 14,
			Bottom = 15,
			BottomLeft = 16,
			BottomRight = 17,
			Border = 18
		}
	}
}