create   function FN_DisaplayAllCustomerRecord()
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
		-- where r.[Type] = 'Client'
	)