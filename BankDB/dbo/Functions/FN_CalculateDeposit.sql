create   function FN_CalculateDeposit(@Amount decimal, @CurrentBalance decimal)
	returns decimal
	as
	begin
	return (@Amount + @CurrentBalance)
	end;