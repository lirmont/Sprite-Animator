namespace SpriteAnimator
{
    partial class AddOrEditGuide
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
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Type:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DisplayMember = "0";
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical"});
			this.comboBox1.Location = new System.Drawing.Point(56, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(129, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.Text = "Horizontal";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(57, 37);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(64, 20);
			this.numericUpDown1.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Position:";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.saveButton, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.cancelButton, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 75);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(176, 28);
			this.tableLayoutPanel1.TabIndex = 7;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(10, 3);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 22);
			this.saveButton.TabIndex = 0;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(91, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 22);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.button2_Click);
			// 
			// AddOrEditGuide
			// 
			this.AcceptButton = this.saveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(191, 108);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(199, 135);
			this.Name = "AddOrEditGuide";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add or Edit Guide";
			this.Shown += new System.EventHandler(this.AddOrEditGuide_Shown);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.NumericUpDown numericUpDown1;

    }
}