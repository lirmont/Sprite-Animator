using System.ComponentModel;

namespace SearchControls
{
	[System.Reflection.ObfuscationAttribute(Feature = "renaming")]
	[Description("A search category with its possible values.")]
	public class SearchCategory : INotifyPropertyChanged
	{
		private string name;
		private SearchPairCollection possibleValues;

		[
		Category("Search Category"),
		Description("Display name of the category.")
		]
		public string Name
		{
			get { return name; }
			set
			{
				bool changed = (name != value) ? true : false;
				name = value;
				if (changed)
					OnPropertyChanged("SearchCategory.Name");
			}
		}

		[
		Category("Search Category"),
		Description("Possible values."),
		TypeConverter(typeof(CollectionConverter))
		]
		public SearchPairCollection NameAndValuePairs
		{
			get
			{
				return possibleValues;
			}
			set
			{
				bool changed = (possibleValues != value) ? true : false;
				possibleValues = value;
				if (changed)
					OnPropertyChanged("SearchCategory.NameAndValuePairs");
			}
		}

		// Available for designer.
		public SearchCategory()
		{
			this.name = "";
			this.NameAndValuePairs = new SearchPairCollection();
		}

		public SearchCategory(string name, SearchPairCollection values)
		{
			this.Name = name;
			this.NameAndValuePairs = values ?? new SearchPairCollection();
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
	}
}
