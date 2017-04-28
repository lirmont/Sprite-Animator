using System;

/// <summary>
/// Structure to define CIE XYZ.
/// </summary>
public struct CIEXYZ
{
	/// <summary>
	/// Gets an empty CIEXYZ structure.
	/// </summary>
	public static readonly CIEXYZ Empty = new CIEXYZ();
	/// <summary>
	/// Gets the CIE D65 (white) structure.
	/// </summary>
	public static readonly CIEXYZ D65 = new CIEXYZ(0.9505, 1.0, 1.0890);

	private double x;
	private double y;
	private double z;

	public static bool operator ==(CIEXYZ item1, CIEXYZ item2)
	{
		return (item1.X == item2.X && item1.Y == item2.Y && item1.Z == item2.Z);
	}

	public static bool operator !=(CIEXYZ item1, CIEXYZ item2)
	{
		return (item1.X != item2.X || item1.Y != item2.Y || item1.Z != item2.Z);
	}

	/// <summary>
	/// Gets or sets X component.
	/// </summary>
	public double X
	{
		get
		{
			return this.x;
		}
		set
		{
			this.x = (value > 0.9505) ? 0.9505 : ((value < 0) ? 0 : value);
		}
	}

	/// <summary>
	/// Gets or sets Y component.
	/// </summary>
	public double Y
	{
		get
		{
			return this.y;
		}
		set
		{
			this.y = (value > 1.0) ? 1.0 : ((value < 0) ? 0 : value);
		}
	}

	/// <summary>
	/// Gets or sets Z component.
	/// </summary>
	public double Z
	{
		get
		{
			return this.z;
		}
		set
		{
			this.z = (value > 1.089) ? 1.089 : ((value < 0) ? 0 : value);
		}
	}

	public CIEXYZ(double x, double y, double z)
	{
		this.x = (x > 0.9505) ? 0.9505 : ((x < 0) ? 0 : x);
		this.y = (y > 1.0) ? 1.0 : ((y < 0) ? 0 : y);
		this.z = (z > 1.089) ? 1.089 : ((z < 0) ? 0 : z);
	}

	public override bool Equals(object obj)
	{
		return (obj == null || GetType() != obj.GetType()) ? false : (this == (CIEXYZ)obj);
	}

	public override int GetHashCode()
	{
		return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
	}

	public static implicit operator HSV(CIEXYZ xyz)
	{
		return RGB.RGBtoHSV(XYZtoRGB(xyz));
	}

	public static implicit operator RGB(CIEXYZ xyz)
	{
		return XYZtoRGB(xyz);
	}

	/// <summary>
	/// Converts CIEXYZ to RGB structure.
	/// </summary>
	public static RGB XYZtoRGB(double x, double y, double z)
	{
		double[] Clinear = new double[3];
		Clinear[0] = x * 3.2410 - y * 1.5374 - z * 0.4986; // red
		Clinear[1] = -x * 0.9692 + y * 1.8760 + z * 0.0416; // green
		Clinear[2] = x * 0.0556 - y * 0.2040 + z * 1.0570; // blue

		for (int i = 0; i < 3; i++)
			Clinear[i] = (Clinear[i] <= 0.0031308) ? 12.92 * Clinear[i] : (1 + 0.055) * Math.Pow(Clinear[i], (1.0 / 2.2)) - 0.055;

		return new RGB(
			Convert.ToInt32(Double.Parse(String.Format("{0:0.00}", Clinear[0] * 255.0))),
			Convert.ToInt32(Double.Parse(String.Format("{0:0.00}", Clinear[1] * 255.0))),
			Convert.ToInt32(Double.Parse(String.Format("{0:0.00}", Clinear[2] * 255.0)))
		);
	}

	public static RGB XYZtoRGB(CIEXYZ xyz)
	{
		return XYZtoRGB(xyz.X, xyz.Y, xyz.Z);
	}

	/// <summary>
	/// XYZ to L*a*b* transformation function.
	/// </summary>
	private static double Fxyz(double t)
	{
		return ((t > 0.008856) ? Math.Pow(t, (1.0 / 3.0)) : (7.787 * t + 16.0 / 116.0));
	}

	/// <summary>
	/// Converts CIEXYZ to CIELab.
	/// </summary>
	public static CIELab XYZtoLab(double x, double y, double z)
	{
		CIELab lab = CIELab.Empty;

		lab.L = 116.0 * Fxyz(y / CIEXYZ.D65.Y) - 16;
		lab.A = 500.0 * (Fxyz(x / CIEXYZ.D65.X) - Fxyz(y / CIEXYZ.D65.Y));
		lab.B = 200.0 * (Fxyz(y / CIEXYZ.D65.Y) - Fxyz(z / CIEXYZ.D65.Z));

		return lab;
	}

	public static CIELab XYZtoLab(CIEXYZ XYZ)
	{
		return XYZtoLab(XYZ.X, XYZ.Y, XYZ.Z);
	}
}