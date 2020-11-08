using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    public class TradeCategoryAppServiceTests : LedgerManagementApplicationTestBase
    {
        private readonly ITradeCategoryAppService _tradeCategoryAppService;

        public TradeCategoryAppServiceTests()
        {
            _tradeCategoryAppService = GetRequiredService<ITradeCategoryAppService>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
        */
    }
}
