using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Tao.OpenGl;
using System.IO;

#pragma warning disable
namespace SpriteAnimator.SupportClasses
{
	/*
	* Image Library
	*/
	public class ImageDescription
	{
		// Mode
		public static bool ForcePowerOfTwoDimensions = false;

		//
		private int id, contextId, stride;
		private int width, height;
		private int significantWidth, significantHeight;
		private GCHandle dataHandle;
		public string name;
		private bool isPlaceholder = true;
		private bool repeat = false;
		private bool pushToContext = true;
		private bool canBePushedToContext = true;
		private string filename = null;
		private int sampling = Gl.GL_NEAREST;
		private bool makeBackgroundTransparent = false;
		private OpenTK.Vector2d textureScale = new OpenTK.Vector2d(1.0, 1.0);

		public bool MakeBackgroundTransparent
		{
			get { return makeBackgroundTransparent; }
			set { makeBackgroundTransparent = value; }
		}

		public IntPtr DataPointer
		{
			get
			{
				if (this.dataHandle.IsAllocated)
					return this.dataHandle.AddrOfPinnedObject();
				return IntPtr.Zero;
			}
		}

		public bool PushToContext
		{
			get { return pushToContext; }
			set
			{
				pushToContext = value;
				if (value == true)
					pushImageToGraphicsContextIfNecessary();
			}
		}

		public int Sampling
		{
			get { return sampling; }
			set { 
				sampling = value;
				// Update the texture's sampling, if necessary.
				pushImageToGraphicsContextIfNecessary();
			}
		}

		public string Filename
		{
			get {
				if (filename != null)
					return filename;
				else
					return "";
			}
			set { filename = value; }
		}

		public bool IsPlaceholder
		{
			get { return isPlaceholder; }
			set { isPlaceholder = value; }
		}

		//
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		//
		public int Width
		{
			get { return width; }
			set { width = value; }
		}

		public int Height
		{
			get { return height; }
			set { height = value; }
		}

		//
		public int Stride
		{
			get { return stride; }
			set { stride = value; }
		}

		public int ContextId
		{
			get {
				if (pushToContext && contextId == 0)
					pushImageToGraphicsContextIfNecessary();
				return contextId;
			}
			set { contextId = value; }
		}

		private Color? backgroundColor = null;

		public Color BackgroundColor
		{
			get {
				try
				{
					if (backgroundColor != null)
						return backgroundColor.Value;
					else
						return (this.Width > 1 && this.Height > 1) ? this.Bitmap.GetPixel(1, 1) : Color.Black;
				}
				catch (Exception)
				{
					return Color.Black;
				}
			}
			set {
				this.backgroundColor = value;
			}
		}

		public DateTime LastWrite
		{
			get
			{
				try
				{
					if (filename != null)
						return File.GetLastWriteTime(filename);
				}
				catch { }
				return DateTime.MinValue;
			}
		}

		public Bitmap Bitmap
		{
			get
			{
				return new Bitmap(this.width, this.height, this.stride, PixelFormat.Format32bppArgb, this.DataPointer);
			}
			private set { }
		}

		public Bitmap SignificantBitmap
		{
			get
			{
				Bitmap possiblyLargerBitmap = Bitmap;
				Bitmap bitmap = new Bitmap(this.significantWidth, this.significantHeight);
				using (Graphics g = Graphics.FromImage(bitmap))
					g.DrawImage(possiblyLargerBitmap, 0, 0, possiblyLargerBitmap.Width, possiblyLargerBitmap.Height);
				possiblyLargerBitmap.Dispose();
				return bitmap;
			}
			private set { }
		}

		public OpenTK.Vector2d TextureScale
		{
			get { return textureScale; }
			set { textureScale = value; }
		}

		public double SignificantWidth {
			get { return TextureScale.X * this.Width; }
		}

		public double SignificantHeight {
			get { return TextureScale.Y * this.Height; }
		}

		public ImageDescription(int id, Bitmap bitmap = null, bool repeat = false, bool pushToContext = true, bool makeBackgroundTransparent = false, Color? backgroundColor = null, int sampling = Gl.GL_NEAREST, bool canBePushedToContext = true)
		{
			this.id = id;
			this.repeat = repeat;
			this.pushToContext = pushToContext;
			this.canBePushedToContext = canBePushedToContext;
			if (!canBePushedToContext)
				this.pushToContext = false;
			this.sampling = sampling;
			this.backgroundColor = backgroundColor;
			this.makeBackgroundTransparent = makeBackgroundTransparent;
			replaceWithBitmap(bitmap);
		}

		public ImageDescription(int id, string filename, bool repeat = false, bool pushToContext = true, bool makeBackgroundTransparent = false, int sampling = Gl.GL_NEAREST)
			: this(id, bitmap: new Bitmap(filename), repeat: repeat, pushToContext: pushToContext, makeBackgroundTransparent: makeBackgroundTransparent, sampling: sampling)
		{
			this.filename = filename;
		}

		public ImageDescription()
			: this(0)
		{
		}

		private Bitmap padImageToNextPowerOfTwo(Bitmap bitmap)
		{
			// Force power of two to handle compatibility for clients that may require them.
			if (canBePushedToContext && ForcePowerOfTwoDimensions && bitmap != null && bitmap.PixelFormat != PixelFormat.Undefined)
			{
				int oldWidth = bitmap.Width;
				int oldHeight = bitmap.Height;
				int newWidth = (int)OpenTKSupportFunctions.NextPowerOfTwo((uint)oldWidth);
				int newHeight = (int)OpenTKSupportFunctions.NextPowerOfTwo((uint)oldHeight);
				//
				bool differentWidth = newWidth != oldWidth;
				bool differentHeight = newHeight != oldHeight;
				if (differentWidth || differentHeight)
				{
					Bitmap newBitmap = new Bitmap(newWidth, newHeight);
					using (Graphics g = Graphics.FromImage(newBitmap))
						g.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
					bitmap = newBitmap;
				}
				if (differentWidth)
					textureScale.X = oldWidth / (double)newWidth;
				if (differentHeight)
					textureScale.Y = oldHeight / (double)newHeight;
			}
			return bitmap;
		}

		public void replaceWithBitmap(Bitmap bitmap = null, bool respectMakeBackgroundTransparent = true, bool significant = true)
		{
			//
			bool isPlaceholder = false;
			if (bitmap == null)
			{
				bitmap = new Bitmap(1, 1);
				bitmap.SetPixel(0, 0, Color.FromArgb(0, 0, 0, 0));
				isPlaceholder = true;
			}
			//
			int significantWidth = bitmap.Width;
			int significantHeight = bitmap.Height;
			bitmap = padImageToNextPowerOfTwo(bitmap);
			//
			int width = 0, height = 0, stride = 0;
			byte[] thisByteArray = new byte[0];
			using (Bitmap bm2 = bitmap)
			{
				//
				width = bm2.Width;
				height = bm2.Height;
				Rectangle rect2 = new Rectangle(0, 0, bm2.Width, bm2.Height);
				BitmapData bm2Data = bm2.LockBits(rect2, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				try
				{
					IntPtr bm2Ptr = bm2Data.Scan0;
					stride = bm2Data.Stride;
					thisByteArray = new byte[Math.Abs(bm2Data.Stride) * bm2.Height];
					Marshal.Copy(bm2Ptr, thisByteArray, 0, thisByteArray.Length);
					bm2Ptr = IntPtr.Zero;
				}
				finally
				{
					bm2.UnlockBits(bm2Data); //Lock End
				}
			}
			//
			this.width = width;
			this.height = height;
			if (significant)
			{
				this.significantWidth = significantWidth;
				this.significantHeight = significantHeight;
			}
			this.stride = stride;
			this.isPlaceholder = isPlaceholder;
			//
			if (this.DataPointer != IntPtr.Zero)
				this.dataHandle.Free();
			// Pin byte array to make pointer available to data.
			this.dataHandle = GCHandle.Alloc(thisByteArray, GCHandleType.Pinned);
			//
			bitmap.Dispose();
			// Make the background of the image transparent after the fact if and only if the code is supposed to respect such a directive and it hasn't already.
			if (respectMakeBackgroundTransparent)
			{
				if (this.makeBackgroundTransparent)
					makeBackgroundOfBitmapTransparent();
			}
			//
			pushImageToGraphicsContextIfNecessary();
		}

		public void replaceWithBitmap(string filename)
		{
			replaceWithBitmap(new Bitmap(filename));
		}

		private void pushImageToGraphicsContextIfNecessary()
		{
			if (pushToContext && canBePushedToContext)
				SupportFunctions.createOrRecreateTexture(this.width, this.height, ref this.contextId, imageData: this.DataPointer, textureRepeat: (repeat) ? Gl.GL_REPEAT : Gl.GL_CLAMP, textureFilter: this.sampling);
		}

		public void makeBackgroundOfBitmapTransparent()
		{
			Bitmap thisBitmap = this.Bitmap;
			thisBitmap.MakeTransparent(this.BackgroundColor);
			this.replaceWithBitmap(thisBitmap, respectMakeBackgroundTransparent: false, significant: false);
		}

		public void resetBackgroundColor()
		{
			backgroundColor = null;
		}

		public void Save()
		{
			if (Filename != null)
			{
				try
				{
					this.SignificantBitmap.Save(Filename);
				}
				catch (Exception) { }
			}
		}

		public void Dispose()
		{
			if (this.DataPointer != IntPtr.Zero)
				this.dataHandle.Free();
		}

		~ImageDescription()
		{
			Dispose();
		}
	}
}
