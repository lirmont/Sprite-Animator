using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpriteAnimator
{
	public partial class FlipRangeOfCompositeFrames : Form
	{
		public int StartFrame
		{
			get
			{
				return (int)startFrame.Value;
			}
			set
			{
				startFrame.Value = value;
			}
		}

		public int EndFrame
		{
			get
			{
				return (int)endFrame.Value;
			}
			set
			{
				endFrame.Value = value;
			}
		}

		public bool FlipOrder
		{
			get
			{
				return flipOrderCheckbox.Checked;
			}
			set
			{
				flipOrderCheckbox.Checked = value;
			}
		}

		public FlipRangeOfCompositeFrames()
		{
			InitializeComponent();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}