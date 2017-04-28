namespace SpriteAnimator
{
    partial class AddOrEditFormat
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Horizontal Guides List", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Vertical Guides List", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Linear Motion Tween List", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Composite Frames", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Available Colors List", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Frames", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Named Attachment Points", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Composite Frame Sets", System.Windows.Forms.HorizontalAlignment.Left);
			this.fileTypeLabel = new System.Windows.Forms.Label();
			this.formatDescriptionLabel = new System.Windows.Forms.Label();
			this.formatStatusLabel = new System.Windows.Forms.Label();
			this.frameWidthLabel = new System.Windows.Forms.Label();
			this.startFrameLabel = new System.Windows.Forms.Label();
			this.columnsLabel = new System.Windows.Forms.Label();
			this.rowsLabel = new System.Windows.Forms.Label();
			this.frameHeightLabel = new System.Windows.Forms.Label();
			this.sourceImageLabel = new System.Windows.Forms.Label();
			this.onLoadZoomLabel = new System.Windows.Forms.Label();
			this.targetMSLabel = new System.Windows.Forms.Label();
			this.endFrameLabel = new System.Windows.Forms.Label();
			this.useNoImageSamplingLabel = new System.Windows.Forms.Label();
			this.useNoSamplingCheckBox = new System.Windows.Forms.CheckBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.browseForReferenceImageButton = new System.Windows.Forms.Button();
			this.validationErrorsToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.guideContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tweenContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addTweenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editTweenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeTweenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addColorContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.frameContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.sliceSourceImageIntoFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generalToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.guidesListBox = new System.Windows.Forms.ListView();
			this.guidesEmptyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.guideTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.guidePositionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tweensListBox = new System.Windows.Forms.ListView();
			this.tweenEmptyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tweenIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tweenFrameLengthColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tweenColorComponentsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tweenMotionComponentsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tweenAdvancementFunctionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.compositeFramesListView = new System.Windows.Forms.ListView();
			this.compositeFramesIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.compositeFramesFrameCountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.compositeFramesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyRangeOfCompositeFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flipRangeOfCompositeFramesHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.slideRangeOfCompositeFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorsListBox = new System.Windows.Forms.ListView();
			this.colorNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colorNumberColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colorSwatchColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colorOpacityColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.framesListView = new System.Windows.Forms.ListView();
			this.framesIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.framesSColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.framesTColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.framesWColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.framesHColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.namedAttachmentPointsListView = new System.Windows.Forms.ListView();
			this.namedAttachmentPointIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.namedAttachmentPointNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.namedAttachmentPointDescriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.namedAttachmentPointsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addNamedAttachmentPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editNamedAttachmentPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeNamedAttachmentPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.compositeFrameSetsListView = new System.Windows.Forms.ListView();
			this.compositeFrameSetNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.compositeFrameSetFramesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.compositeFrameSetContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addCompositeFrameSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editCompositeFrameSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeCompositeFrameSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.soundsListView = new System.Windows.Forms.ListView();
			this.soundsNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.soundsFilenameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.soundsDisplayColorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.soundContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addNewSoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editSoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeSoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lowerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.namedAttachmentPointsPanel = new System.Windows.Forms.Panel();
			this.availableColorsAndGuidesButtonPanel = new SpriteAnimator.ButtonPanel(this.components);
			this.guidesPanel = new System.Windows.Forms.Panel();
			this.colorAndMotionTweensPanel = new System.Windows.Forms.Panel();
			this.colorAndMotionTweensButtonPanel = new SpriteAnimator.ButtonPanel(this.components);
			this.compositeFrameSetsPanel = new System.Windows.Forms.Panel();
			this.compositeFramesPanel = new System.Windows.Forms.Panel();
			this.frameAndCompositeFramesButtonPanel = new SpriteAnimator.ButtonPanel(this.components);
			this.colorsPanel = new System.Windows.Forms.Panel();
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel = new SpriteAnimator.ButtonPanel(this.components);
			this.framesPanel = new System.Windows.Forms.Panel();
			this.saveButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.soundsButtonPanel = new SpriteAnimator.ButtonPanel(this.components);
			this.soundsPanel = new System.Windows.Forms.Panel();
			this.sourceImageMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.onLoadZoomMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.targetMillisecondsMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.endFrameMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.startFrameMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.columnCountMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.rowCountMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.frameHeightMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.frameWidthMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.formatStatusMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.formatDescriptionMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.fileTypeMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.removeSelectedCompositeFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.guideContextMenuStrip.SuspendLayout();
			this.tweenContextMenuStrip.SuspendLayout();
			this.addColorContextMenuStrip.SuspendLayout();
			this.frameContextMenuStrip.SuspendLayout();
			this.compositeFramesContextMenuStrip.SuspendLayout();
			this.namedAttachmentPointsContextMenuStrip.SuspendLayout();
			this.compositeFrameSetContextMenuStrip.SuspendLayout();
			this.soundContextMenuStrip.SuspendLayout();
			this.lowerTableLayoutPanel.SuspendLayout();
			this.namedAttachmentPointsPanel.SuspendLayout();
			this.guidesPanel.SuspendLayout();
			this.colorAndMotionTweensPanel.SuspendLayout();
			this.compositeFrameSetsPanel.SuspendLayout();
			this.compositeFramesPanel.SuspendLayout();
			this.colorsPanel.SuspendLayout();
			this.framesPanel.SuspendLayout();
			this.soundsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// fileTypeLabel
			// 
			this.fileTypeLabel.Location = new System.Drawing.Point(8, 8);
			this.fileTypeLabel.Name = "fileTypeLabel";
			this.fileTypeLabel.Size = new System.Drawing.Size(128, 16);
			this.fileTypeLabel.TabIndex = 0;
			this.fileTypeLabel.Text = "File Type:";
			this.fileTypeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// formatDescriptionLabel
			// 
			this.formatDescriptionLabel.Location = new System.Drawing.Point(8, 32);
			this.formatDescriptionLabel.Name = "formatDescriptionLabel";
			this.formatDescriptionLabel.Size = new System.Drawing.Size(128, 16);
			this.formatDescriptionLabel.TabIndex = 1;
			this.formatDescriptionLabel.Text = "Format Description:";
			this.formatDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// formatStatusLabel
			// 
			this.formatStatusLabel.Location = new System.Drawing.Point(8, 56);
			this.formatStatusLabel.Name = "formatStatusLabel";
			this.formatStatusLabel.Size = new System.Drawing.Size(128, 16);
			this.formatStatusLabel.TabIndex = 2;
			this.formatStatusLabel.Text = "Format Status:";
			this.formatStatusLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// frameWidthLabel
			// 
			this.frameWidthLabel.Location = new System.Drawing.Point(8, 80);
			this.frameWidthLabel.Name = "frameWidthLabel";
			this.frameWidthLabel.Size = new System.Drawing.Size(128, 16);
			this.frameWidthLabel.TabIndex = 3;
			this.frameWidthLabel.Text = "Frame Width:";
			this.frameWidthLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// startFrameLabel
			// 
			this.startFrameLabel.Location = new System.Drawing.Point(8, 176);
			this.startFrameLabel.Name = "startFrameLabel";
			this.startFrameLabel.Size = new System.Drawing.Size(128, 16);
			this.startFrameLabel.TabIndex = 7;
			this.startFrameLabel.Text = "Start Frame:";
			this.startFrameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// columnsLabel
			// 
			this.columnsLabel.Location = new System.Drawing.Point(8, 152);
			this.columnsLabel.Name = "columnsLabel";
			this.columnsLabel.Size = new System.Drawing.Size(128, 16);
			this.columnsLabel.TabIndex = 6;
			this.columnsLabel.Text = "Columns:";
			this.columnsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// rowsLabel
			// 
			this.rowsLabel.Location = new System.Drawing.Point(8, 128);
			this.rowsLabel.Name = "rowsLabel";
			this.rowsLabel.Size = new System.Drawing.Size(128, 16);
			this.rowsLabel.TabIndex = 5;
			this.rowsLabel.Text = "Rows:";
			this.rowsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// frameHeightLabel
			// 
			this.frameHeightLabel.Location = new System.Drawing.Point(8, 104);
			this.frameHeightLabel.Name = "frameHeightLabel";
			this.frameHeightLabel.Size = new System.Drawing.Size(128, 16);
			this.frameHeightLabel.TabIndex = 4;
			this.frameHeightLabel.Text = "Frame Height:";
			this.frameHeightLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// sourceImageLabel
			// 
			this.sourceImageLabel.Location = new System.Drawing.Point(8, 272);
			this.sourceImageLabel.Name = "sourceImageLabel";
			this.sourceImageLabel.Size = new System.Drawing.Size(128, 16);
			this.sourceImageLabel.TabIndex = 11;
			this.sourceImageLabel.Text = "Source Image:";
			this.sourceImageLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// onLoadZoomLabel
			// 
			this.onLoadZoomLabel.Location = new System.Drawing.Point(8, 248);
			this.onLoadZoomLabel.Name = "onLoadZoomLabel";
			this.onLoadZoomLabel.Size = new System.Drawing.Size(128, 16);
			this.onLoadZoomLabel.TabIndex = 10;
			this.onLoadZoomLabel.Text = "On Load, Zoom:";
			this.onLoadZoomLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// targetMSLabel
			// 
			this.targetMSLabel.Location = new System.Drawing.Point(8, 224);
			this.targetMSLabel.Name = "targetMSLabel";
			this.targetMSLabel.Size = new System.Drawing.Size(128, 16);
			this.targetMSLabel.TabIndex = 9;
			this.targetMSLabel.Text = "Target MS:";
			this.targetMSLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// endFrameLabel
			// 
			this.endFrameLabel.Location = new System.Drawing.Point(8, 200);
			this.endFrameLabel.Name = "endFrameLabel";
			this.endFrameLabel.Size = new System.Drawing.Size(128, 16);
			this.endFrameLabel.TabIndex = 8;
			this.endFrameLabel.Text = "End Frame:";
			this.endFrameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// useNoImageSamplingLabel
			// 
			this.useNoImageSamplingLabel.Location = new System.Drawing.Point(8, 293);
			this.useNoImageSamplingLabel.Name = "useNoImageSamplingLabel";
			this.useNoImageSamplingLabel.Size = new System.Drawing.Size(128, 16);
			this.useNoImageSamplingLabel.TabIndex = 12;
			this.useNoImageSamplingLabel.Text = "Use No Image Sampling:";
			this.useNoImageSamplingLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// useNoSamplingCheckBox
			// 
			this.useNoSamplingCheckBox.AutoSize = true;
			this.useNoSamplingCheckBox.Checked = true;
			this.useNoSamplingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.useNoSamplingCheckBox.Location = new System.Drawing.Point(144, 294);
			this.useNoSamplingCheckBox.Name = "useNoSamplingCheckBox";
			this.useNoSamplingCheckBox.Size = new System.Drawing.Size(15, 14);
			this.useNoSamplingCheckBox.TabIndex = 25;
			this.useNoSamplingCheckBox.UseVisualStyleBackColor = true;
			// 
			// browseForReferenceImageButton
			// 
			this.browseForReferenceImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseForReferenceImageButton.Location = new System.Drawing.Point(592, 266);
			this.browseForReferenceImageButton.Name = "browseForReferenceImageButton";
			this.browseForReferenceImageButton.Size = new System.Drawing.Size(56, 22);
			this.browseForReferenceImageButton.TabIndex = 26;
			this.browseForReferenceImageButton.Text = "Browse";
			this.browseForReferenceImageButton.UseVisualStyleBackColor = true;
			this.browseForReferenceImageButton.Click += new System.EventHandler(this.browseForReferenceImageButton_Click);
			// 
			// validationErrorsToolTip
			// 
			this.validationErrorsToolTip.AutomaticDelay = 50;
			this.validationErrorsToolTip.AutoPopDelay = 5000;
			this.validationErrorsToolTip.InitialDelay = 50;
			this.validationErrorsToolTip.ReshowDelay = 10;
			// 
			// guideContextMenuStrip
			// 
			this.guideContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGuideToolStripMenuItem,
            this.editGuideToolStripMenuItem,
            this.removeGuideToolStripMenuItem});
			this.guideContextMenuStrip.Name = "guideContextMenuStrip";
			this.guideContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.guideContextMenuStrip.Size = new System.Drawing.Size(181, 70);
			this.guideContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.guideContextMenuStrip_Opening);
			this.guideContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.guideContextMenuStrip_ItemClicked);
			// 
			// addGuideToolStripMenuItem
			// 
			this.addGuideToolStripMenuItem.Name = "addGuideToolStripMenuItem";
			this.addGuideToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.addGuideToolStripMenuItem.Text = "Add New Guide Line";
			// 
			// editGuideToolStripMenuItem
			// 
			this.editGuideToolStripMenuItem.Enabled = false;
			this.editGuideToolStripMenuItem.Name = "editGuideToolStripMenuItem";
			this.editGuideToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.editGuideToolStripMenuItem.Text = "Edit Guide";
			// 
			// removeGuideToolStripMenuItem
			// 
			this.removeGuideToolStripMenuItem.Enabled = false;
			this.removeGuideToolStripMenuItem.Name = "removeGuideToolStripMenuItem";
			this.removeGuideToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.removeGuideToolStripMenuItem.Text = "Remove Guide";
			this.removeGuideToolStripMenuItem.Click += new System.EventHandler(this.removeGuideToolStripMenuItem_Click);
			// 
			// tweenContextMenuStrip
			// 
			this.tweenContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTweenToolStripMenuItem,
            this.editTweenToolStripMenuItem,
            this.removeTweenToolStripMenuItem});
			this.tweenContextMenuStrip.Name = "tweenContextMenuStrip";
			this.tweenContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.tweenContextMenuStrip.Size = new System.Drawing.Size(164, 70);
			this.tweenContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.tweenContextMenuStrip_Opening);
			this.tweenContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tweenContextMenuStrip_ItemClicked);
			// 
			// addTweenToolStripMenuItem
			// 
			this.addTweenToolStripMenuItem.Name = "addTweenToolStripMenuItem";
			this.addTweenToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.addTweenToolStripMenuItem.Text = "Add New Tween";
			// 
			// editTweenToolStripMenuItem
			// 
			this.editTweenToolStripMenuItem.Enabled = false;
			this.editTweenToolStripMenuItem.Name = "editTweenToolStripMenuItem";
			this.editTweenToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.editTweenToolStripMenuItem.Text = "Edit Tween";
			// 
			// removeTweenToolStripMenuItem
			// 
			this.removeTweenToolStripMenuItem.Enabled = false;
			this.removeTweenToolStripMenuItem.Name = "removeTweenToolStripMenuItem";
			this.removeTweenToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.removeTweenToolStripMenuItem.Text = "Remove Tween";
			this.removeTweenToolStripMenuItem.Click += new System.EventHandler(this.removeTweenToolStripMenuItem_Click);
			// 
			// addColorContextMenuStrip
			// 
			this.addColorContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addColorToolStripMenuItem,
            this.editColorToolStripMenuItem,
            this.removeColorToolStripMenuItem});
			this.addColorContextMenuStrip.Name = "addColorContextMenuStrip";
			this.addColorContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.addColorContextMenuStrip.Size = new System.Drawing.Size(157, 70);
			this.addColorContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.addColorContextMenuStrip_Opening);
			this.addColorContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.addColorContextMenuStrip_ItemClicked);
			// 
			// addColorToolStripMenuItem
			// 
			this.addColorToolStripMenuItem.Name = "addColorToolStripMenuItem";
			this.addColorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.addColorToolStripMenuItem.Text = "Add New Color";
			// 
			// editColorToolStripMenuItem
			// 
			this.editColorToolStripMenuItem.Enabled = false;
			this.editColorToolStripMenuItem.Name = "editColorToolStripMenuItem";
			this.editColorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.editColorToolStripMenuItem.Text = "Edit Color";
			// 
			// removeColorToolStripMenuItem
			// 
			this.removeColorToolStripMenuItem.Enabled = false;
			this.removeColorToolStripMenuItem.Name = "removeColorToolStripMenuItem";
			this.removeColorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.removeColorToolStripMenuItem.Text = "Remove Color";
			this.removeColorToolStripMenuItem.Click += new System.EventHandler(this.removeColorToolStripMenuItem_Click);
			// 
			// frameContextMenuStrip
			// 
			this.frameContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFrameToolStripMenuItem,
            this.editFrameToolStripMenuItem,
            this.removeFrameToolStripMenuItem,
            this.toolStripSeparator1,
            this.sliceSourceImageIntoFramesToolStripMenuItem});
			this.frameContextMenuStrip.Name = "frameContextMenuStrip1";
			this.frameContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.frameContextMenuStrip.Size = new System.Drawing.Size(235, 120);
			this.frameContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.frameContextMenuStrip1_Opening);
			// 
			// addFrameToolStripMenuItem
			// 
			this.addFrameToolStripMenuItem.Name = "addFrameToolStripMenuItem";
			this.addFrameToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			this.addFrameToolStripMenuItem.Text = "Add Frame";
			this.addFrameToolStripMenuItem.Click += new System.EventHandler(this.addFrameToolStripMenuItem_Click);
			// 
			// editFrameToolStripMenuItem
			// 
			this.editFrameToolStripMenuItem.Enabled = false;
			this.editFrameToolStripMenuItem.Name = "editFrameToolStripMenuItem";
			this.editFrameToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			this.editFrameToolStripMenuItem.Text = "Edit Frame";
			this.editFrameToolStripMenuItem.Click += new System.EventHandler(this.editFrameToolStripMenuItem_Click);
			// 
			// removeFrameToolStripMenuItem
			// 
			this.removeFrameToolStripMenuItem.Enabled = false;
			this.removeFrameToolStripMenuItem.Name = "removeFrameToolStripMenuItem";
			this.removeFrameToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			this.removeFrameToolStripMenuItem.Text = "Remove Frame";
			this.removeFrameToolStripMenuItem.Click += new System.EventHandler(this.removeFrameToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
			// 
			// sliceSourceImageIntoFramesToolStripMenuItem
			// 
			this.sliceSourceImageIntoFramesToolStripMenuItem.Enabled = false;
			this.sliceSourceImageIntoFramesToolStripMenuItem.Name = "sliceSourceImageIntoFramesToolStripMenuItem";
			this.sliceSourceImageIntoFramesToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			this.sliceSourceImageIntoFramesToolStripMenuItem.Text = "Slice Source Image into Frames";
			this.sliceSourceImageIntoFramesToolStripMenuItem.Click += new System.EventHandler(this.sliceSourceImageIntoFramesToolStripMenuItem_Click);
			// 
			// guidesListBox
			// 
			this.guidesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.guidesListBox.AutoArrange = false;
			this.guidesListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.guidesEmptyColumnHeader,
            this.guideTypeColumnHeader,
            this.guidePositionColumnHeader});
			this.guidesListBox.ContextMenuStrip = this.guideContextMenuStrip;
			this.guidesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.guidesListBox.FullRowSelect = true;
			this.guidesListBox.GridLines = true;
			listViewGroup1.Header = "Horizontal Guides List";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "Vertical Guides List";
			listViewGroup2.Name = "listViewGroup2";
			this.guidesListBox.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.guidesListBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.guidesListBox.Location = new System.Drawing.Point(0, 0);
			this.guidesListBox.Name = "guidesListBox";
			this.guidesListBox.Size = new System.Drawing.Size(250, 45);
			this.guidesListBox.TabIndex = 34;
			this.generalToolTip.SetToolTip(this.guidesListBox, "Add a blue guide line visible during composite frame editing.");
			this.guidesListBox.UseCompatibleStateImageBehavior = false;
			this.guidesListBox.View = System.Windows.Forms.View.Details;
			this.guidesListBox.SizeChanged += new System.EventHandler(this.ListView_SizeChanged);
			this.guidesListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox2_KeyDown);
			this.guidesListBox.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			// 
			// guidesEmptyColumnHeader
			// 
			this.guidesEmptyColumnHeader.Text = "";
			this.guidesEmptyColumnHeader.Width = 0;
			// 
			// guideTypeColumnHeader
			// 
			this.guideTypeColumnHeader.Text = "Type";
			this.guideTypeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.guideTypeColumnHeader.Width = 100;
			// 
			// guidePositionColumnHeader
			// 
			this.guidePositionColumnHeader.Text = "Position";
			this.guidePositionColumnHeader.Width = 113;
			// 
			// tweensListBox
			// 
			this.tweensListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tweensListBox.AutoArrange = false;
			this.tweensListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tweenEmptyColumnHeader,
            this.tweenIdColumnHeader,
            this.tweenFrameLengthColumnHeader,
            this.tweenColorComponentsColumnHeader,
            this.tweenMotionComponentsColumnHeader,
            this.tweenAdvancementFunctionColumnHeader});
			this.tweensListBox.ContextMenuStrip = this.tweenContextMenuStrip;
			this.tweensListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tweensListBox.FullRowSelect = true;
			this.tweensListBox.GridLines = true;
			listViewGroup3.Header = "Linear Motion Tween List";
			listViewGroup3.Name = "listViewGroup1";
			this.tweensListBox.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
			this.tweensListBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.tweensListBox.Location = new System.Drawing.Point(1, 0);
			this.tweensListBox.Name = "tweensListBox";
			this.tweensListBox.Size = new System.Drawing.Size(501, 45);
			this.tweensListBox.TabIndex = 37;
			this.generalToolTip.SetToolTip(this.tweensListBox, "Add a color or motion tween, assignable during composite frame editing.");
			this.tweensListBox.UseCompatibleStateImageBehavior = false;
			this.tweensListBox.View = System.Windows.Forms.View.Details;
			this.tweensListBox.SizeChanged += new System.EventHandler(this.ListView_SizeChanged);
			this.tweensListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox3_KeyDown);
			this.tweensListBox.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			// 
			// tweenEmptyColumnHeader
			// 
			this.tweenEmptyColumnHeader.Text = "";
			this.tweenEmptyColumnHeader.Width = 0;
			// 
			// tweenIdColumnHeader
			// 
			this.tweenIdColumnHeader.Text = "ID";
			this.tweenIdColumnHeader.Width = 42;
			// 
			// tweenFrameLengthColumnHeader
			// 
			this.tweenFrameLengthColumnHeader.Text = "Frame Length";
			this.tweenFrameLengthColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tweenFrameLengthColumnHeader.Width = 77;
			// 
			// tweenColorComponentsColumnHeader
			// 
			this.tweenColorComponentsColumnHeader.Text = "Color Components";
			this.tweenColorComponentsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tweenColorComponentsColumnHeader.Width = 98;
			// 
			// tweenMotionComponentsColumnHeader
			// 
			this.tweenMotionComponentsColumnHeader.Text = "Motion Components";
			this.tweenMotionComponentsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tweenMotionComponentsColumnHeader.Width = 106;
			// 
			// tweenAdvancementFunctionColumnHeader
			// 
			this.tweenAdvancementFunctionColumnHeader.Text = "Advancement Function";
			this.tweenAdvancementFunctionColumnHeader.Width = 135;
			// 
			// compositeFramesListView
			// 
			this.compositeFramesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.compositeFramesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.compositeFramesIdColumnHeader,
            this.compositeFramesFrameCountColumnHeader});
			this.compositeFramesListView.ContextMenuStrip = this.compositeFramesContextMenuStrip;
			this.compositeFramesListView.FullRowSelect = true;
			listViewGroup4.Header = "Composite Frames";
			listViewGroup4.Name = "Composite Frames";
			this.compositeFramesListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup4});
			this.compositeFramesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.compositeFramesListView.Location = new System.Drawing.Point(0, 0);
			this.compositeFramesListView.Name = "compositeFramesListView";
			this.compositeFramesListView.Size = new System.Drawing.Size(250, 45);
			this.compositeFramesListView.TabIndex = 39;
			this.generalToolTip.SetToolTip(this.compositeFramesListView, "View a list of a available composite frames. Edit composite frames in the main in" +
					"terface.");
			this.compositeFramesListView.UseCompatibleStateImageBehavior = false;
			this.compositeFramesListView.View = System.Windows.Forms.View.Details;
			this.compositeFramesListView.SizeChanged += new System.EventHandler(this.ListView_SizeChanged);
			this.compositeFramesListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.compositeFramesListView_KeyDown);
			this.compositeFramesListView.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			// 
			// compositeFramesIdColumnHeader
			// 
			this.compositeFramesIdColumnHeader.Text = "ID";
			this.compositeFramesIdColumnHeader.Width = 43;
			// 
			// compositeFramesFrameCountColumnHeader
			// 
			this.compositeFramesFrameCountColumnHeader.Text = "# of Frames Used";
			this.compositeFramesFrameCountColumnHeader.Width = 173;
			// 
			// compositeFramesContextMenuStrip
			// 
			this.compositeFramesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyRangeOfCompositeFramesToolStripMenuItem,
            this.flipRangeOfCompositeFramesHorizontallyToolStripMenuItem,
            this.slideRangeOfCompositeFramesToolStripMenuItem,
            this.removeSelectedCompositeFramesToolStripMenuItem});
			this.compositeFramesContextMenuStrip.Name = "compositeFramesContextMenuStrip";
			this.compositeFramesContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.compositeFramesContextMenuStrip.Size = new System.Drawing.Size(299, 92);
			this.compositeFramesContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.compositeFramesContextMenuStrip_Opening);
			// 
			// copyRangeOfCompositeFramesToolStripMenuItem
			// 
			this.copyRangeOfCompositeFramesToolStripMenuItem.Name = "copyRangeOfCompositeFramesToolStripMenuItem";
			this.copyRangeOfCompositeFramesToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
			this.copyRangeOfCompositeFramesToolStripMenuItem.Text = "Copy Range of Composite Frames";
			this.copyRangeOfCompositeFramesToolStripMenuItem.Click += new System.EventHandler(this.copyRangeOfCompositeFramesToolStripMenuItem_Click);
			// 
			// flipRangeOfCompositeFramesHorizontallyToolStripMenuItem
			// 
			this.flipRangeOfCompositeFramesHorizontallyToolStripMenuItem.Name = "flipRangeOfCompositeFramesHorizontallyToolStripMenuItem";
			this.flipRangeOfCompositeFramesHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
			this.flipRangeOfCompositeFramesHorizontallyToolStripMenuItem.Text = "Flip Range of Composite Frames Horizontally";
			this.flipRangeOfCompositeFramesHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.flipRangeOfCompositeFramesHorizontallyToolStripMenuItem_Click);
			// 
			// slideRangeOfCompositeFramesToolStripMenuItem
			// 
			this.slideRangeOfCompositeFramesToolStripMenuItem.Name = "slideRangeOfCompositeFramesToolStripMenuItem";
			this.slideRangeOfCompositeFramesToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
			this.slideRangeOfCompositeFramesToolStripMenuItem.Text = "Slide Range of Composite Frames";
			this.slideRangeOfCompositeFramesToolStripMenuItem.Click += new System.EventHandler(this.slideRangeOfCompositeFramesToolStripMenuItem_Click);
			// 
			// colorsListBox
			// 
			this.colorsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.colorsListBox.AutoArrange = false;
			this.colorsListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colorNameColumnHeader,
            this.colorNumberColumnHeader,
            this.colorSwatchColumnHeader,
            this.colorOpacityColumnHeader});
			this.colorsListBox.ContextMenuStrip = this.addColorContextMenuStrip;
			this.colorsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colorsListBox.FullRowSelect = true;
			this.colorsListBox.GridLines = true;
			listViewGroup5.Header = "Available Colors List";
			listViewGroup5.Name = "Colors";
			this.colorsListBox.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5});
			this.colorsListBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.colorsListBox.Location = new System.Drawing.Point(1, 0);
			this.colorsListBox.Name = "colorsListBox";
			this.colorsListBox.OwnerDraw = true;
			this.colorsListBox.Size = new System.Drawing.Size(251, 45);
			this.colorsListBox.TabIndex = 32;
			this.generalToolTip.SetToolTip(this.colorsListBox, "Add a named color. Colors are referenced in motion and color tweens by name.");
			this.colorsListBox.UseCompatibleStateImageBehavior = false;
			this.colorsListBox.View = System.Windows.Forms.View.Details;
			this.colorsListBox.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
			this.colorsListBox.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listBox1_DrawItem);
			this.colorsListBox.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);
			this.colorsListBox.SizeChanged += new System.EventHandler(this.ListBox1_SizeChanged);
			this.colorsListBox.Invalidated += new System.Windows.Forms.InvalidateEventHandler(this.listView1_Invalidated);
			this.colorsListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
			this.colorsListBox.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.colorsListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
			// 
			// colorNameColumnHeader
			// 
			this.colorNameColumnHeader.Text = "Name";
			this.colorNameColumnHeader.Width = 89;
			// 
			// colorNumberColumnHeader
			// 
			this.colorNumberColumnHeader.Text = "#";
			this.colorNumberColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colorNumberColumnHeader.Width = 23;
			// 
			// colorSwatchColumnHeader
			// 
			this.colorSwatchColumnHeader.Text = "Color";
			this.colorSwatchColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// colorOpacityColumnHeader
			// 
			this.colorOpacityColumnHeader.Text = "Opacity";
			this.colorOpacityColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colorOpacityColumnHeader.Width = 54;
			// 
			// framesListView
			// 
			this.framesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.framesListView.AutoArrange = false;
			this.framesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.framesIdColumnHeader,
            this.framesSColumnHeader,
            this.framesTColumnHeader,
            this.framesWColumnHeader,
            this.framesHColumnHeader});
			this.framesListView.ContextMenuStrip = this.frameContextMenuStrip;
			this.framesListView.FullRowSelect = true;
			listViewGroup6.Header = "Frames";
			listViewGroup6.Name = "listViewGroup2";
			this.framesListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup6});
			this.framesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.framesListView.Location = new System.Drawing.Point(1, 0);
			this.framesListView.Name = "framesListView";
			this.framesListView.Size = new System.Drawing.Size(251, 45);
			this.framesListView.TabIndex = 38;
			this.generalToolTip.SetToolTip(this.framesListView, "Add a frame object cut from the base image.");
			this.framesListView.UseCompatibleStateImageBehavior = false;
			this.framesListView.View = System.Windows.Forms.View.Details;
			this.framesListView.SizeChanged += new System.EventHandler(this.ListView_SizeChanged);
			this.framesListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.framesListView_KeyDown);
			this.framesListView.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			// 
			// framesIdColumnHeader
			// 
			this.framesIdColumnHeader.Text = "ID";
			this.framesIdColumnHeader.Width = 42;
			// 
			// framesSColumnHeader
			// 
			this.framesSColumnHeader.Text = "s";
			this.framesSColumnHeader.Width = 48;
			// 
			// framesTColumnHeader
			// 
			this.framesTColumnHeader.Text = "t";
			this.framesTColumnHeader.Width = 46;
			// 
			// framesWColumnHeader
			// 
			this.framesWColumnHeader.Text = "w";
			this.framesWColumnHeader.Width = 39;
			// 
			// framesHColumnHeader
			// 
			this.framesHColumnHeader.Text = "h";
			this.framesHColumnHeader.Width = 37;
			// 
			// namedAttachmentPointsListView
			// 
			this.namedAttachmentPointsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.namedAttachmentPointsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.namedAttachmentPointIdColumnHeader,
            this.namedAttachmentPointNameColumnHeader,
            this.namedAttachmentPointDescriptionColumnHeader});
			this.namedAttachmentPointsListView.ContextMenuStrip = this.namedAttachmentPointsContextMenuStrip;
			this.namedAttachmentPointsListView.FullRowSelect = true;
			listViewGroup7.Header = "Named Attachment Points";
			listViewGroup7.Name = "listViewGroup1";
			this.namedAttachmentPointsListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup7});
			this.namedAttachmentPointsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.namedAttachmentPointsListView.Location = new System.Drawing.Point(0, 0);
			this.namedAttachmentPointsListView.Name = "namedAttachmentPointsListView";
			this.namedAttachmentPointsListView.Size = new System.Drawing.Size(250, 45);
			this.namedAttachmentPointsListView.TabIndex = 1;
			this.generalToolTip.SetToolTip(this.namedAttachmentPointsListView, "Add named attachment points to allow robust animations.");
			this.namedAttachmentPointsListView.UseCompatibleStateImageBehavior = false;
			this.namedAttachmentPointsListView.View = System.Windows.Forms.View.Details;
			this.namedAttachmentPointsListView.SizeChanged += new System.EventHandler(this.ListView_SizeChanged);
			this.namedAttachmentPointsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.namedAttachmentPointsListView_KeyDown);
			this.namedAttachmentPointsListView.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			// 
			// namedAttachmentPointIdColumnHeader
			// 
			this.namedAttachmentPointIdColumnHeader.Text = "ID";
			this.namedAttachmentPointIdColumnHeader.Width = 41;
			// 
			// namedAttachmentPointNameColumnHeader
			// 
			this.namedAttachmentPointNameColumnHeader.Text = "Name";
			this.namedAttachmentPointNameColumnHeader.Width = 86;
			// 
			// namedAttachmentPointDescriptionColumnHeader
			// 
			this.namedAttachmentPointDescriptionColumnHeader.Text = "Description";
			this.namedAttachmentPointDescriptionColumnHeader.Width = 85;
			// 
			// namedAttachmentPointsContextMenuStrip
			// 
			this.namedAttachmentPointsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNamedAttachmentPointToolStripMenuItem,
            this.editNamedAttachmentPointToolStripMenuItem,
            this.removeNamedAttachmentPointToolStripMenuItem});
			this.namedAttachmentPointsContextMenuStrip.Name = "namedAttachmentPointsContextMenuStrip";
			this.namedAttachmentPointsContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.namedAttachmentPointsContextMenuStrip.Size = new System.Drawing.Size(247, 70);
			this.namedAttachmentPointsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.namedAttachmentPointsContextMenuStrip_Opening);
			// 
			// addNamedAttachmentPointToolStripMenuItem
			// 
			this.addNamedAttachmentPointToolStripMenuItem.Name = "addNamedAttachmentPointToolStripMenuItem";
			this.addNamedAttachmentPointToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
			this.addNamedAttachmentPointToolStripMenuItem.Text = "Add Named Attachment Point";
			this.addNamedAttachmentPointToolStripMenuItem.Click += new System.EventHandler(this.addNamedAttachmentPointToolStripMenuItem_Click);
			// 
			// editNamedAttachmentPointToolStripMenuItem
			// 
			this.editNamedAttachmentPointToolStripMenuItem.Enabled = false;
			this.editNamedAttachmentPointToolStripMenuItem.Name = "editNamedAttachmentPointToolStripMenuItem";
			this.editNamedAttachmentPointToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
			this.editNamedAttachmentPointToolStripMenuItem.Text = "Edit Named Attachment Point";
			this.editNamedAttachmentPointToolStripMenuItem.Click += new System.EventHandler(this.editNamedAttachmentPointToolStripMenuItem_Click);
			// 
			// removeNamedAttachmentPointToolStripMenuItem
			// 
			this.removeNamedAttachmentPointToolStripMenuItem.Enabled = false;
			this.removeNamedAttachmentPointToolStripMenuItem.Name = "removeNamedAttachmentPointToolStripMenuItem";
			this.removeNamedAttachmentPointToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
			this.removeNamedAttachmentPointToolStripMenuItem.Text = "Remove Named Attachment Point";
			this.removeNamedAttachmentPointToolStripMenuItem.Click += new System.EventHandler(this.removeNamedAttachmentPointToolStripMenuItem_Click);
			// 
			// compositeFrameSetsListView
			// 
			this.compositeFrameSetsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.compositeFrameSetsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.compositeFrameSetNameColumnHeader,
            this.compositeFrameSetFramesColumnHeader});
			this.compositeFrameSetsListView.ContextMenuStrip = this.compositeFrameSetContextMenuStrip;
			this.compositeFrameSetsListView.FullRowSelect = true;
			listViewGroup8.Header = "Composite Frame Sets";
			listViewGroup8.Name = "listViewGroup1";
			this.compositeFrameSetsListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup8});
			this.compositeFrameSetsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.compositeFrameSetsListView.Location = new System.Drawing.Point(1, 0);
			this.compositeFrameSetsListView.Name = "compositeFrameSetsListView";
			this.compositeFrameSetsListView.Size = new System.Drawing.Size(251, 45);
			this.compositeFrameSetsListView.TabIndex = 0;
			this.generalToolTip.SetToolTip(this.compositeFrameSetsListView, "Manipulate composite frames that have been created previously.");
			this.compositeFrameSetsListView.UseCompatibleStateImageBehavior = false;
			this.compositeFrameSetsListView.View = System.Windows.Forms.View.Details;
			this.compositeFrameSetsListView.SizeChanged += new System.EventHandler(this.ListView_SizeChanged);
			this.compositeFrameSetsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.compositeFrameSetsListView_KeyDown);
			this.compositeFrameSetsListView.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			// 
			// compositeFrameSetNameColumnHeader
			// 
			this.compositeFrameSetNameColumnHeader.Text = "Name";
			this.compositeFrameSetNameColumnHeader.Width = 133;
			// 
			// compositeFrameSetFramesColumnHeader
			// 
			this.compositeFrameSetFramesColumnHeader.Text = "Frames";
			this.compositeFrameSetFramesColumnHeader.Width = 80;
			// 
			// compositeFrameSetContextMenuStrip
			// 
			this.compositeFrameSetContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCompositeFrameSetToolStripMenuItem,
            this.editCompositeFrameSetToolStripMenuItem,
            this.removeCompositeFrameSetToolStripMenuItem});
			this.compositeFrameSetContextMenuStrip.Name = "compositeFrameSetContextMenuStrip";
			this.compositeFrameSetContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.compositeFrameSetContextMenuStrip.Size = new System.Drawing.Size(230, 70);
			this.compositeFrameSetContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.compositeFrameSetContextMenuStrip_Opening);
			// 
			// addCompositeFrameSetToolStripMenuItem
			// 
			this.addCompositeFrameSetToolStripMenuItem.Name = "addCompositeFrameSetToolStripMenuItem";
			this.addCompositeFrameSetToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
			this.addCompositeFrameSetToolStripMenuItem.Text = "Add Composite Frame Set";
			this.addCompositeFrameSetToolStripMenuItem.Click += new System.EventHandler(this.addCompositeFrameSetToolStripMenuItem_Click);
			// 
			// editCompositeFrameSetToolStripMenuItem
			// 
			this.editCompositeFrameSetToolStripMenuItem.Enabled = false;
			this.editCompositeFrameSetToolStripMenuItem.Name = "editCompositeFrameSetToolStripMenuItem";
			this.editCompositeFrameSetToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
			this.editCompositeFrameSetToolStripMenuItem.Text = "Edit Composite Frame Set";
			this.editCompositeFrameSetToolStripMenuItem.Click += new System.EventHandler(this.editCompositeFrameSetToolStripMenuItem_Click);
			// 
			// removeCompositeFrameSetToolStripMenuItem
			// 
			this.removeCompositeFrameSetToolStripMenuItem.Enabled = false;
			this.removeCompositeFrameSetToolStripMenuItem.Name = "removeCompositeFrameSetToolStripMenuItem";
			this.removeCompositeFrameSetToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
			this.removeCompositeFrameSetToolStripMenuItem.Text = "Remove Composite Frame Set";
			this.removeCompositeFrameSetToolStripMenuItem.Click += new System.EventHandler(this.removeCompositeFrameSetToolStripMenuItem_Click);
			// 
			// soundsListView
			// 
			this.soundsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.soundsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.soundsNameColumnHeader,
            this.soundsFilenameColumnHeader,
            this.soundsDisplayColorColumnHeader});
			this.soundsListView.ContextMenuStrip = this.soundContextMenuStrip;
			this.soundsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.soundsListView.Location = new System.Drawing.Point(1, 0);
			this.soundsListView.Name = "soundsListView";
			this.soundsListView.Size = new System.Drawing.Size(501, 43);
			this.soundsListView.TabIndex = 0;
			this.generalToolTip.SetToolTip(this.soundsListView, "Add sounds to the available sound pool.");
			this.soundsListView.UseCompatibleStateImageBehavior = false;
			this.soundsListView.View = System.Windows.Forms.View.Details;
			this.soundsListView.SizeChanged += new System.EventHandler(this.ListView_SizeChanged);
			this.soundsListView.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			// 
			// soundsNameColumnHeader
			// 
			this.soundsNameColumnHeader.Text = "Name";
			this.soundsNameColumnHeader.Width = 80;
			// 
			// soundsFilenameColumnHeader
			// 
			this.soundsFilenameColumnHeader.Text = "Filename";
			this.soundsFilenameColumnHeader.Width = 242;
			// 
			// soundsDisplayColorColumnHeader
			// 
			this.soundsDisplayColorColumnHeader.Text = "Display Color";
			this.soundsDisplayColorColumnHeader.Width = 140;
			// 
			// soundContextMenuStrip
			// 
			this.soundContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSoundToolStripMenuItem,
            this.editSoundToolStripMenuItem,
            this.removeSoundToolStripMenuItem});
			this.soundContextMenuStrip.Name = "soundContextMenuStrip";
			this.soundContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.soundContextMenuStrip.Size = new System.Drawing.Size(162, 70);
			this.soundContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.soundContextMenuStrip_Opening);
			// 
			// addNewSoundToolStripMenuItem
			// 
			this.addNewSoundToolStripMenuItem.Name = "addNewSoundToolStripMenuItem";
			this.addNewSoundToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.addNewSoundToolStripMenuItem.Text = "Add New Sound";
			this.addNewSoundToolStripMenuItem.Click += new System.EventHandler(this.addNewSoundToolStripMenuItem_Click);
			// 
			// editSoundToolStripMenuItem
			// 
			this.editSoundToolStripMenuItem.Enabled = false;
			this.editSoundToolStripMenuItem.Name = "editSoundToolStripMenuItem";
			this.editSoundToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.editSoundToolStripMenuItem.Text = "Edit Sound";
			this.editSoundToolStripMenuItem.Click += new System.EventHandler(this.editSoundToolStripMenuItem_Click);
			// 
			// removeSoundToolStripMenuItem
			// 
			this.removeSoundToolStripMenuItem.Enabled = false;
			this.removeSoundToolStripMenuItem.Name = "removeSoundToolStripMenuItem";
			this.removeSoundToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.removeSoundToolStripMenuItem.Text = "Remove Sound";
			this.removeSoundToolStripMenuItem.Click += new System.EventHandler(this.removeSoundToolStripMenuItem_Click);
			// 
			// lowerTableLayoutPanel
			// 
			this.lowerTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lowerTableLayoutPanel.ColumnCount = 2;
			this.lowerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.lowerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.lowerTableLayoutPanel.Controls.Add(this.namedAttachmentPointsPanel, 1, 7);
			this.lowerTableLayoutPanel.Controls.Add(this.availableColorsAndGuidesButtonPanel, 0, 0);
			this.lowerTableLayoutPanel.Controls.Add(this.guidesPanel, 1, 1);
			this.lowerTableLayoutPanel.Controls.Add(this.colorAndMotionTweensPanel, 0, 3);
			this.lowerTableLayoutPanel.Controls.Add(this.colorAndMotionTweensButtonPanel, 0, 2);
			this.lowerTableLayoutPanel.Controls.Add(this.compositeFrameSetsPanel, 0, 7);
			this.lowerTableLayoutPanel.Controls.Add(this.compositeFramesPanel, 1, 5);
			this.lowerTableLayoutPanel.Controls.Add(this.frameAndCompositeFramesButtonPanel, 0, 4);
			this.lowerTableLayoutPanel.Controls.Add(this.colorsPanel, 0, 1);
			this.lowerTableLayoutPanel.Controls.Add(this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel, 0, 6);
			this.lowerTableLayoutPanel.Controls.Add(this.framesPanel, 0, 5);
			this.lowerTableLayoutPanel.Controls.Add(this.saveButton, 0, 11);
			this.lowerTableLayoutPanel.Controls.Add(this.closeButton, 1, 11);
			this.lowerTableLayoutPanel.Controls.Add(this.soundsButtonPanel, 0, 8);
			this.lowerTableLayoutPanel.Controls.Add(this.soundsPanel, 0, 9);
			this.lowerTableLayoutPanel.Location = new System.Drawing.Point(144, 312);
			this.lowerTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.lowerTableLayoutPanel.Name = "lowerTableLayoutPanel";
			this.lowerTableLayoutPanel.RowCount = 12;
			this.lowerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.lowerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.99995F));
			this.lowerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.lowerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.99995F));
			this.lowerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.lowerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.99995F));
			this.lowerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.lowerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.99995F));
			this.lowerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.lowerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0002F));
			this.lowerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
			this.lowerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.lowerTableLayoutPanel.Size = new System.Drawing.Size(504, 360);
			this.lowerTableLayoutPanel.TabIndex = 37;
			// 
			// namedAttachmentPointsPanel
			// 
			this.namedAttachmentPointsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.namedAttachmentPointsPanel.BackColor = System.Drawing.Color.SlateGray;
			this.namedAttachmentPointsPanel.Controls.Add(this.namedAttachmentPointsListView);
			this.namedAttachmentPointsPanel.Location = new System.Drawing.Point(252, 218);
			this.namedAttachmentPointsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.namedAttachmentPointsPanel.Name = "namedAttachmentPointsPanel";
			this.namedAttachmentPointsPanel.Size = new System.Drawing.Size(252, 46);
			this.namedAttachmentPointsPanel.TabIndex = 48;
			// 
			// availableColorsAndGuidesButtonPanel
			// 
			this.availableColorsAndGuidesButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.availableColorsAndGuidesButtonPanel.BackColor = System.Drawing.SystemColors.Control;
			this.availableColorsAndGuidesButtonPanel.BorderColor = System.Drawing.Color.SlateGray;
			this.availableColorsAndGuidesButtonPanel.BorderWidth = 2;
			this.availableColorsAndGuidesButtonPanel.ColorSteps = 11D;
			this.lowerTableLayoutPanel.SetColumnSpan(this.availableColorsAndGuidesButtonPanel, 2);
			this.availableColorsAndGuidesButtonPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.availableColorsAndGuidesButtonPanel.ForeColor = System.Drawing.Color.Black;
			this.availableColorsAndGuidesButtonPanel.GradientColor = System.Drawing.Color.Silver;
			this.availableColorsAndGuidesButtonPanel.HoverGradientColor = System.Drawing.Color.LightSlateGray;
			this.availableColorsAndGuidesButtonPanel.Location = new System.Drawing.Point(0, 0);
			this.availableColorsAndGuidesButtonPanel.Margin = new System.Windows.Forms.Padding(0);
			this.availableColorsAndGuidesButtonPanel.Name = "availableColorsAndGuidesButtonPanel";
			this.availableColorsAndGuidesButtonPanel.Size = new System.Drawing.Size(504, 20);
			this.availableColorsAndGuidesButtonPanel.TabIndex = 40;
			this.availableColorsAndGuidesButtonPanel.Title = "Available Colors & Guides";
			this.availableColorsAndGuidesButtonPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonPanel1_MouseClick);
			this.availableColorsAndGuidesButtonPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.buttonPanel1_MouseDoubleClick);
			// 
			// guidesPanel
			// 
			this.guidesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.guidesPanel.BackColor = System.Drawing.Color.SlateGray;
			this.guidesPanel.Controls.Add(this.guidesListBox);
			this.guidesPanel.Location = new System.Drawing.Point(252, 20);
			this.guidesPanel.Margin = new System.Windows.Forms.Padding(0);
			this.guidesPanel.Name = "guidesPanel";
			this.guidesPanel.Padding = new System.Windows.Forms.Padding(0, 0, 2, 1);
			this.guidesPanel.Size = new System.Drawing.Size(252, 46);
			this.guidesPanel.TabIndex = 37;
			// 
			// colorAndMotionTweensPanel
			// 
			this.colorAndMotionTweensPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.colorAndMotionTweensPanel.BackColor = System.Drawing.Color.SlateGray;
			this.lowerTableLayoutPanel.SetColumnSpan(this.colorAndMotionTweensPanel, 2);
			this.colorAndMotionTweensPanel.Controls.Add(this.tweensListBox);
			this.colorAndMotionTweensPanel.Location = new System.Drawing.Point(0, 86);
			this.colorAndMotionTweensPanel.Margin = new System.Windows.Forms.Padding(0);
			this.colorAndMotionTweensPanel.Name = "colorAndMotionTweensPanel";
			this.colorAndMotionTweensPanel.Padding = new System.Windows.Forms.Padding(1, 0, 2, 1);
			this.colorAndMotionTweensPanel.Size = new System.Drawing.Size(504, 46);
			this.colorAndMotionTweensPanel.TabIndex = 37;
			// 
			// colorAndMotionTweensButtonPanel
			// 
			this.colorAndMotionTweensButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.colorAndMotionTweensButtonPanel.BackColor = System.Drawing.SystemColors.Control;
			this.colorAndMotionTweensButtonPanel.BorderColor = System.Drawing.Color.SlateGray;
			this.colorAndMotionTweensButtonPanel.BorderWidth = 2;
			this.colorAndMotionTweensButtonPanel.ColorSteps = 11D;
			this.lowerTableLayoutPanel.SetColumnSpan(this.colorAndMotionTweensButtonPanel, 2);
			this.colorAndMotionTweensButtonPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colorAndMotionTweensButtonPanel.ForeColor = System.Drawing.Color.Black;
			this.colorAndMotionTweensButtonPanel.GradientColor = System.Drawing.Color.Silver;
			this.colorAndMotionTweensButtonPanel.HoverGradientColor = System.Drawing.Color.LightSlateGray;
			this.colorAndMotionTweensButtonPanel.Location = new System.Drawing.Point(0, 66);
			this.colorAndMotionTweensButtonPanel.Margin = new System.Windows.Forms.Padding(0);
			this.colorAndMotionTweensButtonPanel.Name = "colorAndMotionTweensButtonPanel";
			this.colorAndMotionTweensButtonPanel.Size = new System.Drawing.Size(504, 20);
			this.colorAndMotionTweensButtonPanel.TabIndex = 41;
			this.colorAndMotionTweensButtonPanel.Title = "Color & Motion Tweens";
			this.colorAndMotionTweensButtonPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonPanel2_MouseClick);
			this.colorAndMotionTweensButtonPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.buttonPanel2_MouseDoubleClick);
			// 
			// compositeFrameSetsPanel
			// 
			this.compositeFrameSetsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.compositeFrameSetsPanel.BackColor = System.Drawing.Color.SlateGray;
			this.compositeFrameSetsPanel.Controls.Add(this.compositeFrameSetsListView);
			this.compositeFrameSetsPanel.Location = new System.Drawing.Point(0, 218);
			this.compositeFrameSetsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.compositeFrameSetsPanel.Name = "compositeFrameSetsPanel";
			this.compositeFrameSetsPanel.Padding = new System.Windows.Forms.Padding(1, 0, 0, 1);
			this.compositeFrameSetsPanel.Size = new System.Drawing.Size(252, 46);
			this.compositeFrameSetsPanel.TabIndex = 37;
			// 
			// compositeFramesPanel
			// 
			this.compositeFramesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.compositeFramesPanel.BackColor = System.Drawing.Color.SlateGray;
			this.compositeFramesPanel.Controls.Add(this.compositeFramesListView);
			this.compositeFramesPanel.Location = new System.Drawing.Point(252, 152);
			this.compositeFramesPanel.Margin = new System.Windows.Forms.Padding(0);
			this.compositeFramesPanel.Name = "compositeFramesPanel";
			this.compositeFramesPanel.Padding = new System.Windows.Forms.Padding(0, 0, 2, 1);
			this.compositeFramesPanel.Size = new System.Drawing.Size(252, 46);
			this.compositeFramesPanel.TabIndex = 40;
			// 
			// frameAndCompositeFramesButtonPanel
			// 
			this.frameAndCompositeFramesButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.frameAndCompositeFramesButtonPanel.BackColor = System.Drawing.SystemColors.Control;
			this.frameAndCompositeFramesButtonPanel.BorderColor = System.Drawing.Color.SlateGray;
			this.frameAndCompositeFramesButtonPanel.BorderWidth = 2;
			this.frameAndCompositeFramesButtonPanel.ColorSteps = 11D;
			this.lowerTableLayoutPanel.SetColumnSpan(this.frameAndCompositeFramesButtonPanel, 2);
			this.frameAndCompositeFramesButtonPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.frameAndCompositeFramesButtonPanel.ForeColor = System.Drawing.Color.Black;
			this.frameAndCompositeFramesButtonPanel.GradientColor = System.Drawing.Color.Silver;
			this.frameAndCompositeFramesButtonPanel.HoverGradientColor = System.Drawing.Color.LightSlateGray;
			this.frameAndCompositeFramesButtonPanel.Location = new System.Drawing.Point(0, 132);
			this.frameAndCompositeFramesButtonPanel.Margin = new System.Windows.Forms.Padding(0);
			this.frameAndCompositeFramesButtonPanel.Name = "frameAndCompositeFramesButtonPanel";
			this.frameAndCompositeFramesButtonPanel.Size = new System.Drawing.Size(504, 20);
			this.frameAndCompositeFramesButtonPanel.TabIndex = 42;
			this.frameAndCompositeFramesButtonPanel.Title = "Frames & Composite Frames";
			this.frameAndCompositeFramesButtonPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonPanel3_MouseClick);
			this.frameAndCompositeFramesButtonPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.buttonPanel3_MouseDoubleClick);
			// 
			// colorsPanel
			// 
			this.colorsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.colorsPanel.BackColor = System.Drawing.Color.SlateGray;
			this.colorsPanel.Controls.Add(this.colorsListBox);
			this.colorsPanel.Location = new System.Drawing.Point(0, 20);
			this.colorsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.colorsPanel.Name = "colorsPanel";
			this.colorsPanel.Padding = new System.Windows.Forms.Padding(1, 0, 0, 1);
			this.colorsPanel.Size = new System.Drawing.Size(252, 46);
			this.colorsPanel.TabIndex = 37;
			// 
			// compositeFrameSetsAndNamedAttachmentPointsButtonPanel
			// 
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.BackColor = System.Drawing.SystemColors.Control;
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.BorderColor = System.Drawing.Color.SlateGray;
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.BorderWidth = 2;
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.ColorSteps = 11D;
			this.lowerTableLayoutPanel.SetColumnSpan(this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel, 2);
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.ForeColor = System.Drawing.Color.Black;
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.GradientColor = System.Drawing.Color.Silver;
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.HoverGradientColor = System.Drawing.Color.LightSlateGray;
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.Location = new System.Drawing.Point(0, 198);
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.Margin = new System.Windows.Forms.Padding(0);
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.Name = "compositeFrameSetsAndNamedAttachmentPointsButtonPanel";
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.Size = new System.Drawing.Size(504, 20);
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.TabIndex = 43;
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.Title = "Composite Frame Sets & Named Attachment Points";
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonPanel4_MouseClick);
			this.compositeFrameSetsAndNamedAttachmentPointsButtonPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.buttonPanel4_MouseDoubleClick);
			// 
			// framesPanel
			// 
			this.framesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.framesPanel.BackColor = System.Drawing.Color.SlateGray;
			this.framesPanel.Controls.Add(this.framesListView);
			this.framesPanel.Location = new System.Drawing.Point(0, 152);
			this.framesPanel.Margin = new System.Windows.Forms.Padding(0);
			this.framesPanel.Name = "framesPanel";
			this.framesPanel.Padding = new System.Windows.Forms.Padding(1, 0, 0, 1);
			this.framesPanel.Size = new System.Drawing.Size(252, 46);
			this.framesPanel.TabIndex = 37;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.AutoSize = true;
			this.saveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.saveButton.Location = new System.Drawing.Point(207, 334);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(42, 23);
			this.saveButton.TabIndex = 27;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.closeButton.AutoSize = true;
			this.closeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Location = new System.Drawing.Point(255, 334);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(43, 23);
			this.closeButton.TabIndex = 28;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// soundsButtonPanel
			// 
			this.soundsButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.soundsButtonPanel.BorderColor = System.Drawing.Color.SlateGray;
			this.soundsButtonPanel.BorderWidth = 2;
			this.soundsButtonPanel.ColorSteps = 11D;
			this.lowerTableLayoutPanel.SetColumnSpan(this.soundsButtonPanel, 2);
			this.soundsButtonPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.soundsButtonPanel.GradientColor = System.Drawing.Color.Silver;
			this.soundsButtonPanel.HoverGradientColor = System.Drawing.Color.LightSlateGray;
			this.soundsButtonPanel.Location = new System.Drawing.Point(0, 264);
			this.soundsButtonPanel.Margin = new System.Windows.Forms.Padding(0);
			this.soundsButtonPanel.Name = "soundsButtonPanel";
			this.soundsButtonPanel.Size = new System.Drawing.Size(504, 20);
			this.soundsButtonPanel.TabIndex = 44;
			this.soundsButtonPanel.Title = "Sounds";
			this.soundsButtonPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonPanel5_MouseClick);
			this.soundsButtonPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.buttonPanel5_MouseDoubleClick);
			// 
			// soundsPanel
			// 
			this.soundsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.soundsPanel.BackColor = System.Drawing.Color.SlateGray;
			this.lowerTableLayoutPanel.SetColumnSpan(this.soundsPanel, 2);
			this.soundsPanel.Controls.Add(this.soundsListView);
			this.soundsPanel.Location = new System.Drawing.Point(0, 284);
			this.soundsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.soundsPanel.Name = "soundsPanel";
			this.soundsPanel.Padding = new System.Windows.Forms.Padding(1, 0, 2, 1);
			this.soundsPanel.Size = new System.Drawing.Size(504, 46);
			this.soundsPanel.TabIndex = 45;
			// 
			// sourceImageMaskedTextBox
			// 
			this.sourceImageMaskedTextBox.AllowBlank = true;
			this.sourceImageMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.sourceImageMaskedTextBox.EmptyText = "OPTIONAL. Load a source image to cut frames out from.";
			this.sourceImageMaskedTextBox.Interval = 0.5D;
			this.sourceImageMaskedTextBox.Location = new System.Drawing.Point(144, 267);
			this.sourceImageMaskedTextBox.MarkInvalid = false;
			this.sourceImageMaskedTextBox.Name = "sourceImageMaskedTextBox";
			this.sourceImageMaskedTextBox.Size = new System.Drawing.Size(440, 20);
			this.sourceImageMaskedTextBox.TabIndex = 24;
			// 
			// onLoadZoomMaskedTextBox
			// 
			this.onLoadZoomMaskedTextBox.AllowBlank = true;
			this.onLoadZoomMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.onLoadZoomMaskedTextBox.Ceiling = 10D;
			this.onLoadZoomMaskedTextBox.EmptyText = "OPTIONAL. On load, zoom by factor (e.g. 2.00 for doubled size; 0.50 for half-size" +
				").";
			this.onLoadZoomMaskedTextBox.Interval = 0.5D;
			this.onLoadZoomMaskedTextBox.Location = new System.Drawing.Point(144, 242);
			this.onLoadZoomMaskedTextBox.MarkInvalid = false;
			this.onLoadZoomMaskedTextBox.Mask = "0.00";
			this.onLoadZoomMaskedTextBox.Name = "onLoadZoomMaskedTextBox";
			this.onLoadZoomMaskedTextBox.Size = new System.Drawing.Size(504, 20);
			this.onLoadZoomMaskedTextBox.TabIndex = 23;
			// 
			// targetMillisecondsMaskedTextBox
			// 
			this.targetMillisecondsMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.targetMillisecondsMaskedTextBox.Ceiling = 99999D;
			this.targetMillisecondsMaskedTextBox.EmptyText = "How many milliseconds between each frame?";
			this.targetMillisecondsMaskedTextBox.Floor = 1D;
			this.targetMillisecondsMaskedTextBox.HidePromptOnLeave = true;
			this.targetMillisecondsMaskedTextBox.Interval = 0.5D;
			this.targetMillisecondsMaskedTextBox.IsNumeric = true;
			this.targetMillisecondsMaskedTextBox.Location = new System.Drawing.Point(144, 218);
			this.targetMillisecondsMaskedTextBox.MarkInvalid = false;
			this.targetMillisecondsMaskedTextBox.Mask = "09999";
			this.targetMillisecondsMaskedTextBox.Name = "targetMillisecondsMaskedTextBox";
			this.targetMillisecondsMaskedTextBox.Size = new System.Drawing.Size(504, 20);
			this.targetMillisecondsMaskedTextBox.TabIndex = 22;
			// 
			// endFrameMaskedTextBox
			// 
			this.endFrameMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.endFrameMaskedTextBox.Ceiling = 99999D;
			this.endFrameMaskedTextBox.EmptyText = "Last frame for animation queue at load time?";
			this.endFrameMaskedTextBox.Floor = 1D;
			this.endFrameMaskedTextBox.HidePromptOnLeave = true;
			this.endFrameMaskedTextBox.Interval = 0.5D;
			this.endFrameMaskedTextBox.IsNumeric = true;
			this.endFrameMaskedTextBox.Location = new System.Drawing.Point(144, 194);
			this.endFrameMaskedTextBox.MarkInvalid = false;
			this.endFrameMaskedTextBox.Mask = "09999";
			this.endFrameMaskedTextBox.Name = "endFrameMaskedTextBox";
			this.endFrameMaskedTextBox.Size = new System.Drawing.Size(504, 20);
			this.endFrameMaskedTextBox.TabIndex = 21;
			// 
			// startFrameMaskedTextBox
			// 
			this.startFrameMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.startFrameMaskedTextBox.Ceiling = 99999D;
			this.startFrameMaskedTextBox.EmptyText = "First frame for animation queue at load time?";
			this.startFrameMaskedTextBox.Floor = 1D;
			this.startFrameMaskedTextBox.HidePromptOnLeave = true;
			this.startFrameMaskedTextBox.Interval = 0.5D;
			this.startFrameMaskedTextBox.IsNumeric = true;
			this.startFrameMaskedTextBox.Location = new System.Drawing.Point(144, 169);
			this.startFrameMaskedTextBox.MarkInvalid = false;
			this.startFrameMaskedTextBox.Mask = "09999";
			this.startFrameMaskedTextBox.Name = "startFrameMaskedTextBox";
			this.startFrameMaskedTextBox.Size = new System.Drawing.Size(504, 20);
			this.startFrameMaskedTextBox.TabIndex = 20;
			// 
			// columnCountMaskedTextBox
			// 
			this.columnCountMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.columnCountMaskedTextBox.Ceiling = 99999D;
			this.columnCountMaskedTextBox.EmptyText = "How many frames per row will be displayed?";
			this.columnCountMaskedTextBox.Floor = 1D;
			this.columnCountMaskedTextBox.HidePromptOnLeave = true;
			this.columnCountMaskedTextBox.Interval = 0.5D;
			this.columnCountMaskedTextBox.IsNumeric = true;
			this.columnCountMaskedTextBox.Location = new System.Drawing.Point(144, 145);
			this.columnCountMaskedTextBox.MarkInvalid = false;
			this.columnCountMaskedTextBox.Mask = "09999";
			this.columnCountMaskedTextBox.Name = "columnCountMaskedTextBox";
			this.columnCountMaskedTextBox.Size = new System.Drawing.Size(504, 20);
			this.columnCountMaskedTextBox.TabIndex = 19;
			// 
			// rowCountMaskedTextBox
			// 
			this.rowCountMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rowCountMaskedTextBox.Ceiling = 99999D;
			this.rowCountMaskedTextBox.EmptyText = "How many rows will be displayed?";
			this.rowCountMaskedTextBox.Floor = 1D;
			this.rowCountMaskedTextBox.HidePromptOnLeave = true;
			this.rowCountMaskedTextBox.Interval = 0.5D;
			this.rowCountMaskedTextBox.IsNumeric = true;
			this.rowCountMaskedTextBox.Location = new System.Drawing.Point(144, 121);
			this.rowCountMaskedTextBox.MarkInvalid = false;
			this.rowCountMaskedTextBox.Mask = "09999";
			this.rowCountMaskedTextBox.Name = "rowCountMaskedTextBox";
			this.rowCountMaskedTextBox.Size = new System.Drawing.Size(504, 20);
			this.rowCountMaskedTextBox.TabIndex = 18;
			// 
			// frameHeightMaskedTextBox
			// 
			this.frameHeightMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.frameHeightMaskedTextBox.Ceiling = 99999D;
			this.frameHeightMaskedTextBox.EmptyText = "How tall is each output frame?";
			this.frameHeightMaskedTextBox.Floor = 1D;
			this.frameHeightMaskedTextBox.HidePromptOnLeave = true;
			this.frameHeightMaskedTextBox.Interval = 0.5D;
			this.frameHeightMaskedTextBox.IsNumeric = true;
			this.frameHeightMaskedTextBox.Location = new System.Drawing.Point(144, 97);
			this.frameHeightMaskedTextBox.MarkInvalid = false;
			this.frameHeightMaskedTextBox.Mask = "09999";
			this.frameHeightMaskedTextBox.Name = "frameHeightMaskedTextBox";
			this.frameHeightMaskedTextBox.Size = new System.Drawing.Size(504, 20);
			this.frameHeightMaskedTextBox.TabIndex = 17;
			// 
			// frameWidthMaskedTextBox
			// 
			this.frameWidthMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.frameWidthMaskedTextBox.Ceiling = 99999D;
			this.frameWidthMaskedTextBox.EmptyText = "How wide is each output frame?";
			this.frameWidthMaskedTextBox.Floor = 1D;
			this.frameWidthMaskedTextBox.HidePromptOnLeave = true;
			this.frameWidthMaskedTextBox.Interval = 0.5D;
			this.frameWidthMaskedTextBox.IsNumeric = true;
			this.frameWidthMaskedTextBox.Location = new System.Drawing.Point(144, 73);
			this.frameWidthMaskedTextBox.MarkInvalid = false;
			this.frameWidthMaskedTextBox.Mask = "09999";
			this.frameWidthMaskedTextBox.Name = "frameWidthMaskedTextBox";
			this.frameWidthMaskedTextBox.Size = new System.Drawing.Size(504, 20);
			this.frameWidthMaskedTextBox.TabIndex = 16;
			// 
			// formatStatusMaskedTextBox
			// 
			this.formatStatusMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.formatStatusMaskedTextBox.EmptyText = "How complete is this format?";
			this.formatStatusMaskedTextBox.Interval = 0.5D;
			this.formatStatusMaskedTextBox.Location = new System.Drawing.Point(144, 49);
			this.formatStatusMaskedTextBox.MarkInvalid = false;
			this.formatStatusMaskedTextBox.Name = "formatStatusMaskedTextBox";
			this.formatStatusMaskedTextBox.Size = new System.Drawing.Size(504, 20);
			this.formatStatusMaskedTextBox.TabIndex = 15;
			// 
			// formatDescriptionMaskedTextBox
			// 
			this.formatDescriptionMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.formatDescriptionMaskedTextBox.EmptyText = "Enter a description of acceptable files.";
			this.formatDescriptionMaskedTextBox.Interval = 0.5D;
			this.formatDescriptionMaskedTextBox.Location = new System.Drawing.Point(144, 26);
			this.formatDescriptionMaskedTextBox.MarkInvalid = false;
			this.formatDescriptionMaskedTextBox.Name = "formatDescriptionMaskedTextBox";
			this.formatDescriptionMaskedTextBox.Size = new System.Drawing.Size(504, 20);
			this.formatDescriptionMaskedTextBox.TabIndex = 14;
			// 
			// fileTypeMaskedTextBox
			// 
			this.fileTypeMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.fileTypeMaskedTextBox.EmptyText = "Enter the name of the format you\'re creating (note: this becomes a folder name).";
			this.fileTypeMaskedTextBox.Interval = 0.5D;
			this.fileTypeMaskedTextBox.Location = new System.Drawing.Point(144, 3);
			this.fileTypeMaskedTextBox.MarkInvalid = false;
			this.fileTypeMaskedTextBox.Name = "fileTypeMaskedTextBox";
			this.fileTypeMaskedTextBox.Size = new System.Drawing.Size(504, 20);
			this.fileTypeMaskedTextBox.TabIndex = 13;
			// 
			// removeSelectedCompositeFramesToolStripMenuItem
			// 
			this.removeSelectedCompositeFramesToolStripMenuItem.Name = "removeSelectedCompositeFramesToolStripMenuItem";
			this.removeSelectedCompositeFramesToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
			this.removeSelectedCompositeFramesToolStripMenuItem.Text = "Remove Selected Composite Frames";
			this.removeSelectedCompositeFramesToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedCompositeFramesToolStripMenuItem_Click);
			// 
			// AddOrEditFormat
			// 
			this.AcceptButton = this.saveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.closeButton;
			this.ClientSize = new System.Drawing.Size(661, 677);
			this.Controls.Add(this.lowerTableLayoutPanel);
			this.Controls.Add(this.browseForReferenceImageButton);
			this.Controls.Add(this.useNoSamplingCheckBox);
			this.Controls.Add(this.sourceImageMaskedTextBox);
			this.Controls.Add(this.onLoadZoomMaskedTextBox);
			this.Controls.Add(this.targetMillisecondsMaskedTextBox);
			this.Controls.Add(this.endFrameMaskedTextBox);
			this.Controls.Add(this.startFrameMaskedTextBox);
			this.Controls.Add(this.columnCountMaskedTextBox);
			this.Controls.Add(this.rowCountMaskedTextBox);
			this.Controls.Add(this.frameHeightMaskedTextBox);
			this.Controls.Add(this.frameWidthMaskedTextBox);
			this.Controls.Add(this.formatStatusMaskedTextBox);
			this.Controls.Add(this.formatDescriptionMaskedTextBox);
			this.Controls.Add(this.fileTypeMaskedTextBox);
			this.Controls.Add(this.useNoImageSamplingLabel);
			this.Controls.Add(this.sourceImageLabel);
			this.Controls.Add(this.onLoadZoomLabel);
			this.Controls.Add(this.targetMSLabel);
			this.Controls.Add(this.endFrameLabel);
			this.Controls.Add(this.startFrameLabel);
			this.Controls.Add(this.columnsLabel);
			this.Controls.Add(this.rowsLabel);
			this.Controls.Add(this.frameHeightLabel);
			this.Controls.Add(this.frameWidthLabel);
			this.Controls.Add(this.formatStatusLabel);
			this.Controls.Add(this.formatDescriptionLabel);
			this.Controls.Add(this.fileTypeLabel);
			this.MinimumSize = new System.Drawing.Size(381, 500);
			this.Name = "AddOrEditFormat";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Create Format or Edit Existing Format";
			this.Deactivate += new System.EventHandler(this.NewFormat_Deactivate);
			this.guideContextMenuStrip.ResumeLayout(false);
			this.tweenContextMenuStrip.ResumeLayout(false);
			this.addColorContextMenuStrip.ResumeLayout(false);
			this.frameContextMenuStrip.ResumeLayout(false);
			this.compositeFramesContextMenuStrip.ResumeLayout(false);
			this.namedAttachmentPointsContextMenuStrip.ResumeLayout(false);
			this.compositeFrameSetContextMenuStrip.ResumeLayout(false);
			this.soundContextMenuStrip.ResumeLayout(false);
			this.lowerTableLayoutPanel.ResumeLayout(false);
			this.lowerTableLayoutPanel.PerformLayout();
			this.namedAttachmentPointsPanel.ResumeLayout(false);
			this.guidesPanel.ResumeLayout(false);
			this.colorAndMotionTweensPanel.ResumeLayout(false);
			this.compositeFrameSetsPanel.ResumeLayout(false);
			this.compositeFramesPanel.ResumeLayout(false);
			this.colorsPanel.ResumeLayout(false);
			this.framesPanel.ResumeLayout(false);
			this.soundsPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileTypeLabel;
        private System.Windows.Forms.Label formatDescriptionLabel;
        private System.Windows.Forms.Label formatStatusLabel;
        private System.Windows.Forms.Label frameWidthLabel;
        private System.Windows.Forms.Label startFrameLabel;
        private System.Windows.Forms.Label columnsLabel;
        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.Label frameHeightLabel;
        private System.Windows.Forms.Label sourceImageLabel;
        private System.Windows.Forms.Label onLoadZoomLabel;
        private System.Windows.Forms.Label targetMSLabel;
        private System.Windows.Forms.Label endFrameLabel;
        private System.Windows.Forms.Label useNoImageSamplingLabel;
        private SpriteAnimator.MaskedTextBox fileTypeMaskedTextBox;
        private SpriteAnimator.MaskedTextBox formatDescriptionMaskedTextBox;
        private SpriteAnimator.MaskedTextBox frameWidthMaskedTextBox;
        private SpriteAnimator.MaskedTextBox formatStatusMaskedTextBox;
        private SpriteAnimator.MaskedTextBox startFrameMaskedTextBox;
        private SpriteAnimator.MaskedTextBox columnCountMaskedTextBox;
        private SpriteAnimator.MaskedTextBox rowCountMaskedTextBox;
        private SpriteAnimator.MaskedTextBox frameHeightMaskedTextBox;
        private SpriteAnimator.MaskedTextBox sourceImageMaskedTextBox;
        private SpriteAnimator.MaskedTextBox onLoadZoomMaskedTextBox;
        private SpriteAnimator.MaskedTextBox targetMillisecondsMaskedTextBox;
        private SpriteAnimator.MaskedTextBox endFrameMaskedTextBox;
        private System.Windows.Forms.CheckBox useNoSamplingCheckBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button browseForReferenceImageButton;
        private System.Windows.Forms.ToolTip validationErrorsToolTip;
        private System.Windows.Forms.ToolTip generalToolTip;
        private System.Windows.Forms.ContextMenuStrip addColorContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editColorToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip guideContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGuideToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip tweenContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addTweenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTweenToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip frameContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTweenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFrameToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel lowerTableLayoutPanel;
        private System.Windows.Forms.Button closeButton;
        private ButtonPanel availableColorsAndGuidesButtonPanel;
        private System.Windows.Forms.Panel guidesPanel;
        private System.Windows.Forms.ListView guidesListBox;
        private System.Windows.Forms.ColumnHeader guidesEmptyColumnHeader;
        private System.Windows.Forms.ColumnHeader guideTypeColumnHeader;
        private System.Windows.Forms.ColumnHeader guidePositionColumnHeader;
        private System.Windows.Forms.Panel colorAndMotionTweensPanel;
        private System.Windows.Forms.ListView tweensListBox;
        private System.Windows.Forms.ColumnHeader tweenEmptyColumnHeader;
        private System.Windows.Forms.ColumnHeader tweenIdColumnHeader;
        private System.Windows.Forms.ColumnHeader tweenFrameLengthColumnHeader;
        private System.Windows.Forms.ColumnHeader tweenColorComponentsColumnHeader;
        private System.Windows.Forms.ColumnHeader tweenMotionComponentsColumnHeader;
        private System.Windows.Forms.ColumnHeader tweenAdvancementFunctionColumnHeader;
        private ButtonPanel colorAndMotionTweensButtonPanel;
        private System.Windows.Forms.Panel compositeFrameSetsPanel;
        private System.Windows.Forms.ListView compositeFrameSetsListView;
        private System.Windows.Forms.Panel compositeFramesPanel;
        private System.Windows.Forms.ListView compositeFramesListView;
        private System.Windows.Forms.ColumnHeader compositeFramesIdColumnHeader;
        private System.Windows.Forms.ColumnHeader compositeFramesFrameCountColumnHeader;
        private ButtonPanel frameAndCompositeFramesButtonPanel;
        private System.Windows.Forms.Panel colorsPanel;
        private System.Windows.Forms.ListView colorsListBox;
        private System.Windows.Forms.ColumnHeader colorNameColumnHeader;
        private System.Windows.Forms.ColumnHeader colorNumberColumnHeader;
        private System.Windows.Forms.ColumnHeader colorSwatchColumnHeader;
        private System.Windows.Forms.ColumnHeader colorOpacityColumnHeader;
        private ButtonPanel compositeFrameSetsAndNamedAttachmentPointsButtonPanel;
        private System.Windows.Forms.Panel framesPanel;
        private System.Windows.Forms.ListView framesListView;
        private System.Windows.Forms.ColumnHeader framesIdColumnHeader;
        private System.Windows.Forms.ColumnHeader framesSColumnHeader;
        private System.Windows.Forms.ColumnHeader framesTColumnHeader;
        private System.Windows.Forms.ColumnHeader framesWColumnHeader;
        private System.Windows.Forms.ColumnHeader framesHColumnHeader;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ColumnHeader compositeFrameSetNameColumnHeader;
        private System.Windows.Forms.ColumnHeader compositeFrameSetFramesColumnHeader;
        private System.Windows.Forms.ContextMenuStrip compositeFrameSetContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addCompositeFrameSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCompositeFrameSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCompositeFrameSetToolStripMenuItem;
        private ButtonPanel soundsButtonPanel;
		private System.Windows.Forms.Panel soundsPanel;
        private System.Windows.Forms.ContextMenuStrip soundContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNewSoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSoundToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip compositeFramesContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem copyRangeOfCompositeFramesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem flipRangeOfCompositeFramesHorizontallyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem slideRangeOfCompositeFramesToolStripMenuItem;
		private System.Windows.Forms.ListView soundsListView;
		private System.Windows.Forms.ColumnHeader soundsNameColumnHeader;
		private System.Windows.Forms.ColumnHeader soundsFilenameColumnHeader;
		private System.Windows.Forms.ColumnHeader soundsDisplayColorColumnHeader;
		private System.Windows.Forms.Panel namedAttachmentPointsPanel;
		private System.Windows.Forms.ListView namedAttachmentPointsListView;
		private System.Windows.Forms.ColumnHeader namedAttachmentPointIdColumnHeader;
		private System.Windows.Forms.ColumnHeader namedAttachmentPointNameColumnHeader;
		private System.Windows.Forms.ColumnHeader namedAttachmentPointDescriptionColumnHeader;
		private System.Windows.Forms.ContextMenuStrip namedAttachmentPointsContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem addNamedAttachmentPointToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editNamedAttachmentPointToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeNamedAttachmentPointToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem sliceSourceImageIntoFramesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeSelectedCompositeFramesToolStripMenuItem;
    }
}