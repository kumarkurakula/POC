using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.Api.Controllers;
using OnlineShop.Application.Features.CategoryFeature.Commands;
using OnlineShop.Application.Features.CategoryFeature.Queries;
using OnlineShop.Application.Features.OrderFeatures.Commands;
using OnlineShop.Application.Features.ProductsFeatures.Queries;
using System.Net;

namespace OnlineShop.UnitTest.Api.Controller
{
    public class CategoryControllerTest
    {
        private readonly Mock<IMediator> _moqMediator;

        public CategoryControllerTest()
        {
            _moqMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task ProductsController_Should_Return_OkResponse_When_CategorListIsNullOrEmpty()
        {
            var categoryController = new CategoryController(_moqMediator.Object);

            var response = await categoryController.GetAllCategory();

            var result = Assert.IsType<OkObjectResult>(response);
            response.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);

            _moqMediator.Verify(x => x.Send(It.IsAny<GetAllCategoryQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task CategoryController_Should_Return_HttpStatusCode_Ok_When_ResponseIsNotNullOrEmpty()
        {
            var categoryController = new CategoryController(_moqMediator.Object);
            _moqMediator.Setup(m => m.Send(It.IsAny<CreateOrderCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var response = await categoryController.Create(new CreateCategoryCommand());

            var result = Assert.IsType<OkObjectResult>(response);
            response.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);

            _moqMediator.Verify(x => x.Send(It.IsAny<CreateCategoryCommand>(), It.IsAny<CancellationToken>()));
        }
    }
}