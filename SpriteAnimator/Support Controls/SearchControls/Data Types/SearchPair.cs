using System.ComponentModel;

namespace SearchControls
{
	[System.Reflection.ObfuscationAttribute(Feature = "renaming")]
	public class SearchPair : INotifyPropertyChanged
	{
		int key;
		string name;

		[
		Category("Search Option"),
		Description("Integer key of the option.")
		]
		public int Key
		{
			get { return key; }
			set
			{
				bool changed = (key != value) ? true : false;
				key = value;
				if (changed)
					OnPropertyChanged("SearchPair.Key");
			}
		}

		[
		Category("Search Option"),
		Description("Display name of the option.")
		]
		public string Name
		{
			get { return name; }
			set
			{
				bool changed = (name != value) ? true : false;
				name = value;
				if (changed)
					OnPropertyChanged("SearchPair.Name");
			}
		}

		public SearchPair()
		{
			this.key = default(int);
			this.name = null;
		}

		public SearchPair(int key, string name)
		{
			this.key = key;
			this.name = name;
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
