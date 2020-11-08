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

        public PayTrade(
            Guid id,
            PaymentMethod payMethod,
            TradeStatus tradeStatus,
            long payAmount,
            PayFlowType payFlowType,
            Guid? tenantId,
            DateTime creationTime,
            Guid? creatorId,
            DateTime? lastModificationTime,
            Guid? lastModifierId,
            bool isDeleted,
            DateTime? deletionTime,
            Guid? deleterId
        ) : base(id)
        {
            PayMethod = payMethod;
            TradeStatus = tradeStatus;
            PayAmount = payAmount;
            PayFlowType = payFlowType;
            TenantId = tenantId;
            CreationTime = creationTime;
            CreatorId = creatorId;
            LastModificationTime = lastModificationTime;
            LastModifierId = lastModifierId;
            IsDeleted = isDeleted;
            DeletionTime = deletionTime;
            DeleterId = deleterId;
        }
    }
}
