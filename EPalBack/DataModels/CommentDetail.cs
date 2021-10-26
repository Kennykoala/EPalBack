using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class CommentDetail
    {
        public CommentDetail()
        {
            Comments = new HashSet<Comment>();
        }

        public int CommentDetailId { get; set; }
        public int ProductId { get; set; }
        public int MemberId { get; set; }
        public DateTime CommentDate { get; set; }
        public int StarLevel { get; set; }
        public string RecommendContent { get; set; }
        public DateTime CommentUpdateDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
