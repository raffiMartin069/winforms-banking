using Martinez_BankApp.Model.Dto.Admin;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Repository.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.Model.InputModel.Admin
{
	public class TransferBalance
	{
		private readonly TransferBalanceRepository _repository;
		public TransferBalance(string senderAccountNumber, string recipientAccountNumber, string amount, TransferBalanceRepository repository)
		{
			Amount = amount;
			_repository = repository;
			SenderAccountNumber = senderAccountNumber;
			RecipientAccountNumber = recipientAccountNumber;
		}

		public string SenderAccountNumber { get; private set; }
		public string RecipientAccountNumber { get; private set; }
		public string Amount { get; private set; }

		public string SendBalance()
		{
			// This will check if accidentally sent to the same account.
			ValidateDestination();

			ValidateInputs();

			int sender = ValidateSenderAccountNumber();
			int recipient = ValidateRecipientAccountNumber();
			decimal amount = ValidateAmount();

			var dto = new TransferBalanceDto(sender, recipient, amount);

			return _repository.SendBalance(dto);
		}

		private void ValidateDestination()
		{
			if (SenderAccountNumber.Equals(RecipientAccountNumber))
				throw new Exception("You can not send cash to the same account.");
		}

		public string GetName()
		{
			int accountNumber = ValidateRecipientAccountNumber();
			string name = _repository.GetName(accountNumber);

			if(name.Equals(null) || name.Equals(""))
				throw new Exception("Account number does not exist.");

			return name;
		}

		private void ValidateInputs()
		{
			if (SenderAccountNumber.Equals(""))
				throw new Exception("Account number or amount can not be empty.");

			if (RecipientAccountNumber.Equals(""))
				throw new Exception("Account number or amount can not be empty.");

			if(Amount.Equals(""))
				throw new Exception("Account number or amount can not be empty.");
		}

		private int ValidateRecipientAccountNumber()
		{
			if (!int.TryParse(RecipientAccountNumber, out int accountNumber))
				throw new Exception("Please enter a valid Account number.");
			return accountNumber;
		}

		private int ValidateSenderAccountNumber()
		{
			if (!int.TryParse(SenderAccountNumber, out int accountNumber))
				throw new Exception("Please enter a valid Account number.");
			return accountNumber;
		}

		private decimal ValidateAmount()
		{
			if (!decimal.TryParse(Amount, out decimal amount))
				throw new Exception("Please enter a valid Amount.");

			return amount;
		}

		public void ValidateAmount(string amount)
		{
			if (!decimal.TryParse(amount, out decimal cash))
				throw new Exception("Please enter a valid Amount.");

			if (cash <= 0)
				throw new Exception("Amount can not be less than or equal to zero.");
		}
	}
}