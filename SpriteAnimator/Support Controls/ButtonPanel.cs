using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SpriteAnimator
{
	[System.Reflection.ObfuscationAttribute(Feature = "renaming")]
	public partial class ButtonPanel : Panel
	{
		private int borderWidth = 3;
		[Category("Custom")]
		[Description("Border Width?")]
		[DefaultValue(3)]
		public int BorderWidth
		{
			get
			{
				return this.borderWidth;
			}
			set
			{
				this.borderWidth = Math.Abs(value);
				this.Refresh();
			}
		}

		private double steps = 20;
		[Category("Custom")]
		[Description("Color Steps?")]
		[DefaultValue(20)]
		public double ColorSteps
		{
			get
			{
				return this.steps;
			}
			set
			{
				this.steps = Math.Abs(value);
				this.Refresh();
			}
		}

		private Color gradientColor = Color.SlateGray;
		[Category("Custom")]
		[Description("Gradient Color?")]
		public Color GradientColor
		{
			get
			{
				return this.gradientColor;
			}
			set
			{
				this.gradientColor = value;
				this.Refresh();
			}
		}

		private Color hoverGradientColor = Color.LightSlateGray;
		[Category("Custom")]
		[Description("Hover-Select Gradient Color?")]
		public Color HoverGradientColor
		{
			get
			{
				return this.hoverGradientColor;
			}
			set
			{
				this.hoverGradientColor = value;
				this.Refresh();
			}
		}

		private Color borderColor = Color.SlateGray;
		[Category("Custom")]
		[Description("Border Color?")]
		public Color BorderColor
		{
			get
			{
				return this.borderColor;
			}
			set
			{
				this.borderColor = value;
				this.Refresh();
			}
		}

		private string title = "ButtonPanel";
		[Category("Custom")]
		[Description("Title Bar Text?")]
		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				this.title = value;
			}
		}

		public ButtonPanel()
		{
			InitializeComponent();
		}

		public ButtonPanel(IContainer container)
		{
			InitializeComponent();
		}

		public int numberOfClicks = 0;
		public int lastClick = 0;
		protected override void OnMouseEnter(EventArgs e)
		{
			this.Focus();
			this.Refresh();
			this.Cursor = Cursors.Hand;
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			this.Parent.Focus();
			this.Refresh();
			base.OnMouseLeave(e);
		}

		protected override void OnResize(EventArgs eventargs)
		{
			this.Refresh();
			base.OnResize(eventargs);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Color a = BackColor;
			Color c = gradientColor;
			if (this.Focused)
				c = hoverGradientColor;
			Graphics gfx = this.CreateGraphics();
			for (int i = 0; i < Math.Min(steps, Math.Max(0, this.Height)); i++)
			{
				double r = c.R / 255.0, g = c.G / 255.0, b = c.B / 255.0;
				double ar = a.R / 255.0, ag = a.G / 255.0, ab = a.B / 255.0;
				double blend = (i - borderWidth) / steps;
				double blendComplement = 1 - blend;
				Pen p = new Pen(Color.FromArgb(255, (int)Math.Min(255, Math.Max(0, (r * 255))), (int)Math.Min(255, Math.Max(0, (g * 255))), (int)Math.Min(255, Math.Max(0, (b * 255)))));
				if (i > borderWidth)
				{
					try
					{
						gfx.DrawLine(p, new Point(borderWidth, this.Height - i), new Point(this.Width - borderWidth, this.Height - i));
					}
					catch (Exception)
					{
						break;
					}
					c = Color.FromArgb(255,
					(int)
						Math.Min(255, Math.Max(0, ((r * blendComplement + ar * blend) * 255))),
					(int)
						Math.Min(255, Math.Max(0, ((b * blendComplement + ab * blend) * 255))),
					(int)
						Math.Min(255, Math.Max(0, ((g * blendComplement + ag * blend) * 255)))
					);
				}
				else
				{
					// In case the gfx context is protected during closing, catch the mistaken draw requests and ignore them.
					try {
						gfx.DrawLine(new Pen(borderColor), new Point(borderWidth, this.Height - i), new Point(this.Width - borderWidth, this.Height - i));
					} catch { }
				}
			}
			if (borderWidth > 0)
			{
				for (int i = 0; i < borderWidth; i++)
				{
					try
					{
						gfx.DrawLine(new Pen(borderColor), new Point(i, this.Height), new Point(i, 0));
					}
					catch (Exception) { }
					try
					{
						gfx.DrawLine(new Pen(borderColor), new Point(this.Width - borderWidth + i, this.Height), new Point(this.Width - borderWidth + i, 0));
					}
					catch (Exception) { }
				}
				try
				{
					gfx.DrawLine(new Pen(borderColor), new Point(0, 0), new Point(this.Width, 0));
				}
				catch (Exception) { }
			}
			if (title != "")
			{
				try
				{
					gfx.DrawString(title, this.Font, new Pen(gradientColor).Brush, new PointF(borderWidth + 5f, 3f));
				}
				catch (Exception) { }
				try
				{
					gfx.DrawString(title, this.Font, new Pen(this.ForeColor).Brush, new PointF(borderWidth + 4f, 2f));
				}
				catch (Exception) { }
			}
			gfx.Dispose();
			base.OnPaint(e);
		}
	}
}
