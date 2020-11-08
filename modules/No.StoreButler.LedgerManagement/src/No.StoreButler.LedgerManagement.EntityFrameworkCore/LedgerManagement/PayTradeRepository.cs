using System;
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
    }
}