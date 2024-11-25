using Martinez_BankApp.Factory;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Repository.Authentication;
using Martinez_BankApp.View.Forms.Admin;
using System;
using System.Windows.Forms;
using WinFormIdentity.Sessionizer;

namespace Martinez_BankApp.View.ParentMdi
{
	public partial class AdminMdiForm : Form
	{

		public AdminMdiForm()
		{
			InitializeComponent();
		}

		private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var factory = new AdminFormFactory(this);
			factory.CreateNewAccountForm();
		}

		private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var factory = new AdminFormFactory(this);
			factory.CreateWithdrawForm();
		}

		private void depositToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var factory = new AdminFormFactory(this);
			factory.CreateDepositForm();
		}

		private void updateAccountToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var factory = new AdminFormFactory(this);
			factory.CreateUpdateAccountForm();
		}

		private void searchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var factory = new AdminFormFactory(this);
			factory.CreateSearchAccountForm();
		}

		private void listOfCustomerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var factory = new AdminFormFactory(this);
			factory.CreateListOfCustomerForm();
		}

		private void transferToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var factory = new AdminFormFactory(this);
			factory.CreateTransferBalanceForm();

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
