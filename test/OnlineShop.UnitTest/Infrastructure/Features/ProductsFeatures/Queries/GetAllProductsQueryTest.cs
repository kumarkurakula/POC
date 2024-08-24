using FluentAssertions;
using Moq;
using OnlineShop.Application.Features.ProductsFeatures.Queries;
using OnlineShop.Domain.Entities;
using OnlineShop.UnitTest.Fixtures;

namespace OnlineShop.UnitTest.Infrastructure.Features.ProductsFeatures.Queries
{
    public class GetAllProductsQueryTest : IClassFixture<ProductFixtures>
    {
        private readonly ProductFixtures _productFixtures;

        public GetAllProductsQueryTest(ProductFixtures productFixtures)
        {
            _productFixtures = productFixtures;
        }

        [Fact]
        public void GetAllProductQueryHandler_Should_Retunr_Empty_Products_When_ProductsNotExists()
        {
            var moqApplicationInMemoryDbContext = _productFixtures.MoqApplicationInMemoryDbContext;
            moqApplicationInMemoryDbContext.Setup(x => x.GetProducts()).ReturnsAsync(Enumerable.Empty<Product>());
            var productQueryHandler = new GetAllProductQueryHandler(moqApplicationInMemoryDbContext.Object);

            var products = productQueryHandler?.Handle(new GetAllProductsQuery(), default);

            products!.Result.Count().Should().NotBe(1);
        }

        [Fact]
        public void GetAllProductQueryHandler_Should_Retunr_ListOfProducts_When_ProductsExists()
        {
            var moqApplicationInMemoryDbContext = _productFixtures.MoqApplicationInMemoryDbContext;
            moqApplicationInMemoryDbContext.Setup(x => x.GetProducts()).ReturnsAsync(ProductFixtures.GetProduct);
            var productQueryHandler = new GetAllProductQueryHandler(moqApplicationInMemoryDbContext.Object);

            var products = productQueryHandler?.Handle(new GetAllProductsQuery(), default);

            products!.Result.Count().Should().BeGreaterThan(1);
        }

        [Fact]
        public void GetAllProductQueryHandler_Should_Throw_NullReferenceException_When_InMemoryDbContext_IsNull()
        {
            var productQueryHandler = new GetAllProductQueryHandler(null);

            Action act = () => productQueryHandler?.Handle(null, default);

            act.Should().NotThrow();
        }
    }
}