namespace CmsCommerce;

public class Program
{
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);
        builder.ConfigureCmsDefaults();
        builder.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        return builder;
    }

    // This is the same as the above method, but with a different syntax.
    public static IHostBuilder CreateHostBuilder2(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureCmsDefaults()
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}