using Martinez_BankApp.Contract.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Model.Dto.Admin
{
	public class DepositReportDto : ITransactionReport
	{
		public int Id { get; set; }
		public string Fullname { get; set; }
		public decimal CurrentBalance { get; set; }
		public decimal NewBalance { get; set; }
		public string Date { get; set; }
		public decimal PreviousBalance { get; set; }
	}
}
