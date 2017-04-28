using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpriteAnimator
{
	public partial class SlideRangeOfCompositeFrames : Form
	{
		public int SlideFromFrame
		{
			get
			{
				return (int)slideFromIndex.Value;
			}
			set
			{
				slideFromIndex.Value = value;
			}
		}

		public int ToFrame
		{
			get
			{
				return (int)slideToIndex.Value;
			}
			set
			{
				slideToIndex.Value = value;
			}
		}

		public int SlideX
		{
			get
			{
				return (int)X.Value;
			}
			set
			{
				X.Value = value;
			}
		}

		public int SlideY
		{
			get
			{
				return (int)Y.Value;
			}
			set
			{
				Y.Value = value;
			}
		}

		public SlideRangeOfCompositeFrames()
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