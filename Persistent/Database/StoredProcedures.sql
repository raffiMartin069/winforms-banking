use BankApp

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
	@Role varchar(100),
	@Balance decimal
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
			declare @Get_Marital_Status_Id_Reference int;
			declare @Get_AccountId_For_Balance_PK_FK int;

			insert into [Address] values(@Address);
			set @AddressId = SCOPE_IDENTITY();
						
			/*
				Get the Id based on the text from the query (@Role). This will make the Role table
				immutable to changes and let the values inside it to remain the same. The goal is
				to reference only the user based on their roles assigned by the administrator.
			*/
			set @Get_Role_Id_Reference = (select r.Id from [Role] as r where r.[Type] = @Role)

			set @Get_Marital_Status_Id_Reference = (select ms.Id from Marital_Status as ms where ms.[Status] = @MaritalStatus )

			select * from dbo.FN_Get_All_User_Related_Records()

			if @Get_Role_Id_Reference is null or @Get_Role_Id_Reference = ''
				begin
					raiserror('No matching role found', 16, 16);
					return;
				end;

			if @Get_Marital_Status_Id_Reference is null or @Get_Marital_Status_Id_Reference = ''
				begin
					raiserror('No matching marital status found', 16, 16);
					return;
				end;

			insert into [User] values(@FullName, @DateOfBirth, @Gender, @Get_Role_Id_Reference, @AddressId, @Get_Marital_Status_Id_Reference);
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

			insert into Parent values(@UserId, @FatherName, @MotherName);

			if @Balance is null or @Balance < 100.00
				begin
					raiserror ('Please add a balance of atleast ₱100.00', 16, 16);
					return;
				end;

			-- insert into account
			insert into Account values (@UserId);

			set @Get_AccountId_For_Balance_PK_FK = SCOPE_IDENTITY();

			-- insert into balance
			insert into Balance values (@Get_AccountId_For_Balance_PK_FK, @Balance, default, default);

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
			declare @Get_Marital_Status_Id_Reference int; -- this will query the Marital Status table and find the id that matches the keyword

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
			set @Get_Marital_Status_Id_Reference = (select ms.Id from Marital_Status as ms where ms.[Status] = @MaritalStatus )

			if @Get_Role_Id_Reference is null or @Get_Role_Id_Reference = ''
				begin
					raiserror('No matching role found', 16, 16);
					return;
				end;

			if @Get_Marital_Status_Id_Reference is null or @Get_Marital_Status_Id_Reference = ''
				begin
					raiserror('No matching marital status found', 16, 16);
					return;
				end;

			update [User] set FullName = @FullName, DateOfBirth = @DateOfBirth, Gender = @Gender, RoleId = @Get_Role_Id_Reference, MaritalStatusId = @Get_Marital_Status_Id_Reference where Id = @UserId;	

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


-- -------------------------------------------------------------------

create or alter procedure SP_SearchUserByKey
	@Key varchar(255)
	as
	select * from dbo.FN_SearchByKey(@Key);

create or alter procedure SP_GetAllCustomerRecord
	as
	select * from dbo.FN_DisaplayAllCustomerRecord()