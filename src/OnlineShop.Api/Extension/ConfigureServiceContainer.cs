using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OnlineShop.Infrastructure.Persistence;
using System.Reflection;

namespace OnlineShop.Api.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddController(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers().AddNewtonsoftJson();
        }

        public static void AddDbContext(this IServiceCollection serviceCollection)

        {
            serviceCollection.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase("ImMemoryDb"));
        }

        public static void AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<InMemoryDbContext>()
                .AddScoped<IApplicationInMemoryDbContext, ApplicationInMemoryDbContext>();
        }

        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "OpenAPISpecification",
                    new OpenApiInfo()
                    {
                        Title = "EasyGroceries e-commerce shop",
                        Version = "1",
                        Description = "Through this API you can access EasyGroceries e-commerce shop",
                    });
            });
        }

        public static void AddVersion(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}