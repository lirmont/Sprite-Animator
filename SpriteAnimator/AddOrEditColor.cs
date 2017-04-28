using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpriteAnimator
{
	public partial class AddOrEditColor : Form
	{
		public AddOrEditColor()
		{
			InitializeComponent();
			colorDialog = new ColorControl.ColorControl();
		}

		public ColorControl.ColorControl colorDialog = null;
		private void colorSwatchPanel_Click(object sender, EventArgs e)
		{
			if (colorDialog == null)
				colorDialog = new ColorControl.ColorControl();
			//
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				colorSwatchPanel.BackColor = colorDialog.Color;
			}
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			bool thisResult = nameTextBox.validate();
			if (!thisResult)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void AddOrEditColor_Shown(object sender, EventArgs e)
		{
			nameLabel.Focus();
		}
	}
}
