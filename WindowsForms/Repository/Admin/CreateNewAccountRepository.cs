using Martinez_BankApp.Dto.Admin;
using Martinez_BankApp.Persistent.Data;
using System;
using System.Collections;
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

		public string AddAccount(NewAccountDto dto)
		{
			var result = _context.SP_AddClient(dto.FullName, dto.DateOfBirth, dto.Email, 
				dto.Password, dto.RepeatPassword, dto.Phone, 
				dto.Address, dto.MaritalStatus, dto.Gender, 
				dto.MotherName, dto.FatherName, dto.Role, 
				dto.Balance).SingleOrDefault();

			if(result.Message == "1")
				throw new Exception("Failed to create new account");

			return result.Message;
		}
	}
}
