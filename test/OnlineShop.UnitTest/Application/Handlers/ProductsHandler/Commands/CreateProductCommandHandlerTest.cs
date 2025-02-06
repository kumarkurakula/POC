using AutoFixture;
using FluentAssertions;
using Moq;
using OnlineShop.Application.Handlers.ProductHandler.Commands;
using OnlineShop.Application.Model;
using OnlineShop.Domain.Entities;
using OnlineShop.UnitTest.SharedContext;

namespace OnlineShop.UnitTest.Application.Handlers.ProductsHandler.Commands
{
    public class CreateProductCommandHandlerTest : IClassFixture<ApplicationFixture>
    {
        private readonly ApplicationFixture _fixtures;
        private readonly ProductRequest _createOrderCommand;

        public CreateProductCommandHandlerTest(ApplicationFixture fixtures)
        {
            _fixtures = fixtures;
            _createOrderCommand = _fixtures.Fixture.Create<ProductRequest>();
        }

        [Fact]
        public void AddProductCommandHandler_Should_Save_NewProducts_When_PrductsIsNotNullOrEmpty()
        {
            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.AddProducts(It.IsAny<Product>())).ReturnsAsync(1);

            var productCommandHandler = new CreateProductCommandHandler(_fixtures.MoqApplicationInMemoryDbContext.Object, _fixtures.MoqMapper.Object);
            var response = productCommandHandler.Handle(_createOrderCommand, default);

            response.Should().NotBeNull();
            response.Result.Should().BeTrue();

            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.AddProducts(It.IsAny<Product>()));
        }

        [Fact]
        public void AddProductCommandHandler_Should_Save_NewProducts_When_PrductsIsNullOrEmpty()
        {
            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.AddProducts(It.IsAny<Product>())).ReturnsAsync(0);

            var productCommandHandler = new CreateProductCommandHandler(_fixtures.MoqApplicationInMemoryDbContext.Object, _fixtures.MoqMapper.Object);
            var response = productCommandHandler.Handle(_createOrderCommand, default);

            response.Should().NotBeNull();
            response.Result.Should().BeFalse();

            _fixtures.MoqApplicationInMemoryDbContext.Verify(x => x.AddProducts(It.IsAny<Product>()));
        }
    }
}