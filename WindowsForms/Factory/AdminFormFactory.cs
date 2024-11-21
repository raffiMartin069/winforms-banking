using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Repository.Admin;
using Martinez_BankApp.View.Forms.Admin;
using Martinez_BankApp.View.ParentMdi;
using System.Windows.Forms;

namespace Martinez_BankApp.Factory
{
	public class AdminFormFactory
	{
		private readonly AdminMdiForm _adminMdiForm;
		public AdminFormFactory(AdminMdiForm adminMdiForm)
		{
			_adminMdiForm = adminMdiForm;
		}

		private void ShowForm(Form form)
		{
			form.MdiParent = _adminMdiForm; 
			form.Show();
		}

		public void CreateDepositForm()
		{
			var context = new DBContextDataContext();
			var repository = new DepositRepository(context);
			var adminDepositForm = new AdminDepositForm(repository);
			ShowForm(adminDepositForm);
		}

		public void CreateUpdateAccountForm()
		{
			var context = new DBContextDataContext();
			var repository = new UpdateAccountRepository(context);
			var adminUpdateAccountForm = new AdminUpdateAccountForm(repository);
			ShowForm(adminUpdateAccountForm);
		}

		public void CreateWithdrawForm()
		{
			var context = new DBContextDataContext();
			var repository = new WithdrawRepository(context);
			var admingWithdrawalWindow = new AdminWithdrawForm(repository);
			ShowForm(admingWithdrawalWindow);
		}

		public void CreateNewAccountForm()
		{
			var context = new DBContextDataContext();
			var repository = new CreateNewAccountRepository(context);
			var createNewAccountWindow = new CreateNewAccountForm(new CreateNewAccountRepository(context));
			ShowForm(createNewAccountWindow);
		}

		public void CreateSearchAccountForm()
		{
			var context = new DBContextDataContext();
			var repository = new SearchAccountRepository(context);
			var updateExistingAccount = new AdminSearchAccountForm(repository);
			ShowForm(updateExistingAccount);
		}

		public void CreateListOfCustomerForm()
		{
			var context = new DBContextDataContext();
			var repository = new CustomerListRepository(context);
			var listOfCustomer = new AdminCustomerListForm(repository);
			ShowForm(listOfCustomer);
		}

		public void CreateTransferBalanceForm()
		{
			var context = new DBContextDataContext();
			var repository = new TransferBalanceRepository(context);
			var transferBalance = new AdminTransferBalanceForm(repository);
			ShowForm(transferBalance);
		}
	}
}
