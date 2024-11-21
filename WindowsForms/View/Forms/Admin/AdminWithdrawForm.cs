using Martinez_BankApp.Model.InputModel.Admin;
using Martinez_BankApp.Repository.Admin;
using Martinez_BankApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.View.Forms.Admin
{
	public partial class AdminWithdrawForm : Form
	{
		private readonly WithdrawRepository _repository;
		private const string DEFAULT_MODE = "ATM";
		public AdminWithdrawForm(WithdrawRepository repository)
		{
			InitializeComponent();
			_repository = repository;
		}
		private void SaveButton_Click(object sender, EventArgs e)
		{
			try
			{
				var model = new Withdraw
				(
					AccountNumberTextBox.Text,
					NameTextBox.Text,
					OldBalanceTextBox.Text,
					ModeComboBox.Text,
					AmountTextBox.Text
				);

				var dto = model.Validate();

				if (dto == null)
					return;

				var result = _repository.AddWithdraw(dto);
				GetAllRecord();
				MessageBox.Show(result);

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void AdminWithdrawForm_Load(object sender, EventArgs e)
		{
			GetAllRecord();
			WithdrawMode();
		}

		private void ClearAllFieldButton_Click(object sender, EventArgs e)
		{
			SetFieldDefault();
		}

		private void WithdrawDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			PopulateFields();
		}

		private void AmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}
		}

		private void SearchTextBox_TextChanged(object sender, EventArgs e)
		{
			string key = SearchTextBox.Text;
			_repository.FindRecordByKey(key);
			WithdrawDataGridView.DataSource = _repository.FindRecordByKey(key);
		}

		private void PopulateFields()
		{
			AccountNumberTextBox.Text = WithdrawDataGridView.CurrentRow.Cells[0].Value.ToString();
			NameTextBox.Text = WithdrawDataGridView.CurrentRow.Cells[1].Value.ToString();
			OldBalanceTextBox.Text = WithdrawDataGridView.CurrentRow.Cells[4].Value.ToString();
			ModeComboBox.Text = DEFAULT_MODE;
		}

		private void SetFieldDefault()
		{
			AccountNumberTextBox.Clear();
			NameTextBox.Clear();
			OldBalanceTextBox.Clear();
			ModeComboBox.Text = DEFAULT_MODE;
			AmountTextBox.Clear();
		}

		private void WithdrawMode()
		{
			var modes = _repository.GetAllMode();
			var combox = new ComboBoxUtility("Type", "Id", modes, ModeComboBox);
			combox.CreateComboBox();
		}

		private void GetAllRecord()
		{
			var records = _repository.GetAllRecord();
			WithdrawDataGridView.DataSource = records;
			TableHeader();
		}

		private void TableHeader()
		{
			if (WithdrawDataGridView.Columns["Amount"].HeaderText.Equals("Amount"))
				WithdrawDataGridView.Columns["Amount"].Visible = false;
			var tableUtil = new TableUtility(WithdrawDataGridView);
			var headers = new Dictionary<string, string>()
			{
				{"Account_Id", "Account Id" },
				{"Full_Name", "Full Name" },
				{"Gender", "Gender" },
				{"DateOfBirth", "Date Of Birth" },
				{"NewBalance", "Withdraw Balance History" },
				{"WithdrawDate", "Withdraw Date" },
				{"WithdrawTime", "Withdraw Time" },
			};
			tableUtil.SetColumnHeader(headers);
		}
	}
}
