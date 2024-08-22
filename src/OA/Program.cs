using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OA.Domain;
using Serilog;
using System;
using System.IO;

namespace OA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile(path: $"appsettings.{Environment.GetEnvironmentVariable(Constants.ASPNETCORE_ENVIRONMENT)}.json", optional: false, reloadOnChange: true)
               .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configBuilder)
                .CreateLogger();

            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

            Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseSerilog();
    }
}