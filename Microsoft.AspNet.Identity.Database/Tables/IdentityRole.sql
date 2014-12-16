CREATE TABLE [dbo].[IdentityRole]
(
    [Id]   INT NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.IdentityRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);
