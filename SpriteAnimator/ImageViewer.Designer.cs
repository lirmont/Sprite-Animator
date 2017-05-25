namespace SpriteAnimator
{
    partial class ImageViewer
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
                // Make sure thread that causes window shake feature is gone.
                if (shakeWindowThread != null)
                    shakeWindowThread.Dispose();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewer));
			this.displayedImagePictureBox = new System.Windows.Forms.PictureBox();
			this.showOriginalImageButtonPictureBox = new SpriteAnimator.TransparentPictureBox();
			this.zoomOutButtonPictureBox = new SpriteAnimator.TransparentPictureBox();
			this.zoomInButtonPictureBox = new SpriteAnimator.TransparentPictureBox();
			this.exitButtonPictureBox = new SpriteAnimator.TransparentPictureBox();
			((System.ComponentModel.ISupportInitialize)(this.displayedImagePictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// displayedImagePictureBox
			// 
			this.displayedImagePictureBox.BackColor = System.Drawing.Color.Transparent;
			this.displayedImagePictureBox.Location = new System.Drawing.Point(0, 0);
			this.displayedImagePictureBox.Name = "displayedImagePictureBox";
			this.displayedImagePictureBox.Size = new System.Drawing.Size(100, 160);
			this.displayedImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.displayedImagePictureBox.TabIndex = 5;
			this.displayedImagePictureBox.TabStop = false;
			this.displayedImagePictureBox.Click += new System.EventHandler(this.displayedImagePictureBox_Click);
			this.displayedImagePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.displayedImagePictureBox_Paint);
			this.displayedImagePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.displayedImagePictureBox_MouseDown);
			this.displayedImagePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.displayedImagePictureBox_MouseMove);
			this.displayedImagePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.displayedImagePictureBox_MouseUp);
			// 
			// showOriginalImageButtonPictureBox
			// 
			this.showOriginalImageButtonPictureBox.BackColor = System.Drawing.Color.Transparent;
			this.showOriginalImageButtonPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.showOriginalImageButtonPictureBox.Image = global::SpriteAnimator.Properties.Resources.clear;
			this.showOriginalImageButtonPictureBox.Location = new System.Drawing.Point(88, 104);
			this.showOriginalImageButtonPictureBox.Name = "showOriginalImageButtonPictureBox";
			this.showOriginalImageButtonPictureBox.Size = new System.Drawing.Size(25, 25);
			this.showOriginalImageButtonPictureBox.TabIndex = 4;
			this.showOriginalImageButtonPictureBox.Click += new System.EventHandler(this.showOriginalImageButtonPictureBox_Click);
			// 
			// zoomOutButtonPictureBox
			// 
			this.zoomOutButtonPictureBox.BackColor = System.Drawing.Color.Transparent;
			this.zoomOutButtonPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.zoomOutButtonPictureBox.Image = global::SpriteAnimator.Properties.Resources.minus;
			this.zoomOutButtonPictureBox.Location = new System.Drawing.Point(88, 64);
			this.zoomOutButtonPictureBox.Name = "zoomOutButtonPictureBox";
			this.zoomOutButtonPictureBox.Size = new System.Drawing.Size(25, 25);
			this.zoomOutButtonPictureBox.TabIndex = 3;
			this.zoomOutButtonPictureBox.Click += new System.EventHandler(this.zoomOutButtonPictureBox_Click);
			// 
			// zoomInButtonPictureBox
			// 
			this.zoomInButtonPictureBox.BackColor = System.Drawing.Color.Transparent;
			this.zoomInButtonPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.zoomInButtonPictureBox.Image = global::SpriteAnimator.Properties.Resources.plus;
			this.zoomInButtonPictureBox.Location = new System.Drawing.Point(88, 32);
			this.zoomInButtonPictureBox.Name = "zoomInButtonPictureBox";
			this.zoomInButtonPictureBox.Size = new System.Drawing.Size(25, 25);
			this.zoomInButtonPictureBox.TabIndex = 2;
			this.zoomInButtonPictureBox.Click += new System.EventHandler(this.zoomInButtonPictureBox_Click);
			// 
			// exitButtonPictureBox
			// 
			this.exitButtonPictureBox.BackColor = System.Drawing.Color.Transparent;
			this.exitButtonPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.exitButtonPictureBox.Image = global::SpriteAnimator.Properties.Resources.ex;
			this.exitButtonPictureBox.Location = new System.Drawing.Point(88, 0);
			this.exitButtonPictureBox.Name = "exitButtonPictureBox";
			this.exitButtonPictureBox.Size = new System.Drawing.Size(25, 25);
			this.exitButtonPictureBox.TabIndex = 1;
			this.exitButtonPictureBox.Click += new System.EventHandler(this.exitButtonPictureBox_Click);
			// 
			// ImageViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(190, 214);
			this.Controls.Add(this.showOriginalImageButtonPictureBox);
			this.Controls.Add(this.zoomOutButtonPictureBox);
			this.Controls.Add(this.zoomInButtonPictureBox);
			this.Controls.Add(this.exitButtonPictureBox);
			this.Controls.Add(this.displayedImagePictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ImageViewer";
			this.Text = "ImageViewer";
			this.Activated += new System.EventHandler(this.ImageViewer_Activated);
			this.Deactivate += new System.EventHandler(this.ImageViewer_Deactivate);
			this.Load += new System.EventHandler(this.ImageViewer_Load);
			((System.ComponentModel.ISupportInitialize)(this.displayedImagePictureBox)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private TransparentPictureBox exitButtonPictureBox;
        private TransparentPictureBox zoomInButtonPictureBox;
        private TransparentPictureBox zoomOutButtonPictureBox;
        private TransparentPictureBox showOriginalImageButtonPictureBox;
        private System.Windows.Forms.PictureBox displayedImagePictureBox;
    }
}