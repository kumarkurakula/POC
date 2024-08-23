using OnlineShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Persistence
{
    public interface IApplicationInMemoryDbContext
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<int> AddProducts(Product product);
    }
}