using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Model.Dto.Admin
{
	public class WithdrawDto
	{
		public WithdrawDto(int accountNumber, string name, decimal oldBalance, string mode, decimal withdrawAmount)
		{
			AccountNumber = accountNumber;
			Name = name;
			OldBalance = oldBalance;
			Mode = mode;
			WithdrawAmount = withdrawAmount;
		}

		public int AccountNumber { get; private set; }
		public string Name { get; private set; }
		public decimal OldBalance { get; private set; }
		public string Mode { get; private set; }
		public decimal WithdrawAmount { get; private set; }
	}
}
