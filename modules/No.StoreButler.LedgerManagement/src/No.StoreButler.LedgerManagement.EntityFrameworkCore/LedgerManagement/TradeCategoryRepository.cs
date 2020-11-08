using System;
using No.StoreButler.LedgerManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    public class TradeCategoryRepository : EfCoreRepository<ILedgerManagementDbContext, TradeCategory, Guid>, ITradeCategoryRepository
    {
        public TradeCategoryRepository(IDbContextProvider<ILedgerManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}