CREATE TABLE [dbo].[DepositMode] (
    [Id]   INT           IDENTITY (10001, 1) NOT NULL,
    [Type] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Type] ASC)
);

