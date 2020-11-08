using System;
using Volo.Abp.Application.Dtos;

namespace No.StoreButler.LedgerManagement.LedgerManagement.Dtos
{
    [Serializable]
    public class PayTradeDto : EntityDto<Guid>
    {
        /// <summary>
        /// 支付交易 Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 支付方式：0=现金 1=支付宝 2=微信
        /// </summary>
        public PaymentMethod PayMethod { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal PayAmount { get; set; }

        /// <summary>
        /// 资金流向
        /// </summary>
        public PayFlowType PayFlowType { get; set; }

        /// <summary>
        /// 交易状态： 0=等待顾客付款 1=未付款交易超时关闭，或支付完成后全额退款 2=交易支付成功，可退款 3=交易结束，不可退款
        /// </summary>
        public TradeStatus TradeStatus { get; set; }
    }
}