CREATE PROCEDURE [dbo].[GetUser]
	@UserId INTEGER = NULL,
	@UserName NVARCHAR(MAX) = NULL,
	@Email NVARCHAR(256) = NULL
AS

IF @UserId IS NULL OR @UserId = 0
BEGIN
	SET @UserId = (
		SELECT u.Id 
		FROM IdentityUser u
		WHERE (@UserName IS NOT NULL OR @Email IS NOT NULL) AND ((@UserName IS NULL OR u.UserName = @UserName) AND (@Email IS NULL OR u.Email = @Email))
	)
END

SELECT
	u.[Id],
	u.[AccessFailedCount],
	u.[Email],
	u.[EmailConfirmed],
	u.[LockoutEnabled],
	u.[LockoutEndDateUtc],
	u.[PhoneNumber],
	u.[PhoneNumberConfirmed],
	u.[SecurityStamp],
	u.[TwoFactorEnabled],
	u.[UserName],
	u.PasswordHash --Needed only for login
FROM
	IdentityUser u
WHERE
	u.Id = @UserId

SELECT
	ur.RoleId,
	@UserId UserId
FROM
	IdentityUserRole ur
WHERE
	ur.UserId = @UserId

SELECT
	ul.LoginProvider,
	ul.ProviderKey,
	@UserId UserId
FROM
	IdentityUserLogin ul
WHERE
	ul.UserId = @UserId

SELECT
	uc.Id,
	uc.ClaimType,
	uc.ClaimValue,
	@UserId UserId
FROM
	IdentityUserClaim uc
WHERE
	uc.UserId = @UserId