using AutoFixture;
using FluentAssertions;
using Moq;
using OnlineShop.Application.Handlers.CategoryHandler.Queries;
using OnlineShop.Domain.Entities;
using OnlineShop.UnitTest.SharedContext;

namespace OnlineShop.UnitTest.Application.Handlers.CategoryHandlers.Queries
{
    public class GetAllCategoryQueryTest : IClassFixture<ApplicationFixture>
    {
        private readonly ApplicationFixture _fixtures;
        private readonly GetAllCategoryQuery _getAllCategoryQuery;

        public GetAllCategoryQueryTest(ApplicationFixture fixtures)
        {
            _fixtures = fixtures;
            _getAllCategoryQuery = _fixtures.Fixture.Create<GetAllCategoryQuery>();
        }

        [Fact]
        public void GetAllCategoryQueryHandler_Should_Retunr_Empty_Products_When_CategoryNotExists()
        {
            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.GetCateroy()).ReturnsAsync(Enumerable.Empty<Category>());

            var categoryQueryHandler = new GetAllCategoryQueryHandler(_fixtures.MoqApplicationInMemoryDbContext.Object);
            var category = categoryQueryHandler!.Handle(_getAllCategoryQuery, default);

            category!.Result.Should().BeNullOrEmpty();

            _fixtures.MoqApplicationInMemoryDbContext.Verify(x => x.GetCateroy());
        }

        [Fact]
        public void GetAllCategoryQueryHandler_Should_Retunr_ListOfProducts_When_CategoryExists()
        {
            _fixtures.MoqApplicationInMemoryDbContext.Setup(x => x.GetCateroy()).ReturnsAsync(_fixtures.Fixture.Create<IEnumerable<Category>>());

            var categoryQueryHandler = new GetAllCategoryQueryHandler(_fixtures.MoqApplicationInMemoryDbContext.Object);
            var category = categoryQueryHandler!.Handle(_getAllCategoryQuery, default);

            category!.Result.Should().NotBeNullOrEmpty();
            category!.Result.Count().Should().BeGreaterThan(1);

            _fixtures.MoqApplicationInMemoryDbContext.Verify(x => x.GetCateroy());
        }
    }
}