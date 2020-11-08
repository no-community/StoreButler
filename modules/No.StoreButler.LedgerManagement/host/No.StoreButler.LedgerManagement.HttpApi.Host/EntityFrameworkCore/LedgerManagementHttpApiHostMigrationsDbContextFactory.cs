using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace No.StoreButler.LedgerManagement.EntityFrameworkCore
{
    public class LedgerManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<LedgerManagementHttpApiHostMigrationsDbContext>
    {
        public LedgerManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<LedgerManagementHttpApiHostMigrationsDbContext>()
                .UseNpgsql(configuration.GetConnectionString("LedgerManagement"));

            return new LedgerManagementHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
