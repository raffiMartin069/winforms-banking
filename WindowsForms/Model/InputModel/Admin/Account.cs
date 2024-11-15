using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Model.InputModel.Admin
{
	public class Account
	{
		public int UserId { get; set; }
		public Image ProfilePhoto { get; set; }
		public Image OriginalProfilePhoto { get; set; }
		public string FullName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Email { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
		public string HomeAddress { get; set; }
		public string MaritalStatus { get; set; }
		public string Gender { get; set; }
		public string MotherName { get; set; }
		public string FatherName { get; set; }
		public int AccountId { get; set; }
		public string Balance { get; set; }
	}
}
