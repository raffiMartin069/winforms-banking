CREATE TABLE [dbo].[WithdrawLogs] (
    [Id]             INT           IDENTITY (10001, 1) NOT NULL,
    [CurrentBalance] DECIMAL (18)  NOT NULL,
    [WithdrawAmount] DECIMAL (18)  NOT NULL,
    [WithdrawDate]   DATE          DEFAULT (getdate()) NULL,
    [AccountId]      INT           NOT NULL,
    [WithdrawModeId] INT           NOT NULL,
    [FullName]       VARCHAR (255) NOT NULL,
    [NewBalance]     DECIMAL (18)  NOT NULL,
    [WithdrawTime]   TIME (7)      DEFAULT (CONVERT([time],getdate())) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CHK_Withdraw_Less_Than_Current_Balance] CHECK ([WithdrawAmount]<[CurrentBalance]),
    FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY ([WithdrawModeId]) REFERENCES [dbo].[WithdrawMode] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

