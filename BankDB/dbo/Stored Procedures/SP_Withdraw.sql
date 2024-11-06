create   procedure SP_Withdraw
	@Id int, -- Admin Id will be stored as session within the program and this will be passed as parameter per transaction
	@AccountNumber int,
	@FullName varchar(255),
	@CurrentBalance decimal,
	@ModeOfDeposit varchar(255),
	@WithdrawAmount decimal
	as
	begin
		begin transaction
		begin try

		declare @ErrorMessage nvarchar(4000);
		declare @ErrorSeverity int;
		declare @ErrorState int;
		declare @NewAmount_Deducted_From_Withdrawal decimal;
		declare @Is_NameExist bit;
		declare @Get_WithdrawMode_Id_Reference int;

		-- We can reuse this function since they both do the same job
		set @Is_NameExist = dbo.FN_Deposit_IsNameExist(@FullName, @AccountNumber);

		if @Id is null
		begin
			raiserror('Please make sure you have the right priviliges for this transaction.', 16, 16);
			return;
		end;

		if @Is_NameExist = 0
		begin
			raiserror('Name does not exist', 16, 16);
			return;
		end;

		if @WithdrawAmount > @CurrentBalance
		begin
			raiserror('Withdraw amount should be less than the current balance', 16, 16);
			return;
		end;

		-- Get the new balance after the withdrawal
		set @NewAmount_Deducted_From_Withdrawal = dbo.FN_CalculateWithdrawal(@WithdrawAmount, @CurrentBalance);

		set @Get_WithdrawMode_Id_Reference = (select wm.Id from WithdrawMode as wm where wm.[Type] = @ModeOfDeposit);

		insert into WithdrawLogs values(@CurrentBalance, @WithdrawAmount, default, @AccountNumber, @Get_WithdrawMode_Id_Reference, @FullName, @NewAmount_Deducted_From_Withdrawal, default);

		update Balance set Balance.Amount = @NewAmount_Deducted_From_Withdrawal where Id = @AccountNumber;

		commit transaction;
		select 'Withdraw successful' as Message;
		end try
		begin catch
			if @@TRANCOUNT > 0
				begin
					rollback transaction;
					return;
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