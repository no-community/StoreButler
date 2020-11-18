using System;
using Volo.Abp.Application.Dtos;

namespace No.StoreButler.LedgerManagement.LedgerManagement.DTOs
{
    [Serializable]
    public class TradeCategoryDto : EntityDto<Guid>
    {
        /// <summary>
        /// 分类 ID
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        
        /// <summary>
        /// 资金流向
        /// </summary>
        public PayFlowType PayFlowType { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        
        /// <summary>
        /// 最近更新时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
    }
}