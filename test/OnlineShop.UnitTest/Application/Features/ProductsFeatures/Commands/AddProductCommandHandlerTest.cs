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

        public AddProductCommandHandlerTest(ApplicationFixture fixtures)
        {
            _fixtures = fixtures;
        }

        [Fact]
        public void AddProductCommandHandler_Should_Save_NewProducts_When_PrductsIsNotNullOrEmpty()
        {
            var createOrderCommand = _fixtures.Fixture.Create<AddProductCommand>();
            var moqApplicationInMemoryDbContext = _fixtures.MoqApplicationInMemoryDbContext;
            moqApplicationInMemoryDbContext.Setup(x => x.AddProducts(It.IsAny<Product>())).ReturnsAsync(1);

            var productCommandHandler = new AddProductCommandHandler(moqApplicationInMemoryDbContext.Object, _fixtures.MoqMapper.Object);
            var response = productCommandHandler.Handle(createOrderCommand, default);

            response.Should().NotBeNull();
            response.Result.Should().BeTrue();
        }

        [Fact]
        public void AddProductCommandHandler_Should_Save_NewProducts_When_PrductsIsNullOrEmpty()
        {
            var createOrderCommand = _fixtures.Fixture.Create<AddProductCommand>();
            var moqApplicationInMemoryDbContext = _fixtures.MoqApplicationInMemoryDbContext;
            moqApplicationInMemoryDbContext.Setup(x => x.AddProducts(It.IsAny<Product>())).ReturnsAsync(0);

            var productCommandHandler = new AddProductCommandHandler(moqApplicationInMemoryDbContext.Object, _fixtures.MoqMapper.Object);
            var response = productCommandHandler.Handle(createOrderCommand, default);

            response.Should().NotBeNull();
            response.Result.Should().BeFalse();
        }
    }
}