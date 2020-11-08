using No.StoreButler.LedgerManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace No.StoreButler.LedgerManagement.Permissions
{
    public class LedgerManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(LedgerManagementPermissions.GroupName, L("Permission:LedgerManagement"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LedgerManagementResource>(name);
        }
    }
}