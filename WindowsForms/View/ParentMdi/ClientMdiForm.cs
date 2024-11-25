using Martinez_BankApp.Factory;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Repository.Authentication;
using System;
using System.Windows.Forms;
using WinFormIdentity.Sessionizer;

namespace Martinez_BankApp.View.ParentMdi
{
	public partial class ClientMdiForm : Form
	{

		public ClientMdiForm()
		{
			InitializeComponent();
		}

		private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var factory = new ClientFormFactory(this);
			factory.ClientWithdrawForm();
		}

		private void depositToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var factory = new ClientFormFactory(this);
			factory.ClientDepositForm();
		}

		private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Session.Clear();
			var context = new DBContextDataContext();
			var repository = new ClientLoginRepository(context);
			var loginForm = new LoginForm(repository);
			loginForm.Show();
			this.Close();
		}
	}
}
