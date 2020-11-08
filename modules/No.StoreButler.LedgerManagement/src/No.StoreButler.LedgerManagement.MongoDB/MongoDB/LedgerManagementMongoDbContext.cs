using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace No.StoreButler.LedgerManagement.MongoDB
{
    [ConnectionStringName(LedgerManagementDbProperties.ConnectionStringName)]
    public class LedgerManagementMongoDbContext : AbpMongoDbContext, ILedgerManagementMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureLedgerManagement();
        }
    }
}