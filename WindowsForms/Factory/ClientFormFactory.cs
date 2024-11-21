using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Repository.Admin;
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
			var context = new DBContextDataContext();
			var repository = new DepositRepository(context);
			var clientDepositForm = new ClientDepositForm(repository);
			clientDepositForm.MdiParent = _clientMdiForm;
			clientDepositForm.Show();
		}

		public void ClientWithdrawForm()
		{
			var context = new DBContextDataContext();
			var repository = new WithdrawRepository(context);
			var clientWithdrawForm = new ClientWithdrawForm(repository);
			clientWithdrawForm.MdiParent = _clientMdiForm;
			clientWithdrawForm.Show();
		}
	}
}
