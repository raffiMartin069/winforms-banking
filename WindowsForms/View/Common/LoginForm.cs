using Martinez_BankApp.Repository.Authentication;
using System;
using System.Windows.Forms;

namespace Martinez_BankApp
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

        private void LoginButton_Click(object sender, EventArgs e)
		{
			ClientLoginRepository _repository = new ClientLoginRepository();
			bool isValid = false;
			try
			{
				string username = UserNameTextField.Text;
				string password = PasswordTextField.Text;
				_repository.GetUserCredential(username, password);
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("Username is required"))
				{
					UsernameErrorLabel.Text = "Username is required";
					UsernameErrorLabel.Visible = !isValid;
				}

				if (ex.Message.Contains("Password is required"))
				{
					PasswordErrorLabel.Text = "Password is required";
					PasswordErrorLabel.Visible = !isValid;
				}
			}
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			UserNameTextField.Clear();
			PasswordTextField.Clear();
			UsernameErrorLabel.Visible = false;
			PasswordErrorLabel.Visible = false;
		}

		private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool isTicked = false;
			if(ShowPasswordCheckBox.Checked)
			{
				PasswordTextField.UseSystemPasswordChar = isTicked;
				ShowPasswordCheckBox.Text = "Hide Password";
			}
			else
			{
				PasswordTextField.UseSystemPasswordChar = !isTicked;
				ShowPasswordCheckBox.Text = "Show Password";
			}
		}
	}
}
