using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SpriteAnimator
{
	public partial class AddOrEditCompositeFrameSet : Form
	{
		public string SetName
		{
			get { return nameMaskedTextBox.Text; }
			set { nameMaskedTextBox.Text = value; }
		}

		public int? TargetMS
		{
			get { return int.Parse(targetMSMaskedTextBox.Text); }
			set { targetMSMaskedTextBox.Text = value.ToString(); }
		}

		public Shapes.CompositeFrameSet CompositeFrameSet
		{
			get { return new Shapes.CompositeFrameSet(name: SetName, targetMS: TargetMS, compositeFrameCalls: CompositeFrameCalls); }
			private set { }
		}

		public List<Shapes.CompositeFrameCall> CompositeFrameCalls
		{
			get
			{
				List<Shapes.CompositeFrameCall> currentList = new List<Shapes.CompositeFrameCall>();
				foreach (ListViewItem item in compositeFramesListView.Items)
				{
					string eventName = (item.SubItems.Count > 1 && item.SubItems[1].Text != "") ? item.SubItems[1].Text : null;
					currentList.Add(new Shapes.CompositeFrameCall(id: item.SubItems[0].Text, eventName: eventName));
				}
				return currentList;
			}
			set
			{
				compositeFramesListView.Items.Clear();
				foreach (Shapes.CompositeFrameCall call in value)
				{
					compositeFramesListView.Items.Add(
						new ListViewItem(new string[] {
							call.id, call.eventName
						}, (ListViewGroup)null)
					);
				}
			}
		}

		public AddOrEditCompositeFrameSet(List<Shapes.CompositeFrame> availableCompositeFrames)
		{
			InitializeComponent();
			// In-line editing for the list view.
			TxtEdit = new TextBox();
			TxtEdit.BorderStyle = BorderStyle.None;
			TxtEdit.Visible = false;
			TxtEdit.KeyUp += TxtEdit_KeyUp;
			TxtEdit.Leave += TxtEdit_Leave;
			this.Controls.Add(TxtEdit);
			// Frame calls.
			SupportFunctions.ComposeNumericallyGroupedContextMenus(
				availableCompositeFrames.ToArray(),
				compositeFrameGroupsContextMenuStrip,
				delegate(object sender, EventArgs e)
				{
					ToolStripItem item = (ToolStripItem)sender;
					Shapes.CompositeFrame delegateCompositeFrame = item.Tag as Shapes.CompositeFrame;
					if (compositeFramesListView.Items.Count > 0 && (Control.ModifierKeys & Keys.Control) != 0)
					{
						// Attempt to step from last value to current if CTRL is held down.
						int lastCompositeFrameCall = 0;
						if (int.TryParse(compositeFramesListView.Items[compositeFramesListView.Items.Count - 1].SubItems[0].Text, out lastCompositeFrameCall))
						{
							int thisCompositeFrameCall = int.Parse(delegateCompositeFrame.id);
							if (lastCompositeFrameCall < thisCompositeFrameCall)
							{
								for (int i = lastCompositeFrameCall + 1; i <= thisCompositeFrameCall; i++)
									compositeFramesListView.Items.Add(i.ToString());
							}
							else if (lastCompositeFrameCall > thisCompositeFrameCall)
								for (int i = lastCompositeFrameCall - 1; i >= thisCompositeFrameCall; i--)
									compositeFramesListView.Items.Add(i.ToString());
							else
								compositeFramesListView.Items.Add(delegateCompositeFrame.id.ToString());
						} else
							compositeFramesListView.Items.Add(delegateCompositeFrame.id.ToString());
					}
					else
						compositeFramesListView.Items.Add(delegateCompositeFrame.id.ToString());
				}
			); 
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

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			moveCompositeFrameUpToolStripMenuItem.Enabled = (compositeFramesListView.SelectedItems.Count > 0 && compositeFramesListView.SelectedIndices[0] > 0) ? true : false;
			moveCompositeFrameDownToolStripMenuItem.Enabled = (compositeFramesListView.SelectedItems.Count > 0 && compositeFramesListView.SelectedIndices[0] < compositeFramesListView.Items.Count - 1) ? true : false;
			removeCompositeFrameToolStripMenuItem.Enabled = (compositeFramesListView.SelectedItems.Count > 0) ? true : false;
		}

		private void moveCompositeFrameUpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int startIndex = compositeFramesListView.SelectedIndices[0];
			int endIndex = startIndex - 1;
			ListViewItem start = compositeFramesListView.Items[endIndex];
			ListViewItem end = compositeFramesListView.Items[startIndex];
			compositeFramesListView.Items[startIndex] = new ListViewItem("");
			compositeFramesListView.Items[endIndex] = end;
			compositeFramesListView.Items[startIndex] = start;
		}

		private void moveCompositeFrameDownToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int startIndex = compositeFramesListView.SelectedIndices[0];
			int endIndex = startIndex + 1;
			ListViewItem start = compositeFramesListView.Items[endIndex];
			ListViewItem end = compositeFramesListView.Items[startIndex];
			compositeFramesListView.Items[startIndex] = new ListViewItem("");
			compositeFramesListView.Items[endIndex] = end;
			compositeFramesListView.Items[startIndex] = start;
		}

		private void removeCompositeFrameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int startIndex = compositeFramesListView.SelectedIndices[0];
			compositeFramesListView.Items[startIndex].Remove();
		}

		private void AddOrEditCompositeFrameSet_Shown(object sender, EventArgs e)
		{
			nameLabel.Focus();
		}

		#region In-place editing.
		TextBox TxtEdit;
		ListViewItem.ListViewSubItem SelectedLSI;
		private void genericListView_MouseUp(object sender, MouseEventArgs e)
		{
			ListView genericListView = (ListView)sender;
			ListViewHitTestInfo i = genericListView.HitTest(e.X, e.Y);
			SelectedLSI = i.SubItem;
			if (SelectedLSI == null)
				return;
			// Make-shift border style.
			int border = 0;
			switch (genericListView.BorderStyle)
			{
				case BorderStyle.FixedSingle:
					border = 1;
					break;
				case BorderStyle.Fixed3D:
					border = 2;
					break;
			}
			// Sizing.
			int CellWidth = SelectedLSI.Bounds.Width - border * 2;
			int CellHeight = SelectedLSI.Bounds.Height;
			int CellLeft = border * 2 + genericListView.Left + i.SubItem.Bounds.Left;
			int CellTop = border + genericListView.Top + i.SubItem.Bounds.Top;
			// First Column
			if (i.SubItem == i.Item.SubItems[0])
				CellWidth = genericListView.Columns[0].Width;
			// Property updates.
			TxtEdit.Location = new Point(CellLeft, CellTop);
			TxtEdit.Size = new Size(CellWidth, CellHeight);
			TxtEdit.Visible = true;
			TxtEdit.BringToFront();
			TxtEdit.Text = i.SubItem.Text;
			TxtEdit.Select();
			TxtEdit.SelectAll();
		}

		private void genericListView_MouseDown(object sender, MouseEventArgs e)
		{
			HideTextEditor();
		}

		private void TxtEdit_Leave(object sender, EventArgs e)
		{
			HideTextEditor();
		}

		private void TxtEdit_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
				HideTextEditor();
		}

		private void HideTextEditor()
		{
			TxtEdit.Visible = false;
			if (SelectedLSI != null)
				SelectedLSI.Text = TxtEdit.Text;
			SelectedLSI = null;
			TxtEdit.Text = "";
		}
		#endregion
	}
}