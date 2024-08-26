using FluentAssertions;
using MediatR;
using Moq;
using OnlineShop.Api.Controllers;
using OnlineShop.Application.Features.ProductsFeatures.Commands;
using OnlineShop.Application.Features.ProductsFeatures.Queries;

namespace OnlineShop.UnitTest.Api.Controller
{
    public class ProductsControllerTest
    {
        private readonly Mock<IMediator> _moqMediator;

        public ProductsControllerTest()
        {
            _moqMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task ProductsController_Should_Return_NotFoundResonse_When_ProductsIsNullOrEmpty()
        {
            var productsController = new ProductsController(_moqMediator.Object);

            var response = await productsController.AddProducts(null);

            response.Should().NotBeNull();
        }

        [Fact]
        public async Task ProductsController_Should_Return_OkResponse_When_ProductsIsNullOrEmpty()
        {
            var productsController = new ProductsController(_moqMediator.Object);

            var response = await productsController.GetAllProducts();

            response.Should().NotBeNull();
            _moqMediator.Verify(x => x.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task ProductsController_Should_Return_BadRequest_When_ResponseIsNullOrEmpty()
        {
            var productsController = new ProductsController(_moqMediator.Object);

            var response = await productsController.AddProducts(new AddProductCommand());

            response.Should().NotBeNull();
            _moqMediator.Verify(x => x.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task ProductsController_Should_Return_HttpStatusCode_Ok_When_ResponseIsNotNullOrEmpty()
        {
            var productsController = new ProductsController(_moqMediator.Object);
            _moqMediator.Setup(m => m.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var response = await productsController.AddProducts(new AddProductCommand());

            response.Should().NotBeNull();
            _moqMediator.Verify(x => x.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()));
        }
    }
}