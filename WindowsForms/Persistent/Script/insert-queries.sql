INSERT INTO [Gender]
	VALUES
	('Male'),
	('Female'),
	('Non-Binary'),
	('Genderqueer / Gender Non-Conforming'),
	('Transgender'),
	('Other'),
	('Prefer Not to Say');

INSERT INTO [Marital_Status]
	VALUES
	('Married'),
	('Divorced'),
	('Widowed'),
	('Separated'),
	('Single'),
	('Never married');

INSERT INTO [Role]
	VALUES
	('Admin'),
	('Client');

INSERT INTO [WithdrawMode]
	VALUES
	('Over The Counter'),
	('ATM'),
	('Check'),
	('Debit'),
	('Online Bank');
	

INSERT INTO [DepositMode]
	VALUES
	('Over The Counter'),
	('ATM'),
	('Mail'),
	('Online Bank');

SELECT * FROM [Role]
UPDATE [Role] SET Id = 2035 WHERE [Type] = 'Admin'

SELECT * FROM [Marital_Status]

SELECT * FROM [Gender]

SELECT * FROM [WithdrawMode]

SELECT * FROM [DepositMode]
