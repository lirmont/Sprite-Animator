namespace ColorControl
{
	partial class ColorControl
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
			this.simpleOpenGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.colorSelectContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.autoCompareOnStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.storeColorToPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.storeColorForComparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.clearComparisonColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.switchToPaletteModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.colorDisplayPanel = new System.Windows.Forms.Panel();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.helpButton = new System.Windows.Forms.Button();
			this.selectColorLabel = new System.Windows.Forms.Label();
			this.colorComparisonFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.colorSpaceAndOptionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.colorSpaceFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.hsvTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.hueMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.saturationMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.valueMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.hueLabel = new System.Windows.Forms.Label();
			this.saturationLabel = new System.Windows.Forms.Label();
			this.valueLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.rgbTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.rLabel = new System.Windows.Forms.Label();
			this.rValueMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.gLabel = new System.Windows.Forms.Label();
			this.gValueMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.bLabel = new System.Windows.Forms.Label();
			this.bValueMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.xyzTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.xLabel = new System.Windows.Forms.Label();
			this.xValueMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.yLabel = new System.Windows.Forms.Label();
			this.yValueMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.zLabel = new System.Windows.Forms.Label();
			this.zValueMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.labTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.LLabel = new System.Windows.Forms.Label();
			this.LMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.aLabel = new System.Windows.Forms.Label();
			this.aMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.labBLabel = new System.Windows.Forms.Label();
			this.bMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.colorDifferenceTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.colorDifferenceLabel = new System.Windows.Forms.Label();
			this.colorDifferenceValueLabel = new System.Windows.Forms.Label();
			this.formOptionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.hsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rgbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xyzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepHSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepRGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepXYZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepLabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.storedColorsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.automaticallyUseSelectedColorAsActiveColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.removeStoredColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceStoredColorWithActiveColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepToActiveColorFromStoredColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.steppingContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.useStoredColorAsActiveColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.useStoredColorForComparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.switchToColorSelectModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonsPanel = new System.Windows.Forms.Panel();
			this.primaryTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.componentOptionsAndButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.colorSelectContextMenuStrip.SuspendLayout();
			this.colorComparisonFlowLayoutPanel.SuspendLayout();
			this.colorSpaceAndOptionsTableLayoutPanel.SuspendLayout();
			this.colorSpaceFlowLayoutPanel.SuspendLayout();
			this.hsvTableLayoutPanel.SuspendLayout();
			this.rgbTableLayoutPanel.SuspendLayout();
			this.xyzTableLayoutPanel.SuspendLayout();
			this.labTableLayoutPanel.SuspendLayout();
			this.colorDifferenceTableLayoutPanel.SuspendLayout();
			this.formOptionsContextMenuStrip.SuspendLayout();
			this.storedColorsContextMenuStrip.SuspendLayout();
			this.steppingContextMenuStrip.SuspendLayout();
			this.buttonsPanel.SuspendLayout();
			this.primaryTableLayoutPanel.SuspendLayout();
			this.componentOptionsAndButtonsTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
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
			this.simpleOpenGlControl.ColorBits = ((byte)(32));
			this.simpleOpenGlControl.ContextMenuStrip = this.colorSelectContextMenuStrip;
			this.simpleOpenGlControl.DepthBits = ((byte)(16));
			this.simpleOpenGlControl.Location = new System.Drawing.Point(0, 26);
			this.simpleOpenGlControl.Margin = new System.Windows.Forms.Padding(0);
			this.simpleOpenGlControl.Name = "simpleOpenGlControl";
			this.simpleOpenGlControl.Size = new System.Drawing.Size(276, 236);
			this.simpleOpenGlControl.StencilBits = ((byte)(0));
			this.simpleOpenGlControl.TabIndex = 0;
			this.simpleOpenGlControl.VSync = false;
			this.simpleOpenGlControl.Load += new System.EventHandler(this.simpleOpenGlControl_Load);
			this.simpleOpenGlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl_Paint);
			this.simpleOpenGlControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl_MouseDown);
			this.simpleOpenGlControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl_MouseMove);
			this.simpleOpenGlControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl_MouseUp);
			this.simpleOpenGlControl.Resize += new System.EventHandler(this.simpleOpenGlControl_Resize);
			// 
			// colorSelectContextMenuStrip
			// 
			this.colorSelectContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoCompareOnStoreToolStripMenuItem,
            this.toolStripSeparator4,
            this.storeColorToPaletteToolStripMenuItem,
            this.storeColorForComparisonToolStripMenuItem,
            this.toolStripSeparator3,
            this.clearComparisonColorToolStripMenuItem,
            this.toolStripSeparator1,
            this.switchToPaletteModeToolStripMenuItem});
			this.colorSelectContextMenuStrip.Name = "colorSelectContextMenuStrip";
			this.colorSelectContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.colorSelectContextMenuStrip.Size = new System.Drawing.Size(205, 132);
			this.colorSelectContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.colorSelectContextMenuStrip_Opening);
			// 
			// autoCompareOnStoreToolStripMenuItem
			// 
			this.autoCompareOnStoreToolStripMenuItem.Checked = true;
			this.autoCompareOnStoreToolStripMenuItem.CheckOnClick = true;
			this.autoCompareOnStoreToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoCompareOnStoreToolStripMenuItem.Name = "autoCompareOnStoreToolStripMenuItem";
			this.autoCompareOnStoreToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.autoCompareOnStoreToolStripMenuItem.Text = "Auto-Compare on Store";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(201, 6);
			// 
			// storeColorToPaletteToolStripMenuItem
			// 
			this.storeColorToPaletteToolStripMenuItem.Name = "storeColorToPaletteToolStripMenuItem";
			this.storeColorToPaletteToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.storeColorToPaletteToolStripMenuItem.Text = "Store Color to Palette";
			// 
			// storeColorForComparisonToolStripMenuItem
			// 
			this.storeColorForComparisonToolStripMenuItem.Name = "storeColorForComparisonToolStripMenuItem";
			this.storeColorForComparisonToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.storeColorForComparisonToolStripMenuItem.Text = "Store Color for Comparison";
			this.storeColorForComparisonToolStripMenuItem.Click += new System.EventHandler(this.storeColorForComparisonToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(201, 6);
			// 
			// clearComparisonColorToolStripMenuItem
			// 
			this.clearComparisonColorToolStripMenuItem.Name = "clearComparisonColorToolStripMenuItem";
			this.clearComparisonColorToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.clearComparisonColorToolStripMenuItem.Text = "Clear Comparison Color";
			this.clearComparisonColorToolStripMenuItem.Click += new System.EventHandler(this.clearComparisonColorToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
			// 
			// switchToPaletteModeToolStripMenuItem
			// 
			this.switchToPaletteModeToolStripMenuItem.Name = "switchToPaletteModeToolStripMenuItem";
			this.switchToPaletteModeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.switchToPaletteModeToolStripMenuItem.Text = "Switch to Palette Mode";
			this.switchToPaletteModeToolStripMenuItem.Click += new System.EventHandler(this.switchToPaletteModeToolStripMenuItem_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Location = new System.Drawing.Point(0, 262);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(433, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// colorDisplayPanel
			// 
			this.colorDisplayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.colorDisplayPanel.BackColor = System.Drawing.Color.White;
			this.colorDisplayPanel.Location = new System.Drawing.Point(0, 0);
			this.colorDisplayPanel.Margin = new System.Windows.Forms.Padding(0);
			this.colorDisplayPanel.Name = "colorDisplayPanel";
			this.colorDisplayPanel.Size = new System.Drawing.Size(36, 36);
			this.colorDisplayPanel.TabIndex = 2;
			this.colorDisplayPanel.BackColorChanged += new System.EventHandler(this.colorDisplayPanel_BackColorChanged);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(56, 9);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 3;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(56, 37);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// helpButton
			// 
			this.helpButton.Location = new System.Drawing.Point(56, 65);
			this.helpButton.Name = "helpButton";
			this.helpButton.Size = new System.Drawing.Size(75, 23);
			this.helpButton.TabIndex = 5;
			this.helpButton.Text = "Help";
			this.helpButton.UseVisualStyleBackColor = true;
			this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
			// 
			// selectColorLabel
			// 
			this.selectColorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.selectColorLabel.AutoSize = true;
			this.selectColorLabel.Location = new System.Drawing.Point(6, 13);
			this.selectColorLabel.Margin = new System.Windows.Forms.Padding(6, 13, 3, 0);
			this.selectColorLabel.Name = "selectColorLabel";
			this.selectColorLabel.Size = new System.Drawing.Size(67, 13);
			this.selectColorLabel.TabIndex = 6;
			this.selectColorLabel.Text = "Select Color:";
			// 
			// colorComparisonFlowLayoutPanel
			// 
			this.colorComparisonFlowLayoutPanel.BackColor = System.Drawing.Color.White;
			this.colorComparisonFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.colorComparisonFlowLayoutPanel.Controls.Add(this.colorDisplayPanel);
			this.colorComparisonFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.colorComparisonFlowLayoutPanel.Location = new System.Drawing.Point(8, 48);
			this.colorComparisonFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.colorComparisonFlowLayoutPanel.Name = "colorComparisonFlowLayoutPanel";
			this.colorComparisonFlowLayoutPanel.Size = new System.Drawing.Size(40, 40);
			this.colorComparisonFlowLayoutPanel.TabIndex = 8;
			// 
			// colorSpaceAndOptionsTableLayoutPanel
			// 
			this.colorSpaceAndOptionsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.colorSpaceAndOptionsTableLayoutPanel.AutoSize = true;
			this.colorSpaceAndOptionsTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.colorSpaceAndOptionsTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
			this.colorSpaceAndOptionsTableLayoutPanel.ColumnCount = 1;
			this.colorSpaceAndOptionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.colorSpaceAndOptionsTableLayoutPanel.Controls.Add(this.colorSpaceFlowLayoutPanel, 0, 0);
			this.colorSpaceAndOptionsTableLayoutPanel.Controls.Add(this.colorDifferenceTableLayoutPanel, 0, 1);
			this.colorSpaceAndOptionsTableLayoutPanel.Location = new System.Drawing.Point(3, 105);
			this.colorSpaceAndOptionsTableLayoutPanel.Name = "colorSpaceAndOptionsTableLayoutPanel";
			this.colorSpaceAndOptionsTableLayoutPanel.RowCount = 2;
			this.colorSpaceAndOptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.colorSpaceAndOptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.colorSpaceAndOptionsTableLayoutPanel.Size = new System.Drawing.Size(148, 148);
			this.colorSpaceAndOptionsTableLayoutPanel.TabIndex = 9;
			// 
			// colorSpaceFlowLayoutPanel
			// 
			this.colorSpaceFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.colorSpaceFlowLayoutPanel.AutoSize = true;
			this.colorSpaceFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.colorSpaceFlowLayoutPanel.Controls.Add(this.hsvTableLayoutPanel);
			this.colorSpaceFlowLayoutPanel.Controls.Add(this.rgbTableLayoutPanel);
			this.colorSpaceFlowLayoutPanel.Controls.Add(this.xyzTableLayoutPanel);
			this.colorSpaceFlowLayoutPanel.Controls.Add(this.labTableLayoutPanel);
			this.colorSpaceFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
			this.colorSpaceFlowLayoutPanel.Name = "colorSpaceFlowLayoutPanel";
			this.colorSpaceFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(3);
			this.colorSpaceFlowLayoutPanel.Size = new System.Drawing.Size(142, 344);
			this.colorSpaceFlowLayoutPanel.TabIndex = 10;
			// 
			// hsvTableLayoutPanel
			// 
			this.hsvTableLayoutPanel.ColumnCount = 3;
			this.hsvTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.hsvTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.hsvTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.hsvTableLayoutPanel.Controls.Add(this.hueMaskedTextBox, 1, 0);
			this.hsvTableLayoutPanel.Controls.Add(this.saturationMaskedTextBox, 1, 1);
			this.hsvTableLayoutPanel.Controls.Add(this.valueMaskedTextBox, 1, 2);
			this.hsvTableLayoutPanel.Controls.Add(this.hueLabel, 0, 0);
			this.hsvTableLayoutPanel.Controls.Add(this.saturationLabel, 0, 1);
			this.hsvTableLayoutPanel.Controls.Add(this.valueLabel, 0, 2);
			this.hsvTableLayoutPanel.Controls.Add(this.label4, 2, 0);
			this.hsvTableLayoutPanel.Controls.Add(this.label5, 2, 1);
			this.hsvTableLayoutPanel.Controls.Add(this.label6, 2, 2);
			this.hsvTableLayoutPanel.Location = new System.Drawing.Point(6, 6);
			this.hsvTableLayoutPanel.Name = "hsvTableLayoutPanel";
			this.hsvTableLayoutPanel.RowCount = 3;
			this.hsvTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.hsvTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.hsvTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.hsvTableLayoutPanel.Size = new System.Drawing.Size(88, 80);
			this.hsvTableLayoutPanel.TabIndex = 7;
			// 
			// hueMaskedTextBox
			// 
			this.hueMaskedTextBox.Location = new System.Drawing.Point(27, 3);
			this.hueMaskedTextBox.Mask = "000";
			this.hueMaskedTextBox.Name = "hueMaskedTextBox";
			this.hueMaskedTextBox.PromptChar = ' ';
			this.hueMaskedTextBox.Size = new System.Drawing.Size(37, 20);
			this.hueMaskedTextBox.TabIndex = 0;
			this.hueMaskedTextBox.TextChanged += new System.EventHandler(this.hueTextBox_TextChanged);
			this.hueMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.hueTextBox_Validating);
			// 
			// saturationMaskedTextBox
			// 
			this.saturationMaskedTextBox.Location = new System.Drawing.Point(27, 29);
			this.saturationMaskedTextBox.Mask = "000";
			this.saturationMaskedTextBox.Name = "saturationMaskedTextBox";
			this.saturationMaskedTextBox.PromptChar = ' ';
			this.saturationMaskedTextBox.Size = new System.Drawing.Size(37, 20);
			this.saturationMaskedTextBox.TabIndex = 1;
			this.saturationMaskedTextBox.TextChanged += new System.EventHandler(this.saturationTextBox_TextChanged);
			this.saturationMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.genericPercentMaskedTextBox_Validating);
			// 
			// valueMaskedTextBox
			// 
			this.valueMaskedTextBox.Location = new System.Drawing.Point(27, 55);
			this.valueMaskedTextBox.Mask = "000";
			this.valueMaskedTextBox.Name = "valueMaskedTextBox";
			this.valueMaskedTextBox.PromptChar = ' ';
			this.valueMaskedTextBox.Size = new System.Drawing.Size(37, 20);
			this.valueMaskedTextBox.TabIndex = 2;
			this.valueMaskedTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
			this.valueMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.genericPercentMaskedTextBox_Validating);
			// 
			// hueLabel
			// 
			this.hueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.hueLabel.AutoSize = true;
			this.hueLabel.Location = new System.Drawing.Point(3, 0);
			this.hueLabel.Name = "hueLabel";
			this.hueLabel.Size = new System.Drawing.Size(18, 26);
			this.hueLabel.TabIndex = 3;
			this.hueLabel.Text = "H:";
			this.hueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// saturationLabel
			// 
			this.saturationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.saturationLabel.AutoSize = true;
			this.saturationLabel.Location = new System.Drawing.Point(3, 26);
			this.saturationLabel.Name = "saturationLabel";
			this.saturationLabel.Size = new System.Drawing.Size(18, 26);
			this.saturationLabel.TabIndex = 4;
			this.saturationLabel.Text = "S:";
			this.saturationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// valueLabel
			// 
			this.valueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.valueLabel.AutoSize = true;
			this.valueLabel.Location = new System.Drawing.Point(3, 52);
			this.valueLabel.Name = "valueLabel";
			this.valueLabel.Size = new System.Drawing.Size(18, 28);
			this.valueLabel.TabIndex = 5;
			this.valueLabel.Text = "V:";
			this.valueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(70, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(15, 26);
			this.label4.TabIndex = 6;
			this.label4.Text = "°";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(70, 26);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(15, 26);
			this.label5.TabIndex = 7;
			this.label5.Text = "%";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(70, 52);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(15, 28);
			this.label6.TabIndex = 8;
			this.label6.Text = "%";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rgbTableLayoutPanel
			// 
			this.rgbTableLayoutPanel.AutoSize = true;
			this.rgbTableLayoutPanel.ColumnCount = 2;
			this.rgbTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.rgbTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.rgbTableLayoutPanel.Controls.Add(this.rLabel, 0, 0);
			this.rgbTableLayoutPanel.Controls.Add(this.rValueMaskedTextBox, 1, 0);
			this.rgbTableLayoutPanel.Controls.Add(this.gLabel, 0, 1);
			this.rgbTableLayoutPanel.Controls.Add(this.gValueMaskedTextBox, 1, 1);
			this.rgbTableLayoutPanel.Controls.Add(this.bLabel, 0, 2);
			this.rgbTableLayoutPanel.Controls.Add(this.bValueMaskedTextBox, 1, 2);
			this.rgbTableLayoutPanel.Location = new System.Drawing.Point(6, 92);
			this.rgbTableLayoutPanel.Name = "rgbTableLayoutPanel";
			this.rgbTableLayoutPanel.RowCount = 3;
			this.rgbTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.rgbTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.rgbTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.rgbTableLayoutPanel.Size = new System.Drawing.Size(67, 78);
			this.rgbTableLayoutPanel.TabIndex = 8;
			this.rgbTableLayoutPanel.Visible = false;
			// 
			// rLabel
			// 
			this.rLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rLabel.AutoSize = true;
			this.rLabel.Location = new System.Drawing.Point(3, 0);
			this.rLabel.Name = "rLabel";
			this.rLabel.Size = new System.Drawing.Size(18, 26);
			this.rLabel.TabIndex = 0;
			this.rLabel.Text = "R:";
			this.rLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// rValueMaskedTextBox
			// 
			this.rValueMaskedTextBox.Location = new System.Drawing.Point(27, 3);
			this.rValueMaskedTextBox.Mask = "000";
			this.rValueMaskedTextBox.Name = "rValueMaskedTextBox";
			this.rValueMaskedTextBox.PromptChar = ' ';
			this.rValueMaskedTextBox.Size = new System.Drawing.Size(37, 20);
			this.rValueMaskedTextBox.TabIndex = 1;
			this.rValueMaskedTextBox.TextChanged += new System.EventHandler(this.genericRGBComponentMaskedTextBox_TextChanged);
			this.rValueMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.genericRGBComponentMaskedTextBox_Validating);
			// 
			// gLabel
			// 
			this.gLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gLabel.AutoSize = true;
			this.gLabel.Location = new System.Drawing.Point(3, 26);
			this.gLabel.Name = "gLabel";
			this.gLabel.Size = new System.Drawing.Size(18, 26);
			this.gLabel.TabIndex = 2;
			this.gLabel.Text = "G:";
			this.gLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gValueMaskedTextBox
			// 
			this.gValueMaskedTextBox.Location = new System.Drawing.Point(27, 29);
			this.gValueMaskedTextBox.Mask = "000";
			this.gValueMaskedTextBox.Name = "gValueMaskedTextBox";
			this.gValueMaskedTextBox.PromptChar = ' ';
			this.gValueMaskedTextBox.Size = new System.Drawing.Size(37, 20);
			this.gValueMaskedTextBox.TabIndex = 3;
			this.gValueMaskedTextBox.TextChanged += new System.EventHandler(this.genericRGBComponentMaskedTextBox_TextChanged);
			this.gValueMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.genericRGBComponentMaskedTextBox_Validating);
			// 
			// bLabel
			// 
			this.bLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bLabel.AutoSize = true;
			this.bLabel.Location = new System.Drawing.Point(3, 52);
			this.bLabel.Name = "bLabel";
			this.bLabel.Size = new System.Drawing.Size(18, 26);
			this.bLabel.TabIndex = 4;
			this.bLabel.Text = "B:";
			this.bLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// bValueMaskedTextBox
			// 
			this.bValueMaskedTextBox.Location = new System.Drawing.Point(27, 55);
			this.bValueMaskedTextBox.Mask = "000";
			this.bValueMaskedTextBox.Name = "bValueMaskedTextBox";
			this.bValueMaskedTextBox.PromptChar = ' ';
			this.bValueMaskedTextBox.Size = new System.Drawing.Size(37, 20);
			this.bValueMaskedTextBox.TabIndex = 5;
			this.bValueMaskedTextBox.TextChanged += new System.EventHandler(this.genericRGBComponentMaskedTextBox_TextChanged);
			this.bValueMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.genericRGBComponentMaskedTextBox_Validating);
			// 
			// xyzTableLayoutPanel
			// 
			this.xyzTableLayoutPanel.AutoSize = true;
			this.xyzTableLayoutPanel.ColumnCount = 2;
			this.xyzTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.xyzTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.xyzTableLayoutPanel.Controls.Add(this.xLabel, 0, 0);
			this.xyzTableLayoutPanel.Controls.Add(this.xValueMaskedTextBox, 1, 0);
			this.xyzTableLayoutPanel.Controls.Add(this.yLabel, 0, 1);
			this.xyzTableLayoutPanel.Controls.Add(this.yValueMaskedTextBox, 1, 1);
			this.xyzTableLayoutPanel.Controls.Add(this.zLabel, 0, 2);
			this.xyzTableLayoutPanel.Controls.Add(this.zValueMaskedTextBox, 1, 2);
			this.xyzTableLayoutPanel.Location = new System.Drawing.Point(6, 176);
			this.xyzTableLayoutPanel.Name = "xyzTableLayoutPanel";
			this.xyzTableLayoutPanel.RowCount = 3;
			this.xyzTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.xyzTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.xyzTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.xyzTableLayoutPanel.Size = new System.Drawing.Size(147, 78);
			this.xyzTableLayoutPanel.TabIndex = 9;
			this.xyzTableLayoutPanel.Visible = false;
			// 
			// xLabel
			// 
			this.xLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.xLabel.AutoSize = true;
			this.xLabel.Location = new System.Drawing.Point(3, 0);
			this.xLabel.Name = "xLabel";
			this.xLabel.Size = new System.Drawing.Size(17, 26);
			this.xLabel.TabIndex = 0;
			this.xLabel.Text = "X:";
			this.xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xValueMaskedTextBox
			// 
			this.xValueMaskedTextBox.Location = new System.Drawing.Point(26, 3);
			this.xValueMaskedTextBox.Name = "xValueMaskedTextBox";
			this.xValueMaskedTextBox.Size = new System.Drawing.Size(118, 20);
			this.xValueMaskedTextBox.TabIndex = 1;
			this.xValueMaskedTextBox.TextChanged += new System.EventHandler(this.genericXYZComponentMaskedTextBox_TextChanged);
			this.xValueMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.genericXYZComponentMaskedTextBox_Validating);
			// 
			// yLabel
			// 
			this.yLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.yLabel.AutoSize = true;
			this.yLabel.Location = new System.Drawing.Point(3, 26);
			this.yLabel.Name = "yLabel";
			this.yLabel.Size = new System.Drawing.Size(17, 26);
			this.yLabel.TabIndex = 2;
			this.yLabel.Text = "Y:";
			this.yLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// yValueMaskedTextBox
			// 
			this.yValueMaskedTextBox.Location = new System.Drawing.Point(26, 29);
			this.yValueMaskedTextBox.Name = "yValueMaskedTextBox";
			this.yValueMaskedTextBox.Size = new System.Drawing.Size(118, 20);
			this.yValueMaskedTextBox.TabIndex = 3;
			this.yValueMaskedTextBox.TextChanged += new System.EventHandler(this.genericXYZComponentMaskedTextBox_TextChanged);
			this.yValueMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.genericXYZComponentMaskedTextBox_Validating);
			// 
			// zLabel
			// 
			this.zLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.zLabel.AutoSize = true;
			this.zLabel.Location = new System.Drawing.Point(3, 52);
			this.zLabel.Name = "zLabel";
			this.zLabel.Size = new System.Drawing.Size(17, 26);
			this.zLabel.TabIndex = 4;
			this.zLabel.Text = "Z:";
			this.zLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// zValueMaskedTextBox
			// 
			this.zValueMaskedTextBox.Location = new System.Drawing.Point(26, 55);
			this.zValueMaskedTextBox.Name = "zValueMaskedTextBox";
			this.zValueMaskedTextBox.Size = new System.Drawing.Size(118, 20);
			this.zValueMaskedTextBox.TabIndex = 5;
			this.zValueMaskedTextBox.TextChanged += new System.EventHandler(this.genericXYZComponentMaskedTextBox_TextChanged);
			this.zValueMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.genericXYZComponentMaskedTextBox_Validating);
			// 
			// labTableLayoutPanel
			// 
			this.labTableLayoutPanel.AutoSize = true;
			this.labTableLayoutPanel.ColumnCount = 2;
			this.labTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.labTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.labTableLayoutPanel.Controls.Add(this.LLabel, 0, 0);
			this.labTableLayoutPanel.Controls.Add(this.LMaskedTextBox, 1, 0);
			this.labTableLayoutPanel.Controls.Add(this.aLabel, 0, 1);
			this.labTableLayoutPanel.Controls.Add(this.aMaskedTextBox, 1, 1);
			this.labTableLayoutPanel.Controls.Add(this.labBLabel, 0, 2);
			this.labTableLayoutPanel.Controls.Add(this.bMaskedTextBox, 1, 2);
			this.labTableLayoutPanel.Location = new System.Drawing.Point(6, 260);
			this.labTableLayoutPanel.Name = "labTableLayoutPanel";
			this.labTableLayoutPanel.RowCount = 3;
			this.labTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.labTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.labTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.labTableLayoutPanel.Size = new System.Drawing.Size(147, 78);
			this.labTableLayoutPanel.TabIndex = 10;
			this.labTableLayoutPanel.Visible = false;
			// 
			// LLabel
			// 
			this.LLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LLabel.AutoSize = true;
			this.LLabel.Location = new System.Drawing.Point(3, 0);
			this.LLabel.Name = "LLabel";
			this.LLabel.Size = new System.Drawing.Size(16, 26);
			this.LLabel.TabIndex = 0;
			this.LLabel.Text = "L:";
			this.LLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LMaskedTextBox
			// 
			this.LMaskedTextBox.Location = new System.Drawing.Point(25, 3);
			this.LMaskedTextBox.Name = "LMaskedTextBox";
			this.LMaskedTextBox.Size = new System.Drawing.Size(118, 20);
			this.LMaskedTextBox.TabIndex = 1;
			this.LMaskedTextBox.TextChanged += new System.EventHandler(this.genericLabMaskedTextBox_TextChanged);
			this.LMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.LMaskedTextBox_Validating);
			// 
			// aLabel
			// 
			this.aLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.aLabel.AutoSize = true;
			this.aLabel.Location = new System.Drawing.Point(3, 26);
			this.aLabel.Name = "aLabel";
			this.aLabel.Size = new System.Drawing.Size(16, 26);
			this.aLabel.TabIndex = 2;
			this.aLabel.Text = "a:";
			this.aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// aMaskedTextBox
			// 
			this.aMaskedTextBox.Location = new System.Drawing.Point(25, 29);
			this.aMaskedTextBox.Name = "aMaskedTextBox";
			this.aMaskedTextBox.Size = new System.Drawing.Size(119, 20);
			this.aMaskedTextBox.TabIndex = 3;
			this.aMaskedTextBox.TextChanged += new System.EventHandler(this.genericLabMaskedTextBox_TextChanged);
			this.aMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.genericLabComponentMaskedTextBox_Validating);
			// 
			// labBLabel
			// 
			this.labBLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.labBLabel.AutoSize = true;
			this.labBLabel.Location = new System.Drawing.Point(3, 52);
			this.labBLabel.Name = "labBLabel";
			this.labBLabel.Size = new System.Drawing.Size(16, 26);
			this.labBLabel.TabIndex = 4;
			this.labBLabel.Text = "b:";
			this.labBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// bMaskedTextBox
			// 
			this.bMaskedTextBox.Location = new System.Drawing.Point(25, 55);
			this.bMaskedTextBox.Name = "bMaskedTextBox";
			this.bMaskedTextBox.Size = new System.Drawing.Size(119, 20);
			this.bMaskedTextBox.TabIndex = 5;
			this.bMaskedTextBox.TextChanged += new System.EventHandler(this.genericLabMaskedTextBox_TextChanged);
			this.bMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.genericLabComponentMaskedTextBox_Validating);
			// 
			// colorDifferenceTableLayoutPanel
			// 
			this.colorDifferenceTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.colorDifferenceTableLayoutPanel.AutoSize = true;
			this.colorDifferenceTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.colorDifferenceTableLayoutPanel.ColumnCount = 2;
			this.colorDifferenceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.colorDifferenceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.colorDifferenceTableLayoutPanel.Controls.Add(this.colorDifferenceLabel, 0, 0);
			this.colorDifferenceTableLayoutPanel.Controls.Add(this.colorDifferenceValueLabel, 1, 0);
			this.colorDifferenceTableLayoutPanel.Location = new System.Drawing.Point(3, 353);
			this.colorDifferenceTableLayoutPanel.Name = "colorDifferenceTableLayoutPanel";
			this.colorDifferenceTableLayoutPanel.RowCount = 1;
			this.colorDifferenceTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.colorDifferenceTableLayoutPanel.Size = new System.Drawing.Size(142, 13);
			this.colorDifferenceTableLayoutPanel.TabIndex = 11;
			this.colorDifferenceTableLayoutPanel.Visible = false;
			// 
			// colorDifferenceLabel
			// 
			this.colorDifferenceLabel.AutoSize = true;
			this.colorDifferenceLabel.Location = new System.Drawing.Point(3, 0);
			this.colorDifferenceLabel.Name = "colorDifferenceLabel";
			this.colorDifferenceLabel.Size = new System.Drawing.Size(86, 13);
			this.colorDifferenceLabel.TabIndex = 0;
			this.colorDifferenceLabel.Text = "Color Difference:";
			// 
			// colorDifferenceValueLabel
			// 
			this.colorDifferenceValueLabel.AutoSize = true;
			this.colorDifferenceValueLabel.Location = new System.Drawing.Point(95, 0);
			this.colorDifferenceValueLabel.Name = "colorDifferenceValueLabel";
			this.colorDifferenceValueLabel.Size = new System.Drawing.Size(21, 13);
			this.colorDifferenceValueLabel.TabIndex = 1;
			this.colorDifferenceValueLabel.Text = "0%";
			// 
			// formOptionsContextMenuStrip
			// 
			this.formOptionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hsvToolStripMenuItem,
            this.rgbToolStripMenuItem,
            this.xyzToolStripMenuItem,
            this.labToolStripMenuItem});
			this.formOptionsContextMenuStrip.Name = "formOptionsContextMenuStrip";
			this.formOptionsContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.formOptionsContextMenuStrip.Size = new System.Drawing.Size(130, 92);
			// 
			// hsvToolStripMenuItem
			// 
			this.hsvToolStripMenuItem.Checked = true;
			this.hsvToolStripMenuItem.CheckOnClick = true;
			this.hsvToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.hsvToolStripMenuItem.Name = "hsvToolStripMenuItem";
			this.hsvToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.hsvToolStripMenuItem.Text = "HSV";
			this.hsvToolStripMenuItem.Click += new System.EventHandler(this.hsvToolStripMenuItem_Click);
			// 
			// rgbToolStripMenuItem
			// 
			this.rgbToolStripMenuItem.CheckOnClick = true;
			this.rgbToolStripMenuItem.Name = "rgbToolStripMenuItem";
			this.rgbToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.rgbToolStripMenuItem.Text = "RGB";
			this.rgbToolStripMenuItem.Click += new System.EventHandler(this.rgbToolStripMenuItem_Click);
			// 
			// xyzToolStripMenuItem
			// 
			this.xyzToolStripMenuItem.CheckOnClick = true;
			this.xyzToolStripMenuItem.Name = "xyzToolStripMenuItem";
			this.xyzToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.xyzToolStripMenuItem.Text = "CIE XYZ";
			this.xyzToolStripMenuItem.Click += new System.EventHandler(this.xyzToolStripMenuItem_Click);
			// 
			// labToolStripMenuItem
			// 
			this.labToolStripMenuItem.CheckOnClick = true;
			this.labToolStripMenuItem.Name = "labToolStripMenuItem";
			this.labToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.labToolStripMenuItem.Text = "CIE L*a*b*";
			this.labToolStripMenuItem.Click += new System.EventHandler(this.labToolStripMenuItem_Click);
			// 
			// stepHSVToolStripMenuItem
			// 
			this.stepHSVToolStripMenuItem.CheckOnClick = true;
			this.stepHSVToolStripMenuItem.Name = "stepHSVToolStripMenuItem";
			this.stepHSVToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.stepHSVToolStripMenuItem.Text = "HSV";
			this.stepHSVToolStripMenuItem.CheckedChanged += new System.EventHandler(this.genericStepColorSpaceToolStripMenuItem_CheckedChanged);
			// 
			// stepRGBToolStripMenuItem
			// 
			this.stepRGBToolStripMenuItem.CheckOnClick = true;
			this.stepRGBToolStripMenuItem.Name = "stepRGBToolStripMenuItem";
			this.stepRGBToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.stepRGBToolStripMenuItem.Text = "RGB";
			this.stepRGBToolStripMenuItem.CheckedChanged += new System.EventHandler(this.genericStepColorSpaceToolStripMenuItem_CheckedChanged);
			// 
			// stepXYZToolStripMenuItem
			// 
			this.stepXYZToolStripMenuItem.CheckOnClick = true;
			this.stepXYZToolStripMenuItem.Name = "stepXYZToolStripMenuItem";
			this.stepXYZToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.stepXYZToolStripMenuItem.Text = "CIE XYZ";
			this.stepXYZToolStripMenuItem.CheckedChanged += new System.EventHandler(this.genericStepColorSpaceToolStripMenuItem_CheckedChanged);
			// 
			// stepLabToolStripMenuItem
			// 
			this.stepLabToolStripMenuItem.Checked = true;
			this.stepLabToolStripMenuItem.CheckOnClick = true;
			this.stepLabToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.stepLabToolStripMenuItem.Name = "stepLabToolStripMenuItem";
			this.stepLabToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.stepLabToolStripMenuItem.Text = "CIE L*a*b*";
			this.stepLabToolStripMenuItem.CheckedChanged += new System.EventHandler(this.genericStepColorSpaceToolStripMenuItem_CheckedChanged);
			// 
			// storedColorsContextMenuStrip
			// 
			this.storedColorsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automaticallyUseSelectedColorAsActiveColorToolStripMenuItem,
            this.toolStripSeparator6,
            this.removeStoredColorToolStripMenuItem,
            this.replaceStoredColorWithActiveColorToolStripMenuItem,
            this.stepToActiveColorFromStoredColorToolStripMenuItem,
            this.useStoredColorAsActiveColorToolStripMenuItem,
            this.useStoredColorForComparisonToolStripMenuItem,
            this.toolStripSeparator2,
            this.switchToColorSelectModeToolStripMenuItem});
			this.storedColorsContextMenuStrip.Name = "storedColorsContextMenuStrip";
			this.storedColorsContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.storedColorsContextMenuStrip.Size = new System.Drawing.Size(307, 192);
			this.storedColorsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.storedColorsContextMenuStrip_Opening);
			// 
			// automaticallyUseSelectedColorAsActiveColorToolStripMenuItem
			// 
			this.automaticallyUseSelectedColorAsActiveColorToolStripMenuItem.Checked = true;
			this.automaticallyUseSelectedColorAsActiveColorToolStripMenuItem.CheckOnClick = true;
			this.automaticallyUseSelectedColorAsActiveColorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.automaticallyUseSelectedColorAsActiveColorToolStripMenuItem.Name = "automaticallyUseSelectedColorAsActiveColorToolStripMenuItem";
			this.automaticallyUseSelectedColorAsActiveColorToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
			this.automaticallyUseSelectedColorAsActiveColorToolStripMenuItem.Text = "Automatically Use Selected Color as Active Color";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(303, 6);
			// 
			// removeStoredColorToolStripMenuItem
			// 
			this.removeStoredColorToolStripMenuItem.Name = "removeStoredColorToolStripMenuItem";
			this.removeStoredColorToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
			this.removeStoredColorToolStripMenuItem.Text = "Remove Stored Color";
			this.removeStoredColorToolStripMenuItem.Click += new System.EventHandler(this.removeStoredColorToolStripMenuItem_Click);
			// 
			// replaceStoredColorWithActiveColorToolStripMenuItem
			// 
			this.replaceStoredColorWithActiveColorToolStripMenuItem.Name = "replaceStoredColorWithActiveColorToolStripMenuItem";
			this.replaceStoredColorWithActiveColorToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
			this.replaceStoredColorWithActiveColorToolStripMenuItem.Text = "Replace Stored Color with Active Color";
			this.replaceStoredColorWithActiveColorToolStripMenuItem.Click += new System.EventHandler(this.replaceStoredColorWithActiveColorToolStripMenuItem_Click);
			// 
			// stepToActiveColorFromStoredColorToolStripMenuItem
			// 
			this.stepToActiveColorFromStoredColorToolStripMenuItem.DropDown = this.steppingContextMenuStrip;
			this.stepToActiveColorFromStoredColorToolStripMenuItem.Name = "stepToActiveColorFromStoredColorToolStripMenuItem";
			this.stepToActiveColorFromStoredColorToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
			this.stepToActiveColorFromStoredColorToolStripMenuItem.Text = "Step to Active Color from Stored Color";
			// 
			// steppingContextMenuStrip
			// 
			this.steppingContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stepHSVToolStripMenuItem,
            this.stepRGBToolStripMenuItem,
            this.stepXYZToolStripMenuItem,
            this.stepLabToolStripMenuItem,
            this.toolStripSeparator5});
			this.steppingContextMenuStrip.Name = "steppingContextMenuStrip";
			this.steppingContextMenuStrip.OwnerItem = this.stepToActiveColorFromStoredColorToolStripMenuItem;
			this.steppingContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.steppingContextMenuStrip.Size = new System.Drawing.Size(130, 98);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
			// 
			// useStoredColorAsActiveColorToolStripMenuItem
			// 
			this.useStoredColorAsActiveColorToolStripMenuItem.Name = "useStoredColorAsActiveColorToolStripMenuItem";
			this.useStoredColorAsActiveColorToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
			this.useStoredColorAsActiveColorToolStripMenuItem.Text = "Use Stored Color as Active Color";
			this.useStoredColorAsActiveColorToolStripMenuItem.Click += new System.EventHandler(this.useStoredColorAsActiveColorToolStripMenuItem_Click);
			// 
			// useStoredColorForComparisonToolStripMenuItem
			// 
			this.useStoredColorForComparisonToolStripMenuItem.Name = "useStoredColorForComparisonToolStripMenuItem";
			this.useStoredColorForComparisonToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
			this.useStoredColorForComparisonToolStripMenuItem.Text = "Use Stored Color for Comparison";
			this.useStoredColorForComparisonToolStripMenuItem.Click += new System.EventHandler(this.useStoredColorForComparisonToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(303, 6);
			// 
			// switchToColorSelectModeToolStripMenuItem
			// 
			this.switchToColorSelectModeToolStripMenuItem.Name = "switchToColorSelectModeToolStripMenuItem";
			this.switchToColorSelectModeToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
			this.switchToColorSelectModeToolStripMenuItem.Text = "Switch to Color Select Mode";
			this.switchToColorSelectModeToolStripMenuItem.Click += new System.EventHandler(this.switchToColorSelectModeToolStripMenuItem_Click);
			// 
			// buttonsPanel
			// 
			this.buttonsPanel.BackColor = System.Drawing.Color.Transparent;
			this.buttonsPanel.Controls.Add(this.colorComparisonFlowLayoutPanel);
			this.buttonsPanel.Controls.Add(this.okButton);
			this.buttonsPanel.Controls.Add(this.cancelButton);
			this.buttonsPanel.Controls.Add(this.helpButton);
			this.buttonsPanel.Location = new System.Drawing.Point(3, 3);
			this.buttonsPanel.Name = "buttonsPanel";
			this.buttonsPanel.Size = new System.Drawing.Size(147, 96);
			this.buttonsPanel.TabIndex = 13;
			// 
			// primaryTableLayoutPanel
			// 
			this.primaryTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.primaryTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
			this.primaryTableLayoutPanel.ColumnCount = 2;
			this.primaryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.primaryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
			this.primaryTableLayoutPanel.Controls.Add(this.selectColorLabel, 0, 0);
			this.primaryTableLayoutPanel.Controls.Add(this.simpleOpenGlControl, 0, 1);
			this.primaryTableLayoutPanel.Controls.Add(this.componentOptionsAndButtonsTableLayoutPanel, 1, 0);
			this.primaryTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.primaryTableLayoutPanel.Name = "primaryTableLayoutPanel";
			this.primaryTableLayoutPanel.RowCount = 2;
			this.primaryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.primaryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.primaryTableLayoutPanel.Size = new System.Drawing.Size(436, 262);
			this.primaryTableLayoutPanel.TabIndex = 14;
			// 
			// componentOptionsAndButtonsTableLayoutPanel
			// 
			this.componentOptionsAndButtonsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.componentOptionsAndButtonsTableLayoutPanel.AutoSize = true;
			this.componentOptionsAndButtonsTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.componentOptionsAndButtonsTableLayoutPanel.ColumnCount = 1;
			this.componentOptionsAndButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.componentOptionsAndButtonsTableLayoutPanel.Controls.Add(this.colorSpaceAndOptionsTableLayoutPanel, 0, 1);
			this.componentOptionsAndButtonsTableLayoutPanel.Controls.Add(this.buttonsPanel, 0, 0);
			this.componentOptionsAndButtonsTableLayoutPanel.Location = new System.Drawing.Point(279, 3);
			this.componentOptionsAndButtonsTableLayoutPanel.Name = "componentOptionsAndButtonsTableLayoutPanel";
			this.componentOptionsAndButtonsTableLayoutPanel.RowCount = 2;
			this.primaryTableLayoutPanel.SetRowSpan(this.componentOptionsAndButtonsTableLayoutPanel, 2);
			this.componentOptionsAndButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.componentOptionsAndButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.componentOptionsAndButtonsTableLayoutPanel.Size = new System.Drawing.Size(154, 256);
			this.componentOptionsAndButtonsTableLayoutPanel.TabIndex = 15;
			// 
			// ColorControl
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(433, 284);
			this.ContextMenuStrip = this.formOptionsContextMenuStrip;
			this.Controls.Add(this.primaryTableLayoutPanel);
			this.Controls.Add(this.statusStrip);
			this.DoubleBuffered = true;
			this.MinimumSize = new System.Drawing.Size(441, 311);
			this.Name = "ColorControl";
			this.ShowIcon = false;
			this.Text = "Color Select";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColorControl_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ColorControl_FormClosed);
			this.Load += new System.EventHandler(this.ColorControl_Load);
			this.colorSelectContextMenuStrip.ResumeLayout(false);
			this.colorComparisonFlowLayoutPanel.ResumeLayout(false);
			this.colorSpaceAndOptionsTableLayoutPanel.ResumeLayout(false);
			this.colorSpaceAndOptionsTableLayoutPanel.PerformLayout();
			this.colorSpaceFlowLayoutPanel.ResumeLayout(false);
			this.colorSpaceFlowLayoutPanel.PerformLayout();
			this.hsvTableLayoutPanel.ResumeLayout(false);
			this.hsvTableLayoutPanel.PerformLayout();
			this.rgbTableLayoutPanel.ResumeLayout(false);
			this.rgbTableLayoutPanel.PerformLayout();
			this.xyzTableLayoutPanel.ResumeLayout(false);
			this.xyzTableLayoutPanel.PerformLayout();
			this.labTableLayoutPanel.ResumeLayout(false);
			this.labTableLayoutPanel.PerformLayout();
			this.colorDifferenceTableLayoutPanel.ResumeLayout(false);
			this.colorDifferenceTableLayoutPanel.PerformLayout();
			this.formOptionsContextMenuStrip.ResumeLayout(false);
			this.storedColorsContextMenuStrip.ResumeLayout(false);
			this.steppingContextMenuStrip.ResumeLayout(false);
			this.buttonsPanel.ResumeLayout(false);
			this.primaryTableLayoutPanel.ResumeLayout(false);
			this.primaryTableLayoutPanel.PerformLayout();
			this.componentOptionsAndButtonsTableLayoutPanel.ResumeLayout(false);
			this.componentOptionsAndButtonsTableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.Panel colorDisplayPanel;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button helpButton;
		private System.Windows.Forms.Label selectColorLabel;
		private System.Windows.Forms.FlowLayoutPanel colorComparisonFlowLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel colorSpaceAndOptionsTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel colorSpaceFlowLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel hsvTableLayoutPanel;
		private System.Windows.Forms.MaskedTextBox hueMaskedTextBox;
		private System.Windows.Forms.MaskedTextBox saturationMaskedTextBox;
		private System.Windows.Forms.MaskedTextBox valueMaskedTextBox;
		private System.Windows.Forms.Label hueLabel;
		private System.Windows.Forms.Label saturationLabel;
		private System.Windows.Forms.Label valueLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TableLayoutPanel colorDifferenceTableLayoutPanel;
		private System.Windows.Forms.Label colorDifferenceLabel;
		private System.Windows.Forms.Label colorDifferenceValueLabel;
		private System.Windows.Forms.ContextMenuStrip formOptionsContextMenuStrip;
		private System.Windows.Forms.ContextMenuStrip colorSelectContextMenuStrip;
		private System.Windows.Forms.ContextMenuStrip storedColorsContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem hsvToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rgbToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xyzToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem labToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stepHSVToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stepRGBToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stepXYZToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stepLabToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem storeColorToPaletteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem switchToPaletteModeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeStoredColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem switchToColorSelectModeToolStripMenuItem;
		private System.Windows.Forms.Panel buttonsPanel;
		private System.Windows.Forms.TableLayoutPanel primaryTableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel componentOptionsAndButtonsTableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel rgbTableLayoutPanel;
		private System.Windows.Forms.Label rLabel;
		private System.Windows.Forms.MaskedTextBox rValueMaskedTextBox;
		private System.Windows.Forms.Label gLabel;
		private System.Windows.Forms.MaskedTextBox gValueMaskedTextBox;
		private System.Windows.Forms.Label bLabel;
		private System.Windows.Forms.MaskedTextBox bValueMaskedTextBox;
		private System.Windows.Forms.TableLayoutPanel xyzTableLayoutPanel;
		private System.Windows.Forms.Label xLabel;
		private System.Windows.Forms.MaskedTextBox xValueMaskedTextBox;
		private System.Windows.Forms.Label yLabel;
		private System.Windows.Forms.MaskedTextBox yValueMaskedTextBox;
		private System.Windows.Forms.Label zLabel;
		private System.Windows.Forms.MaskedTextBox zValueMaskedTextBox;
		private System.Windows.Forms.TableLayoutPanel labTableLayoutPanel;
		private System.Windows.Forms.Label LLabel;
		private System.Windows.Forms.MaskedTextBox LMaskedTextBox;
		private System.Windows.Forms.Label aLabel;
		private System.Windows.Forms.MaskedTextBox aMaskedTextBox;
		private System.Windows.Forms.Label labBLabel;
		private System.Windows.Forms.MaskedTextBox bMaskedTextBox;
		private System.Windows.Forms.ToolStripMenuItem storeColorForComparisonToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem clearComparisonColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoCompareOnStoreToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem replaceStoredColorWithActiveColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem useStoredColorForComparisonToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem useStoredColorAsActiveColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stepToActiveColorFromStoredColorToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip steppingContextMenuStrip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem automaticallyUseSelectedColorAsActiveColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
	}
}

