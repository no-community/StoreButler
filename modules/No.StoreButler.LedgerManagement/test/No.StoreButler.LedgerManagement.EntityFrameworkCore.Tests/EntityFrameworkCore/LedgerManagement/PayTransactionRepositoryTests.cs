using System;
using System.Threading.Tasks;
using No.StoreButler.LedgerManagement.LedgerManagement;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace No.StoreButler.LedgerManagement.EntityFrameworkCore.LedgerManagement
{
    public class PayTransactionRepositoryTests : LedgerManagementEntityFrameworkCoreTestBase
    {
        private readonly IPayTradeRepository _payTradeRepository;

        public PayTransactionRepositoryTests()
        {
            _payTradeRepository = GetRequiredService<IPayTradeRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
