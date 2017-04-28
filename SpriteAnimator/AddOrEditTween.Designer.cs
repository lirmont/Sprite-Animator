#pragma warning disable
namespace SpriteAnimator
{
    partial class AddOrEditTween
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrEditTween));
			this.advancementFunctionComboBox = new System.Windows.Forms.ComboBox();
			this.advancementFunctionLabel = new System.Windows.Forms.Label();
			this.lengthInFramesNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.lengthInFramesLabel = new System.Windows.Forms.Label();
			this.idLabel = new System.Windows.Forms.Label();
			this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.colorsListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.sharedContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addColorNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveEntryUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveEntryDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.clearEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.coordinatesListView = new System.Windows.Forms.ListView();
			this.xColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.yColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.zColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.idMaskedTextBox = new SpriteAnimator.MaskedTextBox();
			this.saveOrCancelTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.drawingContextTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.simpleOpenGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.widthValueLabel = new System.Windows.Forms.Label();
			this.xLabel = new System.Windows.Forms.Label();
			this.heightValueLabel = new System.Windows.Forms.Label();
			this.magnifyButton = new System.Windows.Forms.Button();
			this.minifyButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.lengthInFramesNumericUpDown)).BeginInit();
			this.mainTableLayoutPanel.SuspendLayout();
			this.sharedContextMenuStrip.SuspendLayout();
			this.saveOrCancelTableLayoutPanel.SuspendLayout();
			this.drawingContextTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// advancementFunctionComboBox
			// 
			this.advancementFunctionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.advancementFunctionComboBox.DisplayMember = "0";
			this.advancementFunctionComboBox.FormattingEnabled = true;
			this.advancementFunctionComboBox.Items.AddRange(new object[] {
            "linear"});
			this.advancementFunctionComboBox.Location = new System.Drawing.Point(160, 29);
			this.advancementFunctionComboBox.Name = "advancementFunctionComboBox";
			this.advancementFunctionComboBox.Size = new System.Drawing.Size(151, 21);
			this.advancementFunctionComboBox.TabIndex = 6;
			this.advancementFunctionComboBox.Text = "linear";
			// 
			// advancementFunctionLabel
			// 
			this.advancementFunctionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.advancementFunctionLabel.Location = new System.Drawing.Point(3, 32);
			this.advancementFunctionLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
			this.advancementFunctionLabel.Name = "advancementFunctionLabel";
			this.advancementFunctionLabel.Size = new System.Drawing.Size(151, 13);
			this.advancementFunctionLabel.TabIndex = 5;
			this.advancementFunctionLabel.Text = "Advancement Function:";
			this.advancementFunctionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lengthInFramesNumericUpDown
			// 
			this.lengthInFramesNumericUpDown.Location = new System.Drawing.Point(160, 56);
			this.lengthInFramesNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.lengthInFramesNumericUpDown.Name = "lengthInFramesNumericUpDown";
			this.lengthInFramesNumericUpDown.Size = new System.Drawing.Size(55, 20);
			this.lengthInFramesNumericUpDown.TabIndex = 7;
			this.lengthInFramesNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lengthInFramesLabel
			// 
			this.lengthInFramesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lengthInFramesLabel.AutoSize = true;
			this.lengthInFramesLabel.Location = new System.Drawing.Point(63, 59);
			this.lengthInFramesLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
			this.lengthInFramesLabel.Name = "lengthInFramesLabel";
			this.lengthInFramesLabel.Size = new System.Drawing.Size(91, 13);
			this.lengthInFramesLabel.TabIndex = 8;
			this.lengthInFramesLabel.Text = "Length in Frames:";
			this.lengthInFramesLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// idLabel
			// 
			this.idLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.idLabel.AutoSize = true;
			this.idLabel.Location = new System.Drawing.Point(133, 5);
			this.idLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
			this.idLabel.Name = "idLabel";
			this.idLabel.Size = new System.Drawing.Size(21, 13);
			this.idLabel.TabIndex = 9;
			this.idLabel.Text = "ID:";
			// 
			// mainTableLayoutPanel
			// 
			this.mainTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mainTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
			this.mainTableLayoutPanel.ColumnCount = 3;
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTableLayoutPanel.Controls.Add(this.colorsListView, 0, 3);
			this.mainTableLayoutPanel.Controls.Add(this.coordinatesListView, 0, 4);
			this.mainTableLayoutPanel.Controls.Add(this.idLabel, 0, 0);
			this.mainTableLayoutPanel.Controls.Add(this.lengthInFramesNumericUpDown, 1, 2);
			this.mainTableLayoutPanel.Controls.Add(this.lengthInFramesLabel, 0, 2);
			this.mainTableLayoutPanel.Controls.Add(this.advancementFunctionComboBox, 1, 1);
			this.mainTableLayoutPanel.Controls.Add(this.advancementFunctionLabel, 0, 1);
			this.mainTableLayoutPanel.Controls.Add(this.idMaskedTextBox, 1, 0);
			this.mainTableLayoutPanel.Controls.Add(this.saveOrCancelTableLayoutPanel, 0, 5);
			this.mainTableLayoutPanel.Controls.Add(this.drawingContextTableLayoutPanel, 2, 0);
			this.mainTableLayoutPanel.Location = new System.Drawing.Point(5, 8);
			this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
			this.mainTableLayoutPanel.RowCount = 6;
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainTableLayoutPanel.Size = new System.Drawing.Size(585, 281);
			this.mainTableLayoutPanel.TabIndex = 10;
			// 
			// colorsListView
			// 
			this.colorsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.colorsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.mainTableLayoutPanel.SetColumnSpan(this.colorsListView, 2);
			this.colorsListView.ContextMenuStrip = this.sharedContextMenuStrip;
			this.colorsListView.Cursor = System.Windows.Forms.Cursors.Default;
			this.colorsListView.FullRowSelect = true;
			this.colorsListView.GridLines = true;
			this.colorsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.colorsListView.HideSelection = false;
			this.colorsListView.LabelEdit = true;
			this.colorsListView.Location = new System.Drawing.Point(3, 82);
			this.colorsListView.MultiSelect = false;
			this.colorsListView.Name = "colorsListView";
			this.colorsListView.Size = new System.Drawing.Size(308, 77);
			this.colorsListView.TabIndex = 11;
			this.colorsListView.UseCompatibleStateImageBehavior = false;
			this.colorsListView.View = System.Windows.Forms.View.Details;
			this.colorsListView.SizeChanged += new System.EventHandler(this.ListView_SizeChanged);
			this.colorsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
			this.colorsListView.MouseEnter += new System.EventHandler(this.colorsListView_MouseEnter);
			this.colorsListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorsListView_MouseUp);
			this.colorsListView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.listView_PreviewKeyDown);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Color Name";
			this.columnHeader1.Width = 303;
			// 
			// sharedContextMenuStrip
			// 
			this.sharedContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addColorNameToolStripMenuItem,
            this.removeEntryToolStripMenuItem,
            this.moveEntryUpToolStripMenuItem,
            this.moveEntryDownToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearEntriesToolStripMenuItem});
			this.sharedContextMenuStrip.Name = "contextMenuStrip1";
			this.sharedContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.sharedContextMenuStrip.Size = new System.Drawing.Size(160, 120);
			this.sharedContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.sharedContextMenuStrip_Opening);
			// 
			// addColorNameToolStripMenuItem
			// 
			this.addColorNameToolStripMenuItem.Name = "addColorNameToolStripMenuItem";
			this.addColorNameToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.addColorNameToolStripMenuItem.Text = "Add Entry";
			this.addColorNameToolStripMenuItem.Click += new System.EventHandler(this.addEntryToolStripMenuItem_Click);
			// 
			// removeEntryToolStripMenuItem
			// 
			this.removeEntryToolStripMenuItem.Name = "removeEntryToolStripMenuItem";
			this.removeEntryToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.removeEntryToolStripMenuItem.Text = "Remove Entry";
			this.removeEntryToolStripMenuItem.Click += new System.EventHandler(this.removeEntryToolStripMenuItem_Click);
			// 
			// moveEntryUpToolStripMenuItem
			// 
			this.moveEntryUpToolStripMenuItem.Name = "moveEntryUpToolStripMenuItem";
			this.moveEntryUpToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.moveEntryUpToolStripMenuItem.Text = "Move Entry Up";
			this.moveEntryUpToolStripMenuItem.Click += new System.EventHandler(this.moveEntryUpToolStripMenuItem_Click);
			// 
			// moveEntryDownToolStripMenuItem
			// 
			this.moveEntryDownToolStripMenuItem.Name = "moveEntryDownToolStripMenuItem";
			this.moveEntryDownToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.moveEntryDownToolStripMenuItem.Text = "Move Entry Down";
			this.moveEntryDownToolStripMenuItem.Click += new System.EventHandler(this.moveEntryDownToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
			// 
			// clearEntriesToolStripMenuItem
			// 
			this.clearEntriesToolStripMenuItem.Name = "clearEntriesToolStripMenuItem";
			this.clearEntriesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.clearEntriesToolStripMenuItem.Text = "Clear Entries";
			this.clearEntriesToolStripMenuItem.Click += new System.EventHandler(this.clearEntriesToolStripMenuItem_Click);
			// 
			// coordinatesListView
			// 
			this.coordinatesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.coordinatesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.xColumnHeader,
            this.yColumnHeader,
            this.zColumnHeader});
			this.mainTableLayoutPanel.SetColumnSpan(this.coordinatesListView, 2);
			this.coordinatesListView.ContextMenuStrip = this.sharedContextMenuStrip;
			this.coordinatesListView.FullRowSelect = true;
			this.coordinatesListView.GridLines = true;
			this.coordinatesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.coordinatesListView.LabelEdit = true;
			this.coordinatesListView.Location = new System.Drawing.Point(3, 165);
			this.coordinatesListView.MultiSelect = false;
			this.coordinatesListView.Name = "coordinatesListView";
			this.coordinatesListView.Size = new System.Drawing.Size(308, 77);
			this.coordinatesListView.TabIndex = 15;
			this.coordinatesListView.UseCompatibleStateImageBehavior = false;
			this.coordinatesListView.View = System.Windows.Forms.View.Details;
			this.coordinatesListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.coordinatesListView_AfterLabelEdit);
			this.coordinatesListView.SizeChanged += new System.EventHandler(this.ListView_SizeChanged);
			this.coordinatesListView.Click += new System.EventHandler(this.coordinatesListView_Click);
			this.coordinatesListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
			this.coordinatesListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.coordinatesListView_MouseClick);
			this.coordinatesListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.genericListView_MouseDown);
			this.coordinatesListView.MouseEnter += new System.EventHandler(this.coordinatesListView_MouseEnter);
			this.coordinatesListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.genericListView_MouseUp);
			this.coordinatesListView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.listView_PreviewKeyDown);
			// 
			// xColumnHeader
			// 
			this.xColumnHeader.Text = "X";
			this.xColumnHeader.Width = 80;
			// 
			// yColumnHeader
			// 
			this.yColumnHeader.Text = "Y";
			this.yColumnHeader.Width = 80;
			// 
			// zColumnHeader
			// 
			this.zColumnHeader.Text = "Z";
			this.zColumnHeader.Width = 80;
			// 
			// idMaskedTextBox
			// 
			this.idMaskedTextBox.EmptyText = "Reference name.";
			this.idMaskedTextBox.Location = new System.Drawing.Point(160, 3);
			this.idMaskedTextBox.MarkInvalid = false;
			this.idMaskedTextBox.Name = "idMaskedTextBox";
			this.idMaskedTextBox.Size = new System.Drawing.Size(151, 20);
			this.idMaskedTextBox.TabIndex = 10;
			// 
			// saveOrCancelTableLayoutPanel
			// 
			this.saveOrCancelTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
			this.saveOrCancelTableLayoutPanel.ColumnCount = 2;
			this.mainTableLayoutPanel.SetColumnSpan(this.saveOrCancelTableLayoutPanel, 2);
			this.saveOrCancelTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.saveOrCancelTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.saveOrCancelTableLayoutPanel.Controls.Add(this.saveButton, 0, 0);
			this.saveOrCancelTableLayoutPanel.Controls.Add(this.cancelButton, 1, 0);
			this.saveOrCancelTableLayoutPanel.Location = new System.Drawing.Point(3, 248);
			this.saveOrCancelTableLayoutPanel.Name = "saveOrCancelTableLayoutPanel";
			this.saveOrCancelTableLayoutPanel.RowCount = 1;
			this.saveOrCancelTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.saveOrCancelTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.saveOrCancelTableLayoutPanel.Size = new System.Drawing.Size(308, 29);
			this.saveOrCancelTableLayoutPanel.TabIndex = 13;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(76, 3);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 0;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(157, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.button2_Click);
			// 
			// drawingContextTableLayoutPanel
			// 
			this.drawingContextTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.drawingContextTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
			this.drawingContextTableLayoutPanel.ColumnCount = 2;
			this.drawingContextTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.drawingContextTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.drawingContextTableLayoutPanel.Controls.Add(this.simpleOpenGlControl, 0, 0);
			this.drawingContextTableLayoutPanel.Controls.Add(this.widthValueLabel, 0, 5);
			this.drawingContextTableLayoutPanel.Controls.Add(this.xLabel, 1, 5);
			this.drawingContextTableLayoutPanel.Controls.Add(this.heightValueLabel, 1, 4);
			this.drawingContextTableLayoutPanel.Controls.Add(this.magnifyButton, 1, 0);
			this.drawingContextTableLayoutPanel.Controls.Add(this.minifyButton, 1, 1);
			this.drawingContextTableLayoutPanel.Location = new System.Drawing.Point(317, 3);
			this.drawingContextTableLayoutPanel.Name = "drawingContextTableLayoutPanel";
			this.drawingContextTableLayoutPanel.RowCount = 6;
			this.mainTableLayoutPanel.SetRowSpan(this.drawingContextTableLayoutPanel, 6);
			this.drawingContextTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.drawingContextTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.drawingContextTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.drawingContextTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.drawingContextTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.drawingContextTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.drawingContextTableLayoutPanel.Size = new System.Drawing.Size(265, 275);
			this.drawingContextTableLayoutPanel.TabIndex = 14;
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
			this.drawingContextTableLayoutPanel.SetRowSpan(this.simpleOpenGlControl, 5);
			this.simpleOpenGlControl.Size = new System.Drawing.Size(234, 255);
			this.simpleOpenGlControl.StencilBits = ((byte)(0));
			this.simpleOpenGlControl.TabIndex = 3;
			this.simpleOpenGlControl.VSync = false;
			this.simpleOpenGlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
			this.simpleOpenGlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddOrEditTween_KeyDown);
			this.simpleOpenGlControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddOrEditTween_KeyPress);
			this.simpleOpenGlControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseDoubleClick);
			this.simpleOpenGlControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseDown);
			this.simpleOpenGlControl.MouseEnter += new System.EventHandler(this.simpleOpenGlControl1_MouseEnter);
			this.simpleOpenGlControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseMove);
			this.simpleOpenGlControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseUp);
			this.simpleOpenGlControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseWheel);
			this.simpleOpenGlControl.Resize += new System.EventHandler(this.simpleOpenGlControl1_Resize);
			// 
			// widthValueLabel
			// 
			this.widthValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.widthValueLabel.AutoSize = true;
			this.widthValueLabel.Location = new System.Drawing.Point(204, 258);
			this.widthValueLabel.Margin = new System.Windows.Forms.Padding(3, 3, 5, 0);
			this.widthValueLabel.Name = "widthValueLabel";
			this.widthValueLabel.Size = new System.Drawing.Size(25, 13);
			this.widthValueLabel.TabIndex = 0;
			this.widthValueLabel.Text = "000";
			// 
			// xLabel
			// 
			this.xLabel.AutoSize = true;
			this.xLabel.Location = new System.Drawing.Point(237, 258);
			this.xLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.xLabel.Name = "xLabel";
			this.xLabel.Size = new System.Drawing.Size(12, 13);
			this.xLabel.TabIndex = 2;
			this.xLabel.Text = "x";
			// 
			// heightValueLabel
			// 
			this.heightValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.heightValueLabel.AutoSize = true;
			this.heightValueLabel.Location = new System.Drawing.Point(237, 239);
			this.heightValueLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.heightValueLabel.Name = "heightValueLabel";
			this.heightValueLabel.Size = new System.Drawing.Size(25, 13);
			this.heightValueLabel.TabIndex = 1;
			this.heightValueLabel.Text = "000";
			// 
			// magnifyButton
			// 
			this.magnifyButton.Location = new System.Drawing.Point(237, 3);
			this.magnifyButton.Name = "magnifyButton";
			this.magnifyButton.Size = new System.Drawing.Size(23, 23);
			this.magnifyButton.TabIndex = 4;
			this.magnifyButton.Text = "+";
			this.magnifyButton.UseVisualStyleBackColor = true;
			this.magnifyButton.Click += new System.EventHandler(this.magnifyButton_Click);
			// 
			// minifyButton
			// 
			this.minifyButton.Location = new System.Drawing.Point(237, 35);
			this.minifyButton.Name = "minifyButton";
			this.minifyButton.Size = new System.Drawing.Size(23, 23);
			this.minifyButton.TabIndex = 5;
			this.minifyButton.Text = "-";
			this.minifyButton.UseVisualStyleBackColor = true;
			this.minifyButton.Click += new System.EventHandler(this.minifyButton_Click);
			// 
			// AddOrEditTween
			// 
			this.AcceptButton = this.saveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(593, 294);
			this.Controls.Add(this.mainTableLayoutPanel);
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(539, 260);
			this.Name = "AddOrEditTween";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Add or Edit Tween";
			this.Shown += new System.EventHandler(this.AddOrEditTween_Shown);
			((System.ComponentModel.ISupportInitialize)(this.lengthInFramesNumericUpDown)).EndInit();
			this.mainTableLayoutPanel.ResumeLayout(false);
			this.mainTableLayoutPanel.PerformLayout();
			this.sharedContextMenuStrip.ResumeLayout(false);
			this.saveOrCancelTableLayoutPanel.ResumeLayout(false);
			this.drawingContextTableLayoutPanel.ResumeLayout(false);
			this.drawingContextTableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox advancementFunctionComboBox;
        private System.Windows.Forms.Label advancementFunctionLabel;
        private System.Windows.Forms.NumericUpDown lengthInFramesNumericUpDown;
        private System.Windows.Forms.Label lengthInFramesLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private MaskedTextBox idMaskedTextBox;
        private System.Windows.Forms.ListView colorsListView;
        private System.Windows.Forms.TableLayoutPanel saveOrCancelTableLayoutPanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TableLayoutPanel drawingContextTableLayoutPanel;
        private System.Windows.Forms.Label widthValueLabel;
        private System.Windows.Forms.Label heightValueLabel;
        private System.Windows.Forms.Label xLabel;
        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl;
        private System.Windows.Forms.ContextMenuStrip sharedContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addColorNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveEntryUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveEntryDownToolStripMenuItem;
        private System.Windows.Forms.Button magnifyButton;
		private System.Windows.Forms.Button minifyButton;
        private System.Windows.Forms.ListView coordinatesListView;
        private System.Windows.Forms.ColumnHeader xColumnHeader;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clearEntriesToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader yColumnHeader;
		private System.Windows.Forms.ColumnHeader zColumnHeader;
    }
}