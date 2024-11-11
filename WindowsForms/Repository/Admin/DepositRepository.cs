using Martinez_BankApp.Dto.Admin;
using Martinez_BankApp.Persistent.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Repository.Admin
{
	public class DepositRepository
	{

        private readonly DBContextDataContext _context;
		public DepositRepository(DBContextDataContext context)
		{
			_context = context;
		}

		public  IEnumerable GetAllRecord()
		{
			return _context.SP_GetAllDepositRecord();
		}

		public string AddDeposit(DepositDto dto)
		{
			return _context.SP_AddDeposit(dto.AccountNumber, dto.Name, dto.OldBalance, dto.Mode, dto.DepositAmount).SingleOrDefault().Message;
		}

		public IEnumerable GetAllDepositMode() => _context.SP_GetAllDepositMode();
	}
}
