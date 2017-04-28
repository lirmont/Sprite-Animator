using System;
using System.Drawing;

#pragma warning disable
namespace SpriteAnimator.SupportClasses
{
	class Blending
	{
		// Target = Source or Incoming Color
		// Blend = Destination or Existing Color
		public static Color Darken(Color Target, Color Blend, bool IgnoreAlpha = false)
		{
			// NOTE: When both colors are completely opaque, 0 is returned for alpha. 
			// Gl.glBlendFunc(Gl.GL_ONE_MINUS_DST_COLOR, Gl.GL_ONE_MINUS_SRC_COLOR);
			double sr = 1 - (Blend.R / 255.0), sg = 1 - (Blend.G / 255.0), sb = 1 - (Blend.B / 255.0), sa = 1 - (Blend.A / 255.0);
			double dr = 1 - (Target.R / 255.0), dg = 1 - (Target.G / 255.0), db = 1 - (Target.B / 255.0), da = 1 - (Target.A / 255.0);
			//R = min(Target,Blend)?
			double r = SupportFunctions.Clamp<double>((Target.R / 255.0) * sr + (Blend.R / 255.0) * dr, 0, 1);
			double g = SupportFunctions.Clamp<double>((Target.G / 255.0) * sg + (Blend.G / 255.0) * dg, 0, 1);
			double b = SupportFunctions.Clamp<double>((Target.B / 255.0) * sb + (Blend.B / 255.0) * db, 0, 1);
			double a = (IgnoreAlpha) ? 1 : SupportFunctions.Clamp<double>((Target.A / 255.0) * sa + (Blend.A / 255.0) * da, 0, 1);
			return Color.FromArgb((int)(a * 255.0), (int)(r * 255.0), (int)(g * 255.0), (int)(b * 255.0));
		}

		public static Color Difference(Color Target, Color Blend, bool IgnoreAlpha = false)
		{
			// Reverse subtraction
			// Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE);
			double sr = -1, sg = -1, sb = -1, sa = 1;
			double dr = 1, dg = 1, db = 1, da = 1;
			//R = min(Target,Blend)?
			double r = SupportFunctions.Clamp<double>((Target.R / 255.0) * sr + (Blend.R / 255.0) * dr, 0, 1);
			double g = SupportFunctions.Clamp<double>((Target.G / 255.0) * sg + (Blend.G / 255.0) * dg, 0, 1);
			double b = SupportFunctions.Clamp<double>((Target.B / 255.0) * sb + (Blend.B / 255.0) * db, 0, 1);
			double a = (IgnoreAlpha) ? 1 : SupportFunctions.Clamp<double>((Target.A / 255.0) * sa + (Blend.A / 255.0) * da, 0, 1);
			return Color.FromArgb((int)(a * 255.0), (int)(r * 255.0), (int)(g * 255.0), (int)(b * 255.0));
		}

		public static Color Multiply(Color Target, Color Blend, bool IgnoreAlpha = false)
		{
			//R = Target x Blend
			double r = (Target.R / 255.0) * (Blend.R / 255.0);
			double g = (Target.G / 255.0) * (Blend.G / 255.0);
			double b = (Target.B / 255.0) * (Blend.B / 255.0);
			double a = (IgnoreAlpha) ? (Target.A / 255.0) * (Blend.A / 255.0) : 1;
			return Color.FromArgb((int)(a * 255), (int)(r * 255), (int)(g * 255), (int)(b * 255));
		}

		public static Color ColorBurn(Color Target, Color Blend, bool IgnoreAlpha = false)
		{
			//R = 1 - (1-Target) / Blend
			// Gl.glBlendFunc(Gl.GL_ZERO, Gl.GL_ONE_MINUS_SRC_COLOR);
			double sr = 0, sg = 0, sb = 0, sa = 0;
			double dr = 1 - (Target.R / 255.0), dg = 1 - (Target.G / 255.0), db = 1 - (Target.B / 255.0), da = 1 - (Target.A / 255.0);
			double r = SupportFunctions.Clamp<double>((Target.R / 255.0) * sr + (Blend.R / 255.0) * dr, 0, 1);
			double g = SupportFunctions.Clamp<double>((Target.G / 255.0) * sg + (Blend.G / 255.0) * dg, 0, 1);
			double b = SupportFunctions.Clamp<double>((Target.B / 255.0) * sb + (Blend.B / 255.0) * db, 0, 1);
			double a = (IgnoreAlpha) ? 1 : SupportFunctions.Clamp<double>((Target.A / 255.0) * sa + (Blend.A / 255.0) * da, 0, 1);
			return Color.FromArgb((int)(a * 255.0), (int)(r * 255.0), (int)(g * 255.0), (int)(b * 255.0));
		}

		public static Color LinearBurn(Color Target, Color Blend, bool IgnoreAlpha = false)
		{
			//R = Target + Blend - 1 
			double r = (Target.R / 255.0) + (Blend.R / 255.0) - 1;
			double g = (Target.G / 255.0) + (Blend.G / 255.0) - 1;
			double b = (Target.B / 255.0) + (Blend.B / 255.0) - 1;
			double a = (IgnoreAlpha) ? (Target.A / 255.0) + (Blend.A / 255.0) - 1 : 1;
			return Color.FromArgb((int)Math.Max((a * 255), 0), (int)Math.Max((r * 255), 0), (int)Math.Max((g * 255), 0), (int)Math.Max((b * 255), 0));
		}

		public static Color Lighten(Color Target, Color Blend, bool IgnoreAlpha = false)
		{
			//R = max(Target,Blend)
			double r = Math.Max(Target.R / 255.0, Blend.R / 255.0);
			double g = Math.Max(Target.G / 255.0, Blend.G / 255.0);
			double b = Math.Max(Target.B / 255.0, Blend.B / 255.0);
			double a = (IgnoreAlpha) ? Math.Max(Target.A / 255.0, Blend.A / 255.0) : 1;
			return Color.FromArgb((int)(a * 255), (int)(r * 255), (int)(g * 255), (int)(b * 255));
		}

		public static Color Screen(Color Target, Color Blend, bool IgnoreAlpha = false)
		{
			//R = 1 - (1-Target) x (1-Blend)
			double r = 1 - (1 - Target.R / 255.0) * (1 - Blend.R / 255.0);
			double g = 1 - (1 - Target.G / 255.0) * (1 - Blend.G / 255.0);
			double b = 1 - (1 - Target.B / 255.0) * (1 - Blend.B / 255.0);
			double a = (IgnoreAlpha) ? 1 - (1 - Target.A / 255.0) * (1 - Blend.A / 255.0) : 1;
			return Color.FromArgb((int)(a * 255), (int)(r * 255), (int)(g * 255), (int)(b * 255));
		}

		public static Color ColorDodge(Color Target, Color Blend, bool IgnoreAlpha = false)
		{
			// Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE);
			double sr = 1, sg = 1, sb = 1, sa = 1;
			double dr = 1, dg = 1, db = 1, da = 1;
			//R = Target / (1-Blend)  
			double r = SupportFunctions.Clamp<double>((Target.R / 255.0) * sr + (Blend.R / 255.0) * dr, 0, 1);
			double g = SupportFunctions.Clamp<double>((Target.G / 255.0) * sg + (Blend.G / 255.0) * dg, 0, 1);
			double b = SupportFunctions.Clamp<double>((Target.B / 255.0) * sb + (Blend.B / 255.0) * db, 0, 1);
			double a = (IgnoreAlpha) ? 1 : SupportFunctions.Clamp<double>((Target.A / 255.0) * sa + (Blend.A / 255.0) * da, 0, 1);
			return Color.FromArgb((int)(a * 255.0), (int)(r * 255.0), (int)(g * 255.0), (int)(b * 255.0));
		}

		public static Color LinearDodge(Color Target, Color Blend, bool IgnoreAlpha = false)
		{
			//R = Target + Blend
			double r = (Target.R / 255.0) + (Blend.R / 255.0);
			double g = (Target.G / 255.0) + (Blend.G / 255.0);
			double b = (Target.B / 255.0) + (Blend.B / 255.0);
			double a = (IgnoreAlpha) ? (Target.A / 255.0) + (Blend.A / 255.0) : 1;

			return Color.FromArgb((int)Math.Min((a * 255), 255), (int)Math.Min((r * 255), 255), (int)Math.Min((g * 255), 255), (int)Math.Min((b * 255), 255));
		}

		public static Color Blend(Color Target, Color Blend, string BlendFunction, Color BackgroundColor)
		{
			switch (BlendFunction)
			{
				case "darken":
				case "darken-ignore-alpha":
					//return Darken(Target, Blend);
					return Darken(Target, Blend, IgnoreAlpha: true);
				case "difference":
				case "difference-ignore-alpha":
					return Difference(Target, Blend, IgnoreAlpha: true);
				case "multiply":
					return Multiply(Target, Blend);
				case "multiply-ignore-alpha":
					return Multiply(Target, Blend, IgnoreAlpha: true);
				case "color-burn":
				case "color-burn-ignore-alpha":
					//return ColorBurn(Target, Blend);
					return ColorBurn(Target, Blend, IgnoreAlpha: true);
				case "linear-burn":
					return LinearBurn(Target, Blend);
				case "linear-burn-ignore-alpha":
					return LinearBurn(Target, Blend, IgnoreAlpha: true);
				case "lighten":
					return Lighten(Target, Blend);
				case "lighten-ignore-alpha":
					return Lighten(Target, Blend, IgnoreAlpha: true);
				case "color-dodge":
				case "color-dodge-ignore-alpha":
					//return ColorDodge(Target, Blend);
					return ColorDodge(Target, Blend, IgnoreAlpha: true);
				case "linear-dodge":
					return LinearDodge(Target, Blend);
				case "linear-dodge-ignore-alpha":
					return LinearDodge(Target, Blend, IgnoreAlpha: true);
				case "screen":
					return Screen(Target, Blend);
				case "screen-ignore-alpha":
					return Screen(Target, Blend, IgnoreAlpha: true);
				default:
					if (Target.A == 0)
						return Blend;
					else if ((Target.R == BackgroundColor.R && Target.G == BackgroundColor.G && Target.B == BackgroundColor.B))
						return Blend;
					else
						return Target;
			}
		}
	}
}
