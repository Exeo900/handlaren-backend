using Core.Models;
using Core.Ports.Out;

namespace Out.Adapter.Database;
public class DataAccess : IDataAccess
{
    public readonly ISqlDataAcess _sqlDataAccess;
    public DataAccess(ISqlDataAcess sqlDataAcess)
    {
        _sqlDataAccess = sqlDataAcess;
    }
    public async Task<IEnumerable<ShoppingListItem>> GetShoppingListItems()
    {
        return await _sqlDataAccess.LoadData<ShoppingListItem, dynamic>(storedProcedure: "[dbo].[spShoppingListItem_GetAll]", new { });
    }
    public async Task<ShoppingListItem?> GetShoppingListItem(Guid id)
    {
        var result = await _sqlDataAccess.LoadData<ShoppingListItem, Guid>(storedProcedure: "[dbo].[spShoppingListItem_Get]", id);
        return result?.FirstOrDefault();
    }

    public async Task CreateShoppingListItem(ShoppingListItem shoppingListItem)
    {
        await _sqlDataAccess.SaveData(storedProcedure: "[dbo].[spShoppingListItem_Create]", new { shoppingListItem.Name, shoppingListItem.Amount });
    }

    public async Task UpdateShoppingListItem(ShoppingListItem shoppingListItem)
    {   
        await _sqlDataAccess.SaveData(storedProcedure: "[dbo].[spShoppingListItem_Update]", shoppingListItem);
    }

    public async Task DeleteShoppingListItem(Guid id)
    {
        await _sqlDataAccess.SaveData(storedProcedure: "[dbo].[spShoppingListItem_Delete]", new { id });
    }
}
