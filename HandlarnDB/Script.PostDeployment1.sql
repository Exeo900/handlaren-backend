if not exists (select 1 from dbo.ShoppingListItem)
begin 
	insert into dbo.ShoppingListItem (Name, Amount, IsChecked, IsActive) 
	values ('Bröd', '1', 1, 1), ('Mjölk', '1', 1, 1), ('Mobiltelefon', '1', 1, 0)
end