using System;
using System.Threading.Tasks;
using No.StoreButler.LedgerManagement.LedgerManagement.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    /// <summary>
    /// 交易分类服务
    /// </summary>
    public interface ITradeCategoryAppService : IApplicationService
    {
        /// <summary>
        /// 创建交易分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TradeCategoryDto> CreateAsync(CreateTradeCategoryInput input);

        /// <summary>
        /// 更新交易分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TradeCategoryDto> UpdateAsync(Guid id, UpdateTradeCategoryInput input);
        
        /// <summary>
        /// 删除交易分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// 获取交易分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TradeCategoryDto> GetAsync(Guid id);

        /// <summary>
        /// 获取交易分类
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<TradeCategoryDto>> GetAsync(GetTradeCategoryInput input);
    }
}