using Martinez_BankApp.Dto.Admin;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Repository.Admin;
using Martinez_BankApp.Utility;
using System;
using System.IO;
using System.Windows.Forms;

namespace Martinez_BankApp.View.Forms.Admin
{
	public partial class CreateNewAccountForm : Form
	{
		private CreateNewAccountRepository _repository = new CreateNewAccountRepository(new DBContextDataContext());
		private const string DEFAULT_MARITAL_STATUS_COMBO_BOX = "Single";
		private const string DEFAULT_GENDER_COMBO_BOX = "Male";
		private const string DEFAULT_ROLE_COMBO_BOX = "Client";
		private byte[] _profilePictureBytes;

		public CreateNewAccountForm()
		{
			InitializeComponent();
		}

		/**
		 * <summary>
		 *	This will query the database for genders to be populated in the Gender Combo Box
		 *	<seealso cref="CreateNewAccountPresenter.GetAllGender"/>
		 * </summary>
		 * **/
		private void GenerateGenderType()
		{
			var genderTypes = _repository.GetAllGender();
			GenderComboBox.DisplayMember = "Type";
			GenderComboBox.ValueMember = "Id";
			GenderComboBox.DataSource = genderTypes;
		}

		/**
		 * <summary>
		 *	This will query the database for genders to be populated in the Marital Status Combo Box
		 *	<seealso cref="CreateNewAccountPresenter.GetAllMaritalStatus"/>
		 * </summary>
		 * **/
		private void GenerateMaritalStatus()
		{
			var maritalStat = _repository.GetAllMaritalStatus();
			MaritalStatusComboBox.DisplayMember = "Status";
			MaritalStatusComboBox.ValueMember = "Id";
			MaritalStatusComboBox.DataSource = maritalStat;
		}

		/**
		 * <summary>
		 *	This will query the database for genders to be populated in the Role Combo Box
		 *	<seealso cref="CreateNewAccountPresenter.GetAllRole"/>
		 * </summary>
		 * **/
		private void GenerateRole()
		{
			var role = _repository.GetAllRole();
			RoleComboBox.DisplayMember = "Type";
			RoleComboBox.ValueMember = "Id";
			RoleComboBox.DataSource = role;
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

		/**
		 * <summary>
		 *	Helper method to loop through the column header and replace underscore with space
		 *	<seealso cref="DisplayAllNewAccount()"/>
		 * </summary>
		 * **/
		private static void LoopThroughColumnHeader(DataGridView view)
		{
			foreach (DataGridViewColumn column in view.Columns)
			{
				column.HeaderText = column.HeaderText.Replace("_", " ");
			}
		}

		private void DisplayAllNewAccount()
		{
			var data = _repository.GetAllNewAccountCreated();
			if (data == null)
				MessagePrompt("No information to be displayed yet.");
			NewAccountsDataTable.DataSource = data;
			LoopThroughColumnHeader(NewAccountsDataTable);
		}

		private void MessagePrompt(string message) => MessageBox.Show(message);

		/**
		 * <summary>
		 *	Helper method to validate the date and balance field
		 *	<seealso cref="SaveButton_Click(object, EventArgs)"/>
		 * </summary>
		 * **/
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
		 * <seealso cref="CreateNewAccountRepository.AddAccount(NewAccount)"/>
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
				AddAccountHelperMethod(DateOfBirthDateTimePicker.Value.ToString(), BalanceTextBox.Text);
				byte[] profile = _profilePictureBytes;
				// Pass as data transfer objects, this model does not have any logic!
				var account = new NewAccount
					(FullNameTextBox.Text, DateOfBirthDateTimePicker.Value, EmailTextBox.Text,
					PasswordTextBox.Text, RepeatPasswordTextBox.Text, PhoneTextBox.Text,
					AddressTextBox.Text, MaritalStatusComboBox.Text, GenderComboBox.Text,
					MothersNameTextBox.Text, FathersNameTextBox.Text, RoleComboBox.Text, decimal.Parse(BalanceTextBox.Text), profile);


				string result = _repository.AddAccount(account);
				
				if(result == "0")
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
			var utility = new ProfilePictureUtility(ProfileImagePictureBox);
			utility.OpenProfilePictureSelector();
			_profilePictureBytes = utility.ConvertImageToByteArray();
		}

		private void SearchBoxTextField_TextChanged(object sender, EventArgs e)
		{
			NewAccountsDataTable.DataSource = _repository.FindAccountByKey(SearchBoxTextField.Text);
		}
	}
}
