using Martinez_BankApp.Factory;
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
			Application.Run(new LoginForm());
			//Application.Run(new AdminMdiForm());
			//Application.Run(new ClientMdiForm());
		}
	}
}
