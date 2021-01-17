using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobViewsApi.Core;

namespace JobViewsApi.Middleware
{
    public class ApiContextMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Path.Value.StartsWith("/api"))
            {
                ApiContext.ServiceScope = httpContext.RequestServices.CreateScope();
            }

            await _next(httpContext);

            if (httpContext.Request.Path.Value.StartsWith("/api"))
            {
                ApiContext.ServiceScope?.Dispose();
            }
        }
    }
}
