using Martinez_BankApp.Repository.Authentication;
using WinFormIdentity.Sessionizer;
using System;
using System.Windows.Forms;
using System.Linq;
using Martinez_BankApp.Utility;

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
			try
			{
				string username = UserNameTextField.Text;
				string password = PasswordTextField.Text;

				AuthenticationUtility.ValidateFields(username, password);

				var identity = _repository.Validate(username, password);

				foreach(var item in identity)
				{
					Session.SetClaim("Email", item.Email);
					Session.SetClaim("Id", item.Id.ToString());
					Session.SetClaim("Role", item.Role);
				}
				AuthenticationUtility.ValidateRole();
				this.Hide();
			}
			catch (Exception ex)
			{
				PasswordErrorLabel.Visible = true;
				PasswordErrorLabel.Text = ex.Message;
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
			string hide = "Hide Password";
			string show = "Show Password";
			if(ShowPasswordCheckBox.Checked)
			{
				PasswordTextField.UseSystemPasswordChar = isTicked;
				ShowPasswordCheckBox.Text = hide;
			}
			else
			{
				PasswordTextField.UseSystemPasswordChar = !isTicked;
				ShowPasswordCheckBox.Text = show;
			}
		}
	}
}
