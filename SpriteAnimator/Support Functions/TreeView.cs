using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SpriteAnimator
{
	partial class SupportFunctions
	{
		/// <summary>
		/// Consumes a dictionary, yielding a TreeNode.
		/// </summary>
		/// <param name="dictionary"> {
		///		{"name", "Displayed Text"},
		///		{"icon", indexOfIconInTreeViewStorageToShowAtLeft},
		///		{"tag", arbitraryObjectToBeAttachedToTreeNode},
		///		{"children", listOfDictionariesLikeThisOne}
		/// }</param>
		/// <returns>Returns a TreeNode for use with a TreeView.</returns>
		public static TreeNode consumeDictionaryNode(Dictionary<string, object> dictionary)
		{
			int iconIndex = (dictionary.ContainsKey("icon") && dictionary["icon"] != null) ? (int)dictionary["icon"] : 0;
			List<Dictionary<string, object>> children = (dictionary.ContainsKey("children") && dictionary["children"] != null) ? (List<Dictionary<string, object>>)dictionary["children"] : null;
			TreeNode thisTreeNode = new TreeNode(
				dictionary["name"] as string,
				iconIndex,
				iconIndex,
				consumeListOfDictionaryNodes(children)
			);
			thisTreeNode.Tag = (dictionary.ContainsKey("tag")) ? dictionary["tag"] : null;
			return thisTreeNode;
		}

		/// <summary>
		/// Consumes a list of dictionary objects, yielding an array of TreeNodes.
		/// </summary>
		/// <param name="children">List of dictionaries consumable by the consumeDictionaryNode function.</param>
		/// <returns>Returns an array of TreeNode objects, representing a TreeView's Nodes.</returns>
		public static TreeNode[] consumeListOfDictionaryNodes(List<Dictionary<string, object>> children)
		{
			List<TreeNode> treeNodes = new List<TreeNode>();
			if (children != null)
				children.ForEach(delegate(Dictionary<string, object> dictionary)
				{
					treeNodes.Add(consumeDictionaryNode(dictionary));
				});
			return treeNodes.ToArray();
		}

		/// <summary>
		/// Consumes a list of Color objects, yielding a list of consumable dictionary objects.
		/// </summary>
		/// <param name="colorList">A list of Shapes.Color objects.</param>
		/// <returns>Returns a list of dictionaries fit for consumption by the consumeListOfDictionaryNodes.</returns>
		public static List<Dictionary<string, object>> compileListOfDictionaryNodesRepresentingColorList(List<Shapes.Color> colorList)
		{
			List<Dictionary<string, object>> availableColors = new List<Dictionary<string, object>>();
			foreach (Shapes.Color thisColor in colorList)
				availableColors.Add(compileDictionaryNodeRepresentingColor(thisColor));
			return availableColors;
		}

		/// <summary>
		/// Consumes a Color object, yielding a consumable dictionary object.
		/// </summary>
		/// <param name="color">A Shapes.Color object.</param>
		/// <returns>Returns a dictionary object, fit for consumption by the consumeDictionaryNode function.</returns>
		public static Dictionary<string, object> compileDictionaryNodeRepresentingColor(Shapes.Color color)
		{
			return new Dictionary<string, object> {
				{"name", color.name},
				{"icon", 2},
				{"children",
					new List<Dictionary<string, object>> {
						new Dictionary<string, object> {
							{"name", "Red:"},
							{"icon", 4},
							{"tag", color.R * 255.0}
						},
						new Dictionary<string, object> {
							{"name", "Green:"},
							{"icon", 4},
							{"tag", color.G * 255.0}
						},
						new Dictionary<string, object> {
							{"name", "Blue:"},
							{"icon", 4},
							{"tag", color.B * 255.0}
						},
						new Dictionary<string, object> {
							{"name", "Alpha:"},
							{"icon", 4},
							{"tag", color.A * 255.0}
						}
					}
				}
			};
		}

		/// <summary>
		/// Consumes a list of Line objects, yielding a list of consumable dictionaries.
		/// </summary>
		/// <param name="lineList">A list of Shapes.Line objects.</param>
		/// <returns>Returns a list of dictionaries fit for consumption by the consumeListOfDictionaryNodes function.</returns>
		public static List<Dictionary<string, object>> compileListOfDictionaryNodesRepresentingLines(List<Shapes.Line> lineList)
		{
			List<Dictionary<string, object>> lines = new List<Dictionary<string, object>>();
			// Add the first point.
			lines.Add(new Dictionary<string, object> {
				{"name", "Point:"},
				{"icon", 3},
				{"tag", string.Format("[{0}, {1}, {2}]", new object[] { lineList[0].Start.X, lineList[0].Start.Y, lineList[0].Start.Z })}
			});
			// Add the last point in each line that composes the tween.
			foreach (Shapes.Line l in lineList)
				lines.Add(new Dictionary<string, object> {
					{"name", "Point:"},
					{"icon", 3},
					{"tag", string.Format("[{0}, {1}, {2}]", new object[] { l.End.X, l.End.Y, l.End.Z })}
				});
			return lines;
		}

		/// <summary>
		/// Consume list of Tween objects, yielding a list of consumable dictionary objects.
		/// </summary>
		/// <param name="tweenList">A list of Shapes.Tween objects.</param>
		/// <returns>Returns a list of dictionaries, fit for consumption by the consumeListOfDictionaryNodes function.</returns>
		public static List<Dictionary<string, object>> compileListOfDictionaryNodesRepresentingTweenList(List<Shapes.Tween> tweenList)
		{
			List<Dictionary<string, object>> tweens = new List<Dictionary<string, object>>();
			foreach (Shapes.Tween thisTween in tweenList)
			{
				List<Dictionary<string, object>> tweenChildren = new List<Dictionary<string, object>>();
				// Add function type (default: linear).
				tweenChildren.Add(
					new Dictionary<string, object> {
						{"name", "Function:"},
						{"icon", 5},
						{"tag", thisTween.advancementFunction}
					}
				);
				// If it has points, show them beneath the "Points" hierarchy.
				if (thisTween.LineSegments.Count > 0)
				{
					tweenChildren.Add(
						new Dictionary<string, object> {
							{"name", "Points:"},
							{"icon", 8},
							{"tag", string.Format("length = {0} pixels", (int)Math.Round(thisTween.Length, 2))},
							{"children", compileListOfDictionaryNodesRepresentingLines(thisTween.LineSegments)}
						}
					);
				}
				// If it has colors, show them beneath the "Colors" hierarchy.
				if (thisTween.colorList.Count > 0)
				{
					tweenChildren.Add(
						new Dictionary<string, object> {
							{"name", "Colors:"},
							{"icon", 1},
							{"children", compileListOfDictionaryNodesRepresentingColorList(thisTween.Colors) }
						}
					);
				}
				// Create the parent entry, representing the Tween object as a whole.
				tweens.Add(
					new Dictionary<string, object> {
						{"name", "Tween " + thisTween.id},
						{"icon", 0},
						{"tag", null},
						{"children", tweenChildren }
					}
				);
			}
			return tweens;
		}

		/// <summary>
		/// Consumes a list of RenderableFrameCall objects, yielding a list of consumable dictionary objects. Extra information about the RenderableFrameCall, regarding named attachment points and tweens, is derived from the the extra 2 parameters.
		/// </summary>
		/// <param name="frameCalls">A list of RenderableFrameCall objects, representing the frame calls in a given composite frame.</param>
		/// <param name="namedAttachmentPoints">A list of Shapes.NamedAttachmentPoint objects, representing all available named attachment points in the given format.</param>
		/// <param name="availableTweens">A list of Shapes.Tween objects, representing all available tweens in the given format.</param>
		/// <returns>Returns a list of dictionaries, fit for consumption by the consumeListOfDictionaryNodes function.</returns>
		public static List<Dictionary<string, object>> compileListOfDictionaryNodesRepresentingFrameCalls(List<SupportClasses.RenderableFrameCall> frameCalls, List<Shapes.NamedAttachmentPoint> namedAttachmentPoints, List<Shapes.Tween> availableTweens)
		{
			List<Dictionary<string, object>> frames = new List<Dictionary<string, object>>();
			for (int frameLocationInStack = frameCalls.Count - 1; frameLocationInStack >= 0; frameLocationInStack--)
			{
				List<Dictionary<string, object>> children = new List<Dictionary<string, object>>();
				//
				SupportClasses.RenderableFrameCall f = frameCalls[frameLocationInStack];
				Shapes.Tween thisTween = availableTweens.Find(item => item.id == f.tween);
				Shapes.NamedAttachmentPoint point = namedAttachmentPoints.Find(thisItem => thisItem.id == f.namedAttachmentPointId);
				//
				frames.Add(
					new Dictionary<string, object> {
						{"name", string.Format("{0:D3}: Calls {1}{2}", new object[] { frameCalls.Count - frameLocationInStack, SupportFunctions.Ordinal(f.id), (point != null) ? ", \"" + (point.name) + "\"" : "" })},
						{"icon", 7},
						{"tag", (f.name != null) ? f.name : null},
						{"children", 
							new List<Dictionary<string, object>> {
								new Dictionary<string, object> {
									{"name", "Blending:"},
									{"icon", 5},
									{"tag", f.blendMode}
								},
								new Dictionary<string, object> {
									{"name", "Calls Frame:"},
									{"icon", 7},
									{"tag", SupportFunctions.Ordinal(f.id)}
								},
								new Dictionary<string, object> {
									{"name", "Color:"},
									{"icon", 2},
									{"tag", string.Format("[{0}, {1}, {2}, {3}]", new object[] { f.color.R, f.color.G, f.color.B, f.color.A })}
								},
								new Dictionary<string, object> {
									{"name", "Tween:"},
									{"icon", 0},
									{"tag", (f.tween != "0") ? f.tween : "N/A"}
								},
								new Dictionary<string, object> {
									{"name", "T-Frame:"},
									{"icon", 7},
									{"tag", (f.tween != "0") ? f.frameInTween.ToString() : "N/A"}
								},
								new Dictionary<string, object> {
									{"name", "Dimensions:"},
									{"icon", 8},
									{"tag", string.Format("[{0}, {1}]", new object[] { f.bound.Width, f.bound.Height })}
								},
								new Dictionary<string, object> {
									{"name", "Offset:"},
									{"icon", 3},
									{"tag", string.Format("[{0}, {1}, {2}]", new object[] { f.bound.X, f.bound.Y, f.OffsetZ })}
								},
								new Dictionary<string, object> {
									{"name", "Scale:"},
									{"icon", 3},
									{"tag", string.Format("[{0}, {1}]", new object[] { f.scaleX, f.scaleY })}
								},
								new Dictionary<string, object> {
									{"name", "Rotation:"},
									{"icon", 3},
									{"tag", string.Format("{0}°", f.rotationZ)}
								}
							}
						}
					}
				);
			}
			return frames;
		}
	}
}
