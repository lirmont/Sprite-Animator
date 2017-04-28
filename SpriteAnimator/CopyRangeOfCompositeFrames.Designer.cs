namespace SpriteAnimator
{
	partial class CopyRangeOfCompositeFrames
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
			this.copyFromLabel = new System.Windows.Forms.Label();
			this.toLabel = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.placeAtLabel = new System.Windows.Forms.Label();
			this.copyFromIndex = new System.Windows.Forms.NumericUpDown();
			this.copyToIndex = new System.Windows.Forms.NumericUpDown();
			this.placeAtIndex = new System.Windows.Forms.NumericUpDown();
			this.mirrorNamedSetsCheckBox = new System.Windows.Forms.CheckBox();
			this.namedSetRewritesLabel = new System.Windows.Forms.Label();
			this.rewritesListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.rewriteContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addRewriteRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editRewriteRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteRewriteRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.copyFromIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.copyToIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.placeAtIndex)).BeginInit();
			this.rewriteContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.copyFromLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.toLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.saveButton, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.cancelButton, 2, 6);
			this.tableLayoutPanel1.Controls.Add(this.placeAtLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.copyFromIndex, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.copyToIndex, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.placeAtIndex, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.mirrorNamedSetsCheckBox, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.namedSetRewritesLabel, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.rewritesListView, 0, 5);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(388, 288);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// copyFromLabel
			// 
			this.copyFromLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.copyFromLabel.AutoSize = true;
			this.copyFromLabel.Location = new System.Drawing.Point(3, 0);
			this.copyFromLabel.Name = "copyFromLabel";
			this.copyFromLabel.Size = new System.Drawing.Size(91, 26);
			this.copyFromLabel.TabIndex = 2;
			this.copyFromLabel.Text = "Copy From:";
			this.copyFromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toLabel
			// 
			this.toLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.toLabel.AutoSize = true;
			this.toLabel.Location = new System.Drawing.Point(3, 26);
			this.toLabel.Name = "toLabel";
			this.toLabel.Size = new System.Drawing.Size(91, 26);
			this.toLabel.TabIndex = 3;
			this.toLabel.Text = "To:";
			this.toLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(129, 262);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(62, 23);
			this.saveButton.TabIndex = 0;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(197, 262);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(62, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// placeAtLabel
			// 
			this.placeAtLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.placeAtLabel.AutoSize = true;
			this.placeAtLabel.Location = new System.Drawing.Point(3, 52);
			this.placeAtLabel.Name = "placeAtLabel";
			this.placeAtLabel.Size = new System.Drawing.Size(91, 26);
			this.placeAtLabel.TabIndex = 4;
			this.placeAtLabel.Text = "Place At:";
			this.placeAtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// copyFromIndex
			// 
			this.copyFromIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.copyFromIndex, 3);
			this.copyFromIndex.Location = new System.Drawing.Point(100, 3);
			this.copyFromIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.copyFromIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.copyFromIndex.Name = "copyFromIndex";
			this.copyFromIndex.Size = new System.Drawing.Size(285, 20);
			this.copyFromIndex.TabIndex = 5;
			this.copyFromIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// copyToIndex
			// 
			this.copyToIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.copyToIndex, 3);
			this.copyToIndex.Location = new System.Drawing.Point(100, 29);
			this.copyToIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.copyToIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.copyToIndex.Name = "copyToIndex";
			this.copyToIndex.Size = new System.Drawing.Size(285, 20);
			this.copyToIndex.TabIndex = 6;
			this.copyToIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// placeAtIndex
			// 
			this.placeAtIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.placeAtIndex, 3);
			this.placeAtIndex.Location = new System.Drawing.Point(100, 55);
			this.placeAtIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.placeAtIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.placeAtIndex.Name = "placeAtIndex";
			this.placeAtIndex.Size = new System.Drawing.Size(285, 20);
			this.placeAtIndex.TabIndex = 7;
			this.placeAtIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// mirrorNamedSetsCheckBox
			// 
			this.mirrorNamedSetsCheckBox.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.mirrorNamedSetsCheckBox, 3);
			this.mirrorNamedSetsCheckBox.Location = new System.Drawing.Point(100, 81);
			this.mirrorNamedSetsCheckBox.Name = "mirrorNamedSetsCheckBox";
			this.mirrorNamedSetsCheckBox.Size = new System.Drawing.Size(172, 17);
			this.mirrorNamedSetsCheckBox.TabIndex = 8;
			this.mirrorNamedSetsCheckBox.Text = "Generate Mirrored Named Sets";
			this.mirrorNamedSetsCheckBox.UseVisualStyleBackColor = true;
			this.mirrorNamedSetsCheckBox.CheckedChanged += new System.EventHandler(this.mirrorNamedSetsCheckBox_CheckedChanged);
			// 
			// namedSetRewritesLabel
			// 
			this.namedSetRewritesLabel.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.namedSetRewritesLabel, 4);
			this.namedSetRewritesLabel.Location = new System.Drawing.Point(3, 101);
			this.namedSetRewritesLabel.Name = "namedSetRewritesLabel";
			this.namedSetRewritesLabel.Size = new System.Drawing.Size(104, 13);
			this.namedSetRewritesLabel.TabIndex = 9;
			this.namedSetRewritesLabel.Text = "Named Set Rewrites";
			// 
			// rewritesListView
			// 
			this.rewritesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rewritesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.tableLayoutPanel1.SetColumnSpan(this.rewritesListView, 4);
			this.rewritesListView.ContextMenuStrip = this.rewriteContextMenuStrip;
			this.rewritesListView.Enabled = false;
			this.rewritesListView.FullRowSelect = true;
			this.rewritesListView.GridLines = true;
			this.rewritesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.rewritesListView.Location = new System.Drawing.Point(3, 117);
			this.rewritesListView.Name = "rewritesListView";
			this.rewritesListView.Size = new System.Drawing.Size(382, 139);
			this.rewritesListView.TabIndex = 10;
			this.rewritesListView.UseCompatibleStateImageBehavior = false;
			this.rewritesListView.View = System.Windows.Forms.View.Details;
			this.rewritesListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rewritesListView_KeyDown);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Text to Rewrite";
			this.columnHeader1.Width = 115;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Replacement";
			this.columnHeader2.Width = 122;
			// 
			// rewriteContextMenuStrip
			// 
			this.rewriteContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRewriteRuleToolStripMenuItem,
            this.editRewriteRuleToolStripMenuItem,
            this.deleteRewriteRuleToolStripMenuItem});
			this.rewriteContextMenuStrip.Name = "rewriteContextMenuStrip";
			this.rewriteContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.rewriteContextMenuStrip.Size = new System.Drawing.Size(181, 70);
			this.rewriteContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.rewriteContextMenuStrip_Opening);
			// 
			// addRewriteRuleToolStripMenuItem
			// 
			this.addRewriteRuleToolStripMenuItem.Name = "addRewriteRuleToolStripMenuItem";
			this.addRewriteRuleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.addRewriteRuleToolStripMenuItem.Text = "Add Rewrite Rule";
			this.addRewriteRuleToolStripMenuItem.Click += new System.EventHandler(this.addRewriteRuleToolStripMenuItem_Click);
			// 
			// editRewriteRuleToolStripMenuItem
			// 
			this.editRewriteRuleToolStripMenuItem.Name = "editRewriteRuleToolStripMenuItem";
			this.editRewriteRuleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.editRewriteRuleToolStripMenuItem.Text = "Edit Rewrite Rule";
			this.editRewriteRuleToolStripMenuItem.Click += new System.EventHandler(this.editRewriteRuleToolStripMenuItem_Click);
			// 
			// deleteRewriteRuleToolStripMenuItem
			// 
			this.deleteRewriteRuleToolStripMenuItem.Name = "deleteRewriteRuleToolStripMenuItem";
			this.deleteRewriteRuleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.deleteRewriteRuleToolStripMenuItem.Text = "Delete Rewrite Rule";
			this.deleteRewriteRuleToolStripMenuItem.Click += new System.EventHandler(this.deleteRewriteRuleToolStripMenuItem_Click);
			// 
			// CopyRangeOfCompositeFrames
			// 
			this.AcceptButton = this.saveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(392, 291);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CopyRangeOfCompositeFrames";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Copy Range of Composite Frames";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.copyFromIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.copyToIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.placeAtIndex)).EndInit();
			this.rewriteContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label copyFromLabel;
		private System.Windows.Forms.Label toLabel;
		private System.Windows.Forms.Label placeAtLabel;
		private System.Windows.Forms.NumericUpDown copyFromIndex;
		private System.Windows.Forms.NumericUpDown copyToIndex;
		private System.Windows.Forms.NumericUpDown placeAtIndex;
		private System.Windows.Forms.CheckBox mirrorNamedSetsCheckBox;
		private System.Windows.Forms.Label namedSetRewritesLabel;
		private System.Windows.Forms.ListView rewritesListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ContextMenuStrip rewriteContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem addRewriteRuleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editRewriteRuleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteRewriteRuleToolStripMenuItem;
	}
}