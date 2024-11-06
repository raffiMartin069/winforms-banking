create   function FN_CalculateWithdrawal(@Amount decimal, @CurrentBalance decimal)
	returns decimal
	as
	begin
		return (@CurrentBalance - @Amount)
	end;