using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApi.Infrastructure.Middleware
{
    public class FolderProtectionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly PathString _path;
        private readonly string _policyName;

        public FolderProtectionMiddleware(RequestDelegate next, ProtectFolderOptions options)
        {
            _next = next;
            _path = options.Path;
            _policyName = options.PolicyName;
        }

        public async Task Invoke(HttpContext httpContext,
                                 IAuthorizationService authorizationService)
        {

            var values = httpContext.Request.Path.ToString().Split(".");

            if (values.ToArray().Length >= 2)
            {
                if (values.Contains("zip"))
                {
                    await _next(httpContext);
                }
                return;

            }


            await _next(httpContext);

            //if (httpContext.Request.Path.StartsWithSegments(_path))
            //{
            //    var authorized = await authorizationService.AuthorizeAsync(
            //                        httpContext.User, null, _policyName);
            //    if (!authorized.Succeeded)
            //    {
            //        await httpContext.Authentication.ChallengeAsync();
            //        return;
            //    }
            //}

            //  await _next(httpContext);
        }
      
    }
    public static class ProtectFolderExtensions
    {
        public static IApplicationBuilder FolderProtection(
            this IApplicationBuilder builder,
            ProtectFolderOptions options)
        {
            return builder.UseMiddleware<FolderProtectionMiddleware>(options);
        }
    }
    public class ProtectFolderOptions
    {

        public PathString Path { get; set; }
        public string PolicyName { get; set; }
    }
}
