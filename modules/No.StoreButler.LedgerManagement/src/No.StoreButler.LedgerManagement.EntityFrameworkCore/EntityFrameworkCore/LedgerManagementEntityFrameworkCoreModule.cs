using No.StoreButler.LedgerManagement.LedgerManagement;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace No.StoreButler.LedgerManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(LedgerManagementDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class LedgerManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<LedgerManagementDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<PayTrade, PayTradeRepository>();
                options.AddRepository<TradeCategory, TradeCategoryRepository>();

                options.AddDefaultRepositories(true);
            });
        }
    }
}
