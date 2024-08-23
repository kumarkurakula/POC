using FluentAssertions;
using Moq;
using OnlineShop.UnitTest.Fixtures;
using OnlineShop.Application.Features.ProductsFeatures.Commands;
using OnlineShop.Domain.Entities;

namespace OnlineShop.UnitTest.Infrastructure.Features.ProductsFeatures.Commands
{
    public class AddProductCommandHandlerTest : IClassFixture<ProductFixtures>
    {
        private readonly ProductFixtures _productFixtures;

        public AddProductCommandHandlerTest(ProductFixtures productFixtures)
        {
            _productFixtures = productFixtures;
        }

        [Fact]
        public void AddProductCommandHandler_Should_Save_NewProducts_When_PrductsIsNotNullOrEmpty()
        {
            var moqApplicationInMemoryDbContext = _productFixtures.MoqApplicationInMemoryDbContext;
            moqApplicationInMemoryDbContext.Setup(x => x.AddProducts(It.IsAny<Product>())).ReturnsAsync(1);

            var productCommandHandler = new AddProductCommandHandler(moqApplicationInMemoryDbContext.Object);
            var response = productCommandHandler.Handle(new AddProductCommand(), default);

            response.Should().NotBeNull();
            response.Result.Should().BeTrue();
        }

        [Fact]
        public void AddProductCommandHandler_Should_Save_NewProducts_When_PrductsIsNullOrEmpty()
        {
            var moqApplicationInMemoryDbContext = _productFixtures.MoqApplicationInMemoryDbContext;
            moqApplicationInMemoryDbContext.Setup(x => x.AddProducts(It.IsAny<Product>())).ReturnsAsync(0);

            var productCommandHandler = new AddProductCommandHandler(moqApplicationInMemoryDbContext.Object);
            var response = productCommandHandler.Handle(new AddProductCommand(), default);

            response.Should().NotBeNull();
            response.Result.Should().BeFalse();
        }
    }
}