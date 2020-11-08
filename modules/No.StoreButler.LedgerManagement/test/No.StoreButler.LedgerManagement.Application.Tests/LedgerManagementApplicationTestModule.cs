using Volo.Abp.Modularity;

namespace No.StoreButler.LedgerManagement
{
    [DependsOn(
        typeof(LedgerManagementApplicationModule),
        typeof(LedgerManagementDomainTestModule)
        )]
    public class LedgerManagementApplicationTestModule : AbpModule
    {

    }
}
