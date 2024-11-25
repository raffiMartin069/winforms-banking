using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.Utility
{
	public class ProfilePictureUtility
	{
		private const string ALLOWED_FORMAT = "Image Files(*.bmp; *.jpg; *.jpeg; *.png; *.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif";

		public PictureBox ProfileImage { get; set; }

		private void CheckImageNotNull()
		{
			if (ProfileImage.Image == null)
				throw new Exception("Please select an image first.");
		}

		/**
		 * <summary>
		 *	Converts an image to a byte array
		 *	<seealso cref="ConvertImageToByteArray"/>
		 * </summary>
		 * **/
		private Bitmap BitMapConversion(Image image)
		{
			var bitmap = new Bitmap(image, new Size(60, image.Height * 50 / image.Width));
			return bitmap;
		}

		/**
		 * <summary>
		 *	Returns a default image if no image is found
		 * </summary>
		 * **/
		private Bitmap GetDefaultImage()
		{
			var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\resources\img\default.png"));
			if (!File.Exists(path))
			{
				MessageBox.Show("Default image not found.");
				return null;
			}
			var defaultImage = Image.FromFile(path);
			var defaultBitmap = new Bitmap(defaultImage, new Size(60, defaultImage.Height * 50 / defaultImage.Width));
			return defaultBitmap;
		}

		/**
		 * <summary>
		 *	Converts a byte array to a bitmap
		 *	<seealso cref="BitMapConversion(Image)"/>
		 * </summary>
		 * **/
		public Bitmap ConvertByteArrayToBitmap(byte[] imageByte)
		{
			if (imageByte == null || imageByte.Length == 0)
			{
				return GetDefaultImage();
			}

			using (MemoryStream stream = new MemoryStream(imageByte))
			{
				var image = Image.FromStream(stream);
				var bitmap = BitMapConversion(image);
				return bitmap;
			}
		}

		/**
		 * <summary>
		 *	Converts a byte array to an image
		 * </summary>
		 * **/
		public static Bitmap ConvertyByteArrayToImage(byte[] imageByte)
		{
			if (imageByte == null || imageByte.Length == 0)
				return new ProfilePictureUtility().GetDefaultImage();


			using (MemoryStream stream = new MemoryStream(imageByte))
			{
				var image = Image.FromStream(stream);
				var bitmap = new ProfilePictureUtility().BitMapConversion(image);
				return bitmap;
			}
		}

		public static Image UncompressedByteArrayToImage(byte[] imageByte)
		{
			if (imageByte == null || imageByte.Length == 0)
				return new ProfilePictureUtility().GetDefaultImage();


			using (MemoryStream stream = new MemoryStream(imageByte))
			{
				var image = Image.FromStream(stream);
				return image;
			}
		}

		/**
		 * <summary>
		 *	Converts an image to a byte array
		 * </summary>
		 * **/
		public byte[] ConvertImageToByteArray()
		{
			try
			{
				byte[] image = null;
				CheckImageNotNull();
				using (MemoryStream stream = new MemoryStream())
				{
					ProfileImage.Image.Save(stream, ProfileImage.Image.RawFormat);
					image = stream.ToArray();
				}
				return image;
			}
			catch (Exception ex)
			{
				MessageBox.Show("No image found.");
				Debug.WriteLine(ex.Message);
				return null;
			}
		}

		/**
		 * <summary>
		 * Allows a user to open an image selector dialog and select an image for profile picture
		 * </summary>
		 * **/
		public void OpenProfilePictureSelector()
		{
			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				dialog.Filter = ALLOWED_FORMAT;

				if (dialog.ShowDialog() != DialogResult.OK)
					return;

				ProfileImage.Image = new System.Drawing.Bitmap(dialog.FileName);
				ProfileImage.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}
	}
}
