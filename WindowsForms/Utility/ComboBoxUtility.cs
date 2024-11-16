using System.Collections;
using System.Windows.Forms;

namespace Martinez_BankApp.Utility
{
	public class ComboBoxUtility
	{
		public ComboBoxUtility(string displayMember, string valueMember, IEnumerable dataSource, ComboBox box)
		{
			DisplayMember = displayMember;
			ValueMember = valueMember;
			DataSource = dataSource;
			Box = box;
		}

		public string DisplayMember { get; private set; }
        public string ValueMember { get; private set; }
        public IEnumerable DataSource { get; private set; }
		public ComboBox Box { get; private set; }

		public ComboBox CreateComboBox()
		{
			Box.DisplayMember = DisplayMember;
			Box.ValueMember = ValueMember;
			Box.DataSource = DataSource;
			return Box;
		}
	}
}
