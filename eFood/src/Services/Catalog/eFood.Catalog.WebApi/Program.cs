using System.Reflection;
using eFood.Catalog.WebApi.DAL;
using eFood.Common.Migrator;
using eFood.Common.Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace eFood.Catalog.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                .MigrateToLatestVersion<CatalogDbContext>((context, provider) =>
                {
                    //  seed data method here
                }).Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseLogging(Assembly.GetExecutingAssembly())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}