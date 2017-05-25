#pragma warning disable
namespace SpriteAnimator
{
    partial class Main
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
                AC.Dispose();
                // Make sure timers are gone.
                if (scanFileChanges != null)
                    scanFileChanges.Dispose();
                if (scanFormatFileChanges != null)
                    scanFormatFileChanges.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.basePanel = new System.Windows.Forms.Panel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.renderControlPanel = new System.Windows.Forms.Panel();
            this.RenderControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.displayButtonPanel = new SpriteAnimator.ButtonPanel(this.components);
            this.displayTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ghostPreviousYesOrNo = new System.Windows.Forms.CheckBox();
            this.ghostNextYesOrNo = new System.Windows.Forms.CheckBox();
            this.drawFrameNumberYesOrNo = new System.Windows.Forms.CheckBox();
            this.transparentBackgroundYesOrNo = new System.Windows.Forms.CheckBox();
            this.drawFrameYesOrNo = new System.Windows.Forms.CheckBox();
            this.keepAspectRatioYesOrNo = new System.Windows.Forms.CheckBox();
            this.autoUpdateYesOrNo = new System.Windows.Forms.CheckBox();
            this.autoUpdateOnFormatChange = new System.Windows.Forms.CheckBox();
            this.useNoSamplingCheckBox = new System.Windows.Forms.CheckBox();
            this.lineWidthLabel = new System.Windows.Forms.Label();
            this.lineWidth = new System.Windows.Forms.NumericUpDown();
            this.rawImageColorOverlayPanel = new System.Windows.Forms.Panel();
            this.rawImageOverlayLabel = new System.Windows.Forms.Label();
            this.colorSwatch = new System.Windows.Forms.Panel();
            this.showAudioWaveForm = new System.Windows.Forms.CheckBox();
            this.ignoreAudio = new System.Windows.Forms.CheckBox();
            this.animationPanel = new System.Windows.Forms.Panel();
            this.animationButtonPanel = new SpriteAnimator.ButtonPanel(this.components);
            this.animationTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.animationYesOrNo = new System.Windows.Forms.CheckBox();
            this.animateByNamedSetRadioButton = new System.Windows.Forms.RadioButton();
            this.namedSetComboBox = new System.Windows.Forms.ComboBox();
            this.animateByRangeRadioButton = new System.Windows.Forms.RadioButton();
            this.startFrameLabel = new System.Windows.Forms.Label();
            this.endFrameLabel = new System.Windows.Forms.Label();
            this.targetMillisecondsLabel = new System.Windows.Forms.Label();
            this.animationTargetStartFrame = new System.Windows.Forms.NumericUpDown();
            this.animationTargetEndFrame = new System.Windows.Forms.NumericUpDown();
            this.animationTargetMS = new System.Windows.Forms.NumericUpDown();
            this.subdivisionPanel = new System.Windows.Forms.Panel();
            this.subdivisionButtonPanel = new SpriteAnimator.ButtonPanel(this.components);
            this.subdivisionTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.numberRows = new System.Windows.Forms.NumericUpDown();
            this.columnsLabel = new System.Windows.Forms.Label();
            this.numberColumns = new System.Windows.Forms.NumericUpDown();
            this.maxCellsLabel = new System.Windows.Forms.Label();
            this.numberMaxCells = new System.Windows.Forms.NumericUpDown();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportActiveFramesAsGIFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneHundredPercentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoHundredPercentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customPercentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customPercentToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.formatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beginNewFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editLoadedFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.availableFormatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.constructedPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.availableAttachmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuFillerToolStripSpringTextBox = new ToolStripSpringTextBox();
            this.rendererLabelToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.rendererToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.spriteSheetOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.previewAreaContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editSelectedFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usePreviousFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipFrameHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basePanel.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.renderControlPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.optionsTableLayoutPanel.SuspendLayout();
            this.displayPanel.SuspendLayout();
            this.displayTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidth)).BeginInit();
            this.rawImageColorOverlayPanel.SuspendLayout();
            this.animationPanel.SuspendLayout();
            this.animationTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationTargetStartFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationTargetEndFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationTargetMS)).BeginInit();
            this.subdivisionPanel.SuspendLayout();
            this.subdivisionTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberMaxCells)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.previewAreaContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.basePanel.BackColor = System.Drawing.Color.Transparent;
            this.basePanel.Controls.Add(this.toolStripContainer1);
            this.basePanel.Location = new System.Drawing.Point(0, 0);
            this.basePanel.Name = "basePanel";
            this.basePanel.Size = new System.Drawing.Size(884, 575);
            this.basePanel.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip);
            this.toolStripContainer1.BottomToolStripPanel.MinimumSize = new System.Drawing.Size(0, 30);
            this.toolStripContainer1.BottomToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.bottomPanel);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(884, 528);
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.toolStripContainer1.RightToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripContainer1.Size = new System.Drawing.Size(884, 583);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainMenuStrip);
            this.toolStripContainer1.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // statusStrip
            // 
            this.statusStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip.AutoSize = false;
            this.statusStrip.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.MinimumSize = new System.Drawing.Size(0, 30);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(884, 30);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 2;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 20, 2);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripStatusLabel.Size = new System.Drawing.Size(38, 25);
            this.toolStripStatusLabel.Text = "Ready";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.Controls.Add(this.renderControlPanel);
            this.bottomPanel.Controls.Add(this.optionsPanel);
            this.bottomPanel.Location = new System.Drawing.Point(0, 0);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(884, 527);
            this.bottomPanel.TabIndex = 1;
            // 
            // renderControlPanel
            // 
            this.renderControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renderControlPanel.Controls.Add(this.RenderControl);
            this.renderControlPanel.Location = new System.Drawing.Point(200, 0);
            this.renderControlPanel.Name = "renderControlPanel";
            this.renderControlPanel.Size = new System.Drawing.Size(684, 525);
            this.renderControlPanel.TabIndex = 1;
            // 
            // RenderControl
            // 
            this.RenderControl.AccumBits = ((byte)(0));
            this.RenderControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RenderControl.AutoCheckErrors = false;
            this.RenderControl.AutoFinish = false;
            this.RenderControl.AutoMakeCurrent = true;
            this.RenderControl.AutoSwapBuffers = true;
            this.RenderControl.BackColor = System.Drawing.Color.Black;
            this.RenderControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RenderControl.BackgroundImage")));
            this.RenderControl.ColorBits = ((byte)(32));
            this.RenderControl.DepthBits = ((byte)(16));
            this.RenderControl.Location = new System.Drawing.Point(0, 0);
            this.RenderControl.Name = "RenderControl";
            this.RenderControl.Size = new System.Drawing.Size(684, 527);
            this.RenderControl.StencilBits = ((byte)(0));
            this.RenderControl.TabIndex = 0;
            this.RenderControl.VSync = false;
            this.RenderControl.Load += new System.EventHandler(this.RenderControl_Load);
            this.RenderControl.Paint += new System.Windows.Forms.PaintEventHandler(this.RenderControl_Paint);
            this.RenderControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RenderControl_KeyDown);
            this.RenderControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RenderControl_KeyPress);
            this.RenderControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RenderControl_MouseClick);
            this.RenderControl.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.RenderControl_PreviewKeyDown);
            this.RenderControl.Resize += new System.EventHandler(this.RenderControl_Resize);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.optionsPanel.AutoScroll = true;
            this.optionsPanel.BackColor = System.Drawing.Color.Transparent;
            this.optionsPanel.Controls.Add(this.optionsTableLayoutPanel);
            this.optionsPanel.Location = new System.Drawing.Point(0, 198);
            this.optionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.optionsPanel.Size = new System.Drawing.Size(200, 327);
            this.optionsPanel.TabIndex = 0;
            this.optionsPanel.Tag = "";
            // 
            // optionsTableLayoutPanel
            // 
            this.optionsTableLayoutPanel.AutoScroll = true;
            this.optionsTableLayoutPanel.BackColor = System.Drawing.Color.SlateGray;
            this.optionsTableLayoutPanel.ColumnCount = 2;
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.54348F));
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.45652F));
            this.optionsTableLayoutPanel.Controls.Add(this.displayPanel, 0, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.displayTableLayoutPanel, 0, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.animationPanel, 0, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.animationTableLayoutPanel, 0, 3);
            this.optionsTableLayoutPanel.Controls.Add(this.subdivisionPanel, 0, 4);
            this.optionsTableLayoutPanel.Controls.Add(this.subdivisionTableLayoutPanel, 0, 5);
            this.optionsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.optionsTableLayoutPanel.Name = "optionsTableLayoutPanel";
            this.optionsTableLayoutPanel.RowCount = 7;
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 306F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optionsTableLayoutPanel.Size = new System.Drawing.Size(182, 630);
            this.optionsTableLayoutPanel.TabIndex = 20;
            // 
            // displayPanel
            // 
            this.displayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayPanel.BackColor = System.Drawing.Color.Transparent;
            this.optionsTableLayoutPanel.SetColumnSpan(this.displayPanel, 2);
            this.displayPanel.Controls.Add(this.displayButtonPanel);
            this.displayPanel.Location = new System.Drawing.Point(0, 0);
            this.displayPanel.Margin = new System.Windows.Forms.Padding(0);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(182, 20);
            this.displayPanel.TabIndex = 33;
            // 
            // displayButtonPanel
            // 
            this.displayButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayButtonPanel.BackColor = System.Drawing.SystemColors.Control;
            this.displayButtonPanel.BorderColor = System.Drawing.Color.SlateGray;
            this.displayButtonPanel.BorderWidth = 2;
            this.displayButtonPanel.ColorSteps = 11D;
            this.displayButtonPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButtonPanel.GradientColor = System.Drawing.Color.Silver;
            this.displayButtonPanel.HoverGradientColor = System.Drawing.Color.LightSlateGray;
            this.displayButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.displayButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.displayButtonPanel.Name = "displayButtonPanel";
            this.displayButtonPanel.Size = new System.Drawing.Size(182, 20);
            this.displayButtonPanel.TabIndex = 25;
            this.displayButtonPanel.Title = "Display";
            this.displayButtonPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.displaySettingsButtonPanel_MouseClick);
            this.displayButtonPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.displaySettingsButtonPanel_MouseDoubleClick);
            // 
            // displayTableLayoutPanel
            // 
            this.displayTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayTableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.displayTableLayoutPanel.ColumnCount = 2;
            this.optionsTableLayoutPanel.SetColumnSpan(this.displayTableLayoutPanel, 2);
            this.displayTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.displayTableLayoutPanel.Controls.Add(this.ghostPreviousYesOrNo, 0, 0);
            this.displayTableLayoutPanel.Controls.Add(this.ghostNextYesOrNo, 0, 1);
            this.displayTableLayoutPanel.Controls.Add(this.drawFrameNumberYesOrNo, 0, 2);
            this.displayTableLayoutPanel.Controls.Add(this.transparentBackgroundYesOrNo, 0, 3);
            this.displayTableLayoutPanel.Controls.Add(this.drawFrameYesOrNo, 0, 4);
            this.displayTableLayoutPanel.Controls.Add(this.keepAspectRatioYesOrNo, 0, 5);
            this.displayTableLayoutPanel.Controls.Add(this.autoUpdateYesOrNo, 0, 6);
            this.displayTableLayoutPanel.Controls.Add(this.autoUpdateOnFormatChange, 0, 7);
            this.displayTableLayoutPanel.Controls.Add(this.useNoSamplingCheckBox, 0, 8);
            this.displayTableLayoutPanel.Controls.Add(this.lineWidthLabel, 0, 12);
            this.displayTableLayoutPanel.Controls.Add(this.lineWidth, 1, 12);
            this.displayTableLayoutPanel.Controls.Add(this.rawImageColorOverlayPanel, 0, 11);
            this.displayTableLayoutPanel.Controls.Add(this.showAudioWaveForm, 0, 9);
            this.displayTableLayoutPanel.Controls.Add(this.ignoreAudio, 0, 10);
            this.displayTableLayoutPanel.Location = new System.Drawing.Point(1, 20);
            this.displayTableLayoutPanel.Margin = new System.Windows.Forms.Padding(1, 0, 2, 1);
            this.displayTableLayoutPanel.Name = "displayTableLayoutPanel";
            this.displayTableLayoutPanel.RowCount = 14;
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.displayTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.displayTableLayoutPanel.Size = new System.Drawing.Size(179, 305);
            this.displayTableLayoutPanel.TabIndex = 29;
            // 
            // ghostPreviousYesOrNo
            // 
            this.ghostPreviousYesOrNo.AutoSize = true;
            this.displayTableLayoutPanel.SetColumnSpan(this.ghostPreviousYesOrNo, 2);
            this.ghostPreviousYesOrNo.Location = new System.Drawing.Point(3, 3);
            this.ghostPreviousYesOrNo.Name = "ghostPreviousYesOrNo";
            this.ghostPreviousYesOrNo.Size = new System.Drawing.Size(130, 17);
            this.ghostPreviousYesOrNo.TabIndex = 6;
            this.ghostPreviousYesOrNo.Text = "Ghost Previous Frame";
            this.ghostPreviousYesOrNo.UseVisualStyleBackColor = true;
            this.ghostPreviousYesOrNo.CheckedChanged += new System.EventHandler(this.ghost_CheckedChanged);
            // 
            // ghostNextYesOrNo
            // 
            this.ghostNextYesOrNo.AutoSize = true;
            this.displayTableLayoutPanel.SetColumnSpan(this.ghostNextYesOrNo, 2);
            this.ghostNextYesOrNo.Location = new System.Drawing.Point(3, 26);
            this.ghostNextYesOrNo.Name = "ghostNextYesOrNo";
            this.ghostNextYesOrNo.Size = new System.Drawing.Size(111, 17);
            this.ghostNextYesOrNo.TabIndex = 7;
            this.ghostNextYesOrNo.Text = "Ghost Next Frame";
            this.ghostNextYesOrNo.UseVisualStyleBackColor = true;
            this.ghostNextYesOrNo.CheckedChanged += new System.EventHandler(this.ghost_CheckedChanged);
            // 
            // drawFrameNumberYesOrNo
            // 
            this.drawFrameNumberYesOrNo.AutoSize = true;
            this.displayTableLayoutPanel.SetColumnSpan(this.drawFrameNumberYesOrNo, 2);
            this.drawFrameNumberYesOrNo.Location = new System.Drawing.Point(3, 49);
            this.drawFrameNumberYesOrNo.Name = "drawFrameNumberYesOrNo";
            this.drawFrameNumberYesOrNo.Size = new System.Drawing.Size(167, 17);
            this.drawFrameNumberYesOrNo.TabIndex = 3;
            this.drawFrameNumberYesOrNo.Text = "Frame Number on Raw Image";
            this.drawFrameNumberYesOrNo.UseVisualStyleBackColor = true;
            this.drawFrameNumberYesOrNo.CheckedChanged += new System.EventHandler(this.drawFrameNumberYesOrNo_CheckedChanged);
            // 
            // transparentBackgroundYesOrNo
            // 
            this.transparentBackgroundYesOrNo.AutoSize = true;
            this.displayTableLayoutPanel.SetColumnSpan(this.transparentBackgroundYesOrNo, 2);
            this.transparentBackgroundYesOrNo.Location = new System.Drawing.Point(3, 72);
            this.transparentBackgroundYesOrNo.Name = "transparentBackgroundYesOrNo";
            this.transparentBackgroundYesOrNo.Size = new System.Drawing.Size(144, 17);
            this.transparentBackgroundYesOrNo.TabIndex = 8;
            this.transparentBackgroundYesOrNo.Text = "Transparent Background";
            this.transparentBackgroundYesOrNo.UseVisualStyleBackColor = true;
            this.transparentBackgroundYesOrNo.CheckedChanged += new System.EventHandler(this.transparentBackgroundYesOrNo_CheckedChanged);
            // 
            // drawFrameYesOrNo
            // 
            this.drawFrameYesOrNo.AutoSize = true;
            this.drawFrameYesOrNo.Checked = true;
            this.drawFrameYesOrNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayTableLayoutPanel.SetColumnSpan(this.drawFrameYesOrNo, 2);
            this.drawFrameYesOrNo.Location = new System.Drawing.Point(3, 95);
            this.drawFrameYesOrNo.Name = "drawFrameYesOrNo";
            this.drawFrameYesOrNo.Size = new System.Drawing.Size(149, 17);
            this.drawFrameYesOrNo.TabIndex = 2;
            this.drawFrameYesOrNo.Text = "Frame Around Raw Image";
            this.drawFrameYesOrNo.UseVisualStyleBackColor = true;
            this.drawFrameYesOrNo.CheckedChanged += new System.EventHandler(this.drawFrameYesOrNo_CheckedChanged);
            // 
            // keepAspectRatioYesOrNo
            // 
            this.keepAspectRatioYesOrNo.AutoSize = true;
            this.displayTableLayoutPanel.SetColumnSpan(this.keepAspectRatioYesOrNo, 2);
            this.keepAspectRatioYesOrNo.Location = new System.Drawing.Point(3, 118);
            this.keepAspectRatioYesOrNo.Name = "keepAspectRatioYesOrNo";
            this.keepAspectRatioYesOrNo.Size = new System.Drawing.Size(165, 17);
            this.keepAspectRatioYesOrNo.TabIndex = 5;
            this.keepAspectRatioYesOrNo.Text = "Keep Aspect Ratio on Resize";
            this.keepAspectRatioYesOrNo.UseVisualStyleBackColor = true;
            this.keepAspectRatioYesOrNo.CheckedChanged += new System.EventHandler(this.keepAspectRatioYesOrNo_CheckedChanged);
            // 
            // autoUpdateYesOrNo
            // 
            this.autoUpdateYesOrNo.AutoSize = true;
            this.autoUpdateYesOrNo.Checked = true;
            this.autoUpdateYesOrNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayTableLayoutPanel.SetColumnSpan(this.autoUpdateYesOrNo, 2);
            this.autoUpdateYesOrNo.Location = new System.Drawing.Point(3, 141);
            this.autoUpdateYesOrNo.Name = "autoUpdateYesOrNo";
            this.autoUpdateYesOrNo.Size = new System.Drawing.Size(160, 17);
            this.autoUpdateYesOrNo.TabIndex = 1;
            this.autoUpdateYesOrNo.Text = "Auto-Update on File Change";
            this.autoUpdateYesOrNo.UseVisualStyleBackColor = true;
            // 
            // autoUpdateOnFormatChange
            // 
            this.autoUpdateOnFormatChange.AutoSize = true;
            this.displayTableLayoutPanel.SetColumnSpan(this.autoUpdateOnFormatChange, 2);
            this.autoUpdateOnFormatChange.Location = new System.Drawing.Point(3, 164);
            this.autoUpdateOnFormatChange.Name = "autoUpdateOnFormatChange";
            this.autoUpdateOnFormatChange.Size = new System.Drawing.Size(173, 17);
            this.autoUpdateOnFormatChange.TabIndex = 12;
            this.autoUpdateOnFormatChange.Text = "Auto-Update on Format Change";
            this.autoUpdateOnFormatChange.UseVisualStyleBackColor = true;
            // 
            // useNoSamplingCheckBox
            // 
            this.useNoSamplingCheckBox.AutoSize = true;
            this.displayTableLayoutPanel.SetColumnSpan(this.useNoSamplingCheckBox, 2);
            this.useNoSamplingCheckBox.Location = new System.Drawing.Point(3, 187);
            this.useNoSamplingCheckBox.Name = "useNoSamplingCheckBox";
            this.useNoSamplingCheckBox.Size = new System.Drawing.Size(108, 17);
            this.useNoSamplingCheckBox.TabIndex = 13;
            this.useNoSamplingCheckBox.Text = "Use No Sampling";
            this.useNoSamplingCheckBox.UseVisualStyleBackColor = true;
            this.useNoSamplingCheckBox.CheckedChanged += new System.EventHandler(this.useNoSamplingCheckBox_CheckedChanged);
            // 
            // lineWidthLabel
            // 
            this.lineWidthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lineWidthLabel.AutoSize = true;
            this.lineWidthLabel.Location = new System.Drawing.Point(3, 284);
            this.lineWidthLabel.Name = "lineWidthLabel";
            this.lineWidthLabel.Size = new System.Drawing.Size(83, 13);
            this.lineWidthLabel.TabIndex = 10;
            this.lineWidthLabel.Text = "Line Width:";
            this.lineWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineWidth
            // 
            this.lineWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lineWidth.Location = new System.Drawing.Point(92, 281);
            this.lineWidth.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.lineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineWidth.Name = "lineWidth";
            this.lineWidth.Size = new System.Drawing.Size(84, 20);
            this.lineWidth.TabIndex = 9;
            this.lineWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // rawImageColorOverlayPanel
            // 
            this.rawImageColorOverlayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawImageColorOverlayPanel.Controls.Add(this.rawImageOverlayLabel);
            this.rawImageColorOverlayPanel.Controls.Add(this.colorSwatch);
            this.rawImageColorOverlayPanel.Location = new System.Drawing.Point(3, 256);
            this.rawImageColorOverlayPanel.MinimumSize = new System.Drawing.Size(150, 19);
            this.rawImageColorOverlayPanel.Name = "rawImageColorOverlayPanel";
            this.rawImageColorOverlayPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.rawImageColorOverlayPanel.Size = new System.Drawing.Size(150, 19);
            this.rawImageColorOverlayPanel.TabIndex = 1;
            this.rawImageColorOverlayPanel.Click += new System.EventHandler(this.frameOverlayColorSwatch_Click);
            // 
            // rawImageOverlayLabel
            // 
            this.rawImageOverlayLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rawImageOverlayLabel.AutoSize = true;
            this.rawImageOverlayLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rawImageOverlayLabel.Location = new System.Drawing.Point(16, 0);
            this.rawImageOverlayLabel.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.rawImageOverlayLabel.Name = "rawImageOverlayLabel";
            this.rawImageOverlayLabel.Size = new System.Drawing.Size(105, 13);
            this.rawImageOverlayLabel.TabIndex = 11;
            this.rawImageOverlayLabel.Text = "Raw Image Overlays";
            this.rawImageOverlayLabel.Click += new System.EventHandler(this.frameOverlayColorSwatch_Click);
            // 
            // colorSwatch
            // 
            this.colorSwatch.BackColor = System.Drawing.Color.Yellow;
            this.colorSwatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.colorSwatch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorSwatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorSwatch.Location = new System.Drawing.Point(0, 1);
            this.colorSwatch.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.colorSwatch.MaximumSize = new System.Drawing.Size(13, 13);
            this.colorSwatch.MinimumSize = new System.Drawing.Size(13, 13);
            this.colorSwatch.Name = "colorSwatch";
            this.colorSwatch.Size = new System.Drawing.Size(13, 13);
            this.colorSwatch.TabIndex = 10;
            this.colorSwatch.Click += new System.EventHandler(this.frameOverlayColorSwatch_Click);
            // 
            // showAudioWaveForm
            // 
            this.showAudioWaveForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showAudioWaveForm.AutoSize = true;
            this.showAudioWaveForm.Checked = true;
            this.showAudioWaveForm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayTableLayoutPanel.SetColumnSpan(this.showAudioWaveForm, 2);
            this.showAudioWaveForm.Location = new System.Drawing.Point(3, 210);
            this.showAudioWaveForm.Name = "showAudioWaveForm";
            this.showAudioWaveForm.Size = new System.Drawing.Size(173, 17);
            this.showAudioWaveForm.TabIndex = 14;
            this.showAudioWaveForm.Text = "Show Audio WaveForm";
            this.showAudioWaveForm.UseVisualStyleBackColor = true;
            this.showAudioWaveForm.CheckedChanged += new System.EventHandler(this.showAudioWaveForm_CheckedChanged);
            // 
            // ignoreAudio
            // 
            this.ignoreAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ignoreAudio.AutoSize = true;
            this.ignoreAudio.Checked = true;
            this.ignoreAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayTableLayoutPanel.SetColumnSpan(this.ignoreAudio, 2);
            this.ignoreAudio.Location = new System.Drawing.Point(3, 233);
            this.ignoreAudio.Name = "ignoreAudio";
            this.ignoreAudio.Size = new System.Drawing.Size(173, 17);
            this.ignoreAudio.TabIndex = 15;
            this.ignoreAudio.Text = "Ignore Audio";
            this.ignoreAudio.UseVisualStyleBackColor = true;
            // 
            // animationPanel
            // 
            this.animationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationPanel.BackColor = System.Drawing.Color.Transparent;
            this.optionsTableLayoutPanel.SetColumnSpan(this.animationPanel, 2);
            this.animationPanel.Controls.Add(this.animationButtonPanel);
            this.animationPanel.Location = new System.Drawing.Point(0, 326);
            this.animationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.animationPanel.Name = "animationPanel";
            this.animationPanel.Size = new System.Drawing.Size(182, 20);
            this.animationPanel.TabIndex = 32;
            // 
            // animationButtonPanel
            // 
            this.animationButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationButtonPanel.BackColor = System.Drawing.SystemColors.Control;
            this.animationButtonPanel.BorderColor = System.Drawing.Color.SlateGray;
            this.animationButtonPanel.BorderWidth = 2;
            this.animationButtonPanel.ColorSteps = 11D;
            this.animationButtonPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animationButtonPanel.GradientColor = System.Drawing.Color.Silver;
            this.animationButtonPanel.HoverGradientColor = System.Drawing.Color.LightSlateGray;
            this.animationButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.animationButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.animationButtonPanel.Name = "animationButtonPanel";
            this.animationButtonPanel.Size = new System.Drawing.Size(182, 20);
            this.animationButtonPanel.TabIndex = 26;
            this.animationButtonPanel.Title = "Animation";
            this.animationButtonPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.animationButtonPanel_MouseClick);
            this.animationButtonPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.animationButtonPanel_MouseDoubleClick);
            // 
            // animationTableLayoutPanel
            // 
            this.animationTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationTableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.animationTableLayoutPanel.ColumnCount = 2;
            this.optionsTableLayoutPanel.SetColumnSpan(this.animationTableLayoutPanel, 2);
            this.animationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.animationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.animationTableLayoutPanel.Controls.Add(this.animationYesOrNo, 0, 0);
            this.animationTableLayoutPanel.Controls.Add(this.animateByNamedSetRadioButton, 0, 1);
            this.animationTableLayoutPanel.Controls.Add(this.namedSetComboBox, 0, 2);
            this.animationTableLayoutPanel.Controls.Add(this.animateByRangeRadioButton, 0, 3);
            this.animationTableLayoutPanel.Controls.Add(this.startFrameLabel, 0, 4);
            this.animationTableLayoutPanel.Controls.Add(this.endFrameLabel, 0, 5);
            this.animationTableLayoutPanel.Controls.Add(this.targetMillisecondsLabel, 0, 6);
            this.animationTableLayoutPanel.Controls.Add(this.animationTargetStartFrame, 1, 4);
            this.animationTableLayoutPanel.Controls.Add(this.animationTargetEndFrame, 1, 5);
            this.animationTableLayoutPanel.Controls.Add(this.animationTargetMS, 1, 6);
            this.animationTableLayoutPanel.Location = new System.Drawing.Point(1, 346);
            this.animationTableLayoutPanel.Margin = new System.Windows.Forms.Padding(1, 0, 2, 1);
            this.animationTableLayoutPanel.Name = "animationTableLayoutPanel";
            this.animationTableLayoutPanel.RowCount = 7;
            this.animationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.animationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.animationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.animationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.animationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.animationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.animationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.animationTableLayoutPanel.Size = new System.Drawing.Size(179, 179);
            this.animationTableLayoutPanel.TabIndex = 28;
            // 
            // animationYesOrNo
            // 
            this.animationYesOrNo.AutoSize = true;
            this.animationYesOrNo.Checked = true;
            this.animationYesOrNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.animationTableLayoutPanel.SetColumnSpan(this.animationYesOrNo, 2);
            this.animationYesOrNo.Location = new System.Drawing.Point(3, 3);
            this.animationYesOrNo.Name = "animationYesOrNo";
            this.animationYesOrNo.Size = new System.Drawing.Size(64, 17);
            this.animationYesOrNo.TabIndex = 9;
            this.animationYesOrNo.Text = "Animate";
            this.animationYesOrNo.UseVisualStyleBackColor = true;
            this.animationYesOrNo.CheckedChanged += new System.EventHandler(this.animationYesOrNo_CheckedChanged);
            // 
            // animateByNamedSetRadioButton
            // 
            this.animateByNamedSetRadioButton.AutoSize = true;
            this.animationTableLayoutPanel.SetColumnSpan(this.animateByNamedSetRadioButton, 2);
            this.animateByNamedSetRadioButton.Enabled = false;
            this.animateByNamedSetRadioButton.Location = new System.Drawing.Point(3, 26);
            this.animateByNamedSetRadioButton.Name = "animateByNamedSetRadioButton";
            this.animateByNamedSetRadioButton.Size = new System.Drawing.Size(136, 17);
            this.animateByNamedSetRadioButton.TabIndex = 22;
            this.animateByNamedSetRadioButton.Text = "Animate by Named Set:";
            this.animateByNamedSetRadioButton.UseVisualStyleBackColor = true;
            this.animateByNamedSetRadioButton.CheckedChanged += new System.EventHandler(this.animateByNamedSetRadioButton_CheckedChanged);
            // 
            // namedSetComboBox
            // 
            this.namedSetComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationTableLayoutPanel.SetColumnSpan(this.namedSetComboBox, 2);
            this.namedSetComboBox.Enabled = false;
            this.namedSetComboBox.FormattingEnabled = true;
            this.namedSetComboBox.Location = new System.Drawing.Point(3, 49);
            this.namedSetComboBox.Name = "namedSetComboBox";
            this.namedSetComboBox.Size = new System.Drawing.Size(173, 21);
            this.namedSetComboBox.TabIndex = 23;
            this.namedSetComboBox.SelectedIndexChanged += new System.EventHandler(this.namedSetComboBox_SelectionChanged);
            // 
            // animateByRangeRadioButton
            // 
            this.animateByRangeRadioButton.AutoSize = true;
            this.animateByRangeRadioButton.Checked = true;
            this.animationTableLayoutPanel.SetColumnSpan(this.animateByRangeRadioButton, 2);
            this.animateByRangeRadioButton.Enabled = false;
            this.animateByRangeRadioButton.Location = new System.Drawing.Point(3, 76);
            this.animateByRangeRadioButton.Name = "animateByRangeRadioButton";
            this.animateByRangeRadioButton.Size = new System.Drawing.Size(115, 17);
            this.animateByRangeRadioButton.TabIndex = 21;
            this.animateByRangeRadioButton.TabStop = true;
            this.animateByRangeRadioButton.Text = "Animate by Range:";
            this.animateByRangeRadioButton.UseVisualStyleBackColor = true;
            this.animateByRangeRadioButton.CheckedChanged += new System.EventHandler(this.animateByRangeRadioButton_CheckedChanged);
            // 
            // startFrameLabel
            // 
            this.startFrameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startFrameLabel.AutoSize = true;
            this.startFrameLabel.Location = new System.Drawing.Point(3, 103);
            this.startFrameLabel.Name = "startFrameLabel";
            this.startFrameLabel.Size = new System.Drawing.Size(83, 13);
            this.startFrameLabel.TabIndex = 4;
            this.startFrameLabel.Text = "Start Frame:";
            this.startFrameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // endFrameLabel
            // 
            this.endFrameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.endFrameLabel.AutoSize = true;
            this.endFrameLabel.Location = new System.Drawing.Point(3, 130);
            this.endFrameLabel.Name = "endFrameLabel";
            this.endFrameLabel.Size = new System.Drawing.Size(83, 13);
            this.endFrameLabel.TabIndex = 7;
            this.endFrameLabel.Text = "End Frame:";
            this.endFrameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // targetMillisecondsLabel
            // 
            this.targetMillisecondsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.targetMillisecondsLabel.AutoSize = true;
            this.targetMillisecondsLabel.Location = new System.Drawing.Point(0, 158);
            this.targetMillisecondsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.targetMillisecondsLabel.Name = "targetMillisecondsLabel";
            this.targetMillisecondsLabel.Size = new System.Drawing.Size(89, 13);
            this.targetMillisecondsLabel.TabIndex = 10;
            this.targetMillisecondsLabel.Text = "Target ms:";
            this.targetMillisecondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // animationTargetStartFrame
            // 
            this.animationTargetStartFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.animationTargetStartFrame.Location = new System.Drawing.Point(92, 99);
            this.animationTargetStartFrame.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animationTargetStartFrame.Name = "animationTargetStartFrame";
            this.animationTargetStartFrame.Size = new System.Drawing.Size(84, 20);
            this.animationTargetStartFrame.TabIndex = 6;
            this.animationTargetStartFrame.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animationTargetStartFrame.ValueChanged += new System.EventHandler(this.animationTargetStartFrame_ValueChanged);
            // 
            // animationTargetEndFrame
            // 
            this.animationTargetEndFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.animationTargetEndFrame.Location = new System.Drawing.Point(92, 126);
            this.animationTargetEndFrame.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animationTargetEndFrame.Name = "animationTargetEndFrame";
            this.animationTargetEndFrame.Size = new System.Drawing.Size(84, 20);
            this.animationTargetEndFrame.TabIndex = 8;
            this.animationTargetEndFrame.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.animationTargetEndFrame.ValueChanged += new System.EventHandler(this.animationTargetEndFrame_ValueChanged);
            // 
            // animationTargetMS
            // 
            this.animationTargetMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.animationTargetMS.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.animationTargetMS.Location = new System.Drawing.Point(92, 154);
            this.animationTargetMS.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.animationTargetMS.Name = "animationTargetMS";
            this.animationTargetMS.Size = new System.Drawing.Size(84, 20);
            this.animationTargetMS.TabIndex = 11;
            this.animationTargetMS.Value = new decimal(new int[] {
            143,
            0,
            0,
            0});
            this.animationTargetMS.ValueChanged += new System.EventHandler(this.animationTargetMS_ValueChanged);
            // 
            // subdivisionPanel
            // 
            this.subdivisionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subdivisionPanel.BackColor = System.Drawing.Color.Transparent;
            this.optionsTableLayoutPanel.SetColumnSpan(this.subdivisionPanel, 2);
            this.subdivisionPanel.Controls.Add(this.subdivisionButtonPanel);
            this.subdivisionPanel.Location = new System.Drawing.Point(0, 526);
            this.subdivisionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.subdivisionPanel.Name = "subdivisionPanel";
            this.subdivisionPanel.Size = new System.Drawing.Size(182, 20);
            this.subdivisionPanel.TabIndex = 31;
            // 
            // subdivisionButtonPanel
            // 
            this.subdivisionButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subdivisionButtonPanel.BackColor = System.Drawing.SystemColors.Control;
            this.subdivisionButtonPanel.BorderColor = System.Drawing.Color.SlateGray;
            this.subdivisionButtonPanel.BorderWidth = 2;
            this.subdivisionButtonPanel.ColorSteps = 11D;
            this.subdivisionButtonPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subdivisionButtonPanel.GradientColor = System.Drawing.Color.Silver;
            this.subdivisionButtonPanel.HoverGradientColor = System.Drawing.Color.LightSlateGray;
            this.subdivisionButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.subdivisionButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.subdivisionButtonPanel.Name = "subdivisionButtonPanel";
            this.subdivisionButtonPanel.Size = new System.Drawing.Size(182, 20);
            this.subdivisionButtonPanel.TabIndex = 28;
            this.subdivisionButtonPanel.Title = "Subdivision";
            this.subdivisionButtonPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.subdivisionButtonPanel_MouseClick);
            this.subdivisionButtonPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.subdivisionButtonPanel_MouseDoubleClick);
            // 
            // subdivisionTableLayoutPanel
            // 
            this.subdivisionTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subdivisionTableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.subdivisionTableLayoutPanel.ColumnCount = 2;
            this.optionsTableLayoutPanel.SetColumnSpan(this.subdivisionTableLayoutPanel, 2);
            this.subdivisionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.subdivisionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.subdivisionTableLayoutPanel.Controls.Add(this.rowsLabel, 0, 0);
            this.subdivisionTableLayoutPanel.Controls.Add(this.numberRows, 1, 0);
            this.subdivisionTableLayoutPanel.Controls.Add(this.columnsLabel, 0, 1);
            this.subdivisionTableLayoutPanel.Controls.Add(this.numberColumns, 1, 1);
            this.subdivisionTableLayoutPanel.Controls.Add(this.maxCellsLabel, 0, 2);
            this.subdivisionTableLayoutPanel.Controls.Add(this.numberMaxCells, 1, 2);
            this.subdivisionTableLayoutPanel.Location = new System.Drawing.Point(1, 546);
            this.subdivisionTableLayoutPanel.Margin = new System.Windows.Forms.Padding(1, 0, 2, 1);
            this.subdivisionTableLayoutPanel.Name = "subdivisionTableLayoutPanel";
            this.subdivisionTableLayoutPanel.RowCount = 3;
            this.subdivisionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.subdivisionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.subdivisionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.subdivisionTableLayoutPanel.Size = new System.Drawing.Size(179, 86);
            this.subdivisionTableLayoutPanel.TabIndex = 27;
            // 
            // rowsLabel
            // 
            this.rowsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Location = new System.Drawing.Point(3, 7);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(83, 13);
            this.rowsLabel.TabIndex = 0;
            this.rowsLabel.Text = "Rows:";
            // 
            // numberRows
            // 
            this.numberRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numberRows.Location = new System.Drawing.Point(92, 4);
            this.numberRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberRows.Name = "numberRows";
            this.numberRows.Size = new System.Drawing.Size(84, 20);
            this.numberRows.TabIndex = 1;
            this.numberRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numberRows.ValueChanged += new System.EventHandler(this.numberRows_ValueChanged);
            // 
            // columnsLabel
            // 
            this.columnsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.columnsLabel.AutoSize = true;
            this.columnsLabel.Location = new System.Drawing.Point(3, 35);
            this.columnsLabel.Name = "columnsLabel";
            this.columnsLabel.Size = new System.Drawing.Size(83, 13);
            this.columnsLabel.TabIndex = 0;
            this.columnsLabel.Text = "Columns:";
            // 
            // numberColumns
            // 
            this.numberColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numberColumns.Location = new System.Drawing.Point(92, 32);
            this.numberColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberColumns.Name = "numberColumns";
            this.numberColumns.Size = new System.Drawing.Size(84, 20);
            this.numberColumns.TabIndex = 1;
            this.numberColumns.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.numberColumns.ValueChanged += new System.EventHandler(this.numberColumns_ValueChanged);
            // 
            // maxCellsLabel
            // 
            this.maxCellsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maxCellsLabel.AutoSize = true;
            this.maxCellsLabel.Location = new System.Drawing.Point(3, 64);
            this.maxCellsLabel.Name = "maxCellsLabel";
            this.maxCellsLabel.Size = new System.Drawing.Size(83, 13);
            this.maxCellsLabel.TabIndex = 0;
            this.maxCellsLabel.Text = "Max Cells:";
            // 
            // numberMaxCells
            // 
            this.numberMaxCells.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numberMaxCells.Location = new System.Drawing.Point(92, 61);
            this.numberMaxCells.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numberMaxCells.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberMaxCells.Name = "numberMaxCells";
            this.numberMaxCells.Size = new System.Drawing.Size(84, 20);
            this.numberMaxCells.TabIndex = 1;
            this.numberMaxCells.Value = new decimal(new int[] {
            56,
            0,
            0,
            0});
            this.numberMaxCells.ValueChanged += new System.EventHandler(this.numberMaxCells_ValueChanged);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.mainMenuFillerToolStripSpringTextBox,
            this.rendererLabelToolStripTextBox,
            this.rendererToolStripComboBox});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainMenuStrip.Size = new System.Drawing.Size(884, 25);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportActiveFramesAsGIFToolStripMenuItem,
            this.toolStripMenuItem2,
            this.formatsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.fileToolStripMenuItem.Text = "File...";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Enabled = false;
            this.loadImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadImageToolStripMenuItem.Image")));
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image...";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageContextMenuButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(208, 6);
            // 
            // exportActiveFramesAsGIFToolStripMenuItem
            // 
            this.exportActiveFramesAsGIFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oneHundredPercentToolStripMenuItem,
            this.twoHundredPercentToolStripMenuItem,
            this.customPercentToolStripMenuItem,
            this.customPercentToolStripTextBox});
            this.exportActiveFramesAsGIFToolStripMenuItem.Enabled = false;
            this.exportActiveFramesAsGIFToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportActiveFramesAsGIFToolStripMenuItem.Image")));
            this.exportActiveFramesAsGIFToolStripMenuItem.Name = "exportActiveFramesAsGIFToolStripMenuItem";
            this.exportActiveFramesAsGIFToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.exportActiveFramesAsGIFToolStripMenuItem.Text = "Export Active Frames as GIF";
            // 
            // oneHundredPercentToolStripMenuItem
            // 
            this.oneHundredPercentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("oneHundredPercentToolStripMenuItem.Image")));
            this.oneHundredPercentToolStripMenuItem.Name = "oneHundredPercentToolStripMenuItem";
            this.oneHundredPercentToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.oneHundredPercentToolStripMenuItem.Text = "100%";
            this.oneHundredPercentToolStripMenuItem.Click += new System.EventHandler(this.exportAnimationAt100PercentToolStripMenuItem_Click);
            // 
            // twoHundredPercentToolStripMenuItem
            // 
            this.twoHundredPercentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("twoHundredPercentToolStripMenuItem.Image")));
            this.twoHundredPercentToolStripMenuItem.Name = "twoHundredPercentToolStripMenuItem";
            this.twoHundredPercentToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.twoHundredPercentToolStripMenuItem.Text = "200%";
            this.twoHundredPercentToolStripMenuItem.Click += new System.EventHandler(this.exportAnimationAt200PercentToolStripMenuItem_Click);
            // 
            // customPercentToolStripMenuItem
            // 
            this.customPercentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("customPercentToolStripMenuItem.Image")));
            this.customPercentToolStripMenuItem.Name = "customPercentToolStripMenuItem";
            this.customPercentToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.customPercentToolStripMenuItem.Text = "Custom %:";
            this.customPercentToolStripMenuItem.Click += new System.EventHandler(this.exportAnimationAtCustomPercentToolStripMenuItem_Click);
            // 
            // customPercentToolStripTextBox
            // 
            this.customPercentToolStripTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.customPercentToolStripTextBox.MaxLength = 4;
            this.customPercentToolStripTextBox.Name = "customPercentToolStripTextBox";
            this.customPercentToolStripTextBox.Size = new System.Drawing.Size(121, 21);
            this.customPercentToolStripTextBox.Text = "300";
            this.customPercentToolStripTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customPercentToolStripTextBox_KeyDown);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(208, 6);
            // 
            // formatsToolStripMenuItem
            // 
            this.formatsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beginNewFormatToolStripMenuItem,
            this.editLoadedFormatToolStripMenuItem});
            this.formatsToolStripMenuItem.Enabled = false;
            this.formatsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("formatsToolStripMenuItem.Image")));
            this.formatsToolStripMenuItem.Name = "formatsToolStripMenuItem";
            this.formatsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.formatsToolStripMenuItem.Text = "Formats";
            // 
            // beginNewFormatToolStripMenuItem
            // 
            this.beginNewFormatToolStripMenuItem.Name = "beginNewFormatToolStripMenuItem";
            this.beginNewFormatToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.beginNewFormatToolStripMenuItem.Text = "Begin New Format";
            this.beginNewFormatToolStripMenuItem.Click += new System.EventHandler(this.beginNewFormatToolStripMenuItem_Click);
            // 
            // editLoadedFormatToolStripMenuItem
            // 
            this.editLoadedFormatToolStripMenuItem.Enabled = false;
            this.editLoadedFormatToolStripMenuItem.Name = "editLoadedFormatToolStripMenuItem";
            this.editLoadedFormatToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.editLoadedFormatToolStripMenuItem.Text = "Edit Loaded Format";
            this.editLoadedFormatToolStripMenuItem.Click += new System.EventHandler(this.editLoadedFormatToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.availableFormatsToolStripMenuItem,
            this.constructedPaletteToolStripMenuItem,
            this.availableAttachmentsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // availableFormatsToolStripMenuItem
            // 
            this.availableFormatsToolStripMenuItem.Enabled = false;
            this.availableFormatsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("availableFormatsToolStripMenuItem.Image")));
            this.availableFormatsToolStripMenuItem.Name = "availableFormatsToolStripMenuItem";
            this.availableFormatsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.availableFormatsToolStripMenuItem.Text = "Available Formats";
            this.availableFormatsToolStripMenuItem.Click += new System.EventHandler(this.availableFormatsToolStripMenuItem_Click);
            // 
            // constructedPaletteToolStripMenuItem
            // 
            this.constructedPaletteToolStripMenuItem.Enabled = false;
            this.constructedPaletteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("constructedPaletteToolStripMenuItem.Image")));
            this.constructedPaletteToolStripMenuItem.Name = "constructedPaletteToolStripMenuItem";
            this.constructedPaletteToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.constructedPaletteToolStripMenuItem.Text = "Constructed Palette";
            this.constructedPaletteToolStripMenuItem.Click += new System.EventHandler(this.constructedPaletteToolStripMenuItem_Click);
            // 
            // availableAttachmentsToolStripMenuItem
            // 
            this.availableAttachmentsToolStripMenuItem.Enabled = false;
            this.availableAttachmentsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("availableAttachmentsToolStripMenuItem.Image")));
            this.availableAttachmentsToolStripMenuItem.Name = "availableAttachmentsToolStripMenuItem";
            this.availableAttachmentsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.availableAttachmentsToolStripMenuItem.Text = "Available Attachments";
            this.availableAttachmentsToolStripMenuItem.Click += new System.EventHandler(this.availableAttachmentsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creditsToolStripMenuItem,
            this.toolStripSeparator3,
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 21);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("creditsToolStripMenuItem.Image")));
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem.Image")));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // mainMenuFillerToolStripSpringTextBox
            // 
            this.mainMenuFillerToolStripSpringTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenuFillerToolStripSpringTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainMenuFillerToolStripSpringTextBox.Enabled = false;
            this.mainMenuFillerToolStripSpringTextBox.Name = "mainMenuFillerToolStripSpringTextBox";
            this.mainMenuFillerToolStripSpringTextBox.ShortcutsEnabled = false;
            this.mainMenuFillerToolStripSpringTextBox.Size = new System.Drawing.Size(423, 21);
            // 
            // rendererLabelToolStripTextBox
            // 
            this.rendererLabelToolStripTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.rendererLabelToolStripTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rendererLabelToolStripTextBox.CausesValidation = false;
            this.rendererLabelToolStripTextBox.Name = "rendererLabelToolStripTextBox";
            this.rendererLabelToolStripTextBox.ReadOnly = true;
            this.rendererLabelToolStripTextBox.ShortcutsEnabled = false;
            this.rendererLabelToolStripTextBox.Size = new System.Drawing.Size(100, 21);
            this.rendererLabelToolStripTextBox.Text = "Renderer:";
            this.rendererLabelToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rendererToolStripComboBox
            // 
            this.rendererToolStripComboBox.AutoSize = false;
            this.rendererToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rendererToolStripComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rendererToolStripComboBox.Name = "rendererToolStripComboBox";
            this.rendererToolStripComboBox.Size = new System.Drawing.Size(121, 21);
            this.rendererToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.rendererToolStripComboBox_SelectedIndexChanged);
            // 
            // spriteSheetOpenFileDialog
            // 
            this.spriteSheetOpenFileDialog.Filter = "Images (*.bmp, *.png)|*.bmp; *.png|Windows Bitmap (*.bmp)|*.bmp|Portable Network " +
    "Graphics (*.png)|*.png";
            this.spriteSheetOpenFileDialog.SupportMultiDottedExtensions = true;
            // 
            // previewAreaContextMenuStrip
            // 
            this.previewAreaContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSelectedFrameToolStripMenuItem,
            this.usePreviousFrameToolStripMenuItem,
            this.flipFrameHorizontallyToolStripMenuItem});
            this.previewAreaContextMenuStrip.Name = "contextMenuStrip1";
            this.previewAreaContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.previewAreaContextMenuStrip.Size = new System.Drawing.Size(183, 70);
            this.previewAreaContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.previewAreaContextMenuStrip_Opening);
            // 
            // editSelectedFrameToolStripMenuItem
            // 
            this.editSelectedFrameToolStripMenuItem.Name = "editSelectedFrameToolStripMenuItem";
            this.editSelectedFrameToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.editSelectedFrameToolStripMenuItem.Text = "Edit Selected Frame...";
            this.editSelectedFrameToolStripMenuItem.Click += new System.EventHandler(this.editSelectedFrameToolStripMenuItem_Click);
            // 
            // usePreviousFrameToolStripMenuItem
            // 
            this.usePreviousFrameToolStripMenuItem.Name = "usePreviousFrameToolStripMenuItem";
            this.usePreviousFrameToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.usePreviousFrameToolStripMenuItem.Text = "Use Previous Frame";
            this.usePreviousFrameToolStripMenuItem.Click += new System.EventHandler(this.usePreviousFrameToolStripMenuItem_Click);
            // 
            // flipFrameHorizontallyToolStripMenuItem
            // 
            this.flipFrameHorizontallyToolStripMenuItem.Name = "flipFrameHorizontallyToolStripMenuItem";
            this.flipFrameHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.flipFrameHorizontallyToolStripMenuItem.Text = "Flip Frame Horizontally";
            this.flipFrameHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.flipFrameHorizontallyToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 579);
            this.Controls.Add(this.basePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sprite Animator";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            this.Move += new System.EventHandler(this.Main_Move);
            this.basePanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.renderControlPanel.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.ResumeLayout(false);
            this.displayPanel.ResumeLayout(false);
            this.displayTableLayoutPanel.ResumeLayout(false);
            this.displayTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidth)).EndInit();
            this.rawImageColorOverlayPanel.ResumeLayout(false);
            this.rawImageColorOverlayPanel.PerformLayout();
            this.animationPanel.ResumeLayout(false);
            this.animationTableLayoutPanel.ResumeLayout(false);
            this.animationTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationTargetStartFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationTargetEndFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationTargetMS)).EndInit();
            this.subdivisionPanel.ResumeLayout(false);
            this.subdivisionTableLayoutPanel.ResumeLayout(false);
            this.subdivisionTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberMaxCells)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.previewAreaContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel basePanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel renderControlPanel;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.OpenFileDialog spriteSheetOpenFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        public Tao.Platform.Windows.SimpleOpenGlControl RenderControl;
        private System.Windows.Forms.CheckBox keepAspectRatioYesOrNo;
        private System.Windows.Forms.CheckBox drawFrameYesOrNo;
        private System.Windows.Forms.CheckBox autoUpdateYesOrNo;
        private System.Windows.Forms.CheckBox drawFrameNumberYesOrNo;
        private System.Windows.Forms.Label startFrameLabel;
        public System.Windows.Forms.CheckBox animationYesOrNo;
        public System.Windows.Forms.NumericUpDown animationTargetEndFrame;
        private System.Windows.Forms.Label endFrameLabel;
        public System.Windows.Forms.NumericUpDown animationTargetStartFrame;
        public System.Windows.Forms.NumericUpDown animationTargetMS;
        private System.Windows.Forms.Label targetMillisecondsLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        public System.Windows.Forms.NumericUpDown numberMaxCells;
        private System.Windows.Forms.Label maxCellsLabel;
        private System.Windows.Forms.NumericUpDown numberColumns;
        private System.Windows.Forms.Label columnsLabel;
        private System.Windows.Forms.NumericUpDown numberRows;
        private System.Windows.Forms.Label rowsLabel;
        public System.Windows.Forms.CheckBox ghostPreviousYesOrNo;
        public System.Windows.Forms.CheckBox ghostNextYesOrNo;
		public System.Windows.Forms.CheckBox transparentBackgroundYesOrNo;
        private System.Windows.Forms.Panel colorSwatch;
        private System.Windows.Forms.Label rawImageOverlayLabel;
        private System.Windows.Forms.Panel rawImageColorOverlayPanel;
        private System.Windows.Forms.Label lineWidthLabel;
        private System.Windows.Forms.NumericUpDown lineWidth;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportActiveFramesAsGIFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneHundredPercentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customPercentToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox customPercentToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem twoHundredPercentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem constructedPaletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem availableFormatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ContextMenuStrip previewAreaContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editSelectedFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usePreviousFrameToolStripMenuItem;
        public System.Windows.Forms.CheckBox autoUpdateOnFormatChange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.CheckBox useNoSamplingCheckBox;
        private System.Windows.Forms.ToolStripMenuItem formatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beginNewFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editLoadedFormatToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel optionsTableLayoutPanel;
        private System.Windows.Forms.RadioButton animateByRangeRadioButton;
        private System.Windows.Forms.RadioButton animateByNamedSetRadioButton;
        private System.Windows.Forms.ComboBox namedSetComboBox;
        private System.Windows.Forms.TableLayoutPanel subdivisionTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel animationTableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel displayTableLayoutPanel;
        private System.Windows.Forms.Panel subdivisionPanel;
        private ButtonPanel subdivisionButtonPanel;
        private System.Windows.Forms.Panel animationPanel;
        private ButtonPanel animationButtonPanel;
        private System.Windows.Forms.Panel displayPanel;
        private ButtonPanel displayButtonPanel;
        private System.Windows.Forms.CheckBox showAudioWaveForm;
        public System.Windows.Forms.CheckBox ignoreAudio;
        private System.Windows.Forms.ToolStripMenuItem flipFrameHorizontallyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem availableAttachmentsToolStripMenuItem;
		private ToolStripSpringTextBox mainMenuFillerToolStripSpringTextBox;
		private System.Windows.Forms.ToolStripTextBox rendererLabelToolStripTextBox;
		private System.Windows.Forms.ToolStripComboBox rendererToolStripComboBox;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

