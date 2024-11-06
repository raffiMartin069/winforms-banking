CREATE TABLE [dbo].[Role] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Type] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Type]='Admin' OR [Type]='Client')
);

