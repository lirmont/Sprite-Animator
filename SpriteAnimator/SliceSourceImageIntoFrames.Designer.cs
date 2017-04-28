namespace SpriteAnimator
{
	partial class SliceSourceImageIntoFrames
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.ignoreEmptFramesCheckBox = new System.Windows.Forms.CheckBox();
			this.autoCompositeCheckBox = new System.Windows.Forms.CheckBox();
			this.rowsMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.columnsMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.dimensionsLabel = new System.Windows.Forms.Label();
			this.buttonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.sliceButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			this.tableLayoutPanel.SuspendLayout();
			this.buttonsTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(37, 13);
			label1.TabIndex = 0;
			label1.Text = "Rows:";
			// 
			// label2
			// 
			label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 32);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(50, 13);
			label2.TabIndex = 1;
			label2.Text = "Columns:";
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(label1, 0, 0);
			this.tableLayoutPanel.Controls.Add(label2, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.ignoreEmptFramesCheckBox, 0, 3);
			this.tableLayoutPanel.Controls.Add(this.autoCompositeCheckBox, 0, 4);
			this.tableLayoutPanel.Controls.Add(this.rowsMaskedTextBox, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.columnsMaskedTextBox, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.dimensionsLabel, 1, 2);
			this.tableLayoutPanel.Controls.Add(this.buttonsTableLayoutPanel, 0, 6);
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 7;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(227, 167);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// ignoreEmptFramesCheckBox
			// 
			this.ignoreEmptFramesCheckBox.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.ignoreEmptFramesCheckBox, 2);
			this.ignoreEmptFramesCheckBox.Location = new System.Drawing.Point(3, 68);
			this.ignoreEmptFramesCheckBox.Name = "ignoreEmptFramesCheckBox";
			this.ignoreEmptFramesCheckBox.Size = new System.Drawing.Size(125, 17);
			this.ignoreEmptFramesCheckBox.TabIndex = 2;
			this.ignoreEmptFramesCheckBox.Text = "Ignore Empty Frames";
			this.ignoreEmptFramesCheckBox.UseVisualStyleBackColor = true;
			// 
			// autoCompositeCheckBox
			// 
			this.autoCompositeCheckBox.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.autoCompositeCheckBox, 2);
			this.autoCompositeCheckBox.Location = new System.Drawing.Point(3, 91);
			this.autoCompositeCheckBox.Name = "autoCompositeCheckBox";
			this.autoCompositeCheckBox.Size = new System.Drawing.Size(177, 17);
			this.autoCompositeCheckBox.TabIndex = 3;
			this.autoCompositeCheckBox.Text = "Automatically Composite Frames";
			this.autoCompositeCheckBox.UseVisualStyleBackColor = true;
			// 
			// rowsMaskedTextBox
			// 
			this.rowsMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rowsMaskedTextBox.Ceiling = 99999D;
			this.rowsMaskedTextBox.Floor = 1D;
			this.rowsMaskedTextBox.IsNumeric = true;
			this.rowsMaskedTextBox.Location = new System.Drawing.Point(59, 3);
			this.rowsMaskedTextBox.MarkInvalid = false;
			this.rowsMaskedTextBox.Name = "rowsMaskedTextBox";
			this.rowsMaskedTextBox.Size = new System.Drawing.Size(165, 20);
			this.rowsMaskedTextBox.TabIndex = 4;
			this.rowsMaskedTextBox.Text = "10";
			this.rowsMaskedTextBox.TextChanged += new System.EventHandler(this.rowsMaskedTextBox_TextChanged);
			// 
			// columnsMaskedTextBox
			// 
			this.columnsMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.columnsMaskedTextBox.Ceiling = 99999D;
			this.columnsMaskedTextBox.Floor = 1D;
			this.columnsMaskedTextBox.IsNumeric = true;
			this.columnsMaskedTextBox.Location = new System.Drawing.Point(59, 29);
			this.columnsMaskedTextBox.MarkInvalid = false;
			this.columnsMaskedTextBox.Name = "columnsMaskedTextBox";
			this.columnsMaskedTextBox.Size = new System.Drawing.Size(165, 20);
			this.columnsMaskedTextBox.TabIndex = 5;
			this.columnsMaskedTextBox.Text = "10";
			this.columnsMaskedTextBox.TextChanged += new System.EventHandler(this.columnsMaskedTextBox_TextChanged);
			// 
			// dimensionsLabel
			// 
			this.dimensionsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.dimensionsLabel.AutoSize = true;
			this.dimensionsLabel.Location = new System.Drawing.Point(59, 52);
			this.dimensionsLabel.Name = "dimensionsLabel";
			this.dimensionsLabel.Size = new System.Drawing.Size(40, 13);
			this.dimensionsLabel.TabIndex = 6;
			this.dimensionsLabel.Text = "XxY px";
			// 
			// buttonsTableLayoutPanel
			// 
			this.buttonsTableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonsTableLayoutPanel.AutoSize = true;
			this.buttonsTableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.SetColumnSpan(this.buttonsTableLayoutPanel, 2);
			this.buttonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.buttonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.buttonsTableLayoutPanel.Controls.Add(this.sliceButton, 0, 0);
			this.buttonsTableLayoutPanel.Controls.Add(this.cancelButton, 1, 0);
			this.buttonsTableLayoutPanel.Location = new System.Drawing.Point(32, 135);
			this.buttonsTableLayoutPanel.Name = "buttonsTableLayoutPanel";
			this.buttonsTableLayoutPanel.RowCount = 1;
			this.buttonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.buttonsTableLayoutPanel.Size = new System.Drawing.Size(162, 29);
			this.buttonsTableLayoutPanel.TabIndex = 7;
			// 
			// sliceButton
			// 
			this.sliceButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.sliceButton.Location = new System.Drawing.Point(3, 3);
			this.sliceButton.Name = "sliceButton";
			this.sliceButton.Size = new System.Drawing.Size(75, 23);
			this.sliceButton.TabIndex = 0;
			this.sliceButton.Text = "Slice";
			this.sliceButton.UseVisualStyleBackColor = true;
			this.sliceButton.Click += new System.EventHandler(this.sliceButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(84, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// SliceSourceImageIntoFrames
			// 
			this.AcceptButton = this.sliceButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(228, 168);
			this.Controls.Add(this.tableLayoutPanel);
			this.Name = "SliceSourceImageIntoFrames";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Slice Source Image Into Frames";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.buttonsTableLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.CheckBox ignoreEmptFramesCheckBox;
		private System.Windows.Forms.CheckBox autoCompositeCheckBox;
		private MaskedTextBox rowsMaskedTextBox;
		private MaskedTextBox columnsMaskedTextBox;
		private System.Windows.Forms.Label dimensionsLabel;
		private System.Windows.Forms.TableLayoutPanel buttonsTableLayoutPanel;
		private System.Windows.Forms.Button sliceButton;
		private System.Windows.Forms.Button cancelButton;
	}
}