using Moq;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Enum;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.UnitTest.Fixtures
{
    public class ProductFixtures
    {
        public Mock<IApplicationInMemoryDbContext> MoqApplicationInMemoryDbContext;

        public ProductFixtures()
        {
            MoqApplicationInMemoryDbContext = new Mock<IApplicationInMemoryDbContext>();
        }

        public IEnumerable<Product> GetProduct()
        {
            return new List<Product>
            {
                 new()
                {
                    ProductName = "Apple",
                    UnitPrice= 200.45m,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    CategoryId = 101,
                },
                new()
                {
                    ProductName = "Milk",
                    UnitOfMeasurement = UnitOfMeasurement.Liter,
                    CategoryId = 1001
                }
            };
        }
    }
}