namespace Core.Models;
public class ShoppingListItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int? Amount { get; set; }
    public bool? IsChecked { get; set; }
    public bool IsActive { get; set; }
    public Guid UserId { get; set; }
}