
using Martinez_BankApp.Dto.Admin;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Utility;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Account = Martinez_BankApp.Model.Admin.Account;

namespace Martinez_BankApp.Repository.Admin
{
	public class AdminUpdateAccountRepository
	{
        private readonly DBContextDataContext _context;

		public AdminUpdateAccountRepository(DBContextDataContext context)
		{
			_context = context;
		}

		public IEnumerable<Account> GetAllAccount()
		{
			var imageUtil = new ProfilePictureUtility();
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
							 ProfilePhoto = new Bitmap(imageUtil.ConvertyByteArrayToImage(row.Profile_Photo.ToArray()),
							 new Size(60, imageUtil.ConvertyByteArrayToImage(row.Profile_Photo.ToArray()).Height * 50 / imageUtil.ConvertyByteArrayToImage(row.Profile_Photo.ToArray()).Width)),
							 OriginalProfilePhoto = imageUtil.ConvertyByteArrayToImage(row.Profile_Photo.ToArray())
						 };
			return result;
		}
		
		public string UpdateAccount(UpdateAccountDto account)
		{
			var result = _context.SP_UpdateUserInfo
				(account.Id, account.FullName, account.DateOfBirth, 
				account.Email, account.Password, account.RepeatPassword, 
				account.Phone, account.Address, account.MaritalStatus,
				account.Gender, account.MotherName, account.FatherName,
				account.Role, account.Balance, account.ProfilePicture)
				.AsEnumerable()
				.ToString();

			return result;
		}
	}
}
