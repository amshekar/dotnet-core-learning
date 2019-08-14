using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using WeatherForecastApi.Helpers;
using WeatherForecastApi.Infrastructure.Middleware;
using WeatherForecastApi.Service;
using WeatherForecastApi.Service.Interfaces;

namespace WeatherForecastApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddLogging(
                builder=> {
                    builder.AddFilter("Microsoft", LogLevel.Warning)
                        .AddFilter("System", LogLevel.Warning)
                        .AddFilter("NToastNotify", LogLevel.Warning)
                        .AddConsole();
                    });
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication",null);
            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1",new OpenApiInfo {Title="EPAMWeekOneAPI",Version="v1" });
                //c.AddSecurityDefinition("basic", new BasicAuthScheme { Type = "basic" });
                //c.DocumentFilter<BasicAuthFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            loggerFactory.AddLog4Net();
            app.UseStaticFilesMiddleWare();
            app.UseDefaultFiles();
            app.FolderProtection(new ProtectFolderOptions
            {
                Path = "/Secret",
                PolicyName = "Authenticated"
            });
            app.UseStaticFiles();

            app.UseSession();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images")),
                RequestPath = "/MyImages"

            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                RequestPath = "/MyImages"
            });
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EPAM WEEK One API");
                c.RoutePrefix = string.Empty;
            });
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
