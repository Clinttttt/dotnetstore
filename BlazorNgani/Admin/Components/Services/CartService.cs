using BlazorNgani.Models;

public class CartService : ICartService
{
    private readonly List<Product> _cartItems = new();
    public event Action? Onchange;

    public Task<List<Product>> CartItems => Task.FromResult(_cartItems.ToList());

    public Task AddToCart(Product product)
    {
        if (!_cartItems.Any(p => p.Id == product.Id))
        {
            _cartItems.Add(product);
            Onchange?.Invoke();
        }
        return Task.CompletedTask;
    }

    public Task RemoveFromCart(Product product)
    {
        var item = _cartItems.FirstOrDefault(p => p.Id == product.Id);
        if (item != null)
        {
            _cartItems.Remove(item);
            Onchange?.Invoke();
        }
        return Task.CompletedTask;
    }

    public Task<List<Product>> GetCart() => Task.FromResult(_cartItems.ToList());
}
