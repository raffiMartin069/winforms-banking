using Martinez_BankApp.Factory;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Repository.Authentication;
using Martinez_BankApp.View.Forms.Admin;
using Martinez_BankApp.View.ParentMdi;
using System;
using System.Windows.Forms;

namespace Martinez_BankApp
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var context = new DBContextDataContext();
			var repository = new ClientLoginRepository(context);
			Application.Run(new LoginForm(repository));
			//Application.Run(new AdminMdiForm());
			// Application.Run(new ReportForm());
			//Application.Run(new ClientMdiForm());
		}
	}
}
