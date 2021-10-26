using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class RecentVistor
    {
        public int VistorId { get; set; }
        public int MemberId { get; set; }
        public int RecentVistorId { get; set; }

        public virtual Member Member { get; set; }
        public virtual Member RecentVistorNavigation { get; set; }
    }
}
