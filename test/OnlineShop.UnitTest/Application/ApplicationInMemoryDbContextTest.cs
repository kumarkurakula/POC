using OnlineShop.UnitTest.Fixtures;

namespace OnlineShop.UnitTest.Application
{
    public class ApplicationInMemoryDbContextTest : IClassFixture<InMemoryDbContextFixture>
    {
        private readonly InMemoryDbContextFixture _inMemoryDbContextFixture;

        public ApplicationInMemoryDbContextTest(InMemoryDbContextFixture inMemoryDbContextFixture)
        {
            _inMemoryDbContextFixture = inMemoryDbContextFixture;
        }
    }
}