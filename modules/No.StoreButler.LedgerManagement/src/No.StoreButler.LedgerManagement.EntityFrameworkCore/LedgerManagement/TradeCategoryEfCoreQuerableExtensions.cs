using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    public static class TradeCategoryEfCoreQueryableExtensions
    {
        public static IQueryable<TradeCategory> IncludeDetails(this IQueryable<TradeCategory> queryable, bool include = true)
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