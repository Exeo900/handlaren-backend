using Core.Models;
using Core.Ports.In;

namespace handlarn_backend;

public static class API
{
    public static void ConfigureApi(this WebApplication webApplication)
    {
        webApplication.MapGet("/siteInfo", SiteInfo);
        webApplication.MapGet("/shoppingItem", GetShoppingListItems);
        webApplication.MapGet("/shoppingItem/{id}", GetShoppingListItem);     
        webApplication.MapPost("/shoppingItem", CreateShoppingListItem);
        webApplication.MapPut("/shoppingItem/{id}", UpdateShoppingListItem);
        webApplication.MapDelete("/shoppingItem/{id}", DeleteShoppingListItem);
        webApplication.MapGet("/userData/{userid}", GetUserData);
        webApplication.MapGet("/userData/", GetUsersData);
    }

    private static IResult SiteInfo(IConfiguration configuration, IWebHostEnvironment env)
    {
        try
        {
            return Results.Ok($"Hello World! Environment: {env.EnvironmentName}");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetShoppingListItems(IShoppingListItemService shoppingListItemService, Guid? userId)
    {
        if (userId.Equals(Guid.Empty))
        {
            return Results.BadRequest($"User id cannot be empty!");
        }

        var shoppingItems = await shoppingListItemService.GetAll(userId);

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

    private static async Task<IResult> CreateShoppingListItem(IShoppingListItemService shoppingListItemService, ShoppingListItem shoppingItem)
    {
        if (shoppingItem is null)
        {
            return Results.BadRequest($"Missing ShoppingListItem Data!");
        }
        else if (string.IsNullOrEmpty(shoppingItem.Name))
        {
            return Results.BadRequest($"Item must have a name!");
        }
        else if (shoppingItem.Amount is null || shoppingItem.Amount < 1)
        {
            return Results.BadRequest($"Needs atleast one amount!");
        }
        else if (shoppingItem.UserId.Equals(Guid.Empty))
        {
            return Results.BadRequest($"User id cannot be empty!");
        }

        await shoppingListItemService.Create(shoppingItem);

        return Results.Ok("Success!");
    }

    private static async Task UpdateShoppingListItem(IShoppingListItemService shoppingListItemService, ShoppingListItem shoppingItem)
    {
        await shoppingListItemService.Update(shoppingItem);
    }

    private static async Task DeleteShoppingListItem(IShoppingListItemService shoppingListItemService, Guid id)
    {
        await shoppingListItemService.Delete(id);
    }

    private static async Task<IResult> GetUsersData(IUserDataService userDataService)
    {
        var users = await userDataService.GetUsers();

        return Results.Ok(users);
    }

    private static async Task<IResult> GetUserData(IUserDataService userDataService, Guid userId)
    {
        if (userId.Equals(Guid.Empty))
        {
            return Results.BadRequest($"User id cannot be empty!");
        }

        var user = await userDataService.GetUser(userId);

        if (user == null)
        {
            return Results.BadRequest($"User not found with id {userId}");
        }

        return Results.Ok(user);
    }
}