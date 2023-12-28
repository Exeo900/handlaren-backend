CREATE PROCEDURE [dbo].[spUserData_Get]
	@userId uniqueidentifier
AS
	SELECT 
		[Id],
		[Name]
	FROM [User] 
		WHERE (@UserId IS NULL OR Id = @userId ); 
RETURN 0
