using System;

namespace No.StoreButler.LedgerManagement.LedgerManagement.Dtos
{
    [Serializable]
    public class CreateTradeCategoryInput
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        
        /// <summary>
        /// 资金流动方向
        /// </summary>
        public PayFlowType PayFlowType { get; set; }
    }
}