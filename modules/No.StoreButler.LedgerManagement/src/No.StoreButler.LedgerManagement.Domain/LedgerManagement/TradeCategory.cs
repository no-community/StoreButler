using System;
using System.Collections.Generic;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    /// <summary>
    /// 交易类别
    /// </summary>
    public class TradeCategory : Entity<Guid>, IMultiTenant, IFullAuditedObject
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        
        /// <summary>
        /// 是否默认
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// 资金流向类型
        /// </summary>
        public PayFlowType PayFlowType { get; set; }
        
        /// <summary>
        /// 交易记录
        /// </summary>
        public List<PayTrade> PayTrades { get; set; }

        public Guid? TenantId { get; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public Guid? DeleterId { get; set; }

        protected TradeCategory()
        {
        }

        public TradeCategory(
            Guid id,
            string name,
            string remarks,
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
            Name = name;
            Remarks = remarks;
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
