using System;
using System.Threading.Tasks;
using No.StoreButler.LedgerManagement.LedgerManagement.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    /// <summary>
    /// 支付交易服务
    /// </summary>
    public interface IPayTradeAppService : IApplicationService
    {
        /// <summary>
        /// 创建交易
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PayTradeDto> CreateAsync(CreatePayTradeInput input);

        /// <summary>
        /// 更新交易
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PayTradeDto> UpdateAsync(Guid id, UpdatePayTradeInput input);

        /// <summary>
        /// 删除交易
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// 获取交易
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PayTradeDto> GetAsync(Guid id);

        /// <summary>
        /// 获取交易
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<PayTradeDto>> GetAsync(GetPayTradeInput input);
    }
}