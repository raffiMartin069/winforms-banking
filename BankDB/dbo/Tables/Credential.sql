CREATE TABLE [dbo].[Credential] (
    [Id]       INT           NOT NULL,
    [Email]    VARCHAR (255) NOT NULL,
    [Password] VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK (charindex('@',[Email])>(0)),
    CHECK (len([Password])>(15)),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    UNIQUE NONCLUSTERED ([Email] ASC)
);

