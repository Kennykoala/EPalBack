using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class MeetLike
    {
        public int MeetLikeId { get; set; }
        public int MemberId { get; set; }
        public int LikeId { get; set; }

        public virtual Member Like { get; set; }
        public virtual Member Member { get; set; }
    }
}
