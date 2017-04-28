namespace SpriteAnimator
{
	partial class AddOrEditCompositeFrameSet
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.nameLabel = new System.Windows.Forms.Label();
			this.nameMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.framesLabel = new System.Windows.Forms.Label();
			this.compositeFramesListView = new System.Windows.Forms.ListView();
			this.frameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.emitEventColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.compositeFrameManipulationContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addCompositeFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.compositeFrameGroupsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.moveCompositeFrameUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveCompositeFrameDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeCompositeFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.targetMSLabel = new System.Windows.Forms.Label();
			this.targetMSMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.compositeFrameManipulationContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.nameLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.nameMaskedTextBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.framesLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.compositeFramesListView, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.saveButton, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.cancelButton, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.targetMSLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.targetMSMaskedTextBox, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 184);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// nameLabel
			// 
			this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(3, 3);
			this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(66, 26);
			this.nameLabel.TabIndex = 0;
			this.nameLabel.Text = "Name:";
			this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nameMaskedTextBox
			// 
			this.nameMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.nameMaskedTextBox, 2);
			this.nameMaskedTextBox.EmptyText = "Enter the name of the composite frame set.";
			this.nameMaskedTextBox.Location = new System.Drawing.Point(72, 6);
			this.nameMaskedTextBox.MarkInvalid = false;
			this.nameMaskedTextBox.Name = "nameMaskedTextBox";
			this.nameMaskedTextBox.Size = new System.Drawing.Size(311, 20);
			this.nameMaskedTextBox.TabIndex = 1;
			// 
			// framesLabel
			// 
			this.framesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.framesLabel.AutoSize = true;
			this.framesLabel.Location = new System.Drawing.Point(6, 58);
			this.framesLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.framesLabel.Name = "framesLabel";
			this.framesLabel.Size = new System.Drawing.Size(60, 95);
			this.framesLabel.TabIndex = 4;
			this.framesLabel.Text = "Frames:";
			this.framesLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// compositeFramesListView
			// 
			this.compositeFramesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.compositeFramesListView.AutoArrange = false;
			this.compositeFramesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.frameColumnHeader,
            this.emitEventColumnHeader});
			this.tableLayoutPanel1.SetColumnSpan(this.compositeFramesListView, 2);
			this.compositeFramesListView.ContextMenuStrip = this.compositeFrameManipulationContextMenuStrip;
			this.compositeFramesListView.FullRowSelect = true;
			this.compositeFramesListView.GridLines = true;
			this.compositeFramesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.compositeFramesListView.Location = new System.Drawing.Point(72, 58);
			this.compositeFramesListView.Name = "compositeFramesListView";
			this.compositeFramesListView.ShowGroups = false;
			this.compositeFramesListView.Size = new System.Drawing.Size(311, 92);
			this.compositeFramesListView.TabIndex = 5;
			this.compositeFramesListView.UseCompatibleStateImageBehavior = false;
			this.compositeFramesListView.View = System.Windows.Forms.View.Details;
			this.compositeFramesListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.genericListView_MouseDown);
			this.compositeFramesListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.genericListView_MouseUp);
			// 
			// frameColumnHeader
			// 
			this.frameColumnHeader.Text = "id";
			this.frameColumnHeader.Width = 59;
			// 
			// emitEventColumnHeader
			// 
			this.emitEventColumnHeader.Text = "emit-event";
			this.emitEventColumnHeader.Width = 220;
			// 
			// compositeFrameManipulationContextMenuStrip
			// 
			this.compositeFrameManipulationContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCompositeFrameToolStripMenuItem,
            this.moveCompositeFrameUpToolStripMenuItem,
            this.moveCompositeFrameDownToolStripMenuItem,
            this.removeCompositeFrameToolStripMenuItem});
			this.compositeFrameManipulationContextMenuStrip.Name = "contextMenuStrip1";
			this.compositeFrameManipulationContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.compositeFrameManipulationContextMenuStrip.Size = new System.Drawing.Size(217, 92);
			this.compositeFrameManipulationContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			// 
			// addCompositeFrameToolStripMenuItem
			// 
			this.addCompositeFrameToolStripMenuItem.DropDown = this.compositeFrameGroupsContextMenuStrip;
			this.addCompositeFrameToolStripMenuItem.Name = "addCompositeFrameToolStripMenuItem";
			this.addCompositeFrameToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.addCompositeFrameToolStripMenuItem.Text = "Add Composite Frame";
			// 
			// compositeFrameGroupsContextMenuStrip
			// 
			this.compositeFrameGroupsContextMenuStrip.Name = "contextMenuStrip2";
			this.compositeFrameGroupsContextMenuStrip.OwnerItem = this.addCompositeFrameToolStripMenuItem;
			this.compositeFrameGroupsContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.compositeFrameGroupsContextMenuStrip.Size = new System.Drawing.Size(61, 4);
			// 
			// moveCompositeFrameUpToolStripMenuItem
			// 
			this.moveCompositeFrameUpToolStripMenuItem.Enabled = false;
			this.moveCompositeFrameUpToolStripMenuItem.Name = "moveCompositeFrameUpToolStripMenuItem";
			this.moveCompositeFrameUpToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.moveCompositeFrameUpToolStripMenuItem.Text = "Move Composite Frame Up";
			this.moveCompositeFrameUpToolStripMenuItem.Click += new System.EventHandler(this.moveCompositeFrameUpToolStripMenuItem_Click);
			// 
			// moveCompositeFrameDownToolStripMenuItem
			// 
			this.moveCompositeFrameDownToolStripMenuItem.Enabled = false;
			this.moveCompositeFrameDownToolStripMenuItem.Name = "moveCompositeFrameDownToolStripMenuItem";
			this.moveCompositeFrameDownToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.moveCompositeFrameDownToolStripMenuItem.Text = "Move Composite Frame Down";
			this.moveCompositeFrameDownToolStripMenuItem.Click += new System.EventHandler(this.moveCompositeFrameDownToolStripMenuItem_Click);
			// 
			// removeCompositeFrameToolStripMenuItem
			// 
			this.removeCompositeFrameToolStripMenuItem.Enabled = false;
			this.removeCompositeFrameToolStripMenuItem.Name = "removeCompositeFrameToolStripMenuItem";
			this.removeCompositeFrameToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.removeCompositeFrameToolStripMenuItem.Text = "Remove Composite Frame";
			this.removeCompositeFrameToolStripMenuItem.Click += new System.EventHandler(this.removeCompositeFrameToolStripMenuItem_Click);
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(149, 156);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 22);
			this.saveButton.TabIndex = 6;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(230, 156);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 22);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// targetMSLabel
			// 
			this.targetMSLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.targetMSLabel.AutoSize = true;
			this.targetMSLabel.Location = new System.Drawing.Point(6, 29);
			this.targetMSLabel.Name = "targetMSLabel";
			this.targetMSLabel.Size = new System.Drawing.Size(60, 26);
			this.targetMSLabel.TabIndex = 2;
			this.targetMSLabel.Text = "Target MS:";
			this.targetMSLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// targetMSMaskedTextBox
			// 
			this.targetMSMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.targetMSMaskedTextBox.Ceiling = 99999D;
			this.tableLayoutPanel1.SetColumnSpan(this.targetMSMaskedTextBox, 2);
			this.targetMSMaskedTextBox.EmptyText = "Milliseconds between drawing operations.";
			this.targetMSMaskedTextBox.Increment = 10D;
			this.targetMSMaskedTextBox.Interval = 0.1D;
			this.targetMSMaskedTextBox.IsNumeric = true;
			this.targetMSMaskedTextBox.Location = new System.Drawing.Point(72, 32);
			this.targetMSMaskedTextBox.MarkInvalid = false;
			this.targetMSMaskedTextBox.Name = "targetMSMaskedTextBox";
			this.targetMSMaskedTextBox.Size = new System.Drawing.Size(311, 20);
			this.targetMSMaskedTextBox.TabIndex = 3;
			// 
			// AddOrEditCompositeFrameSet
			// 
			this.AcceptButton = this.saveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(390, 186);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(296, 213);
			this.Name = "AddOrEditCompositeFrameSet";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add or Edit Composite Frame Set";
			this.Shown += new System.EventHandler(this.AddOrEditCompositeFrameSet_Shown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.compositeFrameManipulationContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label nameLabel;
		private MaskedTextBox nameMaskedTextBox;
		private System.Windows.Forms.Label framesLabel;
		private System.Windows.Forms.ListView compositeFramesListView;
		private System.Windows.Forms.ColumnHeader frameColumnHeader;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.ContextMenuStrip compositeFrameManipulationContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem addCompositeFrameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveCompositeFrameUpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveCompositeFrameDownToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeCompositeFrameToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip compositeFrameGroupsContextMenuStrip;
		private System.Windows.Forms.Label targetMSLabel;
		private MaskedTextBox targetMSMaskedTextBox;
		private System.Windows.Forms.ColumnHeader emitEventColumnHeader;
	}
}