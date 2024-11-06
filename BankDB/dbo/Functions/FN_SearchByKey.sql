create   function FN_SearchByKey(@Key varchar(255))
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