using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int  ProductId {get; set;}

        public decimal TotalPrice { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderStatusId { get; set; }

        public int OrderStatusIdCreator { get; set; }
    }
}
