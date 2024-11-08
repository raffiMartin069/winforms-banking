using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.Utility
{
	public class TableGenerator
	{
		/**
		 * <summary>
		 * This class will generate a table based on a column and header name provided.
		 * To avoid confusion ensure that both column and header name are equal.
		 * <br/>
		 * <br/>
		 * <br/>
		 * If incase an image is needed to be generated, ensure that both column and header name has a <strong>"Profile Photo"</strong> name
		 * otherwise this will not be generated.
		 * <see cref="GenerateTableCoumns()"/>
		 * <seealso cref="CreateImageColumn(string, string)"/>"/>
		 * <seealso cref="CheckColumnIntegrity()"/>"/>
		 * </summary>
		 * **/
		public TableGenerator(DataGridView tableView, List<string> columnName, List<string> columnHeader)
        {
            TableView = tableView;
			ColumnName = columnName;
			ColumnHeader = columnHeader;
		}

        public DataGridView TableView { get; private set; }
		public List<string> ColumnName { get; private set; }
		public List<string> ColumnHeader { get; private set; }

		/**
		 * <summary>
		 * Both Column name and header should be equal otherwise the table would be imbalance and might provide weird results.
		 * </summary>
		 * **/
		private void CheckListLenght()
		{
			if (ColumnName.Count != ColumnHeader.Count)
				throw new Exception("Column name and header must be equal");
		}

		private void CreateImageColumn(string columnName, string columnHeader) 
		{
			if (columnName == "Profile Photo")
			{
				TableView.Columns.Add(new DataGridViewImageColumn()
				{
					Name = columnName,
					HeaderText = columnHeader,
					ImageLayout = DataGridViewImageCellLayout.Zoom
				});
			}
		}

		public DataGridView GenerateTableCoumns()
        {
			CheckListLenght();

			for (int i = 0; i < ColumnName.Count; i++)
			{
				if (ColumnName[i] != ColumnHeader[i] || ColumnHeader[i] != ColumnName[i])
					throw new Exception("Column name and header must be equal");

				CreateImageColumn(ColumnName[i], ColumnHeader[i]);

				// Profile Photo column was already added so we skip this part.
				if (ColumnName[i] == "Profile Photo")
					continue;

				TableView.Columns.Add(ColumnName[i], ColumnHeader[i]);
			}

			return TableView;
		}
	}
}
