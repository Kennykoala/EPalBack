using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class DashBoardViewModel
    {
        /// <summary>
        /// 商品總數
        /// </summary>
        public int ProductTotal { get; set; }
        /// <summary>
        /// 會員總數
        /// </summary>
        public int MemberTotal { get; set; }
        /// <summary>
        /// 訂單總數
        /// </summary>
        public int OrderTotal { get; set; }
        /// <summary>
        /// 評論總數
        /// </summary>
        public int CommentTotal { get; set; }
        /// <summary>
        /// 月營收
        /// </summary>
        public decimal EarningsMonthTotal { get; set; }
        /// <summary>
        /// 年營收
        /// </summary>
        public decimal EarningsYearTotal { get; set; }
        /// <summary>
        /// 月訂單
        /// </summary>
        public int OrderMonthTotal { get; set; }
        /// <summary>
        /// 年訂單
        /// </summary>
        public int OrderYearTotal { get; set; }

        public decimal orderJanuarytotal { get; set; }
        public decimal orderFebruarytotal { get; set; }
        public decimal orderMarchtotal { get; set; }
        public decimal orderApriltotal { get; set; }
        public decimal orderMaytotal { get; set; }


        public decimal orderJunetotal { get; set; }

        public decimal orderJulytotal { get; set; }

        public decimal orderAugusttotal { get; set; }
        public decimal orderSeptembertotal { get; set; }
        public decimal orderOctoberrtotal { get; set; }
        public decimal orderNovembertotal { get; set; }
        public decimal orderDecembertotal { get; set; }

        public int orderstatusid { get; set; }

    }
}
