using System;

namespace No.StoreButler.LedgerManagement.LedgerManagement.Dtos
{
    [Serializable]
    public class CreatePayTradeInput
    {
        /// <summary>
        /// 支付方式：0=现金 1=支付宝 2=微信
        /// </summary>
        public PaymentMethod PayMethod { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public long PayAmount { get; set; }

        /// <summary>
        /// 资金流向
        /// </summary>
        public PayFlowType PayFlowType { get; set; }
        
        /// <summary>
        /// 分类 Id
        /// </summary>
        public Guid TradeCategoryId { get; set; }
    }
}