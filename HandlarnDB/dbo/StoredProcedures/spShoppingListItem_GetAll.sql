CREATE PROCEDURE [dbo].[spShoppingListItem_GetAll]
	@UserId uniqueidentifier
AS
	SELECT  
		[Id],
		[Name],
		[Amount],
		[IsChecked],
		[IsActive],
		[User_Id] as [UserId]
	FROM 
		ShoppingListItem 
	WHERE User_Id = @UserId 
RETURN 0