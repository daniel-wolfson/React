using DataServices;
using JobViewsApi.Core;
using JobViewsApi.Filters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace JobViewsApi.Tests
{
    /// <summary> define web test context </summary>
    public class TestWebHost
    {
        protected IServiceScope serviceScope;
        public IWebHostBuilder WebHostBuilder;
        public TestServer testServer;

        public TestWebHost()
        {
            WebHostBuilder = new WebHostBuilder()
                .Configure(appBuilder =>
                {
                    ApiContext.HttpContext.RequestServices = appBuilder.ApplicationServices;
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    env.EnvironmentName = "Test";
                })
                .ConfigureServices((context, services) =>
                {
                    var webHostEnvironment = context.HostingEnvironment;
                    webHostEnvironment.ContentRootPath =
                        webHostEnvironment.ContentRootPath.Substring(0, webHostEnvironment.ContentRootPath.IndexOf("\\bin"));

                    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                    services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
                    services.AddSingleton(webHostEnvironment);

                    // filters
                    services
                        .AddMvc(options => options.Filters.Add(typeof(ApiExceptionFilter)))
                        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
                })
                .UseStartup<Startup>();

            testServer = new TestServer(WebHostBuilder);
        }
    }
}
