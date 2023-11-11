using Core.Models;
using Core.Ports.In;

namespace handlarn_backend;

public static class API
{
    public static void ConfigureApi(this WebApplication webApplication)
    {
        webApplication.MapGet("/shoppingItem", GetShoppingListItems);
        webApplication.MapGet("/shoppingItem/{id}", GetShoppingListItem);     
        webApplication.MapPost("/shoppingItem", CreateShoppingListItem);
        webApplication.MapPut("/shoppingItem/{id}", UpdateShoppingListItem);
        webApplication.MapDelete("/shoppingItem/{id}", DeleteShoppingListItem);
    }

    private static async Task<IResult> GetShoppingListItems(IShoppingListItemService shoppingListItemService)
    {
        var shoppingItems = await shoppingListItemService.GetAll();

        try
        {    
            return Results.Ok(shoppingItems);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetShoppingListItem(IShoppingListItemService shoppingListItemService, Guid id)
    {
        var shoppingItem = await shoppingListItemService.Get(id);

        if (shoppingItem is null)
        {
            return Results.NotFound($"Sorry, no such shopping item with id {id}");
        }

        return Results.Ok(shoppingItem);
    }

    private static async Task CreateShoppingListItem(IShoppingListItemService shoppingListItemService, ShoppingListItem shoppingItem)
    {
        await shoppingListItemService.Create(shoppingItem);   
    }

    private static async Task UpdateShoppingListItem(IShoppingListItemService shoppingListItemService, ShoppingListItem shoppingItem)
    {
        await shoppingListItemService.Update(shoppingItem);
    }

    private static async Task DeleteShoppingListItem(IShoppingListItemService shoppingListItemService, Guid id)
    {
        await shoppingListItemService.Delete(id);
    }
}