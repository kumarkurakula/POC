using OA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Persistence
{
    public interface IApplicationInMemoryDbContext
    {
        Task InitProductInMemoryDb();
        Task<IEnumerable<Product>> GetProducts();
        Task<int> AddProducts(Product product);
    }
}