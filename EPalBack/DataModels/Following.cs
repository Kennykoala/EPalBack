using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class Following
    {
        public int FollowId { get; set; }
        public int MemberId { get; set; }
        public int FollowingId { get; set; }

        public virtual Member FollowingNavigation { get; set; }
        public virtual Member Member { get; set; }
    }
}
