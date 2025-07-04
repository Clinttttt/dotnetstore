// BlazorNgani/Admin/Components/Services/CartService.cs
using BlazorNgani.Data;
using BlazorNgani.Models;
using Microsoft.EntityFrameworkCore;

public class CartService : ICartService
{
    private readonly ApplicationDbContext _db;
    public event Action? Onchange;

    public CartService(ApplicationDbContext db) => _db = db;

    public async Task AddToCart(Product product)
    {
        // Check if already in cart
        if (!await _db.CartItems.AnyAsync(ci => ci.ProductId == product.Id))
        {
            var cartItem = new CartItem { ProductId = product.Id };
            _db.CartItems.Add(cartItem);
            await _db.SaveChangesAsync();
            Onchange?.Invoke();
        }
    }

    public async Task RemoveFromCart(Product product)
    {
        var cartItem = await _db.CartItems.FirstOrDefaultAsync(ci => ci.ProductId == product.Id);
        if (cartItem != null)
        {
            _db.CartItems.Remove(cartItem);
            await _db.SaveChangesAsync();
            Onchange?.Invoke();
        }
    }

    public async Task<List<Product>> GetCart()
    {
        // Eager load Product for each CartItem
        return await _db.CartItems
            .Include(ci => ci.Product)
            .Select(ci => ci.Product)
            .ToListAsync();
    }

    public Task<List<Product>> CartItems => GetCart();
}

