using Martinez_BankApp.Model.Dto.Admin;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Repository.Admin
{
	public class CustomerListRepository
	{
		private readonly DBContextDataContext _context;

		public CustomerListRepository(DBContextDataContext context)
		{
			_context = context;
		}

		public IEnumerable<UserListDto> GetAllList()
		{
			var result = from user in _context.SP_GetUserList()
						 select new UserListDto()
						 {
							 Id = (int)user.UserId,
							 ProfilePicture = user.Image != null ? ProfilePictureUtility.ConvertyByteArrayToImage(user.Image.ToArray()) : ProfilePictureUtility.ConvertyByteArrayToImage(null),
							 Fullname = user.FullName,
							 Gender = user.Gender,
							 Email = user.Email,
							 PhoneNumber = user.Number,
							 MaritalStatus = user.Marital_Status,
							 DateOfBirth = (DateTime)user.DateOfBirth,
							 Address = user.HomeAddress,
							 Fathername = user.FatherName,
							 Mothername = user.MotherName,
							 Role = user.Role,
							 BankAccountId = user.AccountNumber,
							 Balance = (decimal)user.Amount
						 };

			return result;
		}
	}
}
