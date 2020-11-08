using System;
using System.Threading.Tasks;
using No.StoreButler.LedgerManagement.LedgerManagement;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace No.StoreButler.LedgerManagement.EntityFrameworkCore.LedgerManagement
{
    public class TradeCategoryRepositoryTests : LedgerManagementEntityFrameworkCoreTestBase
    {
        private readonly ITradeCategoryRepository _tradeCategoryRepository;

        public TradeCategoryRepositoryTests()
        {
            _tradeCategoryRepository = GetRequiredService<ITradeCategoryRepository>();
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
