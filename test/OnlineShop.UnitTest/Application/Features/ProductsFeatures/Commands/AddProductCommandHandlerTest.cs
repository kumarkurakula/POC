using AutoFixture;
using FluentAssertions;
using Moq;
using OnlineShop.Application.Features.ProductsFeatures.Commands;
using OnlineShop.Domain.Entities;
using OnlineShop.UnitTest.Fixtures;

namespace OnlineShop.UnitTest.Application.Features.ProductsFeatures.Commands
{
    public class AddProductCommandHandlerTest : IClassFixture<ApplicationFixture>
    {
        private readonly ApplicationFixture _fixtures;
        private readonly AddProductCommand _createOrderCommand;

        public AddProductCommandHandlerTest(ApplicationFixture fixtures)
        {
            _fixtures = fixtures;
            _createOrderCommand = _fixtures.Fixture.Create<AddProductCommand>();
        }

        [Fact]
        public void AddProductCommandHandler_Should_Save_NewProducts_When_PrductsIsNotNullOrEmpty()
        {
            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.AddProducts(It.IsAny<Product>())).ReturnsAsync(1);

            var productCommandHandler = new AddProductCommandHandler(_fixtures.MoqApplicationInMemoryDbContext.Object, _fixtures.MoqMapper.Object);
            var response = productCommandHandler.Handle(_createOrderCommand, default);

            response.Should().NotBeNull();
            response.Result.Should().BeTrue();

            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.AddProducts(It.IsAny<Product>()));
        }

        [Fact]
        public void AddProductCommandHandler_Should_Save_NewProducts_When_PrductsIsNullOrEmpty()
        {
            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.AddProducts(It.IsAny<Product>())).ReturnsAsync(0);

            var productCommandHandler = new AddProductCommandHandler(_fixtures.MoqApplicationInMemoryDbContext.Object, _fixtures.MoqMapper.Object);
            var response = productCommandHandler.Handle(_createOrderCommand, default);

            response.Should().NotBeNull();
            response.Result.Should().BeFalse();

            _fixtures.MoqApplicationInMemoryDbContext.Verify(x => x.AddProducts(It.IsAny<Product>()));
        }
    }
}