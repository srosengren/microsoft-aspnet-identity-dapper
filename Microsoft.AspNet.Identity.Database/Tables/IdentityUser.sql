CREATE TABLE [dbo].[IdentityUser]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[AccessFailedCount] INT NOT NULL DEFAULT(0),
	[Email] NVARCHAR(256),
	[EmailConfirmed] BIT NOT NULL DEFAULT(0),
	[LockoutEnabled] BIT NOT NULL DEFAULT(0),
	[LockoutEndDateUtc] DATETIME2(2),
	[PasswordHash] NVARCHAR(MAX),
	[PhoneNumber] NVARCHAR(MAX),
	[PhoneNumberConfirmed] BIT NOT NULL DEFAULT(0),
	[SecurityStamp] NVARCHAR(MAX),
	[TwoFactorEnabled] BIT NOT NULL DEFAULT(0),
	[UserName] NVARCHAR(MAX),
	CONSTRAINT [PK_dbo.IdentityUser] PRIMARY KEY CLUSTERED ([Id] ASC)
)
