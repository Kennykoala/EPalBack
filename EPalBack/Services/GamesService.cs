using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.DataModels;
using EPalBack.Repositories;
using EPalBack.ViewModels; 

namespace EPalBack.Services
{
    public class GamesService
    {
        private readonly Repository<GameCategory> _game;
        private readonly Repository<Product> _product;
        public GamesService(Repository<GameCategory> game, Repository<Product> product)
        {
            _game = game;
            _product = product;
        }
        public IEnumerable<GamesInfo>GetGamesInfo()
        {
            //var gamez = new GamesCatViewModel();
            var gamesinfo = _game.GetAll().Select(x => new GamesInfo()
            {
                GameCategoryId = x.GameCategoryId,
                GameName = x.GameName,
                GameCover = x.GameCoverImg,
                GameCoverMini = x.GameCoverImgMini,
                GameAlias = x.GameAlias,
                PlayerCount = _product.GetAll().Where( y => y.GameCategoryId == x.GameCategoryId).Count()
            }).ToList();
            return gamesinfo;
        }

    }
}
