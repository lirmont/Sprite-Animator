using System;
using System.Collections.Generic;
using System.Text;

namespace SpriteAnimator
{
	public abstract class IdentificationProperty
	{
		// String or integer representing the ID number found in an "id" attribute of an XML format document.
		public abstract object ID { get; set; }
		// Arbitrary value of the object for use in menu item displays (for example, yielding "5: Weapon" beneath a 1 - 10 grouping).
		public virtual object Tag { get { return ID; } private set { } }
	}
}
