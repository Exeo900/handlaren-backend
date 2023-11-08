using Core.Ports.Out;

namespace handlarn_backend;

public static class API
{
    public static void ConfigureApi(this WebApplication webApplication)
    {
        var shoppingItems = new List<ShoppingItem>()
        {
            new ShoppingItem(){Id = 1, Text = "Ketchup"},
            new ShoppingItem(){Id = 2, Text = "Senap"}
        };

        webApplication.MapGet("/shoppingItem", GetShoppgingItems);

        webApplication.MapGet("/shoppingItem/{id}", (int id) =>
        {
            var item = shoppingItems.FirstOrDefault(x => x.Id == id);

            if (item is null)
            {
                return Results.NotFound($"Sorry, no such item with id {id}");
            }

            return Results.Ok(item);
        });

        webApplication.MapPost("/shoppingItem", (ShoppingItem shoppingItem) =>
        {
            shoppingItems.Add(shoppingItem);
            return shoppingItems;
        });

        webApplication.MapPut("/shoppingItem/{id}", (ShoppingItem shoppingItem, int id) =>
        {
            var item = shoppingItems.FirstOrDefault(x => x.Id == id);

            if (item is null)
            {
                return Results.NotFound($"Sorry, no such item with id {id}");
            }

            item.Text = shoppingItem.Text;

            return Results.Ok(item);
        });

        webApplication.MapDelete("/shoppingItem/{id}", (int id) =>
        {
            var item = shoppingItems.FirstOrDefault(x => x.Id == id);

            if (item is null)
            {
                return Results.NotFound($"Sorry, no such item with id {id}");
            }

            shoppingItems.Remove(item);

            return Results.Ok(shoppingItems);
        });
    }

    private static async Task<IResult> GetShoppgingItems(IDataAccess dataAccess)
    {
        var shoppingItems = await dataAccess.GetShoppingListItems();

        try
        {    
            return Results.Ok(shoppingItems);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}

public class ShoppingItem
{
    public int Id { get; set; }
    public string Text { get; set; }
}

