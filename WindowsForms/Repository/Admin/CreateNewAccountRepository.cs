using Martinez_BankApp.Model.Dto.Admin;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using Account = Martinez_BankApp.Model.InputModel.Admin.Account;

namespace Martinez_BankApp.Repository.Admin
{
	public class CreateNewAccountRepository
	{
		private DBContextDataContext _context;

		public CreateNewAccountRepository(DBContextDataContext context)
		{
			_context = context;
		}

		public IEnumerable GetAllGender() => _context.SP_GetAllGender();

		public IEnumerable GetAllRole() => _context.SP_GetAllRoles();

		public IEnumerable GetAllMaritalStatus() => _context.SP_GetAllMartiralStatus();

		public IEnumerable<Account> GetAllAccount()
		{
			var result = from row in _context.SP_GetAllAccount()
						 select new Account
						 {
							 UserId = row.User_Identification,
							 FullName = row.Client_s_Full_Name,
							 DateOfBirth = row.Date_of_Birth,
							 Email = row.Email,
							 Role = row.Role,
							 PhoneNumber = row.Phone_Number,
							 HomeAddress = row.Home_Address,
							 MaritalStatus = row.Marital_Status,
							 Gender = row.Gender,
							 MotherName = row.Mother_s_Name,
							 FatherName = row.Father_s_Name,
							 AccountId = row.Account_Number,
							 Balance = row.Account_Balance,
							 ProfilePhoto = ProfilePictureUtility.ConvertyByteArrayToImage(row.Profile_Photo.ToArray())
						 };
			return result;
		}

		public string CreateAccount(CreateAccountDto dto)
		{
			var result = _context.SP_CreateAccount(dto.FullName, dto.DateOfBirth, dto.Email, 
				dto.Password, dto.RepeatPassword, dto.Phone, 
				dto.Address, dto.MaritalStatus, dto.Gender, 
				dto.MotherName, dto.FatherName, dto.Role, 
				dto.Balance, dto.ProfilePicture).SingleOrDefault();

			if(result.Message == "1")
				throw new Exception("Failed to create new account");

			return result.Message;
		}

		//public ISingleResult<SP_SearchUserByKeyResult> FindAccountByKey(string key) => _context.SP_SearchUserByKey(key);

		public IEnumerable<NewAccountFinderDto> FindAccountByKey(string key)
		{
			var result = _context.SP_SearchUserByKey(key)
				.Select(i => new NewAccountFinderDto
				{
					Id = i.Id,
					Fullname = i.FullName,
					Gender = i.Gender,
					Role = i.Type,
					Address = i.HomeAddress,
					Email = i.Email,
					Phone = i.Number,
					Fathername = i.Name_of_Father,
					Mothername = i.Name_of_Mother,
					Marriage = i.Status,
					ProfileImage = i.Image != null
						? ProfilePictureUtility.ConvertyByteArrayToImage(i.Image.ToArray())
						: null,
					DateOfBirth = i.DateOfBirth.Date,
					BankAccountId = i.BankAccountId.ToString(),
					AccountBalance = i.Amount.ToString()
				});

			return result;
		}
	}
}
