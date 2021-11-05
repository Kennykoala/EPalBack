using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class ProductStatusViewModel
    {
        public int ProductId { get; set; }
        /// <summary>
        /// 商品上下架狀態
        /// </summary>
        public bool ProductStatus { get; set; }
    }
}
