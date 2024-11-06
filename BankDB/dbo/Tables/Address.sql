CREATE TABLE [dbo].[Address] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [HomeAddress] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

