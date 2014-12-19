CREATE PROCEDURE [dbo].[CreateUser]
	@Id INT = 0,
	@AccessFailedCount INT,
	@Email NVARCHAR(256),
	@EmailConfirmed BIT,
	@LockoutEnabled BIT,
	@LockoutEndDateUtc DATETIME2(2),
	@PasswordHash NVARCHAR(MAX),
	@PhoneNumber NVARCHAR(MAX),
	@PhoneNumberConfirmed BIT,
	@SecurityStamp NVARCHAR(MAX),
	@TwoFactorEnabled BIT,
	@UserName NVARCHAR(MAX),
	@Logins INT = NULL, --Dummy parameter to allow more general user being sent down from store
	@Claims INT = NULL, --Dummy parameter to allow more general user being sent down from store
	@Roles INT = NULL --Dummy parameter to allow more general user being sent down from store
AS
	INSERT INTO IdentityUser(Email,PhoneNumber,SecurityStamp,UserName,PasswordHash) VALUES(@Email,@PhoneNumber,@SecurityStamp,@UserName,@PasswordHash)
	SELECT SCOPE_IDENTITY()
