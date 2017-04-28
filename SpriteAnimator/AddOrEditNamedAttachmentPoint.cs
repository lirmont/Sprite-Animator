using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpriteAnimator
{
	public partial class AddOrEditNamedAttachmentPoint : Form
	{
		public int Id
		{
			get {
				int value = 0;
				int.TryParse(idMaskedTextBox.Text, out value);
				return value; 
			}
			set { idMaskedTextBox.Text = value.ToString(); }
		}

		public string AttachmentPointName
		{
			get { return nameMaskedTextBox.Text; }
			set { nameMaskedTextBox.Text = value; }
		}

		public string Description
		{
			get { return descriptionTextBox.Text; }
			set { descriptionTextBox.Text = value; }
		}

		public double X
		{
			get { return double.Parse(xAttachmentMaskedTextBox.Text); }
			set { xAttachmentMaskedTextBox.Text = value.ToString(); }
		}

		public double Y
		{
			get { return double.Parse(yAttachmentMaskedTextBox.Text); }
			set { yAttachmentMaskedTextBox.Text = value.ToString(); }
		}
		
		public AddOrEditNamedAttachmentPoint()
		{
			InitializeComponent();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void AddOrEditNamedAttachmentPoint_Shown(object sender, EventArgs e)
		{
			idLabel.Focus();
		}
	}
}
