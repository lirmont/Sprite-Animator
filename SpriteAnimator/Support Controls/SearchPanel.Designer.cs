namespace SearchControls
{
	partial class SearchPanel
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.containerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.updateButton = new System.Windows.Forms.Button();
			this.lineSeparator = new SearchControls.LineSeparator();
			this.searchLabel = new System.Windows.Forms.Label();
			this.searchMaskedTextBox = new SearchControls.MaskedTextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.categoryContainerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.containerTableLayoutPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// containerTableLayoutPanel
			// 
			this.containerTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.containerTableLayoutPanel.ColumnCount = 2;
			this.containerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.containerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.containerTableLayoutPanel.Controls.Add(this.updateButton, 0, 3);
			this.containerTableLayoutPanel.Controls.Add(this.lineSeparator, 0, 1);
			this.containerTableLayoutPanel.Controls.Add(this.searchLabel, 0, 0);
			this.containerTableLayoutPanel.Controls.Add(this.searchMaskedTextBox, 1, 0);
			this.containerTableLayoutPanel.Controls.Add(this.panel1, 0, 2);
			this.containerTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.containerTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.containerTableLayoutPanel.Name = "containerTableLayoutPanel";
			this.containerTableLayoutPanel.RowCount = 4;
			this.containerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.containerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.containerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.containerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.containerTableLayoutPanel.Size = new System.Drawing.Size(175, 150);
			this.containerTableLayoutPanel.TabIndex = 0;
			// 
			// updateButton
			// 
			this.updateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.containerTableLayoutPanel.SetColumnSpan(this.updateButton, 2);
			this.updateButton.Location = new System.Drawing.Point(50, 124);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(75, 23);
			this.updateButton.TabIndex = 4;
			this.updateButton.Text = "Update";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// lineSeparator
			// 
			this.lineSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lineSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.containerTableLayoutPanel.SetColumnSpan(this.lineSeparator, 2);
			this.lineSeparator.Location = new System.Drawing.Point(3, 23);
			this.lineSeparator.Margin = new System.Windows.Forms.Padding(3);
			this.lineSeparator.MaximumSize = new System.Drawing.Size(2147483647, 2);
			this.lineSeparator.MinimumSize = new System.Drawing.Size(1, 2);
			this.lineSeparator.Name = "lineSeparator";
			this.lineSeparator.Size = new System.Drawing.Size(169, 2);
			this.lineSeparator.TabIndex = 0;
			// 
			// searchLabel
			// 
			this.searchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.searchLabel.AutoSize = true;
			this.searchLabel.Location = new System.Drawing.Point(3, 0);
			this.searchLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
			this.searchLabel.Name = "searchLabel";
			this.searchLabel.Size = new System.Drawing.Size(44, 18);
			this.searchLabel.TabIndex = 1;
			this.searchLabel.Text = "Search:";
			this.searchLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// searchMaskedTextBox
			// 
			this.searchMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.searchMaskedTextBox.EmptyText = "Title to search for.";
			this.searchMaskedTextBox.Location = new System.Drawing.Point(53, 0);
			this.searchMaskedTextBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.searchMaskedTextBox.MarkInvalid = false;
			this.searchMaskedTextBox.Name = "searchMaskedTextBox";
			this.searchMaskedTextBox.Size = new System.Drawing.Size(119, 20);
			this.searchMaskedTextBox.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.containerTableLayoutPanel.SetColumnSpan(this.panel1, 2);
			this.panel1.Controls.Add(this.categoryContainerTableLayoutPanel);
			this.panel1.Location = new System.Drawing.Point(3, 31);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(169, 87);
			this.panel1.TabIndex = 5;
			// 
			// categoryContainerTableLayoutPanel
			// 
			this.categoryContainerTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.categoryContainerTableLayoutPanel.AutoSize = true;
			this.categoryContainerTableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
			this.categoryContainerTableLayoutPanel.ColumnCount = 2;
			this.categoryContainerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.categoryContainerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.categoryContainerTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.categoryContainerTableLayoutPanel.Name = "categoryContainerTableLayoutPanel";
			this.categoryContainerTableLayoutPanel.RowCount = 1;
			this.categoryContainerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.categoryContainerTableLayoutPanel.Size = new System.Drawing.Size(169, 0);
			this.categoryContainerTableLayoutPanel.TabIndex = 4;
			// 
			// SearchPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.containerTableLayoutPanel);
			this.Name = "SearchPanel";
			this.Size = new System.Drawing.Size(175, 150);
			this.containerTableLayoutPanel.ResumeLayout(false);
			this.containerTableLayoutPanel.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel containerTableLayoutPanel;
		private System.Windows.Forms.Label searchLabel;
		private MaskedTextBox searchMaskedTextBox;
		private LineSeparator lineSeparator;
		private System.Windows.Forms.Button updateButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel categoryContainerTableLayoutPanel;
	}
}
