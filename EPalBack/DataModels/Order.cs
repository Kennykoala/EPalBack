using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class Order
    {
        public Order()
        {
            Payments = new HashSet<Payment>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DesiredStartTime { get; set; }
        public DateTime? GameEndDateTime { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderConfirmation { get; set; }
        public DateTime? GameStartTime { get; set; }

        public virtual Member Customer { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
