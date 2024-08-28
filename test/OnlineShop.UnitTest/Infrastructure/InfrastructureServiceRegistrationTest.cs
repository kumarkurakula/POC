using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.UnitTest.Infrastructure
{
    public class InfrastructureServiceRegistrationTest
    {
        [Fact]
        public void InfrastructureServiceRegistration_Should_NotBe_EmptyServiceCollection()
        {
            var services = new ServiceCollection();

            var provider = services.AddInfrastructureServices();

            provider.Should().NotBeNull();
            provider[3].ServiceType.Name.Should().BeEquivalentTo(nameof(InMemoryDbContext));
            provider[3].Lifetime.Should().Be(ServiceLifetime.Scoped);
            provider[4].ServiceType.Name.Should().BeEquivalentTo(nameof(IApplicationInMemoryDbContext));
            provider[4].Lifetime.Should().Be(ServiceLifetime.Scoped);
        }
    }
}