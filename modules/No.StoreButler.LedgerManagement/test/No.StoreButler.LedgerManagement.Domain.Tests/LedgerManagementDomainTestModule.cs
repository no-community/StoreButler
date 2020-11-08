using No.StoreButler.LedgerManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace No.StoreButler.LedgerManagement
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(LedgerManagementEntityFrameworkCoreTestModule)
        )]
    public class LedgerManagementDomainTestModule : AbpModule
    {
        
    }
}
