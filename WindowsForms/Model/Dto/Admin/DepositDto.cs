using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Model.Dto.Admin
{
	public class DepositDto
	{
		public DepositDto
			(int accountNumber, string name, decimal oldBalance,
			string mode, decimal depositAmount)
		{
			AccountNumber = accountNumber;
			Name = name;
			OldBalance = oldBalance;
			Mode = mode;
			DepositAmount = depositAmount;
		}

		public int AccountNumber { get; private set; }
		public string Name { get; private set; }
        public decimal OldBalance { get; private set; }
        public string Mode { get; private set; }
        public decimal DepositAmount { get; private set; }
    }
}
