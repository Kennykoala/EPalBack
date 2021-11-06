using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class OrderStatusViewModel
    {

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public DateTime DesiredStartTime { get; set; }
    }
}
