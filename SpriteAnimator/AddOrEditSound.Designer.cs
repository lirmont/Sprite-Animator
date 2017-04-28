namespace SpriteAnimator
{
    partial class AddOrEditSound
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
			this.browseButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.maskedTextBox1 = new SpriteAnimator.MaskedTextBox();
			this.maskedTextBox2 = new SpriteAnimator.MaskedTextBox();
			this.maskedTextBox3 = new SpriteAnimator.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
			this.tableLayoutPanel1.Controls.Add(this.browseButton, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.cancelButton, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.saveButton, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.maskedTextBox1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.maskedTextBox2, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.maskedTextBox3, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 116);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// browseButton
			// 
			this.browseButton.Location = new System.Drawing.Point(412, 61);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(75, 23);
			this.browseButton.TabIndex = 2;
			this.browseButton.Text = "Browse";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.button3_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(249, 90);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.button2_Click);
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(168, 90);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 0;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// maskedTextBox1
			// 
			this.maskedTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.maskedTextBox1, 3);
			this.maskedTextBox1.EmptyText = "Name of sound, as used in the formatting document.";
			this.maskedTextBox1.Location = new System.Drawing.Point(86, 3);
			this.maskedTextBox1.MarkInvalid = false;
			this.maskedTextBox1.Name = "maskedTextBox1";
			this.maskedTextBox1.Size = new System.Drawing.Size(403, 20);
			this.maskedTextBox1.TabIndex = 3;
			// 
			// maskedTextBox2
			// 
			this.maskedTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.maskedTextBox2, 3);
			this.maskedTextBox2.EmptyText = "Color name as described by the formatting document.";
			this.maskedTextBox2.Location = new System.Drawing.Point(86, 32);
			this.maskedTextBox2.MarkInvalid = false;
			this.maskedTextBox2.Name = "maskedTextBox2";
			this.maskedTextBox2.Size = new System.Drawing.Size(403, 20);
			this.maskedTextBox2.TabIndex = 4;
			// 
			// maskedTextBox3
			// 
			this.maskedTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.maskedTextBox3, 2);
			this.maskedTextBox3.EmptyText = "OGG Sound File to be played on demand.";
			this.maskedTextBox3.Location = new System.Drawing.Point(86, 61);
			this.maskedTextBox3.MarkInvalid = false;
			this.maskedTextBox3.Name = "maskedTextBox3";
			this.maskedTextBox3.Size = new System.Drawing.Size(320, 20);
			this.maskedTextBox3.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(42, 7);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Name:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 36);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Color Name:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 65);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Filename:";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "OGG Vorbis Media|*.ogg";
			// 
			// AddOrEditSound
			// 
			this.AcceptButton = this.saveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(493, 118);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddOrEditSound";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add or Edit Sound";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
        private MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}