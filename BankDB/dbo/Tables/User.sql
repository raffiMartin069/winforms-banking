CREATE TABLE [dbo].[User] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [FullName]        VARCHAR (255) NOT NULL,
    [DateOfBirth]     DATE          NOT NULL,
    [Gender]          VARCHAR (255) NOT NULL,
    [RoleId]          INT           NOT NULL,
    [AddressId]       INT           NOT NULL,
    [MaritalStatusId] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_MaritalStatusId] FOREIGN KEY ([MaritalStatusId]) REFERENCES [dbo].[Marital_Status] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

