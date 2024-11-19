using Martinez_BankApp.Model.InputModel.Admin;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Repository.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.View.Forms.Admin
{
	public partial class AdminTransferBalanceForm : Form
	{
		private readonly TransferBalanceRepository _repository;
		public AdminTransferBalanceForm(TransferBalanceRepository repository)
		{
			InitializeComponent();
			_repository = repository;
		}

		private void SendACashButton_Click(object sender, EventArgs e)
		{
			string accountNumber = AccountNumberTextBox.Text;
			string amount = AmountTextBox.Text;
			var model = new TransferBalance(accountNumber, amount, _repository);
			try
			{
				var clientName = model.ValidateNameExist();
				
				bool isConfirmed = ConfirmationPrompt(amount, clientName);
				if(!isConfirmed)
					return;
				
				var result = model.Validate();
				MessageBox.Show(result + " to " + clientName);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private bool ConfirmationPrompt(string amount, string clientName)
		{
			MessageBox.Show($"Are you sure you want to send {amount} to {clientName}?", "Confirmation", MessageBoxButtons.YesNo);
			if (DialogResult == DialogResult.No)
				return false;
			return true;
		}

		private void ClearAllFieldButton_Click(object sender, EventArgs e)
		{
			SetToDefault();
		}

		private void SetToDefault()
		{
			AccountNumberTextBox.Text = "";
			AmountTextBox.Text = "";
		}
	}
}
