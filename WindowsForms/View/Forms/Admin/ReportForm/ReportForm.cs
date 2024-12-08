using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.View.Forms.Admin.ReportForms
{
	public partial class ReportForm : Form
	{
		private readonly List<object> _report;
		private readonly string _path;
		private ReportDocument _docs = new ReportDocument(); 

		public ReportForm(List<object> report, string path)
		{
			InitializeComponent();
			_report = report;
			_path = path;
		}

		private void WithdrawReportForm_Load(object sender, EventArgs e)
		{
			try
			{
				_docs.Load(_path);
				_docs.SetDataSource(_report);
				ReportViewer.ReportSource = _docs;
				ReportViewer.Refresh();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
		}
	}
}
