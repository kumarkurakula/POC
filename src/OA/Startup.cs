using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OA.Infrastructure.Extension;
using OA.Service;

namespace OA
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
                 options.WithOrigins("http://localhost:3000")
                 .AllowAnyHeader()
                 .AllowAnyMethod());

            app.ConfigureCustomExceptionMiddleware();

            app.UseRouting();

            app.ConfigureSwagger();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddController();

            services.AddDbContext();

            services.AddAutoMapper();

            services.AddScopedServices();

            services.AddSwaggerOpenAPI();

            services.AddServiceLayer();

            services.AddVersion();
        }
    }
}