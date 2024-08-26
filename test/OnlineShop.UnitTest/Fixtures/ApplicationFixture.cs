using AutoMapper;
using Moq;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Enum;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.UnitTest.Fixtures
{
    [ExcludeFromCodeCoverage]
    public class ApplicationFixture
    {
        public Mock<IApplicationInMemoryDbContext> MoqApplicationInMemoryDbContext;
        public Mock<IMapper> MoqMapper;

        public ApplicationFixture()
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