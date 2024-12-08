using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Contract.Admin
{
	public interface ITransactionReport
	{
		int Id { get; set; }
		string Fullname { get; set; }
		decimal CurrentBalance { get; set; }
		decimal NewBalance { get; set; }
		string Date { get; set; }
		decimal PreviousBalance { get; set; }
	}
}
