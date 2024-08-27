using AutoFixture;
using FluentAssertions;
using Moq;
using OnlineShop.Application.Features.OrderFeatures.Commands;
using OnlineShop.Domain.Entities;
using OnlineShop.UnitTest.Fixtures;

namespace OnlineShop.UnitTest.Application.Features.OrderFeatures
{
    public class CreateOrderCommandHandlerTest : IClassFixture<ApplicationFixture>
    {
        private readonly ApplicationFixture _fixtures;

        public CreateOrderCommandHandlerTest(ApplicationFixture productFixtures)
        {
            _fixtures = productFixtures;
        }

        [Fact]
        public void CreateOrderCommandHandlerTest_Should_Save_NewOrders_When_OrdersIsNotNullOrEmpty()
        {
            var createOrderCommand = _fixtures.Fixture.Create<CreateOrderCommand>();
            var moqApplicationInMemoryDbContext = _fixtures.MoqApplicationInMemoryDbContext;
            moqApplicationInMemoryDbContext.Setup(x => x.CreateOrders(It.IsAny<OrderDetail>())).ReturnsAsync(1);

            var productCommandHandler = new CreateOrderCommandHandler(moqApplicationInMemoryDbContext.Object, _fixtures.MoqMapper.Object);
            var response = productCommandHandler.Handle(createOrderCommand, default);

            response.Should().NotBeNull();
            response.Result.Should().BeTrue();
        }

        [Fact]
        public void CreateOrderCommandHandlerTest_Should_Save_NewOrders_When_OrdersNullOrEmpty()
        {
            var createOrderCommand = _fixtures.Fixture.Create<CreateOrderCommand>();
            var moqApplicationInMemoryDbContext = _fixtures.MoqApplicationInMemoryDbContext;
            moqApplicationInMemoryDbContext.Setup(x => x.CreateOrders(It.IsAny<OrderDetail>())).ReturnsAsync(0);

            var productCommandHandler = new CreateOrderCommandHandler(moqApplicationInMemoryDbContext.Object, _fixtures.MoqMapper.Object);
            var response = productCommandHandler.Handle(createOrderCommand, default);

            response.Should().NotBeNull();
            response.Result.Should().BeFalse();
        }
    }
}