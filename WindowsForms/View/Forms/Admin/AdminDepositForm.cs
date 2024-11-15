using Martinez_BankApp.Dto.Admin;
using Martinez_BankApp.Model.Admin;
using Martinez_BankApp.Repository.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.View.Forms.Admin
{
	public partial class AdminDepositForm : Form
	{

		private readonly DepositRepository _repository;
		private int _accountId;
		private const string DEFAULT_DEPOSIT_MODE = "ATM";

		public AdminDepositForm(DepositRepository repository)
		{
			InitializeComponent();
			_repository = repository;
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

				if(data == null)
				{
					MessageBox.Show("Please fill all fields.");
					return;
				}

				var message = _repository.AddDeposit(data);

				DepositRecord();
				MessageBox.Show(message);
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
			DepositRecord();
			DepositMode();
		}
		private void DepositDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			AccountNumberTextBox.Text = DepositDataGridView.CurrentRow.Cells[0].Value.ToString();
			NameTextBox.Text = DepositDataGridView.CurrentRow.Cells[1].Value.ToString();
			OldBalanceTextBox.Text = DepositDataGridView.CurrentRow.Cells[4].Value.ToString();
		}


		private void DepositMode()
		{
			ModeComboBox.DataSource = _repository.GetAllDepositMode();
			ModeComboBox.DisplayMember = "Type";
			ModeComboBox.ValueMember = "Id";
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
			DepositDataGridView.Columns["Account_Id"].HeaderText = "Account Id";
			DepositDataGridView.Columns["Full_Name"].HeaderText = "Full Name";
			DepositDataGridView.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
			DepositDataGridView.Columns["CurrentBalance"].HeaderText = "Current Balance";
		}

		private void DepositRecord()
		{
			var records = _repository.GetAllRecord();
			DepositDataGridView.DataSource = records;
			TableHeader();
		}
	}
}
