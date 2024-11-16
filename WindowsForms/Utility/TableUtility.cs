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

		/**
		 * <summary>
		 * Pass null if you want to skip a header and content of a column.
		 * </summary>
		 * **/
		//public void SetColumnHeader(string[] defaultHeader, string[] header)
		//{
		//	for (int i = 0; i < defaultHeader.Length; i++)
		//	{
		//		if (defaultHeader[i] == null && header[i] == null)
		//			continue;

		//		View.Columns[i].HeaderText = header[i];
		//	}
		//}
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
