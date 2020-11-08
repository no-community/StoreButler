using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using No.StoreButler.LedgerManagement.LedgerManagement.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    /// <summary>
    /// 支付交易服务
    /// </summary>
    public class PayTradeAppService : LedgerManagementAppService, IPayTradeAppService
    {
        private readonly IPayTradeRepository _payTradeRepo;

        public PayTradeAppService(IPayTradeRepository payTradeRepo)
        {
            _payTradeRepo = payTradeRepo;
        }

        /// <summary>
        /// 创建交易
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public async Task<PayTradeDto> CreateAsync(CreatePayTradeInput input)
        {
            var payTransaction = ObjectMapper.Map<CreatePayTradeInput, PayTrade>(input);

            await _payTradeRepo.InsertAsync(payTransaction, true);
            return ObjectMapper.Map<PayTrade, PayTradeDto>(payTransaction);
        }

        /// <summary>
        /// 更新交易
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public async Task<PayTradeDto> UpdateAsync(Guid id, UpdatePayTradeInput input)
        {
            var payTransaction = await _payTradeRepo.GetAsync(r => r.Id == id);
            ObjectMapper.Map(input, payTransaction);

            await _payTradeRepo.UpdateAsync(payTransaction, true);
            return ObjectMapper.Map<PayTrade, PayTradeDto>(payTransaction);
        }

        /// <summary>
        /// 删除交易
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var payTransaction = await _payTradeRepo.GetAsync(r => r.Id == id);
            await _payTradeRepo.DeleteAsync(payTransaction, true);
        }

        /// <summary>
        /// 获取交易
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PayTradeDto> GetAsync(Guid id)
        {
            var payTransaction = await _payTradeRepo.GetAsync(id);

            return ObjectMapper.Map<PayTrade, PayTradeDto>(payTransaction);
        }

        /// <summary>
        /// 获取交易
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<PayTradeDto>> GetAsync(GetPayTradeInput input)
        {
            var tradeCategories =
                await _payTradeRepo.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
            var totalCount = await _payTradeRepo.GetCountAsync();

            var payTransactionDtos = ObjectMapper.Map<List<PayTrade>, List<PayTradeDto>>(tradeCategories);
            return new PagedResultDto<PayTradeDto>(totalCount, payTransactionDtos);
        }
    }
}