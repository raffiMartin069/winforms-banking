using Martinez_BankApp.View.ParentMdi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Factory
{
	public static class MdiFactory
	{
		public static AdminMdiForm CreateAdminMdiForm()
		{
			return new AdminMdiForm();
		}

		public static ClientMdiForm CreateClientMdiForm()
		{
			return new ClientMdiForm();
		}
	}
}
