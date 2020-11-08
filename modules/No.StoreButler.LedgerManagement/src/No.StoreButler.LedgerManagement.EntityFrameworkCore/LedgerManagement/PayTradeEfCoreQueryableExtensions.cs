using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    public static class PayTradeEfCoreQueryableExtensions
    {
        public static IQueryable<PayTrade> IncludeDetails(this IQueryable<PayTrade> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}