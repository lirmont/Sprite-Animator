using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SpriteAnimator
{
	partial class SupportFunctions
	{
		public static List<string> GetAvailableFormats(string baseLocation = null) {
			baseLocation = baseLocation ?? GetBaseLocation();
			List<string> availableTypes = new List<string>();
			if (Directory.Exists(baseLocation + @"\formats"))
			{
				string[] formatFolders = Directory.GetDirectories(baseLocation + @"\formats");
				//
				foreach (string fn in formatFolders)
					if (File.Exists(fn + @"\sprite.xml"))
						availableTypes.Add( new System.IO.DirectoryInfo(fn).Name );
			}
			return availableTypes;
		}

		public static string GetBaseLocation() {
			return Path.GetDirectoryName(Application.ExecutablePath);
		}

		public static string Combine(params string[] paths) {
			if (paths == null)
				return null;
			string currentPath = paths[0];
			for (int i = 1; i < paths.Length; i++)
				currentPath = Path.Combine(currentPath, paths[i]);
			return currentPath;
		}
	}
}
