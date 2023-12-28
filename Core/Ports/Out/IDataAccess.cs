using Core.Models;

namespace Core.Ports.Out;

public interface IDataAccess
{
    Task<IEnumerable<ShoppingListItem>> GetShoppingListItems(Guid? userId);
    Task<ShoppingListItem?> GetShoppingListItem(Guid id);
    Task CreateShoppingListItem(ShoppingListItem shoppingListItem);
    Task UpdateShoppingListItem(ShoppingListItem shoppingListItem);
    Task DeleteShoppingListItem(Guid id);
    Task<UserData?> GetUserData(Guid userId);
    Task<IEnumerable<UserData>> GetUsersData();
}
