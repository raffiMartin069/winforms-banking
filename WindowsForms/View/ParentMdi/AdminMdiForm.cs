using Martinez_BankApp.Factory;
using Martinez_BankApp.View.Forms.Admin;
using System;
using System.Windows.Forms;

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
	}
}
