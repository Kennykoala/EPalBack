using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public string MemberName { get; set; }

        public string GameName { get; set; }

        public decimal UnitPrice { get; set; }

        public string ProductImg { get; set; }

    }
}
