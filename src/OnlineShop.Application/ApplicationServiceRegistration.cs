using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Behaviors;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace OnlineShop.Application
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}