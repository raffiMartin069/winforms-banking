-- create database BankApp

use BankApp


/*
	This table should only accept a type of Admin and Client
	and nothing else.
*/
create table [Role]
(
	Id int primary key identity(1,1),
	[Type] varchar(100) not null check([Type] = 'Admin' or Type = 'Client'), 
);

insert into [Role] values ('Admin'), ('Client')
select * from [Role]

-- -------------------------------------------------------------------

create table [Address]
(
	Id int primary key identity(1,1),
	HouseNo int not null check(len(HouseNo) > 4),
	Sitio varchar(100) not null,
	Barangay varchar(255) not null,
	Province varchar(255) not null,
	City varchar(255) not null,
);

/*
	Alter table Address
*/

-- I DROPED THE CONSTRAINT AND COLUMNS SO THAT I CAN REPLACE WITH SINGLE COLUMN TO CONFORM WITH THE FORM IN THE PROGRAM.
alter table [Address]
	drop constraint CK__Address__HouseNo__398D8EEE

alter table [Address]
	drop column HouseNo, Sitio, Barangay, Province, City

alter table [Address]
	add HomeAddress varchar(255) not null

select * from [Address]

-- -------------------------------------------------------------------

create table [User]
(
	Id int primary key identity(1,1),
	FullName varchar(255) not null,
	DateOfBirth date not null,
	Gender varchar(255) not null,
);

/*
	Alter tables for USER
*/
alter table [User]
	add RoleId int not null

alter table [User]
	add AddressId int not null

alter table [User]
	add constraint FK_RoleId foreign key (RoleId)
	references [Role](Id)
		on delete cascade
		on update cascade

alter table [User]
	add constraint FK_AddressId foreign key (AddressId)
	references [Address](Id)
		on delete cascade
		on update cascade

alter table [User]
	add MaritalStatusId int

alter table [User]
	add constraint FK_MaritalStatusId foreign key (MaritalStatusId)
	references [Marital_Status](Id)
		on delete cascade
		on update cascade

alter table [User]
	add AccountId int unique

alter table [User]
	add constraint FK_AccountId foreign key (AccountId)
	references [Account](Id)
		on delete cascade
		on update cascade

-- Drop Foreign Key User to Account and change it to Account to User
alter table [User]
	drop constraint UQ__User__349DA5A772142582
alter table [User]
	drop constraint FK_AccountId
alter table [User]
	drop column AccountId

/*
	Select all from User table
*/

select * from [User]
select * from dbo.FN_Get_All_User_Related_Records()
-- -------------------------------------------------------------------

create table Parent
(
	Id int primary key,
	FatherName varchar(255),
	MotherName varchar(255),
	foreign key(Id) references [User](Id)
	on delete cascade 
	on update cascade
);

create table Marital_Status
(
	Id int primary key identity(1,1),
	[Status] varchar(100) not null,
);

/*
	Intentional drop, please note that this is the FINAL ALTERING from the preceeding changes.
*/
drop table Marital_Status -- Recreated table, NOT ADVISABLE CREATE NEW TABLE AND COPY DATA BEFORE DROPING!

alter table Marital_Status
	drop column Id

alter table Marital_Status
	drop constraint PK__Marital___3214EC07FBB0ADF6

insert into Marital_Status values('Maried'), ('Divorced'), ('Widowed'), ('Separated'), ('Single'), ('Never married')

select * from Marital_Status
delete from Marital_Status
select * from FN_Get_All_User_Related_Records()

-- -------------------------------------------------------------------

create table [Credential]
(
	Id int primary key,
	Email varchar(255) 
		not null
		unique
		check(charindex('@', Email) > 0),
	[Password] varchar(255)
		not null
		check(len([Password]) > 16),
	foreign key(Id) references [User](Id)
		on delete cascade
		on update cascade
);

/*
	Alter table Credential
*/


-- change password to varchar(max)
alter table [Credential]
	drop constraint CK__Credentia__Passw__45F365D3

alter table [Credential] 
	drop column [Password]

alter table [Credential]
	add [Password] varchar(max)
		not null
		check(len([Password]) > 15)

-- -------------------------------------------------------------------

create table Client
(
	Id int primary key,
	foreign key(Id) references [User](Id)
		on delete cascade
		on update cascade
);

create table Administrator
(
	Id int primary key,
	foreign key(Id) references [User](Id)
		on delete cascade
		on update cascade
);

create table Phone
(
	Id int primary key,
	Number char(15) check(len(Number) = 11 )
	foreign key(Id) references [User](Id)
		on delete cascade
		on update cascade
);

-- -------------------------------------------------------------------
/*
	General Select Statements with join.
*/

select u.FullName, u.DateOfBirth, c.Email, c.[Password] from [User] as u
	full outer join [Credential] as c 
	on u.Id = c.Id



-- -------------------------------------------------------------------
/*
	BANK ACCOUNT STARTS HERE!
*/

create table Account
(
	Id int primary key identity(10001,1),
	UserId int unique not null,
	foreign key(UserId) references [User](Id)
		on delete cascade on update cascade
);


-- Change the starting point of the identity column to 10000
-- DBCC CHECKIDENT ('Account', RESEED, 9999);
-- -------------------------------------------------------------------

create table Balance
(
	Id int primary key,
	Amount decimal,
	DateEntered date default getdate(),
	TimeEntered time default cast(getdate() as time)
	foreign key(Id) references Account(Id)
		on delete cascade
		on update cascade
);

drop table Balance
-- -------------------------------------------------------------------
create table WithdrawMode
(
	Id int primary key identity(10001,1),
	[Type] varchar(255) not null unique,
);

create table DepositMode
(
	Id int primary key identity(10001,1),
	[Type] varchar(255) not null unique,
);

create table DepositLogs
(
	Id int primary key identity(10001,1),
	CurrentBalance decimal not null,
	DepositAmount decimal not null,
	DepositDate date default getdate(),
	AccountId int not null,
	DepositModeId int not null,
	foreign key(AccountId) references Account(Id)
		on delete cascade
		on update cascade,
	foreign key(DepositModeId) references DepositMode(Id)
		on delete cascade
		on update cascade
);

alter table DepositLogs
	add AccountNumber varchar(255) not null

alter table DepositLogs
	drop column AccountNumber

alter table DepositLogs
	add FullName varchar(255) not null

alter table DepositLogs
	add NewBalance decimal not null

alter table DepositLogs
	add DepositTime time default cast(getdate() as time) not null

create table WithdrawLogs
(
	Id int primary key identity(10001,1),
	CurrentBalance decimal not null,
	WithdrawAmount decimal not null,
	WithdrawDate date default getdate(),
	AccountId int not null,
	WithdrawModeId int not null,
	constraint CHK_Withdraw_Less_Than_Current_Balance check(WithdrawAmount < CurrentBalance), -- Withdraw amount should be less than the amount of the balance inside the account
	foreign key(AccountId) references Account(Id)
		on delete cascade
		on update cascade,
	foreign key(WithdrawModeId) references WithdrawMode(Id)
		on delete cascade
		on update cascade
);

alter table WithdrawLogs
	add AccountNumber varchar(255) not null

alter table WithdrawLogs
	drop column AccountNumber

alter table WithdrawLogs
	add FullName varchar(255) not null

insert into WithdrawMode values('Over The Counter'), ('ATM'), ('Check'), ('Debit'), ('Online Bank')
insert into DepositMode values('Over The Counter'), ('ATM'), ('Mail'), ('Online Bank')

select * from WithdrawLogs

alter table WithdrawLogs
	add NewBalance decimal not null

alter table WithdrawLogs
	add WithdrawTime time default cast(getdate() as time) not null

SELECT DB_ID() AS [Database ID];  
GO

DBCC OPENTRAN (BankApp) WITH TABLERESULTS, NO_INFOMSGS;

SELECT * 
FROM sys.dm_exec_sessions 
WHERE session_id = 52;

kill 52;