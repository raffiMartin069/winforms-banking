using Martinez_BankApp.View.Forms.Admin.ReportForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.Factory
{
	public static class ReportFactory
	{
		private static string EXCESS = ConfigurationManager.AppSettings["Excess"];

		private static string CreateAndFilterPath(string basePath, string pathToReport) => Path.Combine(basePath, pathToReport).Replace(EXCESS, "");

		public static ReportForm CreateReport(string pathToReport, IEnumerable record, Form form)
		{
			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string fullPath = CreateAndFilterPath(basePath, pathToReport);
			var report = new ReportForm(record, fullPath);
			report.MdiParent = form.MdiParent;
			report.Show();
			return report;
		}
	}
}
