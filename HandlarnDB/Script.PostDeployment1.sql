if not exists (select 1 from dbo.ShoppingListItem)
begin 
	insert into dbo.ShoppingListItem (Name, Amount) 
	values ('Mobiltelefon', '1')
end