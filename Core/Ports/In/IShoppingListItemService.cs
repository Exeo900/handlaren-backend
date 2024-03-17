using Core.Models;

namespace Core.Ports.In;
public interface IShoppingListItemService
{
    Task<IEnumerable<ShoppingListItem>> GetAll(Guid? userId);
    Task<ShoppingListItem?> Get(Guid id);
    Task Create(ShoppingListItem shoppingListItem);
    Task Create(IEnumerable<ShoppingListItem> shoppingListItems);
    Task Update(ShoppingListItem shoppingListItem);
    Task Delete(Guid id);
}
