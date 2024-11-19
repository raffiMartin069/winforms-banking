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
		public TransferBalance(string accountNumber, string amount, TransferBalanceRepository repository)
		{
			AccountNumber = accountNumber;
			Amount = amount;
			_repository = repository;
		}

		public string AccountNumber { get; private set; }
        public string Amount { get; private set; }

		public string Validate()
		{
			ValidateInputs();
			int id = ValidateAccountNumber();
			decimal amount = ValidateAmount();

			return _repository.AddBalance(id, amount);
		}

		public string ValidateNameExist()
		{
			int accountNumber = ValidateAccountNumber();
			string name = _repository.GetName(accountNumber);

			if(name.Equals(null) || name.Equals(""))
				throw new Exception("Account number does not exist.");

			return name;
		}

		private void ValidateInputs()
		{
			if (AccountNumber.Equals("") || Amount.Equals(""))
			{
				throw new Exception("Account number or amount can not be empty.");
			}
		}

		private int ValidateAccountNumber()
		{
			if (!int.TryParse(AccountNumber, out int accountNumber))
				throw new Exception("Please enter a valid Account number.");
			return accountNumber;
		}

		private decimal ValidateAmount()
		{
			if (!decimal.TryParse(Amount, out decimal amount))
				throw new Exception("Please enter a valid Amount.");
			return amount;
		}
	}
}
