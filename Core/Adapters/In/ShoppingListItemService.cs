using Core.Models;
using Core.Ports.In;
using Core.Ports.Out;

namespace Core.Adapters.In;
public class ShoppingListItemService : IShoppingListItemService
{
    public readonly IDataAccess _dataAccess;

    public ShoppingListItemService(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<IEnumerable<ShoppingListItem>> GetAll(Guid? userId)
    {
        return await _dataAccess.GetShoppingListItems(userId);
    }
    public async Task<ShoppingListItem?> Get(Guid id)
    {
        return await _dataAccess.GetShoppingListItem(id);
    }

    public async Task Create(ShoppingListItem shoppingListItem)
    {
        await _dataAccess.CreateShoppingListItem(shoppingListItem);
    }

    public async Task Update(ShoppingListItem shoppingListItem)
    {
        await _dataAccess.UpdateShoppingListItem(shoppingListItem);
    }

    public async Task Delete(Guid id)
    {
        await _dataAccess.DeleteShoppingListItem(id);
    }
}
