using System.Collections.Generic;
using System.ComponentModel;

namespace SearchControls
{
	[System.Reflection.ObfuscationAttribute(Feature = "renaming")]
	[Description("Collection of search categories (string, SearchCategory).")]
	public class SearchCategoryCollection : System.Collections.ObjectModel.KeyedCollection<string, SearchCategory>, INotifyPropertyChanged
	{
		public SearchCategoryCollection()
			: base()
		{
		}

		public SearchCategoryCollection(List<SearchCategory> list)
			: base()
		{
			if (list != null)
				foreach (SearchCategory category in list)
					this.Add(category);
		}

		// INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, e);
		}

		protected void OnPropertyChanged(string propertyName)
		{
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}

		protected override void InsertItem(int index, SearchCategory item)
		{
			base.InsertItem(index, item);
			item.PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
			OnPropertyChanged("SearchCategoryCollection");
		}

		void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("SearchCategory");
		}

		protected override void SetItem(int index, SearchCategory item)
		{
			base.SetItem(index, item);
			item.PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
			OnPropertyChanged("SearchCategoryCollection");
		}

		protected override void RemoveItem(int index)
		{
			base.RemoveItem(index);
			OnPropertyChanged("SearchCategoryCollection");
		}

		// KeyedCollection overrides.
		protected override string GetKeyForItem(SearchCategory item)
		{
			return item.Name;
		}

		public new IList<SearchCategory> Items()
		{
			return base.Items;
		}
	}
}
