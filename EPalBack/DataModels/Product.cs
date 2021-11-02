using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class Product
    {
        public Product()
        {
            CommentDetails = new HashSet<CommentDetail>();
            Orders = new HashSet<Order>();
            ProductPlans = new HashSet<ProductPlan>();
            ProductPositions = new HashSet<ProductPosition>();
            ProductServers = new HashSet<ProductServer>();
            ProductStyles = new HashSet<ProductStyle>();
        }

        public int ProductId { get; set; }
        public int GameCategoryId { get; set; }
        public int CreatorId { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductImg { get; set; }
        public string RecommendationVoice { get; set; }
        public string Introduction { get; set; }
        public int? RankId { get; set; }
        public string CreatorImg { get; set; }
        public bool? ProductStatus { get; set; }

        public virtual Member Creator { get; set; }
        public virtual GameCategory GameCategory { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual ICollection<CommentDetail> CommentDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductPlan> ProductPlans { get; set; }
        public virtual ICollection<ProductPosition> ProductPositions { get; set; }
        public virtual ICollection<ProductServer> ProductServers { get; set; }
        public virtual ICollection<ProductStyle> ProductStyles { get; set; }
    }
}
