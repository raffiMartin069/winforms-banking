create   procedure SP_DepositAccount
	@Id int, -- Admin Id will be stored as session within the program and this will be passed as parameter per transaction
	@AccountNumber int,
	@FullName varchar(255),
	@CurrentBalance decimal,
	@ModeOfDeposit varchar(255),
	@DepositAmount decimal
	as

	begin
		begin transaction
		begin  try

			declare @ErrorMessage nvarchar(4000);
			declare @ErrorSeverity int;
			declare @ErrorState int;
			declare @NewAmount decimal;
			declare @Get_DepositMode_Id_Reference int;
			declare @Is_NameExist bit;

			/*
				@FullName and @AccountNumber will be used to check if the name exists in the database.
				Both of the variables will be joined to search for result. If the result is found, the
				transaction will continue. If not, the transaction will be rolled back.
			*/
			set @Is_NameExist = dbo.FN_Deposit_IsNameExist(@FullName, @AccountNumber);

			if @Is_NameExist = 0
				begin
					raiserror('Name does not exist', 16, 16);
					return;
				end;

			if @Id is null
				begin
					raiserror('Please make sure you have the right priviliges for this transaction.', 16, 16);
					return;
				end;
			
			set @NewAmount = dbo.FN_CalculateDeposit(@DepositAmount, @CurrentBalance);

			set @Get_DepositMode_Id_Reference = (select dm.Id from DepositMode as dm where dm.[Type] = @ModeOfDeposit);

			insert into DepositLogs values(@CurrentBalance, @DepositAmount, default, @AccountNumber, @Get_DepositMode_Id_Reference, @FullName, @NewAmount, default);

			-- I UPDATED the Balance table since I already have a Deposit Logs table that will store the transaction history.
			-- History of transactions will be gathered through Deposit Logs table and Withdraw Logs table.
			-- This is make the Balance table more consistent since it will only store the current balance of the account.
			update Balance set Balance.Amount = @NewAmount where Id = @AccountNumber;

			commit transaction;
			select 'Deposit successful' as Message;
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