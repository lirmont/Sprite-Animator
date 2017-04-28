namespace SpriteAnimator
{
    partial class AddOrEditColor
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
			this.nameTextBox = new SpriteAnimator.MaskedTextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.colorLabel = new System.Windows.Forms.Label();
			this.colorSwatchPanel = new System.Windows.Forms.Panel();
			this.buttonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.opacityLabel = new System.Windows.Forms.Label();
			this.opacityTrackBar = new System.Windows.Forms.TrackBar();
			this.buttonTableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// nameTextBox
			// 
			this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.nameTextBox.EmptyText = "Name of the color to be used as a reference on frames and tweens.";
			this.nameTextBox.Interval = 0D;
			this.nameTextBox.Location = new System.Drawing.Point(56, 8);
			this.nameTextBox.MarkInvalid = false;
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(334, 20);
			this.nameTextBox.TabIndex = 0;
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(8, 11);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(38, 13);
			this.nameLabel.TabIndex = 1;
			this.nameLabel.Text = "Name:";
			this.nameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// colorLabel
			// 
			this.colorLabel.AutoSize = true;
			this.colorLabel.Location = new System.Drawing.Point(12, 37);
			this.colorLabel.Name = "colorLabel";
			this.colorLabel.Size = new System.Drawing.Size(34, 13);
			this.colorLabel.TabIndex = 2;
			this.colorLabel.Text = "Color:";
			this.colorLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// colorSwatchPanel
			// 
			this.colorSwatchPanel.BackColor = System.Drawing.Color.White;
			this.colorSwatchPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.colorSwatchPanel.Location = new System.Drawing.Point(56, 36);
			this.colorSwatchPanel.Name = "colorSwatchPanel";
			this.colorSwatchPanel.Size = new System.Drawing.Size(16, 16);
			this.colorSwatchPanel.TabIndex = 3;
			this.colorSwatchPanel.Click += new System.EventHandler(this.colorSwatchPanel_Click);
			// 
			// buttonTableLayoutPanel
			// 
			this.buttonTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
			this.buttonTableLayoutPanel.ColumnCount = 2;
			this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.buttonTableLayoutPanel.Controls.Add(this.saveButton, 0, 0);
			this.buttonTableLayoutPanel.Controls.Add(this.cancelButton, 1, 0);
			this.buttonTableLayoutPanel.Location = new System.Drawing.Point(8, 98);
			this.buttonTableLayoutPanel.Name = "buttonTableLayoutPanel";
			this.buttonTableLayoutPanel.RowCount = 1;
			this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.buttonTableLayoutPanel.Size = new System.Drawing.Size(386, 31);
			this.buttonTableLayoutPanel.TabIndex = 4;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(115, 3);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 25);
			this.saveButton.TabIndex = 0;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(196, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 25);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// opacityLabel
			// 
			this.opacityLabel.AutoSize = true;
			this.opacityLabel.Location = new System.Drawing.Point(0, 62);
			this.opacityLabel.Name = "opacityLabel";
			this.opacityLabel.Size = new System.Drawing.Size(46, 13);
			this.opacityLabel.TabIndex = 5;
			this.opacityLabel.Text = "Opacity:";
			this.opacityLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// opacityTrackBar
			// 
			this.opacityTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.opacityTrackBar.Location = new System.Drawing.Point(56, 56);
			this.opacityTrackBar.Maximum = 100;
			this.opacityTrackBar.Name = "opacityTrackBar";
			this.opacityTrackBar.Size = new System.Drawing.Size(333, 45);
			this.opacityTrackBar.TabIndex = 7;
			this.opacityTrackBar.TickFrequency = 5;
			this.opacityTrackBar.Value = 100;
			// 
			// AddOrEditColor
			// 
			this.AcceptButton = this.saveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(398, 132);
			this.Controls.Add(this.opacityTrackBar);
			this.Controls.Add(this.opacityLabel);
			this.Controls.Add(this.buttonTableLayoutPanel);
			this.Controls.Add(this.colorSwatchPanel);
			this.Controls.Add(this.colorLabel);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.nameTextBox);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(406, 159);
			this.Name = "AddOrEditColor";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add or Edit Color";
			this.Shown += new System.EventHandler(this.AddOrEditColor_Shown);
			this.buttonTableLayoutPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.TableLayoutPanel buttonTableLayoutPanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        public SpriteAnimator.MaskedTextBox nameTextBox;
        public System.Windows.Forms.Panel colorSwatchPanel;
        private System.Windows.Forms.Label opacityLabel;
		public System.Windows.Forms.TrackBar opacityTrackBar;
    }
}