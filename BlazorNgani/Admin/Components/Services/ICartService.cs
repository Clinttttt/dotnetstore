// BlazorNgani/Admin/Components/Services/ICartService.cs
using BlazorNgani.Models;

public interface ICartService
{
    Task<List<Product>> CartItems { get; }
    event Action Onchange;
    Task AddToCart(Product product);
    Task RemoveFromCart(Product product);
    Task<List<Product>> GetCart();
}
