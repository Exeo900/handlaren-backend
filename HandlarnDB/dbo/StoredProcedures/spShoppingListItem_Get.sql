CREATE PROCEDURE [dbo].[spShoppingListItem_Get]
	@Id uniqueidentifier
AS
	SELECT 
		[Id],
		[Name],
		[Amount],
		[MeasurementTypeId],
		[IsChecked],
		[IsActive],
		[User_Id] as [UserId]	
	FROM ShoppingListItem 
	WHERE Id = @Id 
RETURN 0
