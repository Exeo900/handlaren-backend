using Core.Models;

namespace Core.Ports.Out;

public interface IDataAccess
{
    Task<IEnumerable<ShoppingListItem>> GetShoppingListItems();
    Task<ShoppingListItem?> GetShoppingListItem(Guid id);
    Task CreateShoppingListItem(ShoppingListItem shoppingListItem);
    Task UpdateShoppingListItem(ShoppingListItem shoppingListItem);
    Task DeleteShoppingListItem(Guid id);
}
