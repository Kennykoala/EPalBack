using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            OrderOrderStatusIdCreatorNavigations = new HashSet<Order>();
            OrderOrderStatuses = new HashSet<Order>();
        }

        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }

        public virtual ICollection<Order> OrderOrderStatusIdCreatorNavigations { get; set; }
        public virtual ICollection<Order> OrderOrderStatuses { get; set; }
    }
}
