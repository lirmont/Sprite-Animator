namespace SpriteAnimator
{
    partial class Palette
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Palette));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.pagingControlsPanel = new System.Windows.Forms.Panel();
			this.pageLabel = new System.Windows.Forms.Label();
			this.pageNumber = new System.Windows.Forms.NumericUpDown();
			this.useCountCloudCheckBox = new System.Windows.Forms.CheckBox();
			this.compressViewCheckBox = new System.Windows.Forms.CheckBox();
			this.spacerLabel = new System.Windows.Forms.Label();
			this.colorAreaContainer = new System.Windows.Forms.Panel();
			this.colorArea = new System.Windows.Forms.Panel();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.pagingControlsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pageNumber)).BeginInit();
			this.colorAreaContainer.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.colorAreaContainer);
			this.splitContainer1.Size = new System.Drawing.Size(384, 254);
			this.splitContainer1.SplitterDistance = 40;
			this.splitContainer1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.pagingControlsPanel, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.useCountCloudCheckBox, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.compressViewCheckBox, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.spacerLabel, 2, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(382, 40);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(382, 40);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// pagingControlsPanel
			// 
			this.pagingControlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pagingControlsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pagingControlsPanel.Controls.Add(this.pageLabel);
			this.pagingControlsPanel.Controls.Add(this.pageNumber);
			this.pagingControlsPanel.Location = new System.Drawing.Point(264, 3);
			this.pagingControlsPanel.Name = "pagingControlsPanel";
			this.pagingControlsPanel.Size = new System.Drawing.Size(115, 34);
			this.pagingControlsPanel.TabIndex = 8;
			// 
			// pageLabel
			// 
			this.pageLabel.AutoSize = true;
			this.pageLabel.Location = new System.Drawing.Point(8, 8);
			this.pageLabel.Name = "pageLabel";
			this.pageLabel.Size = new System.Drawing.Size(35, 13);
			this.pageLabel.TabIndex = 3;
			this.pageLabel.Text = "Page:";
			// 
			// pageNumber
			// 
			this.pageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pageNumber.AutoSize = true;
			this.pageNumber.Location = new System.Drawing.Point(52, 5);
			this.pageNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.pageNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.pageNumber.Name = "pageNumber";
			this.pageNumber.Size = new System.Drawing.Size(60, 20);
			this.pageNumber.TabIndex = 2;
			this.pageNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.pageNumber.ValueChanged += new System.EventHandler(this.pageNumberNumericUpDown_ValueChanged);
			// 
			// useCountCloudCheckBox
			// 
			this.useCountCloudCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.useCountCloudCheckBox.AutoSize = true;
			this.useCountCloudCheckBox.Location = new System.Drawing.Point(107, 9);
			this.useCountCloudCheckBox.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
			this.useCountCloudCheckBox.Name = "useCountCloudCheckBox";
			this.useCountCloudCheckBox.Size = new System.Drawing.Size(144, 17);
			this.useCountCloudCheckBox.TabIndex = 6;
			this.useCountCloudCheckBox.Text = "Use Count for Size Cloud";
			this.useCountCloudCheckBox.UseVisualStyleBackColor = true;
			this.useCountCloudCheckBox.CheckedChanged += new System.EventHandler(this.useCountCloudCheckBox_CheckedChanged);
			// 
			// compressViewCheckBox
			// 
			this.compressViewCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.compressViewCheckBox.AutoSize = true;
			this.compressViewCheckBox.Checked = true;
			this.compressViewCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.compressViewCheckBox.Location = new System.Drawing.Point(3, 9);
			this.compressViewCheckBox.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
			this.compressViewCheckBox.Name = "compressViewCheckBox";
			this.compressViewCheckBox.Size = new System.Drawing.Size(98, 17);
			this.compressViewCheckBox.TabIndex = 2;
			this.compressViewCheckBox.Text = "Compress View";
			this.compressViewCheckBox.UseVisualStyleBackColor = true;
			this.compressViewCheckBox.CheckedChanged += new System.EventHandler(this.compressView_CheckedChanged);
			// 
			// spacerLabel
			// 
			this.spacerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.spacerLabel.Location = new System.Drawing.Point(257, 3);
			this.spacerLabel.Margin = new System.Windows.Forms.Padding(3);
			this.spacerLabel.Name = "spacerLabel";
			this.spacerLabel.Size = new System.Drawing.Size(1, 34);
			this.spacerLabel.TabIndex = 9;
			// 
			// colorAreaContainer
			// 
			this.colorAreaContainer.AutoScroll = true;
			this.colorAreaContainer.AutoScrollMinSize = new System.Drawing.Size(150, 25);
			this.colorAreaContainer.AutoSize = true;
			this.colorAreaContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.colorAreaContainer.Controls.Add(this.colorArea);
			this.colorAreaContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.colorAreaContainer.Location = new System.Drawing.Point(0, 0);
			this.colorAreaContainer.MinimumSize = new System.Drawing.Size(150, 25);
			this.colorAreaContainer.Name = "colorAreaContainer";
			this.colorAreaContainer.Size = new System.Drawing.Size(384, 210);
			this.colorAreaContainer.TabIndex = 0;
			// 
			// colorArea
			// 
			this.colorArea.AutoScroll = true;
			this.colorArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.colorArea.Location = new System.Drawing.Point(0, 0);
			this.colorArea.Margin = new System.Windows.Forms.Padding(0);
			this.colorArea.Name = "colorArea";
			this.colorArea.Size = new System.Drawing.Size(384, 210);
			this.colorArea.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.statusStrip);
			this.splitContainer2.Panel2MinSize = 22;
			this.splitContainer2.Size = new System.Drawing.Size(384, 283);
			this.splitContainer2.SplitterDistance = 254;
			this.splitContainer2.TabIndex = 1;
			// 
			// statusStrip
			// 
			this.statusStrip.Dock = System.Windows.Forms.DockStyle.Top;
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 0);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(384, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
			this.toolStripStatusLabel.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(369, 14);
			this.toolStripStatusLabel.Spring = true;
			this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Palette
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 283);
			this.Controls.Add(this.splitContainer2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(392, 125);
			this.Name = "Palette";
			this.Text = "Constructed Palette";
			this.Resize += new System.EventHandler(this.Palette_Resize);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.pagingControlsPanel.ResumeLayout(false);
			this.pagingControlsPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pageNumber)).EndInit();
			this.colorAreaContainer.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			this.splitContainer2.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel colorAreaContainer;
        private System.Windows.Forms.Panel colorArea;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel pagingControlsPanel;
		private System.Windows.Forms.Label pageLabel;
		private System.Windows.Forms.NumericUpDown pageNumber;
		private System.Windows.Forms.CheckBox useCountCloudCheckBox;
		private System.Windows.Forms.CheckBox compressViewCheckBox;
		private System.Windows.Forms.Label spacerLabel;
    }
}