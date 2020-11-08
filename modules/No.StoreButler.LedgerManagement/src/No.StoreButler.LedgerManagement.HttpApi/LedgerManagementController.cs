using No.StoreButler.LedgerManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace No.StoreButler.LedgerManagement
{
    public abstract class LedgerManagementController : AbpController
    {
        protected LedgerManagementController()
        {
            LocalizationResource = typeof(LedgerManagementResource);
        }
    }
}
