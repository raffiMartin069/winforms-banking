using Martinez_BankApp.Model.Dto.Admin;
using Martinez_BankApp.Persistent.Data;
using Martinez_BankApp.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using Account = Martinez_BankApp.Model.InputModel.Admin.Account;

namespace Martinez_BankApp.Repository.Admin
{
	public class UpdateAccountRepository
	{
        private readonly DBContextDataContext _context;

		public UpdateAccountRepository(DBContextDataContext context)
		{
			_context = context;
		}
		public IEnumerable GetAllGender() => _context.SP_GetAllGender();

		public IEnumerable GetAllRole() => _context.SP_GetAllRoles();

		public IEnumerable GetAllMaritalStatus() => _context.SP_GetAllMartiralStatus();

		/**
		 * <summary>
		 * This method helps the image to be resized, I am planning to move this to a Model class in the future
		 * </summary>
		 * **/
		//private Bitmap GetAllAccountHelper(Binary raw_photo, ProfilePictureUtility imageUtil)
		//{
		//	return raw_photo.Length < 1 ? null : new Bitmap(imageUtil.ConvertyByteArrayToImage(raw_photo.ToArray()),
		//		new Size(60, imageUtil.ConvertyByteArrayToImage(raw_photo.ToArray()).Height * 50 
		//		/ imageUtil.ConvertyByteArrayToImage(raw_photo.ToArray()).Width));
		//}

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
							 ProfilePhoto = imageUtil.ConvertByteArrayToBitmap(row.Profile_Photo.ToArray()),
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
				.SingleOrDefault();

			return result.Message;
		}
	}
}
