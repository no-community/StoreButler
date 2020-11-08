using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace No.StoreButler.LedgerManagement.MongoDB
{
    public static class LedgerManagementMongoDbContextExtensions
    {
        public static void ConfigureLedgerManagement(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new LedgerManagementMongoModelBuilderConfigurationOptions(
                LedgerManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}