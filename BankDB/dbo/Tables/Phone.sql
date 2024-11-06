CREATE TABLE [dbo].[Phone] (
    [Id]     INT       NOT NULL,
    [Number] CHAR (15) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK (len([Number])=(11)),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

