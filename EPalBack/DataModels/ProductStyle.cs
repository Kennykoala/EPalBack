using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class ProductStyle
    {
        public int ProductStyleId { get; set; }
        public int ProductId { get; set; }
        public int StyleId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Style Style { get; set; }
    }
}
