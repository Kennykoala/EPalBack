using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class GameCategory
    {
        public GameCategory()
        {
            Products = new HashSet<Product>();
        }

        public int GameCategoryId { get; set; }
        public string GameName { get; set; }
        public string GameCoverImg { get; set; }
        public string GameCoverImgMini { get; set; }
        public string GameAlias { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
