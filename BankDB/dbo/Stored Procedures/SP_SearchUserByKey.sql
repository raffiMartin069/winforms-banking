create   procedure SP_SearchUserByKey
	@Key varchar(255)
	as
	select * from dbo.FN_SearchByKey(@Key);