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
	@Role varchar(100)
	as
	begin
	begin transaction
		begin try
			
			declare @AddressId int;
			declare @RoleId int;
			declare @UserId int;
			declare @HashedPassword varchar(max);
			declare @ErrorMessage nvarchar(4000);
			declare @ErrorSeverity int;
			declare @ErrorState int;
			declare @Get_Role_Id_Reference int;

			insert into [Address] values(@Address);
			set @AddressId = SCOPE_IDENTITY();
						
			/*
				Get the Id based on the text from the query (@Role). This will make the Role table
				immutable to changes and let the values inside it to remain the same. The goal is
				to reference only the user based on their roles assigned by the administrator.
			*/
			set @Get_Role_Id_Reference = (select r.Id from [Role] as r where r.[Type] = @Role)


			insert into [User] values(@FullName, @DateOfBirth, @Gender, @Get_Role_Id_Reference, @AddressId);
			set @UserId = SCOPE_IDENTITY();

			insert into Client values(@UserId);

			set @HashedPassword = dbo.GeneratePassword(@Password, @RepeatPassword);

			if @HashedPassword = 'Password do not match'
				begin
					raiserror('Password do not match', 16, 1);
					return;
				end;

			insert into [Credential] values(@UserId, @Email, @HashedPassword);

			insert into Phone values(@UserId, @Phone);

			insert into Marital_Status values(@UserId, @MaritalStatus);

			insert into Parent values(@UserId, @FatherName, @MotherName);

			if ERROR_MESSAGE() is not null and ERROR_SEVERITY() > 0 and ERROR_STATE() > 0
			begin	
				raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState);
				return;
			end;

			commit transaction;
			select 'Account created successfuly' as Message; 
		end try

		begin catch
			
			if @@TRANCOUNT > 0
				begin
					rollback transaction;
				end;


			select 
				@ErrorMessage = ERROR_MESSAGE(),
				@ErrorSeverity = ERROR_SEVERITY(),
				@ErrorState = ERROR_STATE();

			-- Return the error information
			raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState);
			select @ErrorMessage as Message;
		end catch;
	
	end;

-- Testing Area
select * from [User]
select * from [Credential]
select * from [Role]
select * from [Address]

delete from [User];
delete from [Client];
delete from [Credential];
delete from [Address];
delete from [Phone];
delete from [Parent];
delete from [Marital_Status];
delete from [Role];

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
	inner join
	[Role] as r
	on r.Id = u.RoleId
	full outer join
	[Parent] as prnt
	on u.Id = prnt.Id
	full outer join
	[Marital_Status] as m
	on u.Id = m.Id

select * from [User] join [Role] on [Role].Id = [User].Id
-- -------------------------------------------------------------------

create or alter procedure SP_UpdateUserInfo
	@UserId int,
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
	@Role varchar(100)
	
	as
	
	begin
		begin transaction
		begin try
			declare @ErrorMsg nvarchar(4000);
			declare @HashedPassword varchar(max);
			declare @ErrorMessage nvarchar(4000);
			declare @ErrorSeverity int;
			declare @ErrorState int;
			declare @User_Address_FK int; -- indicates that we will be querying Address ID from User ID as FK
			declare @User_Role_FK int; -- indicates that we will be querying Role ID from User ID as FK
			declare @Get_Role_Id_Reference int; -- this will query the Role table and find the id that matches the keyword

			/*
				We need to get assign the user id to entities that do not show strong relationships.
				For Address and Role, since their relationships are weak to the User entity we will
				acquire the Foreign Key of the User entity before we can update to ensure that we are
				updating the correct data.

				@User_Address_FK
				@User_Role_FK
			*/
			set @User_Address_FK = (select u.AddressId from [User] as u where u.Id = @UserId);
			set @User_Role_FK = (select u.RoleId from [User] as u where u.Id = @UserId);

			update [Address] set HomeAddress = @Address where Id = @User_Address_FK;
			

			/*
				Get the Id based on the text from the query (@Role). This will make the Role table
				immutable to changes and let the values inside it to remain the same. The goal is
				to reference only the user based on their roles assigned by the administrator.
			*/ 
			set @Get_Role_Id_Reference = (select r.Id from [Role] as r where r.[Type] = @Role)

			if @Get_Role_Id_Reference is null or @Get_Role_Id_Reference = ''
				begin
					raiserror('No matching role found', 16, 16);
					return;
				end;

			update [User] set FullName = @FullName, DateOfBirth = @DateOfBirth, Gender = @Gender, RoleId = @Get_Role_Id_Reference where Id = @UserId;	

			update [Phone] set Number = @Phone where Id = @UserId;

			set @HashedPassword = dbo.GeneratePassword(@Password, @HashedPassword);

			set @HashedPassword = dbo.GeneratePassword(@Password, @RepeatPassword);

			if @HashedPassword = 'Password do not match'
				begin
					raiserror('Password do not match', 16, 1);
					return;
				end;

			update [Credential] set Email = @Email, [Password] = @HashedPassword where Id = @UserId;

			update [Marital_Status] set [Status] = @MaritalStatus where Id = @UserId;

			update [Parent] set FatherName = @FatherName, MotherName = @MotherName where Id = @UserId;

			if ERROR_MESSAGE() is not null and ERROR_SEVERITY() > 0 and ERROR_STATE() > 0
			begin	
				raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState);
				return;
			end;

			commit transaction;
			select 'Account updated successfuly' as Message; 
		end try
		begin catch
			
			if @@TRANCOUNT > 0
				begin
					rollback transaction;
				end;

			select 
				@ErrorMessage = ERROR_MESSAGE(),
				@ErrorSeverity = ERROR_SEVERITY(),
				@ErrorState = ERROR_STATE();

			-- Return the error information
			raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState);
			select @ErrorMessage as Message;

		end catch;
	end;

-- Testing Area
select * from [User]

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
-- -------------------------------------------------------------------

create or alter procedure SP_SearchUser
	@Key varchar(255)
	as
	select
	u.Id, u.FullName, u.Gender, r.[Type], 
	a.HomeAddress, c.Email, p.Number,
	prnt.FatherName as 'Name of Father', prnt.MotherName as 'Name of Mother', m.[Status]
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
	on u.RoleId = r.Id
	full outer join
	[Parent] as prnt
	on u.Id = prnt.Id
	full outer join
	[Marital_Status] as m
	on u.Id = m.Id
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

