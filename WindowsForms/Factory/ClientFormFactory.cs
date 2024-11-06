using Martinez_BankApp.View.Forms.Client;
using Martinez_BankApp.View.ParentMdi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Factory
{
	public class ClientFormFactory
	{

		private readonly ClientMdiForm _clientMdiForm;
		public ClientFormFactory(ClientMdiForm clientMdiForm)
		{
			_clientMdiForm = clientMdiForm;
		}

		public void ClientDepositForm()
		{
			var clientDepositForm = new ClientDepositForm();
			clientDepositForm.MdiParent = _clientMdiForm;
			clientDepositForm.Show();
		}

		public void ClientWithdrawForm()
		{
			var clientWithdrawForm = new ClientWithdrawForm();
			clientWithdrawForm.MdiParent = _clientMdiForm;
			clientWithdrawForm.Show();
		}
	}
}
