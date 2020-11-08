using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using No.StoreButler.LedgerManagement.LedgerManagement;

namespace No.StoreButler.LedgerManagement.EntityFrameworkCore
{
    [ConnectionStringName(LedgerManagementDbProperties.ConnectionStringName)]
    public interface ILedgerManagementDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<PayTrade> PayTransactions { get; set; }
        DbSet<TradeCategory> TradeCategories { get; set; }
    }
}
