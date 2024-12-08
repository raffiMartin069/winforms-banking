using Martinez_BankApp.Model.Dto.Admin;
using Martinez_BankApp.Model.InputModel.Admin;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Repository.Admin;
using Martinez_BankApp.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Martinez_BankApp.View.Forms.Admin
{
	public partial class CreateNewAccountForm : Form
	{
		private CreateNewAccountRepository _repository;
		private const string DEFAULT_MARITAL_STATUS_COMBO_BOX = "Single";
		private const string DEFAULT_GENDER_COMBO_BOX = "Male";
		private const string DEFAULT_ROLE_COMBO_BOX = "Client";
		private byte[] _profilePictureBytes;

		public CreateNewAccountForm(CreateNewAccountRepository repository)
		{
			InitializeComponent();
			_repository = repository;
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
				var combox = new ComboBoxUtility("Type", "Id", genderTypes, GenderComboBox);
				combox.CreateComboBox();
			}
			catch (Exception ex)
			{
				MessagePrompt("List of gender is empty");
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
				var combox = new ComboBoxUtility("Status", "Id", maritalStat, MaritalStatusComboBox);
				combox.CreateComboBox();
			}
			catch (Exception ex)
			{
				MessagePrompt("List of marital status is empty.");
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
				var combox = new ComboBoxUtility("Type", "Id", role, RoleComboBox);
				combox.CreateComboBox();
			}
			catch (Exception ex)
			{
				MessagePrompt("List of role is empty.");
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

		private void CreateNewAccountForm_Load(object sender, EventArgs e)
		{
			ShowAllDropDownComponents();
			DisplayAllNewAccount();
			DefaultValuesForComboBox();
		}

		private static void ModifyTableHeaders(DataGridView view)
		{
			view.Columns["UserId"].HeaderText = "User ID";
			view.Columns["FullName"].HeaderText = "Full Name";
			view.Columns["DateOfBirth"].HeaderText = "Date of Birth";
			view.Columns["PhoneNumber"].HeaderText = "Phone Number";
			view.Columns["HomeAddress"].HeaderText = "Home Address";
			view.Columns["MaritalStatus"].HeaderText = "Marital Status";
			view.Columns["MotherName"].HeaderText = "Mother's Name";
			view.Columns["FatherName"].HeaderText = "Father's Name";
			view.Columns["AccountId"].HeaderText = "Account ID";
			view.Columns["ProfilePhoto"].HeaderText = "Profile Photo";
		}

		private void DisplayAllNewAccount()
		{
			try
			{
				var data = _repository.GetAllAccount()?.ToList();
				if (data == null)
				{
					MessagePrompt("No information to be displayed yet.");
					return;
				}
				NewAccountsDataTable.DataSource = data;
				NewAccountsDataTable.Columns["OriginalProfilePhoto"].Visible = false;
				ModifyTableHeaders(NewAccountsDataTable);
			}
			catch (Exception ex)
			{
				MessagePrompt("No information to be displayed yet.");
				Debug.WriteLine(ex.Message);
			}
		}

		private void MessagePrompt(string message) => MessageBox.Show(message);

		/**
		 * <summary>
		 *	Helper method to validate the date and balance field
		 *	<seealso cref="SaveButton_Click(object, EventArgs)"/>
		 * </summary>
		 * **/
		[Obsolete("This validation is being replaced an already set in the model.")]
		public void AddAccountHelperMethod(string date, string balance)
		{
			if (!DateTime.TryParse(date, out DateTime dob))
				throw new Exception("Date of birth must not be empty");

			if (!decimal.TryParse(balance, out decimal convertedBalance))
				throw new Exception("Balance must not be empty");
		}

		/**
		 * <summary>
		 * This method is called if the operation is successful.
		 * <br/>
		 * <br/>
		 * <seealso cref="CreateNewAccountRepository.AddAccount(CreateAccountDto)"/>
		 * </summary>
		 * **/
		private void AddAccountOnSuccessSave()
		{
			SetFieldsToDefault();
			DisplayAllNewAccount();
			MessagePrompt("Account created successfuly");
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			try
			{
				byte[] profile = _profilePictureBytes;

				var model = new NewAccount(EmailTextBox.Text, DateOfBirthDateTimePicker.Text, PasswordTextBox.Text, RepeatPasswordTextBox.Text, FullNameTextBox.Text, PhoneTextBox.Text, AddressTextBox.Text, MaritalStatusComboBox.Text, GenderComboBox.Text, MothersNameTextBox.Text, FathersNameTextBox.Text, RoleComboBox.Text, BalanceTextBox.Text, profile, _repository);

				bool isSuccess = model.AddAccount();

				if(isSuccess)
				{
					AddAccountOnSuccessSave();
				}
			}
			catch (Exception ex)
			{
				MessagePrompt(ex.Message);
				return;
			}
		}

		private void DefaultValuesForComboBox()
		{
			MaritalStatusComboBox.Text = DEFAULT_MARITAL_STATUS_COMBO_BOX;
			GenderComboBox.Text = DEFAULT_GENDER_COMBO_BOX;
			RoleComboBox.Text = DEFAULT_ROLE_COMBO_BOX;
		}

		/**
		 * <summary>
		 *	Helper method to set all dropdown fields to default and clear other fields
		 *	<br/><br/>
		 *	<seealso cref="ClearAllFieldButton_Click"/> 
		 *	<br/>
		 *	and
		 *	<br/>
		 *	<seealso cref="SaveButton_Click"/>
		 * </summary>
		 * **/
		private void SetFieldsToDefault()
		{
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

		// This is a byte array to store the profile picture
		// This will be used to store the profile picture in the database
		// This will be used to display the profile picture in the form
		private void ProfileImagePictureBox_Click(object sender, EventArgs e)
		{
			try
			{
				var utility = new ProfilePictureUtility();
				utility.ProfileImage = ProfileImagePictureBox;
				utility.OpenProfilePictureSelector();
				_profilePictureBytes = utility.ConvertImageToByteArray();
			}
			catch(Exception ex)
			{
				MessagePrompt(ex.Message);
			}
		}

		private void SearchBoxTextField_TextChanged(object sender, EventArgs e)
		{
			string key = SearchBoxTextField.Text;
			var result = _repository.FindAccountByKey(key)?.ToList();
			InitializeGridView(result);
			AssignTableHeader(NewAccountsDataTable);
		}

		private void AssignTableHeader(DataGridView view)
		{
			view.Columns["Id"].HeaderText = "User ID";
			view.Columns["ProfileImage"].HeaderText = "Profile Photo";
			view.Columns["Fullname"].HeaderText = "Full Name";
			view.Columns["Gender"].HeaderText = "Gender";
			view.Columns["DateOfBirth"].HeaderText = "Date of Birth";
			view.Columns["Email"].HeaderText = "Email";
			view.Columns["Phone"].HeaderText = "Phone Number";
			view.Columns["Marriage"].HeaderText = "Marital Status";
			view.Columns["Address"].HeaderText = "Home Address";
			view.Columns["Fathername"].HeaderText = "Father's Name";
			view.Columns["Mothername"].HeaderText = "Mother's Name";
			view.Columns["Role"].HeaderText = "Role";
			view.Columns["BankAccountId"].HeaderText = "Account ID";
			view.Columns["AccountBalance"].HeaderText = "Balance";
		}

		private DataGridView InitializeGridView<T>(IEnumerable<T> data)
		{
			NewAccountsDataTable.DataSource = data;
			return NewAccountsDataTable;
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
