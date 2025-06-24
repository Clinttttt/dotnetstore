using BlazorNgani.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorNgani.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ProductDetails> ProductInfo { get; set; }
        protected ApplicationDbContext()
        {
        }
    }
}
