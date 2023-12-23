CREATE PROCEDURE [dbo].[spShoppingListItem_Update]
	@Id uniqueidentifier,
	@Name NVARCHAR(255),
	@Amount INTEGER,
	@isChecked bit,
	@isActive bit
AS
	UPDATE ShoppingListItem
	SET [Name] = @Name, [Amount] = @Amount, [IsChecked] = @isChecked, [IsActive] = @isActive
	WHERE Id = @Id
RETURN 0
