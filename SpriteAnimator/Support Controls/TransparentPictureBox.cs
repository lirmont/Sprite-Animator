using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SpriteAnimator
{
	[System.Reflection.ObfuscationAttribute(Feature = "renaming")]
	public partial class TransparentPictureBox : Panel
	{
		private System.Drawing.Image image;
		public System.Drawing.Image Image
		{
			get { return image; }
			set { image = value; }
		}
		public PictureBoxSizeMode SizeMode;
		public AutoScaleMode AutoScaleMode;

		public TransparentPictureBox()
		{
			InitializeComponent();
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
				return cp;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (this.Image != null)
			{
				Graphics gfx = this.CreateGraphics();
				gfx.DrawImage(this.Image, 0, 0, this.Width, this.Height);
				gfx.Dispose();
			}
			base.OnPaint(e);
		}

		protected void InvalidateEx()
		{
			if (Parent == null)
				return;
			Rectangle rc = new Rectangle(this.Location, this.Size);
			Parent.Invalidate(rc, true);
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			//do not allow the background to be painted 
		}
	}
}
