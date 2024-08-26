using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;


namespace OnlineShop.UnitTest.Controller
{
    public class ProgramTests
    {
        [Fact]
        public async Task Main_ShouldRunApplication()
        {
            var builder = new WebHostBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                })
                .ConfigureServices(services =>
                {
                })
                .Configure(app =>
                {
                    app.UseRouting();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                });

            using var server = new TestServer(builder);

            using var client = server.CreateClient();
            var response = await client.GetAsync("/");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}