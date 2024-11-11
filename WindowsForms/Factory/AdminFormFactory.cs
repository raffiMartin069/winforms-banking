using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Repository.Admin;
using Martinez_BankApp.View.Forms.Admin;
using Martinez_BankApp.View.ParentMdi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Factory
{
	public class AdminFormFactory
	{
		private readonly AdminMdiForm _adminMdiForm;
		public AdminFormFactory(AdminMdiForm adminMdiForm)
		{
			_adminMdiForm = adminMdiForm;
		}

		public void AdminDepositForm()
		{
			var adminDepositForm = new AdminDepositForm();
			adminDepositForm.MdiParent = _adminMdiForm;
			adminDepositForm.Show();
		}

		public void AdminUpdateAccountForm()
		{
			var _context = new DBContextDataContext();
			var adminUpdateAccountForm = new AdminUpdateAccountForm(new AdminUpdateAccountRepository(_context));
			adminUpdateAccountForm.MdiParent = _adminMdiForm;
			adminUpdateAccountForm.Show();
		}

		public void AdminWithdrawForm()
		{
			var admingWithdrawalWindow = new AdminWithdrawForm();
			admingWithdrawalWindow.MdiParent = _adminMdiForm;
			admingWithdrawalWindow.Show();
		}

		public void CreateNewAccountForm()
		{
			using(var _context = new DBContextDataContext())
			{
				var createNewAccountWindow = new CreateNewAccountForm(new CreateNewAccountRepository(_context));
				createNewAccountWindow.MdiParent = _adminMdiForm;
				createNewAccountWindow.Show();
			}
		}

		public void AdminSearchAccount()
		{
			var updateExistingAccount = new AdminSearchAccountForm();
			updateExistingAccount.MdiParent = _adminMdiForm;
			updateExistingAccount.Show();
		}

		public void AdminListOfCustomer()
		{
			var listOfCustomer = new AdminCustomerListForm();
			listOfCustomer.MdiParent = _adminMdiForm;
			listOfCustomer.Show();
		}
	}
}
