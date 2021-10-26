using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int CommentDetailId { get; set; }
        public int SatisfyTagId { get; set; }

        public virtual CommentDetail CommentDetail { get; set; }
        public virtual SatisfyTag SatisfyTag { get; set; }
    }
}
