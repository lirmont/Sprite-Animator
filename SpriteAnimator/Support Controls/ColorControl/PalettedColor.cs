using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#pragma warning disable
namespace ColorControl
{
	public class PalettedColor
	{
		public static Size DefaultSize = new Size(20, 20);

		//
		Color color = Color.White;

		public Color Color
		{
			get { return color; }
			set {
				color = value;
				using (Graphics g = Graphics.FromImage(colorSwatch))
					g.Clear(color);
			}
		}

		Size size = DefaultSize;

		public Size Size
		{
			get { return size; }
			set { size = value; }
		}

		//
		Bitmap colorSwatch = new Bitmap(18, 10);

		public Bitmap ColorSwatch
		{
			get { return colorSwatch; }
			set { colorSwatch = value; }
		}

		bool selected = false, hoverSelected = false;

		public bool IsSelected
		{
			get { return selected; }
			set { selected = value; }
		}

		public bool IsHoverSelected
		{
			get { return hoverSelected; }
			set { hoverSelected = value; }
		}

		public bool HasAChildThatIsSelected
		{
			get {
				if (this.children.Count > 0)
				{
					foreach(PalettedColor child in this.children.Values)
					{
						if (child.IsSelected || child.HasAChildThatIsSelected)
							return true;
					}
				}
				return false;
			}
		}

		public bool HasAChildThatIsHoverSelected
		{
			get
			{
				if (this.children.Count > 0)
				{
					foreach (PalettedColor child in this.children.Values)
					{
						if (child.IsHoverSelected || child.HasAChildThatIsHoverSelected)
							return true;
					}
				}
				return false;
			}
		}

		//
		PalettedColor parent = null;
		Dictionary<double, PalettedColor> children = new Dictionary<double, PalettedColor>();

		internal PalettedColor Parent
		{
			get { return parent; }
			set { parent = value; }
		}

		internal Dictionary<double, PalettedColor> Children
		{
			get { return children; }
			set { children = value; }
		}

		internal double? Degree {
			get {
				if (parent != null)
				{
					foreach (double key in parent.Children.Keys)
					{
						PalettedColor value = parent.Children[key];
						if (value == this)
							return key;
					}
				}
				return null;
			}
		}

		internal double? ReverseDegree
		{
			get
			{
				double? degree = Degree;
				if (degree != null)
				{
					degree += 180;
					if (degree >= 360 || degree <= -360)
					{
						degree = 0 + (degree % 360);
					}
				}
				return degree;
			}
		}
		
		//
		public float ColorDifference {
			get {
				return (parent != null) ? SupportFunctions.ColorDifference(new RGB(color), new RGB(parent.color)) : 0.00f;
			}
		}

		public PalettedColor(Color color, PalettedColor parent = null, Dictionary<double, PalettedColor> children = null, Size? size = null)
		{
			this.Color = color;
			if (size != null)
				this.size = size.Value;
			//
			this.parent = parent;
			if (children != null)
				this.children = children;
		}

		public PalettedColor addColorAsChild(Color color, LayoutEngine engine)
		{
			CIELab lab = new RGB(color);
			double degree = engine.GetNextAvailableDegree(this);
			this.children.Add(degree, new PalettedColor(color, parent: this));
			return this.children[degree];
		}

		public void addColorAsChild(PalettedColor thisColor, LayoutEngine engine)
		{
			thisColor.parent = this;
			this.children.Add(engine.GetNextAvailableDegree(this), thisColor);
		}

		public delegate void Handler();

		public ToolStripMenuItem generateToolStripMenuItem(Color pickedColor, LayoutEngine engine, Handler action = null)
		{
			ToolStripMenuItem item = new ToolStripMenuItem(ColorTranslator.ToHtml(color), colorSwatch);
			item.ImageScaling = ToolStripItemImageScaling.None;
			if (this.children.Count == 0)
			{
				item.Click += new EventHandler(delegate(object s, EventArgs es)
				{
					this.addColorAsChild(pickedColor, engine);
					if (action != null)
						action();
				});
			}
			else
			{
				ToolStripMenuItem addToThisTtem = new ToolStripMenuItem("Add to this color.");
				addToThisTtem.ImageScaling = ToolStripItemImageScaling.None;
				addToThisTtem.Click += new EventHandler(delegate(object s, EventArgs es)
				{
					this.addColorAsChild(pickedColor, engine);
					if (action != null)
						action();
				});
				item.DropDownItems.Add(addToThisTtem);
				//
				foreach (double angle in this.children.Keys)
					item.DropDownItems.Add(this.children[angle].generateToolStripMenuItem(pickedColor, engine, action: action));
			}
			return item;
		}

		public void removeSelectedColors()
		{
			if ((IsSelected || IsHoverSelected) && parent != null)
			{
				foreach (double angle in new List<double>(parent.Children.Keys))
					if (parent.Children[angle] == this)
						parent.Children.Remove(angle);
			}
			else
				foreach (double angle in new List<double>(Children.Keys))
				{
					PalettedColor thisColor = Children[angle];
					thisColor.removeSelectedColors();
				}
		}

		public void unselectColors()
		{
			if (IsSelected)
				IsSelected = false;
			//
			foreach (PalettedColor thisColor in Children.Values)
				thisColor.unselectColors();
		}

		public void unHoverSelectColors()
		{
			if (IsHoverSelected)
				IsHoverSelected = false;
			//
			foreach (PalettedColor thisColor in Children.Values)
				thisColor.unHoverSelectColors();
		}

		public void replaceSelectedWithColor(Color replacement)
		{
			if (IsSelected || IsHoverSelected)
				color = replacement;
			//
			foreach (PalettedColor thisColor in Children.Values)
				thisColor.replaceSelectedWithColor(replacement);
		}

		public PalettedColor selectedColor()
		{
			if (IsSelected || IsHoverSelected)
				return this;
			//
			PalettedColor foundColor = null;
			foreach (PalettedColor thisColor in Children.Values)
			{
				if (foundColor == null)
					foundColor = thisColor.selectedColor();
			}
			return foundColor;
		}
	}
}
