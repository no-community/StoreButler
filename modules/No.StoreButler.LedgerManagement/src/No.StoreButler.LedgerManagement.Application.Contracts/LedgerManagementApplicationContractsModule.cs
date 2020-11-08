using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace No.StoreButler.LedgerManagement
{
    [DependsOn(
        typeof(LedgerManagementDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class LedgerManagementApplicationContractsModule : AbpModule
    {

    }
}
