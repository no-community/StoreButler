using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace No.StoreButler.LedgerManagement.EntityFrameworkCore
{
    public class LedgerManagementHttpApiHostMigrationsDbContext : AbpDbContext<LedgerManagementHttpApiHostMigrationsDbContext>
    {
        public LedgerManagementHttpApiHostMigrationsDbContext(DbContextOptions<LedgerManagementHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureLedgerManagement();
            modelBuilder.ConfigureAuditLogging();
            modelBuilder.ConfigurePermissionManagement();
            modelBuilder.ConfigureSettingManagement();
        }
    }
}
