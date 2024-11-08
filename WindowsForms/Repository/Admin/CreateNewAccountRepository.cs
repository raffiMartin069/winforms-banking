using Martinez_BankApp.Dto.Admin;
using Martinez_BankApp.Model.Admin;
using Martinez_BankApp.Persistent.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

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

		public ISingleResult<SP_DisplayNewAccountCreatedResult> GetAllNewAccountCreated() => _context.SP_DisplayNewAccountCreated();

		//public IEnumerable GetImages() => from image in _context.ProfilePictures select new { image.Image, image.Id };

		public IEnumerable<Image> GetImages() => _context.ProfilePictures.Select(image => new Image(image.Id, image.Image.ToArray()));

		public string AddAccount(NewAccount dto)
		{
			var result = _context.SP_AddClient(dto.FullName, dto.DateOfBirth, dto.Email, 
				dto.Password, dto.RepeatPassword, dto.Phone, 
				dto.Address, dto.MaritalStatus, dto.Gender, 
				dto.MotherName, dto.FatherName, dto.Role, 
				dto.Balance, dto.ProfilePicture).SingleOrDefault();

			if(result.Message == "1")
				throw new Exception("Failed to create new account");

			return result.Message;
		}

		public ISingleResult<SP_SearchUserByKeyResult> FindAccountByKey(string key) => _context.SP_SearchUserByKey(key);
	}
}
