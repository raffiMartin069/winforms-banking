using Martinez_BankApp.Model.InputModel.Admin;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Repository.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
			string senderId = SenderAccountNumberTextBox.Text;
			string recipientId = RecipientAccountNumberTextBox.Text;
			string amount = AmountTextBox.Text;
			var model = new TransferBalance(senderId, recipientId, amount, _repository);
			try
			{
				// Get the name of the client. 
				// This is to let admin identify if he/she is sending the cash to the right account. 
				var clientName = model.GetName();

				// Overload the method ValidateAmount to check the amount early instead after confirmation is done.
				model.ValidateAmount(amount);

				bool isConfirmed = ConfirmationPrompt(amount, clientName);
				if (!isConfirmed)
					return;

				// Send the cash to the recipient.
				var result = model.SendBalance();

				// Extract the result of the transaction.
				string msg = ExtractSendACashResult(result);

				MessageBox.Show(msg);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/**
		 * <summary>
		 * The database will throw away a custom message if the transaction is failed and only when the custom error is defined in the database.
		 * The default error message is "1" if the transaction is failed and "0" if success.
		 * Other than that it means that the error might be custom.
		 * </summary>
		 * **/
		private string ExtractSendACashResult(string result)
		{
			string success = "0";
			string failed = "1";
			string custom = result;
			if (result.Equals(failed))
				return "Express send failed to transfer a cash. Please try again later.";

			if (result.Equals(success))
				return "Express send sent succesfully.";

			return custom;
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
			RecipientAccountNumberTextBox.Text = "";
			AmountTextBox.Text = "";
		}
	}
}
