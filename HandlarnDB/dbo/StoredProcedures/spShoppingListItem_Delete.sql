CREATE PROCEDURE [dbo].[spShoppingListItem_Delete]
	@Id uniqueidentifier
AS
	DELETE FROM ShoppingListItem where Id = @Id
RETURN 0
