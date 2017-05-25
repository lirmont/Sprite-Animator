using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;

#pragma warning disable
namespace SpriteAnimator.Shapes
{
	public class Color
	{
		public double A
		{
			get { return color.A / 255.0; }
		}
		public double R
		{
			get { return color.R / 255.0; }
		}
		public double G
		{
			get { return color.G / 255.0; }
		}
		public double B
		{
			get { return color.B / 255.0; }
		}

		public System.Drawing.Color color = System.Drawing.Color.White;
		public string name;

		public Color(string name = "", System.Drawing.Color? color = null)
		{
			if (color != null)
				this.color = color ?? System.Drawing.Color.White;
			this.name = name;
		}

		public void Render()
		{
			Gl.glColor4d(R, G, B, A);
		}
	}

	// Guide, programming for storing guide line objects.
	public class Guide
	{
		public enum GuideType
		{
			Horizontal,
			Vertical,
			Screen
		}

		public GuideType type = GuideType.Horizontal;
		public double position = 0;

		public Guide(GuideType type = GuideType.Horizontal, double position = 0)
		{
			this.type = type;
			this.position = position;
		}
	}

	public class Rect
	{
		public double x, y, width, height;

		public double Height
		{
			get { return height; }
			set { height = value; }
		}

		public double Width
		{
			get { return width; }
			set { width = value; }
		}

		public double Y
		{
			get { return y; }
			set { y = value; }
		}

		public double X
		{
			get { return x; }
			set { x = value; }
		}

		public Rect(double x = 0, double y = 0, double width = 1, double height = 1)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}
	}

	// FrameInTween, programming for storage of positional requests.
	public class FrameInTween : IdentificationProperty
	{
		public int id;

		public override object ID
		{
			get { return id; }
			set { id = (int)value; }
		}

		public FrameInTween(int id = 0)
		{
			this.id = id;
		}

		public bool Equals(FrameInTween frameInTweenToCompareTo)
		{
			return frameInTweenToCompareTo.id == id;
		}
	}

	// Frame, programming for storage of frame objects.
	public class Frame : IdentificationProperty
	{
		public int id;
		public int s, t, w, h;
		public string color = null;

		public override object ID
		{
			get { return id; }
			set { id = (int)value; }
		}

		public Frame(int s = 0, int t = 0, int w = 1, int h = 1, int id = 0, string color = null)
		{
			this.id = id;
			this.s = s;
			this.t = t;
			this.w = w;
			this.h = h;
			this.color = color;
		}

		public bool Equals(Frame frameToCompareTo)
		{
			return frameToCompareTo.id == id;
		}
	}

	public class NamedAttachmentPoint : IdentificationProperty, System.ComponentModel.INotifyPropertyChanged
	{
		public int id;
		public string name, description;
		public double x = 0.5, y = 0.5;
		public bool hidden = false;

		public string PointName
		{
			get { return this.name; }
			set
			{
				this.name = value;
				NotifyPropertyChanged("PointName");
			}
		}

		public override object ID
		{
			get { return this.id; }
			set
			{
				this.id = (int)value;
				NotifyPropertyChanged("ID");
			}
		}

		public override object Tag
		{
			get { return string.Format("{0}: {1}", new object[] {this.id, this.name}); }
		}

		public NamedAttachmentPoint(int id = 0, string name = "(no name)", string description = "", double x = 0.5, double y = 0.5) {
			this.description = description;
			this.x = x;
			this.y = y;
			this.id = id;
			this.name = name;
		}

		// Declare the PropertyChanged event.
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		// NotifyPropertyChanged will raise the PropertyChanged event passing the source property that is being updated.
		public void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}

	public class Tween : IdentificationProperty
	{
		public string id;
		private int frameLength;
		public string advancementFunction;
		private List<Line> lineSegments;
		public string[] colorNames;
		public List<System.Drawing.Color> colorList;

		public override object ID
		{
			get { return id; }
			set { id = (string)value; }
		}

		/// <summary>
		/// Returns the length of the Tween object in frames.
		/// </summary>
		public int FrameLength
		{
			get { return frameLength; }
			set { frameLength = value; }
		}

		/// <summary>
		/// Returns the Line objects associated with the Tween object.
		/// </summary>
		public List<Line> LineSegments
		{
			get { return lineSegments; }
			set { lineSegments = value; }
		}

		/// <summary>
		/// Returns a boolean indicating whether the Tween effects a positional change.
		/// </summary>
		public bool HasTranslationComponent
		{
			get { return (lineSegments.Count > 0); }
		}

		/// <summary>
		/// Returns the first Line object of the collection of line segments composing the Tween object's physical form.
		/// </summary>
		public Line FirstLineSegment
		{
			get { return (HasTranslationComponent) ? lineSegments[0] : null; }
		}

		/// <summary>
		/// Returns the last Line object of the collection of line segments composing the Tween object's physical form.
		/// </summary>
		public Line LastLineSegment
		{
			get { return (HasTranslationComponent) ? lineSegments[lineSegments.Count - 1] : null; }
		}

		/// <summary>
		/// Returns the total length (in pixels) of the line segments attached to the Tween object.
		/// </summary>
		public double Length
		{
			get { return (lineSegments.Count > 0) ? lineSegments[lineSegments.Count - 1].distanceLeadingUpToLine + lineSegments[lineSegments.Count - 1].Length : 0; }
		}

		/// <summary>
		/// Returns the named Color objects associated with the Tween object.
		/// </summary>
		public List<Shapes.Color> Colors
		{
			get
			{
				List<Shapes.Color> thisColorList = new List<Shapes.Color>();
				for (int i = 0; i < colorList.Count; i++)
				{
					// For malformed descriptions, fall back to the hexadecimal name.
					string name = (colorNames != null && colorNames.Length > i) ? colorNames[i] : colorList[i].Name;
					thisColorList.Add(new Shapes.Color(name: name, color: colorList[i]));
				}
				return thisColorList;
			}
		}

		/// <summary>
		/// Returns boolean indicating whether the Tween object effects a color change.
		/// </summary>
		public bool HasColorComponent
		{
			get
			{
				if (colorList.Count > 0)
					return true;
				return false;
			}
		}

		public Tween(int frameLength, string advancementFunction = "linear", string id = "0", Point[] points = null, System.Drawing.Color[] colors = null, string[] colorNames = null)
		{
			this.id = id;
			// Set frame length.
			this.frameLength = frameLength;
			// Set function name.
			this.advancementFunction = advancementFunction;
			// Add colors.
			this.colorNames = colorNames;
			this.colorList = new List<System.Drawing.Color>();
			if (colors != null)
				for (int i = 0; i < colors.Length; i++)
					colorList.Add(colors[i]);
			// Add lines.
			this.lineSegments = new List<Line>();
			if (points != null && points.Length > 0)
			{
				// Enforce the idea of a line.
				if (points.Length == 1)
				{
					points = new Point[] {
						points[0],
						points[0],
					};
				}
				// Create the line.
				double runningDistanceTotal = 0;
				for (int i = 1; i < points.Length; i++)
				{
					Line line = new Line(points[i - 1], points[i], runningDistanceTotal);
					lineSegments.Add(line);
					runningDistanceTotal += line.Length;
				}
			}
		}

		public System.Drawing.Color colorFromFrame(int frame = 0)
		{
			if (frame < 1)
				return System.Drawing.Color.FromArgb(255, 255, 255, 255);
			else if (frame == 1 || colorList.Count == 1)
				return colorList[0];
			else if (frame >= frameLength)
				return colorList[colorList.Count - 1];
			else
			{
				double zeroToOneIndex = (double)frame / (double)this.FrameLength;
				int startIndex = 0, endIndex = 0;
				double zeroToOneStartIndex = 0, zeroToOneEndIndex = 1.0;
				for (int i = 0; i < colorList.Count; i++)
				{
					double thisZeroToOneIndex = (double)(i + 1) / (double)(colorList.Count);
					if (thisZeroToOneIndex == zeroToOneIndex)
					{
						startIndex = endIndex = i;
						zeroToOneStartIndex = zeroToOneEndIndex = zeroToOneIndex;
					}
					else if (thisZeroToOneIndex >= zeroToOneIndex)
					{
						endIndex = i;
						zeroToOneEndIndex = thisZeroToOneIndex;
						break;
					}
					else
					{
						startIndex = i;
						zeroToOneStartIndex = thisZeroToOneIndex;
					}
				}
				double transitionPercent = (zeroToOneIndex - zeroToOneStartIndex) / (zeroToOneEndIndex - zeroToOneStartIndex);
				return System.Drawing.Color.FromArgb(
					(int)((1 - transitionPercent) * colorList[startIndex].A + transitionPercent * colorList[endIndex].A),
					(int)((1 - transitionPercent) * colorList[startIndex].R + transitionPercent * colorList[endIndex].R),
					(int)((1 - transitionPercent) * colorList[startIndex].G + transitionPercent * colorList[endIndex].G),
					(int)((1 - transitionPercent) * colorList[startIndex].B + transitionPercent * colorList[endIndex].B)
				);
			}
		}

		public Point XYZFromFrame(double frame = 0)
		{
			if (frame < 0 || !HasTranslationComponent)
				return new Point(0, 0, 0);
			else if (frame == 0)
				return this.FirstLineSegment.Start;
			else if (frame >= frameLength)
				return (lineSegments.Count > 0) ? this.LastLineSegment.End : new Point(0, 0, 0);
			else
			{
				// TODO: Easing
				double distance = (frame - 1) * (this.Length / (double)(this.FrameLength - 1));
				Line lineSegmentThatContainsPoint = this.LineSegments.Find(
						item =>
								(item.distanceLeadingUpToLine) <= distance
							 && (item.distanceLeadingUpToLine + item.Length) >= distance
				);
				//
				if (lineSegmentThatContainsPoint != null)
				{
					double distanceOnLineSegmentThatContainsPoint = distance - lineSegmentThatContainsPoint.distanceLeadingUpToLine;
					return lineSegmentThatContainsPoint.PointAtDistance(distanceOnLineSegmentThatContainsPoint);
				}
				else
					return new Point(0, 0, 0);
			}
		}

		public double distanceFromFrame(double frame = 0)
		{
			if (frame <= 0)
				return 0.00;
			else if (frame >= frameLength)
				return (lineSegments.Count > 0) ? this.Length : 0.00;
			else
			{
				// TODO: Easing
				double distance = (frame - 1) * (this.Length / (double)(this.FrameLength - 1));
				return distance;
			}
		}

		public List<Point> getPoints()
		{
			List<Point> points = new List<Point>();
			if (HasTranslationComponent)
			{
				points.Add(this.FirstLineSegment.Start);
				for (int i = 0; i < this.LineSegments.Count; i++)
					points.Add(this.LineSegments[i].End);
			}
			return points;
		}
	}

	public class Line
	{
		public Point Start, End;
		public double distanceLeadingUpToLine;

		public double Length
		{
			get { return Start.DistanceToPoint(End); }
		}

		public double X1Property
		{
			get { return Start.X; }
			set { Start.X = value; }
		}

		public double Y1Property
		{
			get { return Start.Y; }
			set { Start.Y = value; }
		}

		public double Z1Property
		{
			get { return Start.Z; }
			set { Start.Z = value; }
		}

		public double X2Property
		{
			get { return End.X; }
			set { End.X = value; }
		}

		public double Y2Property
		{
			get { return End.Y; }
			set { End.Y = value; }
		}

		public double Z2Property
		{
			get { return End.Z; }
			set { End.Z = value; }
		}

		public Line(Point Start, Point End, double distanceLeadingUpToLine = 0)
		{
			this.Start = Start;
			this.End = End;
			this.distanceLeadingUpToLine = distanceLeadingUpToLine;
		}

		public Point EquationOfLine(Point t)
		{
			return this.Start + t * (this.End - this.Start);
		}

		public Point PointAtDistance(double distanceOnLine)
		{
			// Calculate the percentage of the requested distance against the distance of the line.
			double percentageOfDistance = (this.Length > 0) ? distanceOnLine / this.Length : 0;
			// Get a point-vector that represents the percentage of the line the point will end at; multiplied against the distance.
			Point percentagePoint = new Point(percentageOfDistance);
			// Line: <x, y, z> = Start<x, y, z> + t<x, y, z> * (End<x, y, z> - Start<x, y, z>)
			Point pointOnLine = EquationOfLine(percentagePoint);
			// Send the point back.
			return pointOnLine;
		}
	}

	public class Point
	{
		public double X, Y, Z;

		public double x
		{
			get { return X; }
			set { X = value; }
		}

		public double y
		{
			get { return Y; }
			set { Y = value; }
		}

		public double z
		{
			get { return Z; }
			set { Z = value; }
		}

		public double S
		{
			get { return X; }
			set { X = value; }
		}

		public double T
		{
			get { return Y; }
			set { Y = value; }
		}

		public double R
		{
			get { return Z; }
			set { Z = value; }
		}

		public Point(double X, double Y, double Z = 0)
		{
			this.X = X;
			this.Y = Y;
			this.Z = Z;
		}

		public Point(double C)
		{
			this.X = C;
			this.Y = C;
			this.Z = C;
		}

		public double DistanceToPoint(Point B)
		{
			Point squaredDifference = (B - this) * (B - this);
			return Math.Sqrt(squaredDifference.X + squaredDifference.Y + squaredDifference.Z);
		}

		public void Render()
		{
			Gl.glVertex3d(X, Y, Z);
		}

		public void RenderAsTextureCoordinate()
		{
			Gl.glTexCoord3d(S, T, R);
		}

		public static Point operator -(Point B, Point A)
		{
			return new Point(B.X - A.X, B.Y - A.Y, B.Z - A.Z);
		}

		public static Point operator +(Point A, Point B)
		{
			return new Point(A.X + B.X, A.Y + B.Y, A.Z + B.Z);
		}

		public static Point operator *(Point A, Point B)
		{
			return new Point(A.X * B.X, A.Y * B.Y, A.Z * B.Z);
		}

		public static Point operator /(Point A, Point B)
		{
			return new Point(A.X / B.X, A.Y / B.Y, A.Z / B.Z);
		}

		public override string ToString()
		{
			return string.Format("Shapes.Point({0}, {1}, {2})", new object[]{ X, Y, Z });
		} 
	}

	// FrameCall, programming for storage of frame calls inside composite frames.
	public class FrameCall : IdentificationProperty
	{
		public string id = "0";
		public double offsetX = 0, offsetY = 0, offsetZ = 0, rotationZ = 0, scaleX = 1, scaleY = 1;
		public bool flipX = false;
		public string tweenId = "0";
		public int frameInTween = 0;
		public string motionTrailType = "instance";
		public int motionTrailFramesInTween = 0;
		public string colorName = "";
		public string blendMode = "overwrite";
		public String namedAttachmentPointId = null;

		public override object ID
		{
			get { return id; }
			set { id = (string)value; }
		}

		public double OffsetX
		{
			get { return offsetX; }
			set { offsetX = value; }
		}

		public double OffsetY
		{
			get { return offsetY; }
			set { offsetY = value; }
		}

		public double OffsetZ
		{
			get { return offsetZ; }
			set { offsetZ = value; }
		}

		public double ScaleX
		{
			get { return scaleX; }
			set { scaleX = value; }
		}

		public double ScaleY
		{
			get { return scaleY; }
			set { scaleY = value; }
		}

		public double RotationZ
		{
			get { return rotationZ; }
			set { rotationZ = value; }
		}

		public string ColorName
		{
			get { return colorName; }
			set { colorName = value; }
		}

		public string BlendMode
		{
			get { return blendMode; }
			set { blendMode = value; }
		}

		public int MotionTrailFramesInTween
		{
			get { return motionTrailFramesInTween; }
			set { motionTrailFramesInTween = value; }
		}

		public string MotionTrailType
		{
			get { return motionTrailType; }
			set { motionTrailType = value; }
		}

		public int FrameInTween
		{
			get { return frameInTween; }
			set { frameInTween = value; }
		}

		public string TweenId
		{
			get { return tweenId; }
			set { tweenId = value; }
		}

		public bool FlipX
		{
			get { return flipX; }
			set { flipX = value; }
		}

		public String NamedAttachmentPointId
		{
			get { return namedAttachmentPointId; }
			set { namedAttachmentPointId = value; }
		}

		public FrameCall(
			string id = "0",
			double offsetX = 0, double offsetY = 0, double offsetZ = 0, double rotationZ = 0, double scaleX = 1, double scaleY = 1,
			bool flipX = false,
			string tweenId = "0", int frameInTween = 0,
			string motionTrailType = "instance",
			int motionTrailFramesInTween = 0,
			string colorName = "",
			string blendMode = "overwrite",
			String namedAttachmentPointId = null
		)
		{
			this.id = id;
			this.offsetX = offsetX;
			this.offsetY = offsetY;
			this.offsetZ = offsetZ;
			this.rotationZ = rotationZ;
			this.scaleX = scaleX;
			this.scaleY = scaleY;
			this.flipX = flipX;
			this.tweenId = tweenId;
			this.frameInTween = frameInTween;
			this.motionTrailType = motionTrailType;
			this.motionTrailFramesInTween = motionTrailFramesInTween;
			this.colorName = colorName;
			this.blendMode = blendMode;
			this.namedAttachmentPointId = namedAttachmentPointId;
		}

		public FrameCall(FrameCall obj)
		{
			id = obj.id;
			namedAttachmentPointId = obj.namedAttachmentPointId;
			offsetX = obj.offsetX;
			offsetY = obj.offsetY;
			offsetZ = obj.offsetZ;
			rotationZ = obj.rotationZ;
			scaleX = obj.scaleX;
			scaleY = obj.scaleY;
			flipX = obj.flipX;
			tweenId = obj.tweenId;
			frameInTween = obj.frameInTween;
			motionTrailType = obj.motionTrailType;
			motionTrailFramesInTween = obj.motionTrailFramesInTween;
			colorName = obj.colorName;
			blendMode = obj.blendMode;
		}
	}

	// CompositeFrame, programming for storage of composite frames.
	public class CompositeFrame : IdentificationProperty, IEquatable<CompositeFrame>
	{
		public string id = "0";
		public List<Sound> sounds = new List<Sound>();
		public List<FrameCall> frameCalls = new List<FrameCall>();

		public override object ID
		{
			get { return id; }
			set { id = (string)value; }
		}

		public CompositeFrame(string id = "0")
		{
			this.id = id;
		}

		public bool Equals(CompositeFrame compositeFrameToCompareTo)
		{
			return compositeFrameToCompareTo.id == id;
		}

		public static bool Equals(CompositeFrame compositeFrameA, CompositeFrame compositeFrameB)
		{
			return compositeFrameA.id == compositeFrameB.id;
		}
	}

	// CompositeFrameCall, programming for named sets of composite frame calls.
	public class CompositeFrameCall : IdentificationProperty, IEquatable<CompositeFrameCall>
	{
		public string id = "0";
		public string eventName = null;

		public override object ID
		{
			get { return id; }
			set { id = (string)value; }
		}

		public CompositeFrameCall(string id = "0", string eventName = null)
		{
			this.id = id;
			this.eventName = eventName;
		}

		public bool Equals(CompositeFrameCall compositeFrameToCompareTo)
		{
			return compositeFrameToCompareTo.id == id;
		}

		public static bool Equals(CompositeFrameCall compositeFrameA, CompositeFrameCall compositeFrameB)
		{
			return compositeFrameA.id == compositeFrameB.id;
		}
	}

	// 
	public class CompositeFrameSet : IEquatable<CompositeFrameSet>
	{
		public string name = null;
		public int? targetMS = null;
		public List<CompositeFrameCall> compositeFrameCalls;

		public CompositeFrameSet(string name = null, int? targetMS = null, List<CompositeFrameCall> compositeFrameCalls = null)
		{
			this.name = name;
			this.targetMS = targetMS;
			this.compositeFrameCalls = compositeFrameCalls;
		}

		public string FrameCallsForDisplay()
		{
			List<string> list = new List<string>();
			foreach (CompositeFrameCall call in this.compositeFrameCalls)
				list.Add(call.id);
			return (this.compositeFrameCalls != null) ? string.Join(", ", list.ToArray()) : "";
		}

		public bool Equals(CompositeFrameSet compositeFrameSetToCompareTo)
		{
			return compositeFrameSetToCompareTo.name == name;
		}

		public static bool Equals(CompositeFrameSet compositeFrameSetA, CompositeFrameSet compositeFrameSetB)
		{
			return compositeFrameSetA.name == compositeFrameSetB.name;
		}
	}
}