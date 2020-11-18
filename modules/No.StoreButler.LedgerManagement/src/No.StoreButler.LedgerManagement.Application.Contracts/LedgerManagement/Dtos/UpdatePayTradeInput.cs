using System;

namespace No.StoreButler.LedgerManagement.LedgerManagement.DTOs
{
    [Serializable]
    public class UpdatePayTradeInput
    {
        /// <summary>
        /// 支付方式
        /// </summary>
        public PaymentMethod PayMethod { get; set; }
        
        /// <summary>
        /// 交易状态
        /// </summary>
        public TradeStatus TradeStatus { get; set; }
        
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal PayAmount { get; set; }
        
        /// <summary>
        /// 资金流向
        /// </summary>
        public PayFlowType PayFlowType { get; set; }
        
        /// <summary>
        /// 分类 Id
        /// </summary>
        public Guid TradeCategoryId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}