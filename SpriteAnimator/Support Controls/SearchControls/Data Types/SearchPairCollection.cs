using System.Collections.Generic;
using System.ComponentModel;

namespace SearchControls
{
	[System.Reflection.ObfuscationAttribute(Feature = "renaming")]
	[Description("Collection of search pairs (int, string).")]
	public class SearchPairCollection : System.Collections.ObjectModel.KeyedCollection<object, SearchPair>, INotifyPropertyChanged
	{
		public SearchPairCollection()
			: base()
		{
		}

		public SearchPairCollection(List<SearchPair> list)
		{
			if (list != null)
				foreach (SearchPair pair in list)
					this.Add(pair);
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

		protected override void InsertItem(int index, SearchPair item)
		{
			base.InsertItem(index, item);
			item.PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
			OnPropertyChanged("SearchPairCollection");
		}

		void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("SearchPair");
		}

		protected override void SetItem(int index, SearchPair item)
		{
			base.SetItem(index, item);
			item.PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
			OnPropertyChanged("SearchPairCollection");
		}

		protected override void RemoveItem(int index)
		{
			base.RemoveItem(index);
			OnPropertyChanged("SearchPairCollection");
		}

		// KeyedCollection overrides.
		protected override object GetKeyForItem(SearchPair item)
		{
			return item.Key;
		}

		public new IList<SearchPair> Items()
		{
			return base.Items;
		}
	}
}
