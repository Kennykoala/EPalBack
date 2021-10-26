using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class SatisfyTag
    {
        public SatisfyTag()
        {
            Comments = new HashSet<Comment>();
        }

        public int SatisfyTagId { get; set; }
        public string SatisfyTagName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
