using System;
using Volo.Abp.Domain.Repositories;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    public interface IPayTradeRepository : IRepository<PayTrade, Guid>
    {
    }
}