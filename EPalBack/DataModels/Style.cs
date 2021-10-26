using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class Style
    {
        public Style()
        {
            ProductStyles = new HashSet<ProductStyle>();
        }

        public int StyleId { get; set; }
        public string StyleName { get; set; }

        public virtual ICollection<ProductStyle> ProductStyles { get; set; }
    }
}
