using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace SpriteAnimator.SupportClasses
{
	public class Format
	{
		// File system.
		private string baseLocation = "", formatName = null;

		public string FormatName
		{
			get { return formatName; }
			set {
				string previousName = formatName;
				formatName = value;
				//
				if (previousName != formatName)
				{
					this.root = null;
					this.Update();
				}
			}
		}

		public string Path(string file)
		{
			// ..\formats\format\file.ext; or, uninitialized: ..\formats\file.ext
			if (this.formatName != null)
				return System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.Combine(this.baseLocation, "formats"), this.formatName), file);
			else
				return System.IO.Path.Combine(System.IO.Path.Combine(this.baseLocation, "formats"), file);
		}

		// Format header.
		private int targetRows, targetColumns, targetStart, targetEnd, targetMS;
		private int baseWidth, baseHeight, frameWidth, frameHeight;
		private bool useNoSampling;
		private double onLoadZoom;

		// Format header accessors.
		public double OnLoadZoom
		{
			get { return onLoadZoom; }
			set { onLoadZoom = value; }
		}

		public int TargetRows
		{
			get { return targetRows; }
			set { targetRows = value; }
		}

		public int TargetColumns
		{
			get { return targetColumns; }
			set { targetColumns = value; }
		}

		public int TargetStart
		{
			get { return targetStart; }
			set { targetStart = value; }
		}

		public int TargetEnd
		{
			get { return targetEnd; }
			set { targetEnd = value; }
		}

		public int TargetMS
		{
			get { return targetMS; }
			set { targetMS = value; }
		}

		public int BaseWidth
		{
			get { return baseWidth; }
			set { baseWidth = value; }
		}

		public int BaseHeight
		{
			get { return baseHeight; }
			set { baseHeight = value; }
		}

		public int FrameWidth
		{
			get { return frameWidth; }
			set { frameWidth = value; }
		}

		public int FrameHeight
		{
			get { return frameHeight; }
			set { frameHeight = value; }
		}

		public bool UseNoSampling
		{
			get { return useNoSampling; }
			set { useNoSampling = value; }
		}

		// Format components.
		private List<Shapes.Color> availableColorList = new List<Shapes.Color>();

		public List<Shapes.Color> AvailableColorList
		{
			get { return availableColorList; }
			set { availableColorList = value; }
		}

		private List<Shapes.Tween> availableTweenList = new List<Shapes.Tween>();

		public List<Shapes.Tween> AvailableTweenList
		{
			get { return availableTweenList; }
			set { availableTweenList = value; }
		}

		private List<Shapes.Guide> guides = new List<Shapes.Guide>();

		public List<Shapes.Guide> Guides
		{
			get { return guides; }
			set { guides = value; }
		}

		private List<Shapes.Frame> availableFrameList = new List<Shapes.Frame>();

		public List<Shapes.Frame> AvailableFrameList
		{
			get { return availableFrameList; }
			set { availableFrameList = value; }
		}

		private List<Shapes.CompositeFrameSet> compositeFrameSetList = new List<Shapes.CompositeFrameSet>();

		public List<Shapes.CompositeFrameSet> CompositeFrameSetList
		{
			get { return compositeFrameSetList; }
			set { compositeFrameSetList = value; }
		}

		private List<Shapes.NamedAttachmentPoint> availableNamedAttachmentPointsList = new List<Shapes.NamedAttachmentPoint>();

		public List<Shapes.NamedAttachmentPoint> AvailableNamedAttachmentPointsList
		{
			get { return availableNamedAttachmentPointsList; }
			set { availableNamedAttachmentPointsList = value; }
		}

		private List<Sound> availableSounds = new List<Sound>();

		public List<Sound> AvailableSounds
		{
			get { return availableSounds; }
			set { availableSounds = value; }
		}

		private Dictionary<int, List<Sound>> compositeFrameSoundCues = new Dictionary<int, List<Sound>>();

		public Dictionary<int, List<Sound>> CompositeFrameSoundCues
		{
			get { return compositeFrameSoundCues; }
			set { compositeFrameSoundCues = value; }
		}

		public Dictionary<string, List<int>> CompositeFramesBySoundName
		{
			get
			{
				Dictionary<string, List<int>> soundToCues = new Dictionary<string, List<int>>();
				// Initialize all the sounds.
				foreach (Sound s in AvailableSounds)
				{
					if (!soundToCues.ContainsKey(s.name))
						soundToCues[s.name] = new List<int>();
				}
				// Fill out the sounds with what composite frames they're used in.
				foreach (int key in CompositeFrameSoundCues.Keys)
				{
					foreach (Sound s in CompositeFrameSoundCues[key])
					{
						soundToCues[s.name].Add(key);
					}
				}
				return soundToCues;
			}
		}

		private Dictionary<int, List<Shapes.FrameCall>> compositeFrames = new Dictionary<int, List<Shapes.FrameCall>>();

		public Dictionary<int, List<Shapes.FrameCall>> CompositeFrames
		{
			get { return compositeFrames; }
			set { compositeFrames = value; }
		}

		private Dictionary<int, List<int>> compositeFramesWithNamedAttachments = new Dictionary<int, List<int>>();

		public Dictionary<int, List<int>> CompositeFramesWithNamedAttachments
		{
			get { return compositeFramesWithNamedAttachments; }
			set { compositeFramesWithNamedAttachments = value; }
		}

		public Shapes.Frame[] AvailableFrameListAsArray
		{
			get { return AvailableFrameList.ToArray(); }
		}

		public Shapes.NamedAttachmentPoint[] AvailableNamedAttachmentPointsListAsArray
		{
			get { return AvailableNamedAttachmentPointsList.ToArray(); }
		}

		// XML.
		public DateTime LastWrite
		{
			get {
				return File.GetLastWriteTime(Path("sprite.xml"));
			}
		}

		private XmlElement root = null;

		public XmlElement Root
		{
			get
			{
				// Find it only if it doesn't already exist.
				if (this.root == null)
				{
					XmlTextReader reader = new XmlTextReader(Path("sprite.xml"));
					XmlDocument doc = new XmlDocument();
					doc.Load(reader);
					reader.Close();
					this.root = doc.DocumentElement;
				}
				// Return the root element ("/").
				return this.root;
			}
		}

		public Format(string formatName, string baseLocation = null)
		{
			this.baseLocation = (baseLocation != null) ? baseLocation : System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
			this.FormatName = formatName;
		}

		public void Update()
		{
			XmlNode nodeFormat = this.Root.SelectSingleNode("/format");
			// Header
			this.TargetRows = (nodeFormat.Attributes.GetNamedItem("target-rows") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("target-rows").Value) : 1;
			this.TargetColumns = (nodeFormat.Attributes.GetNamedItem("target-columns") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("target-columns").Value) : 0;
			this.BaseHeight = (nodeFormat.Attributes.GetNamedItem("base-height") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("base-height").Value) : 0;
			this.BaseWidth = (nodeFormat.Attributes.GetNamedItem("base-width") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("base-width").Value) : 0;
			this.TargetStart = (nodeFormat.Attributes.GetNamedItem("target-start") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("target-start").Value) : 1;
			this.TargetEnd = (nodeFormat.Attributes.GetNamedItem("target-end") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("target-end").Value) : targetStart;
			this.TargetMS = (nodeFormat.Attributes.GetNamedItem("target-ms") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("target-ms").Value) : 143;
			this.UseNoSampling = (nodeFormat.Attributes.GetNamedItem("no-sampling") != null) ? bool.Parse(nodeFormat.Attributes.GetNamedItem("no-sampling").Value) : false;
			this.FrameHeight = (nodeFormat.Attributes.GetNamedItem("frame-height") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("frame-height").Value) : 0;
			this.FrameWidth = (nodeFormat.Attributes.GetNamedItem("frame-width") != null) ? int.Parse(nodeFormat.Attributes.GetNamedItem("frame-width").Value) : 0;
			this.OnLoadZoom = (nodeFormat.Attributes.GetNamedItem("on-load-zoom") != null) ? double.Parse(nodeFormat.Attributes.GetNamedItem("on-load-zoom").Value) : 1;
			// Load available color list, guides list, available tween list, available frames, composite frames, and composite frame sets.
			this.availableColorList = SupportFunctions.GetListOfAvailableColorsFromXMLRoot(this.Root);
			this.guides = SupportFunctions.GetListOfGuidesFromXMLRoot(this.Root);
			this.availableTweenList = SupportFunctions.GetListOfAvailableTweensFromXMLRoot(this.Root);
			this.availableFrameList = SupportFunctions.GetListOfAvailableFramesFromXMLRoot(this.Root);
			this.compositeFrameSetList = SupportFunctions.GetListOfAvailableCompositeFrameSetsFromXMLRoot(this.Root, targetMS: targetMS);
			this.availableNamedAttachmentPointsList = SupportFunctions.GetListOfAvailableNamedAttachmentPointsFromXMLRoot(this.Root);
			this.availableSounds = SupportFunctions.GetListOfAvailableSoundsFromXMLRoot(this.Root);
			// Clear the list of composite frame sound cues.
			this.compositeFrameSoundCues.Clear();
			foreach (Sound s in this.availableSounds)
			{
				if (s != null)
				{
					// Find the index of the sound.
					int index = this.availableSounds.FindIndex(item => item != null && item.name == s.name);
					// Find the composite frames this sound is used in.
					List<int> usedInCompositeFrames = new List<int>();
					XmlNodeList usedSoundList = this.Root.SelectNodes("composite-frames/composite-frame[@id]/sound[@name=\"" + s.name + "\"]");
					foreach (XmlNode node in usedSoundList)
					{
						int id = int.Parse(node.ParentNode.Attributes.GetNamedItem("id").Value);
						usedInCompositeFrames.Add(id);
					}
					// If the sound is actually used, then initialize it to be played. Otherwise, just save its description.
					if (usedInCompositeFrames.Count > 0)
					{
						usedInCompositeFrames.ForEach(delegate(int frame)
						{
							// Create a sound list for the composite frame id if one does not already exist.
							if (!this.compositeFrameSoundCues.ContainsKey(frame - 1))
								this.compositeFrameSoundCues[frame - 1] = new List<Sound>();
							// Add the basic information of the sound to be played.
							this.compositeFrameSoundCues[frame - 1].Add(this.availableSounds[index]);
						});
					}
				}
			}
			// 1..X
			CompositeFrames.Clear();
			LoadOrReloadRangeOfCompositeFrames(from: 1, to: TargetRows * TargetColumns);
		}

		public void LoadOrReloadRangeOfCompositeFrames(int from = 1, int to = 1, bool reloadRoot = false)
		{
			// Force the XML to be re-tokenized.
			if (reloadRoot)
				root = null;
			// Obtain the composite frames.
			for (int compositeFrameId = from; compositeFrameId <= to; compositeFrameId++)
				LoadOrReloadCompositeFrame(compositeFrameId);
		}

		public void LoadOrReloadRangeOfCompositeFrames(List<int> compositeFrameIdList, bool reloadRoot = false)
		{
			// Force the XML to be re-tokenized.
			if (reloadRoot)
				root = null;
			// Obtain the composite frames.
			foreach(int compositeFrameId in compositeFrameIdList)
				LoadOrReloadCompositeFrame(compositeFrameId);
		}

		public void LoadOrReloadCompositeFrame(int compositeFrameId, bool reloadRoot = false)
		{
			// Force the XML to be re-tokenized.
			if (reloadRoot)
				root = null;
			// Obtain the per-composite frame RenderableFrameCalls.
			CompositeFrames[compositeFrameId] = SupportFunctions.GetListOfFrameCallsFromCompositeFrame(copyFromFrame: compositeFrameId, root: Root);
			// Write out the named attachments for easy use.
			List<int> listOfUsedNamedAttachments = new List<int>();
			CompositeFrames[compositeFrameId].ForEach(delegate(Shapes.FrameCall call) {
				int id = 0;
				bool parsed = int.TryParse(call.NamedAttachmentPointId, out id);
				if (parsed && !listOfUsedNamedAttachments.Contains(id))
					listOfUsedNamedAttachments.Add(id);
			});
			CompositeFramesWithNamedAttachments[compositeFrameId] = listOfUsedNamedAttachments;
		}

		public List<RenderableFrameCall> GetRenderableFrameCallsForCompositeFrameId(int id)
		{
			if (CompositeFrames.ContainsKey(id))
			{
				List<Shapes.FrameCall> calls = CompositeFrames[id];
				List<RenderableFrameCall> renderableCalls = new List<RenderableFrameCall>();
				foreach (Shapes.FrameCall call in calls)
					renderableCalls.Add(new RenderableFrameCall(call, format: this));
				return renderableCalls;
			}
			else
				return new List<RenderableFrameCall>();
		}

		public Shapes.Frame GetFrameFromFrameCall(Shapes.FrameCall call)
		{
			int id = int.Parse(call.id);
			Shapes.Frame frame = AvailableFrameList.Find(item => item.id == id);
			return (frame != null) ? frame : null;
		}

		public Shapes.Tween GetTweenFromFrameCall(Shapes.FrameCall call)
		{
			Shapes.Tween tween = AvailableTweenList.Find(item => item.id == call.TweenId);
			return (tween != null) ? tween : null;
		}

		public Shapes.NamedAttachmentPoint GetNamedAttachmentPointFromFrameCall(Shapes.FrameCall call)
		{
			int id = 0;
			Shapes.NamedAttachmentPoint point = null;
			int.TryParse(call.NamedAttachmentPointId, out id);
			point = availableNamedAttachmentPointsList.Find(item => item.id == id);
			return point;
		}

		public System.Drawing.Color GetColorFromFrameCall(Shapes.FrameCall call)
		{
			System.Drawing.Color color = System.Drawing.Color.White;
			bool frameCallHasColor = false;
			if (call.colorName != null && call.colorName != "")
			{
				frameCallHasColor = true;
				Shapes.Color frameCallColor = AvailableColorList.Find(item => item.name == call.colorName);
				if (frameCallColor != null)
					color = frameCallColor.color;
				else
					frameCallHasColor = false;
			}
			//
			bool tweenHasColor = false;
			Shapes.Tween thisTween = null;
			if (call.TweenId != "0")
			{
				thisTween = AvailableTweenList.Find(item => item.id == call.TweenId);
				if (thisTween != null)
				{
					if (thisTween.HasColorComponent)
					{
						tweenHasColor = true;
						if (!frameCallHasColor)
							color = thisTween.colorFromFrame(call.FrameInTween);
					}
				}
			}
			//
			if (!frameCallHasColor && !tweenHasColor)
			{
				Shapes.Frame frame = GetFrameFromFrameCall(call);
				// Try to get color off of frame definition (as opposed to frame call; default is white).
				string originalColorName = (frame != null) ? frame.color : null;
				if (originalColorName != null)
				{
					Shapes.Color originalFrameColor = AvailableColorList.Find(item => item.name == originalColorName);
					color = (originalFrameColor != null) ? originalFrameColor.color : System.Drawing.Color.White;
				}
			}
			//
			return color;
		}

		public Shapes.Point GetTotalOffsetFromFrameCall(Shapes.FrameCall call)
		{
			Shapes.Tween thisTween = GetTweenFromFrameCall(call);
			double layerOffsetX = call.OffsetX, layerOffsetY = call.OffsetY, layerOffsetZ = call.OffsetZ;
			if (thisTween != null)
			{
				Shapes.Point offset = thisTween.XYZFromFrame(call.FrameInTween);
				layerOffsetX += offset.X;
				layerOffsetY += offset.Y;
				layerOffsetZ += offset.Z;
			}
			return new Shapes.Point(layerOffsetX, layerOffsetY, layerOffsetZ);
		}
	}
}
