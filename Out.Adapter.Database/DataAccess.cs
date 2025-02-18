﻿using Core.Models;
using Core.Ports.Out;

namespace Out.Adapter.Database;
public class DataAccess : IDataAccess
{
    public readonly ISqlDataAcess _sqlDataAccess;
    public DataAccess(ISqlDataAcess sqlDataAcess)
    {
        _sqlDataAccess = sqlDataAcess;
    }
    public async Task<IEnumerable<ShoppingListItem>> GetShoppingListItems(Guid? userId)
    {
        return await _sqlDataAccess.LoadData<ShoppingListItem, dynamic>(storedProcedure: "[dbo].[spShoppingListItem_GetAll]", new { userId });
    }

    public async Task<ShoppingListItem?> GetShoppingListItem(Guid id)
    {
        var result = await _sqlDataAccess.LoadData<ShoppingListItem, Guid>(storedProcedure: "[dbo].[spShoppingListItem_Get]", id);
        return result?.FirstOrDefault();
    }

    public async Task CreateShoppingListItem(ShoppingListItem shoppingListItem)
    {
        await _sqlDataAccess.SaveData(storedProcedure: "[dbo].[spShoppingListItem_Create]", new { shoppingListItem.Name, shoppingListItem.Amount, shoppingListItem.MeasurementTypeId, shoppingListItem.UserId });
    }

    public async Task CreateShoppingListItems(IEnumerable<ShoppingListItem> shoppingListItems)
    {
        // TODO: Create bulk sp instead, insert them all in db directly at the same time.
        foreach (var item in shoppingListItems)
        {
            await CreateShoppingListItem(item);
        }
    }

    public async Task UpdateShoppingListItem(ShoppingListItem shoppingListItem)
    {   
        await _sqlDataAccess.SaveData(storedProcedure: "[dbo].[spShoppingListItem_Update]", shoppingListItem);
    }

    public async Task DeleteShoppingListItem(Guid id)
    {
        await _sqlDataAccess.SaveData(storedProcedure: "[dbo].[spShoppingListItem_Delete]", new { id });
    }

    public async Task<UserData?> GetUserData(Guid userId)
    {
        var result = await GetUsersDataInternal(userId);

        return result?.FirstOrDefault();
    }

    public async Task<IEnumerable<UserData>> GetUsersData()
    {
        return await GetUsersDataInternal(null);
    }

    private async Task<IEnumerable<UserData>> GetUsersDataInternal(Guid? userId)
    {
        return await _sqlDataAccess.LoadData<UserData, dynamic>(storedProcedure: "[dbo].[spUserData_Get]", new { userId });
    }
}
