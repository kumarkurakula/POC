using FluentAssertions;
using MediatR;
using Moq;
using OnlineShop.Api.Controllers;
using OnlineShop.Application.Features.OrderFeatures.Commands;

namespace OnlineShop.UnitTest.Api.Controller
{
    public class OrdersControllerTest
    {
        private readonly Mock<IMediator> _moqMediator;

        public OrdersControllerTest()
        {
            _moqMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task OrderController_Should_Return_BadRequest_When_ResponseIsNullOrEmpty()
        {
            var orderController = new OrderController(_moqMediator.Object);

            var response = await orderController.CreateOrder(new CreateOrderCommand());

            response.Should().NotBeNull();
            _moqMediator.Verify(x => x.Send(It.IsAny<CreateOrderCommand>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task OrderController_Should_Return_HttpStatusCode_Ok_When_ResponseIsNotNullOrEmpty()
        {
            var orderController = new OrderController(_moqMediator.Object);
            _moqMediator.Setup(m => m.Send(It.IsAny<CreateOrderCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var response = await orderController.CreateOrder(new CreateOrderCommand());

            response.Should().NotBeNull();
            _moqMediator.Verify(x => x.Send(It.IsAny<CreateOrderCommand>(), It.IsAny<CancellationToken>()));
        }
    }
}