
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

		public IEnumerable<SP_GetUserCredentialResult> Validate(string email, string password)
		{
			return _context.SP_GetUserCredential(email, password);
		}
	}
}
