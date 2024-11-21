using Martinez_BankApp.Model.InputModel.Admin;
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
	public partial class ClientWithdrawForm : Form
	{
		private readonly WithdrawRepository _repository;
		private const string DEFAULT_MODE = "ATM";

		public ClientWithdrawForm(WithdrawRepository repository)
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
				SetFieldDefault();
				MessageBox.Show(result);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ClearAllFieldButton_Click(object sender, EventArgs e)
		{
			SetFieldDefault();
		}

		private void WithdrawMode()
		{
			var modes = _repository.GetAllMode();
			var combox = new ComboBoxUtility("Type", "Id", modes, ModeComboBox);
			combox.CreateComboBox();
		}

		private void SetFieldDefault()
		{
			AccountNumberTextBox.Clear();
			NameTextBox.Clear();
			OldBalanceTextBox.Clear();
			ModeComboBox.Text = DEFAULT_MODE;
			AmountTextBox.Clear();
		}

		private void ClientWithdrawForm_Load(object sender, EventArgs e)
		{
			WithdrawMode();
		}
	}
}
