using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Model.Dto.Admin
{
	public class TransferBalanceDto
	{
		public TransferBalanceDto(int senderAccountNumber, int recipientAccountNumber, decimal amount)
		{
			Amount = amount;
			SenderAccountNumber = senderAccountNumber;
			RecipientAccountNumber = recipientAccountNumber;
		}
		public int SenderAccountNumber { get; private set; }
		public int RecipientAccountNumber { get; private set; }
		public decimal Amount { get; private set; }
	}
}
