create   function FN_DisplayNewAccountCreated()
	returns table
	return 
	(
		select u.Id as 'User Identification', u.FullName as 'Client''s Full Name', u.DateOfBirth as 'Date of Birth', cred.Email,
		ph.Number as 'Phone Number', addr.HomeAddress as 'Home Address', ms.Status as 'Marital Status',
		u.Gender, prnt.MotherName as 'Mother''s Name', prnt.FatherName as 'Father''s Name',acc.Id as 'Account Number', bal.Amount as 'Account Balance' from [User] as u
		inner join
		[Credential] as cred
		on u.Id = cred.Id
		inner join
		[Phone] as ph
		on u.Id = ph.Id
		inner join
		[Address] as addr
		on u.AddressId = addr.Id
		inner join
		[Marital_Status] as ms
		on u.MaritalStatusId = ms.Id
		inner join
		[Parent] as prnt
		on u.Id = prnt.Id
		inner join
		[Account] as acc
		on u.Id = acc.UserId
		inner join
		[Balance] as bal
		on acc.Id = bal.Id
	);