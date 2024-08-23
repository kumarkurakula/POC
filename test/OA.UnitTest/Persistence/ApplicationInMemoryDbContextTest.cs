using OA.UnitTest.Fixtures;

namespace OA.UnitTest.Persistence
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