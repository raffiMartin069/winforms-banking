using Martinez_BankApp.Model.Dto.Admin;
using Martinez_BankApp.Persistent.Data;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Repository.Admin
{
	public class ReportRepository
	{
		private readonly DBContextDataContext _context;

		public ReportRepository(DBContextDataContext context)
		{
			_context = context;
		}

		public IEnumerable<WithdrawReportDto> GetWithdrawLog() => from result in _context.SP_GetAllWithdrawRecord()
													 select new WithdrawReportDto
													 {
														 Id = result.Account_Id,
														 Fullname = result.Full_Name,
														 CurrentBalance = result.Amount,
														 PreviousBalance = result.NewBalance,
														 Date = result.WithdrawDate.ToString()
													 };

		public IEnumerable<DepositReportDto> GetDepositLog() => from result in _context.SP_GetAllDepositRecord()
																  select new DepositReportDto
																  {
																	  Id = result.Account_Id,
																	  Fullname = result.Full_Name,
																	  CurrentBalance = result.Amount,
																	  PreviousBalance = result.NewBalance,
																	  Date = result.DepositDate.ToString()
																  };
	}
}
