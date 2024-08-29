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
        private readonly GetAllProductsQuery _createOrderCommand;

        public GetAllProductsQueryTest(ApplicationFixture productFixtures)
        {
            _fixtures = productFixtures;
            _createOrderCommand = _fixtures.Fixture.Create<GetAllProductsQuery>();
        }

        [Fact]
        public void GetAllProductQueryHandler_Should_Retunr_Empty_Products_When_ProductsNotExists()
        {
            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.GetProducts()).ReturnsAsync(Enumerable.Empty<Product>());

            var productQueryHandler = new GetAllProductQueryHandler(_fixtures.MoqApplicationInMemoryDbContext.Object);
            var response = productQueryHandler!.Handle(_createOrderCommand, default);

            response!.Result.Should().BeNullOrEmpty();

            _fixtures.MoqApplicationInMemoryDbContext.Verify(x => x.GetProducts());
        }

        [Fact]
        public void GetAllProductQueryHandler_Should_Retunr_ListOfProducts_When_ProductsExists()
        {
            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.GetProducts()).ReturnsAsync(ApplicationFixture.GetProduct);

            var productQueryHandler = new GetAllProductQueryHandler(_fixtures.MoqApplicationInMemoryDbContext.Object);
            var response = productQueryHandler!.Handle(_createOrderCommand, default);

            response.Result.Should().NotBeNullOrEmpty();
            response!.Result.Count().Should().BeGreaterThan(1);

            _fixtures.MoqApplicationInMemoryDbContext.Verify(x => x.GetProducts());
        }
    }
}