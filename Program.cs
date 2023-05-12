using Mediachase.Commerce.Catalog;
using Serilog;

namespace CmsCommerce;

using CmsCommerce.Extensions;
using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;

// PROGRAM CLASS
// public abstract class Program
// {
//     public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();
//
//     private static IHostBuilder CreateHostBuilder(string[] args)
//     {
//         var builder = Host.CreateDefaultBuilder(args);
//         builder.ConfigureCmsDefaults();
//         builder.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
//         return builder;
//     }
// }

public abstract class Program
{
    public static void Main(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var isDevelopment = environment == Environments.Development;

        if (isDevelopment)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("App_Data/log.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        CreateHostBuilder(args, isDevelopment).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args, bool isDevelopment)
    {
        if (isDevelopment)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureCmsDefaults()
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
        else
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureCmsDefaults()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}
/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
// STARTUP CLASS
public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;

    public Startup(IWebHostEnvironment webHostingEnvironment)
    {
        _webHostingEnvironment = webHostingEnvironment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_webHostingEnvironment.IsDevelopment())
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
                Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

            services.Configure<SchedulerOptions>(options => options.Enabled = false);
        }

        // Add cors for local development
        services.AddCors(options =>
        {
            options.AddPolicy(name: "Local",
                builder =>
                {
                    builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("https://localhost")
                        .AllowCredentials();
                });
        });

        // Correlates to Caching in appsettings.json
        services.Configure<CatalogOptions>(o =>
        {
            o.Cache.UseCache = true;
            o.Cache.ContentVersionCacheExpiration = TimeSpan.FromMinutes(05);
            o.Cache.CollectionCacheExpiration = TimeSpan.FromMinutes(05);
            o.Cache.EntryCacheExpiration = TimeSpan.FromMinutes(05);
            o.Cache.NodeCacheExpiration = TimeSpan.FromMinutes(05);
        });

        services
            .AddLogging()
            .AddCmsAspNetIdentity<ApplicationUser>()
            .AddCms()
            .AddCommerce()
            .AddCmsTagHelpers()
            .AddAlloy()
            .AddAdminUserRegistration()
            .AddEmbeddedLocalization<Startup>();


        // Opti cookie security policy
        services.ConfigureApplicationCookie(c => c.Cookie.SecurePolicy = _webHostingEnvironment.IsDevelopment()
            ? Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest
            : Microsoft.AspNetCore.Http.CookieSecurePolicy.Always);


        services.AddDetection(); // Required by Wangkanai.Detection

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSerilogRequestLogging(); // Serilog
        app.UseDetection(); // Required by Wangkanai.Detection
        app.UseSession(); // Session
        app.UseHttpsRedirection(); // For security - Adds middleware for redirecting HTTP Requests to HTTPS
        app.UseHsts(); //Strict-Transport-Security header. For security
        app.UseStatusCodePagesWithReExecute("/error/{0}"); // For error pages
        app.UseCookiePolicy(); // For security
        app.UseCors("Local"); // Add cors for local development
        app.UseStaticFiles(); // For serving static files and default file names
        app.UseRouting(); // For routing requests
        app.UseAuthentication(); // For authentication - These must be in this order
        app.UseAuthorization(); // For authorization
        //app.UseEndpoints(endpoints => { endpoints.MapContent(); });
        // Endpoint config from Foundation
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name: "Default", pattern: "{controller}/{action}/{id?}");
            endpoints.MapControllers();
            endpoints.MapRazorPages();
            endpoints.MapContent();
        });
    }
}
// This is the same as the above method, but with a different syntax.
// public static IHostBuilder CreateHostBuilder2(string[] args) =>
//     Host.CreateDefaultBuilder(args)
//         .ConfigureCmsDefaults()
//         .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });