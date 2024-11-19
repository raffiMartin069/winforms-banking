using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Model.Dto.Admin
{
	public class TransferBalanceDto
	{
		public TransferBalanceDto(int accountNumber, decimal amount)
		{
			AccountNumber = accountNumber;
			Amount = amount;
		}
		public int AccountNumber { get; private set; }
		public decimal Amount { get; private set; }
	}
}
