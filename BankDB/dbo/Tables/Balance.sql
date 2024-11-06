CREATE TABLE [dbo].[Balance] (
    [Id]          INT          NOT NULL,
    [Amount]      DECIMAL (18) NULL,
    [DateEntered] DATE         DEFAULT (getdate()) NULL,
    [TimeEntered] TIME (7)     DEFAULT (CONVERT([time],getdate())) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[Account] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

