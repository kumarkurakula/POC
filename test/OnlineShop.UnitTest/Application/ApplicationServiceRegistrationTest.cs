using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application;

namespace OnlineShop.UnitTest.Application
{
    public class ApplicationServiceRegistrationTest
    {
        [Fact]
        public void ApplicationServiceRegistration_Should_NotBe_EmptyServiceCollection()
        {
            var services = new ServiceCollection();

            var provider = services.AddApplicationServices();

            provider.Should().NotBeNull();
            provider[7].ServiceType.Name.Should().BeEquivalentTo(nameof(IMapper));
            provider[7].Lifetime.Should().Be(ServiceLifetime.Transient);
        }
    }
}