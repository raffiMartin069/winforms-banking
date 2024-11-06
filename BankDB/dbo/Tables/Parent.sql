CREATE TABLE [dbo].[Parent] (
    [Id]         INT           NOT NULL,
    [FatherName] VARCHAR (255) NULL,
    [MotherName] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

