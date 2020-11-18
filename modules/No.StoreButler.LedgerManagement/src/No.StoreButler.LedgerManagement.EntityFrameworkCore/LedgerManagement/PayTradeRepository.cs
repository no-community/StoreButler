using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using No.StoreButler.LedgerManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    public class PayTradeRepository : EfCoreRepository<ILedgerManagementDbContext, PayTrade, Guid>, IPayTradeRepository
    {
        public PayTradeRepository(IDbContextProvider<ILedgerManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override IQueryable<PayTrade> WithDetails()
        {
            return GetQueryable().Include(x => x.TradeCategory);
        }
    }
}