using Martinez_BankApp.InputModel.Model.Admin;
using Martinez_BankApp.Repository.Admin;
using Martinez_BankApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.View.Forms.Client
{
	public partial class ClientDepositForm : Form
	{
		private readonly DepositRepository _repository;
		private const string DEFAULT_DEPOSIT_MODE = "ATM";
		public ClientDepositForm(DepositRepository repository)
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
				var message = _repository.AddDeposit(data);
				MessageBox.Show(message);
				ClearAll();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
		}

		private void DepositMode()
		{
			var modes = _repository.GetAllDepositMode();
			var combox = new ComboBoxUtility("Type", "Id", modes, ModeComboBox);
			combox.CreateComboBox();
		}

		private void AmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}
		}

		private void ClientDepositForm_Load(object sender, EventArgs e)
		{
			DepositMode();
		}

		private void ClearAll()
		{
			AccountNumberTextBox.Text = "";
			NameTextBox.Text = "";
			OldBalanceTextBox.Text = "";
			ModeComboBox.Text = DEFAULT_DEPOSIT_MODE;
			AmountTextBox.Text = "";
		}

		private void ClearAllFieldButton_Click(object sender, EventArgs e)
		{
			ClearAll();
		}
	}
}
