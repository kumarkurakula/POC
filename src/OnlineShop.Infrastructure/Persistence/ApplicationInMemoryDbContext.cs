using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Domain.Entities;
using OnlineShop.Persistence.Seeds;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Persistence
{
    public class ApplicationInMemoryDbContext : IApplicationInMemoryDbContext
    {
        private readonly InMemoryDbContext _dbContext;

        public ApplicationInMemoryDbContext(InMemoryDbContext inMemoryDbContext)
        {
            _dbContext = inMemoryDbContext;
        }

        public async Task<int> AddProducts(Product product)
        {
            _dbContext.Product.AddRange(product);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CreateOrders(OrderDetail orderDetail)
        {
            _dbContext.Orders.AddRange(orderDetail);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CreateCategory(Category category)
        {
            _dbContext.Category.AddRange(category);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            _ = InitProductInMemoryDb();

            var list = await _dbContext.Product.ToListAsync();
            return list;
        }

        public async Task<IEnumerable<Category>> GetCateroy()
        {
            _ = InitCategoryInMemoryDb();

            var list = await _dbContext.Category.ToListAsync();
            return list;
        }

        private async Task InitProductInMemoryDb()
        {
            await SeedData.Seed(_dbContext).ConfigureAwait(false);
        }
        private async Task InitCategoryInMemoryDb()
        {
            await SeedData.CategorySeed(_dbContext).ConfigureAwait(false);
        }
    }
}