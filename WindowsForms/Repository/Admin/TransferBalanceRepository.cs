using Martinez_BankApp.Model.Dto.Admin;
using Martinez_BankApp.Persistent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Repository.Admin
{
	public class TransferBalanceRepository
	{
        private readonly DBContextDataContext _context;
		public TransferBalanceRepository(DBContextDataContext context)
		{
			_context = context;
		}

		public string SendBalance(TransferBalanceDto dto)
		{
			return _context.SP_AdminSendCash(dto.SenderAccountNumber, dto.RecipientAccountNumber, dto.Amount).FirstOrDefault().MESSAGE;
		}

		public string GetName(int accountNumber) => _context.SP_GetName(accountNumber).FirstOrDefault().MESSAGE;
	}
}
