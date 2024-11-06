create   procedure SP_SearchUser
	@Key varchar(255)
	as
	select * from dbo.FN_SearchByKey(@Key);