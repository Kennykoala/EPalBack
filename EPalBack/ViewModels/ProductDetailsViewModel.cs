using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class ProductDetailsViewModel
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品人姓名
        /// </summary>
        public string CreatorName { get; set; }

        /// <summary>
        /// 會員Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// 商品人照片
        /// </summary>
        public string CreatorImg { get; set; }

        /// <summary>
        /// 單價
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 商品自介
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// 遊戲ID
        /// </summary>
        public int GameCategoryId { get; set; }

        /// <summary>
        /// 伺服器ID
        /// </summary>
        public int ServerId { get; set; }

        /// <summary>
        /// 風格ID
        /// </summary>
        public int StyleId { get; set; }

        /// <summary>
        /// 語言ID
        /// </summary>
        public int LanguageId { get; set; }

    }
}
