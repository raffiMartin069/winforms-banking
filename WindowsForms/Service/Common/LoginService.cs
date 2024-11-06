using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Service.Common
{
	public class LoginService
	{
		public void GetUserCredential(string username, string password)
		{
			if (string.IsNullOrEmpty(username))
				throw new Exception("Username is required");

			if (string.IsNullOrEmpty(password))
				throw new Exception("Password is required");
		}
	}
}
