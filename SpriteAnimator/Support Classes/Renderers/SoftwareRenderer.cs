using System;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;

namespace SpriteAnimator.SupportClasses
{
	public class SoftwareRenderer : Renderer
	{
		public SoftwareRenderer()
			: base("Software",
			string.Format("{0}", "Graphics Device Interface Plus"),
			string.Format("{0}", Assembly.GetAssembly(typeof(System.Drawing.Graphics)).GetName().Version),
			requiresReloadOnSamplingChange: false)
		{
		}

		public override System.Drawing.Bitmap renderCompositeFrameToBitmap(Rectangle backBufferRectangle, int thisCompositeFrameId, Format format, Dictionary<int, ImageDescription> namedAttachments, ImageDescription image)
		{
			//
			// TODO: Possibly sort by Z.
			List<Shapes.FrameCall> calls = format.CompositeFrames[thisCompositeFrameId];
			Size BackBufferSize = backBufferRectangle.Size;
			//
			Bitmap backBuffer = new Bitmap(BackBufferSize.Width, BackBufferSize.Height);
			foreach (Shapes.FrameCall thisCall in calls)
			{
				Shapes.Frame frame = format.GetFrameFromFrameCall(thisCall);
				Shapes.NamedAttachmentPoint point = format.GetNamedAttachmentPointFromFrameCall(thisCall);
				Shapes.Tween thisTween = format.GetTweenFromFrameCall(thisCall);
				Color color = format.GetColorFromFrameCall(thisCall);
				Shapes.Point totalOffset = format.GetTotalOffsetFromFrameCall(thisCall);
				//
				ImageDescription namedAttachment = null;
				if (point != null && namedAttachments.ContainsKey(point.id))
					namedAttachment = namedAttachments[point.id];
				//
				int attachmentId = 0;
				int.TryParse(thisCall.NamedAttachmentPointId, out attachmentId);
				// Archetype is the progenitor of all child layers; layer is to be drawn last.
				Bitmap layerArchetype = SupportFunctions.GetFrameBitmapFromLoadedImage(frame.s, frame.t, frame.w, frame.h, image.Bitmap);
				int tweenExists = (thisTween != null) ? 1 : 0;
				//
				for (double framesInPass = 0; framesInPass < 1 + (thisCall.MotionTrailFramesInTween * tweenExists); )
				{
					double advance = 1.0;
					// Draw the frame to the buffer.
					Rectangle layerShape = new Rectangle((int)totalOffset.X, (int)totalOffset.Y, frame.w, frame.h);
					//
					using (Bitmap layer = SupportFunctions.Copy(layerArchetype, BackBufferSize, frame.w, frame.h, totalOffset.X, totalOffset.Y, thisCall.ScaleX, thisCall.ScaleY, thisCall.RotationZ, flipX: thisCall.FlipX, namedAttachmentPoint: point, namedAttachment: namedAttachment))
					{
						Rectangle layerBoundingRectangle = new Rectangle(0, 0, layer.Width, layer.Height);
						//
						int scaledAddWidth = (int)Math.Ceiling((double)frame.w * (double)thisCall.ScaleX), scaledAddHeight = (int)Math.Ceiling((double)frame.h * (double)thisCall.ScaleY);
						Point scaledLayerOffset;
						Shapes.Point offset, offsetNew;
						if (thisTween != null)
						{
							offset = thisTween.XYZFromFrame(thisCall.FrameInTween);
							offsetNew = thisTween.XYZFromFrame(Math.Max(thisCall.FrameInTween - framesInPass, 1));
						}
						else
							offset = offsetNew = new Shapes.Point(0, 0, 0);
						// Translation from motion trail. Typically zero or the offset from tween, if a tween is present. Otherwise, it may be an offset from a different frame in the tween (i.e. giving the effect of a trail).
						Point motionTranslation = new Point((int)(offset.X - offsetNew.X), (int)(offset.Y - offsetNew.Y));
						//
						if (framesInPass <= 0)
						{
							scaledLayerOffset = new Point(
								SupportFunctions.Clamp<int>((int)Math.Floor(totalOffset.X - (double)(scaledAddWidth - frame.w) / 2.0), 0, BackBufferSize.Width),
								SupportFunctions.Clamp<int>((int)Math.Floor(totalOffset.Y - (double)(scaledAddHeight - frame.h) / 2.0), 0, BackBufferSize.Height)
							);
						}
						else
						{
							scaledLayerOffset = new Point(
								SupportFunctions.Clamp<int>((int)Math.Floor((totalOffset.X - motionTranslation.X) - (double)(scaledAddWidth - frame.w) / 2.0), 0, BackBufferSize.Width),
								SupportFunctions.Clamp<int>((int)Math.Floor((totalOffset.Y - motionTranslation.Y) - (double)(scaledAddHeight - frame.h) / 2.0), 0, BackBufferSize.Height)
							);
						}
						// Determine how large the frame call is (does not currently include named attachments).
						int diagonal = (int)Math.Ceiling(Math.Sqrt(Math.Pow(scaledAddWidth, 2) + Math.Pow(scaledAddHeight, 2)));
						// Try to cut down on writes unless necessary by only performing important actions.
						if (thisCall.BlendMode != "overwrite" || color != Color.White || thisTween != null)
						{
							// Prepare the bounding rectangle, expecting to compare at least 2 * output width * output height amount of pixel.
							Rectangle rectangle = new Rectangle(0, 0, BackBufferSize.Width, BackBufferSize.Height);
							// If there's not a named attachment image to draw, try to close in on only the necessary pixels to draw.
							if (point == null)
							{
								rectangle = new Rectangle(
									SupportFunctions.Clamp<int>((int)Math.Floor(scaledLayerOffset.X + scaledAddWidth / 2.0 - diagonal / 2.0), 0, BackBufferSize.Width),
									SupportFunctions.Clamp<int>((int)Math.Floor(scaledLayerOffset.Y + scaledAddHeight / 2.0 - diagonal / 2.0), 0, BackBufferSize.Height),
									SupportFunctions.Clamp<int>(diagonal, 0, BackBufferSize.Width),
									SupportFunctions.Clamp<int>(diagonal, 0, BackBufferSize.Height)
								);
							}
							// Perform the drawing, blending into the bitmap of the composite frame.
							for (int y = rectangle.Top; y < rectangle.Bottom; y++)
							{
								for (int x = rectangle.Left; x < rectangle.Right; x++)
								{
									Point backBufferPixelLocation = new Point(x, y);
									Point layerPixelLocation = new Point(backBufferPixelLocation.X + motionTranslation.X, backBufferPixelLocation.Y + motionTranslation.Y);
									if (layerBoundingRectangle.Contains(layerPixelLocation) && backBufferRectangle.Contains(backBufferPixelLocation))
									{
										// Get color already in the drawing context.
										Color existingColor = backBuffer.GetPixel(backBufferPixelLocation.X, backBufferPixelLocation.Y);
										// Get color of the transformed layer.
										Color layerColor = layer.GetPixel(layerPixelLocation.X, layerPixelLocation.Y);
										//
										double premultiplier = (color.A / 255.0 * layerColor.A / 255.0);
										layerColor = Color.FromArgb((int)(color.A / 255.0 * layerColor.A), (int)(premultiplier * (color.R / 255.0 * layerColor.R)), (int)(premultiplier * (color.G / 255.0 * layerColor.G)), (int)(premultiplier * (color.B / 255.0 * layerColor.B)));
										Color finalColor = Blending.Blend(layerColor, existingColor, thisCall.BlendMode, image.BackgroundColor);
										backBuffer.SetPixel(backBufferPixelLocation.X, backBufferPixelLocation.Y, finalColor);
									}
								}
							}
						}
						else
						{
							// Do clone onto.
							using (Graphics g = Graphics.FromImage(backBuffer))
							{
								g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
								g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
								g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
								g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
								g.DrawImage(layer, 0f, 0f);
							}
						}
						// Control the advancement of the loop.
						if (thisTween != null && thisCall.MotionTrailFramesInTween > 0 && thisCall.MotionTrailType == "instance-fill" && diagonal / thisTween.Length > 0)
							advance = diagonal / thisTween.Length;
					}
					framesInPass += advance;
				}
			}
			return backBuffer;
		}
	}
}
