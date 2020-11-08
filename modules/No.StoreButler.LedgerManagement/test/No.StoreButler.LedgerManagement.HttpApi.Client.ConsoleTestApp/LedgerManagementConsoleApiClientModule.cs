using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace No.StoreButler.LedgerManagement
{
    [DependsOn(
        typeof(LedgerManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class LedgerManagementConsoleApiClientModule : AbpModule
    {
        
    }
}
