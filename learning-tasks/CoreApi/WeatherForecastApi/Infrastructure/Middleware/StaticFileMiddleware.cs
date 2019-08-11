using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApi.Infrastructure.Middleware
{
    public class StaticFileMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<StaticFileMiddleware> _logger;
        public StaticFileMiddleware(RequestDelegate requestDelegate, ILogger<StaticFileMiddleware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {

            //var avoidFolders = new string[] { "js", "css", "jpg" };

            //if (avoidFolders.Contains(httpContext.Request.Path.Value.Trim('/')))
            //{
            //    httpContext.Response.StatusCode = 404;

            //}

            //else
            //{
            //    await _next(httpContext);
            //}

            await _next(httpContext);

        }
    }
    public static class StaticFileMiddlewareExtensions
    {
        public static IApplicationBuilder UseStaticFilesMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StaticFileMiddleware>();
        }
    }

}
