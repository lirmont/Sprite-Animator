using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SpriteAnimator
{
	public partial class SliceSourceImageIntoFrames : Form
	{
		private string sourceImageFilename;
		private Size sourceImageDimensions = new Size(1, 1);

		public string SourceImageFilename
		{
			get { return sourceImageFilename; }
			set { sourceImageFilename = value; }
		}

		public Size SourceImageDimensions
		{
			get { return sourceImageDimensions; }
			set { sourceImageDimensions = value; }
		}

		public int Rows {
			get
			{
				int test = 0;
				int.TryParse(rowsMaskedTextBox.Text, out test);
				return test;
			}
		}

		public int Columns {
			get
			{
				int test = 0;
				int.TryParse(columnsMaskedTextBox.Text, out test);
				return test;
			}
		}

		public int StepX {
			get {
				return (int)Math.Round(FloatingStepX);
			}
		}

		public int StepY {
			get {
				return (int)Math.Round(FloatingStepY);
			}
		}

		public float FloatingStepX
		{
			get
			{
				return sourceImageDimensions.Width / (float)Columns;
			}
		}

		public float FloatingStepY
		{
			get
			{
				return sourceImageDimensions.Height / (float)Rows;
			}
		}

		public bool IgnoreEmptyFrames { get { return ignoreEmptFramesCheckBox.Checked; } }
		public bool AutomaticallyCompositeFrames { get { return autoCompositeCheckBox.Checked; } }

		public SliceSourceImageIntoFrames(string sourceImageFilename)
		{
			this.sourceImageFilename = sourceImageFilename;
			//
			InitializeComponent();
			//
			if (File.Exists(SourceImageFilename))
				using (Bitmap b = new Bitmap(SourceImageFilename))
					sourceImageDimensions = new Size(b.Width, b.Height);
			//
			synchronizeDimensionsLabel();
		}

		private void synchronizeDimensionsLabel()
		{
			dimensionsLabel.Text = string.Format("{0}x{1} px", new object[] { FloatingStepX, FloatingStepY });
		}

		private void sliceButton_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void rowsMaskedTextBox_TextChanged(object sender, EventArgs e)
		{
			synchronizeDimensionsLabel();
		}

		private void columnsMaskedTextBox_TextChanged(object sender, EventArgs e)
		{
			synchronizeDimensionsLabel();
		}
	}
}
