using DataServices;
using JobViewsApi.Core;
using JobViewsApi.Filters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Serilog;
using System;
using System.Linq.Expressions;
using System.Reflection;

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

                    config.SetBasePath(env.ContentRootPath)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                          .AddEnvironmentVariables(prefix: "PandoLogic_")
                          .AddEnvironmentVariables()
                          .Build();
                })
                .ConfigureServices((context, services) =>
                {
                    var loggerConfig = new LoggerConfiguration()
                        .ReadFrom.Configuration(context.Configuration);

                    // logger
                    Log.Logger = loggerConfig.CreateLogger();
                    Log.Information($"{Assembly.GetEntryAssembly().GetName().Name} API started");
                    services.AddSingleton(Log.Logger);

                    var webHostEnvironment = context.HostingEnvironment;
                    webHostEnvironment.ContentRootPath = webHostEnvironment.ContentRootPath.Substring(0, webHostEnvironment.ContentRootPath.IndexOf("\\bin")).Replace(".Tests", "");

                    // contexts
                    var mockContext = new Mock<HttpContext>(MockBehavior.Strict);
                    mockContext.SetupGet(hc => hc.User.Identity.Name).Returns("PandoLogic");
                    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                    services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
                    services.AddSingleton<IWebHostEnvironment>(webHostEnvironment);

                    // filters
                    services
                        .AddMvc(options => options.Filters.Add(typeof(ApiExceptionFilter)))
                        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

                    // helpers
                    var mockUrlHelper = new Mock<IUrlHelper>(MockBehavior.Strict);
                    Expression<Func<IUrlHelper, string>> urlSetup = url => url.Action(It.Is<UrlActionContext>(uac => uac.Action == "Get"));
                    mockUrlHelper.Setup(urlSetup).Returns("mock/testing");

                    // service provider & http context
                    //ApiContext.ServiceProvider = services.BuildServiceProvider();
                    //ApiContext.HttpContext = new DefaultHttpContext() { RequestServices = ApiContext.ServiceProvider };
                })
                .ConfigureLogging((context, logging) =>
                {
                    logging.AddSerilog(logging.Services
                        .BuildServiceProvider()
                        .GetRequiredService<ILogger>(),
                        dispose: true);
                })
                .UseSerilog()
                .UseStartup<Startup>();

            testServer = new TestServer(WebHostBuilder);
        }
    }
}
