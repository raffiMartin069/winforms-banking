create database BankApp

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

/*
	Select all from User table
*/

select * from [User]
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
	Id int primary key,
	[Status] varchar(100),
	foreign key(Id) references [User](Id)
	on delete cascade
	on update cascade
);

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
	All functions
*/
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

-- -------------------------------------------------------------------
/*
	All strored procedures
*/
create or alter procedure SP_AddClient
	@FullName varchar(255),
	@DateOfBirth date,
	@Email varchar(255),
	@Password varchar(255),
	@RepeatPassword varchar(255),
	@Phone char(15),
	@Address varchar(255),
	@MaritalStatus varchar(255),
	@Gender varchar(255),
	@MotherName varchar(255),
	@FatherName varchar(255),
	@Role varchar(255)
	as
	begin
	begin transaction
		begin try
			
			declare @AddressId int;
			declare @RoleId int;
			declare @UserId int;
			declare @HashedPassword varchar(max);

			insert into [Address] values(@Address);
			set @AddressId = SCOPE_IDENTITY();

			insert into [Role] values(@Role);
			set @RoleId = SCOPE_IDENTITY();

			insert into [User] values(@FullName, @DateOfBirth, @Gender, @RoleId, @AddressId);
			set @UserId = SCOPE_IDENTITY();

			insert into Client values(@UserId);

			set @HashedPassword = dbo.GeneratePassword(@Password, @RepeatPassword);

			insert into [Credential] values(@UserId, @Email, @HashedPassword);

			insert into Phone values(@UserId, @Phone);

			insert into Marital_Status values(@UserId, @MaritalStatus);

			insert into Parent values(@UserId, @FatherName, @MotherName);

			return 'Account created successfuly'; 
		end try

		begin catch
			rollback transaction;
			 -- Handle the error
			declare @ErrorMessage nvarchar(4000);
			declare @ErrorSeverity int;
			declare @ErrorState int;

			select 
				@ErrorMessage = ERROR_MESSAGE(),
				@ErrorSeverity = ERROR_SEVERITY(),
				@ErrorState = ERROR_STATE();

			-- Return the error information
			raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState);
			return 'Something went wrong';
		end catch;
	
	end;




-- -------------------------------------------------------------------