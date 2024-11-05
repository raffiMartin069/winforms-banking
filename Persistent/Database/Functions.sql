use BankApp

/*
	All functions
*/
create or alter function FN_SearchByKey(@Key varchar(255))
	returns table
	return 
	(
		select u.Id, u.FullName, u.Gender, r.[Type], 
		a.HomeAddress, c.Email, p.Number,
		prnt.FatherName as 'Name of Father', prnt.MotherName as 'Name of Mother', m.[Status]
		from [User] as u
		inner join
		[Credential] as c
		on u.Id = c.Id
		inner join
		[Phone] as p
		on u.Id = p.Id
		inner join
		[Address] as a
		on u.AddressId = a.Id
		inner join
		[Role] as r
		on u.RoleId = r.Id
		inner join
		[Parent] as prnt
		on u.Id = prnt.Id
		inner join
		[Marital_Status] as m
		on u.MaritalStatusId = m.Id
		where 
		u.FullName like @Key  + '%' 
		or
		u.DateOfBirth like @Key  + '%' 
		or
		c.Email like @Key  + '%' 
		or
		p.Number like @Key  + '%' 
		or
		a.HomeAddress like @Key  + '%' 
		or
		m.[Status] like @Key  + '%' 
		or
		u.Gender like @Key  + '%' 
		or
		prnt.FatherName like @Key  + '%' 
		or
		prnt.MotherName like @Key  + '%' 
		or
		r.[Type] like @Key  + '%'
	)

create or alter function FN_DisaplayAllCustomerRecord()
	returns table
	return 
	(
		select u.Id as 'User Id', u.FullName, u.DateOfBirth,
		u.Gender, acc.Id as 'Account Number', bal.Amount as 'Current Balance', p.Number,
		c.Email, a.HomeAddress, r.[Type], prnt.FatherName, prnt.MotherName,
		m.[Status]
		from [User] as u
		full outer join
		[Credential] as c
		on u.Id = c.Id
		full outer join
		[Phone] as p
		on u.Id = p.Id
		full outer join 
		[Address] as a
		on u.AddressId = a.Id
		inner join
		[Role] as r
		on r.Id = u.RoleId
		full outer join
		[Parent] as prnt
		on u.Id = prnt.Id
		inner join
		[Marital_Status] as m
		on  m.Id = u.MaritalStatusId
		inner join
		Account as acc
		on u.Id = acc.UserId
		inner join
		Balance as bal
		on acc.Id = bal.Id
		where r.[Type] = 'Client'
	)

create or alter function FN_Get_All_User_Related_Records()
	returns table
	return 
	(
		select u.Id as 'User Id', u.FullName, u.DateOfBirth,
	u.Gender, u.AddressId, u.RoleId,
	p.Id as 'Phone Id', p.Number,
	c.Id as 'Credential Id', c.Email, c.[Password],
	a.Id as 'Home Address Id', a.HomeAddress,
	r.Id as 'Role Id', r.[Type],
	prnt.Id as 'Parent Id', prnt.FatherName, prnt.MotherName,
	u.Id as 'Marital Status Id', m.[Status]
	from [User] as u
	full outer join
	[Credential] as c
	on u.Id = c.Id
	full outer join
	[Phone] as p
	on u.Id = p.Id
	full outer join 
	[Address] as a
	on u.AddressId = a.Id
	inner join
	[Role] as r
	on r.Id = u.RoleId
	full outer join
	[Parent] as prnt
	on u.Id = prnt.Id
	inner join
	[Marital_Status] as m
	on  m.Id = u.MaritalStatusId
	)

create or alter function GeneratePassword
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