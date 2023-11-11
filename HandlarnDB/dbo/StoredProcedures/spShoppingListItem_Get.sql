CREATE PROCEDURE [dbo].[spShoppingListItem_Get]
	@Id uniqueidentifier
AS
	SELECT * from ShoppingListItem where Id = @Id 
RETURN 0
