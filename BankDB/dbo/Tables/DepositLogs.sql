CREATE TABLE [dbo].[DepositLogs] (
    [Id]             INT           IDENTITY (10001, 1) NOT NULL,
    [CurrentBalance] DECIMAL (18)  NOT NULL,
    [DepositAmount]  DECIMAL (18)  NOT NULL,
    [DepositDate]    DATE          DEFAULT (getdate()) NULL,
    [AccountId]      INT           NOT NULL,
    [DepositModeId]  INT           NOT NULL,
    [FullName]       VARCHAR (255) NOT NULL,
    [NewBalance]     DECIMAL (18)  NOT NULL,
    [DepositTime]    TIME (7)      DEFAULT (CONVERT([time],getdate())) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY ([DepositModeId]) REFERENCES [dbo].[DepositMode] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

