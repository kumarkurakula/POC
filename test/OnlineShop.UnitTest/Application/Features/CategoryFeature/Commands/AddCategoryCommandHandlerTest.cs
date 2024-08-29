using AutoFixture;
using FluentAssertions;
using Moq;
using OnlineShop.Application.Features.CategoryFeature.Commands;
using OnlineShop.Domain.Entities;
using OnlineShop.UnitTest.Fixtures;

namespace OnlineShop.UnitTest.Application.Features.CategoryFeature.Commands
{
    public class AddCategoryCommandHandlerTest : IClassFixture<ApplicationFixture>
    {
        private readonly ApplicationFixture _fixtures;
        private readonly CreateCategoryCommand _createCategoryCommand;

        public AddCategoryCommandHandlerTest(ApplicationFixture fixtures)
        {
            _fixtures = fixtures;
            _createCategoryCommand = _fixtures.Fixture.Create<CreateCategoryCommand>();
        }

        [Fact]
        public void AddCategoryCommandHandler_Should_Save_NewCategory_When_CategoryIsNotNullOrEmpty()
        {
            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.CreateCategory(It.IsAny<Category>())).ReturnsAsync(1);

            var categoryCommandHandler = new CreateCategoryCommandHandler(_fixtures.MoqApplicationInMemoryDbContext.Object, _fixtures.MoqMapper.Object);
            var response = categoryCommandHandler.Handle(_createCategoryCommand, default);

            response.Should().NotBeNull();
            response.Result.Should().BeTrue();

            _fixtures.MoqApplicationInMemoryDbContext.Verify(x => x.CreateCategory(It.IsAny<Category>()));
        }

        [Fact]
        public void AddCategoryCommandHandler_Should_Save_NewProducts_When_CategoryIsNullOrEmpty()
        {
            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.CreateCategory(It.IsAny<Category>())).ReturnsAsync(0);

            var categoryCommandHandler = new CreateCategoryCommandHandler(_fixtures.MoqApplicationInMemoryDbContext.Object, _fixtures.MoqMapper.Object);
            var response = categoryCommandHandler.Handle(_createCategoryCommand, default);

            response.Should().NotBeNull();
            response.Result.Should().BeFalse();

            _fixtures.MoqApplicationInMemoryDbContext.Verify(x => x.CreateCategory(It.IsAny<Category>()));
        }
    }
}