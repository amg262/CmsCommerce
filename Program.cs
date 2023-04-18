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
                .MinimumLevel.Warning()
                .WriteTo.File("App_Data/log.txt", rollingInterval: RollingInterval.Day)
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

        app.UseDetection(); // Required by Wangkanai.Detection
        app.UseSession();

        app.UseHttpsRedirection();
        app.UseHsts();
        app.UseStatusCodePagesWithReExecute("/error/{0}");

        app.UseCookiePolicy();
        app.UseCors("Local");
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

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