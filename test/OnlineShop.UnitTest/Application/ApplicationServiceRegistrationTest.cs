using AutoMapper;
using FluentAssertions;
using MediatR;
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
            provider[12].ServiceType.Name.Should().BeEquivalentTo(nameof(IMediator));
            provider[12].Lifetime.Should().Be(ServiceLifetime.Transient);
        }
    }
}