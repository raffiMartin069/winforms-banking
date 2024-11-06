create   function FN_Deposit_IsNameExist(@FullName varchar(255), @AccountNumber varchar(255))
	returns bit
	as
	begin
		declare @IsExist varchar(255);

		set @IsExist = (select u.FullName from Account as acc inner join [User] as u on acc.UserId = u.Id where u.FullName = @FullName and acc.Id = @AccountNumber);

		if @IsExist is not null or @IsExist != ''
		begin
			return 1;
		end;

		return 0;
	end;