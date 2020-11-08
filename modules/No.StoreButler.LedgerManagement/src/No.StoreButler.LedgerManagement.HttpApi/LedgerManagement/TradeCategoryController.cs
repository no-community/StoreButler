using System;
using No.StoreButler.LedgerManagement.LedgerManagement.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    /// <summary>
    /// 交易分类管理
    /// </summary>
    [RemoteService(Name = "LedgerManagementTradeCategory")]
    [Route("/api/ledger/trade-category")]
    public class TradeCategoryController : LedgerManagementController, ITradeCategoryAppService
    {
        private readonly ITradeCategoryAppService _service;

        public TradeCategoryController(ITradeCategoryAppService service)
        {
            _service = service;
        }

        /// <summary>
        /// 创建交易分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual Task<TradeCategoryDto> CreateAsync(CreateTradeCategoryInput input)
        {
            return _service.CreateAsync(input);
        }
        
        /// <summary>
        /// 更新交易分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public virtual Task<TradeCategoryDto> UpdateAsync(Guid id, UpdateTradeCategoryInput input)
        {
            return _service.UpdateAsync(id, input);
        }
        
        /// <summary>
        /// 删除交易分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
        
        /// <summary>
        /// 获取交易分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public virtual Task<TradeCategoryDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }
        
        /// <summary>
        /// 获取交易分类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual Task<PagedResultDto<TradeCategoryDto>> GetAsync(GetTradeCategoryInput input)
        {
            return _service.GetAsync(input);
        }
    }
}