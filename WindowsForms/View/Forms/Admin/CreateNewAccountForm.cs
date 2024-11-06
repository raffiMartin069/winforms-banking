using Martinez_BankApp.Dto.Admin;
using Martinez_BankApp.Persistent;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Service.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.View.Forms.Admin
{
	public partial class CreateNewAccountForm : Form
	{
		private CreateNewAccountService _service = new CreateNewAccountService();
		private const string DEFAULT_MARITAL_STATUS_COMBO_BOX = "Single";
		private const string DEFAULT_GENDER_COMBO_BOX= "Male";
		private const string DEFAULT_ROLE_COMBO_BOX = "Client";

		public CreateNewAccountForm()
		{
			InitializeComponent();
		}

		/**
		 * <summary>
		 *	This will query the database for genders to be populated in the Gender Combo Box
		 *	<seealso cref="CreateNewAccountService.GetAllGender"/>
		 * </summary>
		 * **/
		private void GenerateGenderType()
		{
			var genderTypes = _service.GetAllGender();
			GenderComboBox.DisplayMember = "Name";
			GenderComboBox.ValueMember = "Id";
			GenderComboBox.DataSource = genderTypes;
		}

		/**
		 * <summary>
		 *	This will query the database for genders to be populated in the Marital Status Combo Box
		 *	<seealso cref="CreateNewAccountService.GetAllMaritalStatus"/>
		 * </summary>
		 * **/
		private void GenerateMaritalStatus()
		{
			var maritalStat = _service.GetAllMaritalStatus();
			MaritalStatusComboBox.DisplayMember = "Status";
			MaritalStatusComboBox.ValueMember = "Id";
			MaritalStatusComboBox.DataSource = maritalStat;
		}

		/**
		 * <summary>
		 *	This will query the database for genders to be populated in the Role Combo Box
		 *	<seealso cref="CreateNewAccountService.GetAllRole"/>
		 * </summary>
		 * **/
		private void GenerateRole()
		{
			var role = _service.GetAllRole();
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
			var data = _service.GetAllNewAccount();
			if(data == null)
				MessagePrompt("No information to be displayed yet.");
			NewAccountsDataTable.DataSource = data;
			LoopThroughColumnHeader(NewAccountsDataTable);
		}

		private void MessagePrompt(string message) => MessageBox.Show(message);

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (!decimal.TryParse(BalanceTextBox.Text, out decimal balance))
			{
				MessagePrompt("Balance must not be empty");
				return;
			}	

			var dto = new NewAccountDto(
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
				balance
			);

			string result = _service.AddAccount(dto);
			// Redisplay all new accounts

			// This indicates the account was not created.
			if(result == "1")
				return;

			SetFieldsToDefault();
			DisplayAllNewAccount();
			MessagePrompt("Account created successfuly");
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
	}
}
