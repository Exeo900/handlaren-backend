CREATE PROCEDURE [dbo].[spShoppingListItem_Create]
	@Name NVARCHAR(255),
	@Amount INTEGER,
	@UserId uniqueidentifier
AS
	INSERT INTO ShoppingListItem (Name, Amount, User_Id) VALUES (@Name, @Amount, @UserId)
RETURN 0
