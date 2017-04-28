using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SpriteAnimator
{
	public partial class AvailableFormats : Form
	{
		private Main parent = null;
		private ImageViewer im = null;
		private List<Format> formats = new List<Format>();

		/*
		 * Image Blending
		 */
		public List<Color> protectedColors = new List<Color>();

		public AvailableFormats(Main parent)
		{
			this.parent = parent;
			if (Directory.Exists(parent.baseLocation + @"\formats"))
			{
				string[] formatFolders = Directory.GetDirectories(parent.baseLocation + @"\formats");
				foreach (string fn in formatFolders)
				{
					if (File.Exists(fn + @"\sprite.xml"))
					{
						System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(fn + @"\sprite.xml");
						System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
						doc.Load(reader);
						reader.Close();
						System.Xml.XmlElement root = doc.DocumentElement;
						System.Xml.XmlNode nodeFormat = root.SelectSingleNode("/format");
						string name = (nodeFormat.Attributes.GetNamedItem("name") != null) ? nodeFormat.Attributes.GetNamedItem("name").Value : new System.IO.DirectoryInfo(fn).Name;
						int targetRows = (nodeFormat.Attributes.GetNamedItem("target-rows") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("target-rows").Value) : 1;
						int targetColumns = (nodeFormat.Attributes.GetNamedItem("target-columns") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("target-columns").Value) : 0;
						int baseHeight = (nodeFormat.Attributes.GetNamedItem("base-height") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("base-height").Value) : 0;
						int baseWidth = (nodeFormat.Attributes.GetNamedItem("base-width") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("base-width").Value) : 0;
						int targetStart = (nodeFormat.Attributes.GetNamedItem("target-start") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("target-start").Value) : 1;
						int targetEnd = (nodeFormat.Attributes.GetNamedItem("target-end") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("target-end").Value) : targetStart;
						int frameHeight = (nodeFormat.Attributes.GetNamedItem("frame-height") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("frame-height").Value) : 0;
						int frameWidth = (nodeFormat.Attributes.GetNamedItem("frame-width") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("frame-width").Value) : 0;
						bool useNoSampling = (nodeFormat.Attributes.GetNamedItem("no-sampling") != null) ? bool.Parse(nodeFormat.Attributes.GetNamedItem("no-sampling").Value) : false;
						bool hasReference = File.Exists(fn + @"\reference.bmp");
						string status = (nodeFormat.Attributes.GetNamedItem("status") != null) ? nodeFormat.Attributes.GetNamedItem("status").Value : "Work in progress.";
						string referenceImage = fn + @"\reference.bmp";
						if (hasReference)
						{
							System.Xml.XmlNodeList nodeReference = root.SelectNodes("/format/reference/protected-colors/color");
							protectedColors = new List<Color>();
							foreach (System.Xml.XmlNode node in nodeReference)
							{
								int r = (node.Attributes.GetNamedItem("r") != null) ? int.Parse(node.Attributes.GetNamedItem("r").Value) : 0;
								int g = (node.Attributes.GetNamedItem("g") != null) ? int.Parse(node.Attributes.GetNamedItem("g").Value) : 0;
								int b = (node.Attributes.GetNamedItem("b") != null) ? int.Parse(node.Attributes.GetNamedItem("b").Value) : 0;
								protectedColors.Add(Color.FromArgb(255, r, g, b));
							}
						}
						formats.Add(new Format(name: name, type: new System.IO.DirectoryInfo(fn).Name, baseHeight: baseHeight, baseWidth: baseWidth, frameHeight: frameHeight, frameWidth: frameWidth, targetRows: targetRows, targetColumns: targetColumns, targetStart: targetStart, targetEnd: targetEnd, noSampling: useNoSampling, hasReference: hasReference, referenceImageFile: referenceImage, status: status));
					}
				}
			}
			InitializeComponent();
			//
			formatNameComboBox.DisplayMember = "Name";
			formatNameComboBox.ValueMember = "Type";
			//
			formatNameComboBox.DataSource = formats;
			// Look for current value.
			int selectedIndex = -1;
			if (parent.loadedFormat != "")
			{
				for (int i = 0; i < formatNameComboBox.Items.Count; i++)
				{
					Format f = formatNameComboBox.Items[i] as Format;
					if (selectedIndex < 0 && f.Type == parent.loadedFormat.ToLower())
						selectedIndex = i;
				}
			}
			// Set value.
			if (formatNameComboBox.Items.Count > 0)
				formatNameComboBox.SelectedIndex = (selectedIndex < 0) ? 0 : selectedIndex;
		}

		private void refreshForm()
		{
			Format f = formatNameComboBox.SelectedItem as Format;
			if (f != null)
			{
				label12.Text = string.Format("{0} pixels", f.baseWidth.ToString());
				label13.Text = string.Format("{0} pixels", f.baseHeight.ToString());
				label14.Text = string.Format("{0} pixels", f.frameWidth.ToString());
				label15.Text = string.Format("{0} pixels", f.frameHeight.ToString());
				label16.Text = string.Format("{0}", (!f.noSampling).ToString().ToLower());
				label20.Text = string.Format("{0} rows", f.targetRows.ToString());
				label19.Text = string.Format("{0} columns", f.targetColumns.ToString());
				label18.Text = SupportFunctions.Ordinal(f.targetStart);
				label17.Text = SupportFunctions.Ordinal(f.targetEnd);
				if (parent.loadedImageDescription.Filename != "")
				{
					string s = System.IO.Path.GetFileNameWithoutExtension(parent.loadedImageDescription.Filename);
					string[] c = s.Split('.');
					string d = System.IO.Path.GetExtension(parent.loadedImageDescription.Filename);
					label22.Text = string.Format("{0}.{1}{2}", new object[] { c[0], f.Type, d });
				}
				else
					label22.Text = string.Format("{0}.{1}.bmp; {2}.{3}.png", new object[] { "my-sprite", f.Type, "my-sprite", f.Type });
				label29.Text = f.status;
				if (f.hasReference)
				{
					label7.Enabled = true;
					linkLabel1.Enabled = true;
				}
				else
				{
					label7.Enabled = false;
					linkLabel1.Enabled = false;
				}
			}
			label1.Focus();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			refreshForm();
		}

		private void AvailableFormats_Shown(object sender, EventArgs e)
		{
			label1.Focus();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Format f = formatNameComboBox.SelectedItem as Format;
			if (f != null)
			{
				im = new ImageViewer(f.referenceImageFile, f.Type.ToLower(), protectedColors, parent);
				im.Show(this.parent.previewWindow);
			}
		}

		private void AvailableFormats_FormClosed(object sender, FormClosedEventArgs e)
		{
			parent.availableFormatsWindow = null;
		}
	}

	public class Format
	{
		public string name = "", type = "", referenceImageFile = "", status = "";
		public int baseHeight = 0, baseWidth = 0, frameHeight = 0, frameWidth = 0, targetRows = 0, targetColumns = 0, targetStart = 0, targetEnd = 0;
		public bool hasReference = false, noSampling = false;

		[System.Reflection.ObfuscationAttribute(Feature = "renaming")]
		public string Type
		{
			get { return type.ToLower(); }
			set { type = value; }
		}

		[System.Reflection.ObfuscationAttribute(Feature = "renaming")]
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public Format(string name = "", string type = "", int baseHeight = 0, int baseWidth = 0, int frameHeight = 0, int frameWidth = 0, int targetRows = 0, int targetColumns = 0, int targetStart = 0, int targetEnd = 0, bool noSampling = false, bool hasReference = true, string referenceImageFile = "", string status = "")
		{
			this.name = name;
			this.type = type;
			this.baseHeight = baseHeight;
			this.baseWidth = baseWidth;
			this.frameHeight = frameHeight;
			this.frameWidth = frameWidth;
			this.targetRows = targetRows;
			this.targetColumns = targetColumns;
			this.targetStart = targetStart;
			this.targetEnd = targetEnd;
			this.noSampling = noSampling;
			this.hasReference = hasReference;
			this.referenceImageFile = referenceImageFile;
			this.status = status;
		}
	}
}
