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
        /// 遊戲名稱
        /// </summary>
        public string GameCategory { get; set; }

        /// <summary>
        /// 商品伺服器
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// 單價
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 商品遊戲語言
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 商品遊戲牌位
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// 商品遊戲風格
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// 商品自介
        /// </summary>
        public string Introduction { get; set; }


    }
}
