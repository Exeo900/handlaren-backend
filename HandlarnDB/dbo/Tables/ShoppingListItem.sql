CREATE TABLE [dbo].[ShoppingListItem]
(
	[Id] UNIQUEIDENTIFIER CONSTRAINT [PK_ShoppingListItem_Id] PRIMARY KEY default NEWID(),
	[Name] NVARCHAR(255) NOT NULL,
	[Amount] INT NULL,
	[IsChecked] BIT NULL,
	[IsActive] BIT NOT NULL	default 1
)
