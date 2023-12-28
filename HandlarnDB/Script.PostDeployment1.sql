DECLARE @PontusId uniqueidentifier;
DECLARE @IngerOchKennetId uniqueidentifier;

SET @PontusId = 'f12d21fd-6652-46b0-8423-bf7cd57f1032';
SET @IngerOchKennetId = 'c8180e48-df80-4b8b-a90f-3d4601b683c3';

if not exists (select 1 from dbo.[User])
begin 
	insert into dbo.[User] 
	(Id, Name) 
	values 
	(@PontusId, 'Pontus'), 
	(@IngerOchKennetId, 'Inger och Kennet')
end


if not exists (select 1 from dbo.ShoppingListItem)
begin 
	insert into dbo.ShoppingListItem (Name, Amount, IsChecked, IsActive, [User_Id]) 
	values 
	('Bröd', '1', 1, 1, @PontusId), 
	('Mjölk', '1', 1, 1, @PontusId), 
	('Mobiltelefon', '1', 1, 0, @PontusId),
	('Köttfärs', '1', 0, 1, @IngerOchKennetId),
	('Smör', '1', 0, 1, @IngerOchKennetId)
end