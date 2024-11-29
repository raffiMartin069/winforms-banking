using Martinez_BankApp.Factory;
using Martinez_BankApp.InputModel.Model.Admin;
using Martinez_BankApp.Repository.Admin;
using Martinez_BankApp.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace Martinez_BankApp.View.Forms.Admin
{
	public partial class AdminDepositForm : Form
	{

		private readonly DepositRepository _repository;
		private readonly ReportRepository _report;
		
		//private int _accountId;
		private const string DEFAULT_DEPOSIT_MODE = "ATM";


		public AdminDepositForm(DepositRepository repository, ReportRepository report)
		{
			InitializeComponent();
			_repository = repository;
			_report = report;
		}

		private void AmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			try
			{
				var model = new Deposit
					(AccountNumberTextBox.Text,
					NameTextBox.Text,
					OldBalanceTextBox.Text,
					ModeComboBox.Text,
					AmountTextBox.Text);
				var data = model.Validate();
				var message = _repository.AddDeposit(data);
				GetAllRecord();
				MessageBox.Show(message);
				ClearAll();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
		}

		private void ClearAllFieldButton_Click(object sender, EventArgs e)
		{
			ClearAll();
		}


		private void AdminDepositForm_Load(object sender, EventArgs e)
		{
			GetAllRecord();
			DepositMode();
		}
		private void DepositDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			AccountNumberTextBox.Text = DepositDataGridView.CurrentRow.Cells[0].Value.ToString();
			NameTextBox.Text = DepositDataGridView.CurrentRow.Cells[1].Value.ToString();
			
			var currentBalance = DepositDataGridView.CurrentRow.Cells[4].Value.ToString();
			OldBalanceTextBox.Text = currentBalance;
			AccountBalanceLabel.Text = currentBalance; // assign balance for better display
		}

		private void DepositMode()
		{
			var modes = _repository.GetAllDepositMode();
			var combox = new ComboBoxUtility("Type", "Id", modes, ModeComboBox);
			combox.CreateComboBox();
		}

		private void ClearAll()
		{
			AccountNumberTextBox.Text = "";
			NameTextBox.Text = "";
			OldBalanceTextBox.Text = "";
			ModeComboBox.Text = DEFAULT_DEPOSIT_MODE;
			AmountTextBox.Text = "";
		}

		private void TableHeader()
		{
			//if(DepositDataGridView.Columns["Amount"].HeaderText.Equals("Amount"))
			//	DepositDataGridView.Columns["Amount"].Visible = false;
			
			var tableUtil = new TableUtility(DepositDataGridView);

			var headers = new Dictionary<string, string>()
			{
				{"Account_Id", "Account Id" },
				{"Full_Name", "Full Name" },
				{"Gender", "Gender" },
				{"DateOfBirth", "Date Of Birth" },
				{"NewBalance", "Current Balance" },
				{"Amount", "Previous Balance" },
				{"DepositDate", "Deposit Date" },
				{"DepositTime", "Deposit Time" },
			};
			tableUtil.SetColumnHeader(headers);
		}

		private void GetAllRecord()
		{
			var records = _repository.GetAllRecord();
			DepositDataGridView.DataSource = records;
			TableHeader();
		}

		private void SearchRecordTextBox_TextChanged(object sender, EventArgs e)
		{
			string key = SearchRecordTextBox.Text;
			var data = _repository.FindRecordByKey(key);
			DepositDataGridView.DataSource = data;
		}

		private void GenerateSummaryReportLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string path = ConfigurationManager.AppSettings["DepositReport"];
			ReportFactory.CreateReport(path, _report.GetDepositLog()?.ToList<object>(), this);
		}
	}
}
