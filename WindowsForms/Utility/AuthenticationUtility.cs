using Martinez_BankApp.Factory;
using System;
using WinFormIdentity.Sessionizer;

namespace Martinez_BankApp.Utility
{
	public static class AuthenticationUtility
	{
		private const string ADMINISTRATIVE_ACCESS = "Admin";
		public static void ValidateRole()
		{
			if (Session.GetClaim("Role").Equals(ADMINISTRATIVE_ACCESS))
				MdiFactory.CreateAdminMdiForm().Show();
			else
				MdiFactory.CreateClientMdiForm().Show();
		}

		public static void ValidateFields(string password, string username)
		{
			if (string.IsNullOrEmpty(username))
			{
				throw new Exception("Username and Password can not be empty.");
			}

			if (string.IsNullOrEmpty(password))
			{
				throw new Exception("Username and Password can not be empty.");
			}
		}
	}
}
