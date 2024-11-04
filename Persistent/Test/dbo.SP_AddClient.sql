USE [BankApp]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[SP_AddClient]
		@FullName = N'Internal Test',
		@DateOfBirth = '01/01/1991',
		@Email = N'internal.testswed33@gmail222.com',
		@Password = N'test',
		@RepeatPassword = N'test',
		@Phone = N'09111111111',
		@Address = N'sample street, 0000, barangay sample, sample city',
		@MaritalStatus = N'married',
		@Gender = N'male',
		@MotherName = N'sample sample',
		@FatherName = N'sample sample',
		@Role = N'clients'

select * from [Role]

select u.Id as 'User Id', u.FullName, u.DateOfBirth,
	u.Gender, u.AddressId, u.RoleId,
	p.Id as 'Phone Id', p.Number,
	c.Id as 'Credential Id', c.Email, c.[Password],
	a.Id as 'Home Address Id', a.HomeAddress,
	r.Id as 'Role Id', r.[Type],
	prnt.Id as 'Parent Id', prnt.FatherName, prnt.MotherName,
	m.Id as 'Marital Status Id', m.[Status]
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
	full outer join
	[Role] as r
	on u.RoleId = r.Id
	full outer join
	[Parent] as prnt
	on u.Id = prnt.Id
	full outer join
	[Marital_Status] as m
	on u.Id = m.Id

SELECT	'Return Value' = @return_value

GO
