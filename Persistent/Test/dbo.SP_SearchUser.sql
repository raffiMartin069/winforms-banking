USE [BankApp]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[SP_SearchUser]
		@Key = 'm'

SELECT	'Return Value' = @return_value

GO
