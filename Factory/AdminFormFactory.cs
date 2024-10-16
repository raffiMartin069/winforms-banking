using Martinez_BankApp.View.Forms.Admin;
using Martinez_BankApp.View.ParentMdi;
using System;
using System.Collections.Generic;
using System.Linq;
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
			var adminUpdateAccountForm = new AdminUpdateAccountForm();
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
			var createNewAccountWindow = new CreateNewAccountForm();
			createNewAccountWindow.MdiParent = _adminMdiForm;
			createNewAccountWindow.Show();
		}
	}
}
