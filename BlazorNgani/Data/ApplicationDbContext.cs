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
        protected ApplicationDbContext()
        {
        }
    }
}
