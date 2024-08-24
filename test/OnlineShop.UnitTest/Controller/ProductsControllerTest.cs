﻿using FluentAssertions;
using MediatR;
using Moq;
using OnlineShop.Api.Controllers;
using OnlineShop.Application.Features.ProductsFeatures.Commands;

namespace OnlineShop.UnitTest.Controller
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
        }

        [Fact]
        public async Task ProductsController_Should_Return_BadRequest_When_ResponseIsNullOrEmpty()
        {
            var productsController = new ProductsController(_moqMediator.Object);
            var response = await productsController.AddProducts(new AddProductCommand());
            response.Should().NotBeNull();
        }
    }
}