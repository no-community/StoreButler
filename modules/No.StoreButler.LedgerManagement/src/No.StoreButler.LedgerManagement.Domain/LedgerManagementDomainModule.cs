using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace No.StoreButler.LedgerManagement
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(LedgerManagementDomainSharedModule)
    )]
    public class LedgerManagementDomainModule : AbpModule
    {

    }
}
