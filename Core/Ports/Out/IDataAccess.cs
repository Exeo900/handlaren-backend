using Core.Models;

namespace Core.Ports.Out;

public interface IDataAccess
{
    Task<IEnumerable<ShoppingListItem>> GetShoppingListItems();
}
