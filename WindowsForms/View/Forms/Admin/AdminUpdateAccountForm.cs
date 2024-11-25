using Martinez_BankApp.Model.Dto.Admin;
using Martinez_BankApp.Repository.Admin;
using Martinez_BankApp.Utility;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Martinez_BankApp.View.Forms.Admin
{
	public partial class AdminUpdateAccountForm : Form
	{
		private UpdateAccountRepository _repository;
		private byte[] _profilePictureBytes;
		private const string DEFAULT_MARITAL_STATUS_COMBO_BOX = "Single";
		private const string DEFAULT_GENDER_COMBO_BOX = "Male";
		private const string DEFAULT_ROLE_COMBO_BOX = "Client";
		private int _userId = 0;

		public AdminUpdateAccountForm(UpdateAccountRepository repository)
		{
			InitializeComponent();
			_repository = repository;
		}

		private DataGridView PopulateTable()
		{
			try
			{
				var accounts = _repository.GetAllAccount()?.ToList();
				AccountDataGridView.DataSource = accounts;
				AccountDataGridView.Columns["OriginalProfilePhoto"].Visible = false;

				return AccountDataGridView;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}

		/**
		 * <summary>
		 *	This will query the database for genders to be populated in the Gender Combo Box
		 *	<seealso cref="CreateNewAccountPresenter.GetAllGender"/>
		 * </summary>
		 * **/
		private void GenerateGenderType()
		{
			try
			{
				var genderTypes = _repository.GetAllGender();
				GenderComboBox.DisplayMember = "Type";
				GenderComboBox.ValueMember = "Id";
				GenderComboBox.DataSource = genderTypes;
			}
			catch (Exception ex)
			{
				MessageBox.Show("List of gender is empty");
				Debug.WriteLine(ex.Message);
			}
		}

		/**
		 * <summary>
		 *	This will query the database for genders to be populated in the Marital Status Combo Box
		 *	<seealso cref="CreateNewAccountPresenter.GetAllMaritalStatus"/>
		 * </summary>
		 * **/
		private void GenerateMaritalStatus()
		{
			try
			{
				var maritalStat = _repository.GetAllMaritalStatus();
				MaritalStatusComboBox.DisplayMember = "Status";
				MaritalStatusComboBox.ValueMember = "Id";
				MaritalStatusComboBox.DataSource = maritalStat;
			}
			catch (Exception ex)
			{
				MessageBox.Show("List of marital status is empty.");
				Debug.WriteLine(ex.Message);
			}
		}

		/**
		 * <summary>
		 *	This will query the database for genders to be populated in the Role Combo Box
		 *	<seealso cref="CreateNewAccountPresenter.GetAllRole"/>
		 * </summary>
		 * **/
		private void GenerateRole()
		{
			try
			{
				var role = _repository.GetAllRole();
				RoleComboBox.DisplayMember = "Type";
				RoleComboBox.ValueMember = "Id";
				RoleComboBox.DataSource = role;
			}
			catch (Exception ex)
			{
				MessageBox.Show("List of role is empty.");
				Debug.WriteLine(ex.Message);
			}
		}

		/**
		 * <summary>
		 * Helper method to show all drop down components
		 * <summary/>
		 * **/
		private void ShowAllDropDownComponents()
		{
			GenerateGenderType();
			GenerateMaritalStatus();
			GenerateRole();
		}

		private void AdminUpdateAccountForm_Load(object sender, EventArgs e)
		{
			PopulateTable();
			ShowAllDropDownComponents();
		}

		private void DefaultValuesForComboBox()
		{
			MaritalStatusComboBox.Text = DEFAULT_MARITAL_STATUS_COMBO_BOX;
			GenderComboBox.Text = DEFAULT_GENDER_COMBO_BOX;
			RoleComboBox.Text = DEFAULT_ROLE_COMBO_BOX;
		}

		private void SetImageDefaultValue()
		{
			if (ProfileImagePictureBox.Image is null)
				ProfileImagePictureBox.Image = ProfileImagePictureBox.ErrorImage;
		}

		private void SetFieldsToDefault()
		{
			_userId = 0;
			FullNameTextBox.Clear();
			DateOfBirthDateTimePicker.Value.ToLocalTime();
			EmailTextBox.Clear();
			PasswordTextBox.Clear();
			RepeatPasswordTextBox.Clear();
			PhoneTextBox.Clear();
			AddressTextBox.Clear();
			MothersNameTextBox.Clear();
			FathersNameTextBox.Clear();
			BalanceTextBox.Clear();
			DefaultValuesForComboBox();
		}

		private void ClearAllFieldButton_Click(object sender, EventArgs e)
		{
			SetFieldsToDefault();
		}

		private void OnSelectPopulateFields()
		{
			_userId = Convert.ToInt32(AccountDataGridView.CurrentRow.Cells[0].Value);
			ProfileImagePictureBox.Image = (Image)AccountDataGridView.CurrentRow.Cells["OriginalProfilePhoto"].Value;
			ProfileImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			FullNameTextBox.Text = AccountDataGridView.CurrentRow.Cells[3].Value.ToString();
			DateOfBirthDateTimePicker.Value = (DateTime)AccountDataGridView.CurrentRow.Cells[4].Value;
			RoleComboBox.Text = AccountDataGridView.CurrentRow.Cells[6].Value.ToString();
			EmailTextBox.Text = AccountDataGridView.CurrentRow.Cells[5].Value.ToString();
			PhoneTextBox.Text = AccountDataGridView.CurrentRow.Cells[7].Value.ToString();
			AddressTextBox.Text = AccountDataGridView.CurrentRow.Cells[8].Value.ToString();
			MaritalStatusComboBox.Text = AccountDataGridView.CurrentRow.Cells[9].Value.ToString();
			GenderComboBox.Text = AccountDataGridView.CurrentRow.Cells[10].Value.ToString();
			MothersNameTextBox.Text = AccountDataGridView.CurrentRow.Cells[11].Value.ToString();
			FathersNameTextBox.Text = AccountDataGridView.CurrentRow.Cells[12].Value.ToString();
			BalanceTextBox.Text = AccountDataGridView.CurrentRow.Cells[14].Value.ToString();
		}

		private DialogResult UpdatePrompt()
		{
			MessageBoxButtons buttons = new MessageBoxButtons();
			buttons = MessageBoxButtons.YesNo;
			var result = MessageBox.Show("Are you sure you want to update this account?", "Update Account", buttons);
			return result;
		}

		private decimal RemoveBalanceCurreny()
		{
			if (BalanceTextBox.Text == null)
			{
				return 0;
			}

			string strippedBalance = BalanceTextBox.Text.Replace("Php ", "");
			
			if (!decimal.TryParse(strippedBalance, out decimal balance))
			{
				throw new Exception("Invalid Balance");
			}

			return balance;
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			var result = UpdatePrompt();

			if (result == DialogResult.No)
			{
				return;
			}

			try
			{
				decimal balance = RemoveBalanceCurreny();

				var imageUtility = new ProfilePictureUtility();
				var setImage = imageUtility.ProfileImage = ProfileImagePictureBox;
				_profilePictureBytes = imageUtility.ConvertImageToByteArray();


				string password = PasswordTextBox.Text;
				string repeatPassword = RepeatPasswordTextBox.Text;

				if (!string.IsNullOrEmpty(password))
				{
					if (!password.Equals(repeatPassword))
					{
						MessageBox.Show("Password does not match");
						return;
					}
				}


				var accountDto = new UpdateAccountDto
					(
						_userId,
						FullNameTextBox.Text,
						DateOfBirthDateTimePicker.Value,
						EmailTextBox.Text,
						PasswordTextBox.Text,
						RepeatPasswordTextBox.Text,
						PhoneTextBox.Text,
						AddressTextBox.Text,
						MaritalStatusComboBox.Text,
						GenderComboBox.Text,
						MothersNameTextBox.Text,
						FathersNameTextBox.Text,
						RoleComboBox.Text,
						balance,
						_profilePictureBytes
					);

				string resultMessage = _repository.UpdateAccount(accountDto).ToString();
				
				PopulateTable();
				SetFieldsToDefault();
				
				MessageBox.Show(resultMessage);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
		}

		private void AccountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			OnSelectPopulateFields();
		}

		private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			bool isVisible = false;
			string show = "Show Password";
			string hide = "Hide Password";
			if (ShowPasswordCheckBox.Checked)
			{
				PasswordTextBox.UseSystemPasswordChar = isVisible;
				RepeatPasswordTextBox.UseSystemPasswordChar = isVisible;
				ShowPasswordCheckBox.Text = hide;
			}
			else
			{
				PasswordTextBox.UseSystemPasswordChar = !isVisible;
				RepeatPasswordTextBox.UseSystemPasswordChar = !isVisible;
				ShowPasswordCheckBox.Text = show;
			}
		}

		private void ProfileImagePictureBox_Click(object sender, EventArgs e)
		{
			try
			{
				var utility = new ProfilePictureUtility();
				utility.ProfileImage = ProfileImagePictureBox;
				utility.OpenProfilePictureSelector();
				_profilePictureBytes = utility.ConvertImageToByteArray();
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
		}

		private void AllowNumericOnlyOnPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}
		}
	}
}
