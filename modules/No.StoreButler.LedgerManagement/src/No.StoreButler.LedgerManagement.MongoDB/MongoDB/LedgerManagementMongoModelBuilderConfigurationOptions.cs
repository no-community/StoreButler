using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace No.StoreButler.LedgerManagement.MongoDB
{
    public class LedgerManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public LedgerManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}