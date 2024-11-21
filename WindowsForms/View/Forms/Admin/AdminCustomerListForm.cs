using Martinez_BankApp.Repository.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martinez_BankApp.View.Forms.Admin
{
	public partial class AdminCustomerListForm : Form
	{
		private readonly CustomerListRepository _repository;
		public AdminCustomerListForm(CustomerListRepository repository)
		{
			InitializeComponent();
			_repository = repository;
		}

		private void AdminCustomerListForm_Load(object sender, EventArgs e)
		{
			CustomerListDataGridView.DataSource = _repository.GetAllList()?.ToList();
			AssignTableHeader(CustomerListDataGridView);
		}

		private void AssignTableHeader(DataGridView view)
		{
			view.Columns["Id"].HeaderText = "ID";
			view.Columns["ProfilePicture"].HeaderText = "Profile Picture";
			view.Columns["Fullname"].HeaderText = "Full Name";
			view.Columns["Gender"].HeaderText = "Gender";
			view.Columns["Email"].HeaderText = "Email";
			view.Columns["PhoneNumber"].HeaderText = "Phone Number";
			view.Columns["MaritalStatus"].HeaderText = "Marital Status";
			view.Columns["DateOfBirth"].HeaderText = "Date of Birth";
			view.Columns["Address"].HeaderText = "Address";
			view.Columns["Fathername"].HeaderText = "Father's Name";
			view.Columns["Mothername"].HeaderText = "Mother's Name";
			view.Columns["Role"].HeaderText = "Role";
			view.Columns["BankAccountId"].HeaderText = "Bank Account ID";
			view.Columns["Balance"].HeaderText = "Balance";
		}
	}
}
