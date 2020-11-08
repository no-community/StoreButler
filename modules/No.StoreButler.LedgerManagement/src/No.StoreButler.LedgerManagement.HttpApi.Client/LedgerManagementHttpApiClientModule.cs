using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace No.StoreButler.LedgerManagement
{
    [DependsOn(
        typeof(LedgerManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class LedgerManagementHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "LedgerManagement";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(LedgerManagementApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
