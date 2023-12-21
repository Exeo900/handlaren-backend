if not exists (select 1 from dbo.ShoppingListItem)
begin 
	insert into dbo.ShoppingListItem (Name, Amount, IsActive) 
	values ('Bröd', '1', 1), ('Mobiltelefon', '1', 0)
end