using BlazorNgani.Data;
using BlazorNgani.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorNgani.Admin.Components.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db) => _db = db;
        public async Task<List<Product>> GetAllProduct() =>
            await _db.ProductInfos.ToListAsync();
        public async Task<Product> GetProduct(int productId)
        {
            return await _db.ProductInfos.FindAsync(productId);
        }
    }
}
