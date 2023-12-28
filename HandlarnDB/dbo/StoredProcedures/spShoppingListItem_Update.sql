CREATE PROCEDURE [dbo].[spShoppingListItem_Update]
	@Id uniqueidentifier,
	@Name NVARCHAR(255),
	@Amount INTEGER,
	@IsChecked bit,
	@IsActive bit,
	@UserId uniqueidentifier
AS
	UPDATE ShoppingListItem
	SET [Name] = @Name, [Amount] = @Amount, [IsChecked] = @IsChecked, [IsActive] = @IsActive, [User_Id] = @UserId
	WHERE Id = @Id
RETURN 0
