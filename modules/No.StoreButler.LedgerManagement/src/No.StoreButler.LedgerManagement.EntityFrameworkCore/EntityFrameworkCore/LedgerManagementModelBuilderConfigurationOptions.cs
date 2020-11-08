using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace No.StoreButler.LedgerManagement.EntityFrameworkCore
{
    public class LedgerManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public LedgerManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}