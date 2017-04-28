using System;

namespace SpriteAnimator
{
	partial class SupportFunctions
	{
		public static int GCD(int a, int b)
		{
			while (b > 0)
			{
				int rem = a % b;
				a = b;
				b = rem;
			}
			return a;
		}

		public static double EaseOutSine(double t, double b, double c, double d)
		{
			return c * Math.Sin(t / d * (Math.PI / 2)) + b;
		}

		/// <summary>
		/// Determines if the given point is inside the polygon
		/// </summary>
		/// <param name="polygon">the vertices of polygon</param>
		/// <param name="testPoint">the given point</param>
		/// <returns>true if the point is inside the polygon; otherwise, false</returns>
		public static bool PointIsInPolygon(Shapes.Point[] polygon, Shapes.Point testPoint)
		{
			bool result = false;
			int j = polygon.Length - 1;
			for (int i = 0; i < polygon.Length; i++)
			{
				if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
				{
					if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
					{
						result = !result;
					}
				}
				j = i;
			}
			return result;
		}

		public static T Clamp<T>(T value, T min, T max) where T : System.IComparable<T>
		{
			T result = value;
			if (value.CompareTo(max) > 0)
				result = max;
			if (value.CompareTo(min) < 0)
				result = min;
			return result;
		}
	}
}
