using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class ProductServer
    {
        public int ProductServerId { get; set; }
        public int ProductId { get; set; }
        public int ServerId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Server Server { get; set; }
    }
}
