using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class DashBoardViewModel
    {
        public int ProductTotal { get; set; }

        public int MemberTotal { get; set; }

        public int OrderTotal { get; set; }

        public int CommentTotal { get; set; }

        public decimal EarningsMonthTotal { get; set; }

        public decimal EarningsYearTotal { get; set; }

        public int OrderMonthTotal { get; set; }

        public int OrderYearTotal { get; set; }

    }
}
