using Martinez_BankApp.Repository.Authentication;
using WinFormIdentity.Sessionizer;
using System;
using System.Windows.Forms;

namespace Martinez_BankApp
{
	public partial class LoginForm : Form
	{
		private readonly ClientLoginRepository _repository;
		public LoginForm(ClientLoginRepository repository)
		{
			InitializeComponent();
			_repository = repository;
		}

		private void LoginButton_Click(object sender, EventArgs e)
		{
			bool isValid = false;
			try
			{
				string username = UserNameTextField.Text;
				string password = PasswordTextField.Text;
				var identity = _repository.Validate(username, password);

				// placeholder for id
				Session.Id = 1001;
				Session.Username = identity.ToString();
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
