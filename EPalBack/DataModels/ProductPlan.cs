using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class ProductPlan
    {
        public int PlanId { get; set; }
        public int ProductId { get; set; }
        public string GameAvailableDay { get; set; }
        public TimeSpan? GameStartTime { get; set; }
        public TimeSpan? GameEndTime { get; set; }

        public virtual Product Product { get; set; }
    }
}
