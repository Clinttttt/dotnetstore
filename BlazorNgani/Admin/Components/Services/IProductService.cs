using BlazorNgani.Models;

namespace BlazorNgani.Admin.Components.Services
{
    public  interface IProductService
    {
        Task <List<Product>> GetAllProduct();
        Task<Product> GetProduct(int productId);
      
    }
}
  