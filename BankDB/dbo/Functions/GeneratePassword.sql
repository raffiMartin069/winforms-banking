create   function GeneratePassword
	(
		@Password varchar(255),
		@RepeatPassword varchar(255)
	)
	returns varchar(max)
	as
	begin
		
		declare @HashedPassword varchar(max);
		
		if @Password != @RepeatPassword
		begin
			return 'Password do not match';
		end;

		set @HashedPassword = convert(varchar(max), HASHBYTES('SHA2_256', @Password), 1);

		return @HashedPassword;
	end;