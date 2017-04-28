using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpriteAnimator
{
	public partial class AddOrEditSound : Form
	{
		private string soundName = "", colorName = "", filename = "";

		public string Filename
		{
			get { return maskedTextBox3.Text; }
			set { maskedTextBox3.Text = filename = value; }
		}

		public string ColorName
		{
			get { return maskedTextBox2.Text; }
			set { maskedTextBox2.Text = colorName = value; }
		}

		public string SoundName
		{
			get { return maskedTextBox1.Text; }
			set { maskedTextBox1.Text = soundName = value; }
		}

		public AddOrEditSound()
		{
			InitializeComponent();
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

		private void button3_Click(object sender, EventArgs e)
		{
			DialogResult d = openFileDialog1.ShowDialog(this);
			if (d == DialogResult.OK)
				maskedTextBox3.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);
		}
	}
}
