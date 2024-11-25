using Martinez_BankApp.Factory;
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
	}
}
