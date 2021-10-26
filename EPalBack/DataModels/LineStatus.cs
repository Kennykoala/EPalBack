using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class LineStatus
    {
        public LineStatus()
        {
            Members = new HashSet<Member>();
        }

        public int LineStatusId { get; set; }
        public string LineStatusName { get; set; }
        public string LineStatusImg { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
