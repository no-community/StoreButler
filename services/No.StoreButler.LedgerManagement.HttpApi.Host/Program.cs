using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace No.StoreButler.LedgerManagement
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                     .ConfigureWebHostDefaults(configure: webBuilder => { webBuilder.UseStartup<Startup>(); })
                     .UseAutofac();

        // .UseSerilog(configureLogger: (hostingContext, loggerConfiguration) => loggerConfiguration
        //                 .ReadFrom.Configuration(hostingContext.Configuration));
    }
}
