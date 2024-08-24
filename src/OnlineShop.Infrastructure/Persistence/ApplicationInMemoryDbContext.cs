using OnlineShop.Domain.Entities;
using OnlineShop.Persistence.Seeds;
using System.Collections.Generic;
using System.Linq;
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

        public Task<IEnumerable<Product>> GetProducts()
        {
            _ = InitProductInMemoryDb();

            var list = _dbContext.Product.ToList();
            return Task.FromResult<IEnumerable<Product>>(list);
        }

        private async Task InitProductInMemoryDb()
        {
            await ProductsSeedData.Seed(_dbContext).ConfigureAwait(false);
        }
    }
}