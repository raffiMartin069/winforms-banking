using Martinez_BankApp.Enum;
using Martinez_BankApp.Model.Dto.Admin;
using Martinez_BankApp.Repository.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Martinez_BankApp.Model.InputModel.Admin
{
	public class NewAccount
	{
		private CreateNewAccountRepository _repo;
		public NewAccount(string email, string dateOfBirth, string password, string repeatPassword,
			string name, string phoneNumber, string address, string maritalStatus,
			string gender, string motherName, string fatherName, string role,
			string balance, byte[] profilePicture, CreateNewAccountRepository repo)
		{
			Email = email;
			DateOfBirth = dateOfBirth;
			Password = password;
			RepeatPassword = repeatPassword;
			Name = name;
			PhoneNumber = phoneNumber;
			Address = address;
			MaritalStatus = maritalStatus;
			Gender = gender;
			MotherName = motherName;
			FatherName = fatherName;
			Role = role;
			Balance = balance;
			ProfilePicture = profilePicture;
			_repo = repo;
		}

		public string Email { get; private set; }
		public string DateOfBirth { get; private set; }
		public string Password { get; private set; }
		public string RepeatPassword { get; private set; }
		public string Name { get; private set; }
		public string PhoneNumber { get; private set; }
		public string Address { get; private set; }
		public string MaritalStatus { get; private set; }
		public string Gender { get; private set; }
		public string MotherName { get; private set; }
		public string FatherName { get; private set; }
		public string Role { get; private set; }
		public string Balance { get; private set; }
		public byte[] ProfilePicture { get; private set; }

		public bool AddAccount()
		{
			ValidateEmail();
			ValidateDateOfBirth();
			ValidatePassword();
			ValidateName();
			ValidatePhoneNumber();
			ValidateAddress();
			ValidateMarriageStatus();
			ValidateGender();
			ValidateRole();
			ValidateBalance();
			ValidateByteProfile();

			var account = new CreateAccountDto
					(Name, DateTime.Parse(DateOfBirth).Date, Email,
					Password, RepeatPassword, PhoneNumber,
					Address, MaritalStatus, Gender,
					MotherName, FatherName, Role, decimal.Parse(Balance), ProfilePicture);

			return _repo.CreateAccount(account) == "0" ? true : false;
		}

		private void ValidateEmail()
		{
			if (string.IsNullOrEmpty(Email))
				throw new Exception("Email is required");

			// check if email contains @ and use regex
			if (!Email.Contains("@") || !Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
				throw new Exception("Email is invalid");
		}

		private void ValidateDateOfBirth()
		{
			if (string.IsNullOrEmpty(DateOfBirth))
				throw new Exception("Date of Birth is required");

			if (!DateTime.TryParse(DateOfBirth, out DateTime dob))
				throw new Exception("Date of birth must not be empty");
		}

		private void ValidatePassword()
		{
			if (string.IsNullOrEmpty(Password))
				throw new Exception("Password is required");

			if (string.IsNullOrEmpty(RepeatPassword))
				throw new Exception("Repeat Password is required");

			if (!Password.Equals(RepeatPassword))
				throw new Exception("Password does not match");
		}

		private void ValidateName() 
		{
			if (string.IsNullOrEmpty(Name))
				throw new Exception("Name is required");
		}

		private void ValidatePhoneNumber()
		{
			if (string.IsNullOrEmpty(PhoneNumber))
				throw new Exception("Phone Number is required");
			
			if (PhoneNumber.Length != 11)
				throw new Exception("Phone Number must be 11 digits");

			if (!PhoneNumber.StartsWith("09"))
				throw new Exception("Phone Number must start with 09");
		}

		private void ValidateAddress()
		{
			if (string.IsNullOrEmpty(Address))
				throw new Exception("Address is required");
		}

		private void ValidateMarriageStatus()
		{
			if (string.IsNullOrEmpty(MaritalStatus))
				throw new Exception("Marital Status is required");

			var status = typeof(Enum.MarriageStatusEnums);
			bool isMatched = false;
			foreach (var i in status.GetEnumValues())
			{
				if (MaritalStatus == i.ToString())
					isMatched = true;
			}

			if (!isMatched)
				throw new Exception("Marital Status is invalid");
		}

		private void ValidateGender()
		{
			if (string.IsNullOrEmpty(Gender))
				throw new Exception("Gender can not be empty");

			// We need to loop since we have enums listed in our program.
			// However manual should be done on other choices since they are not qualified to be enums due to white spaces.
			var genders = typeof(Enum.GenderEnums);
			bool isMatched = false;
			foreach(var i in genders.GetEnumValues())
			{
				if (Gender == i.ToString())
					isMatched = true;
			}

			if (Gender.Equals("Genderqueer / Gender Non-Conforming"))
				isMatched = true;

			if (Gender.Equals("Non-Binary"))
				isMatched = true;

			if (Gender.Equals("Prefer Not to Say"))
				isMatched = true;

			if (!isMatched)
				throw new Exception("Please select gender according to the drop down menu.");
		}

		private void ValidateRole()
		{
			if (string.IsNullOrEmpty(Role))
				throw new Exception("Role is required");

			var role = typeof(Enum.RoleEnums);
			bool isMatched = false;
			foreach(var i in role.GetEnumValues())
			{
				if (Role == i.ToString())
					isMatched = true;
			}

			if(!isMatched)
				throw new Exception("Role is invalid");
		}

		private void ValidateBalance()
		{
			if (string.IsNullOrEmpty(Balance))
				throw new Exception("Balance is required");

			if (!decimal.TryParse(Balance, out decimal convertedBalance))
				throw new Exception("Balance must not be empty");

			if (convertedBalance <= 0)
				throw new Exception("Balance must be greater than 0");

			if (convertedBalance % 100 != 0)
				throw new Exception("Balance must be a multiple of hundreds or thousands");
		}

		private void ValidateByteProfile()
		{
			if (ProfilePicture == null)
				throw new Exception("Profile Picture is required");

			if (ProfilePicture.Length == 0)
				throw new Exception("Profile Picture is empty");

			if (ProfilePicture.Length > 1000000)
				throw new Exception("Profile Picture is too large");

			if (ProfilePicture.Length < 1000)
				throw new Exception("Profile Picture is too small");
		}
	}
}
