namespace SpriteAnimator.SupportClasses
{
	public class ColorWithCount
	{
		private System.Drawing.Color color;
		private int count;

		public System.Drawing.Color Color
		{
			get { return color; }
			set { color = value; }
		}

		public int Count
		{
			get { return count; }
			set { count = value; }
		}

		public ColorWithCount(System.Drawing.Color color, int count = 1)
		{
			this.color = color;
			this.count = count;
		}

		public static implicit operator System.Drawing.Color(ColorWithCount c)
		{
			return c.Color;
		}
	}
}
