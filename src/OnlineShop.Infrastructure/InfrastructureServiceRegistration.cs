using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Contracts.Persistence;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services
                .AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase("ImMemoryDb"))
                .AddScoped<InMemoryDbContext>()
                .AddScoped<IApplicationInMemoryDbContext, ApplicationInMemoryDbContext>();
        }
    }
}