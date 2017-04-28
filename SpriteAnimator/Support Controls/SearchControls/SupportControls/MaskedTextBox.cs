using System.ComponentModel;
using System.Drawing;
namespace SearchControls
{
	[System.Reflection.ObfuscationAttribute(Feature = "renaming")]
	public partial class MaskedTextBox : System.Windows.Forms.MaskedTextBox
	{
		private System.Windows.Forms.Button up, down;

		private string emptyText = "";
		[Category("Custom")]
		[Description("Displays a message when no data is available.")]
		[DefaultValue(typeof(string), "")]
		public string EmptyText
		{
			get
			{
				return this.emptyText;
			}
			set
			{
				this.emptyText = value;
			}
		}

		private bool isNumeric = false;
		[Category("Custom")]
		[Description("Is the mask numeric?")]
		[DefaultValue(false)]
		public bool IsNumeric
		{
			get
			{
				return this.isNumeric;
			}
			set
			{
				this.isNumeric = value;
			}
		}

		private double ceiling = 1.0;
		[Category("Custom")]
		[Description("If mask is numeric, what is the ceiling?")]
		[DefaultValue(1.0)]
		public double Ceiling
		{
			get
			{
				return this.ceiling;
			}
			set
			{
				this.ceiling = value;
			}
		}

		private double floor = 0.0;
		[Category("Custom")]
		[Description("If mask is numeric, what is the floor?")]
		[DefaultValue(0.0)]
		public double Floor
		{
			get
			{
				return this.floor;
			}
			set
			{
				this.floor = value;
			}
		}

		private double increment = 1.0;
		[Category("Custom")]
		[Description("If mask is numeric, what is the up/down increment?")]
		[DefaultValue(1.0)]
		public double Increment
		{
			get
			{
				return this.increment;
			}
			set
			{
				this.increment = value;
			}
		}

		private double interval = 200.0;
		[Category("Custom")]
		[Description("If mask is numeric, what is the update interval?")]
		[DefaultValue(0.2)]
		public double Interval
		{
			get
			{
				return this.interval / 1000.0;
			}
			set
			{
				this.interval = value * 1000.0;
			}
		}

		private bool allowBlank = false;
		[Category("Custom")]
		[Description("Allow field to be empty?")]
		[DefaultValue(false)]
		public bool AllowBlank
		{
			get
			{
				return this.allowBlank;
			}
			set
			{
				this.allowBlank = value;
			}
		}

		private bool markInvalid = false;

		public bool MarkInvalid
		{
			get { return markInvalid; }
			set
			{
				markInvalid = value;
				this.Invalidate();
			}
		}

		private System.Timers.Timer updateUp, updateDown;

		public MaskedTextBox()
		{
			InitializeComponent();
		}

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			switch (m.Msg)
			{
				case 15: // this is the WM_PAINT message
					// call the default win32 Paint method for the TextBox first
					this.Invalidate();
					base.WndProc(ref m);
					// now use our code to draw extra stuff over the TextBox
					this.CustomPaint();
					break;
				default:
					base.WndProc(ref m);
					break;
			}
		}

		private void updateText(string t, MaskedTextBox mtb)
		{
			try
			{
				mtb.Invoke((System.Windows.Forms.MethodInvoker)delegate
				{
					mtb.Text = t;
				});
			}
			catch (System.Exception) { }
		}

		public bool validate()
		{
			if (
				( // Mask marked as done, but, if it's not supposed to be blank and it is, then mark invalid.
					MaskCompleted && (!AllowBlank && Text.Trim(' ', '.') == "")
				) ||
				( // Mask is marked as not done, but, if it's blank and that's okay, ignore.
					!MaskCompleted && !(AllowBlank && Text.Trim(' ', '.') == "")
				)
				)
			{
				MarkInvalid = true;
			}
			else
			{
				MarkInvalid = false;
			}
			return MarkInvalid;
		}

		private void CustomPaint()
		{
			if (this.Text.Trim(' ', '.') == "" && this.EmptyText != "" && !this.Focused)
			{
				Graphics g = this.CreateGraphics();
				g.Clear(this.BackColor);
				g.DrawString(this.EmptyText, new Font(Parent.Font, FontStyle.Regular), new SolidBrush(Color.FromArgb(0x70, 0x70, 0x70)), new Point(1, 2));
				if (markInvalid)
				{
					Rectangle r = this.ClientRectangle;
					r.Width -= 1 + ((this.isNumeric ? 1 : 0) * 15);
					g.DrawRectangle(Pens.Red, r);
				}
			}
			else if (markInvalid)
			{
				Graphics g = this.CreateGraphics();
				Rectangle r = this.ClientRectangle;
				r.Width -= 1 + ((this.isNumeric ? 1 : 0) * 15);
				g.DrawRectangle(Pens.Red, r);
			}
			//
			if (this.isNumeric)
			{
				if (up == null)
				{
					updateUp = new System.Timers.Timer(interval);
					updateUp.Interval = interval;
					updateUp.Elapsed += new System.Timers.ElapsedEventHandler(delegate(object sender, System.Timers.ElapsedEventArgs e)
					{
						if (string.IsNullOrEmpty(this.Text))
							updateText(Floor.ToString(), this);
						updateText((System.Math.Min(double.Parse(this.Text) + increment, Ceiling)).ToString(), this);
					});
					up = new System.Windows.Forms.Button();
					up.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
					up.Location = new Point(this.Width - 19, 0);
					up.Width = 15;
					up.Height = System.Math.Max((int)(this.Height / 2.0) - 2, 5);
					up.BackColor = SystemColors.ButtonFace;
					up.MouseHover += new System.EventHandler(delegate(object sender, System.EventArgs e)
					{
						this.Cursor = System.Windows.Forms.Cursors.Hand;
					});
					up.MouseLeave += new System.EventHandler(delegate(object sender, System.EventArgs e)
					{
						this.Cursor = System.Windows.Forms.Cursors.IBeam;
					});
					up.MouseDown += new System.Windows.Forms.MouseEventHandler(delegate(object sender, System.Windows.Forms.MouseEventArgs e)
					{
						if (string.IsNullOrEmpty(this.Text))
							updateText(Floor.ToString(), this);
						else
							updateText((System.Math.Min(double.Parse(this.Text) + increment, Ceiling)).ToString(), this);
						updateUp.Enabled = true;
					});
					up.MouseUp += new System.Windows.Forms.MouseEventHandler(delegate(object sender, System.Windows.Forms.MouseEventArgs e)
					{
						updateUp.Enabled = false;
						this.Focus();
					});
					up.Paint += new System.Windows.Forms.PaintEventHandler(delegate(object sender, System.Windows.Forms.PaintEventArgs e)
					{
						if (System.Windows.Forms.ScrollBarRenderer.IsSupported)
							System.Windows.Forms.ScrollBarRenderer.DrawArrowButton(e.Graphics, up.ClientRectangle, System.Windows.Forms.VisualStyles.ScrollBarArrowButtonState.UpNormal);
						else
						{
							e.Graphics.DrawPolygon(Pens.Black, new Point[] { 
                                new Point((int)(up.Width/2.0+2), (int)(up.Height/2.0)),
                                new Point((int)(up.Width/2.0-2), (int)(up.Height/2.0)),
                                new Point((int)(up.Width/2.0), (int)(up.Height/2.0-2))
                            });
							e.Graphics.FillPolygon(Brushes.Black, new Point[] { 
                                new Point((int)(up.Width/2.0+2), (int)(up.Height/2.0)),
                                new Point((int)(up.Width/2.0-2), (int)(up.Height/2.0)),
                                new Point((int)(up.Width/2.0), (int)(up.Height/2.0-2))
                            }, System.Drawing.Drawing2D.FillMode.Winding);
						}
					});
					this.Controls.Add(up);
				}
				if (down == null)
				{
					updateDown = new System.Timers.Timer(interval);
					updateDown.Interval = interval;
					updateDown.Elapsed += new System.Timers.ElapsedEventHandler(delegate(object sender, System.Timers.ElapsedEventArgs e)
					{
						if (string.IsNullOrEmpty(this.Text))
							updateText(Floor.ToString(), this);
						updateText((System.Math.Max(double.Parse(this.Text) - increment, Floor)).ToString(), this);
					});
					down = new System.Windows.Forms.Button();
					down.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
					down.Location = new Point(this.Width - 19, (int)(this.Height / 2.0 - 2));
					down.Width = 15;
					down.Height = System.Math.Max((int)(this.Height / 2.0) - 2, 5);
					down.BackColor = SystemColors.ButtonFace;
					down.MouseHover += new System.EventHandler(delegate(object sender, System.EventArgs e)
					{
						this.Cursor = System.Windows.Forms.Cursors.Hand;
					});
					down.MouseLeave += new System.EventHandler(delegate(object sender, System.EventArgs e)
					{
						this.Cursor = System.Windows.Forms.Cursors.IBeam;
					});
					down.MouseDown += new System.Windows.Forms.MouseEventHandler(delegate(object sender, System.Windows.Forms.MouseEventArgs e)
					{
						if (string.IsNullOrEmpty(this.Text))
							updateText(Floor.ToString(), this);
						else
							updateText((System.Math.Max(double.Parse(this.Text) - increment, Floor)).ToString(), this);
						updateDown.Enabled = true;
					});
					down.MouseUp += new System.Windows.Forms.MouseEventHandler(delegate(object sender, System.Windows.Forms.MouseEventArgs e)
					{
						updateDown.Enabled = false;
						this.Focus();
					});
					down.Paint += new System.Windows.Forms.PaintEventHandler(delegate(object sender, System.Windows.Forms.PaintEventArgs e)
					{
						if (System.Windows.Forms.ScrollBarRenderer.IsSupported)
							System.Windows.Forms.ScrollBarRenderer.DrawArrowButton(e.Graphics, down.ClientRectangle, System.Windows.Forms.VisualStyles.ScrollBarArrowButtonState.DownNormal);
						else
						{
							e.Graphics.DrawPolygon(Pens.Black, new Point[] { 
                                new Point((int)(down.Width/2.0+2), (int)(down.Height/2.0-2)),
                                new Point((int)(down.Width/2.0-2), (int)(down.Height/2.0-2)),
                                new Point((int)(down.Width/2.0), (int)(down.Height/2.0))
                            });
							e.Graphics.FillPolygon(Brushes.Black, new Point[] { 
                                new Point((int)(down.Width/2.0+2), (int)(down.Height/2.0-2)),
                                new Point((int)(down.Width/2.0-2), (int)(down.Height/2.0-2)),
                                new Point((int)(down.Width/2.0), (int)(down.Height/2.0))
                            }, System.Drawing.Drawing2D.FillMode.Winding);
						}
					});
					this.Controls.Add(down);
				}
			}
		}
	}
}
