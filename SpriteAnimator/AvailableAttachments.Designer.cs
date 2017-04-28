namespace SpriteAnimator
{
	partial class AvailableAttachments
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvailableAttachments));
			this.namedAttachmentPointComboBox = new System.Windows.Forms.ComboBox();
			this.addImageButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.mainAreaTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.messageLabel = new System.Windows.Forms.Label();
			this.rowTargetTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.imageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.mainAreaTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// namedAttachmentPointComboBox
			// 
			this.namedAttachmentPointComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.namedAttachmentPointComboBox.Enabled = false;
			this.namedAttachmentPointComboBox.FormattingEnabled = true;
			this.namedAttachmentPointComboBox.Location = new System.Drawing.Point(6, 8);
			this.namedAttachmentPointComboBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 3);
			this.namedAttachmentPointComboBox.Name = "namedAttachmentPointComboBox";
			this.namedAttachmentPointComboBox.Size = new System.Drawing.Size(314, 21);
			this.namedAttachmentPointComboBox.Sorted = true;
			this.namedAttachmentPointComboBox.TabIndex = 1;
			// 
			// addImageButton
			// 
			this.addImageButton.Enabled = false;
			this.addImageButton.Location = new System.Drawing.Point(332, 6);
			this.addImageButton.Margin = new System.Windows.Forms.Padding(6);
			this.addImageButton.Name = "addImageButton";
			this.addImageButton.Size = new System.Drawing.Size(75, 23);
			this.addImageButton.TabIndex = 2;
			this.addImageButton.Text = "Add Image";
			this.addImageButton.UseVisualStyleBackColor = true;
			this.addImageButton.Click += new System.EventHandler(this.addImageButton_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.namedAttachmentPointComboBox, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.addImageButton, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(413, 35);
			this.tableLayoutPanel1.TabIndex = 28;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.mainAreaTableLayoutPanel);
			this.panel1.Location = new System.Drawing.Point(0, 32);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(413, 276);
			this.panel1.TabIndex = 29;
			// 
			// mainAreaTableLayoutPanel
			// 
			this.mainAreaTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mainAreaTableLayoutPanel.AutoScroll = true;
			this.mainAreaTableLayoutPanel.ColumnCount = 1;
			this.mainAreaTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainAreaTableLayoutPanel.Controls.Add(this.messageLabel, 0, 1);
			this.mainAreaTableLayoutPanel.Controls.Add(this.rowTargetTableLayoutPanel, 0, 0);
			this.mainAreaTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.mainAreaTableLayoutPanel.Name = "mainAreaTableLayoutPanel";
			this.mainAreaTableLayoutPanel.RowCount = 2;
			this.mainAreaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainAreaTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainAreaTableLayoutPanel.Size = new System.Drawing.Size(413, 277);
			this.mainAreaTableLayoutPanel.TabIndex = 31;
			// 
			// messageLabel
			// 
			this.messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.messageLabel.AutoSize = true;
			this.messageLabel.Enabled = false;
			this.messageLabel.Location = new System.Drawing.Point(3, 4);
			this.messageLabel.Name = "messageLabel";
			this.messageLabel.Size = new System.Drawing.Size(407, 273);
			this.messageLabel.TabIndex = 0;
			this.messageLabel.Text = "No named attachment points available.";
			this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// rowTargetTableLayoutPanel
			// 
			this.rowTargetTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rowTargetTableLayoutPanel.AutoSize = true;
			this.rowTargetTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.rowTargetTableLayoutPanel.ColumnCount = 1;
			this.rowTargetTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.rowTargetTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.rowTargetTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.rowTargetTableLayoutPanel.Name = "rowTargetTableLayoutPanel";
			this.rowTargetTableLayoutPanel.RowCount = 1;
			this.rowTargetTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.rowTargetTableLayoutPanel.Size = new System.Drawing.Size(410, 4);
			this.rowTargetTableLayoutPanel.TabIndex = 30;
			this.rowTargetTableLayoutPanel.Visible = false;
			// 
			// imageOpenFileDialog
			// 
			this.imageOpenFileDialog.Filter = "Images (*.bmp, *.png)|*.bmp;*.png";
			// 
			// AvailableAttachments
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(413, 310);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AvailableAttachments";
			this.Text = "Available Attachments";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AvailableAttachments_FormClosing);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.mainAreaTableLayoutPanel.ResumeLayout(false);
			this.mainAreaTableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox namedAttachmentPointComboBox;
		private System.Windows.Forms.Button addImageButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel rowTargetTableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel mainAreaTableLayoutPanel;
		private System.Windows.Forms.Label messageLabel;
		private System.Windows.Forms.OpenFileDialog imageOpenFileDialog;
	}
}