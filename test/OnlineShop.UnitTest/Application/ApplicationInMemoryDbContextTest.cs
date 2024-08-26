using OnlineShop.UnitTest.Fixtures;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.UnitTest.Application
{
    [ExcludeFromCodeCoverage]
    public class ApplicationInMemoryDbContextTest : IClassFixture<InMemoryDbContextFixture>
    {
        private readonly InMemoryDbContextFixture _inMemoryDbContextFixture;

        public ApplicationInMemoryDbContextTest(InMemoryDbContextFixture inMemoryDbContextFixture)
        {
            _inMemoryDbContextFixture = inMemoryDbContextFixture;
        }
    }
}