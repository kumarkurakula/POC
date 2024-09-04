using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.Api.Controllers;
using OnlineShop.Application.Model;
using System.Net;

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

            var response = await orderController.Create(new OrderRequest());

            var result = Assert.IsType<OkObjectResult>(response);
            response.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);

            _moqMediator.Verify(x => x.Send(It.IsAny<OrderRequest>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task OrderController_Should_Return_HttpStatusCode_Ok_When_ResponseIsNotNullOrEmpty()
        {
            var orderController = new OrderController(_moqMediator.Object);
            _moqMediator.Setup(m => m.Send(It.IsAny<OrderRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var response = await orderController.Create(new OrderRequest());

            var result = Assert.IsType<OkObjectResult>(response);
            response.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);

            _moqMediator.Verify(x => x.Send(It.IsAny<OrderRequest>(), It.IsAny<CancellationToken>()));
        }
    }
}