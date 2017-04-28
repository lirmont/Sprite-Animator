using System.Collections.Generic;
using System.Drawing;

namespace SpriteAnimator.SupportClasses
{
	abstract public class Renderer
	{
		private string name;
		private bool requiresReloadOnSamplingChange = false;
		//
		private string renderer;
		private string version;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Technology
		{
			get { return string.Format("{0} ({1})", new object[] { renderer, version}); }
		}

		public string TechnologyName
		{
			get { return renderer; }
			set { renderer = value; }
		}

		public string Version
		{
			get { return version; }
			set { version = value; }
		}

		public bool RequiresReloadOnSamplingChange
		{
			get { return requiresReloadOnSamplingChange; }
			set { requiresReloadOnSamplingChange = value; }
		}

		public Renderer(string name, string renderer, string version, bool requiresReloadOnSamplingChange = false)
		{
			this.name = name;
			this.renderer = renderer;
			this.version = version;
			this.requiresReloadOnSamplingChange = requiresReloadOnSamplingChange;
		}

		abstract public Bitmap renderCompositeFrameToBitmap(Rectangle backBufferRectangle, int thisCompositeFrameId, Format format, Dictionary<int, ImageDescription> namedAttachments, ImageDescription image);

		public override string ToString()
		{
			return string.Format("{0} Renderer: {1}", new object[] { name, Technology });
		}
	}
}
