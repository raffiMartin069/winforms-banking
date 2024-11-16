using Martinez_BankApp.Factory;
using System;
using System.Windows.Forms;

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
	}
}
