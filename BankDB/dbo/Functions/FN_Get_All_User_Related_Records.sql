create   function FN_Get_All_User_Related_Records()
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