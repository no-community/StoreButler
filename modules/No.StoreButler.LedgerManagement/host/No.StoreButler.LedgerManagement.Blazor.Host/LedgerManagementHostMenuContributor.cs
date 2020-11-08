using System.Threading.Tasks;
using No.StoreButler.LedgerManagement.Localization;
using Volo.Abp.UI.Navigation;

namespace No.StoreButler.LedgerManagement.Blazor.Host
{
    public class LedgerManagementHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<LedgerManagementResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "LedgerManagement.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
