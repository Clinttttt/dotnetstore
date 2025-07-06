using BlazorNgani.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorNgani.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> ProductInfos { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<AdminInfoModel> AdminInformation { get; set; }

        protected ApplicationDbContext()
        {
        }
    }
}
