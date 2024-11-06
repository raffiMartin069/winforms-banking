using Martinez_BankApp.Dto.Admin;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Repository.Admin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.Service.Admin
{
	public class CreateNewAccountService
	{
		private DBContextDataContext _context = new DBContextDataContext();

        public IEnumerable GetAllGender()
		{
			var service = new CreateNewAccountRepository(_context);
			return service.GetAllGender();
		}

		public IEnumerable GetAllMaritalStatus()
		{
			var service = new CreateNewAccountRepository(_context);
			return service.GetAllMaritalStatus();
		}

		public IEnumerable GetAllRole()
		{
			var service = new CreateNewAccountRepository(_context);
			return service.GetAllRole();
		}

		public string AddAccount(NewAccountDto dto)
		{
			try
			{
				var service = new CreateNewAccountRepository(_context);

				return service.AddAccount(dto);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return "1";
			}
		}

		public ISingleResult<SP_DisplayNewAccountCreatedResult> GetAllNewAccount()
		{
			try
			{
				var accounts = new CreateNewAccountRepository(_context);
				return accounts.GetAllNewAccountCreated();
			}
			catch (Exception)
			{
				ISingleResult<SP_DisplayNewAccountCreatedResult> result = null;
				return result;
			}
				
		}
	}
}
