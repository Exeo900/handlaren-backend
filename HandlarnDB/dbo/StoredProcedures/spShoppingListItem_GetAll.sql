CREATE PROCEDURE [dbo].[spShoppingListItem_GetAll]
	@UserId uniqueidentifier
AS
	SELECT  
		[Id],
		[Name],
		[Amount],
		[MeasurementTypeId],
		[IsChecked],
		[IsActive],
		[User_Id] as [UserId]
	FROM 
		ShoppingListItem 
	WHERE (@UserId IS NULL OR User_Id = @UserId);  
RETURN 0