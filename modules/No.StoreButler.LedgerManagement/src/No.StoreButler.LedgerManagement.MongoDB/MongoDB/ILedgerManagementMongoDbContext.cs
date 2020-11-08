using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace No.StoreButler.LedgerManagement.MongoDB
{
    [ConnectionStringName(LedgerManagementDbProperties.ConnectionStringName)]
    public interface ILedgerManagementMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
