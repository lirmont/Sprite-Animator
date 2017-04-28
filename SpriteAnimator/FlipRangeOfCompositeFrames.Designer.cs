namespace SpriteAnimator
{
	partial class FlipRangeOfCompositeFrames
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.startFrameLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.startFrame = new System.Windows.Forms.NumericUpDown();
			this.endFrame = new System.Windows.Forms.NumericUpDown();
			this.flipOrderLabel = new System.Windows.Forms.Label();
			this.flipOrderCheckbox = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.startFrame)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.endFrame)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.saveButton, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.cancelButton, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.startFrameLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.startFrame, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.endFrame, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.flipOrderLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.flipOrderCheckbox, 1, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 102);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(73, 75);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(64, 23);
			this.saveButton.TabIndex = 0;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(143, 75);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(64, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// startFrameLabel
			// 
			this.startFrameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.startFrameLabel.AutoSize = true;
			this.startFrameLabel.Location = new System.Drawing.Point(3, 0);
			this.startFrameLabel.Name = "startFrameLabel";
			this.startFrameLabel.Size = new System.Drawing.Size(64, 24);
			this.startFrameLabel.TabIndex = 2;
			this.startFrameLabel.Text = "Start Frame:";
			this.startFrameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "End Frame:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// startFrame
			// 
			this.startFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.startFrame, 3);
			this.startFrame.Location = new System.Drawing.Point(73, 3);
			this.startFrame.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.startFrame.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.startFrame.Name = "startFrame";
			this.startFrame.Size = new System.Drawing.Size(204, 20);
			this.startFrame.TabIndex = 4;
			this.startFrame.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// endFrame
			// 
			this.endFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.endFrame, 3);
			this.endFrame.Location = new System.Drawing.Point(73, 27);
			this.endFrame.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.endFrame.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.endFrame.Name = "endFrame";
			this.endFrame.Size = new System.Drawing.Size(204, 20);
			this.endFrame.TabIndex = 5;
			this.endFrame.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// flipOrderLabel
			// 
			this.flipOrderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.flipOrderLabel.AutoSize = true;
			this.flipOrderLabel.Location = new System.Drawing.Point(3, 48);
			this.flipOrderLabel.Name = "flipOrderLabel";
			this.flipOrderLabel.Size = new System.Drawing.Size(64, 24);
			this.flipOrderLabel.TabIndex = 6;
			this.flipOrderLabel.Text = "Flip Order:";
			this.flipOrderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// flipOrderCheckbox
			// 
			this.flipOrderCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.flipOrderCheckbox.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.flipOrderCheckbox, 3);
			this.flipOrderCheckbox.Location = new System.Drawing.Point(73, 51);
			this.flipOrderCheckbox.Name = "flipOrderCheckbox";
			this.flipOrderCheckbox.Size = new System.Drawing.Size(204, 18);
			this.flipOrderCheckbox.TabIndex = 7;
			this.flipOrderCheckbox.UseVisualStyleBackColor = true;
			// 
			// FlipRangeOfCompositeFrames
			// 
			this.AcceptButton = this.saveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(292, 119);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FlipRangeOfCompositeFrames";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Flip Range of Composite Frames";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.startFrame)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.endFrame)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label startFrameLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown startFrame;
		private System.Windows.Forms.NumericUpDown endFrame;
		private System.Windows.Forms.Label flipOrderLabel;
		private System.Windows.Forms.CheckBox flipOrderCheckbox;
	}
}