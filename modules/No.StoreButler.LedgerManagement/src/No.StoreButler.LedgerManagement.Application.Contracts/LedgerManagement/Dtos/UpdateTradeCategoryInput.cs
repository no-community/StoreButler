using System;
using System.ComponentModel.DataAnnotations;

namespace No.StoreButler.LedgerManagement.LedgerManagement.DTOs
{
    [Serializable]
    public class UpdateTradeCategoryInput
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "分类名称不能为空")]
        [StringLength(25, ErrorMessage = "分类名称不能超过25个字")]
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(100, ErrorMessage = "备注不能超过100个字")]
        public string Remarks { get; set; }
    }
}