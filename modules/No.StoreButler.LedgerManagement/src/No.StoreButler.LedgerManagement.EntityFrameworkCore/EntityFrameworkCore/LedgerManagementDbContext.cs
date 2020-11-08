using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using No.StoreButler.LedgerManagement.LedgerManagement;

namespace No.StoreButler.LedgerManagement.EntityFrameworkCore
{
    [ConnectionStringName(LedgerManagementDbProperties.ConnectionStringName)]
    public class LedgerManagementDbContext : AbpDbContext<LedgerManagementDbContext>, ILedgerManagementDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<PayTrade> PayTransactions { get; set; }
        public DbSet<TradeCategory> TradeCategories { get; set; }

        public LedgerManagementDbContext(DbContextOptions<LedgerManagementDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureLedgerManagement();
        }
    }
}
