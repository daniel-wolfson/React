using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JobViewsApi.Core
{
    /// <summary> General context, contains: Identity, ServiceProvider, HttpContext, Cache, Configurations, Helpers </summary>
    public static class ApiContext
    {
        public static IServiceScope ServiceScope { get; set; }

        public static IServiceProvider ServiceProvider { get; set; }

        private static HttpContext _httpContext;
        public static HttpContext HttpContext
        {
            get
            {
                if (_httpContext == null)
                    _httpContext = ServiceScope?.ServiceProvider?.GetService<IHttpContextAccessor>()?.HttpContext
                        ?? new DefaultHttpContext() { RequestServices = ServiceProvider };
                return _httpContext;
            }
            set
            {
                _httpContext = value;
            }
        }
    }
}