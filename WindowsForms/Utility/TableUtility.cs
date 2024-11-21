using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.Utility
{
	public class TableUtility
	{
		public TableUtility(DataGridView view)
		{
			View = view;
		}

		public DataGridView View { get; set; }

		public void SetColumnHeader(Dictionary<string, string> headers)
		{
			foreach(var header in headers)
			{
				if((header.Key == null || header.Value == null))
					continue;
				View.Columns[header.Key].HeaderText = header.Value;
			}
		}
	}
}
