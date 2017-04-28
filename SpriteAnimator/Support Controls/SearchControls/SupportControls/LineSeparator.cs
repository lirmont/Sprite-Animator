using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SearchControls
{
	[System.Reflection.ObfuscationAttribute(Feature = "renaming")]
	public partial class LineSeparator : Label
	{
		public override bool AutoSize
		{
			get
			{
				return false;
			}
		}

		public override Size MaximumSize
		{
			get
			{
				return new Size(int.MaxValue, 2);
			}
		}

		public override Size MinimumSize
		{
			get
			{
				return new Size(1, 2);
			}
		}

		public override string Text
		{
			get
			{
				return "";
			}
		}

		public LineSeparator()
		{
			InitializeComponent();
			this.AutoSize = false;
			this.Height = 2;
			this.BorderStyle = BorderStyle.Fixed3D;
		}
	}
}
