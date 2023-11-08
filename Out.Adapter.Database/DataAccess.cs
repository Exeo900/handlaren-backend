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

    public Task<IEnumerable<ShoppingListItem>> GetShoppingListItems() => _sqlDataAccess.LoadData<ShoppingListItem, dynamic>(storedProcedure: "[dbo].[spShoppingListItem_GetAll]", new { }, "Default");
}
