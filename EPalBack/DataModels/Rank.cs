using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class Rank
    {
        public Rank()
        {
            Products = new HashSet<Product>();
        }

        public int RankId { get; set; }
        public string RankName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
