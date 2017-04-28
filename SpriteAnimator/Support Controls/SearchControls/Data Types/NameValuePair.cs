using System;
using System.Collections.Generic;
using System.Text;

namespace SearchControls
{
	[System.Reflection.ObfuscationAttribute(Feature = "renaming")]
	public class NameValuePair
	{
		int? key;
		string name;

		public int? Key
		{
			get { return key; }
			set { key = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public NameValuePair(int? key, string name)
		{
			this.key = key;
			this.name = name;
		}
	}
}
