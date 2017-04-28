using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpriteAnimator
{
	public partial class AddOrEditGuide : Form
	{
		public AddOrEditGuide()
		{
			InitializeComponent();
		}

		private void AddOrEditGuide_Shown(object sender, EventArgs e)
		{
			label1.Focus();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
