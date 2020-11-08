using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using No.StoreButler.LedgerManagement.LedgerManagement.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    /// <summary>
    /// 交易分类服务
    /// </summary>
    public class TradeCategoryAppService : LedgerManagementAppService, ITradeCategoryAppService
    {
        private readonly ITradeCategoryRepository _tradeCategoryRepo;

        public TradeCategoryAppService(ITradeCategoryRepository tradeCategoryRepo)
        {
            _tradeCategoryRepo = tradeCategoryRepo;
        }

        /// <summary>
        /// 创建交易分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public async Task<TradeCategoryDto> CreateAsync(CreateTradeCategoryInput input)
        {
            var isExist = await _tradeCategoryRepo.AnyAsync(i => i.Name == input.Name);
            if (isExist)
            {
                throw new UserFriendlyException($"'{input.Name}' 已被注册");
            }

            var tradeCategory = ObjectMapper.Map<CreateTradeCategoryInput, TradeCategory>(input);

            await _tradeCategoryRepo.InsertAsync(tradeCategory, true);
            return ObjectMapper.Map<TradeCategory, TradeCategoryDto>(tradeCategory);
        }

        /// <summary>
        /// 更新交易分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public async Task<TradeCategoryDto> UpdateAsync(Guid id, UpdateTradeCategoryInput input)
        {
            var isExist = await _tradeCategoryRepo.AnyAsync(i => i.Name == input.Name);
            if (isExist)
            {
                throw new UserFriendlyException($"'{input.Name}' 已被注册");
            }

            var tradeCategory = await _tradeCategoryRepo.GetAsync(r => r.Id == id);
            ObjectMapper.Map(input, tradeCategory);

            await _tradeCategoryRepo.UpdateAsync(tradeCategory, true);
            return ObjectMapper.Map<TradeCategory, TradeCategoryDto>(tradeCategory);
        }

        /// <summary>
        /// 删除交易分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var tradeCategory = await _tradeCategoryRepo.GetAsync(r => r.Id == id);
            await _tradeCategoryRepo.DeleteAsync(tradeCategory, true);
        }

        /// <summary>
        /// 获取交易分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TradeCategoryDto> GetAsync(Guid id)
        {
            var tradeCategory = await _tradeCategoryRepo.GetAsync(id);

            return ObjectMapper.Map<TradeCategory, TradeCategoryDto>(tradeCategory);
        }

        /// <summary>
        /// 获取交易分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<TradeCategoryDto>> GetAsync(GetTradeCategoryInput input)
        {
            var tradeCategories =
                await _tradeCategoryRepo.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
            var totalCount = await _tradeCategoryRepo.GetCountAsync();

            var tradeCategoryDTOs = ObjectMapper.Map<List<TradeCategory>, List<TradeCategoryDto>>(tradeCategories);

            return new PagedResultDto<TradeCategoryDto>(totalCount, tradeCategoryDTOs);
        }
    }
}