using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CurrencyConverter.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
           .UseSerilog((hostingContext, loggerConfiguration) =>
                   loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
                   .Enrich.WithCorrelationId()
                   .Enrich.FromLogContext())
           .ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.ConfigureKestrel(serverOptions =>
               {
                   serverOptions.AllowSynchronousIO = true;
                }).UseStartup<Startup>();
           });
    }

}
