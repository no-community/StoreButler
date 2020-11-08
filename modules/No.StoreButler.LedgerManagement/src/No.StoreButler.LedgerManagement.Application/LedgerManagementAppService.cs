using No.StoreButler.LedgerManagement.Localization;
using Volo.Abp.Application.Services;

namespace No.StoreButler.LedgerManagement
{
    public abstract class LedgerManagementAppService : ApplicationService
    {
        protected LedgerManagementAppService()
        {
            LocalizationResource = typeof(LedgerManagementResource);
            ObjectMapperContext = typeof(LedgerManagementApplicationModule);
        }
    }
}
