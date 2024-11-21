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
	public partial class AdminSearchAccountForm : Form
	{
		private readonly SearchAccountRepository _repository;
		public AdminSearchAccountForm(SearchAccountRepository repository)
		{
			InitializeComponent();
			_repository = repository;
		}


		private DataGridView InitializeGridView<T>(IEnumerable<T> data)
		{
			dataGridView1.DataSource = data;
			return dataGridView1;
		}

		private void LoadUserList()
		{
			InitializeGridView(_repository.GetUserList()?.ToList());
			AssignTableHeader(dataGridView1);
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

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			var key = textBox1.Text;
			var result = _repository.GetUserList(key)?.ToList();
			InitializeGridView(result);
			AssignTableHeader(dataGridView1);
		}


		private void AdminSearchAccountForm_Load(object sender, EventArgs e)
		{
			LoadUserList();
			
		}
	}
}
