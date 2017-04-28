using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpriteAnimator
{
	public class FormRegex : Form
	{
		public string RegularExpression
		{
			get { return regexTextBox.Text; }
			set { regexTextBox.Text = value; }
		}

		public bool CaseSensitive {
			get { return checkIgnoreCase.Checked; }
			set { checkIgnoreCase.Checked = value; }
		}

		public string ReplacementText {
			get { return textReplace.Text; }
			set { textReplace.Text = value; }
		}

		public string SubjectText {
			get { return textSubject.Text; }
			set { textSubject.Text = value; }
		}

		public RegularExpressionReplacement ReplacementRegex {
			get {
				return new RegularExpressionReplacement(RegularExpression, ReplacementText, CaseSensitive);
			}
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		// Design time objects
		private System.Windows.Forms.TextBox regexTextBox;
		private System.Windows.Forms.Label regexLabel;
		private System.Windows.Forms.Label labelSubject;
		private System.Windows.Forms.Button testMatchButton;
		private System.Windows.Forms.TextBox textSubject;
		private System.Windows.Forms.TextBox resultsTextBox;
		private System.Windows.Forms.Label labelResults;
		private System.Windows.Forms.CheckBox checkIgnoreCase;
		private System.Windows.Forms.Button getMatchButton;
		private System.Windows.Forms.TextBox textReplace;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox replaceResultsTextBox;
		private TableLayoutPanel tableLayoutPanel1;
		private TableLayoutPanel tableLayoutPanel2;
		private TableLayoutPanel tableLayoutPanel3;
		private Button saveButton;
		private Button cancelButton;
		private System.Windows.Forms.Button testReplaceButton;

		// (\.[^.]+)$
		public FormRegex()
		{
			InitializeComponent();
		}

		public FormRegex(RegularExpressionReplacement replacement)
			: this()
		{
			this.CaseSensitive = replacement.CaseSensitive;
			this.ReplacementText = replacement.ReplacementText;
			this.RegularExpression = replacement.RegularExpression;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			this.regexTextBox = new System.Windows.Forms.TextBox();
			this.regexLabel = new System.Windows.Forms.Label();
			this.labelSubject = new System.Windows.Forms.Label();
			this.testMatchButton = new System.Windows.Forms.Button();
			this.textSubject = new System.Windows.Forms.TextBox();
			this.resultsTextBox = new System.Windows.Forms.TextBox();
			this.labelResults = new System.Windows.Forms.Label();
			this.checkIgnoreCase = new System.Windows.Forms.CheckBox();
			this.getMatchButton = new System.Windows.Forms.Button();
			this.textReplace = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.replaceResultsTextBox = new System.Windows.Forms.TextBox();
			this.testReplaceButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// regexTextBox
			// 
			this.regexTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.regexTextBox, 2);
			this.regexTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.regexTextBox.Location = new System.Drawing.Point(3, 16);
			this.regexTextBox.Multiline = true;
			this.regexTextBox.Name = "regexTextBox";
			this.regexTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.regexTextBox.Size = new System.Drawing.Size(554, 49);
			this.regexTextBox.TabIndex = 2;
			this.regexTextBox.Text = "(\\.[^.]+)$";
			// 
			// regexLabel
			// 
			this.regexLabel.AutoSize = true;
			this.regexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.regexLabel.Location = new System.Drawing.Point(3, 0);
			this.regexLabel.Name = "regexLabel";
			this.regexLabel.Size = new System.Drawing.Size(101, 13);
			this.regexLabel.TabIndex = 1;
			this.regexLabel.Text = "Regular Expression:";
			// 
			// labelSubject
			// 
			this.labelSubject.AutoSize = true;
			this.labelSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSubject.Location = new System.Drawing.Point(3, 103);
			this.labelSubject.Name = "labelSubject";
			this.labelSubject.Size = new System.Drawing.Size(70, 13);
			this.labelSubject.TabIndex = 7;
			this.labelSubject.Text = "Test Subject:";
			// 
			// testMatchButton
			// 
			this.testMatchButton.AutoSize = true;
			this.testMatchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.testMatchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.testMatchButton.Location = new System.Drawing.Point(111, 3);
			this.testMatchButton.Name = "testMatchButton";
			this.testMatchButton.Size = new System.Drawing.Size(71, 23);
			this.testMatchButton.TabIndex = 11;
			this.testMatchButton.Text = "Test Match";
			this.testMatchButton.Click += new System.EventHandler(this.btnMatch_Click);
			// 
			// textSubject
			// 
			this.textSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textSubject.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textSubject.Location = new System.Drawing.Point(3, 119);
			this.textSubject.Multiline = true;
			this.textSubject.Name = "textSubject";
			this.textSubject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textSubject.Size = new System.Drawing.Size(274, 122);
			this.textSubject.TabIndex = 8;
			this.textSubject.Text = "Some.Action.With.Direction";
			// 
			// resultsTextBox
			// 
			this.resultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.resultsTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resultsTextBox.Location = new System.Drawing.Point(3, 260);
			this.resultsTextBox.Multiline = true;
			this.resultsTextBox.Name = "resultsTextBox";
			this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.resultsTextBox.Size = new System.Drawing.Size(274, 122);
			this.resultsTextBox.TabIndex = 16;
			// 
			// labelResults
			// 
			this.labelResults.AutoSize = true;
			this.labelResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelResults.Location = new System.Drawing.Point(3, 244);
			this.labelResults.Name = "labelResults";
			this.labelResults.Size = new System.Drawing.Size(51, 13);
			this.labelResults.TabIndex = 15;
			this.labelResults.Text = "Matches:";
			// 
			// checkIgnoreCase
			// 
			this.checkIgnoreCase.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.checkIgnoreCase.AutoSize = true;
			this.checkIgnoreCase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkIgnoreCase.Location = new System.Drawing.Point(3, 6);
			this.checkIgnoreCase.Name = "checkIgnoreCase";
			this.checkIgnoreCase.Size = new System.Drawing.Size(102, 17);
			this.checkIgnoreCase.TabIndex = 5;
			this.checkIgnoreCase.Text = "Case insensitive";
			// 
			// getMatchButton
			// 
			this.getMatchButton.AutoSize = true;
			this.getMatchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.getMatchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.getMatchButton.Location = new System.Drawing.Point(188, 3);
			this.getMatchButton.Name = "getMatchButton";
			this.getMatchButton.Size = new System.Drawing.Size(67, 23);
			this.getMatchButton.TabIndex = 12;
			this.getMatchButton.Text = "Get Match";
			this.getMatchButton.Click += new System.EventHandler(this.btnGetMatch_Click);
			// 
			// textReplace
			// 
			this.textReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textReplace.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textReplace.Location = new System.Drawing.Point(283, 119);
			this.textReplace.Multiline = true;
			this.textReplace.Name = "textReplace";
			this.textReplace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textReplace.Size = new System.Drawing.Size(274, 122);
			this.textReplace.TabIndex = 10;
			this.textReplace.Text = ".Direction";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(283, 103);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Replacement Text:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(283, 244);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "Replacement Result:";
			// 
			// replaceResultsTextBox
			// 
			this.replaceResultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.replaceResultsTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.replaceResultsTextBox.Location = new System.Drawing.Point(284, 260);
			this.replaceResultsTextBox.Multiline = true;
			this.replaceResultsTextBox.Name = "replaceResultsTextBox";
			this.replaceResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.replaceResultsTextBox.Size = new System.Drawing.Size(273, 122);
			this.replaceResultsTextBox.TabIndex = 18;
			// 
			// testReplaceButton
			// 
			this.testReplaceButton.AutoSize = true;
			this.testReplaceButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.testReplaceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.testReplaceButton.Location = new System.Drawing.Point(261, 3);
			this.testReplaceButton.Name = "testReplaceButton";
			this.testReplaceButton.Size = new System.Drawing.Size(81, 23);
			this.testReplaceButton.TabIndex = 19;
			this.testReplaceButton.Text = "Test Replace";
			this.testReplaceButton.Click += new System.EventHandler(this.btnReplace_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.regexLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.replaceResultsTextBox, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.regexTextBox, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.resultsTextBox, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelSubject, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelResults, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.textReplace, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.textSubject, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 7);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 8;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 420);
			this.tableLayoutPanel1.TabIndex = 20;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Controls.Add(this.testReplaceButton, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.checkIgnoreCase, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.getMatchButton, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.testMatchButton, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 71);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(345, 29);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.saveButton, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.cancelButton, 1, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(199, 388);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.Size = new System.Drawing.Size(162, 29);
			this.tableLayoutPanel3.TabIndex = 19;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.saveButton.AutoSize = true;
			this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.saveButton.Location = new System.Drawing.Point(3, 3);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 0;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cancelButton.AutoSize = true;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelButton.Location = new System.Drawing.Point(84, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// FormRegex
			// 
			this.AcceptButton = this.saveButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(562, 423);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinimumSize = new System.Drawing.Size(500, 450);
			this.Name = "FormRegex";
			this.ShowIcon = false;
			this.Text = "Regular Expression for Replacement";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		private RegexOptions getRegexOptions()
		{
			RegexOptions options = new RegexOptions();
			if (checkIgnoreCase.Checked) options |= RegexOptions.IgnoreCase;
			return options;
		}

		private void btnMatch_Click(object sender, System.EventArgs e)
		{
			replaceResultsTextBox.Text = "N/A";
			try
			{
				if (Regex.IsMatch(textSubject.Text, regexTextBox.Text, getRegexOptions()))
					resultsTextBox.Text = "The regex matches part or all of the subject";
				else
					resultsTextBox.Text = "The regex cannot be matched in the subject";
			}
			catch (Exception ex)
			{
				// Most likely cause is a syntax error in the regular expression
				resultsTextBox.Text = "Regex.IsMatch() threw an exception:\r\n" + ex.Message;
			}
		}

		private void btnGetMatch_Click(object sender, System.EventArgs e)
		{
			replaceResultsTextBox.Text = "N/A";
			try
			{
				resultsTextBox.Text = Regex.Match(textSubject.Text, regexTextBox.Text, getRegexOptions()).Value;
			}
			catch (Exception ex)
			{
				resultsTextBox.Text = "Regex.Match() threw an exception:\r\n" + ex.Message;
			}
		}

		private void btnReplace_Click(object sender, System.EventArgs e)
		{
			try
			{
				replaceResultsTextBox.Text = Regex.Replace(textSubject.Text, regexTextBox.Text, textReplace.Text, getRegexOptions());
				resultsTextBox.Text = "N/A";
			}
			catch (Exception ex)
			{
				resultsTextBox.Text = "Regex.Replace() threw an exception:\r\n" + ex.Message;
				replaceResultsTextBox.Text = "N/A";
			}
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}
	}
}
