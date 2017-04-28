using System;

/// <summary>
/// RGB structure.
/// </summary>
public struct RGB
{
	/// <summary>
	/// Gets an empty RGB structure;
	/// </summary>
	public static readonly RGB Empty = new RGB();

	private int red;
	private int green;
	private int blue;

	public static bool operator ==(RGB item1, RGB item2)
	{
		return (
			item1.Red == item2.Red
			&& item1.Green == item2.Green
			&& item1.Blue == item2.Blue
			);
	}

	public static bool operator !=(RGB item1, RGB item2)
	{
		return (
			item1.Red != item2.Red
			|| item1.Green != item2.Green
			|| item1.Blue != item2.Blue
			);
	}

	/// <summary>
	/// Gets or sets red value.
	/// </summary>
	public int Red
	{
		get
		{
			return red;
		}
		set
		{
			red = (value > 255) ? 255 : ((value < 0) ? 0 : value);
		}
	}

	/// <summary>
	/// Gets or sets red value.
	/// </summary>
	public int Green
	{
		get
		{
			return green;
		}
		set
		{
			green = (value > 255) ? 255 : ((value < 0) ? 0 : value);
		}
	}

	/// <summary>
	/// Gets or sets red value.
	/// </summary>
	public int Blue
	{
		get
		{
			return blue;
		}
		set
		{
			blue = (value > 255) ? 255 : ((value < 0) ? 0 : value);
		}
	}

	public RGB(int R, int G, int B)
	{
		this.red = (R > 255) ? 255 : ((R < 0) ? 0 : R);
		this.green = (G > 255) ? 255 : ((G < 0) ? 0 : G);
		this.blue = (B > 255) ? 255 : ((B < 0) ? 0 : B);
	}

	public RGB(System.Drawing.Color argb)
	{
		this.red = argb.R;
		this.green = argb.G;
		this.blue = argb.B;
	}

	public override bool Equals(object obj)
	{
		return (obj == null || GetType() != obj.GetType()) ? false : (this == (RGB)obj);
	}

	public override int GetHashCode()
	{
		return Red.GetHashCode() ^ Green.GetHashCode() ^ Blue.GetHashCode();
	}

	public static implicit operator System.Drawing.Color(RGB rgb)
	{
		return System.Drawing.Color.FromArgb(255, rgb.Red, rgb.Green, rgb.Blue);
	}

	public static implicit operator CIELab(RGB rgb)
	{
		return RGBtoLab(rgb);
	}

	public static implicit operator CIEXYZ(RGB rgb)
	{
		return RGBtoXYZ(rgb);
	}

	public static implicit operator HSV(RGB rgb)
	{
		return RGBtoHSV(rgb);
	}

	/// <summary>
	/// Converts RGB to CIE XYZ (CIE 1931 color space)
	/// </summary>
	public static CIEXYZ RGBtoXYZ(int red, int green, int blue)
	{
		// normalize red, green, blue values
		double rLinear = (double)red / 255.0;
		double gLinear = (double)green / 255.0;
		double bLinear = (double)blue / 255.0;

		// convert to a sRGB form
		double r = (rLinear > 0.04045) ? Math.Pow((rLinear + 0.055) / (
			1 + 0.055), 2.2) : (rLinear / 12.92);
		double g = (gLinear > 0.04045) ? Math.Pow((gLinear + 0.055) / (
			1 + 0.055), 2.2) : (gLinear / 12.92);
		double b = (bLinear > 0.04045) ? Math.Pow((bLinear + 0.055) / (
			1 + 0.055), 2.2) : (bLinear / 12.92);

		// converts
		return new CIEXYZ(
			(r * 0.4124 + g * 0.3576 + b * 0.1805),
			(r * 0.2126 + g * 0.7152 + b * 0.0722),
			(r * 0.0193 + g * 0.1192 + b * 0.9505)
			);
	}

	public static CIEXYZ RGBtoXYZ(RGB rgb)
	{
		return RGBtoXYZ(rgb.Red, rgb.Green, rgb.Blue);
	}

	/// <summary>
	/// Converts RGB to CIELab.
	/// </summary>
	public static CIELab RGBtoLab(int red, int green, int blue)
	{
		return CIEXYZ.XYZtoLab(RGBtoXYZ(red, green, blue));
	}

	public static CIELab RGBtoLab(RGB rgb)
	{
		return CIEXYZ.XYZtoLab(RGBtoXYZ(rgb.Red, rgb.Green, rgb.Blue));
	}

	/// <summary>
	/// Converts RGB to HSB.
	/// </summary>
	public static HSV RGBtoHSV(int red, int green, int blue)
	{
		// normalize red, green and blue values
		double r = ((double)red / 255.0);
		double g = ((double)green / 255.0);
		double b = ((double)blue / 255.0);
		//
		double max = Math.Max(r, Math.Max(g, b));
		double min = Math.Min(r, Math.Min(g, b));
		double delta = max - min;
		//
		double h = 0.0;
		double s = (max == 0) ? 0.0 : (1.0 - (min / max));
		double v = max;
		//
		if (delta > 0)
		{
			if (max == r && max != g)
				h = (g - b) / delta + (g < b ? 6 : 0);
			if (max == g && max != b)
				h = (b - r) / delta + 2;
			if (max == b && max != r)
				h = (r - g) / delta + 4;
			h *= 60.0;
			if (h < 0)
				h += 360.0;
		}
		else
		{
			s = 0;
			h = 0.001;
		}
		return new HSV(h, s, v);
	}

	public static HSV RGBtoHSV(RGB rgb)
	{
		return RGBtoHSV(rgb.Red, rgb.Green, rgb.Blue);
	}
}