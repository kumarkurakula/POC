using Microsoft.AspNetCore.Builder;
using OnlineShop.Application.Middleware;

namespace OnlineShop.Api.Extension
{
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