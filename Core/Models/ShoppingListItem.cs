namespace Core.Models;
public class ShoppingListItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int? Amount { get; set; }
    public bool? isChecked { get; set; }
}