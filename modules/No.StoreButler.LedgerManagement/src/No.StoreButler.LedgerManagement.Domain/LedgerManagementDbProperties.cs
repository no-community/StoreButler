namespace No.StoreButler.LedgerManagement
{
    public static class LedgerManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "LedgerManagement";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "LedgerManagement";
    }
}
