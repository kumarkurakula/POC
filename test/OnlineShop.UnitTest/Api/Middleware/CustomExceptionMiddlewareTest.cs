using FluentAssertions;
using Microsoft.AspNetCore.Http;
using OnlineShop.Api.Middleware;
using OnlineShop.Application.Exceptions;
using OnlineShop.UnitTest.Fixtures;
using System.Net.Mime;
using System.Net;

namespace OnlineShop.UnitTest.Api.Middleware
{
    public class CustomExceptionMiddlewareTest : IClassFixture<ApplicationFixture>
    {
        private readonly ApplicationFixture _fixtures;

        public CustomExceptionMiddlewareTest(ApplicationFixture fixtures)
        {
            _fixtures = fixtures;
        }

        [Fact]
        public async Task CustomExceptionMiddleware_Should_Add_Headerame_To_HttpResponse_When_NoException()
        {
            bool isNextDelegateCalled = false;

            _fixtures.HttpContextMock.SetupGet(x => x.Response).Returns(_fixtures.HttpResponseMock.Object);
            _fixtures.HttpContextMock.SetupGet(x => x.Response.Headers).Returns(new HeaderDictionary());

            var requestDelegate = new RequestDelegate(async (innerContext) =>
            {
                isNextDelegateCalled = true;
                await Task.CompletedTask;
            });

            var middelware = new CustomExceptionMiddleware(requestDelegate);

            await middelware.InvokeAsync(_fixtures.HttpContextMock.Object);

            isNextDelegateCalled.Should().BeTrue();
        }

        [Fact]
        public async Task CustomExceptionMiddleware_Should_Throw_BadRequestException()
        {
            var context = new DefaultHttpContext();
            var middleware = new CustomExceptionMiddleware(next: (innerHttpContext) =>
            {
                throw new BadRequestException(string.Empty);
            });

            await middleware.InvokeAsync(context);

            context.Response.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            context.Response.ContentType.Should().Be(MediaTypeNames.Application.Json);
        }

        [Fact]
        public async Task CustomExceptionMiddleware_Should_Throw_InternalServerError()
        {
            var context = new DefaultHttpContext();
            var middleware = new CustomExceptionMiddleware(next: (innerHttpContext) =>
            {
                throw new Exception();
            });

            await middleware.InvokeAsync(context);

            context.Response.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
            context.Response.ContentType.Should().Be(MediaTypeNames.Application.Json);
        }

        [Fact]
        public async Task CustomExceptionMiddleware_Should_Throw_NotFoundException()
        {
            var context = new DefaultHttpContext();
            var middleware = new CustomExceptionMiddleware(next: (innerHttpContext) =>
            {
                throw new NotFoundException(string.Empty, null);
            });

            await middleware.InvokeAsync(context);

            context.Response.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
            context.Response.ContentType.Should().Be(MediaTypeNames.Application.Json);
        }
    }
}