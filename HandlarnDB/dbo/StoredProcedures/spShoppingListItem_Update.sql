CREATE PROCEDURE [dbo].[spShoppingListItem_Update]
	@Id uniqueidentifier,
	@Name NVARCHAR(255),
	@Amount INTEGER,
	@MeasurementTypeId INTEGER,
	@Measurement INTEGER, -- Temp, remove this and fix so not all properties are included in update.
	@IsChecked bit,
	@IsActive bit,
	@UserId uniqueidentifier
AS
	UPDATE ShoppingListItem
	SET [Name] = @Name, [Amount] = @Amount, [MeasurementTypeId] = @MeasurementTypeId, [IsChecked] = @IsChecked, [IsActive] = @IsActive, [User_Id] = @UserId
	WHERE Id = @Id
RETURN 0
