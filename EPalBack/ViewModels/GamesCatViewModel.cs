using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class GamesCatViewModel
    {
        public List<GamesInfo> GamesList;
    }
    public class GamesInfo
    {
        public int GameCategoryId { get; set; }
        public string GameName { get; set; }
        public string GameCover { get; set; }
        public string GameCoverMini { get; set; }
        public string GameAlias { get; set; }
        public int PlayerCount { get; set; } 
    }


}
