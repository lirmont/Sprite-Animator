using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpriteAnimator
{
	public partial class CopyRangeOfCompositeFrames : Form
	{
		public int CopyFromFrame
		{
			get { return (int)copyFromIndex.Value; }
			set { copyFromIndex.Value = value; }
		}

		public int ToFrame
		{
			get { return (int)copyToIndex.Value; }
			set { copyToIndex.Value = value; }
		}

		public int PlaceAtIndex
		{
			get { return (int)placeAtIndex.Value; }
			set { placeAtIndex.Value = value; }
		}

		public bool GenerateMirroredSets
		{
			get { return mirrorNamedSetsCheckBox.Checked; }
			set { mirrorNamedSetsCheckBox.Checked = value; }
		}

		public List<RegularExpressionReplacement> Rewrites
		{
			get {
				List<RegularExpressionReplacement> replacements = new List<RegularExpressionReplacement>();
				if (rewritesListView.Items.Count > 0)
					foreach (ListViewItem item in rewritesListView.Items)
						replacements.Add(item.Tag as RegularExpressionReplacement);
				//
				return replacements;
			}
		}

		public CopyRangeOfCompositeFrames()
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

		private void addRewriteRuleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormRegex dlg = new FormRegex();
			if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				addNewRewriteToListView(dlg.ReplacementRegex);
		}

		private void addNewRewriteToListView(RegularExpressionReplacement newReplacement)
		{
			// Add to list view.
			ListViewItem item = new ListViewItem(new string[] { 
				newReplacement.RegularExpression, newReplacement.ReplacementText
			});
			item.Tag = newReplacement;
			rewritesListView.Items.Add(item);
		}

		private void editRewriteRuleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ListViewItem selected = rewritesListView.SelectedItems[0];
			RegularExpressionReplacement replacement = selected.Tag as RegularExpressionReplacement;
			FormRegex dlg = new FormRegex(replacement);
			if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				addNewRewriteToListView(dlg.ReplacementRegex);
		}

		private void deleteRewriteRuleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SupportFunctions.RemoveSelectedListViewItems(rewritesListView);
		}

		private void rewriteContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			bool haveSelection = (rewritesListView.SelectedIndices.Count > 0) ? true : false;
			editRewriteRuleToolStripMenuItem.Enabled = haveSelection;
			deleteRewriteRuleToolStripMenuItem.Enabled = haveSelection;
		}

		private void rewritesListView_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					deleteRewriteRuleToolStripMenuItem_Click(sender, (EventArgs)e);
					break;
			}
		}

		private void mirrorNamedSetsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox box = sender as CheckBox;
			if (box != null)
				rewritesListView.Enabled = box.Checked;
		}
	}
}