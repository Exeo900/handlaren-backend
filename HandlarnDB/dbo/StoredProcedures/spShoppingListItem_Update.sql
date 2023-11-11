CREATE PROCEDURE [dbo].[spShoppingListItem_Update]
	@Id uniqueidentifier,
	@Name NVARCHAR(255),
	@Amount INTEGER
AS
	UPDATE ShoppingListItem
	SET [Name] = @Name, Amount = @Amount
	WHERE Id = @Id
RETURN 0
