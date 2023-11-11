using Core.Models;

namespace Core.Ports.In;
public interface IShoppingListItemService
{
    Task<IEnumerable<ShoppingListItem>> GetAll();
    Task<ShoppingListItem?> Get(Guid id);
    Task Create(ShoppingListItem shoppingListItem);
    Task Update(ShoppingListItem shoppingListItem);
    Task Delete(Guid id);
}
