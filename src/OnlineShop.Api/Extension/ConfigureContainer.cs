using Microsoft.AspNetCore.Builder;
using OnlineShop.Api.Middleware;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Api.Extension
{

    [ExcludeFromCodeCoverage]
    public static class ConfigureContainer
    {
        internal static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }

        internal static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app
                .UseSwagger()
                .UseSwaggerUI(setupAction =>
                {
                    setupAction.SwaggerEndpoint("/swagger/OpenAPISpecification/swagger.json", "EasyGroceries e-commerce shop API");
                    setupAction.RoutePrefix = "OpenAPI";
                });
        }
    }
}