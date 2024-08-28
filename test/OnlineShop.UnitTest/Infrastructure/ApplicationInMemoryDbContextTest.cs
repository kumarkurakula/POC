using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.UnitTest.Infrastructure
{
    public class ApplicationInMemoryDbContextTest
    {
        private readonly DbContextOptionsBuilder<InMemoryDbContext> dbContext;
        private readonly InMemoryDbContext inMemoryDbContext;

        public ApplicationInMemoryDbContextTest()
        {
            dbContext = new DbContextOptionsBuilder<InMemoryDbContext>();
            dbContext.UseInMemoryDatabase(Guid.NewGuid().ToString());
            inMemoryDbContext = new InMemoryDbContext(dbContext.Options);
        }

        [Fact]
        public async Task ApplicationInMemoryDbContext_Should_AddProducts_When_Products_IsNullOrEmpty()
        {
            var context = new ApplicationInMemoryDbContext(inMemoryDbContext);

            var response = await context.AddProducts(new Product()).ConfigureAwait(false);

            response.Should().NotBe(null);
            response.Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task ApplicationInMemoryDbContext_Should_CreateOrders_When_Orders_IsNullOrEmpty()
        {
            var fixture = new Fixture();
            var orderDetails = fixture.Create<OrderDetail>();

            var context = new ApplicationInMemoryDbContext(inMemoryDbContext);

            var response = await context.CreateOrders(orderDetails).ConfigureAwait(false);

            response.Should().NotBe(null);
        }

        [Fact]
        public async Task ApplicationInMemoryDbContext_Should_GetProducts()
        {
            var context = new ApplicationInMemoryDbContext(inMemoryDbContext);

            var response = await context.GetProducts().ConfigureAwait(false);

            response.Should().NotBeEmpty();
            response.Count().Should().BeGreaterThanOrEqualTo(1);
        }
    }
}