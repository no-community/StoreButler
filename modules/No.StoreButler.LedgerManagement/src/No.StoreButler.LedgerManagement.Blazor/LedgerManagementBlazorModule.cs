using Microsoft.Extensions.DependencyInjection;
using No.StoreButler.LedgerManagement.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace No.StoreButler.LedgerManagement.Blazor
{
    [DependsOn(
        typeof(LedgerManagementHttpApiClientModule),
        typeof(AbpAutoMapperModule)
        )]
    public class LedgerManagementBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<LedgerManagementBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<LedgerManagementBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new LedgerManagementMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(LedgerManagementBlazorModule).Assembly);
            });
        }
    }
}