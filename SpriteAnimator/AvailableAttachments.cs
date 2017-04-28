using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SpriteAnimator
{
	public partial class AvailableAttachments : Form
	{
		private Main parent = null;

		public AvailableAttachments(Main m)
		{
			this.parent = m;
			InitializeComponent();
			//
			rowTargetTableLayoutPanel.RowCount = 0;
			//
			namedAttachmentPointComboBox.DisplayMember = "PointName";
			namedAttachmentPointComboBox.ValueMember = "ID";
			//
			UpdateComboBox();
		}

		// Thread-safe update data source method.
		public void UpdateDataSource(AvailableAttachments a)
		{
			if (a != null && !a.Disposing && !a.IsDisposed)
			{
				a.Invoke((MethodInvoker)delegate
				{
					a.UpdateComboBox();
				});
			}
		}

		private void UpdateComboBox()
		{
			namedAttachmentPointComboBox.Items.Clear();
			if (this.parent.Format != null && this.parent.Format.AvailableNamedAttachmentPointsList.Count > 0)
			{
				messageLabel.Visible = false;
				namedAttachmentPointComboBox.Enabled = true;
				addImageButton.Enabled = true;
				foreach (Shapes.NamedAttachmentPoint point in this.parent.Format.AvailableNamedAttachmentPointsList)
					namedAttachmentPointComboBox.Items.Add(point);
				//
				namedAttachmentPointComboBox.SelectedIndex = 0;
			}
			else
			{
				messageLabel.Visible = true;
				rowTargetTableLayoutPanel.Visible = false;
				namedAttachmentPointComboBox.Enabled = false;
				addImageButton.Enabled = false;
				rowTargetTableLayoutPanel.Controls.Clear();
			}
		}

		private void addNamedAttachmentPointEntryGivenId(int id)
		{
			Shapes.NamedAttachmentPoint point = this.parent.Format.AvailableNamedAttachmentPointsList.Find(item => item.id == id);
			if (point != null)
			{
				// Create table layout: 3x1
				TableLayoutPanel panel = new TableLayoutPanel();
				panel.Tag = point;
				panel.AutoSize = true;
				panel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
				panel.RowCount = 1;
				panel.ColumnCount = 4;
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
				panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
				panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				//
				Button eye = new Button();
				eye.Image = (Image)global::SpriteAnimator.Properties.Resources.ResourceManager.GetObject("eye");
				eye.Anchor = AnchorStyles.None;
				eye.AutoSize = true;
				eye.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
				eye.FlatStyle = FlatStyle.Flat;
				eye.FlatAppearance.BorderSize = 0;
				eye.FlatAppearance.MouseOverBackColor = Color.Transparent;
				eye.FlatAppearance.MouseDownBackColor = Color.Transparent;
				eye.Click += new EventHandler(eye_Click);
				//
				PictureBox image = new PictureBox();
				if (this.parent.namedAttachments[id].IsPlaceholder)
				{
					image.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
					image.BorderStyle = BorderStyle.FixedSingle;
					image.SizeMode = PictureBoxSizeMode.Normal;
				}
				else
				{
					image.Anchor = AnchorStyles.None;
					image.BorderStyle = BorderStyle.None;
					image.SizeMode = PictureBoxSizeMode.AutoSize;
					image.Image = this.parent.namedAttachments[id].SignificantBitmap;
				}
				image.Margin = new Padding(6, 3, 6, 3);
				image.Click += new EventHandler(image_Click);
				//
				Label nameString = new Label();
				nameString.AutoSize = true;
				nameString.Text = string.Format("{0} (ID: {1})", new object[] { point.name, point.id });
				nameString.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
				nameString.TextAlign = ContentAlignment.MiddleLeft;
				//
				Button cancel = new Button();
				cancel.Image = (Image)global::SpriteAnimator.Properties.Resources.ResourceManager.GetObject("cancel");
				cancel.Anchor = AnchorStyles.None;
				cancel.AutoSize = false;
				cancel.FlatStyle = FlatStyle.Flat;
				cancel.FlatAppearance.BorderSize = 0;
				cancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
				cancel.FlatAppearance.MouseDownBackColor = Color.Transparent;
				cancel.Tag = point;
				cancel.Click += new EventHandler(cancel_Click);
				//
				panel.Controls.Add(eye, 0, 0);
				panel.Controls.Add(image, 1, 0);
				panel.Controls.Add(nameString, 2, 0);
				panel.Controls.Add(cancel, 3, 0);
				//
				rowTargetTableLayoutPanel.Controls.Add(panel);
			}
			rowTargetTableLayoutPanel.Visible = true;
		}

		void cancel_Click(object sender, EventArgs e)
		{
			BackgroundWorker deleteEntryBackgroundThread = new BackgroundWorker();
			deleteEntryBackgroundThread.DoWork += new DoWorkEventHandler(deleteEntryBackgroundThread_DoWork);
			deleteEntryBackgroundThread.RunWorkerAsync(new object[] {this, sender});
		}

		void deleteEntryBackgroundThread_DoWork(object sender, DoWorkEventArgs e)
		{
			object[] objects = e.Argument as object[];
			AvailableAttachments m = objects[0] as AvailableAttachments;
			Button thisButton = objects[1] as Button;
			Shapes.NamedAttachmentPoint point = (Shapes.NamedAttachmentPoint)thisButton.Parent.Tag;
			m.Invoke((MethodInvoker)delegate
			{
				// Remove row.
				rowTargetTableLayoutPanel.Controls.Remove(thisButton.Parent);
			});
			// Replace bitmap with a blank image; signal reload of appropriate frames.
			m.parent.loadImageAsNamedAttachment(id: point.id, bitmap: null, m: m.parent, reloadCompositeFrames: true);
		}

		void image_Click(object sender, EventArgs e)
		{
			PictureBox thisPictureBox = (PictureBox)sender;
			// Get initial directory.
			if (Properties.Settings.Default.namedAttachmentDirectory != "")
				imageOpenFileDialog.InitialDirectory = Properties.Settings.Default.namedAttachmentDirectory;
			//
			DialogResult result = imageOpenFileDialog.ShowDialog();
			String fileName = null;
			if (result == System.Windows.Forms.DialogResult.OK)
			{
				Properties.Settings.Default.namedAttachmentDirectory = System.IO.Path.GetDirectoryName(imageOpenFileDialog.FileName);
				Properties.Settings.Default.Save();
				fileName = imageOpenFileDialog.FileName;
			}
			//
			if (fileName != null)
			{
				BackgroundWorker updatePictureBoxBackgroundThread = new BackgroundWorker();
				updatePictureBoxBackgroundThread.DoWork += new DoWorkEventHandler(updatePictureBoxBackgroundThread_HandleClick);
				updatePictureBoxBackgroundThread.RunWorkerAsync(new object[] { this, thisPictureBox, fileName.ToString() });
			}
		}

		void updatePictureBoxBackgroundThread_HandleClick(object sender, DoWorkEventArgs e)
		{
			object[] objects = e.Argument as object[];
			HandleImageClick(objects[0] as AvailableAttachments, objects[1] as PictureBox, objects[2] as string);
		}

		// Thread-Safe
		private void HandleImageClick(AvailableAttachments m, PictureBox thisPictureBox, string fileName)
		{
			Shapes.NamedAttachmentPoint point = (Shapes.NamedAttachmentPoint)thisPictureBox.Parent.Tag;
			SupportClasses.ImageDescription thisDescription = m.parent.namedAttachments[point.id];
			// Replace bitmap with a blank image; signal reload of appropriate frames.
			m.parent.loadImageAsNamedAttachment(id: point.id, bitmap: new Bitmap(fileName), m: m.parent, reloadCompositeFrames: true);
			// Show the stored image.
			m.Invoke((MethodInvoker)delegate
			{
				thisPictureBox.Anchor = AnchorStyles.None;
				thisPictureBox.BorderStyle = BorderStyle.None;
				thisPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
				thisPictureBox.Image = m.parent.namedAttachments[point.id].SignificantBitmap;
			});
		}

		void eye_Click(object sender, EventArgs e)
		{
			BackgroundWorker hideOrShowEyeBackgroundThread = new BackgroundWorker();
			hideOrShowEyeBackgroundThread.DoWork += new DoWorkEventHandler(hideOrShowEyeBackgroundThread_DoWork);
			hideOrShowEyeBackgroundThread.RunWorkerAsync(new object[] { this, sender });
		}

		void hideOrShowEyeBackgroundThread_DoWork(object sender, DoWorkEventArgs e)
		{
			object[] objects = e.Argument as object[];
			AvailableAttachments m = objects[0] as AvailableAttachments;
			Button thisButton = objects[1] as Button;
			Shapes.NamedAttachmentPoint point = (Shapes.NamedAttachmentPoint)thisButton.Parent.Tag;
			m.Invoke((MethodInvoker)delegate
			{
				if (point.hidden)
				{
					thisButton.Image = (Image)global::SpriteAnimator.Properties.Resources.ResourceManager.GetObject("eye");
					point.hidden = false;
				}
				else
				{
					thisButton.Image = (Image)global::SpriteAnimator.Properties.Resources.ResourceManager.GetObject("closed_eye");
					point.hidden = true;
				}
			});
			// Signal reload of appropriate frames.
			m.parent.reloadCompositeFramesWithTheGivenNamedAttachmentPointId(point.id);
		}

		private void addImageButton_Click(object sender, EventArgs e)
		{
			if (namedAttachmentPointComboBox.SelectedItem != null)
			{
				Shapes.NamedAttachmentPoint point = (Shapes.NamedAttachmentPoint)namedAttachmentPointComboBox.SelectedItem;
				addNamedAttachmentPointEntryGivenId(point.id);
			}
		}

		private void AvailableAttachments_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Hide rather than close.
			this.Hide();
			e.Cancel = true;
		}
	}
}
