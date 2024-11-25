
using Martinez_BankApp.Model.Dto;
using Martinez_BankApp.Persistent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Martinez_BankApp.Repository.Authentication
{
	public class ClientLoginRepository
	{
		private readonly DBContextDataContext _context;
		public ClientLoginRepository(DBContextDataContext context)
		{
			_context = context;
		}

		public IEnumerable<LoginAccountDto> Validate(string email, string password)
		{
			var result = from account in _context.SP_GetUserCredential(email, password)
					 select new LoginAccountDto
					 {
						 Id = account.Id,
						 Email = account.Email,
						 Role = account.Type
					 };

			return result;
		}
	}
}
