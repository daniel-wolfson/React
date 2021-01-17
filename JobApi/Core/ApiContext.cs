using Microsoft.Extensions.DependencyInjection;

namespace JobViewsApi.Core
{
    /// <summary> General context, contains: Identity, ServiceProvider, HttpContext, Cache, Configurations, Helpers </summary>
    public static class ApiContext
    {
        public static IServiceScope ServiceScope { get; set; }
    }
}