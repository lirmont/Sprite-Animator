using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;
using SpriteAnimator.SupportClasses;

namespace SpriteAnimator
{
	partial class SupportFunctions
	{
		public static Bitmap Copy(Bitmap srcBitmap, Size outputSize, double width, double height, double offsetX, double offsetY, double scaleX, double scaleY, double rotationZ, bool flipX = false, Shapes.NamedAttachmentPoint namedAttachmentPoint = null, SupportClasses.ImageDescription namedAttachment = null)
		{
			//
			int outputWidth = outputSize.Width, outputHeight = outputSize.Height;
			//
			scaleX = (flipX) ? -scaleX : scaleX;
			float halfWidth = (float)width / 2f, halfHeight = (float)height / 2f;
			float centerX = -halfWidth, centerY = -halfHeight;
			float translateX = (int)offsetX + halfWidth, translateY = (int)offsetY + halfHeight;
			// Prepare frame call image.
			Bitmap bmp = new Bitmap(outputWidth, outputHeight);
			// Prepare named attachment image.
			Bitmap attachmentLayer = null;
			if (namedAttachment != null && !namedAttachment.IsPlaceholder)
				attachmentLayer = (Bitmap)namedAttachment.Bitmap.Clone();
			//
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.Clear(Color.FromArgb(1, 1, 1, 0));
				// Push the coordinate transformation.
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
				g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
				g.TranslateTransform(translateX, translateY);
				if (rotationZ != 0)
					g.RotateTransform((float)rotationZ);
				g.ScaleTransform((float)scaleX, (float)scaleY);
				// Draw the frame call.
				g.DrawImage(srcBitmap, centerX, centerY, new Rectangle(Point.Empty, new Size(outputWidth, outputHeight)), GraphicsUnit.Pixel);
				//
				if (namedAttachmentPoint != null && attachmentLayer != null)
				{
					// Draw the attachment.
					g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
					g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
					centerX += halfWidth - (0.5f * attachmentLayer.Width);
					centerY += halfHeight - (0.5f * attachmentLayer.Height);
					g.DrawImage(
						(Image)attachmentLayer,
						(float)(centerX - attachmentLayer.Width * (0.5f - namedAttachmentPoint.x)),
						(float)(centerY + attachmentLayer.Height * (0.5f - namedAttachmentPoint.y)),
						(float)attachmentLayer.Width,
						(float)attachmentLayer.Height
					);
				}
			}
			return bmp;
		}

		public static Bitmap GetFrameBitmapFromLoadedImage(int sInPixels, int tInPixels, int addWidth, int addHeight, Bitmap existingBitmap)
		{
			Bitmap layerArchetype;
			try
			{
				int thisSInPixels = Math.Min(existingBitmap.Width, Math.Abs(sInPixels));
				int thisTInPixels = Math.Min(existingBitmap.Height, Math.Abs(tInPixels));
				int thisAddWidth = Math.Min(existingBitmap.Width - sInPixels, addWidth);
				int thisAddHeight = Math.Min(existingBitmap.Height - tInPixels, addHeight);
				// Get the frame call's image.
				layerArchetype = existingBitmap.Clone(new Rectangle(thisSInPixels, thisTInPixels, thisAddWidth, thisAddHeight), existingBitmap.PixelFormat);
			}
			catch (Exception)
			{
				layerArchetype = new Bitmap(addWidth, addHeight);
			}
			return layerArchetype;
		}

		private static List<PixelFormat> fourComponentFormats = new List<PixelFormat> {
			PixelFormat.Format32bppArgb,
			PixelFormat.Format16bppArgb1555,
			PixelFormat.Format32bppPArgb,
			PixelFormat.Format64bppArgb,
			PixelFormat.Format64bppPArgb
		};
		private static List<PixelFormat> singleComponentFormats = new List<PixelFormat> {
			PixelFormat.Format16bppGrayScale,
			PixelFormat.Alpha,
		};
		private static List<PixelFormat> convertFormatsTo32 = new List<PixelFormat> {
			PixelFormat.Format16bppRgb555,
			PixelFormat.Format16bppRgb565,
			PixelFormat.Format8bppIndexed,
			PixelFormat.Format4bppIndexed
		};
		public static List<Color> Colors(Bitmap inputBitmap)
		{
			Bitmap bmp;
			// Convert the image if it's indexed (so that the colors can be read properly).
			if (convertFormatsTo32.Exists(item => item == inputBitmap.PixelFormat))
				bmp = ConvertTo32(inputBitmap);
			else
				bmp = inputBitmap;
			//
			List<Color> colors = new List<Color>();
			// Lock the bitmap's bits.
			Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
			PixelFormat format = bmp.PixelFormat;
			BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, format);
			// Component count (RGB or RGBA).
			int components = 3;
			if (fourComponentFormats.Exists(item => item == format))
				components = 4;
			else if (singleComponentFormats.Exists(item => item == format))
				components = 1;
			// Get the address of the first line.
			IntPtr ptr = bmpData.Scan0;
			// Declare an array to hold the bytes of the bitmap.
			int bytes = bmpData.Stride * bmp.Height;
			byte[] rgbaValues = new byte[bytes];
			// Dimensions: major = components.
			List<byte[]> stuff = new List<byte[]>();
			// Copy the RGB values into the array.
			Marshal.Copy(ptr, rgbaValues, 0, bytes);
			// The stride is the width of a single row of pixels (a scan line), rounded up to a four-byte boundary. If the stride is positive, the bitmap is top-down. If the stride is negative, the bitmap is bottom-up.
			int stride = bmpData.Stride;
			// Put the colors into a list.
			for (int row = 0; row < bmpData.Height; row++)
			{
				for (int column = 0; column < bmpData.Width; column++)
				{
					byte[] thisComponentSet = new byte[components];
					for (int component = 0; component < components; component++)
						thisComponentSet[component] = (byte)(rgbaValues[(row * stride) + (column * components) + component]);
					if (thisComponentSet.Length == 4)
						colors.Add(Color.FromArgb(thisComponentSet[3], thisComponentSet[2], thisComponentSet[1], thisComponentSet[0]));
					else if (thisComponentSet.Length == 3)
						colors.Add(Color.FromArgb(thisComponentSet[2], thisComponentSet[1], thisComponentSet[0]));
					//
					stuff.Add(thisComponentSet);
				}
			}
			return colors;
		}

		private static Bitmap ConvertTo32(Bitmap bmp)
		{
			Bitmap converted = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppArgb);
			using (Graphics g = Graphics.FromImage(converted))
			{
				// Prevent DPI conversion
				g.PageUnit = GraphicsUnit.Pixel;
				g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
				g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
				// Draw the image
				g.DrawImageUnscaled(bmp, 0, 0);
			}
			return converted;
		}

		public static List<Color> UniqueColors(Bitmap bmp)
		{
			List<Color> colors = Colors(bmp);
			return Distinct<Color>(colors);
		}

		public static List<T> Distinct<T>(IEnumerable<T> source)
		{
			List<T> uniques = new List<T>();
			foreach (T item in source)
			{
				if (!uniques.Contains(item)) uniques.Add(item);
			}
			return uniques;
		}

		public static void RunColorsForConstructedPalette(string file)
		{
			Thread colorThread = new Thread(new ThreadStart(delegate()
			{
				Palette.colorsInPalette.Clear();
				//
				using (Bitmap image = new Bitmap(file))
				{
					List<SupportClasses.ColorWithCount> colorsWithCount = new List<ColorWithCount>();
					// Get colors.
					List<Color> colors = SupportFunctions.Colors(image);
					// Pull out the unique ones and count them.
					List<Color> uniqueColors = SupportFunctions.Distinct<Color>(colors);
					foreach (Color color in uniqueColors)
					{
						List<Color> thisColorList = colors.FindAll(item => item == color);
						int count = thisColorList.Count;
						colorsWithCount.Add(new ColorWithCount(color, count));
					}
					Palette.colorsInPalette = colorsWithCount;
				}
			}));
			colorThread.Name = "Run Colors for Constructed Palette";
			colorThread.Start();
		}
	}
}
