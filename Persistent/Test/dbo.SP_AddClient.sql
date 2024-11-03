USE [BankApp]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[SP_AddClient]
		@FullName = 'Internal Test',
		@DateOfBirth = '01/01/1991',
		@Email = 'internal.test@gmail.com',
		@Password = 'test',
		@RepeatPassword = 'test',
		@Phone = '09111111111',
		@Address = 'sample street, 0000, barangay sample, sample city',
		@MaritalStatus = 'married',
		@Gender = 'male',
		@MotherName = 'sample sample',
		@FatherName = 'sample sample',
		@Role = 'admin'

SELECT	@return_value as 'Return Value'

GO
