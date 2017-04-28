using System.Windows.Forms;

namespace SpriteAnimator
{
	partial class SupportFunctions
	{
		public static void RemoveSelectedListViewItems(ListView control)
		{
			if (control.SelectedIndices.Count > 0)
			{
				ListView.SelectedIndexCollection indices = control.SelectedIndices;
				for (int i = indices.Count - 1; i >= 0; i--)
					control.Items.RemoveAt(indices[i]);
			}
		}
	}
}
