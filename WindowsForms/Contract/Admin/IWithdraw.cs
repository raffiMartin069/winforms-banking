using Martinez_BankApp.Model.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Contract.Admin
{
	public interface IWithdraw
	{
		WithdrawDto Validate();
	}
}
