using OnlineShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Application.Contracts.Persistence
{
    public interface IApplicationInMemoryDbContext
    {
        Task<IEnumerable<Category>> GetCateroy();
        Task<IEnumerable<Product>> GetProducts();
        Task<int> AddProducts(Product product);
        Task<int> CreateCategory(Category category);
        Task<int> CreateOrders(OrderDetail orderDetail);
    }
}