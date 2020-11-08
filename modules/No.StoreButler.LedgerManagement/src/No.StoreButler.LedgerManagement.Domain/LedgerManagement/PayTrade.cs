using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    /// <summary>
    /// 交易记录
    /// </summary>
    public class PayTrade : AggregateRoot<Guid>, IMultiTenant, IFullAuditedObject
    {
        /// <summary>
        /// 支付方式
        /// </summary>
        public PaymentMethod PayMethod { get; set; }

        /// <summary>
        /// 支付状态
        /// </summary>
        public TradeStatus TradeStatus { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        public long PayAmount { get; set; }

        /// <summary>
        /// 资金流动类型
        /// </summary>
        public PayFlowType PayFlowType { get; set; }
        
        /// <summary>
        /// 交易分类 Id
        /// </summary>
        public Guid TradeCategoryId { get; set; }
        
        /// <summary>
        /// 交易分类
        /// </summary>
        public TradeCategory TradeCategory { get; set; }

        public Guid? TenantId { get; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public Guid? DeleterId { get; set; }

        protected PayTrade()
        {
        }

        /// <summary>
        /// 交易创建
        /// </summary>
        public void TradeCreate()
        {
            TradeStatus = TradeStatus.WaitBuyerPay;
        }

        /// <summary>
        /// 交易关闭
        /// </summary>
        public void TradeClose()
        {
            TradeStatus = TradeStatus.Close;
        }

        /// <summary>
        /// 交易成功
        /// </summary>
        public void TradeSuccess()
        {
            TradeStatus = TradeStatus.Success;
        }

        /// <summary>
        /// 交易完成
        /// </summary>
        public void TradeFinished()
        {
            TradeStatus = TradeStatus.Finished;
        }
    }
}
