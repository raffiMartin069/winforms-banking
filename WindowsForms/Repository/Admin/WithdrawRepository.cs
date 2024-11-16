using Martinez_BankApp.Model.Dto.Admin;
using Martinez_BankApp.Persistent.Data;
using System.Collections;
using System.Linq;

namespace Martinez_BankApp.Repository.Admin
{
	public class WithdrawRepository
	{
        private readonly DBContextDataContext _context;
		public WithdrawRepository(DBContextDataContext context)
		{
			_context = context;
		}

		public IEnumerable GetAllMode() => _context.SP_GetAllWithdrawMode();
		
		public IEnumerable GetAllRecord() => _context.SP_GetAllWithdrawRecord();

		public IEnumerable FindRecordByKey(string key) => _context.SP_FindWithdrawById(key);

		public string AddWithdraw(WithdrawDto dto)
		{
			return _context.SP_Withdraw(dto.AccountNumber, dto.Name, dto.OldBalance, dto.Mode, dto.WithdrawAmount).FirstOrDefault().Message;
		}
	}
}
