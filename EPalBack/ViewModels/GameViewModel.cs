using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class GameViewModel
    {
        public List<game> GameAll { get; set; }
    }

    public class game
    {
        public int GameId { get; set; }

        public string GameName{ get; set; }
    }
}
