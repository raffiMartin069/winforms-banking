using Martinez_BankApp.Contract.Admin;
using Martinez_BankApp.Model.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.InputModel.Model.Admin
{
	public class Deposit
	{
		public Deposit(string accountNumber, string fullName, string oldBalance, string mode, string amount)
		{
			AccountNumber = accountNumber;
			FullName = fullName;
			OldBalance = oldBalance;
			Mode = mode;
			Amount = amount;
		}

		public string AccountNumber { get; set; }
        public string FullName { get; set; }
        public string OldBalance { get; set; }
        public string Mode { get; set; }
        public string Amount { get; set; }

		private bool CheckDecimalValidity()
		{
			if (!decimal.TryParse(OldBalance, out decimal oldBalance))
				throw new Exception("Please enter a valid balance");

			if (!decimal.TryParse(Amount, out decimal amount))
				throw new Exception("Please enter a valid deposit amount.");

			return true;
		}

		private bool CheckStrValidity()
		{
			if (string.IsNullOrEmpty(AccountNumber))
				throw new Exception("Account number must not be emty.");

			if (string.IsNullOrEmpty(FullName))
				throw new Exception("Full name must not be emty.");

			if (string.IsNullOrEmpty(Mode))
				throw new Exception("Mode can not be empty.");

			return true;
		}

		public DepositDto Validate()
		{
			bool isValidStr = CheckStrValidity();
			bool isValidDecimal = CheckDecimalValidity();
			string exception = "Something went wrong, please try again later";
			return !isValidDecimal && !isValidStr ? throw new Exception(exception) : new DepositDto
			(
				int.Parse(AccountNumber),
				FullName,
				decimal.Parse(OldBalance),
				Mode,
				decimal.Parse(Amount)
			);
		}
	}
}
