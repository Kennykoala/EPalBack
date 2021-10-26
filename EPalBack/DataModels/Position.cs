using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class Position
    {
        public Position()
        {
            ProductPositions = new HashSet<ProductPosition>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public virtual ICollection<ProductPosition> ProductPositions { get; set; }
    }
}
