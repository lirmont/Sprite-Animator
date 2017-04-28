#pragma warning disable
namespace SpriteAnimator
{
	partial class AddOrEditFrame
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrEditFrame));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.idMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.sMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.tMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.wMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.hMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.idLabel = new System.Windows.Forms.Label();
			this.sLabel = new System.Windows.Forms.Label();
			this.tLabel = new System.Windows.Forms.Label();
			this.wLabel = new System.Windows.Forms.Label();
			this.hLabel = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.simpleOpenGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.magnifyButton = new System.Windows.Forms.Button();
			this.minifyButton = new System.Windows.Forms.Button();
			this.imageWidthLabel = new System.Windows.Forms.Label();
			this.xLabel = new System.Windows.Forms.Label();
			this.imageHeightLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.idMaskedTextBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.sMaskedTextBox, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tMaskedTextBox, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.wMaskedTextBox, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.hMaskedTextBox, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.idLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.sLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.wLabel, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.hLabel, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.saveButton, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.cancelButton, 2, 6);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 8);
			this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(462, 109);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(535, 208);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// idMaskedTextBox
			// 
			this.idMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.idMaskedTextBox.Ceiling = 9999D;
			this.tableLayoutPanel1.SetColumnSpan(this.idMaskedTextBox, 2);
			this.idMaskedTextBox.EmptyText = "ID number.";
			this.idMaskedTextBox.Floor = 1D;
			this.idMaskedTextBox.IsNumeric = true;
			this.idMaskedTextBox.Location = new System.Drawing.Point(30, 3);
			this.idMaskedTextBox.MarkInvalid = false;
			this.idMaskedTextBox.Name = "idMaskedTextBox";
			this.idMaskedTextBox.Size = new System.Drawing.Size(352, 20);
			this.idMaskedTextBox.TabIndex = 0;
			// 
			// sMaskedTextBox
			// 
			this.sMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.sMaskedTextBox.Ceiling = 9999D;
			this.tableLayoutPanel1.SetColumnSpan(this.sMaskedTextBox, 2);
			this.sMaskedTextBox.EmptyText = "X component of starting point in pixels from upper-left side of image.";
			this.sMaskedTextBox.IsNumeric = true;
			this.sMaskedTextBox.Location = new System.Drawing.Point(30, 31);
			this.sMaskedTextBox.MarkInvalid = false;
			this.sMaskedTextBox.Name = "sMaskedTextBox";
			this.sMaskedTextBox.Size = new System.Drawing.Size(352, 20);
			this.sMaskedTextBox.TabIndex = 1;
			// 
			// tMaskedTextBox
			// 
			this.tMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tMaskedTextBox.Ceiling = 9999D;
			this.tableLayoutPanel1.SetColumnSpan(this.tMaskedTextBox, 2);
			this.tMaskedTextBox.EmptyText = "Y component of starting point in pixels from upper-left side of image.";
			this.tMaskedTextBox.IsNumeric = true;
			this.tMaskedTextBox.Location = new System.Drawing.Point(30, 59);
			this.tMaskedTextBox.MarkInvalid = false;
			this.tMaskedTextBox.Name = "tMaskedTextBox";
			this.tMaskedTextBox.Size = new System.Drawing.Size(352, 20);
			this.tMaskedTextBox.TabIndex = 2;
			// 
			// wMaskedTextBox
			// 
			this.wMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.wMaskedTextBox.Ceiling = 9999D;
			this.tableLayoutPanel1.SetColumnSpan(this.wMaskedTextBox, 2);
			this.wMaskedTextBox.EmptyText = "Width of bounding box in pixels.";
			this.wMaskedTextBox.IsNumeric = true;
			this.wMaskedTextBox.Location = new System.Drawing.Point(30, 87);
			this.wMaskedTextBox.MarkInvalid = false;
			this.wMaskedTextBox.Name = "wMaskedTextBox";
			this.wMaskedTextBox.Size = new System.Drawing.Size(352, 20);
			this.wMaskedTextBox.TabIndex = 3;
			// 
			// hMaskedTextBox
			// 
			this.hMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.hMaskedTextBox.Ceiling = 9999D;
			this.tableLayoutPanel1.SetColumnSpan(this.hMaskedTextBox, 2);
			this.hMaskedTextBox.EmptyText = "Height of bounding box in pixels.";
			this.hMaskedTextBox.IsNumeric = true;
			this.hMaskedTextBox.Location = new System.Drawing.Point(30, 115);
			this.hMaskedTextBox.MarkInvalid = false;
			this.hMaskedTextBox.Name = "hMaskedTextBox";
			this.hMaskedTextBox.Size = new System.Drawing.Size(352, 20);
			this.hMaskedTextBox.TabIndex = 4;
			// 
			// idLabel
			// 
			this.idLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.idLabel.AutoSize = true;
			this.idLabel.Location = new System.Drawing.Point(3, 7);
			this.idLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
			this.idLabel.Name = "idLabel";
			this.idLabel.Size = new System.Drawing.Size(21, 13);
			this.idLabel.TabIndex = 5;
			this.idLabel.Text = "ID:";
			// 
			// sLabel
			// 
			this.sLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sLabel.AutoSize = true;
			this.sLabel.Location = new System.Drawing.Point(9, 35);
			this.sLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
			this.sLabel.Name = "sLabel";
			this.sLabel.Size = new System.Drawing.Size(15, 13);
			this.sLabel.TabIndex = 6;
			this.sLabel.Text = "s:";
			// 
			// tLabel
			// 
			this.tLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tLabel.AutoSize = true;
			this.tLabel.Location = new System.Drawing.Point(11, 63);
			this.tLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
			this.tLabel.Name = "tLabel";
			this.tLabel.Size = new System.Drawing.Size(13, 13);
			this.tLabel.TabIndex = 7;
			this.tLabel.Text = "t:";
			// 
			// wLabel
			// 
			this.wLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.wLabel.AutoSize = true;
			this.wLabel.Location = new System.Drawing.Point(6, 91);
			this.wLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
			this.wLabel.Name = "wLabel";
			this.wLabel.Size = new System.Drawing.Size(18, 13);
			this.wLabel.TabIndex = 8;
			this.wLabel.Text = "w:";
			// 
			// hLabel
			// 
			this.hLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hLabel.AutoSize = true;
			this.hLabel.Location = new System.Drawing.Point(8, 119);
			this.hLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
			this.hLabel.Name = "hLabel";
			this.hLabel.Size = new System.Drawing.Size(16, 13);
			this.hLabel.TabIndex = 9;
			this.hLabel.Text = "h:";
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(120, 181);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 12;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(201, 181);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 11;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.simpleOpenGlControl, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.magnifyButton, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.minifyButton, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.imageWidthLabel, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.xLabel, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.imageHeightLabel, 1, 3);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(385, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 5;
			this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 7);
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 208);
			this.tableLayoutPanel2.TabIndex = 13;
			// 
			// simpleOpenGlControl
			// 
			this.simpleOpenGlControl.AccumBits = ((byte)(0));
			this.simpleOpenGlControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.simpleOpenGlControl.AutoCheckErrors = false;
			this.simpleOpenGlControl.AutoFinish = false;
			this.simpleOpenGlControl.AutoMakeCurrent = true;
			this.simpleOpenGlControl.AutoSwapBuffers = true;
			this.simpleOpenGlControl.BackColor = System.Drawing.Color.Black;
			this.simpleOpenGlControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simpleOpenGlControl.BackgroundImage")));
			this.simpleOpenGlControl.ColorBits = ((byte)(32));
			this.simpleOpenGlControl.DepthBits = ((byte)(16));
			this.simpleOpenGlControl.Location = new System.Drawing.Point(0, 0);
			this.simpleOpenGlControl.Margin = new System.Windows.Forms.Padding(0);
			this.simpleOpenGlControl.Name = "simpleOpenGlControl";
			this.tableLayoutPanel2.SetRowSpan(this.simpleOpenGlControl, 4);
			this.simpleOpenGlControl.Size = new System.Drawing.Size(119, 188);
			this.simpleOpenGlControl.StencilBits = ((byte)(0));
			this.simpleOpenGlControl.TabIndex = 3;
			this.simpleOpenGlControl.VSync = false;
			this.simpleOpenGlControl.Load += new System.EventHandler(this.simpleOpenGlControl_Load);
			this.simpleOpenGlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl_Paint);
			this.simpleOpenGlControl.MouseEnter += new System.EventHandler(this.simpleOpenGlControl_MouseEnter);
			this.simpleOpenGlControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl_MouseMove);
			this.simpleOpenGlControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl_MouseUp);
			this.simpleOpenGlControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl_MouseWheel);
			this.simpleOpenGlControl.Resize += new System.EventHandler(this.simpleOpenGlControl_Resize);
			// 
			// magnifyButton
			// 
			this.magnifyButton.Location = new System.Drawing.Point(122, 3);
			this.magnifyButton.Name = "magnifyButton";
			this.magnifyButton.Size = new System.Drawing.Size(23, 23);
			this.magnifyButton.TabIndex = 6;
			this.magnifyButton.Text = "+";
			this.magnifyButton.UseVisualStyleBackColor = true;
			this.magnifyButton.Click += new System.EventHandler(this.magnifyButton_Click);
			// 
			// minifyButton
			// 
			this.minifyButton.Location = new System.Drawing.Point(122, 32);
			this.minifyButton.Name = "minifyButton";
			this.minifyButton.Size = new System.Drawing.Size(23, 23);
			this.minifyButton.TabIndex = 7;
			this.minifyButton.Text = "-";
			this.minifyButton.UseVisualStyleBackColor = true;
			this.minifyButton.Click += new System.EventHandler(this.minifyButton_Click);
			// 
			// imageWidthLabel
			// 
			this.imageWidthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.imageWidthLabel.AutoSize = true;
			this.imageWidthLabel.Location = new System.Drawing.Point(91, 193);
			this.imageWidthLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.imageWidthLabel.Name = "imageWidthLabel";
			this.imageWidthLabel.Size = new System.Drawing.Size(25, 13);
			this.imageWidthLabel.TabIndex = 0;
			this.imageWidthLabel.Text = "000";
			// 
			// xLabel
			// 
			this.xLabel.AutoSize = true;
			this.xLabel.Location = new System.Drawing.Point(122, 192);
			this.xLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
			this.xLabel.Name = "xLabel";
			this.xLabel.Size = new System.Drawing.Size(12, 13);
			this.xLabel.TabIndex = 2;
			this.xLabel.Text = "x";
			// 
			// imageHeightLabel
			// 
			this.imageHeightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.imageHeightLabel.AutoSize = true;
			this.imageHeightLabel.Location = new System.Drawing.Point(122, 175);
			this.imageHeightLabel.Name = "imageHeightLabel";
			this.imageHeightLabel.Size = new System.Drawing.Size(25, 13);
			this.imageHeightLabel.TabIndex = 1;
			this.imageHeightLabel.Text = "000";
			// 
			// AddOrEditFrame
			// 
			this.AcceptButton = this.saveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(543, 222);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(551, 249);
			this.Name = "AddOrEditFrame";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Add or Edit Frame";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private MaskedTextBox idMaskedTextBox;
		private MaskedTextBox sMaskedTextBox;
		private MaskedTextBox tMaskedTextBox;
		private MaskedTextBox wMaskedTextBox;
		private MaskedTextBox hMaskedTextBox;
		private System.Windows.Forms.Label idLabel;
		private System.Windows.Forms.Label sLabel;
		private System.Windows.Forms.Label tLabel;
		private System.Windows.Forms.Label wLabel;
		private System.Windows.Forms.Label hLabel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label imageWidthLabel;
		private System.Windows.Forms.Label imageHeightLabel;
		private System.Windows.Forms.Label xLabel;
		private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl;
		private System.Windows.Forms.Button magnifyButton;
		private System.Windows.Forms.Button minifyButton;
	}
}