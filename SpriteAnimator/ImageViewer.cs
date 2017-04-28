using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Threading;

namespace SpriteAnimator
{
	public partial class ImageViewer : Form
	{
		private string referenceImageFilename = "";
		private Main parent = null;
		private List<Color> protectedColors = new List<Color>();
		private string selectedType = "";

		/*
		 * Dragging Variables
		 */
		private bool isDragging = false;
		private Point storedFormLocation, storedMouseLocation;

		/*
		 * Deactivation/Reactivation Handler Variables
		 */
		private bool lostFocus = false;
		private int runTimes = 0;
		private System.Threading.Timer shakeWindowThread;
		private double currentTime = 0, startValue = 0, changeInValue = 0, duration = 0;

		/*
		 * Image Sizing Variables
		 */
		private double zoomCoefficient = 0.2;
		private int zoomLevel = 0;

		/*
		 * Blended Image
		 */
		private bool haveAnImageToOverlay = false;
		private bool showLoadedImage = false;
		private SupportClasses.ImageDescription referenceImageDescription = new SupportClasses.ImageDescription(0, canBePushedToContext: false);
		private SupportClasses.ImageDescription compositeImageDescription = new SupportClasses.ImageDescription(1, canBePushedToContext: false);

		#region Thread-safe update methods.
		private void setDisplayedImage(ImageViewer instance, Bitmap image)
		{
			instance.Invoke((MethodInvoker)delegate()
			{
				instance.displayedImagePictureBox.Image = image;
			});
		}

		private void setShowOriginalImageButtonTransprentPictureBoxImage(ImageViewer instance, Bitmap image)
		{
			instance.Invoke((MethodInvoker)delegate()
			{
				instance.showOriginalImageButtonPictureBox.Image = image;
			});
		}

		private void setLocation(ImageViewer m, int x, int y)
		{
			if (m != null && m.Disposing != true)
			{
				try
				{
					m.Invoke((MethodInvoker)delegate
					{
						m.Location = new Point(x, y);
					});
				}
				catch (Exception) { }
			}
		}
		#endregion

		public ImageViewer(string referenceImageFilename, string selectedType, List<Color> protectedColors, Main m)
		{
			this.parent = m;
			this.protectedColors = protectedColors;
			this.selectedType = selectedType;
			this.referenceImageFilename = referenceImageFilename;
			//
			InitializeComponent();
			// Get the reference image; use it as the initial display.
			referenceImageDescription.replaceWithBitmap(referenceImageFilename);
			compositeImageDescription.replaceWithBitmap(referenceImageDescription.SignificantBitmap);
			// If the parent exists, try to take it a step farther and include the actual image super-imposed on the reference image.
			haveAnImageToOverlay = (parent != null && parent.loadedFormat.ToLower() == selectedType) ? true : false;
			// Write and use picture data for overlaid reference (composite: reference image + original image).
			if (haveAnImageToOverlay)
				generateAndUseCompositeImage(this);
		}

		private void ImageViewer_Load(object sender, EventArgs e)
		{
			//
			setDisplayedImage(this, compositeImageDescription.SignificantBitmap);
			layoutOverlays(this, firstTime: true);
		}

		private void ImageViewer_Deactivate(object sender, EventArgs e)
		{
			lostFocus = true;
		}

		private void ImageViewer_Activated(object sender, EventArgs e)
		{
			if (lostFocus)
			{
				duration = 8;
				runTimes = 0;
				storedFormLocation = new Point(this.Location.X, this.Location.Y);
				ImageViewer instance = this;
				shakeWindowThread = new System.Threading.Timer(delegate(object data)
				{
					currentTime = runTimes;
					changeInValue = 8;
					startValue = storedFormLocation.X - changeInValue;
					double newChangeInValue = 2 * changeInValue;
					if (runTimes <= duration && (instance != null || instance.Disposing != true))
					{
						double c = SupportFunctions.EaseOutSine(currentTime, startValue, newChangeInValue, duration);
						setLocation(instance, (int)c, storedFormLocation.Y);
					}
					else
					{
						if (changeInValue > 1)
						{
							runTimes = 0;
							changeInValue -= 2;
							duration -= 2;
						}
						else
						{
							setLocation(instance, storedFormLocation.X, storedFormLocation.Y);
							shakeWindowThread.Dispose();
						}
					}
					runTimes++;
				}, "Shake Form on Reactivation", 0, 5);
				lostFocus = false;
			}
		}

		private void generateAndUseCompositeImage(ImageViewer instance)
		{
			Thread generateCompositeImageThread = new Thread(new ThreadStart(delegate()
			{
				Bitmap blendedImage = compositeImageDescription.SignificantBitmap;
				Bitmap originalImage = parent.loadedImageDescription.SignificantBitmap;
				for (int i = 0; i < blendedImage.Height; i++)
				{
					for (int r = 0; r < blendedImage.Width; r++)
					{
						Color a = blendedImage.GetPixel(r, i);
						Color b = a;
						if (originalImage.Height > i && originalImage.Width > r)
							b = originalImage.GetPixel(r, i);
						if (this.protectedColors.Find(item => item.R == a.R && item.G == a.G && item.B == a.B) == Color.Empty)
						{
							// Replace non-protected color with pixel color of loaded file.
							Color c = Color.FromArgb(255, b.R, b.G, b.B);
							blendedImage.SetPixel(r, i, c);
						}
					}
				}
				// Store the image 
				compositeImageDescription.replaceWithBitmap(blendedImage);
				//
				showLoadedImage = true;
				updateDisplayBasedOnSettings(instance);
				layoutOverlays(instance);
			}));
			generateCompositeImageThread.Name = "Generate Image Composited with Reference Image";
			generateCompositeImageThread.Start();
		}

		private void layoutOverlays(ImageViewer instance, bool firstTime = false)
		{
			instance.Invoke((MethodInvoker)delegate()
			{
				showOriginalImageButtonPictureBox.Visible = (haveAnImageToOverlay) ? true : false;
				// Initially, set the size of the form and image control, respecting the size of the loaded reference image. Otherwise, just change the size of the form.
				if (firstTime)
				{
					if (displayedImagePictureBox.Image != null)
					{
						this.Width = displayedImagePictureBox.Image.Width + exitButtonPictureBox.Width / 2;
						this.Height = displayedImagePictureBox.Image.Height;
						displayedImagePictureBox.Width = displayedImagePictureBox.Image.Width;
						displayedImagePictureBox.Height = displayedImagePictureBox.Image.Height;
					}
				}
				else
				{
					this.Width = displayedImagePictureBox.Width + exitButtonPictureBox.Width / 2;
					this.Height = displayedImagePictureBox.Height;
				}
				verticallyArrangeImageButtons();
			});
		}
		
		private void verticallyArrangeImageButtons(int distance = 15)
		{
			exitButtonPictureBox.Location = new Point(this.Width - exitButtonPictureBox.Width, distance / 3);
			zoomInButtonPictureBox.Location = new Point(this.Width - zoomInButtonPictureBox.Width, exitButtonPictureBox.Location.Y + exitButtonPictureBox.Height + distance);
			zoomOutButtonPictureBox.Location = new Point(this.Width - zoomOutButtonPictureBox.Width, zoomInButtonPictureBox.Location.Y + zoomInButtonPictureBox.Height + distance / 3);
			showOriginalImageButtonPictureBox.Location = new Point(this.Width - showOriginalImageButtonPictureBox.Width, zoomOutButtonPictureBox.Location.Y + zoomOutButtonPictureBox.Height + distance);
			this.Invalidate();
			displayedImagePictureBox.Invalidate();
			exitButtonPictureBox.Invalidate();
			zoomInButtonPictureBox.Invalidate();
			zoomOutButtonPictureBox.Invalidate();
			showOriginalImageButtonPictureBox.Invalidate();
		}

		private void exitButtonPictureBox_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void displayedImagePictureBox_Click(object sender, EventArgs e)
		{
			storedFormLocation = new Point(this.Location.X, this.Location.Y);
		}

		private void displayedImagePictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (isDragging && e.Button == MouseButtons.Left)
			{
				this.Left += e.X - storedMouseLocation.X;
				this.Top += e.Y - storedMouseLocation.Y;
			}
		}

		private void displayedImagePictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			isDragging = true;
			storedMouseLocation = new Point(e.X, e.Y);
		}

		private void displayedImagePictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			isDragging = false;
			layoutOverlays(this);
		}

		private void zoomInButtonPictureBox_Click(object sender, EventArgs e)
		{
			zoomLevel++;
			updateDisplayedPictureBoxSize();
		}
		
		private void zoomOutButtonPictureBox_Click(object sender, EventArgs e)
		{
			zoomLevel--;
			updateDisplayedPictureBoxSize();
		}

		private void updateDisplayedPictureBoxSize()
		{
			int widthModifier;
			int heightModifier;
			calculateImageZoomModifiers(out widthModifier, out heightModifier);
			// If the zoom level would modify the size such that it negatively exceeds the image size.
			if (zoomLevel < 0 && (Math.Abs(widthModifier) >= referenceImageDescription.Width || Math.Abs(heightModifier) >= referenceImageDescription.Height))
			{
				zoomLevel++;
				calculateImageZoomModifiers(out widthModifier, out heightModifier);
			}
			// Set the size.
			displayedImagePictureBox.Width = referenceImageDescription.Width + widthModifier;
			displayedImagePictureBox.Height = referenceImageDescription.Height + heightModifier;
			layoutOverlays(this);
		}

		private void calculateImageZoomModifiers(out int widthModifier, out int heightModifier)
		{
			widthModifier = (int)(referenceImageDescription.Width * zoomLevel * zoomCoefficient);
			heightModifier = (int)(referenceImageDescription.Height * zoomLevel * zoomCoefficient);
		}

		private void showOriginalImageButtonPictureBox_Click(object sender, EventArgs e)
		{
			showLoadedImage = !showLoadedImage;
			updateDisplayBasedOnSettings(this);
			layoutOverlays(this);
		}

		private void updateDisplayBasedOnSettings(ImageViewer instance)
		{
			if (showLoadedImage)
			{
				setDisplayedImage(instance, compositeImageDescription.SignificantBitmap);
				setShowOriginalImageButtonTransprentPictureBoxImage(instance, global::SpriteAnimator.Properties.Resources.solid);
			}
			else
			{
				setDisplayedImage(instance, referenceImageDescription.SignificantBitmap);
				setShowOriginalImageButtonTransprentPictureBoxImage(instance, global::SpriteAnimator.Properties.Resources.clear);
			}
		}

		private void displayedImagePictureBox_Paint(object sender, PaintEventArgs e)
		{
			PictureBox box = sender as PictureBox;
			// Only upscale the image with the nearest neighbor filter if the image is exactly dividable by the original reference image dimensions.
			if (box.Width % referenceImageDescription.Width == 0 && box.Height % referenceImageDescription.Height == 0)
			{
				Bitmap image = (showLoadedImage) ? compositeImageDescription.SignificantBitmap : referenceImageDescription.SignificantBitmap;
				e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
				e.Graphics.DrawImage(image, new Rectangle(0, 0, box.Width, box.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
			}
		}
	}
}
