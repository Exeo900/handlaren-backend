CREATE PROCEDURE [dbo].[spShoppingListItem_Create]
	@Name NVARCHAR(255),
	@Amount INTEGER
AS
	INSERT INTO ShoppingListItem (Name, Amount) VALUES (@Name, @Amount)
RETURN 0
