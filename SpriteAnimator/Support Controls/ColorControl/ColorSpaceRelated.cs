using System.Windows.Forms;
using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace ColorControl {
	public partial class ColorControl : Form
	{
		//
		double hueDegree = 0.001;
		double valueZeroToOne = 1, saturationZeroToOne = 1;

		// HSV components (active color space).
		public double HueDegree
		{
			get { return hueDegree; }
			set
			{
				hueDegree = value;
				updateColorSpaceComponents();
			}
		}

		public double SaturationZeroToOne
		{
			get { return saturationZeroToOne; }
			set
			{
				saturationZeroToOne = value;
				updateColorSpaceComponents();
			}
		}

		public double ValueZeroToOne
		{
			get { return valueZeroToOne; }
			set
			{
				valueZeroToOne = value;
				updateColorSpaceComponents();
			}
		}

		// Convenience accessors.
		public double ReverseValueZeroToOne
		{
			get { return 1 - valueZeroToOne; }
			set
			{
				valueZeroToOne = 1 - value;
				colorDisplayPanel.BackColor = Color;
			}
		}

		// Utility methods.
		private void setPickedColorByColor(object color, bool doNotIgnoreType = false)
		{
			Type type = color.GetType();
			HSV? hsv = null;
			if (type == typeof(System.Drawing.Color))
			{
				hsv = new RGB((System.Drawing.Color)color);
				doNotIgnoreType = true;
			}
			else if (type == typeof(RGB))
				hsv = (RGB)color;
			else if (type == typeof(HSV))
				hsv = (HSV)color;
			else if (type == typeof(CIEXYZ))
				hsv = (CIEXYZ)color;
			else if (type == typeof(CIELab))
				hsv = (CIELab)color;
			//
			if (hsv != null)
			{
				ignoreTextChanges = true;
				{
					HueDegree = hsv.Value.Hue;
					SaturationZeroToOne = hsv.Value.Saturation;
					ValueZeroToOne = hsv.Value.Value;
				}
				ignoreTextChanges = false;
				updateColorSpaceComponents(ignore: (!doNotIgnoreType) ? type : null);
			}
		}

		private void updateColorDifference()
		{
			if (PreviousColor != null)
			{
				float difference = SupportFunctions.ColorDifference(new RGB(PreviousColor.Value), new RGB(colorDisplayPanel.BackColor));
				colorDifferenceValueLabel.Text = string.Format("{0:##0.00}%", difference);
			}
		}

		private void updateColorSpaceComponents(Type ignore = null)
		{
			if (!ignoreTextChanges)
			{
				HSV hsv = new HSV(HueDegree, SaturationZeroToOne, ValueZeroToOne);
				RGB rgb = hsv;
				CIEXYZ xyz = hsv;
				CIELab Lab = hsv;
				ignoreTextChanges = true;
				{
					if (ignore != typeof(HSV))
					{
						hueMaskedTextBox.Text = Math.Floor(hsv.Hue).ToString();
						saturationMaskedTextBox.Text = Math.Round(hsv.Saturation * 100).ToString();
						valueMaskedTextBox.Text = Math.Round(hsv.Value * 100).ToString();
					}
					//
					if (ignore != typeof(RGB))
					{
						rValueMaskedTextBox.Text = rgb.Red.ToString();
						gValueMaskedTextBox.Text = rgb.Green.ToString();
						bValueMaskedTextBox.Text = rgb.Blue.ToString();
					}
					//
					if (ignore != typeof(CIEXYZ))
					{
						xValueMaskedTextBox.Text = xyz.X.ToString();
						yValueMaskedTextBox.Text = xyz.Y.ToString();
						zValueMaskedTextBox.Text = xyz.Z.ToString();
					}
					//
					if (ignore != typeof(CIELab))
					{
						LMaskedTextBox.Text = Lab.L.ToString();
						aMaskedTextBox.Text = Lab.A.ToString();
						bMaskedTextBox.Text = Lab.B.ToString();
					}
				}
				ignoreTextChanges = false;
				colorDisplayPanel.BackColor = Color;
			}
		}

		#region Show/Hide Color Space Menu Item Click handlers.
		private void hsvToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (hsvToolStripMenuItem.Checked)
				recalculatePrimaryTableLayout();
			hsvTableLayoutPanel.Visible = hsvToolStripMenuItem.Checked;
			if (!hsvToolStripMenuItem.Checked)
				recalculatePrimaryTableLayout();
		}

		private void rgbToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (rgbToolStripMenuItem.Checked)
				recalculatePrimaryTableLayout();
			rgbTableLayoutPanel.Visible = rgbToolStripMenuItem.Checked;
			if (!rgbToolStripMenuItem.Checked)
				recalculatePrimaryTableLayout();
		}

		private void xyzToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (xyzToolStripMenuItem.Checked)
				recalculatePrimaryTableLayout();
			xyzTableLayoutPanel.Visible = xyzToolStripMenuItem.Checked;
			if (!xyzToolStripMenuItem.Checked)
				recalculatePrimaryTableLayout();
		}

		private void labToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (labToolStripMenuItem.Checked)
				recalculatePrimaryTableLayout();
			labTableLayoutPanel.Visible = labToolStripMenuItem.Checked;
			if (!labToolStripMenuItem.Checked)
				recalculatePrimaryTableLayout();
		}

		private void recalculatePrimaryTableLayout()
		{
			int width = buttonsPanel.Width + buttonsPanel.Margin.Horizontal + buttonsPanel.Parent.Margin.Horizontal + buttonsPanel.Parent.Padding.Horizontal;
			int widthOfShownComponents = colorSpaceAndOptionsTableLayoutPanel.Margin.Horizontal + colorSpaceAndOptionsTableLayoutPanel.Padding.Horizontal;
			int checkedCount = 0;
			foreach (object[] set in new List<object[]> { 
				new object[] { hsvToolStripMenuItem, hsvTableLayoutPanel },
				new object[] { rgbToolStripMenuItem, rgbTableLayoutPanel },
				new object[] { xyzToolStripMenuItem, xyzTableLayoutPanel },
				new object[] { labToolStripMenuItem, labTableLayoutPanel }
			})
			{
				ToolStripMenuItem menuItem = set[0] as ToolStripMenuItem;
				Control control = set[1] as TableLayoutPanel;
				widthOfShownComponents += (menuItem.Checked) ? control.Width + control.Margin.Horizontal + control.Parent.Margin.Horizontal + control.Parent.Padding.Horizontal : 0;
				checkedCount += (menuItem.Checked) ? 1 : 0;
			}
			widthOfShownComponents += (checkedCount >= 2) ? 20 : 0;
			int finalWidth = Math.Max(width, widthOfShownComponents);
			int delta = finalWidth - (int)Math.Ceiling(primaryTableLayoutPanel.ColumnStyles[1].Width);
			//
			if (delta != 0)
			{
				primaryTableLayoutPanel.ColumnStyles[1].Width = finalWidth;
				this.Width += delta;
			}
		}
		#endregion

		#region Component Validating and TextChanged handlers.
		private void genericPercentMaskedTextBox_Validating(object sender, CancelEventArgs e)
		{
			if (!ignoreTextChanges)
			{
				MaskedTextBox control = sender as MaskedTextBox;
				int percentAsWholeNumber = 0;
				bool parsed = int.TryParse(control.Text, out percentAsWholeNumber);
				e.Cancel = !(parsed && percentAsWholeNumber <= 100 && 0 <= percentAsWholeNumber) ? true : false;
			}
		}

		private void hueTextBox_Validating(object sender, CancelEventArgs e)
		{
			if (!ignoreTextChanges)
			{
				MaskedTextBox control = sender as MaskedTextBox;
				double degree0To360 = 0;
				bool parsed = double.TryParse(control.Text, out degree0To360);
				e.Cancel = !(parsed && degree0To360 < 360 && 0 <= degree0To360) ? true : false;
			}
		}

		private void genericRGBComponentMaskedTextBox_Validating(object sender, CancelEventArgs e)
		{
			if (!ignoreTextChanges)
			{
				MaskedTextBox control = sender as MaskedTextBox;
				int component = 0;
				bool parsed = int.TryParse(control.Text, out component);
				e.Cancel = !(parsed && component < 256 && 0 <= component) ? true : false;
			}
		}

		private void genericXYZComponentMaskedTextBox_Validating(object sender, CancelEventArgs e)
		{
			if (!ignoreTextChanges)
			{
				MaskedTextBox control = sender as MaskedTextBox;
				double component = 0;
				bool parsed = double.TryParse(control.Text, out component);
				e.Cancel = !(parsed && component <= 1 && 0 <= component) ? true : false;
			}
		}

		private void LMaskedTextBox_Validating(object sender, CancelEventArgs e)
		{
			if (!ignoreTextChanges)
			{
				MaskedTextBox control = sender as MaskedTextBox;
				double component = 0;
				bool parsed = double.TryParse(control.Text, out component);
				e.Cancel = !(parsed && component <= 100 && 0 <= component) ? true : false;
			}
		}

		private void genericLabComponentMaskedTextBox_Validating(object sender, CancelEventArgs e)
		{
			if (!ignoreTextChanges)
			{
				MaskedTextBox control = sender as MaskedTextBox;
				double component = 0;
				bool parsed = double.TryParse(control.Text, out component);
				e.Cancel = !(parsed && component <= 127 && -128 <= component) ? true : false;
			}
		}

		private void hueTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!ignoreTextChanges)
			{
				MaskedTextBox control = sender as MaskedTextBox;
				double degree = 0;
				bool parsed = double.TryParse(control.Text, out degree);
				degree = SupportFunctions.Clamp<double>(degree, 0.001, 359.999);
				if (parsed)
					HueDegree = degree;
			}
		}

		private void saturationTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!ignoreTextChanges)
			{
				MaskedTextBox control = sender as MaskedTextBox;
				double saturation = 0;
				bool parsed = double.TryParse(control.Text, out saturation);
				if (parsed)
					SaturationZeroToOne = saturation / 100.0;
			}
		}

		private void valueTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!ignoreTextChanges)
			{
				MaskedTextBox control = sender as MaskedTextBox;
				double value = 0;
				bool parsed = double.TryParse(control.Text, out value);
				if (parsed)
					ValueZeroToOne = value / 100.0;
			}
		}

		private void genericRGBComponentMaskedTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!ignoreTextChanges)
			{
				int r = 0, g = 0, b = 0;
				List<bool> parsed = new List<bool> {
					int.TryParse(rValueMaskedTextBox.Text, out r),
					int.TryParse(gValueMaskedTextBox.Text, out g),
					int.TryParse(bValueMaskedTextBox.Text, out b)
				};
				if (parsed.TrueForAll(item => item == true))
					setPickedColorByColor(new RGB(r, g, b));
			}
		}

		private void genericXYZComponentMaskedTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!ignoreTextChanges)
			{
				double x = 0, y = 0, z = 0;
				List<bool> parsed = new List<bool> {
					double.TryParse(xValueMaskedTextBox.Text, out x),
					double.TryParse(yValueMaskedTextBox.Text, out y),
					double.TryParse(zValueMaskedTextBox.Text, out z)
				};
				if (parsed.TrueForAll(item => item == true))
					setPickedColorByColor(new CIEXYZ(x, y, z));
			}
		}

		private void genericLabMaskedTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!ignoreTextChanges)
			{
				double L = 0, a = 0, b = 0;
				List<bool> parsed = new List<bool> {
					double.TryParse(LMaskedTextBox.Text, out L),
					double.TryParse(aMaskedTextBox.Text, out a),
					double.TryParse(bMaskedTextBox.Text, out b)
				};
				if (parsed.TrueForAll(item => item == true))
					setPickedColorByColor(new CIELab(L, a, b));
			}
		}
		#endregion
	}
}