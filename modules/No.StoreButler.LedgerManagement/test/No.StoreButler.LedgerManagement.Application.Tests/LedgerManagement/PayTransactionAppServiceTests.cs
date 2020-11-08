using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    public class PayTransactionAppServiceTests : LedgerManagementApplicationTestBase
    {
        private readonly IPayTradeAppService _payTradeAppService;

        public PayTransactionAppServiceTests()
        {
            _payTradeAppService = GetRequiredService<IPayTradeAppService>();
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
