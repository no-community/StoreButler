using System;
using No.StoreButler.LedgerManagement.LedgerManagement.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    /// <summary>
    /// 支付交易管理
    /// </summary>
    [RemoteService(Name = "LedgerManagementPayTrade")]
    [Route("/api/ledger/pay-trade")]
    public class PayTradeController : LedgerManagementController, IPayTradeAppService
    {
        private readonly IPayTradeAppService _service;

        public PayTradeController(IPayTradeAppService service)
        {
            _service = service;
        }
        
        /// <summary>
        /// 交易创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual Task<PayTradeDto> CreateAsync(CreatePayTradeInput input)
        {
            return _service.CreateAsync(input);
        }
        
        /// <summary>
        /// 修改交易内容
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public virtual Task<PayTradeDto> UpdateAsync(Guid id, UpdatePayTradeInput input)
        {
            return _service.UpdateAsync(id, input);
        }
        
        /// <summary>
        /// 删除交易
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
        /// 获取交易
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public virtual Task<PayTradeDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }
        
        /// <summary>
        /// 获取交易
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual Task<PagedResultDto<PayTradeDto>> GetAsync(GetPayTradeInput input)
        {
            return _service.GetAsync(input);
        }
    }
}