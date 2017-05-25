#pragma warning disable 618, 612
namespace SpriteAnimator
{
	partial class ImageViewerOGL
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
                // Make sure timers are gone.
                if (scheduleRedraw != null)
                    scheduleRedraw.Dispose();
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewerOGL));
			this.optionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.popInOrOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.firstToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.useFrozenBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.secondToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.setToDefaultSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setToScaledSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setToFrameSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.simpleOpenGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.optionsContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// optionsContextMenuStrip
			// 
			this.optionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popInOrOutToolStripMenuItem,
            this.firstToolStripSeparator,
            this.useFrozenBackgroundToolStripMenuItem,
            this.secondToolStripSeparator,
            this.setToDefaultSizeToolStripMenuItem,
            this.setToScaledSizeToolStripMenuItem,
            this.setToFrameSizeToolStripMenuItem,
            this.resizeToolStripMenuItem});
			this.optionsContextMenuStrip.Name = "contextMenuStrip1";
			this.optionsContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.optionsContextMenuStrip.Size = new System.Drawing.Size(188, 170);
			// 
			// popInOrOutToolStripMenuItem
			// 
			this.popInOrOutToolStripMenuItem.Name = "popInOrOutToolStripMenuItem";
			this.popInOrOutToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.popInOrOutToolStripMenuItem.Text = "Pop Out/Pop-In";
			this.popInOrOutToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// firstToolStripSeparator
			// 
			this.firstToolStripSeparator.Name = "firstToolStripSeparator";
			this.firstToolStripSeparator.Size = new System.Drawing.Size(184, 6);
			// 
			// useFrozenBackgroundToolStripMenuItem
			// 
			this.useFrozenBackgroundToolStripMenuItem.Checked = true;
			this.useFrozenBackgroundToolStripMenuItem.CheckOnClick = true;
			this.useFrozenBackgroundToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.useFrozenBackgroundToolStripMenuItem.Name = "useFrozenBackgroundToolStripMenuItem";
			this.useFrozenBackgroundToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.useFrozenBackgroundToolStripMenuItem.Text = "Use Frozen Background";
			// 
			// secondToolStripSeparator
			// 
			this.secondToolStripSeparator.Name = "secondToolStripSeparator";
			this.secondToolStripSeparator.Size = new System.Drawing.Size(184, 6);
			// 
			// setToDefaultSizeToolStripMenuItem
			// 
			this.setToDefaultSizeToolStripMenuItem.Name = "setToDefaultSizeToolStripMenuItem";
			this.setToDefaultSizeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.setToDefaultSizeToolStripMenuItem.Text = "Set to Default Size";
			this.setToDefaultSizeToolStripMenuItem.Click += new System.EventHandler(this.setToDefaultSizeToolStripMenuItem_Click);
			// 
			// setToScaledSizeToolStripMenuItem
			// 
			this.setToScaledSizeToolStripMenuItem.Name = "setToScaledSizeToolStripMenuItem";
			this.setToScaledSizeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.setToScaledSizeToolStripMenuItem.Text = "Set to Scaled Size";
			this.setToScaledSizeToolStripMenuItem.Click += new System.EventHandler(this.setToScaledSizeToolStripMenuItem_Click);
			// 
			// setToFrameSizeToolStripMenuItem
			// 
			this.setToFrameSizeToolStripMenuItem.Name = "setToFrameSizeToolStripMenuItem";
			this.setToFrameSizeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.setToFrameSizeToolStripMenuItem.Text = "Set to Frame Size";
			this.setToFrameSizeToolStripMenuItem.Click += new System.EventHandler(this.setToFrameSizeToolStripMenuItem_Click);
			// 
			// resizeToolStripMenuItem
			// 
			this.resizeToolStripMenuItem.CheckOnClick = true;
			this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
			this.resizeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.resizeToolStripMenuItem.Text = "Resize";
			this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
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
			this.simpleOpenGlControl.Name = "simpleOpenGlControl";
			this.simpleOpenGlControl.Size = new System.Drawing.Size(83, 91);
			this.simpleOpenGlControl.StencilBits = ((byte)(0));
			this.simpleOpenGlControl.TabIndex = 1;
			this.simpleOpenGlControl.VSync = false;
			this.simpleOpenGlControl.Click += new System.EventHandler(this.simpleOpenGlControl_Click);
			this.simpleOpenGlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.subRenderControl_Paint);
			this.simpleOpenGlControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl_MouseClick);
			this.simpleOpenGlControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl_MouseDown);
			this.simpleOpenGlControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl_MouseMove);
			this.simpleOpenGlControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl_MouseUp);
			// 
			// ImageViewerOGL
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(83, 91);
			this.ControlBox = false;
			this.Controls.Add(this.simpleOpenGlControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ImageViewerOGL";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Activated += new System.EventHandler(this.ImageViewerOGL_Activated);
			this.Deactivate += new System.EventHandler(this.ImageViewer_Deactivate);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageViewerOGL_FormClosing);
			this.SizeChanged += new System.EventHandler(this.ImageViewerOGL_SizeChanged);
			this.optionsContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip optionsContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem popInOrOutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setToFrameSizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setToDefaultSizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator secondToolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem setToScaledSizeToolStripMenuItem;
		public Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl;
		private System.Windows.Forms.ToolStripSeparator firstToolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem useFrozenBackgroundToolStripMenuItem;
	}
}