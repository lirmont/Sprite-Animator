using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SearchControls
{
	public partial class SearchPanel : UserControl
	{
		private SearchCategoryCollection optionalCategories;

		[
		Category("Searching"),
		Description("Specifies optional search parameters.")
		]
		public SearchCategoryCollection Categories
		{
			get {
				return optionalCategories;
			}
			set {
				if (value == null)
					value = new SearchCategoryCollection();
				optionalCategories = value;
				//
				if (this.IsHandleCreated)
					this.Invoke((MethodInvoker)redoOptionalCategoriesLayout);
				else
					redoOptionalCategoriesLayout();
			}
		}

		[Browsable(false)]
		public string SearchText
		{
			get {
				string text = searchMaskedTextBox.Text;
				if (string.IsNullOrEmpty(text))
					text = null;
				return text;
			}
			set {
				searchMaskedTextBox.Text = (string.IsNullOrEmpty(value)) ? null : value;
			}
		}

		[Browsable(false)]
		public Dictionary<string, int> SearchCriteria
		{
			get {
				Dictionary<string, int> criteria = new Dictionary<string, int>();
				foreach (Control control in categoryContainerTableLayoutPanel.Controls)
				{
					if (control is ComboBox)
					{
						ComboBox comboBox = (ComboBox)control;
						string key = (string)(comboBox.Tag);
						if (comboBox.SelectedIndex > 0)
						{
							SearchPair pair = (SearchPair)comboBox.SelectedItem;
							if (pair != null)
								criteria.Add(key, pair.Key);
						}
					}
				}
				return criteria;
			}
		}

		private Dictionary<string, ComboBox> SearchComboBoxesByName
		{
			get {
				Dictionary<string, ComboBox> lookupDictionary = new Dictionary<string, ComboBox>();
				foreach (Control control in categoryContainerTableLayoutPanel.Controls)
				{
					if (control is ComboBox)
					{
						ComboBox comboBox = (ComboBox)control;
						string key = (string)(comboBox.Tag);
						lookupDictionary.Add(key, comboBox);
					}
				}
				return lookupDictionary;
			}
		}

		private bool CategoriesMatchComboBoxes
		{
			get
			{
				bool categoriesMatchComboBoxes = (Categories.Count == SearchComboBoxesByName.Count) ? true : false;
				foreach (SearchCategory category in Categories)
				{
					if (!SearchComboBoxesByName.ContainsKey(category.Name))
						categoriesMatchComboBoxes = false;
				}
				return categoriesMatchComboBoxes;
			}
		}

		public event EventHandler SearchSubmitted;

		protected void OnSearchSubmitted(EventArgs e = null)
		{
			EventHandler handler = SearchSubmitted;
			if (handler != null)
				handler(this, e);
		}

		public SearchPanel()
		{
			InitializeComponent();
			Categories = new SearchCategoryCollection();
			Categories.PropertyChanged += new PropertyChangedEventHandler(Categories_PropertyChanged);
		}

		void Categories_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.Invoke((MethodInvoker)redoOptionalCategoriesLayout);
		}

		private void redoOptionalCategoriesLayout()
		{
			//
			lineSeparator.Visible = (Categories.Count > 0) ? true : false;
			//
			if (!CategoriesMatchComboBoxes)
			{
				categoryContainerTableLayoutPanel.Controls.Clear();
				foreach (SearchCategory category in Categories.Items())
					addSearchCategoryToForm(category);
			}
			else {
				// Synchronize combobox entries.
				foreach (SearchCategory category in Categories.Items())
					synchronizeCategoryItemsToFormComboBox(category);
			}
		}

		private void synchronizeCategoryItemsToFormComboBox(SearchCategory category, ComboBox comboBox = null)
		{
			ComboBox categoryComboBox = comboBox ?? SearchComboBoxesByName[category.Name];
			if (categoryComboBox != null)
			{
				categoryComboBox.Items.Add(new NameValuePair(null, string.Format("Any {0}", category.Name)));
				foreach (SearchPair pair in category.NameAndValuePairs.Items())
					categoryComboBox.Items.Add(pair);
				// Set value.
				categoryComboBox.SelectedIndex = 0;
			}
		}

		private void addSearchCategoryToForm(SearchCategory category)
		{
			categoryContainerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			int thisRow = categoryContainerTableLayoutPanel.RowCount = categoryContainerTableLayoutPanel.RowStyles.Count;
			//
			Label categoryLabel = new Label();
			categoryLabel.AutoSize = true;
			categoryLabel.Text = string.Format("{0}:", category.Name);
			//
			categoryContainerTableLayoutPanel.Controls.Add(categoryLabel);
			categoryContainerTableLayoutPanel.SetCellPosition(categoryLabel, new TableLayoutPanelCellPosition(0, thisRow - 1));
			categoryLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			categoryLabel.TextAlign = ContentAlignment.MiddleRight;
			//
			ComboBox categoryComboBox = new ComboBox();
			categoryComboBox.Tag = category.Name;
			categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			categoryComboBox.ValueMember = "Key";
			categoryComboBox.DisplayMember = "Name";
			categoryComboBox.DropDown +=new EventHandler(categoryComboBox_DropDown);
			//
			synchronizeCategoryItemsToFormComboBox(category, comboBox: categoryComboBox);
			//
			categoryContainerTableLayoutPanel.Controls.Add(categoryComboBox);
			categoryContainerTableLayoutPanel.SetCellPosition(categoryComboBox, new TableLayoutPanelCellPosition(1, thisRow - 1));
			categoryLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			//
			categoryComboBox.SelectedIndexChanged += new EventHandler(categoryComboBox_SelectedIndexChanged);
		}

		private void categoryComboBox_DropDown(object sender, System.EventArgs e)
		{
			ComboBox senderComboBox = (ComboBox)sender;
			int width = senderComboBox.DropDownWidth;
			Graphics g = senderComboBox.CreateGraphics();
			Font font = senderComboBox.Font;
			int vertScrollBarWidth = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;

			int newWidth;
			foreach (object item in senderComboBox.Items)
			{
				string s = "";
				if (item is NameValuePair)
				{
					NameValuePair valuePair = (NameValuePair)item;
					s = valuePair.Name;
				}
				else if (item is SearchPair) {
					SearchPair searchPair = (SearchPair)item;
					s = searchPair.Name;
				}
				newWidth = (int)g.MeasureString(s, font).Width + vertScrollBarWidth;
				if (width < newWidth)
					width = newWidth;
			}
			senderComboBox.DropDownWidth = Math.Max(senderComboBox.Width, width);
		}

		private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			searchLabel.Focus();
			// Redraw.
			ComboBox comboBox = (ComboBox)sender;
			comboBox.Invalidate();
		}

		private void updateButton_Click(object sender, EventArgs e)
		{
			OnSearchSubmitted();
		}
	}
}
