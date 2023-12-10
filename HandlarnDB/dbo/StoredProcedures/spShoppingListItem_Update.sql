CREATE PROCEDURE [dbo].[spShoppingListItem_Update]
	@Id uniqueidentifier,
	@Name NVARCHAR(255),
	@Amount INTEGER,
	@isChecked bit
AS
	UPDATE ShoppingListItem
	SET [Name] = @Name, Amount = @Amount, isChecked = @isChecked
	WHERE Id = @Id
RETURN 0
