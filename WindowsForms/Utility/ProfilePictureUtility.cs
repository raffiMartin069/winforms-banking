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

		public Image ConvertyByteArrayToImage(byte[] imageByte)
		{
			if(imageByte == null || imageByte.Length == 0)
				return null;

			using(MemoryStream stream = new MemoryStream(imageByte))
			{
				var image = Image.FromStream(stream);
				return image;
			}
		}

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
