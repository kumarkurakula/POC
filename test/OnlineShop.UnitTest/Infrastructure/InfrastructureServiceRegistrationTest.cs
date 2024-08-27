using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            provider.Count.Should().Be(5);
        }
    }
}