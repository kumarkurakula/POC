using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Persistence
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<OrderDetail> Orders { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}