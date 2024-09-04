using AutoFixture;
using FluentAssertions;
using Moq;
using OnlineShop.Application.Features.OrderFeatures.Commands;
using OnlineShop.Application.Model;
using OnlineShop.Domain.Entities;
using OnlineShop.UnitTest.Fixtures;

namespace OnlineShop.UnitTest.Application.Features.OrderFeatures
{
    public class CreateOrderCommandHandlerTest : IClassFixture<ApplicationFixture>
    {
        private readonly ApplicationFixture _fixtures;
        private readonly OrderRequest _createOrderCommand;

        public CreateOrderCommandHandlerTest(ApplicationFixture fixtures)
        {
            _fixtures = fixtures;
            _createOrderCommand = _fixtures.Fixture.Create<OrderRequest>();
        }

        [Fact]
        public void CreateOrderCommandHandlerTest_Should_Save_NewOrders_When_OrdersIsNotNullOrEmpty()
        {
            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.CreateOrders(It.IsAny<OrderDetail>())).ReturnsAsync(1);

            var productCommandHandler = new CreateOrderCommandHandler(_fixtures.MoqApplicationInMemoryDbContext.Object, _fixtures.MoqMapper.Object);
            var response = productCommandHandler.Handle(_createOrderCommand, default);

            response.Should().NotBeNull();
            response.Result.Should().BeTrue();

            _fixtures.MoqApplicationInMemoryDbContext.Verify(x => x.CreateOrders(It.IsAny<OrderDetail>()));
        }

        [Fact]
        public void CreateOrderCommandHandlerTest_Should_Save_NewOrders_When_OrdersNullOrEmpty()
        {
            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.CreateOrders(It.IsAny<OrderDetail>())).ReturnsAsync(0);

            var productCommandHandler = new CreateOrderCommandHandler(_fixtures.MoqApplicationInMemoryDbContext.Object, _fixtures.MoqMapper.Object);
            var response = productCommandHandler.Handle(_createOrderCommand, default);

            response.Should().NotBeNull();
            response.Result.Should().BeFalse();

            _fixtures.MoqApplicationInMemoryDbContext.Verify(x => x.CreateOrders(It.IsAny<OrderDetail>()));
        }
    }
}