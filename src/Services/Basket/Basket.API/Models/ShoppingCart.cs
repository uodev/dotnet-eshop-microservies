namespace Basket.API.Models;

public class ShoppingCart
{
    public string UserName { get; set; } = default!; // unique olacak ve primary key
    public List<ShoppingCartItem> Items { get; set; } = [];
    public decimal TotalPrice => Items.Sum(i => i.Price);

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }

    public ShoppingCart()
    {
    }
}