using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Enum;
using OnlineShop.Infrastructure.Persistence;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.UnitTest.Fixtures
{
    [ExcludeFromCodeCoverage]
    public class ApplicationFixture
    {
        public Fixture Fixture;
        public Mock<IApplicationInMemoryDbContext> MoqApplicationInMemoryDbContext;
        public DbContextOptionsBuilder DbContextOptionsBuilder;
        public Mock<IMapper> MoqMapper;
        public Mock<HttpResponse> HttpResponseMock;
        public Mock<HttpContext> HttpContextMock;
        public Mock<InMemoryDbContext> moqInMemoryDbContext;

        public ApplicationFixture()
        {
            Fixture = new Fixture();
            MoqApplicationInMemoryDbContext = new Mock<IApplicationInMemoryDbContext>();
            moqInMemoryDbContext = new Mock<InMemoryDbContext>();
            MoqMapper = new Mock<IMapper>();
            HttpResponseMock = new Mock<HttpResponse>();
            HttpContextMock = new Mock<HttpContext>();
            DbContextOptionsBuilder = new DbContextOptionsBuilder<InMemoryDbContext>();
            DbContextOptionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
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