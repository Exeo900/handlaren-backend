﻿CREATE TABLE [dbo].[ShoppingListItem]
(
	[Id] UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	[Name] NVARCHAR(255) NOT NULL,
	[Amount] INT NULL
)
