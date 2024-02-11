CREATE PROCEDURE [dbo].[spShoppingListItem_Create]
	@Name NVARCHAR(255),
	@Amount INTEGER,
	@MeasurementTypeId INTEGER,
	@UserId uniqueidentifier
AS
	INSERT INTO ShoppingListItem (Name, Amount, MeasurementTypeId, User_Id) VALUES (@Name, @Amount, @MeasurementTypeId, @UserId)
RETURN 0
