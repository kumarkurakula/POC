using AutoMapper;
using Moq;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Enum;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.UnitTest.Fixtures
{
    public class ProductFixtures
    {
        public Mock<IApplicationInMemoryDbContext> MoqApplicationInMemoryDbContext;
        public Mock<IMapper> MoqMapper;


        public ProductFixtures()
        {
            MoqApplicationInMemoryDbContext = new Mock<IApplicationInMemoryDbContext>();
            MoqMapper = new Mock<IMapper>();
        }

        public static IEnumerable<Product> GetProduct() => new List<Product>
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