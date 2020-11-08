using Volo.Abp.Reflection;

namespace No.StoreButler.LedgerManagement.Permissions
{
    public class LedgerManagementPermissions
    {
        public const string GroupName = "LedgerManagement";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(LedgerManagementPermissions));
        }
    }
}