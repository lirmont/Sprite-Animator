using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpriteAnimator
{
	public partial class Palette : Form
	{
		public static List<SupportClasses.ColorWithCount> colorsInPalette = new List<SupportClasses.ColorWithCount>();
		const int compressedPageSize = 190;
		const int uncompressedPageSize = 11;
		private int start, pageSize, limit, page;
		//
		private int pixelCount = 0;
		private static Color backgroundColor = Color.Black;

		//
		public static Color? MostUsedColor
		{
			get
			{
				SupportClasses.ColorWithCount majorColor = null;
				if (colorsInPalette.Count > 0)
				{
					foreach (SupportClasses.ColorWithCount color in colorsInPalette)
					{
						if (!(color.Color.R == backgroundColor.R && color.Color.G == backgroundColor.G && color.Color.B == backgroundColor.B))
						{
							if (majorColor == null)
								majorColor = color;
							else if (color.Count > majorColor.Count)
								majorColor = color;
						}
					}
				}
				return majorColor;
			}
		}

		public Palette(int pixelCount = 0, Color? backgroundColor = null)
		{
			if (backgroundColor == null)
				backgroundColor = Color.Black;
			// Recognize a background color so it can be removed from the list and from counting metrics.
			backgroundColor = backgroundColor.Value;
			// Prepare to remove the background color from counting metrics.
			int countOfBackgroundPixels = 0;
			SupportClasses.ColorWithCount backgroundColorWithCount = colorsInPalette.Find(color => (color.Color.R == backgroundColor.Value.R && color.Color.G == backgroundColor.Value.G && color.Color.B == backgroundColor.Value.B));
			if (backgroundColorWithCount != null)
				countOfBackgroundPixels = backgroundColorWithCount.Count;
			// Store a pixel count so that colors can be compared to each other.
			this.pixelCount = Math.Max(0, pixelCount - countOfBackgroundPixels);
			// Initialize paging settings.
			page = 1;
			start = 0;
			pageSize = limit = compressedPageSize;
			// Realize the form.
			InitializeComponent();
			resetMaximumValueOfPagingControl();
			layoutColors();
		}

		public void layoutColors()
		{
			colorArea.Controls.Clear();
			int currentRowIfNotChecked = 0;
			Panel currentPanel = null;
			if (start + limit > colorsInPalette.Count)
				limit = colorsInPalette.Count - start;
			for (int i = start; i < start + limit; i++)
			{
				Color c = colorsInPalette[i];
				int thisUseCount = colorsInPalette[i].Count;
				// Only include the color if it's not the background color, considering the background color is not actually used (as it's treated as a transparent pixel).
				if (!(c.R == backgroundColor.R && c.G == backgroundColor.G && c.B == backgroundColor.B))
				{
					Colors.ReseneColor rc = Colors.ColorList.Find(item => item.r == c.R && item.g == c.G && item.b == c.B);
					if (rc == null)
						rc = new Colors.ReseneColor("(no name)", c.R, c.G, c.B);
					// Draw compressed view; otherwise, draw extended view.
					if (compressViewCheckBox.Checked)
					{
						// Create a FlowLayoutPanel to house the color swatches.
						if (currentPanel == null)
						{
							currentPanel = new FlowLayoutPanel();
							currentPanel.Width = this.colorArea.Width;
							currentPanel.Height = this.colorArea.Height;
							currentPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
							this.colorArea.Controls.Add(currentPanel);
							currentPanel.Hide();
							currentPanel.SuspendLayout();
						}
						// Create a color swatch.
						Panel p = new Panel();
						double totalCount = (pixelCount > 0) ? pixelCount : thisUseCount;
						if (useCountCloudCheckBox.Checked)
						{
							p.Width = (int)(15 * Math.Pow(1 + thisUseCount / totalCount, 10));
							p.Height = (int)(15 * Math.Pow(1 + thisUseCount / totalCount, 10));
						}
						else
						{
							p.Width = 15;
							p.Height = 15;
						}
						p.Padding = new Padding(0);
						p.BorderStyle = BorderStyle.Fixed3D;
						p.BackColor = c;
						p.Anchor = AnchorStyles.Left;
						p.MouseEnter += delegate(object sender, EventArgs e)
						{
							toolStripStatusLabel.Text = String.Format("#{0:X2}{1:X2}{2:X2}, {3} (HSB: {4:0.00}, {5:0.00}, {6:0.00})", new object[] { c.R, c.G, c.B, rc.name, c.GetHue(), c.GetSaturation(), c.GetBrightness() });
						};
						currentPanel.Controls.Add(p);
					}
					else
					{
						// Container for row: color polygon, name, and description.
						Panel thisRow = new Panel();
						thisRow.Height = 15;
						thisRow.Location = new Point(compressViewCheckBox.Left, 3 + currentRowIfNotChecked * 18);
						thisRow.Width = this.colorArea.Width;
						thisRow.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
						thisRow.BackColor = Color.Transparent;
						this.colorArea.Controls.Add(thisRow);
						currentPanel = thisRow;
						// Color polygon.
						Panel p = new Panel();
						p.Width = 45;
						p.Height = 15;
						p.Padding = new Padding(0);
						p.BorderStyle = BorderStyle.Fixed3D;
						p.BackColor = c;
						p.Anchor = AnchorStyles.Left;
						p.MouseEnter += delegate(object sender, EventArgs e)
						{
							toolStripStatusLabel.Text = String.Format("#{0:X2}{1:X2}{2:X2}, {3} (HSB: {4:0.00}, {5:0.00}, {6:0.00})", new object[] { c.R, c.G, c.B, rc.name, c.GetHue(), c.GetSaturation(), c.GetBrightness() });
						};
						// Hexadecimal name.
						Label q = new Label();
						q.AutoSize = false;
						q.Height = 15;
						q.Width = 74;
						q.Location = new Point(p.Width, 0);
						q.Font = new Font(new FontFamily("Courier New"), 10f, FontStyle.Bold);
						q.Text = String.Format("#{0:X2}{1:X2}{2:X2},", new object[] { c.R, c.G, c.B });
						q.BackColor = Color.Transparent;
						// Actual name, along with hue, saturation, and brightness.
						Label s = new Label();
						s.Height = 15;
						s.Width = this.colorArea.Width - p.Width - q.Width;
						s.Anchor = AnchorStyles.Right | AnchorStyles.Left;
						s.Location = new Point(p.Width + q.Width, 0);
						s.Font = new Font(new FontFamily("Courier New"), 10f, FontStyle.Regular);
						s.Text = String.Format("{0,-15} (HSB: {1,6:0.00}, {2,4:0.00}, {3,4:0.00})", new object[] { rc.name, c.GetHue(), c.GetSaturation(), c.GetBrightness() });
						s.BackColor = Color.Transparent;
						// Add everything in.
						currentPanel.Controls.Add(p);
						currentPanel.Controls.Add(q);
						currentPanel.Controls.Add(s);
						//
						currentRowIfNotChecked++;
					}
				}
			}
			//
			if (currentPanel != null)
			{
				currentPanel.ResumeLayout();
				currentPanel.Show();
			}
		}

		private void Palette_Resize(object sender, EventArgs e)
		{
			this.colorArea.Height = (colorArea.HorizontalScroll.Visible) ? this.colorArea.Height + 17 : this.colorArea.Height;
		}

		private void compressView_CheckedChanged(object sender, EventArgs e)
		{
			if (compressViewCheckBox.Checked)
			{
				start = 0;
				pageSize = limit = compressedPageSize;
				page = 1;
				colorArea.BackColor = Color.Transparent;
				useCountCloudCheckBox.Enabled = true;
			}
			else
			{
				start = 0;
				pageSize = limit = uncompressedPageSize;
				page = 1;
				colorArea.BackColor = Color.WhiteSmoke;
				useCountCloudCheckBox.Enabled = false;
			}
			resetMaximumValueOfPagingControl();
			pageNumber.Value = 1;
			layoutColors();
		}

		private void resetMaximumValueOfPagingControl()
		{
			pageNumber.Maximum = (colorsInPalette.Count - 1) / pageSize + 1;
		}

		private void pageNumberNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			start = ((int)pageNumber.Value - 1) * pageSize;
			limit = pageSize;
			page = (int)pageNumber.Value;
			layoutColors();
		}

		private void useCountCloudCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			layoutColors();
		}
	}
}
