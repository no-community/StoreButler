using Localization.Resources.AbpUi;
using No.StoreButler.LedgerManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace No.StoreButler.LedgerManagement
{
    [DependsOn(
        typeof(LedgerManagementApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class LedgerManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(LedgerManagementHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<LedgerManagementResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
