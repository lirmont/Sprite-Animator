using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using SpriteAnimator.SupportClasses;
using System.Security.Cryptography;

#pragma warning disable
namespace SpriteAnimator
{
	partial class SupportFunctions
	{
		public static bool IntegerValueListEquals(List<int> oldList, List<int> newList)
		{
			if (oldList.Count == newList.Count && oldList.TrueForAll(item => newList.Contains(item)))
				return true;
			return false;
		}

		public static string GetProgramVersionString()
		{
			return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		public static string ApiEncode(string dataString)
		{
			byte[] key = Encoding.ASCII.GetBytes("E80B482236C0957267A5466B");
			byte[] iv = Encoding.ASCII.GetBytes("824DB9AA");
			byte[] data = Encoding.ASCII.GetBytes(dataString);
			byte[] enc = new byte[0];
			TripleDES tdes = TripleDES.Create();
			tdes.IV = iv;
			tdes.Key = key;
			tdes.Mode = CipherMode.CBC;
			tdes.Padding = PaddingMode.Zeros;
			ICryptoTransform ict = tdes.CreateEncryptor();
			enc = ict.TransformFinalBlock(data, 0, data.Length);
			return Bin2Hex(enc);
		}

		public static string ApiDecode(string Data)
		{
			byte[] key = Encoding.ASCII.GetBytes("E80B482236C0957267A5466B");
			byte[] iv = Encoding.ASCII.GetBytes("824DB9AA");
			byte[] data = StringToByteArray(Data);
			byte[] enc = new byte[0];
			TripleDES tdes = TripleDES.Create();
			tdes.IV = iv;
			tdes.Key = key;
			tdes.Mode = CipherMode.CBC;
			tdes.Padding = PaddingMode.Zeros;
			ICryptoTransform ict = tdes.CreateDecryptor();
			enc = ict.TransformFinalBlock(data, 0, data.Length);
			return Encoding.ASCII.GetString(enc).TrimEnd('\0');
		}
		
		static string Bin2Hex(byte[] bin)
		{
			StringBuilder sb = new StringBuilder(bin.Length * 2);
			foreach (byte b in bin)
				sb.Append(b.ToString("x").PadLeft(2, '0'));
			return sb.ToString();
		}

		public static string ByteArrayToString(byte[] ba)
		{
			string hex = BitConverter.ToString(ba);
			return hex.Replace("-", "");
		}

		public static byte[] StringToByteArray(String hex)
		{
			byte[] bytes = new byte[]{};
			if (hex != null)
			{
				int NumberChars = hex.Length;
				bytes = new byte[NumberChars / 2];
				for (int i = 0; i < NumberChars; i += 2)
					bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			}
			return bytes;
		}

		public static void ComposeNumericallyGroupedContextMenus(IdentificationProperty[] items, System.Windows.Forms.ContextMenuStrip stripToHoldGroups, System.EventHandler handler, int sizePerGroup = 10)
		{
			if (items.Length > 0)
			{
				// Determine amount of items that fit into N groups (where N is the size per group; ex: 10 groups of 10 objects).
				int sizeSquared = sizePerGroup * sizePerGroup;
				// Scale the list based on size.
				if (items.Length > sizeSquared)
					sizePerGroup *= 1 + items.Length / (sizeSquared + 1);
				//
				sizePerGroup = Math.Min(40, sizePerGroup);
				// Count how many menu item lists will be needed to house the frame assets.
				int createXMenuItemLists = (items.Length / sizePerGroup) + Math.Min(items.Length % sizePerGroup, 1);
				for (int cursorInList = 0; cursorInList < createXMenuItemLists; cursorInList++)
				{
					int startInclusive = Math.Min(cursorInList * sizePerGroup, items.Length - 1);
					int endNonInclusive = ((cursorInList + 1) * sizePerGroup <= items.Length) ? (cursorInList + 1) * sizePerGroup : items.Length;
					ToolStripMenuItem t = new ToolStripMenuItem(string.Format("{0} - {1}", items[startInclusive].ID, items[endNonInclusive - 1].ID));
					for (int startI = startInclusive; startI < endNonInclusive; startI++)
					{
						ToolStripMenuItem item = new ToolStripMenuItem(string.Format("{0}", items[startI].Tag), null, handler);
						item.Tag = items[startI];
						t.DropDownItems.Add(item);
					}
					stripToHoldGroups.Items.Add(t);
				}
			}
		}

		public static XmlDocument GetSpriteFormatXMLDocument(string baseLocation = "", string format = "")
		{
			XmlDocument doc = null;
			// Make sure there is a baseLocation and loadedFormat provided.
			if (baseLocation != "" && format != "")
			{
				// If the necessary things are provided, create a file URI.
				string xmlFileURI = baseLocation + @"\formats\" + format + @"\sprite.xml";
				// If the file exists, read in the XML file.
				if (File.Exists(xmlFileURI))
				{
					// Read in format file (XML).
					XmlTextReader reader = new XmlTextReader(xmlFileURI);
					// Create a document to store the read in.
					doc = new XmlDocument();
					// Pass the reader into the document.
					doc.Load(reader);
					// Close the reader.
					reader.Close();
				}
			}
			return doc;
		}

		public static XmlElement GetSpriteFormatXMLRoot(string baseLocation = "", string format = "")
		{
			XmlElement root = null;
			// Make sure there is a baseLocation and loadedFormat provided.
			if (baseLocation != "" && format != "")
			{
				// If the necessary things are provided, create a file URI.
				string xmlFileURI = baseLocation + @"\formats\" + format + @"\sprite.xml";
				// If the file exists, read in the XML file.
				if (File.Exists(xmlFileURI))
				{
					// Read in format file (XML).
					XmlTextReader reader = new XmlTextReader(xmlFileURI);
					// Create a document to store the read in.
					XmlDocument doc = new XmlDocument();
					// Attempt to parse the XML in the file (fails if no root element exists).
					try
					{
						// Pass the reader into the document.
						doc.Load(reader);
						// Close the reader.
						reader.Close();
						// Query for the XML root object.
						root = doc.DocumentElement;
					}
					catch (Exception) { }
				}
			}
			return root;
		}

		public static XmlElement GetSpriteFormatXMLRoot(XmlDocument document = null)
		{
			return (document != null) ? document.DocumentElement : null;
		}

		public static string GetNameFromSpriteFormatXMLDocument(string baseLocation = "", string format = "")
		{
			string name = format;
			XmlElement root = SupportFunctions.GetSpriteFormatXMLRoot(baseLocation, format);
			if (root != null)
			{
				System.Xml.XmlNode nodeFormat = root.SelectSingleNode("/format");
				name = (nodeFormat.Attributes.GetNamedItem("name") != null) ? nodeFormat.Attributes.GetNamedItem("name").Value : format;
			}
			return name;
		}

		public static List<Shapes.Tween> GetListOfAvailableTweensFromXMLRoot(XmlElement root = null, string baseLocation = "", string format = "")
		{
			// Create a place to store the tween objects.
			List<Shapes.Tween> availableTweenList = new List<Shapes.Tween>();
			// If the XML's root doesn't exist, try to get it.
			root = (root == null) ? GetSpriteFormatXMLRoot(baseLocation: baseLocation, format: format) : root;
			if (root != null)
			{
				// Create a place to store the colors.
				List<Shapes.Color> availableColorList = SupportFunctions.GetListOfAvailableColorsFromXMLRoot(root: root);
				List<string> colorNames = new List<string>();
				XmlNode nodeMotionTweens = root.SelectSingleNode("/format/motion-tweens");
				if (nodeMotionTweens != null)
				{
					foreach (XmlNode t in nodeMotionTweens.ChildNodes)
					{
						int frameLength = (t.Attributes.GetNamedItem("length-in-frames") != null) ? int.Parse(t.Attributes.GetNamedItem("length-in-frames").Value) : 1;
						string advancementFunction = (t.Attributes.GetNamedItem("advancement-function") != null) ? t.Attributes.GetNamedItem("advancement-function").Value : "linear";
						string id = (t.Attributes.GetNamedItem("id") != null) ? t.Attributes.GetNamedItem("id").Value : "0";
						List<Shapes.Point> pointsInTween = new List<Shapes.Point>();
						List<Color> colorsInTween = new List<Color>();
						foreach (XmlNode pt in t.ChildNodes)
						{
							if (pt.Name == "point")
							{
								int x = (pt.Attributes.GetNamedItem("x") != null) ? int.Parse(pt.Attributes.GetNamedItem("x").Value) : 0;
								int y = (pt.Attributes.GetNamedItem("y") != null) ? int.Parse(pt.Attributes.GetNamedItem("y").Value) : 0;
								int z = (pt.Attributes.GetNamedItem("z") != null) ? int.Parse(pt.Attributes.GetNamedItem("z").Value) : 0;
								pointsInTween.Add(new Shapes.Point(x, y, z));
							}
							else if (pt.Name == "color-state")
							{
								string name = (pt.Attributes.GetNamedItem("name") != null) ? pt.Attributes.GetNamedItem("name").Value : "1";
								Shapes.Color thisColor = availableColorList.Find(item => item.name == name);
								if (thisColor == null)
									thisColor = new Shapes.Color(name: name, color: Color.White);
								colorsInTween.Add(thisColor.color);
								colorNames.Add(thisColor.name);
							}
						}
						availableTweenList.Add(new Shapes.Tween(frameLength, advancementFunction: advancementFunction, id: id, points: pointsInTween.ToArray(), colors: colorsInTween.ToArray(), colorNames: colorNames.ToArray()));
					}
				}
			}
			return availableTweenList;
		}

		public static List<Shapes.Guide> GetListOfGuidesFromXMLRoot(XmlElement root = null, string baseLocation = "", string format = "")
		{
			// Create a place to store the guides.
			List<Shapes.Guide> guides = new List<Shapes.Guide>();
			// If the XML's root doesn't exist, try to get it.
			root = (root == null) ? GetSpriteFormatXMLRoot(baseLocation: baseLocation, format: format) : root;
			if (root != null)
			{
				XmlNode nodeGuides = root.SelectSingleNode("/format/guides");
				if (nodeGuides != null)
				{
					foreach (XmlNode t in nodeGuides.ChildNodes)
					{
						string guideType = (t.Attributes.GetNamedItem("type") != null) ? (t.Attributes.GetNamedItem("type").Value) : "horizontal";
						double guidePosition = (t.Attributes.GetNamedItem("value") != null) ? double.Parse(t.Attributes.GetNamedItem("value").Value) : 0;
						if (guideType.ToLower() == "horizontal")
							guides.Add(new Shapes.Guide(Shapes.Guide.GuideType.Horizontal, guidePosition));
						else if (guideType.ToLower() == "vertical")
							guides.Add(new Shapes.Guide(Shapes.Guide.GuideType.Vertical, guidePosition));
						else
							guides.Add(new Shapes.Guide(Shapes.Guide.GuideType.Horizontal, guidePosition));
					}
				}
			}
			return guides;
		}

		public static List<Shapes.Color> GetListOfAvailableColorsFromXMLRoot(XmlElement root = null, string baseLocation = "", string format = "")
		{
			// Create a place to store the list of colors.
			List<Shapes.Color> availableColorList = new List<Shapes.Color>();
			// If the XML's root doesn't exist, try to get it.
			root = (root == null) ? GetSpriteFormatXMLRoot(baseLocation: baseLocation, format: format) : root;
			if (root != null)
			{
				XmlNode nodeColorList = root.SelectSingleNode("/format/colors");
				if (nodeColorList != null)
				{
					foreach (XmlNode pt in nodeColorList.ChildNodes)
					{
						if (pt.Name == "color")
						{
							string name = (pt.Attributes.GetNamedItem("name") != null) ? pt.Attributes.GetNamedItem("name").Value : "1";
							double r = (pt.Attributes.GetNamedItem("r") != null) ? double.Parse(pt.Attributes.GetNamedItem("r").Value) : 1;
							double g = (pt.Attributes.GetNamedItem("g") != null) ? double.Parse(pt.Attributes.GetNamedItem("g").Value) : 1;
							double b = (pt.Attributes.GetNamedItem("b") != null) ? double.Parse(pt.Attributes.GetNamedItem("b").Value) : 1;
							double a = (pt.Attributes.GetNamedItem("a") != null) ? double.Parse(pt.Attributes.GetNamedItem("a").Value) : 1;
							availableColorList.Add(
								new Shapes.Color(
									name: name,
									color: Color.FromArgb((int)(a * 255.0), (int)(r * 255.0), (int)(g * 255.0), (int)(b * 255.0))
								)
							);
						}
					}
				}
			}
			return availableColorList;
		}

		public static List<Shapes.Frame> GetListOfAvailableFramesFromXMLRoot(XmlElement root = null, string baseLocation = "", string format = "")
		{
			// If the XML's root doesn't exist, try to get it.
			root = (root == null) ? GetSpriteFormatXMLRoot(baseLocation: baseLocation, format: format) : root;
			//
			List<Shapes.Frame> frames = new List<Shapes.Frame>();
			XmlNode nodeFrames = root.SelectSingleNode("/format/frames");
			if (nodeFrames != null)
			{
				foreach (XmlNode f in nodeFrames.ChildNodes)
				{
					if (f.Name == "frame")
					{
						if (f.Attributes.GetNamedItem("id") != null)
						{
							int fId = int.Parse(f.Attributes.GetNamedItem("id").Value);
							int sInPixels = (f != null && f.Attributes.GetNamedItem("s") != null) ? int.Parse(f.Attributes.GetNamedItem("s").Value) : 0;
							int tInPixels = (f != null && f.Attributes.GetNamedItem("t") != null) ? int.Parse(f.Attributes.GetNamedItem("t").Value) : 0;
							int addWidth = (f != null && f.Attributes.GetNamedItem("w") != null) ? int.Parse(f.Attributes.GetNamedItem("w").Value) : 1;
							int addHeight = (f != null && f.Attributes.GetNamedItem("h") != null) ? int.Parse(f.Attributes.GetNamedItem("h").Value) : 1;
							string color = (f != null && f.Attributes.GetNamedItem("color-name") != null) ? f.Attributes.GetNamedItem("color-name").Value : null;
							frames.Add(new Shapes.Frame(s: sInPixels, t: tInPixels, w: addWidth, h: addHeight, color: color, id: fId));
						}
					}
				}
				frames.Sort(delegate(Shapes.Frame a, Shapes.Frame b)
				{
					if (a.id < b.id)
						return -1;
					else if (a.id > b.id)
						return 1;
					else
						return 0;
				});
			}
			return frames;
		}

		public static List<Shapes.FrameCall> GetListOfFrameCallsFromCompositeFrame(int copyFromFrame = 0, XmlElement root = null, string baseLocation = "", string format = "", Main parent = null)
		{
			// If the XML's root doesn't exist, try to get it.
			root = (root == null) ? GetSpriteFormatXMLRoot(baseLocation: baseLocation, format: format) : root;
			// Create a place to store the colors.
			List<Shapes.Color> availableColorList = SupportFunctions.GetListOfAvailableColorsFromXMLRoot(root: root);
			// Create a place to store the tween objects.
			List<Shapes.Tween> availableTweenList = SupportFunctions.GetListOfAvailableTweensFromXMLRoot(root: root);
			// Create a place to store a list of Quad instances.
			List<Shapes.FrameCall> frameCallsInCompositeFrame = new List<Shapes.FrameCall>();
			if (root != null)
			{
				// Determine which frame to copy the information out from.
				int thisFrame = (copyFromFrame > 0 || parent == null) ? copyFromFrame : (parent.advanceRows * parent.columns) + (parent.advanceColumns + 1);
				XmlNodeList frameList = root.SelectNodes("/format/composite-frames/composite-frame[@id=" + thisFrame + "]/frame");
				foreach (XmlNode node in frameList)
				{
					#region Create a variable to store the final color choice along with 2 tracking variables.
					Color color = Color.White;
					bool frameCallHasColor = false;
					bool tweenHasColor = false;
					#endregion
					#region Get image size or use base-width and base-height from the format to use as the denominator in the pixel-to-percentage texture coordinate calculations.
					XmlNode nodeFormat = root.SelectSingleNode("/format");
					int baseHeight = (nodeFormat.Attributes.GetNamedItem("base-height") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("base-height").Value) : 0;
					int baseWidth = (nodeFormat.Attributes.GetNamedItem("base-width") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("base-width").Value) : 0;
					// The denominators for the texture coordinate calculations.
					double rawW = (parent != null) ? parent.loadedImageDescription.Width : baseWidth;
					double rawH = (parent != null) ? parent.loadedImageDescription.Height : baseHeight;
					#endregion
					#region Get layer options (offset, flip, scale, tween, rotation, blend, frame-in-tween, etc).
					int frameIdToInclude = int.Parse(node.Attributes.GetNamedItem("id").Value);
					//
					string name = (node.Attributes.GetNamedItem("name") != null) ? node.Attributes.GetNamedItem("name").Value : null;
					String namedAttachmentPointId = (node.Attributes.GetNamedItem("named-attachment-point-id") != null) ? node.Attributes.GetNamedItem("named-attachment-point-id").Value : null;
					int layerOffsetX = (node.Attributes.GetNamedItem("offset-x") != null) ? int.Parse(node.Attributes.GetNamedItem("offset-x").Value) : 0;
					int layerOffsetY = (node.Attributes.GetNamedItem("offset-y") != null) ? int.Parse(node.Attributes.GetNamedItem("offset-y").Value) : 0;
					int layerOffsetZ = (node.Attributes.GetNamedItem("offset-z") != null) ? int.Parse(node.Attributes.GetNamedItem("offset-z").Value) : 0;
					double scaleX = (node.Attributes.GetNamedItem("scale-x") != null) ? double.Parse(node.Attributes.GetNamedItem("scale-x").Value) : 1;
					double scaleY = (node.Attributes.GetNamedItem("scale-y") != null) ? double.Parse(node.Attributes.GetNamedItem("scale-y").Value) : 1;
					bool flipX = (node.Attributes.GetNamedItem("flip-x") != null) ? bool.Parse(node.Attributes.GetNamedItem("flip-x").Value) : false;
					string tweenId = (node.Attributes.GetNamedItem("tween") != null) ? node.Attributes.GetNamedItem("tween").Value : "0";
					int frameInTween = (node.Attributes.GetNamedItem("frame-in-tween") != null) ? int.Parse(node.Attributes.GetNamedItem("frame-in-tween").Value) : 0;
					int motionTrailFramesInTween = (node.Attributes.GetNamedItem("motion-trail-frames-in-tween") != null) ? int.Parse(node.Attributes.GetNamedItem("motion-trail-frames-in-tween").Value) : 0;
					string motionTrailType = (node.Attributes.GetNamedItem("motion-trail-type") != null) ? node.Attributes.GetNamedItem("motion-trail-type").Value : "instance";
					double rotationZ = (node.Attributes.GetNamedItem("rotation-z") != null) ? double.Parse(node.Attributes.GetNamedItem("rotation-z").Value) : 0;
					string defaultBlendMode = (node.ParentNode.Attributes.GetNamedItem("blend") != null) ? node.ParentNode.Attributes.GetNamedItem("blend").Value : "overwrite";
					string blendMode = (node.Attributes.GetNamedItem("blend") != null) ? node.Attributes.GetNamedItem("blend").Value : defaultBlendMode;
					int offsetFromTweenX = 0, offsetFromTweenY = 0, offsetFromTweenZ = 0;
					// Try to get the frame call's explicit color.
					string frameCallColorName = (node.Attributes.GetNamedItem("color-name") != null) ? node.Attributes.GetNamedItem("color-name").Value : null;
					if (frameCallColorName != null)
					{
						frameCallHasColor = true;
						Shapes.Color frameCallColor = availableColorList.Find(item => item.name == frameCallColorName);
						if (frameCallColor != null)
							color = frameCallColor.color;
						else
							frameCallHasColor = false;
					}
					// Try to get the frame call's position and color from the tween, overriding the color only if the frame call doesn't have an explicit color.
					if (tweenId != "0")
					{
						Shapes.Tween thisTween = availableTweenList.Find(item => item.id == tweenId);
						if (thisTween != null)
						{
							Shapes.Point offset = thisTween.XYZFromFrame(frameInTween);
							offsetFromTweenX = (int)offset.X;
							offsetFromTweenY = (int)offset.Y;
							offsetFromTweenZ = (int)offset.Z;
							if (thisTween.HasColorComponent)
							{
								tweenHasColor = true;
								if (!frameCallHasColor)
									color = thisTween.colorFromFrame(frameInTween);
							}
						}
					}
					#endregion
					#region Get layer S,T components & suggested color of the frame that's being called (if applicable).
					XmlNode frameToInclude = root.SelectSingleNode("/format/frames/frame[@id=" + frameIdToInclude + "]");
					// Get the width and height of the frame that's being called.
					int addWidth = (frameToInclude != null && frameToInclude.Attributes.GetNamedItem("w") != null) ? int.Parse(frameToInclude.Attributes.GetNamedItem("w").Value) : 1;
					int addHeight = (frameToInclude != null && frameToInclude.Attributes.GetNamedItem("h") != null) ? int.Parse(frameToInclude.Attributes.GetNamedItem("h").Value) : 1;
					// Get (s, t) in the pixel-coordinate system.
					int sInPixels = (frameToInclude != null && frameToInclude.Attributes.GetNamedItem("s") != null) ? int.Parse(frameToInclude.Attributes.GetNamedItem("s").Value) : 0;
					int tInPixels = (frameToInclude != null && frameToInclude.Attributes.GetNamedItem("t") != null) ? int.Parse(frameToInclude.Attributes.GetNamedItem("t").Value) : 0;
					// Calculate the pixel-coordinate system data from the s and width and t and height for (S, T).
					int swInPixels = sInPixels + addWidth;
					int thInPixels = tInPixels + addHeight;
					// Change the pixel-coordinate system data into percentages, flipping the s and S values if the flip-x attribute is on.
					double s = (!flipX) ? sInPixels / rawW : swInPixels / rawW;
					double t = tInPixels / rawH;
					double S = (!flipX) ? swInPixels / rawW : sInPixels / rawW;
					double T = thInPixels / rawH;
					// Try to get the frame call's default color, if the call doesn't have an explicit color on the call or a color from its tween.
					if (frameToInclude != null && !frameCallHasColor && !tweenHasColor)
					{
						string originalColorName = (frameToInclude.Attributes.GetNamedItem("color-name") != null) ? frameToInclude.Attributes.GetNamedItem("color-name").Value : null;
						if (originalColorName != null)
						{
							Shapes.Color originalFrameColor = availableColorList.Find(item => item.name == originalColorName);
							color = (originalFrameColor != null) ? originalFrameColor.color : Color.White;
						}
					}
					#endregion
					// Copy the frame call's description to the list.
					frameCallsInCompositeFrame.Add(
						new Shapes.FrameCall(
							id: frameIdToInclude.ToString(),
							offsetX: layerOffsetX,
							offsetY: layerOffsetY,
							offsetZ: layerOffsetZ,
							flipX: flipX,
							tweenId: tweenId,
							frameInTween: frameInTween,
							blendMode: blendMode,
							scaleX: scaleX,
							scaleY: scaleY,
							colorName: frameCallColorName,
							rotationZ: rotationZ,
							motionTrailType: motionTrailType,
							motionTrailFramesInTween: motionTrailFramesInTween,
							namedAttachmentPointId: namedAttachmentPointId
						)
					);
				}
			}
			return frameCallsInCompositeFrame;
		}

		public static List<Sound> GetListOfAvailableSoundsFromXMLRoot(XmlElement root = null, string baseLocation = "", string format = "")
		{
			// If the XML's root doesn't exist, try to get it.
			root = (root == null) ? GetSpriteFormatXMLRoot(baseLocation: baseLocation, format: format) : root;
			// Create a place to store the colors.
			List<Shapes.Color> availableColorList = SupportFunctions.GetListOfAvailableColorsFromXMLRoot(root: root);
			//
			XmlNodeList soundsList = root.SelectNodes("/format/sounds/sound");
			List<Sound> sounds = new List<Sound>();
			foreach (XmlNode sound in soundsList)
			{
				string name = (sound.Attributes.GetNamedItem("name") != null) ? sound.Attributes.GetNamedItem("name").Value : "0";
				string filename = (sound.Attributes.GetNamedItem("filename") != null) ? sound.Attributes.GetNamedItem("filename").Value : "";
				//
				string colorName = (sound.Attributes.GetNamedItem("color-name") != null) ? sound.Attributes.GetNamedItem("color-name").Value : "";
				Color lineColor = Color.White;
				if (colorName != "")
				{
					Shapes.Color c = availableColorList.Find(item => item.name == colorName);
					if (c != null)
						lineColor = c.color;
				}
				sounds.Add(new Sound(name: name, filename: filename, colorName: colorName, color: lineColor));
			}
			return sounds;
		}

		public static List<Shapes.NamedAttachmentPoint> GetListOfAvailableNamedAttachmentPointsFromXMLRoot(XmlElement root = null,  string baseLocation = "", string format = "")
		{
			// If the XML's root doesn't exist, try to get it.
			root = (root == null) ? GetSpriteFormatXMLRoot(baseLocation: baseLocation, format: format) : root;
			//
			List<Shapes.NamedAttachmentPoint> namedAttachmentPoints = new List<Shapes.NamedAttachmentPoint>();
			XmlNodeList availableNamedAttachmentPoints = root.SelectNodes("/format/named-attachment-points/named-attachment-point");
			foreach (XmlNode attachmentPointToInclude in availableNamedAttachmentPoints)
			{
				// Store the data.
				int id = (attachmentPointToInclude != null && attachmentPointToInclude.Attributes.GetNamedItem("id") != null) ? int.Parse(attachmentPointToInclude.Attributes.GetNamedItem("id").Value) : 1;
				string name = (attachmentPointToInclude != null && attachmentPointToInclude.Attributes.GetNamedItem("name") != null) ? attachmentPointToInclude.Attributes.GetNamedItem("name").Value : "(no name)";
				string description = (attachmentPointToInclude != null && attachmentPointToInclude.Attributes.GetNamedItem("description") != null) ? attachmentPointToInclude.Attributes.GetNamedItem("description").Value : "";
				double x = (attachmentPointToInclude != null && attachmentPointToInclude.Attributes.GetNamedItem("x") != null) ? double.Parse(attachmentPointToInclude.Attributes.GetNamedItem("x").Value) : 0.5;
				double y = (attachmentPointToInclude != null && attachmentPointToInclude.Attributes.GetNamedItem("y") != null) ? double.Parse(attachmentPointToInclude.Attributes.GetNamedItem("y").Value) : 0.5;
				namedAttachmentPoints.Add(new Shapes.NamedAttachmentPoint(id: id, name: name, description: description, x: x, y: y));
			}
			return namedAttachmentPoints;
		}

		public static List<Shapes.CompositeFrameSet> GetListOfAvailableCompositeFrameSetsFromXMLRoot(XmlElement root = null, string baseLocation = "", string format = "", int targetMS = 143)
		{
			// If the XML's root doesn't exist, try to get it.
			root = (root == null) ? GetSpriteFormatXMLRoot(baseLocation: baseLocation, format: format) : root;
			//
			List<Shapes.CompositeFrameSet> compositeFrameSetList = new List<Shapes.CompositeFrameSet>();
			XmlNodeList setList = root.SelectNodes("/format/composite-frame-sets/composite-frame-set");
			foreach (XmlNode setToInclude in setList)
			{
				string name = (setToInclude.Attributes.GetNamedItem("name") != null) ? setToInclude.Attributes.GetNamedItem("name").Value : "0";
				int? thisTargetMS = (setToInclude.Attributes.GetNamedItem("target-ms") != null) ? (int?)int.Parse(setToInclude.Attributes.GetNamedItem("target-ms").Value) : targetMS;
				List<Shapes.CompositeFrameCall> calls = new List<Shapes.CompositeFrameCall>();
				foreach (XmlNode compositeFrameToCall in setToInclude.ChildNodes)
				{
					if (compositeFrameToCall != null)
					{
						string id = (compositeFrameToCall.Attributes.GetNamedItem("id") != null) ? compositeFrameToCall.Attributes.GetNamedItem("id").Value : null;
						string eventName = (compositeFrameToCall.Attributes.GetNamedItem("emit-event") != null) ? compositeFrameToCall.Attributes.GetNamedItem("emit-event").Value : null;
						calls.Add(new Shapes.CompositeFrameCall(id: id, eventName: eventName));
					}
				}
				compositeFrameSetList.Add(new Shapes.CompositeFrameSet(name: name, targetMS: thisTargetMS, compositeFrameCalls: calls));
			}
			return compositeFrameSetList;
		}

		public static void SaveQuadListToCompositeFrameXML(string baseLocation = "", string format = "", int writeThisFrame = 0, List<RenderableFrameCall> loadedFrames = null, List<string> sounds = null)
		{
			// Read in format file (XML).
			XmlDocument doc = SupportFunctions.GetSpriteFormatXMLDocument(baseLocation: baseLocation, format: format);
			XmlElement root = SupportFunctions.GetSpriteFormatXMLRoot(doc);
			// Create a place to store the colors.
			List<Shapes.Color> availableColorList = SupportFunctions.GetListOfAvailableColorsFromXMLRoot(root: root);
			if (root != null)
			{
				// Select "FORMAT" node and get attributes (target, base, frame).
				XmlNode nodeFormat = root.SelectSingleNode("/format");
				// Iterate through each composite frame.
				foreach (XmlNode nodeLevel1 in root.ChildNodes)
				{
					if (nodeLevel1.Name == "composite-frames")
					{
						foreach (XmlNode nodeLevel2 in nodeLevel1.ChildNodes)
							if (nodeLevel2.Name == "composite-frame" && nodeLevel2.Attributes.GetNamedItem("id") != null && int.Parse(nodeLevel2.Attributes.GetNamedItem("id").Value) == writeThisFrame)
								nodeLevel2.ParentNode.RemoveChild(nodeLevel2);
						XmlNode replacement = doc.CreateNode(XmlNodeType.Element, "composite-frame", null);
						XmlAttribute replacementId = doc.CreateAttribute("id");
						replacementId.InnerText = string.Format("{0}", writeThisFrame);
						replacement.Attributes.Append(replacementId);
						// Sound Calls
						if (sounds != null)
						{
							for (int i = 0; i < sounds.Count; i++)
							{
								XmlElement sound = doc.CreateElement("sound");
								XmlAttribute name = doc.CreateAttribute("name");
								name.InnerText = sounds[i];
								sound.Attributes.Append(name);
								replacement.AppendChild(sound);
							}
						}
						// Frame Calls
						for (int i = loadedFrames.Count - 1; i >= 0; i--)
						{
							RenderableFrameCall q = loadedFrames[i];
							XmlNode thisNode = doc.CreateNode(XmlNodeType.Element, "frame", null);
							XmlAttribute thisNodeId, thisNodeOffsetX, thisNodeOffsetY, thisNodeOffsetZ, thisNodeTween, thisNodeFrameInTween, thisNodeMotionTrailType, thisNodeMotionTrailFramesInTween, thisNodeBlend, thisNodeFlipX, thisNodeScaleX, thisNodeScaleY, thisNodeRotationZ, thisNodeColorName, thisNodeName, thisNodeNamedAttachmentPointId;
							if (q.id > 0)
							{
								thisNodeId = doc.CreateAttribute("id");
								thisNodeId.InnerText = string.Format("{0}", q.id);
								thisNode.Attributes.Append(thisNodeId);

								if (q.name != null)
								{
									thisNodeName = doc.CreateAttribute("name");
									thisNodeName.InnerText = string.Format("{0}", q.name);
									thisNode.Attributes.Append(thisNodeName);
								}

								if (q.namedAttachmentPointId != 0)
								{
									thisNodeNamedAttachmentPointId = doc.CreateAttribute("named-attachment-point-id");
									thisNodeNamedAttachmentPointId.InnerText = string.Format("{0}", q.namedAttachmentPointId);
									thisNode.Attributes.Append(thisNodeNamedAttachmentPointId);
								}

								if (q.bound.X - q.offsetFromTweenX != 0)
								{
									thisNodeOffsetX = doc.CreateAttribute("offset-x");
									thisNodeOffsetX.InnerText = string.Format("{0}", (int)(q.bound.X));
									thisNode.Attributes.Append(thisNodeOffsetX);
								}

								if (q.bound.Y - q.offsetFromTweenY != 0)
								{
									thisNodeOffsetY = doc.CreateAttribute("offset-y");
									thisNodeOffsetY.InnerText = string.Format("{0}", (int)(q.bound.Y));
									thisNode.Attributes.Append(thisNodeOffsetY);
								}

								if (q.OffsetZ - q.offsetFromTweenZ != 0)
								{
									thisNodeOffsetZ = doc.CreateAttribute("offset-z");
									thisNodeOffsetZ.InnerText = string.Format("{0}", (int)(q.OffsetZ));
									thisNode.Attributes.Append(thisNodeOffsetZ);
								}

								if (q.tween != "0")
								{
									thisNodeTween = doc.CreateAttribute("tween");
									thisNodeTween.InnerText = string.Format("{0}", q.tween);
									thisNode.Attributes.Append(thisNodeTween);
									//
									if (q.frameInTween != 0)
									{
										thisNodeFrameInTween = doc.CreateAttribute("frame-in-tween");
										thisNodeFrameInTween.InnerText = string.Format("{0}", q.frameInTween);
										thisNode.Attributes.Append(thisNodeFrameInTween);
									}
									//
									if (q.motionTrailType != "instance")
									{
										thisNodeMotionTrailType = doc.CreateAttribute("motion-trail-type");
										thisNodeMotionTrailType.InnerText = string.Format("{0}", q.motionTrailType);
										thisNode.Attributes.Append(thisNodeMotionTrailType);
									}
									//
									if (q.motionTrailFramesInTween != 0)
									{
										thisNodeMotionTrailFramesInTween = doc.CreateAttribute("motion-trail-frames-in-tween");
										thisNodeMotionTrailFramesInTween.InnerText = string.Format("{0}", q.motionTrailFramesInTween);
										thisNode.Attributes.Append(thisNodeMotionTrailFramesInTween);
									}
								}

								if (q.flipX != false)
								{
									thisNodeFlipX = doc.CreateAttribute("flip-x");
									thisNodeFlipX.InnerText = string.Format("{0}", q.flipX);
									thisNode.Attributes.Append(thisNodeFlipX);
								}

								if (q.blendMode != "overwrite")
								{
									thisNodeBlend = doc.CreateAttribute("blend");
									thisNodeBlend.InnerText = string.Format("{0}", q.blendMode);
									thisNode.Attributes.Append(thisNodeBlend);
								}

								if (q.colorName != null && !q.NoColorAtFrameCall)
								{
									Shapes.Color thisColor = availableColorList.Find(item => item.name == q.colorName);
									if (thisColor != null)
									{
										thisNodeColorName = doc.CreateAttribute("color-name");
										thisNodeColorName.InnerText = string.Format("{0}", thisColor.name);
										thisNode.Attributes.Append(thisNodeColorName);
									}
								}

								if (q.scaleX != 1)
								{
									thisNodeScaleX = doc.CreateAttribute("scale-x");
									thisNodeScaleX.InnerText = string.Format("{0}", q.scaleX);
									thisNode.Attributes.Append(thisNodeScaleX);
								}

								if (q.scaleY != 1)
								{
									thisNodeScaleY = doc.CreateAttribute("scale-y");
									thisNodeScaleY.InnerText = string.Format("{0}", q.scaleY);
									thisNode.Attributes.Append(thisNodeScaleY);
								}

								if (q.rotationZ != 0)
								{
									thisNodeRotationZ = doc.CreateAttribute("rotation-z");
									thisNodeRotationZ.InnerText = string.Format("{0}", q.rotationZ);
									thisNode.Attributes.Append(thisNodeRotationZ);
								}

								replacement.AppendChild(thisNode);
							}
						}
						nodeLevel1.AppendChild(replacement);
					}
				}
			}
			// Save the document out, overwriting the existing format.
			SaveSortedXmlDocument(doc, baseLocation, format);
		}

		public static void SaveSortedXmlDocument(XmlDocument doc, string baseLocation, string format)
		{
			string file = baseLocation + @"\formats\" + format + @"\sprite.xml";
			//
			string temporaryFile = Path.GetTempFileName();
			XslCompiledTransform xslt = new XslCompiledTransform();
			xslt.Load(Path.Combine(Path.Combine(baseLocation, "formats"), "SortedFormat.xslt"));
			using (XmlWriter writer = XmlWriter.Create(temporaryFile, xslt.OutputSettings))
			{
				xslt.Transform(doc.CreateNavigator(), null, writer);
			}
			File.Copy(temporaryFile, file, true);
			File.Delete(temporaryFile);
		}

		// Text formatting.
		public static string Ordinal(int number)
		{
			var tens = Math.Floor(number / 10f) % 10;
			if (tens == 1)
				return number + "th";
			switch (number % 10)
			{
				case 1: return number + "st";
				case 2: return number + "nd";
				case 3: return number + "rd";
				default: return number + "th";
			}
		}

		// Swap X/Y as necessary to make a positive domain and range box; used in box select operations.
		public static Rectangle NormalizeBox(ref Point p1, ref Point p2)
		{
			if (p2.X < p1.X)
			{
				p1.X ^= p2.X;
				p2.X ^= p1.X;
				p1.X ^= p2.X;
			}
			if (p2.Y < p1.Y)
			{
				p1.Y ^= p2.Y;
				p2.Y ^= p1.Y;
				p1.Y ^= p2.Y;
			}
			return new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
		}
	}
}