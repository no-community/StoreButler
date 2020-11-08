using System;

namespace No.StoreButler.LedgerManagement.LedgerManagement.Dtos
{
    [Serializable]
    public class UpdateTradeCategoryInput
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}