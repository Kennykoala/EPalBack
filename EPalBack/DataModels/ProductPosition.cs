using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class ProductPosition
    {
        public int ProductPositionId { get; set; }
        public int ProductId { get; set; }
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }
        public virtual Product Product { get; set; }
    }
}
