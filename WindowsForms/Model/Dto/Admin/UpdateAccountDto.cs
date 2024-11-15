using System;

namespace Martinez_BankApp.Model.Dto.Admin
{
	public class UpdateAccountDto
	{
		public UpdateAccountDto
			(int id, string fullName, DateTime dateOfBirth,
			string email, string password, string repeatPassword,
			string phone, string address, string maritalStatus,
			string gender, string motherName, string fatherName, 
			string role, decimal balance, byte[] profilePicture)
		{
			Id = id;
			FullName = fullName;
			DateOfBirth = dateOfBirth;
			Email = email;
			Password = password;
			RepeatPassword = repeatPassword;
			Phone = phone;
			Address = address;
			MaritalStatus = maritalStatus;
			Gender = gender;
			MotherName = motherName;
			FatherName = fatherName;
			Role = role;
			Balance = balance;
			ProfilePicture = profilePicture;
		}

		public int Id { get; private set; }
		public string FullName { get; private set; }
		public DateTime DateOfBirth { get; private set; }
		public string Email { get; private set; }
		public string Password { get; private set; }
		public string RepeatPassword { get; private set; }
		public string Phone { get; private set; }
		public string Address { get; private set; }
		public string MaritalStatus { get; private set; }
		public string Gender { get; private set; }
		public string MotherName { get; private set; }
		public string FatherName { get; private set; }
		public string Role { get; private set; }
		public decimal Balance { get; private set; }
		public byte[] ProfilePicture { get; private set; }
	}
}
