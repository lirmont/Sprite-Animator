using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using SpriteAnimator.SupportClasses;

#pragma warning disable
namespace SpriteAnimator
{
	public partial class AddOrEditTween : Form
	{
		// Guide lines.
		private List<Shapes.Guide> guides = new List<Shapes.Guide>();
		// Available Colors.
		private List<Shapes.Color> colors = new List<Shapes.Color>();
		// Actual Colors.
		private List<string> colorsUsedInOrder = new List<string>();
		// Points.
		private List<Shapes.Point> points = new List<Shapes.Point>();
		private string id = "";
		private string advancementFunction = "linear";
		private int lengthInFrames = 1;

		public int LengthInFrames
		{
			get { return (int)lengthInFramesNumericUpDown.Value; }
			set
			{
				lengthInFramesNumericUpDown.Value = lengthInFrames = value;
			}
		}
		private bool hitTestPassed = false;
		private int isDraggingIndex = -1;
		private ListView contextMenuSender = null;

		public string AdvancementFunction
		{
			get { return advancementFunctionComboBox.Text; }
			set { advancementFunctionComboBox.Text = advancementFunction = value; }
		}

		public string Id
		{
			get { return idMaskedTextBox.Text; }
			set { idMaskedTextBox.Text = id = value; }
		}

		Shapes.Point getPointFromIndex(int i)
		{
			double x = 0, y = 0, z = 0;
			if (coordinatesListView.Items[i].Text != "")
			{
				double.TryParse(coordinatesListView.Items[i].SubItems[0].Text, out x);
				double.TryParse(coordinatesListView.Items[i].SubItems[1].Text, out y);
				double.TryParse(coordinatesListView.Items[i].SubItems[2].Text, out z);
			}
			return new Shapes.Point(x, y, z);
		}

		public List<Shapes.Point> Points
		{
			get
			{
				List<Shapes.Point> pointsList = new List<Shapes.Point>();
				for (int i = 0; i < coordinatesListView.Items.Count; i++)
				{
					pointsList.Add(getPointFromIndex(i));
				}
				return pointsList;
			}
			set
			{
				points = value;
				foreach (Shapes.Point p in value)
				{
					coordinatesListView.Items.Add(
						new ListViewItem(
							new string[] { 
								p.X.ToString(), p.Y.ToString(), p.Z.ToString()
							}
						)
					);
				}
			}
		}

		public List<string> ColorsUsedInOrder
		{
			get
			{
				List<string> usedColorList = new List<string>();
				foreach (ListViewItem s in colorsListView.Items)
				{
					usedColorList.Add(s.Text);
				}
				return usedColorList;
			}
			set
			{
				colorsUsedInOrder = value;
				colorsListView.Items.Clear();
				foreach (string s in value)
				{
					colorsListView.Items.Add(s);
				}
			}
		}

		public List<Color> ColorList
		{
			get
			{
				List<Color> c = new List<Color>();
				ColorsUsedInOrder.ForEach(delegate(string s)
				{
					Shapes.Color foundColor = colors.Find(item => item.name == s);
					if (foundColor != null)
						c.Add(Color.FromArgb((int)(foundColor.A * 255.0), (int)(foundColor.R * 255.0), (int)(foundColor.G * 255.0), (int)(foundColor.B * 255.0)));
					else
						c.Add(Color.White);
				});
				return c;
			}
		}
		public List<Shapes.Color> Colors
		{
			get
			{
				return colors;
			}
			set { colors = value; }
		}

		public List<Shapes.Guide> Guides
		{
			get { return guides; }
			set { guides = value; }
		}

		private Color backgroundColor = Color.Black;
		private int targetMilliseconds = 20;
		private int startMilliseconds = 0, currentMilliseconds = 0;
		private System.Threading.Timer scheduleRedraw;
		private bool forceRedraw = false;
		private double scaleX = 1, scaleY = 1, scaleZ = 1;
		private double gutterX = 0, gutterY = 0;
		private double sceneRotationX = 0, sceneRotationY = 0, sceneRotationZ = 0;
		private int frameWidth = 0, frameHeight = 0;
		private double circleSize = 3;
		private double[] currentProjectionMatrix = new double[16], currentModelviewMatrix = new double[16];
		private int[] currentViewportMatrix = new int[4];

		public int FrameHeight
		{
			get { return frameHeight; }
			set
			{
				frameHeight = value;
				halfHeight = value / 2.0;
				heightValueLabel.Text = value.ToString();
			}
		}

		public int FrameWidth
		{
			get { return frameWidth; }
			set
			{
				frameWidth = value;
				halfWidth = value / 2.0;
				widthValueLabel.Text = value.ToString();
			}
		}

		private int CursorX
		{
			get
			{
				return Cursor.Position.X - this.simpleOpenGlControl.PointToScreen(new Point(0, 0)).X;
			}
		}

		private int CursorY
		{
			get
			{
				return Cursor.Position.Y - this.simpleOpenGlControl.PointToScreen(new Point(0, 0)).Y;
			}
		}

		private int cursorDeltaX = 0, cursorDeltaY = 0;

		private int CursorDeltaY
		{
			get { return cursorDeltaY; }
			set { cursorDeltaY = value; }
		}

		private int CursorDeltaX
		{
			get { return cursorDeltaX; }
			set { cursorDeltaX = value; }
		}

		private int cursorLastX = 0, cursorLastY = 0;

		private int CursorLastY
		{
			get { return cursorLastY; }
			set { cursorLastY = value; }
		}

		private int CursorLastX
		{
			get { return cursorLastX; }
			set { cursorLastX = value; }
		}

		// Input
		private List<Input> inputInterface = new List<Input>();

		private void populateInputInterface()
		{
			// Handle mouse movement.
			inputInterface.AddRange(new List<Input>{
				new Input(Keys.NumPad1, handler: delegate(Input i) {
					sceneRotationX = sceneRotationY = sceneRotationZ = 0;
				}),
				new Input(Keys.NumPad6, handler: delegate(Input i) {
					sceneRotationY -= 15;
				}),
				new Input(Keys.NumPad4, handler: delegate(Input i) {
					sceneRotationY += 15;
				}),
				new Input(Keys.NumPad8, handler: delegate(Input i) {
					sceneRotationX -= 15;
				}),
				new Input(Keys.NumPad2, handler: delegate(Input i) {
					sceneRotationX += 15;
				})
			});
		}

		#region Form-Level Key Down/Key Press Events
		private List<Keys> keysOnlyAvailableInKeyDown = new List<Keys> { Keys.Escape, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9 };
		private void AddOrEditTween_KeyDown(object sender, KeyEventArgs e)
		{

			if (keysOnlyAvailableInKeyDown.Contains(e.KeyCode))
			{
				Input foundInput = inputInterface.Find(item => item.signature == string.Format("{0}", e.KeyCode));
				if (foundInput != null)
				{
					foundInput.activate();
					foundInput.handler(foundInput);
					foundInput.deactivate();
				}
			}
		}

		private void AddOrEditTween_KeyPress(object sender, KeyPressEventArgs e)
		{
			Input foundInput = inputInterface.Find(item => item.signature == string.Format("{0}", Char.ToLower(e.KeyChar)) || item.signature == string.Format("{0}", Char.ToUpper(e.KeyChar)));
			if (foundInput != null)
			{
				foundInput.activate();
				foundInput.handler(foundInput);
				foundInput.deactivate();
			}
		}
		#endregion

		TextBox TxtEdit;
		double halfWidth = 0, halfHeight = 0;
		public AddOrEditTween()
		{
			InitializeComponent();
			//
			populateInputInterface();
			//
			TxtEdit = new TextBox();
			TxtEdit.BorderStyle = BorderStyle.None;
			TxtEdit.Visible = false;
			TxtEdit.KeyUp += TxtEdit_KeyUp;
			TxtEdit.Leave += TxtEdit_Leave;
			TxtEdit.MouseLeave += new EventHandler(TxtEdit_MouseLeave);
			this.Controls.Add(TxtEdit);
			//
			simpleOpenGlControl.InitializeContexts();
			#region Scheduled re-draw and last write scan tasks.
			scheduleRedraw = new System.Threading.Timer(delegate(object data)
			{
				currentMilliseconds = Environment.TickCount & Int32.MaxValue;
				if (targetMilliseconds <= currentMilliseconds - startMilliseconds || forceRedraw)
					simpleOpenGlControl.Draw();
			}, "Redrawing Render Control", targetMilliseconds, targetMilliseconds);
			#endregion
			simpleOpenGlControl1_Resize(null, null);
			Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
		}

		private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
		{
			if (simpleOpenGlControl.Width == frameWidth && simpleOpenGlControl.Height == frameHeight)
				gutterX = gutterY = 0;
			else if (simpleOpenGlControl.Width >= frameWidth
				 && (this.Height - System.Windows.Forms.SystemInformation.CaptionHeight) <= frameHeight)
			{
				gutterX = (int)((simpleOpenGlControl.Width - scaleX * frameWidth) / 2.0);
				gutterY = 0;
			}
			else
			{
				gutterX = (int)((simpleOpenGlControl.Width - scaleX * frameWidth) / 2.0);
				gutterY = (int)((simpleOpenGlControl.Height - scaleY * frameHeight) / 2.0);
			}
		}

		private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
		{
			simpleOpenGlControl.MakeCurrent();
			Gl.glViewport(0, 0, simpleOpenGlControl.Width, simpleOpenGlControl.Height);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Glu.gluPerspective(45.0f, ((float)(simpleOpenGlControl.Width) / (float)(simpleOpenGlControl.Height)), 0.1f, 2.0f);
			Gl.glClearColor(backgroundColor.R / 255f, backgroundColor.G / 255f, backgroundColor.B / 255f, 0f);
			Gl.glEnable(Gl.GL_LINE_SMOOTH);
			Gl.glEnable(Gl.GL_BLEND);
			Gl.glEnable(Gl.GL_DEPTH_TEST);
			Gl.glDepthFunc(Gl.GL_LEQUAL);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
			SupportFunctions.pushScreenCoordinateMatrix(0, simpleOpenGlControl.Width, simpleOpenGlControl.Height, 0, near: -frameWidth * 2, far: frameWidth * 2);
			{
				simpleOpenGlControl1_Draw();
			}
			SupportFunctions.pop_projection_matrix();
		}

		private void simpleOpenGlControl1_Draw()
		{
			#region Set up color list.
			List<Color> colorList = new List<Color>();
			if (colorsListView.Items.Count == 0)
			{
				colorList.Add(Color.White);
				colorList.Add(Color.White);
			}
			else if (colorsListView.Items.Count == 1)
			{
				foreach (ListViewItem item in colorsListView.Items)
				{
					Shapes.Color c = colors.Find(findObject => findObject.name == item.SubItems[0].Text);
					if (c != null)
					{
						colorList.Add(c.color);
						colorList.Add(c.color);
					}
					else
					{
						colorList.Add(Color.White);
						colorList.Add(Color.White);
					}
				}
			}
			else
			{
				foreach (ListViewItem item in colorsListView.Items)
				{
					Shapes.Color c = colors.Find(findObject => findObject.name == item.SubItems[0].Text);
					if (c != null)
						colorList.Add(c.color);
					else
						colorList.Add(Color.White);
				}
			}
			Shapes.Point previousPoint = null;
			double totalDistance = 0;
			double runningDistance = 0;
			for (int i = 0; i < coordinatesListView.Items.Count; i++)
			{
				Shapes.Point p = getPointFromIndex(i);
				double x = p.x, y = p.y, z = p.z;
				if (previousPoint == null)
					previousPoint = new Shapes.Point(x, y, z);
				Shapes.Line line = new Shapes.Line(previousPoint, new Shapes.Point(x, y, z));
				totalDistance += line.Length;
				previousPoint = new Shapes.Point(x, y, z);
			}
			#endregion
			Gl.glColor3d(1, 1, 1);
			Gl.glDisable(Gl.GL_CULL_FACE);
			Gl.glPushMatrix();
			{
				Gl.glTranslated(gutterX + scaleX * halfWidth, gutterY + scaleY * halfHeight, 0);
				Gl.glScaled(scaleX, scaleY, scaleZ);
				//
				Gl.glRotated(sceneRotationX, 1, 0, 0);
				Gl.glRotated(sceneRotationY, 0, 1, 0);
				Gl.glRotated(sceneRotationZ, 0, 0, 1);
				// Draw bounding box.
				SupportFunctions.DrawBoundingBox(halfWidth, halfHeight, halfDepth: halfWidth);
				//
				Gl.glPushMatrix();
				{
					Gl.glTranslated(-halfWidth, -halfHeight, 0);
					//
					Gl.glGetDoublev(Gl.GL_PROJECTION_MATRIX, currentProjectionMatrix);
					Gl.glGetDoublev(Gl.GL_MODELVIEW_MATRIX, currentModelviewMatrix);
					Gl.glGetIntegerv(Gl.GL_VIEWPORT, currentViewportMatrix);
					//
					#region Draw blue guides.
					SupportFunctions.setBlendMode("lighten");
					SupportFunctions.DrawGuideLines(frameWidth, frameHeight, guides);
					#endregion
					#region Draw motion tween.
					if (coordinatesListView.Items.Count > 0)
					{
						// Draw Points as Line Segments.
						SupportFunctions.setBlendMode("line");
						Gl.glLineWidth((float)Math.Max(1.5f, Math.Min(3.0f, circleSize)));
						Gl.glColor4d(1, 1, 1, 1);
						Gl.glBegin(Gl.GL_LINE_STRIP);
						{
							previousPoint = null;
							runningDistance = 0;
							for (int i = 0; i < coordinatesListView.Items.Count; i++)
							{
								Shapes.Point p = getPointFromIndex(i);
								double x = p.x, y = p.y, z = p.z;
								if (previousPoint == null)
									previousPoint = new Shapes.Point(x, y, z);
								Shapes.Line line = new Shapes.Line(previousPoint, new Shapes.Point(x, y, z));
								runningDistance += line.Length;
								Color thisColor = Color.White;
								double zeroToOneIndex = (runningDistance / totalDistance);
								int startIndex = 0, endIndex = 0;
								double zeroToOneStartIndex = 0, zeroToOneEndIndex = 1.0;
								for (int r = 0; r < colorList.Count; r++)
								{
									double thisZeroToOneIndex = (double)(r + 1) / (double)(colorList.Count);
									if (thisZeroToOneIndex == zeroToOneIndex)
									{
										startIndex = endIndex = r;
										zeroToOneStartIndex = zeroToOneEndIndex = zeroToOneIndex;
									}
									else if (thisZeroToOneIndex >= zeroToOneIndex)
									{
										endIndex = r;
										zeroToOneEndIndex = thisZeroToOneIndex;
										break;
									}
									else
									{
										startIndex = r;
										zeroToOneStartIndex = thisZeroToOneIndex;
									}
								}
								double transitionPercent = (zeroToOneIndex - zeroToOneStartIndex) / (zeroToOneEndIndex - zeroToOneStartIndex);
								if (double.IsNaN(transitionPercent) || double.IsInfinity(transitionPercent))
									transitionPercent = .5;
								thisColor = System.Drawing.Color.FromArgb(
									(int)((1 - transitionPercent) * colorList[startIndex].A + transitionPercent * colorList[endIndex].A),
									(int)((1 - transitionPercent) * colorList[startIndex].R + transitionPercent * colorList[endIndex].R),
									(int)((1 - transitionPercent) * colorList[startIndex].G + transitionPercent * colorList[endIndex].G),
									(int)((1 - transitionPercent) * colorList[startIndex].B + transitionPercent * colorList[endIndex].B)
								);
								Gl.glColor4d(thisColor.R / 255.0, thisColor.G / 255.0, thisColor.B / 255.0, thisColor.A / 255.0);
								Gl.glVertex3d(x, y, z);
								previousPoint = new Shapes.Point(x, y, z);
							}
						}
						Gl.glEnd();
						// Draw Points as Points.
						if (coordinatesListView.Items.Count > 0)
						{
							Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ZERO);
							previousPoint = null;
							runningDistance = 0;
							for (int i = 0; i < coordinatesListView.Items.Count; i++)
							{
								Gl.glPushMatrix();
								{
									Shapes.Point p = getPointFromIndex(i);
									double x = p.x, y = p.y, z = p.z;
									if (previousPoint == null)
										previousPoint = new Shapes.Point(x, y, z);
									Shapes.Line line = new Shapes.Line(previousPoint, new Shapes.Point(x, y, z));
									runningDistance += line.Length;
									Color thisColor = Color.White;
									double zeroToOneIndex = (runningDistance / totalDistance);
									int startIndex = 0, endIndex = 0;
									double zeroToOneStartIndex = 0, zeroToOneEndIndex = 1.0;
									for (int r = 0; r < colorList.Count; r++)
									{
										double thisZeroToOneIndex = (double)(r + 1) / (double)(colorList.Count);
										if (thisZeroToOneIndex == zeroToOneIndex)
										{
											startIndex = endIndex = r;
											zeroToOneStartIndex = zeroToOneEndIndex = zeroToOneIndex;
										}
										else if (thisZeroToOneIndex >= zeroToOneIndex)
										{
											endIndex = r;
											zeroToOneEndIndex = thisZeroToOneIndex;
											break;
										}
										else
										{
											startIndex = r;
											zeroToOneStartIndex = thisZeroToOneIndex;
										}
									}
									double transitionPercent = (zeroToOneIndex - zeroToOneStartIndex) / (zeroToOneEndIndex - zeroToOneStartIndex);
									if (double.IsNaN(transitionPercent) || double.IsInfinity(transitionPercent))
										transitionPercent = .5;
									thisColor = System.Drawing.Color.FromArgb(
										(int)((1 - transitionPercent) * colorList[startIndex].A + transitionPercent * colorList[endIndex].A),
										(int)((1 - transitionPercent) * colorList[startIndex].R + transitionPercent * colorList[endIndex].R),
										(int)((1 - transitionPercent) * colorList[startIndex].G + transitionPercent * colorList[endIndex].G),
										(int)((1 - transitionPercent) * colorList[startIndex].B + transitionPercent * colorList[endIndex].B)
									);
									Gl.glTranslated(x, y, z);
									Gl.glRotated(180 - sceneRotationX, 1, 0, 0);
									Gl.glRotated(180 + sceneRotationY, 0, 1, 0);
									Gl.glRotated(sceneRotationZ, 0, 0, 1);
									if (coordinatesListView.Items[i].Selected)
										SupportFunctions.drawCircle(r: circleSize, fill: Color.FromArgb(255, 184, 184, 226), outline: thisColor);
									else
										SupportFunctions.drawCircle(r: circleSize, outline: thisColor);
									previousPoint = new Shapes.Point(x, y, z);
								}
								Gl.glPopMatrix();
							}
						}
					}
					#endregion
					#region Draw color gradient.
					if (sceneRotationX == 0 && sceneRotationY == 0 && sceneRotationZ == 0)
					{
						Gl.glPushMatrix();
						{
							Gl.glLineWidth(2);
							SupportFunctions.setBlendMode("line");
							Gl.glTranslated(0, frameHeight + 2, 0);
							Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
							{
								for (int index = 0; index < colorList.Count; index++)
								{
									Gl.glColor4d(colorList[index].R / 255.0, colorList[index].G / 255.0, colorList[index].B / 255.0, colorList[index].A / 255.0);
									if (index == 0)
									{
										Gl.glVertex2d(0, 10);
										Gl.glVertex2d(0, 0);
									}
									else if (index == colorList.Count - 1)
									{
										Gl.glVertex2d(frameWidth, 10);
										Gl.glVertex2d(frameWidth, 0);
									}
									else
									{
										double zeroToOneIndex = (index) / (colorList.Count - 1.0);
										Gl.glVertex2d(frameWidth * zeroToOneIndex, 10);
										Gl.glVertex2d(frameWidth * zeroToOneIndex, 0);
									}
								}
							}
							Gl.glEnd();
						}
						Gl.glPopMatrix();
					}
					#endregion
				}
				Gl.glPopMatrix();
			}
			Gl.glPopMatrix();
			// Cursor.
			if (!hitTestPassed)
				SupportFunctions.DrawNoActionAvailableCursor(CursorX, CursorY, frameWidth);
		}

		private bool pointIsBeneathCursor(Shapes.Point thisPoint)
		{
			//
			Glu.gluProject(thisPoint.X, thisPoint.Y, thisPoint.Z, currentModelviewMatrix, currentProjectionMatrix, currentViewportMatrix, out thisPoint.X, out thisPoint.Y, out thisPoint.Z);
			thisPoint.Y = simpleOpenGlControl.Height - thisPoint.Y;
			// Create hit box.
			Shapes.Point[] hitBox = new Shapes.Point[] {
				new Shapes.Point(thisPoint.X + circleSize * scaleX, thisPoint.Y + circleSize * scaleY, thisPoint.Z),
				new Shapes.Point(thisPoint.X + circleSize * scaleX, thisPoint.Y - circleSize * scaleY, thisPoint.Z),
				new Shapes.Point(thisPoint.X - circleSize * scaleX, thisPoint.Y - circleSize * scaleY, thisPoint.Z),
				new Shapes.Point(thisPoint.X - circleSize * scaleX, thisPoint.Y + circleSize * scaleY, thisPoint.Z)
			};
			//
			return SupportFunctions.PointIsInPolygon(hitBox, new Shapes.Point(CursorX, CursorY));
		}

		private void AddOrEditTween_Shown(object sender, EventArgs e)
		{
			idLabel.Focus();
		}

		private void removeEntryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (contextMenuSender != null)
			{
				ListView view = contextMenuSender as ListView;
				if (view.SelectedIndices.Count > 0)
				{
					int selectedIndex = view.SelectedIndices[0];
					if (view != null)
					{
						if (view.Items.Count - 1 >= selectedIndex)
							view.Items.RemoveAt(selectedIndex);
					}
				}
			}
		}

		private void addEntryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (contextMenuSender != null)
			{
				ListView view = contextMenuSender as ListView;
				if (view != null)
				{
					foreach (ListViewItem item in view.Items)
						item.Selected = false;
					view.Items.Add(new ListViewItem(new string[] { "" }));
					view.Items[view.Items.Count - 1].Selected = true;
					view.SelectedItems[0].BeginEdit();
				}
			}
		}

		private void moveEntryUpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (contextMenuSender != null)
			{
				ListView view = contextMenuSender;
				int selectedIndex = view.SelectedIndices[0];
				if (view != null)
				{
					ListViewItem item = view.Items[selectedIndex - 1];
					ListViewItem replacingItem = view.Items[selectedIndex];
					view.Items[selectedIndex - 1] = new ListViewItem("");
					view.Items[selectedIndex] = new ListViewItem("");
					view.Items[selectedIndex - 1] = replacingItem;
					view.Items[selectedIndex] = item;
				}
			}
		}

		private void moveEntryDownToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (contextMenuSender != null)
			{
				ListView view = contextMenuSender;
				int selectedIndex = view.SelectedIndices[0];
				if (view != null)
				{
					ListViewItem item = view.Items[selectedIndex + 1];
					ListViewItem replacingItem = view.Items[selectedIndex];
					view.Items[selectedIndex + 1] = new ListViewItem("");
					view.Items[selectedIndex] = new ListViewItem("");
					view.Items[selectedIndex + 1] = replacingItem;
					view.Items[selectedIndex] = item;
				}
			}
		}

		private void clearEntriesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (contextMenuSender != null)
			{
				// Prepare which list to act on.
				ListView view = contextMenuSender;
				// Clear the list.
				if (view != null)
					view.Items.Clear();
			}
		}

		private void sharedContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			if (contextMenuSender != null)
			{
				ListView view = contextMenuSender as ListView;
				if (view.SelectedIndices.Count >= 1)
				{
					moveEntryUpToolStripMenuItem.Enabled = (view.SelectedIndices[0] != 0);
					moveEntryDownToolStripMenuItem.Enabled = (view.SelectedIndices[0] != view.Items.Count - 1);
				}
				else
				{
					moveEntryUpToolStripMenuItem.Enabled = false;
					moveEntryDownToolStripMenuItem.Enabled = false;
				}
				removeEntryToolStripMenuItem.Enabled = (view.SelectedIndices.Count != 0);
			}
		}

		private void magnifyButton_Click(object sender, EventArgs e)
		{
			scaleX += 1;
			scaleY += 1;
			simpleOpenGlControl1_Resize(sender, e);
		}

		private void minifyButton_Click(object sender, EventArgs e)
		{
			if (scaleX > 1)
				scaleX -= 1;
			if (scaleY > 1)
				scaleY -= 1;
			simpleOpenGlControl1_Resize(sender, e);
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
					float totalColumnWidth = 2;
					for (int i = 0; i < listView.Columns.Count; i++)
						totalColumnWidth += Convert.ToInt32(listView.Columns[i].Width);
					for (int i = 0; i < listView.Columns.Count; i++)
						listView.Columns[i].Width = (int)((Convert.ToInt32(listView.Columns[i].Width) / totalColumnWidth) * listView.ClientRectangle.Width);
				}
			}
			ResizingGeneric = false;
		}

		private void simpleOpenGlControl1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
			double numberOfPixelsToMove = (numberOfTextLinesToMove * (1.0 / 6.0));
			//
			if (scaleX + numberOfPixelsToMove > 1)
				scaleX += numberOfPixelsToMove;
			else
				scaleX = 1;
			//
			if (scaleY + numberOfPixelsToMove > 1)
				scaleY += numberOfPixelsToMove;
			else
				scaleY = 1;
			//
			simpleOpenGlControl1_Resize(sender, e);
		}

		private void simpleOpenGlControl1_MouseMove(object sender, MouseEventArgs e)
		{
			CursorDeltaX = CursorX - CursorLastX;
			CursorDeltaY = CursorY - CursorLastY;
			CursorLastX = e.X;
			CursorLastY = e.Y;
			//
			if (e.Button == MouseButtons.Middle)
			{
				double minorDx = CursorDeltaX / 1;
				double minorDy = CursorDeltaY / 1;
				gutterX += minorDx;
				gutterY += minorDy;
				return;
			}
			//
			if (isDraggingIndex < 0)
			{
				int selectedIndex = -1;
				for (int i = 0; i < coordinatesListView.Items.Count; i++)
				{
					Shapes.Point p = getPointFromIndex(i);
					if (pointIsBeneathCursor(p))
						selectedIndex = i;
				}
				if (selectedIndex >= 0)
				{
					hitTestPassed = true;
					this.Cursor = System.Windows.Forms.Cursors.Hand;
				}
				else
				{
					hitTestPassed = false;
					this.Cursor = System.Windows.Forms.Cursors.Arrow;
				}
			}
			else
			{
				double scaledCursorDeltaX = CursorDeltaX / scaleX;
				double scaledCursorDeltaY = CursorDeltaY / scaleY;
				// X component.
				double pXofY = scaledCursorDeltaX * (90 + (2 * sceneRotationY + 90)) / 180.0;
				double minorDx = pXofY;
				// Y component.
				double pYofX = scaledCursorDeltaY * (90 + (90 + 2 * sceneRotationX)) / 180.0;
				double minorDy = pYofX;
				// Z component.
				double pZofY = scaledCursorDeltaX * (90 + (-90 + 2 * sceneRotationY)) / 180.0;
				double pZofX = scaledCursorDeltaY * (90 + (-90 - 2 * sceneRotationX)) / 180.0;
				double minorDz = pZofY + pZofX;
				//
				Shapes.Point p = getPointFromIndex(isDraggingIndex);
				p += new Shapes.Point(minorDx, minorDy, minorDz);
				//
				if (false)
				{
					coordinatesListView.Items[isDraggingIndex].SubItems[0].Text = ((int)p.X).ToString();
					coordinatesListView.Items[isDraggingIndex].SubItems[1].Text = ((int)p.Y).ToString();
					coordinatesListView.Items[isDraggingIndex].SubItems[2].Text = ((int)p.Z).ToString();
				}
				else
				{
					coordinatesListView.Items[isDraggingIndex].SubItems[0].Text = p.X.ToString();
					coordinatesListView.Items[isDraggingIndex].SubItems[1].Text = p.Y.ToString();
					coordinatesListView.Items[isDraggingIndex].SubItems[2].Text = p.Z.ToString();
				}
			}
		}

		private void simpleOpenGlControl1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int previouslySelected = isDraggingIndex;
				isDraggingIndex = -1;
				for (int i = 0; i < coordinatesListView.Items.Count; i++)
				{
					Shapes.Point p = getPointFromIndex(i);
					if (pointIsBeneathCursor(p) && i != previouslySelected)
					{
						coordinatesListView.Items[i].Selected = true;
						isDraggingIndex = i;
					}
					else
						coordinatesListView.Items[i].Selected = false;
				}
			}
			else if (e.Button == System.Windows.Forms.MouseButtons.XButton1)
				circleSize = Math.Max(0, circleSize - 0.5);
			else if (e.Button == System.Windows.Forms.MouseButtons.XButton2)
				circleSize += 0.5;
		}

		private void simpleOpenGlControl1_MouseUp(object sender, MouseEventArgs e)
		{
			isDraggingIndex = -1;
			for (int i = 0; i < coordinatesListView.Items.Count; i++)
			{
				if (coordinatesListView.Items[i].Selected)
				{
					Shapes.Point p = getPointFromIndex(i);
					coordinatesListView.Items[i].Selected = false;
					// Round everything out.
					coordinatesListView.Items[i].SubItems[0].Text = ((int)Math.Round(p.X)).ToString();
					coordinatesListView.Items[i].SubItems[1].Text = ((int)Math.Round(p.Y)).ToString();
					coordinatesListView.Items[i].SubItems[2].Text = ((int)Math.Round(p.Z)).ToString();
				}
			}
		}

		private void coordinatesListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			advancementFunctionLabel.Focus();
		}

		private void coordinatesListView_Click(object sender, EventArgs e)
		{
			contextMenuSender = coordinatesListView;
		}

		private void coordinatesListView_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
				contextMenuSender = coordinatesListView;
		}

		private void colorsListView_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
				contextMenuSender = colorsListView;
		}

		private void simpleOpenGlControl1_MouseEnter(object sender, EventArgs e)
		{
			simpleOpenGlControl.Focus();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void colorsListView_MouseEnter(object sender, EventArgs e)
		{
			contextMenuSender = colorsListView;
		}

		private void coordinatesListView_MouseEnter(object sender, EventArgs e)
		{
			contextMenuSender = coordinatesListView;
		}

		private void simpleOpenGlControl1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				Shapes.Tween t = new Shapes.Tween(LengthInFrames, AdvancementFunction, Id, Points.ToArray(), ColorList.ToArray(), ColorsUsedInOrder.ToArray());

				double withinX = 9999, withinY = 9999;
				double bounding = 3;
				double x = CursorX, y = CursorY;
				double boundX = x - bounding, boundY = y - bounding;
				double boundX2 = x + bounding, boundY2 = y + bounding;

				double increment = t.FrameLength / 100.0;
				double thisX = (CursorX - gutterX) / scaleX, thisY = (CursorY - gutterY) / scaleY, thisZ = 0;
				Shapes.Point foundPoint = new Shapes.Point(thisX, thisY);
				double distanceIndex = 0;
				for (double i = 0; i < t.FrameLength; i += increment)
				{
					Shapes.Point p = t.XYZFromFrame(i);
					double compareX = p.X, compareY = p.Y;
					if (thisX > compareX - bounding && thisX < compareX + bounding &&
						thisY > compareY - bounding && thisY < compareY + bounding &&
						Math.Abs(thisX - p.X) + Math.Abs(thisY - p.Y) < Math.Abs(withinX) + Math.Abs(withinY)
					   )
					{
						withinX = thisX - p.X;
						withinY = thisY - p.Y;
						foundPoint = p;
						distanceIndex = t.distanceFromFrame(i);
					}
				}
				int betweenZero = 0, betweenOne = 0;
				for (int i = 0; i < t.LineSegments.Count; i++)
				{
					if (t.LineSegments[i].distanceLeadingUpToLine <= distanceIndex)
						betweenZero = i;
					if (t.LineSegments[i].distanceLeadingUpToLine < distanceIndex &&
						 t.LineSegments[i].distanceLeadingUpToLine + t.LineSegments[i].Length > distanceIndex
						)
					{
						betweenOne = i + 1;
						break;
					}
				}
				// If hit test failed, find which end it's closer to.
				if (betweenZero == 0 && betweenOne == 0)
				{
					List<Shapes.Point> p = t.getPoints();
					if (p.Count > 1)
					{
						Shapes.Point p1 = p[0];
						Shapes.Point p2 = p[p.Count - 1];
						if (Math.Sqrt(Math.Pow(foundPoint.X - p1.X, 2) + Math.Pow(foundPoint.Y - p1.Y, 2)) >
							Math.Sqrt(Math.Pow(foundPoint.X - p2.X, 2) + Math.Pow(foundPoint.Y - p2.Y, 2)))
						{
							betweenOne = p.Count;
						}
					}
				}
				coordinatesListView.Items.Insert(betweenOne,
					new ListViewItem(
						new string[] {
						Math.Round(thisX).ToString(),
						Math.Round(thisY).ToString(),
						Math.Round(thisZ).ToString()
					}
					)
				);
			}
		}

		private void listView_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					removeEntryToolStripMenuItem_Click(sender, (EventArgs)e);
					break;
			}
		}

		private void listView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					e.IsInputKey = true;
					break;
			}
		}

		#region In-place editing.
		ListViewItem.ListViewSubItem SelectedLSI;
		private void genericListView_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				ListView genericListView = (ListView)sender;
				ListViewHitTestInfo i = genericListView.HitTest(e.X, e.Y);
				SelectedLSI = i.SubItem;
				if (SelectedLSI == null)
					return;
				// Make-shift border style.
				int border = 0;
				switch (genericListView.BorderStyle)
				{
					case BorderStyle.FixedSingle:
						border = 1;
						break;
					case BorderStyle.Fixed3D:
						border = 2;
						break;
				}
				// Sizing.
				int CellWidth = SelectedLSI.Bounds.Width - border * 2;
				int CellHeight = SelectedLSI.Bounds.Height;
				int CellLeft = border * 2 + genericListView.Left + i.SubItem.Bounds.Left;
				int CellTop = border + genericListView.Top + i.SubItem.Bounds.Top;
				// First Column
				if (i.SubItem == i.Item.SubItems[0])
					CellWidth = genericListView.Columns[0].Width;
				// Property updates.
				TxtEdit.Location = new Point(CellLeft + 9, CellTop + 8);
				TxtEdit.Size = new Size(CellWidth - 9, CellHeight);
				TxtEdit.Visible = true;
				TxtEdit.BringToFront();
				TxtEdit.Text = i.SubItem.Text;
				TxtEdit.Select();
				TxtEdit.SelectAll();
			}
		}

		private void genericListView_MouseDown(object sender, MouseEventArgs e)
		{
			HideTextEditor();
		}

		private void genericListView_Scroll(object sender, MouseEventArgs e)
		{
			HideTextEditor();
		}

		private void TxtEdit_Leave(object sender, EventArgs e)
		{
			HideTextEditor();
		}

		void TxtEdit_MouseLeave(object sender, EventArgs e)
		{
			HideTextEditor();
		}

		private void TxtEdit_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
				HideTextEditor();
		}

		private void HideTextEditor()
		{
			TxtEdit.Visible = false;
			if (SelectedLSI != null)
				SelectedLSI.Text = TxtEdit.Text;
			SelectedLSI = null;
			TxtEdit.Text = "";
			idLabel.Focus();
		}
		#endregion
	}
}
