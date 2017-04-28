using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace SpriteAnimator
{
	public partial class AddOrEditFormat : Form
	{
		private Main parent = null;
		private bool fileDialogOpen = false, messageBoxIsOpen = false, addItemIsOpen = false, returnUpdateOnChangeTo = false;
		private object[][] form;

		public AddOrEditFormat(Main m = null, bool editLoaded = false, bool returnUpdateOnChangeTo = false)
		{
			if (m != null)
				this.parent = m;
			this.returnUpdateOnChangeTo = returnUpdateOnChangeTo;
			InitializeComponent();
			form = new object[][] {
				new object[]{null, fileTypeMaskedTextBox},
				new object[]{"name", formatDescriptionMaskedTextBox},
				new object[]{"status", formatStatusMaskedTextBox},
				new object[]{"frame-width", frameWidthMaskedTextBox},
				new object[]{"frame-height", frameHeightMaskedTextBox},
				new object[]{"target-rows", rowCountMaskedTextBox},
				new object[]{"target-columns", columnCountMaskedTextBox},
				new object[]{"target-start", startFrameMaskedTextBox},
				new object[]{"target-end", endFrameMaskedTextBox},
				new object[]{"target-ms", targetMillisecondsMaskedTextBox},
				new object[]{"on-load-zoom", onLoadZoomMaskedTextBox},
				new object[]{"base-width", sourceImageMaskedTextBox},
				new object[]{"base-height", sourceImageMaskedTextBox},
				new object[]{"no-sampling", useNoSamplingCheckBox}
			};
			if (m != null && editLoaded)
			{
				if (Directory.Exists(parent.baseLocation + @"\formats"))
				{
					string fn = parent.baseLocation + @"\formats\" + m.loadedFormat + @"\sprite.xml";
					if (File.Exists(fn))
					{
						System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(fn);
						System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
						doc.Load(reader);
						reader.Close();
						System.Xml.XmlElement root = doc.DocumentElement;
						System.Xml.XmlNode nodeFormat = root.SelectSingleNode("/format");
						fileTypeMaskedTextBox.Text = m.loadedFormat;
						formatDescriptionMaskedTextBox.Text = (nodeFormat.Attributes.GetNamedItem("name") != null) ? nodeFormat.Attributes.GetNamedItem("name").Value : new System.IO.DirectoryInfo(fn).Name;
						formatStatusMaskedTextBox.Text = (nodeFormat.Attributes.GetNamedItem("status") != null) ? nodeFormat.Attributes.GetNamedItem("status").Value : "Work in progress.";
						frameWidthMaskedTextBox.Text = (nodeFormat.Attributes.GetNamedItem("frame-width") != null) ? nodeFormat.Attributes.GetNamedItem("frame-width").Value : "0";
						frameHeightMaskedTextBox.Text = (nodeFormat.Attributes.GetNamedItem("frame-height") != null) ? nodeFormat.Attributes.GetNamedItem("frame-height").Value : "0";
						rowCountMaskedTextBox.Text = (nodeFormat.Attributes.GetNamedItem("target-rows") != null) ? nodeFormat.Attributes.GetNamedItem("target-rows").Value : "1";
						columnCountMaskedTextBox.Text = (nodeFormat.Attributes.GetNamedItem("target-columns") != null) ? nodeFormat.Attributes.GetNamedItem("target-columns").Value : "0";
						startFrameMaskedTextBox.Text = (nodeFormat.Attributes.GetNamedItem("target-start") != null) ? nodeFormat.Attributes.GetNamedItem("target-start").Value : "1";
						endFrameMaskedTextBox.Text = (nodeFormat.Attributes.GetNamedItem("target-end") != null) ? nodeFormat.Attributes.GetNamedItem("target-end").Value : "6";
						targetMillisecondsMaskedTextBox.Text = (nodeFormat.Attributes.GetNamedItem("target-ms") != null) ? nodeFormat.Attributes.GetNamedItem("target-ms").Value : "143";
						onLoadZoomMaskedTextBox.Text = (nodeFormat.Attributes.GetNamedItem("on-load-zoom") != null) ? nodeFormat.Attributes.GetNamedItem("on-load-zoom").Value : "1.00";
						sourceImageMaskedTextBox.Text = m.loadedImageDescription.Filename;
						useNoSamplingCheckBox.Checked = (nodeFormat.Attributes.GetNamedItem("no-sampling") != null) ? bool.Parse(nodeFormat.Attributes.GetNamedItem("no-sampling").Value) : false;
						XmlNodeList availableCompositeFrames = root.SelectNodes("/format/composite-frames/composite-frame");
						List<XmlNode> nodes = new List<XmlNode>();
						foreach (XmlNode frameToInclude in availableCompositeFrames)
						{
							nodes.Add(frameToInclude);
						}
						nodes.Sort(
							(a, b) =>
								  System.Convert.ToInt16(a.Attributes.GetNamedItem("id").Value)
								- System.Convert.ToInt16(b.Attributes.GetNamedItem("id").Value)
						);
						foreach (XmlNode frameToInclude in nodes)
						{
							Shapes.CompositeFrame compositeFrame = new Shapes.CompositeFrame();
							compositeFrame.id = (frameToInclude != null && frameToInclude.Attributes.GetNamedItem("id") != null) ? frameToInclude.Attributes.GetNamedItem("id").Value : "1";
							List<Shapes.FrameCall> frames = new List<Shapes.FrameCall>();
							foreach (XmlNode node in frameToInclude.ChildNodes)
							{
								if (node.Name == "sound")
								{
									compositeFrame.sounds.Add(new Sound(name: (node.Attributes.GetNamedItem("name") != null) ? node.Attributes.GetNamedItem("name").Value : "0"));
								}
								else if (node.Name == "frame")
								{
									Shapes.FrameCall call = new Shapes.FrameCall();
									call.BlendMode = (node.Attributes.GetNamedItem("blend") != null) ? node.Attributes.GetNamedItem("blend").Value : "overwrite";
									call.NamedAttachmentPointId = (node.Attributes.GetNamedItem("named-attachment-point-id") != null) ? node.Attributes.GetNamedItem("named-attachment-point-id").Value : null;
									call.id = node.Attributes.GetNamedItem("id").Value;
									call.OffsetX = (node.Attributes.GetNamedItem("offset-x") != null) ? double.Parse(node.Attributes.GetNamedItem("offset-x").Value) : 0;
									call.OffsetY = (node.Attributes.GetNamedItem("offset-y") != null) ? double.Parse(node.Attributes.GetNamedItem("offset-y").Value) : 0;
									call.OffsetZ = (node.Attributes.GetNamedItem("offset-z") != null) ? double.Parse(node.Attributes.GetNamedItem("offset-z").Value) : 0;
									call.RotationZ = (node.Attributes.GetNamedItem("rotation-z") != null) ? double.Parse(node.Attributes.GetNamedItem("rotation-z").Value) : 0;
									call.ScaleX = (node.Attributes.GetNamedItem("scale-x") != null) ? double.Parse(node.Attributes.GetNamedItem("scale-x").Value) : 1;
									call.ScaleY = (node.Attributes.GetNamedItem("scale-y") != null) ? double.Parse(node.Attributes.GetNamedItem("scale-y").Value) : 1;
									call.FlipX = (node.Attributes.GetNamedItem("flip-x") != null) ? bool.Parse(node.Attributes.GetNamedItem("flip-x").Value) : false;
									call.TweenId = (node.Attributes.GetNamedItem("tween") != null) ? node.Attributes.GetNamedItem("tween").Value : "0";
									call.FrameInTween = (node.Attributes.GetNamedItem("frame-in-tween") != null) ? int.Parse(node.Attributes.GetNamedItem("frame-in-tween").Value) : 0;
									call.MotionTrailFramesInTween = (node.Attributes.GetNamedItem("motion-trail-frames-in-tween") != null) ? int.Parse(node.Attributes.GetNamedItem("motion-trail-frames-in-tween").Value) : 0;
									call.MotionTrailType = (node.Attributes.GetNamedItem("motion-trail-type") != null) ? node.Attributes.GetNamedItem("motion-trail-type").Value : "instance";
									call.ColorName = (node.Attributes.GetNamedItem("color-name") != null) ? node.Attributes.GetNamedItem("color-name").Value : null;
									frames.Add(call);
								}
							}
							compositeFrame.frameCalls = frames;
							ListViewItem lvi = new ListViewItem(new string[]{
								compositeFrame.id, string.Format("{0} frames", compositeFrame.frameCalls.Count)
							}, compositeFramesListView.Groups[0]);
							lvi.Tag = compositeFrame;
							compositeFramesListView.Items.Add(lvi);
						}
						// Frames
						foreach (Shapes.Frame f in parent.Format.AvailableFrameList)
						{
							framesListView.Items.Add(
								new ListViewItem(
									new string[] {
										f.id.ToString(), f.s.ToString(), f.t.ToString(), f.w.ToString(), f.h.ToString()
									}, framesListView.Groups[0]
								)
							);
						}
						// Colors
						foreach (Shapes.Color c in parent.Format.AvailableColorList)
						{
							string thisColor = String.Format("#{0:X2}{1:X2}{2:X2}", c.color.R, c.color.G, c.color.B);
							colorsListBox.Items.Add(
								new ListViewItem(
									new string[] {
										c.name, thisColor, thisColor, String.Format("{0,3:0}%", (c.color.A/255.0)*100.0)
									}, colorsListBox.Groups[0]
								)
							);
						}
						// Guides
						foreach (Shapes.Guide g in parent.Format.Guides)
						{
							if (g.type.ToString() == "Horizontal" || g.type.ToString() == "horizontal")
							{
								guidesListBox.Items.Add(
									new ListViewItem(
										new string[] { "", String.Format("{0}", g.type), g.position.ToString() },
										guidesListBox.Groups[0]
									)
								);
							}
							else
							{
								guidesListBox.Items.Add(
									new ListViewItem(
										new string[] { "", String.Format("{0}", g.type), g.position.ToString() },
										guidesListBox.Groups[1]
									)
								);
							}
						}
						// Tweens
						foreach (Shapes.Tween t in parent.Format.AvailableTweenList)
						{
							int hasLines = (t.LineSegments.Count > 0) ? 1 : 0;
							string framePlurality = (t.FrameLength != 1) ? "frames" : "frame";
							string linePlurality = (t.LineSegments.Count != 1) ? "lines" : "line";
							string colorPlurality = (t.colorList.Count != 1) ? "colors" : "color";
							ListViewItem lvi = new ListViewItem(
								new string[] { "", String.Format("{0}", t.id), String.Format("{0} frames", new object[] { t.FrameLength.ToString(), framePlurality }), String.Format("{0} {1}", new object[] { t.colorList.Count.ToString(), colorPlurality }), String.Format("{0} {1}", new object[] { (hasLines * (t.LineSegments.Count + 1)).ToString(), linePlurality }), t.advancementFunction },
								tweensListBox.Groups[0]
							);
							lvi.Tag = t;
							tweensListBox.Items.Add(lvi);
						}
						// Composite Frame Sets
						foreach (Shapes.CompositeFrameSet cset in parent.Format.CompositeFrameSetList)
						{
							ListViewItem item = new ListViewItem(new string[] { cset.name, cset.FrameCallsForDisplay(), cset.targetMS.ToString() }, compositeFrameSetsListView.Groups[0]);
							item.Tag = cset;
							compositeFrameSetsListView.Items.Add(item);
						}
						// Named Attachment Points
						foreach (Shapes.NamedAttachmentPoint nap in parent.Format.AvailableNamedAttachmentPointsList)
						{
							ListViewItem item = new ListViewItem(new string[] { nap.id.ToString(), nap.name, nap.description }, namedAttachmentPointsListView.Groups[0]);
							item.Tag = nap;
							namedAttachmentPointsListView.Items.Add(item);
						}
						// Sounds
						foreach (Sound s in parent.Format.AvailableSounds)
						{
							ListViewItem lvi = new ListViewItem(
								new string[] { s.name, Path.GetFileName(s.filename), s.colorName }
							);
							soundsListView.Items.Add(lvi);
						}
					}
				}
				// Auto-hide areas that don't have anything to show (in a loaded format).
				if (colorsListBox.Items.Count == 0 && guidesListBox.Items.Count == 0)
					lowerTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
				if (tweensListBox.Items.Count == 0)
					lowerTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
				if (framesListView.Items.Count == 0 && compositeFramesListView.Items.Count == 0)
					lowerTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Absolute, 0F);
				if (compositeFrameSetsListView.Items.Count == 0)
					lowerTableLayoutPanel.RowStyles[7] = new RowStyle(SizeType.Absolute, 0F);
				if (soundsListView.Items.Count == 0)
					lowerTableLayoutPanel.RowStyles[9] = new RowStyle(SizeType.Absolute, 0F);
			}
			this.fileTypeLabel.Select();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			if (parent != null)
				parent.autoUpdateOnFormatChange.Checked = returnUpdateOnChangeTo;
			this.Close();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			validationErrorsToolTip.RemoveAll();
			bool somethingIsInvalid = false;
			//Validate
			for (int i = 0; i < form.Length; i++)
			{
				object obj = form[i][1];
				if (obj.GetType() == Type.GetType("SpriteAnimator.MaskedTextBox"))
				{
					bool thisResult = ((SpriteAnimator.MaskedTextBox)obj).validate();
					if (thisResult)
					{
						if (!((SpriteAnimator.MaskedTextBox)obj).AllowBlank && ((SpriteAnimator.MaskedTextBox)obj).Text.Trim(' ', '.') == "")
							validationErrorsToolTip.SetToolTip((Control)obj, "This field cannot be blank.");
						else if (!((SpriteAnimator.MaskedTextBox)obj).MaskCompleted && ((SpriteAnimator.MaskedTextBox)obj).IsNumeric)
							validationErrorsToolTip.SetToolTip((Control)obj, "This field must be a number between " + ((SpriteAnimator.MaskedTextBox)obj).Floor + " - " + ((SpriteAnimator.MaskedTextBox)obj).Ceiling + ".");
						else if (!((SpriteAnimator.MaskedTextBox)obj).MaskCompleted)
							validationErrorsToolTip.SetToolTip((Control)obj, "This field must be in the format: " + ((SpriteAnimator.MaskedTextBox)obj).Mask.ToString() + ".");
					}
					somethingIsInvalid = (thisResult || somethingIsInvalid) ? true : false;
				}
			}
			//Close
			messageBoxIsOpen = true;
			if (!somethingIsInvalid)
			{
				bool keepGoing = true;
				if (File.Exists(parent.baseLocation + @"\formats\" + fileTypeMaskedTextBox.Text + @"\sprite.xml") && fileTypeMaskedTextBox.Text != parent.loadedFormat)
				{
					DialogResult dr = new DialogResult();
					dr = MessageBox.Show(this, "Overwrite existing file?", "File Exists", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
					if (dr == DialogResult.OK)
					{
						messageBoxIsOpen = false;
					}
					else if (dr == DialogResult.Cancel)
					{
						// Prevent writing file.
						keepGoing = false;
						fileTypeMaskedTextBox.MarkInvalid = true;
						messageBoxIsOpen = false;
					}
				}
				// Write file out and be done with it.
				if (keepGoing)
					createOrUpdateFile();
			}
		}

		private void createOrUpdateFile()
		{
			if (!File.Exists(parent.baseLocation + @"\formats\" + fileTypeMaskedTextBox.Text + @"\sprite.xml"))
			{
				System.IO.Directory.CreateDirectory(parent.baseLocation + @"\formats\" + fileTypeMaskedTextBox.Text);
				using (FileStream fs = File.Create(parent.baseLocation + @"\formats\" + fileTypeMaskedTextBox.Text + @"\sprite.xml")) { };
			}
			//
			XmlTextReader reader = new XmlTextReader(parent.baseLocation + @"\formats\" + fileTypeMaskedTextBox.Text + @"\sprite.xml");
			XmlDocument doc = new XmlDocument();
			XmlElement root;
			try
			{
				doc.Load(reader);
				root = doc.DocumentElement;
			}
			catch (Exception)
			{
				XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
				doc.AppendChild(dec); // Create the root element
				root = doc.CreateElement("format");
			}
			reader.Close();
			// Delete and recreate attributes on the frame object.
			for (int i = 0; i < form.Length; i++)
			{
				object obj = form[i][1];
				if (form[i][0] != null)
				{
					XmlAttribute attribute;
					String attributeName = form[i][0].ToString();
					if (root.Attributes.GetNamedItem(attributeName) != null)
						root.Attributes.RemoveNamedItem(attributeName);
					attribute = doc.CreateAttribute(attributeName);
					if (obj.GetType() == Type.GetType("SpriteAnimator.MaskedTextBox"))
					{
						
						String text = null;
						// Handle empty mask text (ex: "  . ")
						if (attributeName == "on-load-zoom")
						{
							// Set default zoom.
							double zoom = 1.00;
							text = ((SpriteAnimator.MaskedTextBox)obj).Text.Trim();
							// Attempt to parse actual value (which may be empty mask text).
							if (text != ".")
								Double.TryParse(text, out zoom);
							// Don't write anything out that exceeds the mask or reaches 0.
							zoom = Math.Max(0.01, Math.Min(9.99, zoom));
							// Replace the data on the form object.
							text = string.Format("{0:0.00}", zoom);
						}
						// Get base width, which is necessary for outside programming.
						else if (attributeName == "base-width")
						{
							if (File.Exists(sourceImageMaskedTextBox.Text))
								using (Bitmap b = new Bitmap(sourceImageMaskedTextBox.Text))
									text = b.Width.ToString();
						}
						// Get base height, which is necessary for outside programming.
						else if (attributeName == "base-height")
						{
							if (File.Exists(sourceImageMaskedTextBox.Text))
								using (Bitmap b = new Bitmap(sourceImageMaskedTextBox.Text))
									text = b.Height.ToString();
						}
						// If control has an attribute name, attempt to store the value of the control.
						else if (attributeName != null)
							text = ((SpriteAnimator.MaskedTextBox)obj).Text;
						// Set the attribute.
						attribute.InnerText = text;
					}
					else if (obj.GetType().ToString() == "System.Windows.Forms.CheckBox")
						attribute.InnerText = ((System.Windows.Forms.CheckBox)obj).Checked ? "true" : "false";
					// Attach the attribute, if there is something to attach.
					if (attribute.InnerText != null && attribute.InnerText != "")
						root.Attributes.Append(attribute);
					else
						root.Attributes.Remove(attribute);
				}
			}

			bool rootWasEmpty = false;
			if (root.IsEmpty)
				rootWasEmpty = true;

			// Frames.
			XmlElement frames;
			XmlNode f = root.SelectSingleNode("/format/frames");
			bool needToAddBaseElement = true;
			if (f != null)
			{
				needToAddBaseElement = false;
				frames = f as XmlElement;
				frames.RemoveAll();
			}
			else
				frames = doc.CreateElement("frames");
			//
			foreach (ListViewItem saveFrame in framesListView.Items)
			{
				XmlElement frame = doc.CreateElement("frame");
				XmlAttribute id = doc.CreateAttribute("id"), s = doc.CreateAttribute("s"), t = doc.CreateAttribute("t"), w = doc.CreateAttribute("w"), h = doc.CreateAttribute("h");
				id.InnerText = saveFrame.SubItems[0].Text;
				s.InnerText = saveFrame.SubItems[1].Text;
				t.InnerText = saveFrame.SubItems[2].Text;
				w.InnerText = saveFrame.SubItems[3].Text;
				h.InnerText = saveFrame.SubItems[4].Text;
				frame.Attributes.Append(id);
				frame.Attributes.Append(s);
				frame.Attributes.Append(t);
				frame.Attributes.Append(w);
				frame.Attributes.Append(h);
				frames.AppendChild(frame);
			}
			if (needToAddBaseElement)
				root.AppendChild(frames);

			// Composite Frames.
			XmlElement compositeFrames;
			XmlNode cf = root.SelectSingleNode("/format/composite-frames");
			needToAddBaseElement = true;
			if (cf != null)
			{
				needToAddBaseElement = false;
				compositeFrames = cf as XmlElement;
				cf.RemoveAll();
			}
			else
			{
				compositeFrames = doc.CreateElement("composite-frames");
			}
			//
			foreach (ListViewItem saveFrame in compositeFramesListView.Items)
			{
				Shapes.CompositeFrame c = saveFrame.Tag as Shapes.CompositeFrame;
				XmlElement frame = doc.CreateElement("composite-frame");
				XmlAttribute cid = doc.CreateAttribute("id");
				cid.InnerText = saveFrame.SubItems[0].Text;
				frame.Attributes.Append(cid);
				foreach (Sound cs in c.sounds)
				{
					XmlElement soundCall = doc.CreateElement("frame");
					XmlAttribute name = doc.CreateAttribute("name");
					name.InnerText = cs.name;
					soundCall.Attributes.Append(name);
					compositeFrames.AppendChild(soundCall);
				}
				foreach (Shapes.FrameCall fc in c.frameCalls)
				{
					XmlElement frameCall = doc.CreateElement("frame");
					XmlAttribute
						id = doc.CreateAttribute("id"),
						namedAttachmentPointId = doc.CreateAttribute("named-attachment-point-id"),
						blendMode = doc.CreateAttribute("blend"),
						colorName = doc.CreateAttribute("color-name"),
						flipX = doc.CreateAttribute("flip-x"),
						tween = doc.CreateAttribute("tween"),
						frameInTween = doc.CreateAttribute("frame-in-tween"),
						motionTrailType = doc.CreateAttribute("motion-trail-type"),
						motionTrailFramesInTween = doc.CreateAttribute("motion-trail-frames-in-tween"),
						offsetX = doc.CreateAttribute("offset-x"),
						offsetY = doc.CreateAttribute("offset-y"),
						offsetZ = doc.CreateAttribute("offset-z"),
						scaleX = doc.CreateAttribute("scale-x"),
						scaleY = doc.CreateAttribute("scale-y"),
						rotationZ = doc.CreateAttribute("rotation-z");
					// Set the data on the attribute items of the frame calls.
					id.InnerText = fc.id;
					namedAttachmentPointId.InnerText = fc.NamedAttachmentPointId ?? "";
					blendMode.InnerText = fc.BlendMode;
					colorName.InnerText = fc.ColorName;
					flipX.InnerText = fc.FlipX.ToString();
					frameInTween.InnerText = fc.FrameInTween.ToString();
					motionTrailFramesInTween.InnerText = fc.MotionTrailFramesInTween.ToString();
					motionTrailType.InnerText = fc.MotionTrailType;
					offsetX.InnerText = fc.OffsetX.ToString();
					offsetY.InnerText = fc.OffsetY.ToString();
					offsetZ.InnerText = fc.OffsetZ.ToString();
					rotationZ.InnerText = fc.RotationZ.ToString();
					scaleX.InnerText = fc.ScaleX.ToString();
					scaleY.InnerText = fc.ScaleY.ToString();
					tween.InnerText = fc.TweenId.ToString();
					// Append the non-default items.
					frameCall.Attributes.Append(id);
					if (fc.NamedAttachmentPointId != null && fc.NamedAttachmentPointId != "0")
						frameCall.Attributes.Append(namedAttachmentPointId);
					if (fc.BlendMode != "overwrite")
						frameCall.Attributes.Append(blendMode);
					if (fc.ColorName != null && fc.ColorName.Trim() != "")
						frameCall.Attributes.Append(colorName);
					if (fc.FlipX != false)
						frameCall.Attributes.Append(flipX);
					if (fc.TweenId != "0")
						frameCall.Attributes.Append(tween);
					if (fc.FrameInTween != 0)
						frameCall.Attributes.Append(frameInTween);
					if (fc.MotionTrailFramesInTween != 0)
						frameCall.Attributes.Append(motionTrailFramesInTween);
					if (fc.MotionTrailType != "instance" && fc.MotionTrailType != "")
						frameCall.Attributes.Append(motionTrailType);
					if (fc.OffsetX != 0)
						frameCall.Attributes.Append(offsetX);
					if (fc.OffsetY != 0)
						frameCall.Attributes.Append(offsetY);
					if (fc.OffsetZ != 0)
						frameCall.Attributes.Append(offsetZ);
					if (fc.RotationZ != 0)
						frameCall.Attributes.Append(rotationZ);
					if (fc.ScaleX != 1)
						frameCall.Attributes.Append(scaleX);
					if (fc.ScaleY != 1)
						frameCall.Attributes.Append(scaleY);
					frame.AppendChild(frameCall);
				}
				compositeFrames.AppendChild(frame);
			}
			if (needToAddBaseElement)
				root.AppendChild(compositeFrames);

			// Guides
			XmlElement guides;
			XmlNode gu = root.SelectSingleNode("/format/guides");
			if (gu != null)
			{
				guides = gu as XmlElement;
				guides.RemoveAll();
				foreach (ListViewItem item in guidesListBox.Items)
				{
					XmlElement guide = doc.CreateElement("guide");
					XmlAttribute type = doc.CreateAttribute("type"), value = doc.CreateAttribute("value");
					type.InnerText = item.SubItems[1].Text.ToLower();
					value.InnerText = item.SubItems[2].Text;
					guide.Attributes.Append(type);
					guide.Attributes.Append(value);
					guides.AppendChild(guide);
				}
			}
			else
			{
				guides = doc.CreateElement("guides");
				foreach (ListViewItem item in guidesListBox.Items)
				{
					XmlElement guide = doc.CreateElement("guide");
					XmlAttribute type = doc.CreateAttribute("type"), value = doc.CreateAttribute("value");
					type.InnerText = item.SubItems[1].Text.ToLower();
					value.InnerText = item.SubItems[2].Text;
					guide.Attributes.Append(type);
					guide.Attributes.Append(value);
					guides.AppendChild(guide);
				}
				root.AppendChild(guides);
			}

			// Colors
			XmlElement colors;
			XmlNode co = root.SelectSingleNode("/format/colors");
			if (co != null)
			{
				colors = co as XmlElement;
				colors.RemoveAll();
				foreach (ListViewItem item in colorsListBox.Items)
				{
					XmlElement element = doc.CreateElement("color");
					XmlAttribute name = doc.CreateAttribute("name"), r = doc.CreateAttribute("r"), g = doc.CreateAttribute("g"), b = doc.CreateAttribute("b"), a = doc.CreateAttribute("a");
					string color = item.SubItems[2].Text;
					string R = color.Substring(1, 2), G = color.Substring(3, 2), B = color.Substring(5, 2);
					Color c = Color.FromArgb(Int32.Parse(R, System.Globalization.NumberStyles.HexNumber), Int32.Parse(G, System.Globalization.NumberStyles.HexNumber), Int32.Parse(B, System.Globalization.NumberStyles.HexNumber));
					name.InnerText = item.SubItems[0].Text;
					r.InnerText = (c.R / 255.0).ToString();
					g.InnerText = (c.G / 255.0).ToString();
					b.InnerText = (c.B / 255.0).ToString();
					a.InnerText = (int.Parse(item.SubItems[3].Text.Substring(0, item.SubItems[3].Text.Length - 1)) / 100.0).ToString();
					element.Attributes.Append(name);
					element.Attributes.Append(r);
					element.Attributes.Append(g);
					element.Attributes.Append(b);
					element.Attributes.Append(a);
					colors.AppendChild(element);
				}
			}
			else
			{
				colors = doc.CreateElement("colors");
				foreach (ListViewItem item in colorsListBox.Items)
				{
					XmlElement element = doc.CreateElement("color");
					XmlAttribute name = doc.CreateAttribute("name"), r = doc.CreateAttribute("r"), g = doc.CreateAttribute("g"), b = doc.CreateAttribute("b"), a = doc.CreateAttribute("a");
					string color = item.SubItems[2].Text;
					string R = color.Substring(1, 2), G = color.Substring(3, 2), B = color.Substring(5, 2);
					Color c = Color.FromArgb(Int32.Parse(R, System.Globalization.NumberStyles.HexNumber), Int32.Parse(G, System.Globalization.NumberStyles.HexNumber), Int32.Parse(B, System.Globalization.NumberStyles.HexNumber));
					name.InnerText = item.SubItems[0].Text;
					r.InnerText = (c.R / 255.0).ToString();
					g.InnerText = (c.G / 255.0).ToString();
					b.InnerText = (c.B / 255.0).ToString();
					a.InnerText = (int.Parse(item.SubItems[3].Text.Substring(0, item.SubItems[3].Text.Length - 1)) / 100.0).ToString();
					element.Attributes.Append(name);
					element.Attributes.Append(r);
					element.Attributes.Append(g);
					element.Attributes.Append(b);
					element.Attributes.Append(a);
					colors.AppendChild(element);
				}
				root.AppendChild(colors);
			}

			// Motion-Tweens
			XmlElement motionTweens;
			XmlNode mt = root.SelectSingleNode("/format/motion-tweens");
			if (mt != null)
			{
				motionTweens = mt as XmlElement;
				motionTweens.RemoveAll();
				foreach (ListViewItem item in tweensListBox.Items)
				{
					XmlElement tween = doc.CreateElement("motion-tween");
					XmlAttribute id = doc.CreateAttribute("id"), length = doc.CreateAttribute("length-in-frames"), advance = doc.CreateAttribute("advancement-function");
					Shapes.Tween thisTween = item.Tag as Shapes.Tween;
					id.InnerText = thisTween.id;
					length.InnerText = thisTween.FrameLength.ToString();
					advance.InnerText = thisTween.advancementFunction;
					tween.Attributes.Append(id);
					tween.Attributes.Append(length);
					tween.Attributes.Append(advance);
					for (int i = 0; i < thisTween.colorList.Count; i++)
					{
						XmlElement colorState = doc.CreateElement("color-state");
						XmlAttribute name = doc.CreateAttribute("name");
						name.InnerText = thisTween.colorNames[i];
						colorState.Attributes.Append(name);
						tween.AppendChild(colorState);
					}
					if (thisTween.LineSegments.Count > 0)
					{
						List<Shapes.Point> points = thisTween.getPoints();
						foreach (Shapes.Point p in points)
						{
							XmlElement point = doc.CreateElement("point");
							XmlAttribute xPos = doc.CreateAttribute("x"), yPos = doc.CreateAttribute("y"), zPos = doc.CreateAttribute("z");
							xPos.InnerText = p.X.ToString();
							yPos.InnerText = p.Y.ToString();
							zPos.InnerText = p.Z.ToString();
							point.Attributes.Append(xPos);
							point.Attributes.Append(yPos);
							point.Attributes.Append(zPos);
							tween.AppendChild(point);
						}
					}
					motionTweens.AppendChild(tween);
				}
			}
			else
			{
				motionTweens = doc.CreateElement("motion-tweens");
				foreach (ListViewItem item in tweensListBox.Items)
				{
					XmlElement tween = doc.CreateElement("motion-tween");
					XmlAttribute id = doc.CreateAttribute("id"), length = doc.CreateAttribute("length-in-frames");
					Shapes.Tween thisTween = item.Tag as Shapes.Tween;
					id.InnerText = item.SubItems[1].Text;
					length.InnerText = thisTween.FrameLength.ToString();
					tween.Attributes.Append(id);
					tween.Attributes.Append(length);
					for (int i = 0; i < thisTween.colorList.Count; i++)
					{
						XmlElement colorState = doc.CreateElement("color-state");
						XmlAttribute name = doc.CreateAttribute("name");
						name.InnerText = thisTween.colorNames[i];
						colorState.Attributes.Append(name);
						tween.AppendChild(colorState);
					}
					if (thisTween.LineSegments.Count > 0)
					{
						List<Shapes.Line> lines = thisTween.LineSegments;
						lines.Insert(0, new Shapes.Line(thisTween.LineSegments[0].Start, thisTween.LineSegments[0].Start));
						for (int i = 0; i < lines.Count; i++)
						{
							XmlElement point = doc.CreateElement("point");
							XmlAttribute xPos = doc.CreateAttribute("x"), yPos = doc.CreateAttribute("y");
							xPos.InnerText = thisTween.LineSegments[i].End.X.ToString();
							yPos.InnerText = thisTween.LineSegments[i].End.Y.ToString();
							point.Attributes.Append(xPos);
							point.Attributes.Append(yPos);
							tween.AppendChild(point);
						}
					}
					motionTweens.AppendChild(tween);
				}
				root.AppendChild(motionTweens);
			}

			// Composite Frame Sets
			XmlElement setList;
			XmlNode sets = root.SelectSingleNode("/format/composite-frame-sets");
			if (sets != null)
			{
				setList = sets as XmlElement;
				setList.RemoveAll();
				foreach (ListViewItem item in compositeFrameSetsListView.Items)
				{
					XmlElement set = doc.CreateElement("composite-frame-set");
					XmlAttribute name = doc.CreateAttribute("name"), targetMS = doc.CreateAttribute("target-ms");
					Shapes.CompositeFrameSet thisSet = item.Tag as Shapes.CompositeFrameSet;
					name.InnerText = thisSet.name;
					targetMS.InnerText = thisSet.targetMS.ToString();
					set.Attributes.Append(name);
					if (thisSet.targetMS != null && targetMS.InnerText != targetMillisecondsMaskedTextBox.Text)
						set.Attributes.Append(targetMS);
					foreach (Shapes.CompositeFrameCall call in thisSet.compositeFrameCalls)
					{
						XmlElement frame = doc.CreateElement("frame");
						XmlAttribute id = doc.CreateAttribute("id"), emitEvent = doc.CreateAttribute("emit-event");
						id.InnerText = call.id;
						emitEvent.InnerText = call.eventName;
						//
						frame.Attributes.Append(id);
						if (call.eventName != null)
							frame.Attributes.Append(emitEvent);
						//
						set.AppendChild(frame);
					}
					setList.AppendChild(set);
				}
			}
			else
			{
				setList = doc.CreateElement("composite-frame-sets");
				foreach (ListViewItem item in compositeFrameSetsListView.Items)
				{
					XmlElement set = doc.CreateElement("composite-frame-set");
					XmlAttribute name = doc.CreateAttribute("name");
					name.InnerText = item.SubItems[0].Text;
					set.Attributes.Append(name);
					foreach (string s in System.Text.RegularExpressions.Regex.Split(item.SubItems[1].Text, ", "))
					{
						XmlElement frame = doc.CreateElement("frame");
						XmlAttribute id = doc.CreateAttribute("id");
						id.InnerText = s;
						frame.Attributes.Append(id);
						set.AppendChild(frame);
					}
					setList.AppendChild(set);
				}
				root.AppendChild(setList);
			}

			// Named Attachment Points
			XmlElement namedAttachmentPoints;
			XmlNode naps = root.SelectSingleNode("/format/named-attachment-points");
			if (naps != null)
			{
				namedAttachmentPoints = naps as XmlElement;
				namedAttachmentPoints.RemoveAll();
				foreach (ListViewItem item in namedAttachmentPointsListView.Items)
				{
					XmlElement namedAttachmentPoint = doc.CreateElement("named-attachment-point");
					XmlAttribute id = doc.CreateAttribute("id"), name = doc.CreateAttribute("name"), description = doc.CreateAttribute("description"), x = doc.CreateAttribute("x"), y = doc.CreateAttribute("y");
					Shapes.NamedAttachmentPoint nap = item.Tag as Shapes.NamedAttachmentPoint;
					id.InnerText = nap.id.ToString();
					name.InnerText = nap.name;
					description.InnerText = nap.description;
					x.InnerText = nap.x.ToString();
					y.InnerText = nap.y.ToString();
					//
					namedAttachmentPoint.Attributes.Append(id);
					namedAttachmentPoint.Attributes.Append(name);
					namedAttachmentPoint.Attributes.Append(description);
					if (nap.x != 0.5)
						namedAttachmentPoint.Attributes.Append(x);
					if (nap.y != 0.5)
						namedAttachmentPoint.Attributes.Append(y);
					//
					namedAttachmentPoints.AppendChild(namedAttachmentPoint);
				}
			}
			else
			{
				namedAttachmentPoints = doc.CreateElement("named-attachment-points");
				foreach (ListViewItem item in namedAttachmentPointsListView.Items)
				{
					XmlElement namedAttachmentPoint = doc.CreateElement("named-attachment-point");
					XmlAttribute id = doc.CreateAttribute("id"), name = doc.CreateAttribute("name"), description = doc.CreateAttribute("description"), x = doc.CreateAttribute("x"), y = doc.CreateAttribute("y");
					Shapes.NamedAttachmentPoint nap = item.Tag as Shapes.NamedAttachmentPoint;
					id.InnerText = nap.id.ToString();
					name.InnerText = nap.name;
					description.InnerText = nap.description;
					x.InnerText = nap.x.ToString();
					y.InnerText = nap.y.ToString();
					//
					namedAttachmentPoint.Attributes.Append(id);
					namedAttachmentPoint.Attributes.Append(name);
					namedAttachmentPoint.Attributes.Append(description);
					if (nap.x != 0.5)
						namedAttachmentPoint.Attributes.Append(x);
					if (nap.y != 0.5)
						namedAttachmentPoint.Attributes.Append(y);
					//
					namedAttachmentPoints.AppendChild(namedAttachmentPoint);
				}
				root.AppendChild(namedAttachmentPoints);
			}

			// Sounds
			XmlElement sounds;
			XmlNode soundsList = root.SelectSingleNode("/format/sounds");
			if (soundsList != null)
			{
				sounds = soundsList as XmlElement;
				sounds.RemoveAll();
				foreach (ListViewItem item in soundsListView.Items)
				{
					XmlElement sound = doc.CreateElement("sound");
					XmlAttribute name = doc.CreateAttribute("name"), filename = doc.CreateAttribute("filename"), colorName = doc.CreateAttribute("color-name");
					name.InnerText = item.SubItems[0].Text;
					filename.InnerText = item.SubItems[1].Text;
					colorName.InnerText = item.SubItems[2].Text;
					sound.Attributes.Append(name);
					sound.Attributes.Append(filename);
					sound.Attributes.Append(colorName);
					sounds.AppendChild(sound);
				}
			}
			else
			{
				sounds = doc.CreateElement("sounds");
				foreach (ListViewItem item in soundsListView.Items)
				{
					XmlElement sound = doc.CreateElement("sound");
					XmlAttribute name = doc.CreateAttribute("name"), filename = doc.CreateAttribute("filename"), colorName = doc.CreateAttribute("color-name");
					name.InnerText = item.SubItems[0].Text;
					filename.InnerText = item.SubItems[1].Text;
					colorName.InnerText = item.SubItems[2].Text;
					sound.Attributes.Append(name);
					sound.Attributes.Append(filename);
					sound.Attributes.Append(colorName);
					sounds.AppendChild(sound);
				}
				root.AppendChild(sounds);
			}

			if (rootWasEmpty)
				doc.AppendChild(root);

			// Save the document out, overwriting the existing format.
			SupportFunctions.SaveSortedXmlDocument(doc, this.parent.baseLocation, fileTypeMaskedTextBox.Text);
		}

		private void browseForReferenceImageButton_Click(object sender, EventArgs e)
		{
			fileDialogOpen = true;
			DialogResult d = openFileDialog.ShowDialog(this);
			if (d == DialogResult.OK)
			{
				sourceImageMaskedTextBox.Text = openFileDialog.FileName;
				fileDialogOpen = false;
			}
			else
			{
				fileDialogOpen = false;
			}
		}

		private void NewFormat_Deactivate(object sender, EventArgs e)
		{
			if (!fileDialogOpen && !messageBoxIsOpen && !addItemIsOpen)
			{
				if (this.parent != null)
				{
					this.parent.Show();
					this.parent.BringToFront();
					this.parent.Activate();
				}
				this.BringToFront();
				this.Activate();
			}
		}

		#region List View Owner-Draw Events.
		private bool Resizing = false;
		private void ListBox1_SizeChanged(object sender, EventArgs e)
		{
			if (!Resizing)
			{
				Resizing = true;
				ListView listView = sender as ListView;
				if (listView != null)
				{
					float totalColumnWidth = 5;
					for (int i = 0; i < listView.Columns.Count; i++)
						totalColumnWidth += Convert.ToInt32(listView.Columns[i].Width);
					for (int i = 0; i < listView.Columns.Count; i++)
					{
						float colPercentage = 0;
						if (i == 0)
							colPercentage = (Convert.ToInt32(listView.Columns[i].Width) + Convert.ToInt32(listView.Columns[i + 1].Width) - 25) / totalColumnWidth;
						else if (i == 1)
							colPercentage = 25 / totalColumnWidth;
						else
							colPercentage = (Convert.ToInt32(listView.Columns[i].Width) / totalColumnWidth);
						listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
					}
				}
			}
			Resizing = false;
		}

		private bool ResizingGeneric = false;
		private void ListView_SizeChanged(object sender, EventArgs e)
		{
			if (!ResizingGeneric)
			{
				ResizingGeneric = true;
				ListView listView = sender as ListView;
				if (listView != null)
				{
					float totalColumnWidth = 5;
					for (int i = 0; i < listView.Columns.Count; i++)
						totalColumnWidth += Convert.ToInt32(listView.Columns[i].Width);
					for (int i = 0; i < listView.Columns.Count; i++)
						listView.Columns[i].Width = (int)((Convert.ToInt32(listView.Columns[i].Width) / totalColumnWidth) * listView.ClientRectangle.Width);
				}
			}
			ResizingGeneric = false;
		}

		private void listBox1_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			if ((e.State & ListViewItemStates.Selected) != 0)
			{
				e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
				e.DrawFocusRectangle();
			}
			else
				e.Graphics.FillRectangle(Brushes.White, e.Bounds);

			if (colorsListBox.View != View.Details)
				e.DrawText();
		}

		private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}

		private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			TextFormatFlags flags = TextFormatFlags.Left;
			using (StringFormat sf = new StringFormat())
			{
				switch (e.Header.TextAlign)
				{
					case HorizontalAlignment.Center:
						sf.Alignment = StringAlignment.Center;
						flags = TextFormatFlags.HorizontalCenter;
						break;
					case HorizontalAlignment.Right:
						sf.Alignment = StringAlignment.Far;
						flags = TextFormatFlags.Right;
						break;
				}

				if (e.ColumnIndex == 1)
				{
					string color = e.SubItem.Text;
					string R = color.Substring(1, 2), G = color.Substring(3, 2), B = color.Substring(5, 2);
					Brush b = new SolidBrush(Color.FromArgb(Int32.Parse(R, System.Globalization.NumberStyles.HexNumber), Int32.Parse(G, System.Globalization.NumberStyles.HexNumber), Int32.Parse(B, System.Globalization.NumberStyles.HexNumber)));
					Brush highlight =
						new SolidBrush(
							Color.FromArgb(
								(int)(Int32.Parse(R, System.Globalization.NumberStyles.HexNumber) * .5 + SystemColors.Highlight.R * .5),
								(int)(Int32.Parse(G, System.Globalization.NumberStyles.HexNumber) * .5 + SystemColors.Highlight.G * .5),
								(int)(Int32.Parse(B, System.Globalization.NumberStyles.HexNumber) * .5 + SystemColors.Highlight.B * .5)
							)
						);
					if ((e.ItemState & ListViewItemStates.Selected) == 0)
						e.Graphics.FillRectangle(b, e.Bounds);
					else
						e.Graphics.FillRectangle(highlight, e.Bounds);
					return;
				}
				if ((e.ItemState & ListViewItemStates.Selected) == 0)
					e.DrawText(flags);
				else
				{
					if (e.ColumnIndex > 0)
						e.Graphics.DrawString(e.SubItem.Text, colorsListBox.Font, SystemBrushes.HighlightText, e.Bounds, sf);
					else
					{
						Rectangle r = e.Bounds;
						r.Offset(12, 0);
						e.Graphics.DrawString(e.SubItem.Text, colorsListBox.Font, SystemBrushes.HighlightText, r, sf);
					}
				}
			}
		}

		private void listView1_MouseMove(object sender, MouseEventArgs e)
		{
			ListViewItem item = colorsListBox.GetItemAt(e.X, e.Y);
			if (item != null && item.Tag == null)
			{
				colorsListBox.Invalidate(item.Bounds);
				item.Tag = "tagged";
			}
		}

		void listView1_Invalidated(object sender, InvalidateEventArgs e)
		{
			foreach (ListViewItem item in colorsListBox.Items)
			{
				if (item == null) return;
				item.Tag = null;
			}
		}
		#endregion

		private void addColorContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			if (colorsListBox.SelectedIndices.Count > 0)
			{
				editColorToolStripMenuItem.Enabled = true;
				removeColorToolStripMenuItem.Enabled = true;
			}
			else
			{
				editColorToolStripMenuItem.Enabled = false;
				removeColorToolStripMenuItem.Enabled = false;
			}
		}

		private void guideContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			if (guidesListBox.SelectedIndices.Count > 0)
			{
				editGuideToolStripMenuItem.Enabled = true;
				removeGuideToolStripMenuItem.Enabled = true;
			}
			else
			{
				editGuideToolStripMenuItem.Enabled = false;
				removeGuideToolStripMenuItem.Enabled = false;
			}
		}

		private void tweenContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			if (tweensListBox.SelectedIndices.Count > 0)
			{
				editTweenToolStripMenuItem.Enabled = true;
				removeTweenToolStripMenuItem.Enabled = true;
			}
			else
			{
				editTweenToolStripMenuItem.Enabled = false;
				removeTweenToolStripMenuItem.Enabled = false;
			}
		}

		private void addColorContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem.Text == "Add New Color")
			{
				addItemIsOpen = true;
				AddOrEditColor addOrEditColor = new AddOrEditColor();
				DialogResult dr = addOrEditColor.ShowDialog(this);
				if (dr == DialogResult.OK || dr == DialogResult.Cancel)
				{
					if (dr == DialogResult.OK)
					{
						Color c = addOrEditColor.colorSwatchPanel.BackColor;
						string thisColor = String.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);
						colorsListBox.Items.Add(
							new ListViewItem(
								new string[] {
									addOrEditColor.nameTextBox.Text, thisColor, thisColor, String.Format("{0,3:0}%", addOrEditColor.opacityTrackBar.Value)
								}, colorsListBox.Groups[0]
							)
						);
					}
					addItemIsOpen = false;
				}
			}
			else if (e.ClickedItem.Text == "Remove Color")
			{
				removeColorToolStripMenuItem_Click(sender, (EventArgs)e);
			}
			else
			{
				addItemIsOpen = true;
				AddOrEditColor addOrEditColor = new AddOrEditColor();
				ListViewItem item = colorsListBox.SelectedItems[0] as ListViewItem;
				addOrEditColor.nameTextBox.Text = item.SubItems[0].Text;
				string color = item.SubItems[2].Text;
				string R = color.Substring(1, 2), G = color.Substring(3, 2), B = color.Substring(5, 2);
				addOrEditColor.colorDialog.Color = addOrEditColor.colorSwatchPanel.BackColor = Color.FromArgb(Int32.Parse(R, System.Globalization.NumberStyles.HexNumber), Int32.Parse(G, System.Globalization.NumberStyles.HexNumber), Int32.Parse(B, System.Globalization.NumberStyles.HexNumber));
				addOrEditColor.opacityTrackBar.Value = int.Parse(item.SubItems[3].Text.Substring(0, item.SubItems[3].Text.Length - 1));
				DialogResult dr = addOrEditColor.ShowDialog(this);
				if (dr == DialogResult.OK || dr == DialogResult.Cancel)
				{
					if (dr == DialogResult.OK)
					{
						Color c = addOrEditColor.colorSwatchPanel.BackColor;
						string thisColor = String.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);
						colorsListBox.BeginUpdate();
						colorsListBox.Items[colorsListBox.SelectedIndices[0]].SubItems[0].Text = addOrEditColor.nameTextBox.Text;
						colorsListBox.Items[colorsListBox.SelectedIndices[0]].SubItems[1].Text = thisColor;
						colorsListBox.Items[colorsListBox.SelectedIndices[0]].SubItems[2].Text = thisColor;
						colorsListBox.Items[colorsListBox.SelectedIndices[0]].SubItems[3].Text = String.Format("{0,3:0}%", addOrEditColor.opacityTrackBar.Value);
						colorsListBox.EndUpdate();
					}
					addItemIsOpen = false;
				}
			}
		}

		private void guideContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem.Text == "Add New Guide Line")
			{
				addItemIsOpen = true;
				AddOrEditGuide addOrEditGuide = new AddOrEditGuide();
				DialogResult dr = addOrEditGuide.ShowDialog(this);
				if (dr == DialogResult.OK || dr == DialogResult.Cancel)
				{
					if (dr == DialogResult.OK)
					{
						ListViewGroup group = guidesListBox.Groups[0];
						if (addOrEditGuide.comboBox1.Text == "Vertical" || addOrEditGuide.comboBox1.Text == "vertical")
							group = guidesListBox.Groups[1];
						guidesListBox.Items.Add(
							new ListViewItem(
								new string[] {
									"", addOrEditGuide.comboBox1.Text, String.Format("{0}", addOrEditGuide.numericUpDown1.Value)
								}, group
							)
						);
					}
					addItemIsOpen = false;
				}
			}
			else if (e.ClickedItem.Text == "Remove Guide")
			{
				removeGuideToolStripMenuItem_Click(sender, e);
			}
			else
			{
				addItemIsOpen = true;
				AddOrEditGuide addOrEditGuide = new AddOrEditGuide();
				ListViewItem item = guidesListBox.SelectedItems[0] as ListViewItem;
				addOrEditGuide.comboBox1.Text = item.SubItems[1].Text;
				addOrEditGuide.numericUpDown1.Value = int.Parse(item.SubItems[2].Text);
				DialogResult dr = addOrEditGuide.ShowDialog(this);
				if (dr == DialogResult.OK || dr == DialogResult.Cancel)
				{
					if (dr == DialogResult.OK)
					{
						ListViewGroup group = guidesListBox.Groups[0];
						if (addOrEditGuide.comboBox1.Text == "Vertical" || addOrEditGuide.comboBox1.Text == "vertical")
							group = guidesListBox.Groups[1];
						guidesListBox.Items[guidesListBox.SelectedIndices[0]] = new ListViewItem(
							new string[] {
								"", addOrEditGuide.comboBox1.Text, String.Format("{0}", addOrEditGuide.numericUpDown1.Value)
							}, group
						);
					}
					addItemIsOpen = false;
				}
			}
		}

		private void tweenContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem.Text == "Add New Tween")
			{
				addItemIsOpen = true;
				AddOrEditTween addOrEditTween = new AddOrEditTween();
				if (frameWidthMaskedTextBox.Text != "")
					addOrEditTween.FrameWidth = int.Parse(frameWidthMaskedTextBox.Text);
				else
					addOrEditTween.FrameWidth = 0;
				if (frameHeightMaskedTextBox.Text != "")
					addOrEditTween.FrameHeight = int.Parse(frameHeightMaskedTextBox.Text);
				else
					addOrEditTween.FrameHeight = 0;
				List<Shapes.Color> colors = new List<Shapes.Color>();
				foreach (ListViewItem item in colorsListBox.Items)
				{
					string color = item.SubItems[2].Text;
					string R = color.Substring(1, 2), G = color.Substring(3, 2), B = color.Substring(5, 2);
					colors.Add(new Shapes.Color(item.SubItems[0].Text, Color.FromArgb((int)(int.Parse(item.SubItems[3].Text.Substring(0, item.SubItems[3].Text.Length - 1)) / 100.0 * 255), Int32.Parse(R, System.Globalization.NumberStyles.HexNumber), Int32.Parse(G, System.Globalization.NumberStyles.HexNumber), Int32.Parse(B, System.Globalization.NumberStyles.HexNumber))));
				}
				addOrEditTween.Colors = colors;
				List<Shapes.Guide> guides = new List<Shapes.Guide>();
				foreach (ListViewItem item in guidesListBox.Items)
				{
					if (item.SubItems[1].Text == "Horizontal" || item.SubItems[1].Text == "horizontal")
						guides.Add(new Shapes.Guide(type: Shapes.Guide.GuideType.Horizontal, position: double.Parse(item.SubItems[2].Text)));
					else
						guides.Add(new Shapes.Guide(type: Shapes.Guide.GuideType.Vertical, position: double.Parse(item.SubItems[2].Text)));
				}
				addOrEditTween.Guides = guides;
				DialogResult dr = addOrEditTween.ShowDialog(this);
				if (dr == DialogResult.OK || dr == DialogResult.Cancel)
				{
					if (dr == DialogResult.OK)
					{
						Shapes.Tween t = new Shapes.Tween(addOrEditTween.LengthInFrames, addOrEditTween.AdvancementFunction, addOrEditTween.Id, addOrEditTween.Points.ToArray(), addOrEditTween.ColorList.ToArray(), addOrEditTween.ColorsUsedInOrder.ToArray());
						int hasLines = (t.LineSegments.Count > 0) ? 1 : 0;
						string framePlurality = (t.FrameLength != 1) ? "frames" : "frame";
						string linePlurality = (t.LineSegments.Count != 1) ? "lines" : "line";
						string colorPlurality = (t.colorList.Count != 1) ? "colors" : "color";
						ListViewItem lvi = new ListViewItem(
							new string[] { "", String.Format("{0}", t.id), String.Format("{0} frames", new object[] { t.FrameLength.ToString(), framePlurality }), String.Format("{0} {1}", new object[] { t.colorList.Count.ToString(), colorPlurality }), String.Format("{0} {1}", new object[] { (hasLines * (t.LineSegments.Count + 1)).ToString(), linePlurality }), t.advancementFunction },
							tweensListBox.Groups[0]
						);
						lvi.Tag = t;
						tweensListBox.Items.Add(lvi);
					}
					addItemIsOpen = false;
				}
			}
			else if (e.ClickedItem.Text == "Remove Tween")
			{
				removeGuideToolStripMenuItem_Click(sender, (EventArgs)e);
			}
			else
			{
				addItemIsOpen = true;
				AddOrEditTween addOrEditTween = new AddOrEditTween();
				ListViewItem thisItem = tweensListBox.SelectedItems[0] as ListViewItem;
				// Send id.
				addOrEditTween.Id = thisItem.SubItems[1].Text;
				// Send advancement function.
				addOrEditTween.AdvancementFunction = thisItem.SubItems[5].Text;
				// Send length in frames.
				addOrEditTween.LengthInFrames = ((Shapes.Tween)thisItem.Tag).FrameLength;
				// Send frame dimensions or 0x0.
				if (frameWidthMaskedTextBox.Text != "")
					addOrEditTween.FrameWidth = int.Parse(frameWidthMaskedTextBox.Text);
				else
					addOrEditTween.FrameWidth = 0;
				if (frameHeightMaskedTextBox.Text != "")
					addOrEditTween.FrameHeight = int.Parse(frameHeightMaskedTextBox.Text);
				else
					addOrEditTween.FrameHeight = 0;

				// Get and add available colors.
				List<Shapes.Color> colors = new List<Shapes.Color>();
				foreach (ListViewItem item in colorsListBox.Items)
				{
					string color = item.SubItems[2].Text;
					string R = color.Substring(1, 2), G = color.Substring(3, 2), B = color.Substring(5, 2);
					colors.Add(new Shapes.Color(item.SubItems[0].Text, Color.FromArgb((int)(int.Parse(item.SubItems[3].Text.Substring(0, item.SubItems[3].Text.Length - 1)) / 100.0 * 255), Int32.Parse(R, System.Globalization.NumberStyles.HexNumber), Int32.Parse(G, System.Globalization.NumberStyles.HexNumber), Int32.Parse(B, System.Globalization.NumberStyles.HexNumber))));
				}
				addOrEditTween.Colors = colors;

				// Get and add guides.
				List<Shapes.Guide> guides = new List<Shapes.Guide>();
				foreach (ListViewItem item in guidesListBox.Items)
				{
					if (item.SubItems[1].Text == "Horizontal" || item.SubItems[1].Text == "horizontal")
						guides.Add(new Shapes.Guide(type: Shapes.Guide.GuideType.Horizontal, position: double.Parse(item.SubItems[2].Text)));
					else
						guides.Add(new Shapes.Guide(type: Shapes.Guide.GuideType.Vertical, position: double.Parse(item.SubItems[2].Text)));
				}
				addOrEditTween.Guides = guides;

				// Add used colors.
				List<string> colorsUsed = new List<string>();
				foreach (string s in ((Shapes.Tween)(tweensListBox.SelectedItems[0].Tag)).colorNames)
					colorsUsed.Add(s);
				addOrEditTween.ColorsUsedInOrder = colorsUsed;

				// Add points.
				addOrEditTween.Points = ((Shapes.Tween)(tweensListBox.SelectedItems[0].Tag)).getPoints();
				DialogResult dr = addOrEditTween.ShowDialog(this);
				if (dr == DialogResult.OK || dr == DialogResult.Cancel)
				{
					if (dr == DialogResult.OK)
					{
						Shapes.Tween t = new Shapes.Tween(addOrEditTween.LengthInFrames, addOrEditTween.AdvancementFunction, addOrEditTween.Id, addOrEditTween.Points.ToArray(), addOrEditTween.ColorList.ToArray(), addOrEditTween.ColorsUsedInOrder.ToArray());
						int hasLines = (t.LineSegments.Count > 0) ? 1 : 0;
						string framePlurality = (t.FrameLength != 1) ? "frames" : "frame";
						string linePlurality = (t.LineSegments.Count != 1) ? "lines" : "line";
						string colorPlurality = (t.colorList.Count != 1) ? "colors" : "color";
						tweensListBox.BeginUpdate();
						tweensListBox.Items[tweensListBox.SelectedIndices[0]].SubItems[1].Text = String.Format("{0}", t.id);
						tweensListBox.Items[tweensListBox.SelectedIndices[0]].SubItems[2].Text = String.Format("{0} frames", new object[] { t.FrameLength.ToString(), framePlurality });
						tweensListBox.Items[tweensListBox.SelectedIndices[0]].SubItems[3].Text = String.Format("{0} {1}", new object[] { t.colorList.Count.ToString(), colorPlurality });
						tweensListBox.Items[tweensListBox.SelectedIndices[0]].SubItems[4].Text = String.Format("{0} {1}", new object[] { (hasLines * (t.LineSegments.Count + 1)).ToString(), linePlurality });
						tweensListBox.Items[tweensListBox.SelectedIndices[0]].SubItems[5].Text = t.advancementFunction;
						tweensListBox.Items[tweensListBox.SelectedIndices[0]].Tag = t;
						tweensListBox.EndUpdate();
					}
					addItemIsOpen = false;
				}
			}
		}

		private void frameContextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			bool fileExists = File.Exists(sourceImageMaskedTextBox.Text);
			if (framesListView.SelectedIndices.Count > 0)
			{
				editFrameToolStripMenuItem.Enabled = true;
				removeFrameToolStripMenuItem.Enabled = true;
			}
			else
			{
				editFrameToolStripMenuItem.Enabled = false;
				removeFrameToolStripMenuItem.Enabled = false;
			}
			sliceSourceImageIntoFramesToolStripMenuItem.Enabled = fileExists;
		}

		private void addFrameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddOrEditFrame addOrEditFrame = new AddOrEditFrame();
			addItemIsOpen = true;
			addOrEditFrame.LoadedImage = sourceImageMaskedTextBox.Text;
			DialogResult dr = addOrEditFrame.ShowDialog(this);
			if (dr == DialogResult.OK || dr == DialogResult.Cancel)
			{
				if (dr == DialogResult.OK)
				{
					addFrame(addOrEditFrame.Id.ToString(),
						addOrEditFrame.S.ToString(),
						addOrEditFrame.T.ToString(),
						addOrEditFrame.W.ToString(),
						addOrEditFrame.H.ToString());
				}
				addItemIsOpen = false;
			}
		}

		private void addFrame(string id, string s, string t, string w, string h)
		{
			framesListView.Items.Add(new ListViewItem(new string[] { id, s, t, w, h }, framesListView.Groups[0]));
		}

		private string addFrameAutoIndex(string s, string t, string w, string h)
		{
			string id = getNextFrameId();
			framesListView.Items.Add(new ListViewItem(new string[] { id, s, t, w, h }, framesListView.Groups[0]));
			return id;
		}

		private string getNextFrameId()
		{
			int maxId = 1;
			foreach (ListViewItem item in framesListView.Items) {
				string id = item.SubItems[0].Text;
				int thisId = 0;
				bool parsed = int.TryParse(id, out thisId);
				if (parsed)
					maxId = Math.Max(maxId, thisId + 1);
			}
			return maxId.ToString();
		}

		private string getNextCompositeFrameId()
		{
			int maxId = 1;
			foreach (ListViewItem item in compositeFramesListView.Items)
			{
				string id = item.SubItems[0].Text;
				int thisId = 0;
				bool parsed = int.TryParse(id, out thisId);
				if (parsed)
					maxId = Math.Max(maxId, thisId + 1);
			}
			return maxId.ToString();
		}

		private void editFrameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddOrEditFrame addOrEditFrame = new AddOrEditFrame();
			addItemIsOpen = true;
			addOrEditFrame.Id = int.Parse(framesListView.SelectedItems[0].SubItems[0].Text);
			addOrEditFrame.S = int.Parse(framesListView.SelectedItems[0].SubItems[1].Text);
			addOrEditFrame.T = int.Parse(framesListView.SelectedItems[0].SubItems[2].Text);
			addOrEditFrame.W = int.Parse(framesListView.SelectedItems[0].SubItems[3].Text);
			addOrEditFrame.H = int.Parse(framesListView.SelectedItems[0].SubItems[4].Text);
			addOrEditFrame.LoadedImage = sourceImageMaskedTextBox.Text;
			DialogResult dr = addOrEditFrame.ShowDialog(this);
			if (dr == DialogResult.OK || dr == DialogResult.Cancel)
			{
				if (dr == DialogResult.OK)
				{
					framesListView.Items[framesListView.SelectedIndices[0]].SubItems[0].Text = addOrEditFrame.Id.ToString();
					framesListView.Items[framesListView.SelectedIndices[0]].SubItems[1].Text = addOrEditFrame.S.ToString();
					framesListView.Items[framesListView.SelectedIndices[0]].SubItems[2].Text = addOrEditFrame.T.ToString();
					framesListView.Items[framesListView.SelectedIndices[0]].SubItems[3].Text = addOrEditFrame.W.ToString();
					framesListView.Items[framesListView.SelectedIndices[0]].SubItems[4].Text = addOrEditFrame.H.ToString();
				}
				addItemIsOpen = false;
			}
		}

		private void removeFrameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SupportFunctions.RemoveSelectedListViewItems(framesListView);
		}

		private void control_MouseEnter(object sender, EventArgs e)
		{
			ListView view = sender as ListView;
			ListView.SelectedIndexCollection indices = view.SelectedIndices;
			for (int i = 0; i < indices.Count; i++)
				view.Items[indices[i]].Selected = false;
			((Control)sender).Focus();
		}

		private void listBox2_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					removeGuideToolStripMenuItem_Click(sender, (EventArgs)e);
					break;
			}
		}

		private void removeGuideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SupportFunctions.RemoveSelectedListViewItems(guidesListBox);
		}

		private void removeTweenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SupportFunctions.RemoveSelectedListViewItems(tweensListBox);
		}

		private void framesListView_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					removeFrameToolStripMenuItem_Click(sender, (EventArgs)e);
					break;
			}
		}

		private void listBox1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					removeColorToolStripMenuItem_Click(sender, (EventArgs)e);
					break;
			}
		}

		private void removeColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SupportFunctions.RemoveSelectedListViewItems(colorsListBox);
		}

		private void listBox3_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					removeTweenToolStripMenuItem_Click(sender, (EventArgs)e);
					break;
			}
		}

		private void buttonPanel1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				availableColorsAndGuidesButtonPanel.numberOfClicks = 0;
				availableColorsAndGuidesButtonPanel.lastClick = Environment.TickCount & Int32.MaxValue;
				System.Timers.Timer t = new System.Timers.Timer(200);
				t.Elapsed += new System.Timers.ElapsedEventHandler(delegate(object nsender, System.Timers.ElapsedEventArgs ne)
				{
					if (availableColorsAndGuidesButtonPanel.numberOfClicks < 2)
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleButtonPanel1Click(true);
						});
					}
					else
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleButtonPanel1Click(false);
						});
					}
					t.Enabled = false;
				});
				t.Enabled = true;
			}
		}

		public void handleButtonPanel1Click(bool fire)
		{
			if (fire)
			{
				if (lowerTableLayoutPanel.RowStyles[1].Height > 0)
					lowerTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
				else
				{
					lowerTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Percent, 25F);
					colorsListBox.Refresh();
					guidesListBox.Refresh();
				}
			}
		}

		private void buttonPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				availableColorsAndGuidesButtonPanel.numberOfClicks = 2;
				lowerTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Percent, 25F);
				colorsListBox.Refresh();
				guidesListBox.Refresh();
				lowerTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[7] = new RowStyle(SizeType.Absolute, 0F);
			}
		}

		private void buttonPanel2_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				colorAndMotionTweensButtonPanel.numberOfClicks = 0;
				colorAndMotionTweensButtonPanel.lastClick = Environment.TickCount & Int32.MaxValue;
				System.Timers.Timer t = new System.Timers.Timer(200);
				t.Elapsed += new System.Timers.ElapsedEventHandler(delegate(object nsender, System.Timers.ElapsedEventArgs ne)
				{
					if (colorAndMotionTweensButtonPanel.numberOfClicks < 2)
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleButtonPanel2Click(true);
						});
					}
					else
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleButtonPanel2Click(false);
						});
					}
					t.Enabled = false;
				});
				t.Enabled = true;
			}
		}

		public void handleButtonPanel2Click(bool fire)
		{
			if (fire)
			{
				if (lowerTableLayoutPanel.RowStyles[3].Height > 0)
					lowerTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
				else
				{
					lowerTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Percent, 25F);
					tweensListBox.Refresh();
				}
			}
		}

		private void buttonPanel3_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				frameAndCompositeFramesButtonPanel.numberOfClicks = 0;
				frameAndCompositeFramesButtonPanel.lastClick = Environment.TickCount & Int32.MaxValue;
				System.Timers.Timer t = new System.Timers.Timer(200);
				t.Elapsed += new System.Timers.ElapsedEventHandler(delegate(object nsender, System.Timers.ElapsedEventArgs ne)
				{
					if (frameAndCompositeFramesButtonPanel.numberOfClicks < 2)
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleButtonPanel3Click(true);
						});
					}
					else
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleButtonPanel3Click(false);
						});
					}
					t.Enabled = false;
				});
				t.Enabled = true;
			}
		}

		public void handleButtonPanel3Click(bool fire)
		{
			if (fire)
			{
				if (lowerTableLayoutPanel.RowStyles[5].Height > 0)
					lowerTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Absolute, 0F);
				else
				{
					lowerTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Percent, 25F);
					framesListView.Refresh();
					compositeFramesListView.Refresh();
				}
			}
		}

		private void buttonPanel4_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				compositeFrameSetsAndNamedAttachmentPointsButtonPanel.numberOfClicks = 0;
				compositeFrameSetsAndNamedAttachmentPointsButtonPanel.lastClick = Environment.TickCount & Int32.MaxValue;
				System.Timers.Timer t = new System.Timers.Timer(200);
				t.Elapsed += new System.Timers.ElapsedEventHandler(delegate(object nsender, System.Timers.ElapsedEventArgs ne)
				{
					if (compositeFrameSetsAndNamedAttachmentPointsButtonPanel.numberOfClicks < 2)
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleButtonPanel4Click(true);
						});
					}
					else
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleButtonPanel4Click(false);
						});
					}
					t.Enabled = false;
				});
				t.Enabled = true;
			}
		}

		public void handleButtonPanel4Click(bool fire)
		{
			if (fire)
			{
				if (lowerTableLayoutPanel.RowStyles[7].Height > 0)
					lowerTableLayoutPanel.RowStyles[7] = new RowStyle(SizeType.Absolute, 0F);
				else
				{
					lowerTableLayoutPanel.RowStyles[7] = new RowStyle(SizeType.Percent, 25F);
					compositeFrameSetsListView.Refresh();
				}
			}
		}

		private void buttonPanel5_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				soundsButtonPanel.numberOfClicks = 0;
				soundsButtonPanel.lastClick = Environment.TickCount & Int32.MaxValue;
				System.Timers.Timer t = new System.Timers.Timer(200);
				t.Elapsed += new System.Timers.ElapsedEventHandler(delegate(object nsender, System.Timers.ElapsedEventArgs ne)
				{
					if (soundsButtonPanel.numberOfClicks < 2)
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleButtonPanel5Click(true);
						});
					}
					else
					{
						this.Invoke((MethodInvoker)delegate
						{
							handleButtonPanel5Click(false);
						});
					}
					t.Enabled = false;
				});
				t.Enabled = true;
			}
		}

		public void handleButtonPanel5Click(bool fire)
		{
			if (fire)
			{
				if (lowerTableLayoutPanel.RowStyles[9].Height > 0)
					lowerTableLayoutPanel.RowStyles[9] = new RowStyle(SizeType.Absolute, 0F);
				else
				{
					lowerTableLayoutPanel.RowStyles[9] = new RowStyle(SizeType.Percent, 25F);
					soundsListView.Refresh();
				}
			}
		}

		private void buttonPanel2_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				colorAndMotionTweensButtonPanel.numberOfClicks = 2;
				lowerTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Percent, 25F);
				tweensListBox.Refresh();
				lowerTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[7] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[9] = new RowStyle(SizeType.Absolute, 0F);
			}
		}

		private void buttonPanel3_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				frameAndCompositeFramesButtonPanel.numberOfClicks = 2;
				lowerTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Percent, 25F);
				framesListView.Refresh();
				compositeFramesListView.Refresh();
				lowerTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[7] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[9] = new RowStyle(SizeType.Absolute, 0F);
			}
		}

		private void buttonPanel4_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				compositeFrameSetsAndNamedAttachmentPointsButtonPanel.numberOfClicks = 2;
				lowerTableLayoutPanel.RowStyles[7] = new RowStyle(SizeType.Percent, 25F);
				compositeFrameSetsListView.Refresh();
				lowerTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[9] = new RowStyle(SizeType.Absolute, 0F);
			}
		}

		private void buttonPanel5_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				compositeFrameSetsAndNamedAttachmentPointsButtonPanel.numberOfClicks = 2;
				lowerTableLayoutPanel.RowStyles[9] = new RowStyle(SizeType.Percent, 25F);
				soundsListView.Refresh();
				lowerTableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[5] = new RowStyle(SizeType.Absolute, 0F);
				lowerTableLayoutPanel.RowStyles[7] = new RowStyle(SizeType.Absolute, 0F);
			}
		}

		private void addCompositeFrameSetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Compile a list of available composite frames that can be included in a named set.
			List<Shapes.CompositeFrame> availableCompositeFrames = new List<Shapes.CompositeFrame>();
			foreach (ListViewItem item in compositeFramesListView.Items)
				availableCompositeFrames.Add((Shapes.CompositeFrame)item.Tag);
			// Create the dialog.
			AddOrEditCompositeFrameSet addOrEditSet = new AddOrEditCompositeFrameSet(availableCompositeFrames);
			int targetMS = 0;
			if(int.TryParse(targetMillisecondsMaskedTextBox.Text, out targetMS))
				addOrEditSet.TargetMS = targetMS;
			addItemIsOpen = true;
			//
			DialogResult dr = addOrEditSet.ShowDialog(this);
			if (dr == DialogResult.OK || dr == DialogResult.Cancel)
			{
				if (dr == DialogResult.OK)
				{
					Shapes.CompositeFrameSet set = addOrEditSet.CompositeFrameSet;
					ListViewItem item = new ListViewItem(new string[] { 
						set.name,
						set.FrameCallsForDisplay(),
						set.targetMS.ToString()
					}, compositeFrameSetsListView.Groups[0]);
					item.Tag = set;
					compositeFrameSetsListView.Items.Add(item);
				}
				addItemIsOpen = false;
			}
		}

		private void editCompositeFrameSetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Compile a list of available composite frames that can be included in a named set.
			List<Shapes.CompositeFrame> availableCompositeFrames = new List<Shapes.CompositeFrame>();
			foreach (ListViewItem item in compositeFramesListView.Items)
				availableCompositeFrames.Add((Shapes.CompositeFrame)item.Tag);
			// Create the dialog.
			AddOrEditCompositeFrameSet addOrEditSet = new AddOrEditCompositeFrameSet(availableCompositeFrames);
			addItemIsOpen = true;
			//
			Shapes.CompositeFrameSet thisSet = compositeFrameSetsListView.SelectedItems[0].Tag as Shapes.CompositeFrameSet;
			addOrEditSet.SetName = thisSet.name;
			addOrEditSet.TargetMS = thisSet.targetMS;
			addOrEditSet.CompositeFrameCalls = thisSet.compositeFrameCalls;
			DialogResult dr = addOrEditSet.ShowDialog(this);
			if (dr == DialogResult.OK || dr == DialogResult.Cancel)
			{
				if (dr == DialogResult.OK)
				{
					Shapes.CompositeFrameSet set = addOrEditSet.CompositeFrameSet;
					compositeFrameSetsListView.SelectedItems[0].SubItems[0].Text = set.name;
					compositeFrameSetsListView.SelectedItems[0].SubItems[1].Text = set.FrameCallsForDisplay();
					compositeFrameSetsListView.SelectedItems[0].SubItems[2].Text = set.targetMS.ToString();
					compositeFrameSetsListView.SelectedItems[0].Tag = set;
				}
				addItemIsOpen = false;
			}
		}

		private void compositeFrameSetContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			editCompositeFrameSetToolStripMenuItem.Enabled = removeCompositeFrameSetToolStripMenuItem.Enabled = (compositeFrameSetsListView.SelectedIndices.Count > 0) ? true : false;
		}

		private void removeCompositeFrameSetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SupportFunctions.RemoveSelectedListViewItems(compositeFrameSetsListView);
		}

		private void addNewSoundToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddOrEditSound addOrEditSound = new AddOrEditSound();
			addItemIsOpen = true;
			DialogResult dr = addOrEditSound.ShowDialog(this);
			if (dr == DialogResult.OK || dr == DialogResult.Cancel)
			{
				if (dr == DialogResult.OK)
				{
					soundsListView.Items.Add(new ListViewItem(new string[] { 
						addOrEditSound.SoundName,
						addOrEditSound.Filename,
						addOrEditSound.ColorName
					}));
				}
				addItemIsOpen = false;
			}
		}

		private void editSoundToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddOrEditSound addOrEditSound = new AddOrEditSound();
			addItemIsOpen = true;
			addOrEditSound.SoundName = soundsListView.SelectedItems[0].SubItems[0].Text;
			addOrEditSound.Filename = soundsListView.SelectedItems[0].SubItems[1].Text;
			addOrEditSound.ColorName = soundsListView.SelectedItems[0].SubItems[2].Text;
			DialogResult dr = addOrEditSound.ShowDialog(this);
			if (dr == DialogResult.OK || dr == DialogResult.Cancel)
			{
				if (dr == DialogResult.OK)
				{
					soundsListView.SelectedItems[0].SubItems[0].Text = addOrEditSound.SoundName;
					soundsListView.SelectedItems[0].SubItems[1].Text = Path.GetFileName(addOrEditSound.Filename);
					soundsListView.SelectedItems[0].SubItems[2].Text = addOrEditSound.ColorName;
				}
				addItemIsOpen = false;
			}
		}

		private void removeSoundToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SupportFunctions.RemoveSelectedListViewItems(soundsListView);
		}

		private void soundContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			// Only enable editing/removal if there is a sound selected. Otherwise, disable.
			editSoundToolStripMenuItem.Enabled = removeSoundToolStripMenuItem.Enabled =  (soundsListView.SelectedItems.Count > 0) ? true : false;
		}

		private void copyRangeOfCompositeFramesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRangeOfCompositeFrames copyRangeOfCompositeFrames = new CopyRangeOfCompositeFrames();
			addItemIsOpen = true;
			DialogResult dr = copyRangeOfCompositeFrames.ShowDialog(this);
			if (dr == DialogResult.OK || dr == DialogResult.Cancel)
			{
				if (dr == DialogResult.OK)
				{
					int startRange = copyRangeOfCompositeFrames.CopyFromFrame;
					int endRange = copyRangeOfCompositeFrames.ToFrame;
					int placeAtIndex = copyRangeOfCompositeFrames.PlaceAtIndex;
					int finalIndex = placeAtIndex + endRange - startRange;
					// Get the whole list of composite frames.
					List<Shapes.CompositeFrame> compositeFramesBeforeCopy = new List<Shapes.CompositeFrame>();
					foreach (ListViewItem item in compositeFramesListView.Items)
						compositeFramesBeforeCopy.Add((Shapes.CompositeFrame)item.Tag);
					// From that list, get out just the ones that are supposed to be copied, creating a copy in the process.
					List<Shapes.CompositeFrame> compositeFramesToAdd = new List<Shapes.CompositeFrame>();
					List<Shapes.CompositeFrameSet> compositeFrameSetsToMirror = new List<Shapes.CompositeFrameSet>();
					foreach (Shapes.CompositeFrame compositeFrame in compositeFramesBeforeCopy)
					{
						int id = Int32.Parse(compositeFrame.id);
						if (startRange <= id && id <= endRange)
						{
							// Create id: 61 + (1 - 1) = 0; 61 + (10 - 1) = 70; 61 + (50 - 50) = 61
							int newId = placeAtIndex + (id - startRange);
							// Create object with new id and the same frame calls.
							Shapes.CompositeFrame copiedCompositeFrame = new Shapes.CompositeFrame(id: newId.ToString());
							foreach (Shapes.FrameCall thisCall in compositeFrame.frameCalls)
								copiedCompositeFrame.frameCalls.Add(new Shapes.FrameCall(thisCall));
							// Add it to the list.
							compositeFramesToAdd.Add(copiedCompositeFrame);
							// If named sets need to be mirrored, get only the effected ones.
							if (copyRangeOfCompositeFrames.GenerateMirroredSets)
							{
								// Find all composite frame sets that contain this composite frame.
								foreach (ListViewItem thisItem in compositeFrameSetsListView.Items) {
									Shapes.CompositeFrameSet set = thisItem.Tag as Shapes.CompositeFrameSet;
									if (set != null && set.compositeFrameCalls.Exists(item => item.id == compositeFrame.id))
										if (!compositeFrameSetsToMirror.Contains(set))
											compositeFrameSetsToMirror.Add(set);
								}
							}
						}
					}
					// Join the two lists into a new combined list.
					List<Shapes.CompositeFrame> compositeFramesAfterCopy = new List<Shapes.CompositeFrame>();
					compositeFramesAfterCopy.AddRange(compositeFramesToAdd);
					foreach (Shapes.CompositeFrame compositeFrame in compositeFramesBeforeCopy)
						if (!compositeFramesAfterCopy.Contains(compositeFrame))
							compositeFramesAfterCopy.Add(compositeFrame);
					// Clear the list view that represents composite frames.
					compositeFramesListView.Items.Clear();
					List<ListViewItem> finalList = new List<ListViewItem>();
					// Finally, add all the composite frames back into the list view.
					foreach (Shapes.CompositeFrame compositeFrame in compositeFramesAfterCopy)
					{
						ListViewItem lvi = new ListViewItem(new string[]{
							compositeFrame.id, string.Format("{0} frames", compositeFrame.frameCalls.Count)
						}, compositeFramesListView.Groups[0]);
						lvi.Tag = compositeFrame;
						finalList.Add(lvi);
					}
					finalList.Sort((x, y) => Int32.Parse(x.SubItems[0].Text).CompareTo(Int32.Parse(y.SubItems[0].Text)));
					foreach (ListViewItem lvi in finalList)
						compositeFramesListView.Items.Add(lvi);
					// Update the view.
					compositeFramesListView.Refresh();
					//
					if (copyRangeOfCompositeFrames.GenerateMirroredSets && compositeFrameSetsToMirror.Count > 0)
					{
						List<RegularExpressionReplacement> replacements = copyRangeOfCompositeFrames.Rewrites;
						foreach (Shapes.CompositeFrameSet set in compositeFrameSetsToMirror)
						{
							string newSetName = set.name;
							foreach (RegularExpressionReplacement replacement in replacements)
							{
								RegexOptions options = new RegexOptions();
								if (replacement.CaseSensitive) options |= RegexOptions.IgnoreCase;
								newSetName = Regex.Replace(newSetName, replacement.RegularExpression, replacement.ReplacementText, options);
							}
							// Because composite frame sets are keyed by a name string, try to force a different name.
							if (newSetName == set.name)
								newSetName += ".Mirrored";
							// Create new set.
							Shapes.CompositeFrameSet mirroredSet = new Shapes.CompositeFrameSet(newSetName, set.targetMS, compositeFrameCalls: new List<Shapes.CompositeFrameCall>());
							// Add the adjusted frame calls to the new set.
							foreach (Shapes.CompositeFrameCall call in set.compositeFrameCalls)
							{
								int newId = placeAtIndex + (Int32.Parse(call.id) - startRange);
								Shapes.CompositeFrameCall newCall = new Shapes.CompositeFrameCall(id: string.Format("{0}", newId), eventName: call.eventName);
								mirroredSet.compositeFrameCalls.Add(newCall);
							}
							// Add the set.
							ListViewItem item = new ListViewItem(new string[] { 
								mirroredSet.name,
								mirroredSet.FrameCallsForDisplay(),
								mirroredSet.targetMS.ToString()
							}, compositeFrameSetsListView.Groups[0]);
							item.Tag = mirroredSet;
							compositeFrameSetsListView.Items.Add(item);
						}
						// Update the view.
						compositeFrameSetsListView.Refresh();
					}
				}
				addItemIsOpen = false;
			}
		}

		private void flipRangeOfCompositeFramesHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FlipRangeOfCompositeFrames flipRangeOfCompositeFramesHorizontally = new FlipRangeOfCompositeFrames();
			addItemIsOpen = true;
			DialogResult dr = flipRangeOfCompositeFramesHorizontally.ShowDialog(this);
			if (dr == DialogResult.OK || dr == DialogResult.Cancel)
			{
				if (dr == DialogResult.OK)
				{
					int startRange = flipRangeOfCompositeFramesHorizontally.StartFrame;
					int endRange = flipRangeOfCompositeFramesHorizontally.EndFrame;
					bool flipOrder = flipRangeOfCompositeFramesHorizontally.FlipOrder;
					// Get frame-width.
					int frameWidth = Int32.Parse(frameWidthMaskedTextBox.Text);
					// Iterate over the composite frames, flipping them if they fall within the specified range of composite frame numbers.
					foreach (ListViewItem item in compositeFramesListView.Items)
					{
						Shapes.CompositeFrame compositeFrame = item.Tag as Shapes.CompositeFrame;
						int id = Int32.Parse(compositeFrame.id);
						if (startRange <= id && id <= endRange)
						{
							foreach (Shapes.FrameCall call in compositeFrame.frameCalls)
							{
								int callId = Int32.Parse(call.id);
								int callWidth = GetWidthOfFrameForFrameCall(callId);
								int callOffsetX = (int)call.OffsetX;
								int newX = (int)(frameWidth - callOffsetX - callWidth);
								call.OffsetX = newX;
								call.FlipX = !call.FlipX;
							}
							if (flipOrder)
								compositeFrame.frameCalls.Reverse();
						}
						item.Tag = compositeFrame;
					}
				}
				addItemIsOpen = false;
			}
		}

		private int GetWidthOfFrameForFrameCall(int idOfFrame)
		{
			// Iterate over the frames list view to find a frame with the appropriate id.
			foreach (ListViewItem lvi in framesListView.Items)
			{
				int index = Int32.Parse(lvi.SubItems[0].Text);
				if (index == idOfFrame)
				{
					int width = Int32.Parse(lvi.SubItems[3].Text);
					return width;
				}
			}
			return 0;
		}

		private void slideRangeOfCompositeFramesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SlideRangeOfCompositeFrames slideRangeOfCompositeFrames = new SlideRangeOfCompositeFrames();
			addItemIsOpen = true;
			DialogResult dr = slideRangeOfCompositeFrames.ShowDialog(this);
			if (dr == DialogResult.OK || dr == DialogResult.Cancel)
			{
				if (dr == DialogResult.OK)
				{
					int startRange = slideRangeOfCompositeFrames.SlideFromFrame;
					int endRange = slideRangeOfCompositeFrames.ToFrame;
					int x = slideRangeOfCompositeFrames.SlideX;
					int y = slideRangeOfCompositeFrames.SlideY;
					// Iterate over the composite frames, flipping them if they fall within the specified range of composite frame numbers.
					foreach (ListViewItem item in compositeFramesListView.Items)
					{
						Shapes.CompositeFrame compositeFrame = item.Tag as Shapes.CompositeFrame;
						int id = Int32.Parse(compositeFrame.id);
						if (startRange <= id && id <= endRange)
						{
							foreach (Shapes.FrameCall call in compositeFrame.frameCalls)
							{
								int callOffsetX = (int)call.OffsetX + x;
								int callOffsetY = (int)call.OffsetY + y;
								call.OffsetX = callOffsetX;
								call.OffsetY = callOffsetY;
							}
						}
						item.Tag = compositeFrame;
					}
				}
				addItemIsOpen = false;
			}
		}

		private void addNamedAttachmentPointToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddOrEditNamedAttachmentPoint addOrEditNamedAttachmentPoint = new AddOrEditNamedAttachmentPoint();
			addItemIsOpen = true;
			DialogResult dr = addOrEditNamedAttachmentPoint.ShowDialog(this);
			if (dr == DialogResult.OK || dr == DialogResult.Cancel)
			{
				if (dr == DialogResult.OK)
				{
					ListViewItem item = new ListViewItem(new string[] { 
						addOrEditNamedAttachmentPoint.Id.ToString(),
						addOrEditNamedAttachmentPoint.AttachmentPointName,
						addOrEditNamedAttachmentPoint.Description
					}, namedAttachmentPointsListView.Groups[0]);
					item.Tag = new Shapes.NamedAttachmentPoint(id: addOrEditNamedAttachmentPoint.Id, name: addOrEditNamedAttachmentPoint.AttachmentPointName, description: addOrEditNamedAttachmentPoint.Description, x: addOrEditNamedAttachmentPoint.X, y: addOrEditNamedAttachmentPoint.Y);
					namedAttachmentPointsListView.Items.Add(item);
				}
				addItemIsOpen = false;
			}
		}

		private void editNamedAttachmentPointToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddOrEditNamedAttachmentPoint addOrEditNamedAttachmentPoint = new AddOrEditNamedAttachmentPoint();
			//
			Shapes.NamedAttachmentPoint nap = namedAttachmentPointsListView.SelectedItems[0].Tag as Shapes.NamedAttachmentPoint;
			addOrEditNamedAttachmentPoint.Id = nap.id;
			addOrEditNamedAttachmentPoint.AttachmentPointName = nap.name;
			addOrEditNamedAttachmentPoint.Description = nap.description;
			addOrEditNamedAttachmentPoint.X = nap.x;
			addOrEditNamedAttachmentPoint.Y = nap.y;
			//
			addItemIsOpen = true;
			DialogResult dr = addOrEditNamedAttachmentPoint.ShowDialog(this);
			if (dr == DialogResult.OK || dr == DialogResult.Cancel)
			{
				if (dr == DialogResult.OK)
				{
					namedAttachmentPointsListView.SelectedItems[0].SubItems[0].Text = addOrEditNamedAttachmentPoint.Id.ToString();
					namedAttachmentPointsListView.SelectedItems[0].SubItems[1].Text = addOrEditNamedAttachmentPoint.AttachmentPointName;
					namedAttachmentPointsListView.SelectedItems[0].SubItems[2].Text = addOrEditNamedAttachmentPoint.Description;
					namedAttachmentPointsListView.SelectedItems[0].Tag = new Shapes.NamedAttachmentPoint(id: addOrEditNamedAttachmentPoint.Id, name: addOrEditNamedAttachmentPoint.AttachmentPointName, description: addOrEditNamedAttachmentPoint.Description, x: addOrEditNamedAttachmentPoint.X, y: addOrEditNamedAttachmentPoint.Y);
				}
				addItemIsOpen = false;
			}
		}

		private void namedAttachmentPointsContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			if (namedAttachmentPointsListView.SelectedItems.Count > 0)
			{
				editNamedAttachmentPointToolStripMenuItem.Enabled = true;
				removeNamedAttachmentPointToolStripMenuItem.Enabled = true;
			}
			else
			{
				editNamedAttachmentPointToolStripMenuItem.Enabled = false;
				removeNamedAttachmentPointToolStripMenuItem.Enabled = false;
			}
		}

		private void removeNamedAttachmentPointToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SupportFunctions.RemoveSelectedListViewItems(namedAttachmentPointsListView);
		}

		private void namedAttachmentPointsListView_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					removeNamedAttachmentPointToolStripMenuItem_Click(sender, (EventArgs)e);
					break;
			}
		}

		private void compositeFrameSetsListView_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					removeCompositeFrameSetToolStripMenuItem_Click(sender, (EventArgs)e);
					break;
			}
		}

		private void sliceSourceImageIntoFramesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SliceSourceImageIntoFrames dlg = new SliceSourceImageIntoFrames(sourceImageMaskedTextBox.Text);
			addItemIsOpen = true;
			DialogResult dr = dlg.ShowDialog(this);
			if (dr == DialogResult.OK || dr == DialogResult.Cancel)
			{
				Application.DoEvents();
				//
				if (dr == DialogResult.OK)
				{
					Bitmap bmp = (dlg.IgnoreEmptyFrames) ? new Bitmap(dlg.SourceImageFilename) : (Bitmap)null;
					Color? transparentColor = (dlg.IgnoreEmptyFrames) ? bmp.GetPixel(0, 0) : (Color?)null;
					for (int row = 0; row < dlg.Rows; row++)
					{
						for (int column = 0; column < dlg.Columns; column++)
						{
							int s = column * dlg.StepX, w = dlg.StepX, t = row * dlg.StepY, h = dlg.StepY;
							if (s + w > dlg.SourceImageDimensions.Width)
								w = dlg.SourceImageDimensions.Width - s;
							if (t + h > dlg.SourceImageDimensions.Height)
								h = dlg.SourceImageDimensions.Height - t;
							bool ignoreThisFrame = false;
							if (dlg.IgnoreEmptyFrames)
							{
								using (Bitmap subFrameImage = bmp.Clone(new Rectangle(s, t, w, h), System.Drawing.Imaging.PixelFormat.Format32bppArgb)) {
									List<Color> theseColors = SupportFunctions.UniqueColors(subFrameImage);
									bool hadTransparentColor = theseColors.Contains(transparentColor.Value);
									ignoreThisFrame = !(theseColors.Count > 1 || (theseColors.Count == 1 && !hadTransparentColor));
								}
							}
							if (!ignoreThisFrame)
							{
								// Add frame.
								string thisId = addFrameAutoIndex(s.ToString(), t.ToString(), w.ToString(), h.ToString());
								//
								if (dlg.AutomaticallyCompositeFrames)
								{
									Shapes.CompositeFrame compositeFrame = new Shapes.CompositeFrame(id: getNextCompositeFrameId());
									List<Shapes.FrameCall> frames = new List<Shapes.FrameCall> {
									new Shapes.FrameCall(id: thisId)
								};
									compositeFrame.frameCalls = frames;
									ListViewItem lvi = new ListViewItem(new string[]{
									compositeFrame.id, string.Format("{0} frames", compositeFrame.frameCalls.Count)
								}, compositeFramesListView.Groups[0]);
									lvi.Tag = compositeFrame;
									compositeFramesListView.Items.Add(lvi);
								}
							}
						}
					}
					// Update frame width/height data if there's none previously set.
					if (frameWidthMaskedTextBox.Text == "")
						frameWidthMaskedTextBox.Text = string.Format("{0}", dlg.StepX);
					if (frameHeightMaskedTextBox.Text == "")
						frameHeightMaskedTextBox.Text = string.Format("{0}", dlg.StepY);
					// Update row/column data if there's non previously set.
					if (columnCountMaskedTextBox.Text == "")
						columnCountMaskedTextBox.Text = string.Format("{0}", dlg.Columns);
					if (rowCountMaskedTextBox.Text == "")
						rowCountMaskedTextBox.Text = string.Format("{0}", dlg.Rows);
					//
					if (bmp != null)
						bmp.Dispose();
				}
				addItemIsOpen = false;
				dlg.Dispose();
			}
		}

		private void removeSelectedCompositeFramesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SupportFunctions.RemoveSelectedListViewItems(compositeFramesListView);
		}

		private void compositeFramesContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			bool haveSelection = (compositeFramesListView.SelectedIndices.Count > 0) ? true : false;
			removeSelectedCompositeFramesToolStripMenuItem.Enabled = haveSelection;
		}

		private void compositeFramesListView_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					removeSelectedCompositeFramesToolStripMenuItem_Click(sender, (EventArgs)e);
					break;
			}
		}
	}
}