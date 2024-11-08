using Martinez_BankApp.Dto.Admin;
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
			try
			{
				var genderTypes = _repository.GetAllGender();
				GenderComboBox.DisplayMember = "Type";
				GenderComboBox.ValueMember = "Id";
				GenderComboBox.DataSource = genderTypes;
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
				MaritalStatusComboBox.DisplayMember = "Status";
				MaritalStatusComboBox.ValueMember = "Id";
				MaritalStatusComboBox.DataSource = maritalStat;
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
				RoleComboBox.DisplayMember = "Type";
				RoleComboBox.ValueMember = "Id";
				RoleComboBox.DataSource = role;
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

		/**
		 * <summary>
		 * I made the column name and header to be the same to avoid confusion.
		 * Both of them can be the same which I decided to just use this method
		 * instead of creating for another method that would handle all headers.
		 * </summary>
		 * **/
		private List<string> ColumnNameAndHeaderList()
		{
			return new List<string>
			{
				"User Identification",
				"Profile Photo",
				"Full Name",
				"Date of Birth",
				"Email",
				"Phone Number",
				"Home Address",
				"Marital Status",
				"Gender",
				"Mother's Name",
				"Father's Name",
				"Account Number",
				"Amount Balance"
			};
		}

		private void CreateTableRow(List<SP_DisplayNewAccountCreatedResult> data, ProfilePictureUtility profileUtility)
		{
			foreach (var row in data)
			{
				int index = NewAccountsDataTable.Rows.Add();
				DataGridViewRow newRow = NewAccountsDataTable.Rows[index];
				newRow.Cells["User Identification"].Value = row.User_Identification.ToString();
				var img = profileUtility.ConvertyByteArrayToImage(row.Profile_Photo.ToArray());
				var resizedImg = new Bitmap(img, new Size(50, 50));
				newRow.Cells["Profile Photo"].Value = resizedImg;
				newRow.Cells["Full Name"].Value = row.Client_s_Full_Name;
				newRow.Cells["Date of Birth"].Value = row.Date_of_Birth;
				newRow.Cells["Email"].Value = row.Email;
				newRow.Cells["Phone Number"].Value = row.Phone_Number;
				newRow.Cells["Home Address"].Value = row.Home_Address;
				newRow.Cells["Marital Status"].Value = row.Marital_Status;
				newRow.Cells["Gender"].Value = row.Gender;
				newRow.Cells["Mother's Name"].Value = row.Mother_s_Name;
				newRow.Cells["Father's Name"].Value = row.Father_s_Name;
				newRow.Cells["Account Number"].Value = row.Account_Number;
				newRow.Cells["Amount Balance"].Value = row.Account_Balance;
			}
		}

		private DataGridView CreateStaticColumns()
		{
			var tableGenerator = new TableGenerator(NewAccountsDataTable, ColumnNameAndHeaderList(), ColumnNameAndHeaderList());
			return tableGenerator.GenerateTableCoumns();
		}

		private void DisplayAllNewAccount()
		{
			try
			{
				var listOfImages = new List<Image>();
				var profileUtility = new ProfilePictureUtility();
				var data = _repository.GetAllNewAccountCreated()?.ToList();
				if (data == null)
				{
					MessagePrompt("No information to be displayed yet.");
					return;
				}

				CreateStaticColumns();
				CreateTableRow(data, profileUtility);
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
			NewAccountsDataTable.DataSource = _repository.FindAccountByKey(SearchBoxTextField.Text);
		}
	}
}
