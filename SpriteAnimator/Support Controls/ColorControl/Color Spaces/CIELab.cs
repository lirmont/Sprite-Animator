/// <summary>
/// Structure to define CIE L*a*b*.
/// </summary>
public struct CIELab
{
	/// <summary>
	/// Gets an empty CIELab structure.
	/// </summary>
	public static readonly CIELab Empty = new CIELab();

	private double l;
	private double a;
	private double b;

	public static bool operator ==(CIELab item1, CIELab item2)
	{
		return (item1.L == item2.L && item1.A == item2.A && item1.B == item2.B);
	}

	public static bool operator !=(CIELab item1, CIELab item2)
	{
		return (item1.L != item2.L || item1.A != item2.A || item1.B != item2.B);
	}

	/// <summary>
	/// Gets or sets L component.
	/// </summary>
	public double L
	{
		get
		{
			return this.l;
		}
		set
		{
			this.l = value;
		}
	}

	/// <summary>
	/// Gets or sets a component.
	/// </summary>
	public double A
	{
		get
		{
			return this.a;
		}
		set
		{
			this.a = value;
		}
	}

	/// <summary>
	/// Gets or sets a component.
	/// </summary>
	public double B
	{
		get
		{
			return this.b;
		}
		set
		{
			this.b = value;
		}
	}

	public CIELab(double l, double a, double b)
	{
		this.l = l;
		this.a = a;
		this.b = b;
	}

	public override bool Equals(object obj)
	{
		return (obj == null || GetType() != obj.GetType()) ? false : (this == (CIELab)obj);
	}

	public override int GetHashCode()
	{
		return L.GetHashCode() ^ a.GetHashCode() ^ b.GetHashCode();
	}

	public static implicit operator HSV(CIELab Lab)
	{
		return CIEXYZ.XYZtoRGB(LabtoXYZ(Lab));
	}

	public static implicit operator RGB(CIELab Lab)
	{
		return CIEXYZ.XYZtoRGB(LabtoXYZ(Lab));
	}

	/// <summary>
	/// Converts CIELab to CIEXYZ.
	/// </summary>
	public static CIEXYZ LabtoXYZ(double l, double a, double b)
	{
		double delta = 6.0 / 29.0;

		double fy = (l + 16) / 116.0;
		double fx = fy + (a / 500.0);
		double fz = fy - (b / 200.0);

		return new CIEXYZ(
			(fx > delta) ? CIEXYZ.D65.X * (fx * fx * fx) : (fx - 16.0 / 116.0) * 3 * (
				delta * delta) * CIEXYZ.D65.X,
			(fy > delta) ? CIEXYZ.D65.Y * (fy * fy * fy) : (fy - 16.0 / 116.0) * 3 * (
				delta * delta) * CIEXYZ.D65.Y,
			(fz > delta) ? CIEXYZ.D65.Z * (fz * fz * fz) : (fz - 16.0 / 116.0) * 3 * (
				delta * delta) * CIEXYZ.D65.Z
			);
	}

	public static CIEXYZ LabtoXYZ(CIELab Lab)
	{
		return LabtoXYZ(Lab.L, Lab.a, Lab.b);
	}
}