using AutoFixture;
using FluentAssertions;
using Moq;
using OnlineShop.Application.Features.ProductsFeatures.Queries;
using OnlineShop.Domain.Entities;
using OnlineShop.UnitTest.Fixtures;

namespace OnlineShop.UnitTest.Application.Features.ProductsFeatures.Queries
{
    public class GetAllProductsQueryTest : IClassFixture<ApplicationFixture>
    {
        private readonly ApplicationFixture _fixtures;

        public GetAllProductsQueryTest(ApplicationFixture productFixtures)
        {
            _fixtures = productFixtures;
        }

        [Fact]
        public void GetAllProductQueryHandler_Should_Retunr_Empty_Products_When_ProductsNotExists()
        {
            var createOrderCommand = _fixtures.Fixture.Create<GetAllProductsQuery>();
            var moqApplicationInMemoryDbContext = _fixtures.MoqApplicationInMemoryDbContext;
            moqApplicationInMemoryDbContext.Setup(x => x.GetProducts()).ReturnsAsync(Enumerable.Empty<Product>());

            var productQueryHandler = new GetAllProductQueryHandler(moqApplicationInMemoryDbContext.Object);
            var products = productQueryHandler?.Handle(new GetAllProductsQuery(), default);

            products!.Result.Count().Should().NotBe(1);
        }

        [Fact]
        public void GetAllProductQueryHandler_Should_Retunr_ListOfProducts_When_ProductsExists()
        {
            var createOrderCommand = _fixtures.Fixture.Create<GetAllProductsQuery>();
            var moqApplicationInMemoryDbContext = _fixtures.MoqApplicationInMemoryDbContext;
            moqApplicationInMemoryDbContext.Setup(x => x.GetProducts()).ReturnsAsync(ApplicationFixture.GetProduct);

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