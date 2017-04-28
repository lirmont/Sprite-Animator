using System;
using System.Collections.Generic;
using System.Drawing;
using Tao.OpenGl;

#pragma warning disable
namespace SpriteAnimator.SupportClasses
{
	public class RenderableFrameCall
	{
		public Shapes.Rect bound = new Shapes.Rect(0, 0, 0, 0);
		private double offsetZ = 0;
		public bool hoverSelected = false, selected = false, flipX = false;
		public Color selectedColor = Color.Yellow, color = Color.White;
		public string colorName = null;
		public double s = 0, t = 0, S = 0, T = 0;
		public string tween = "0", blendMode = "overwrite";
		public string name = null;
		public int namedAttachmentPointId = 0;
		public int frameInTween = 0, id = 0, offsetFromTweenX = 0, offsetFromTweenY = 0, offsetFromTweenZ = 0;
		public double scaleX = 1, scaleY = 1, rotationZ = 0;
		//
		public string motionTrailType = "instance";
		public int motionTrailFramesInTween = 0;

		public bool NoColorAtFrameCall
		{
			get { return (colorName != null) ? false : true; }
		}

		public double OffsetX
		{
			get { return bound.X; }
			set { bound.X = value; }
		}

		public double OffsetY
		{
			get { return bound.Y; }
			set { bound.Y = value; }
		}

		public double OffsetZ
		{
			get { return offsetZ; }
			set { offsetZ = value; }
		}

		//
		private double HalfWidth
		{
			get { return bound.Width / 2.0; }
		}

		private double HalfHeight
		{
			get { return bound.Height / 2.0; }
		}

		//
		public double Width
		{
			get { return bound.Width; }
			set { bound.Width = value; }
		}

		public double Height
		{
			get { return bound.Height; }
			set { bound.Height = value; }
		}

		//
		public double Left
		{
			get { return offsetFromTweenX + OffsetX; }
		}

		public double Right
		{
			get { return Left + Width; }
		}

		public double Top
		{
			get { return offsetFromTweenY + OffsetY; }
		}

		public double Bottom
		{
			get { return Top + Height; }
		}

		public double Depth
		{
			get { return offsetFromTweenZ + OffsetZ; }
		}

		public Shapes.Point Center
		{
			get { return new Shapes.Point(Left + HalfWidth, Top + HalfHeight, Depth); }
		}

		public Shapes.Point TotalOffset
		{
			get { return new Shapes.Point(Left, Top, Depth); }
		}

		public Shapes.Point OffsetFromTween
		{
			get { return new Shapes.Point(offsetFromTweenX, offsetFromTweenY, offsetFromTweenZ); }
		}

		public bool HasDefaultScale
		{
			get { return (scaleX == 1 && scaleY == 1); }
		}

		//
		private int? namedAttachmentPointImageId = null;

		public RenderableFrameCall(Shapes.FrameCall call, SupportClasses.Format format)
		{
			this.id = int.Parse(call.id);
			this.tween = call.TweenId;
			this.frameInTween = call.FrameInTween;
			// Do color look-up.
			this.color = format.GetColorFromFrameCall(call);
			this.colorName = call.ColorName;
			//
			int namedAttachmentPointId = 0;
			int.TryParse(call.NamedAttachmentPointId, out namedAttachmentPointId);
			this.namedAttachmentPointId = namedAttachmentPointId;
			//
			this.rotationZ = call.RotationZ;
			this.scaleX = call.ScaleX;
			this.scaleY = call.ScaleY;
			//
			this.motionTrailType = call.MotionTrailType;
			this.motionTrailFramesInTween = call.MotionTrailFramesInTween;
			// Do width/height look-up.
			Shapes.Frame frame = null;
			if (format.AvailableFrameList != null)
				frame = format.AvailableFrameList.Find(item => item.id == this.id);
			if (frame != null)
			{
				SizeF imageSize = new SizeF(format.BaseWidth, format.BaseHeight);
				this.bound = new Shapes.Rect(call.OffsetX, call.OffsetY, frame.w, frame.h);
				this.s = frame.s / imageSize.Width;
				this.t = frame.t / imageSize.Height;
				this.S = (frame.s + frame.w) / imageSize.Width;
				this.T = (frame.t + frame.h) / imageSize.Height;
			}
			else
			{
				this.bound = new Shapes.Rect(call.OffsetX, call.OffsetY, 0, 0);
				this.s = 0;
				this.t = 0;
				this.S = 1;
				this.T = 1;
			}
			//
			this.offsetZ = call.OffsetZ;
			this.blendMode = call.BlendMode;
			//
			Shapes.Tween tween = null;
			if (call.TweenId != "0" && format.AvailableTweenList != null)
				tween = format.AvailableTweenList.Find(item => item.id == call.TweenId);
			if (tween != null)
			{
				Shapes.Point p = tween.XYZFromFrame(call.FrameInTween);
				this.offsetFromTweenX = (int)p.X;
				this.offsetFromTweenY = (int)p.Y;
				this.offsetFromTweenZ = (int)p.Z;
			}
			else
			{
				this.offsetFromTweenX = 0;
				this.offsetFromTweenY = 0;
				this.offsetFromTweenZ = 0;
			}
			//
			this.flipX = call.FlipX;
			if (this.flipX)
			{
				double temporaryS = this.S;
				this.S = s;
				this.s = temporaryS;
			}
			//
			this.hoverSelected = false;
			this.selectedColor = Color.Yellow;
		}

		public RenderableFrameCall(Shapes.Rect bound, bool selected = false, double s = 0, double t = 0, double S = 0, double T = 0, string tween = "0", int frameInTween = 0, bool flipX = false, string blendMode = "overwrite", int id = 0, int offsetFromTweenX = 0, int offsetFromTweenY = 0, int offsetFromTweenZ = 0, double scaleX = 1, double scaleY = 1, Color? color = null, double rotationZ = 0, string name = null, int namedAttachmentPointId = 0, int offsetZ = 0, string colorName = null)
		{
			// ID
			this.id = id;
			// Tween
			this.tween = tween;
			this.frameInTween = frameInTween;
			// Color
			if (color != null)
				this.color = color ?? Color.White;
			this.colorName = colorName;
			// Names
			this.name = name;
			this.namedAttachmentPointId = namedAttachmentPointId;
			// Rotation
			this.rotationZ = rotationZ;
			// Scale
			this.scaleX = scaleX;
			this.scaleY = scaleY;
			// Offsets
			this.bound = bound;
			this.offsetZ = offsetZ;
			this.offsetFromTweenX = offsetFromTweenX;
			this.offsetFromTweenY = offsetFromTweenY;
			this.offsetFromTweenZ = offsetFromTweenZ;
			// Blending
			this.blendMode = blendMode;
			// Texture coordinates
			this.s = s;
			this.t = t;
			this.S = S;
			this.T = T;
			// Orientation of texture coordinates
			this.flipX = flipX;
			// Selection
			this.hoverSelected = selected;
			this.selectedColor = Color.Yellow;
		}

		public RenderableFrameCall(RenderableFrameCall q)
		{
			// ID
			this.id = q.id;
			// Tween
			this.tween = q.tween;
			this.frameInTween = q.frameInTween;
			// Color
			this.color = q.color;
			this.colorName = q.colorName;
			// Names
			this.name = q.name;
			this.namedAttachmentPointId = q.namedAttachmentPointId;
			// Rotation
			this.rotationZ = q.rotationZ;
			// Scale
			this.scaleX = q.scaleX;
			this.scaleY = q.scaleY;
			// Motion trail
			this.motionTrailType = q.motionTrailType;
			this.motionTrailFramesInTween = q.motionTrailFramesInTween;
			// Offsets
			this.bound = new Shapes.Rect(q.bound.x, q.bound.y, q.bound.width, q.bound.height);
			this.offsetZ = q.offsetZ;
			this.offsetFromTweenX = q.offsetFromTweenX;
			this.offsetFromTweenY = q.offsetFromTweenY;
			this.offsetFromTweenZ = q.offsetFromTweenZ;
			// Blending
			this.blendMode = q.blendMode;
			// Textures coordinates
			this.s = q.s;
			this.t = q.t;
			this.S = q.S;
			this.T = q.T;
			// Orientation of texture coordinates
			this.flipX = q.flipX;
			// Selection
			this.selected = q.selected;
			this.hoverSelected = q.hoverSelected;
			this.selectedColor = q.selectedColor;
		}

		public void glRender(int thisTexture, Dictionary<int, ImageDescription> namedAttachments, Format format, bool renderPath = false, bool renderPoints = false, bool renderDistance = false, bool? useNoSampling = null, bool treatSelectionAsPaintable = false, float selectionLineWidth = 2f, OpenTK.Vector2d? textureScale = null)
		{
			if (useNoSampling == null)
				useNoSampling = format.UseNoSampling;
			//
			Shapes.Tween thisTween = format.AvailableTweenList.Find(item => item.id == this.tween);
			//
			Gl.glPushAttrib(Gl.GL_CURRENT_BIT);
			{
				// Draw the selection box on the same level as the geometry.
				if (selected)
				{
					Gl.glPushMatrix();
					{
						Gl.glTranslated(Left + HalfWidth, Top + HalfHeight, Depth);
						Gl.glRotated(rotationZ, 0, 0, 1);
						Gl.glScaled(scaleX, scaleY, 1);
						//
						if (!treatSelectionAsPaintable)
							SupportFunctions.render(-HalfWidth, HalfWidth, HalfHeight, -HalfHeight, depth: Depth, color: selectedColor, lineWidth: selectionLineWidth, blendMode: "line", drawingMode: Gl.GL_LINE_LOOP);
						else
							SupportFunctions.render(-HalfWidth, HalfWidth, HalfHeight, -HalfHeight, depth: Depth, color: Color.FromArgb((int)(0.25 * 255), Color.White), lineWidth: 1f, blendMode: "line", drawingMode: Gl.GL_LINE_LOOP);
					}
					Gl.glPopMatrix();
				}
				if (thisTween != null && selected && !treatSelectionAsPaintable)
				{
					#region Draw Tween Overlay
					if (renderPath)
					{
						SupportFunctions.setBlendMode("line");
						Gl.glLineWidth(2);
						Gl.glColor4d(0, 1, 0, 1);
						Gl.glBegin(Gl.GL_LINES);
						{
							thisTween.LineSegments.ForEach(delegate(Shapes.Line l)
							{
								Gl.glVertex3d(l.X1Property, l.Y1Property, l.Z1Property);
								Gl.glVertex3d(l.X2Property, l.Y2Property, l.Z2Property);
							});
						}
						Gl.glEnd();
					}
					#endregion
					#region Draw Distance from Tween Overlay
					if (renderDistance)
					{
						Shapes.Point start = thisTween.XYZFromFrame(frameInTween);
						Gl.glPushMatrix();
						{
							Gl.glPushAttrib(Gl.GL_LINE_BIT);
							{
								Gl.glEnable(Gl.GL_LINE_STIPPLE);
								Gl.glLineWidth(2);
								Gl.glLineStipple(3, 0xAAAA);
								SupportFunctions.setBlendMode("line");
								Gl.glColor4d(1, 0, 0, 1);
								Gl.glBegin(Gl.GL_LINES);
								{
									Gl.glVertex3d(start.X, start.Y, start.Z);
									Gl.glVertex3d(Left, Top, Depth);
								}
								Gl.glEnd();
								Gl.glDisable(Gl.GL_LINE_STIPPLE);
							}
							Gl.glPopAttrib();
						}
					}
					#endregion
					#region Draw Points in Tween
					if (renderPoints)
					{
						SupportFunctions.setBlendMode("line");
						Gl.glPointSize(5);
						Gl.glColor4d(0, 0, 1, 1);
						Gl.glBegin(Gl.GL_POINTS);
						{
							Gl.glVertex3d(thisTween.LineSegments[0].X1Property, thisTween.LineSegments[0].Y1Property, thisTween.LineSegments[0].Z1Property);
							thisTween.LineSegments.ForEach(delegate(Shapes.Line l)
							{
								Gl.glVertex3d(l.X2Property, l.Y2Property, l.Z2Property);
							});
						}
						Gl.glEnd();
					}
					#endregion
				}
				#region Draw Bitmap.
				Gl.glPushMatrix();
				{
					Gl.glTranslated(Left + HalfWidth, Top + HalfHeight, Depth);
					Gl.glRotated(rotationZ, 0, 0, 1);
					Gl.glScaled(scaleX, scaleY, 1);
					//
					int startingTFrame = frameInTween - motionTrailFramesInTween;
					double thisLength = (thisTween != null) ? thisTween.distanceFromFrame(frame: frameInTween) - thisTween.distanceFromFrame(frame: startingTFrame) : 0.9;
					for (double distanceAlongLine = 0; distanceAlongLine <= thisLength;)
					{
						double thisFrameInTween = startingTFrame + (motionTrailFramesInTween * distanceAlongLine / thisLength);
						// In a non-motion-trail scenario, 1.0 advances the loop to the end.
						double advance = 1.0;
						//
						int scaledAddWidth = (int)Math.Ceiling(Width * scaleX), scaledAddHeight = (int)Math.Ceiling(Height * scaleY);
						Shapes.Point offset = OffsetFromTween, offsetNew = new Shapes.Point(0, 0, 0);
						if (thisTween != null)
							offsetNew = thisTween.XYZFromFrame(thisFrameInTween);
						// Translation from motion trail. Typically zero or the offset from tween, if a tween is present. Otherwise, it may be an offset from a different frame in the tween (i.e. giving the effect of a trail).
						Point motionTranslation = new Point((int)(offset.X - offsetNew.X), (int)(offset.Y - offsetNew.Y));
						//
						Point scaledLayerOffset = new Point(
							SupportFunctions.Clamp<int>((int)Math.Floor((TotalOffset.X - motionTranslation.X) - (double)(scaledAddWidth - Width) / 2.0), 0, format.FrameWidth),
							SupportFunctions.Clamp<int>((int)Math.Floor((TotalOffset.Y - motionTranslation.Y) - (double)(scaledAddHeight - Height) / 2.0), 0, format.FrameHeight)
						);
						// Determine how large the frame call is (does not currently include named attachments).
						int distanceCoveredByThisFrame = (int)Math.Max(1, Math.Floor(Math.Min(0.5 * scaledAddWidth, 0.5 * scaledAddHeight)));
						int advancement = (thisLength > 1) ? distanceCoveredByThisFrame : 1;
						Gl.glPushMatrix();
						{
							// Handled by Left and Top already.
							//Gl.glTranslated(-motionTranslation.X, -motionTranslation.Y, 0);
							// Pick the appropriate color.
							Color thisColor = color;
							if ((selected || hoverSelected) && !treatSelectionAsPaintable)
								thisColor = selectedColor;
							else if (!(selected || hoverSelected) && treatSelectionAsPaintable)
								thisColor = Color.FromArgb((int)(255 * 0.25), thisColor);
							// Perform the actual drawing.
							SupportFunctions.render(-HalfWidth, HalfWidth, HalfHeight, -HalfHeight, color: thisColor, s: s, t: t, S: S, T: T, textureId: thisTexture, blendMode: blendMode, overrideFilter: (format.UseNoSampling && HasDefaultScale) ? Gl.GL_NEAREST : Gl.GL_LINEAR, textureScale: textureScale);
						}
						Gl.glPopMatrix();
						// Control the advancement of the loop.
						if (thisTween != null && motionTrailFramesInTween > 0 && motionTrailType == "instance-fill" && advancement > 0)
							advance = advancement;
						distanceAlongLine += advance;
					}
					// Draw Second Bitmap (case: named attachment point).
					if (this.namedAttachmentPointId != 0)
					{
						if (namedAttachments.ContainsKey(this.namedAttachmentPointId))
						{
							if (flipX)
								Gl.glScaled(-scaleX, scaleY, 1);
							// Get named attachment point.
							Shapes.NamedAttachmentPoint point = format.AvailableNamedAttachmentPointsList.Find(item => item.id == this.namedAttachmentPointId);
							if (point != null && !point.hidden)
							{
								SupportClasses.ImageDescription description = namedAttachments[this.namedAttachmentPointId];
								// Push the image to the context if it hasn't been pushed yet.
								if (description.PushToContext == false)
									description.PushToContext = true;
								// Draw attachment layer: +/-x is right, left; +/-y is up, down.
								SupportFunctions.render(
									left: -description.Width * (1.0 - point.x),
									right: description.Width * point.x,
									bottom: description.Height * (1.0 - point.y),
									top: -description.Height * point.y,
									color: (selected || hoverSelected) ? selectedColor : Color.White,
									textureId: description.ContextId,
									overrideFilter: (format.UseNoSampling && HasDefaultScale) ? Gl.GL_NEAREST : Gl.GL_LINEAR
								);
							}
						}
					}
					Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
				}
				Gl.glPopMatrix();
				#endregion
			}
			Gl.glPopAttrib();
		}

		public void glRenderHoverSelect()
		{
			// Draw the hover selection box way above the geometry to support proper selection (i.e. land inside selected hit-box supercedes new selections).
			if (hoverSelected)
			{
				Gl.glPushMatrix();
				{
					Gl.glTranslated(Left + HalfWidth, Top + HalfHeight, Depth);
					Gl.glRotated(rotationZ, 0, 0, 1);
					Gl.glScaled(scaleX, scaleY, 1);
					SupportFunctions.render(-HalfWidth, HalfWidth, HalfHeight, -HalfHeight, depth: Depth, color: selectedColor, lineWidth: 2f, blendMode: "line", drawingMode: Gl.GL_LINE_LOOP);
				}
				Gl.glPopMatrix();
			}
		}

		public void clearOverriddenColor(Format format)
		{
			if (!NoColorAtFrameCall)
			{
				// Reset override features.
				colorName = null;
				// Figure out if this thing has a tween with a color component.
				bool tweenHasColor = false;
				Shapes.Tween thisTween = null;
				if (tween != "0")
				{
					thisTween = format.AvailableTweenList.Find(item => item.id == tween);
					if (thisTween != null)
					{
						if (thisTween.HasColorComponent)
						{
							tweenHasColor = true;
							this.color = thisTween.colorFromFrame(frameInTween);
						}
					}
				}
				// If not, set it back to flat white.
				if (!tweenHasColor)
					this.color = Color.White;
			}
		}
	}
}
