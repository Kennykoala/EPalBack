using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.ViewModels;
using EPalBack.Repositories;
using EPalBack.DataModels;

namespace EPalBack.Services
{
    public class ProductService
    {
        private readonly Repository<Product> _product;
        private readonly Repository<Server> _server;
        private readonly Repository<Style> _style;
        private readonly Repository<GameCategory> _game;
        private readonly Repository<Language> _language;

        public ProductService(Repository<Product> product,Repository<Server> server, Repository<Style> style, Repository<GameCategory> game, Repository<Language> language)
        {
            _product = product;
            _server = server;
            _style = style;
            _language = language;
            _game = game;
        }

        public IEnumerable<ProductViewModel>GetAllProduct()
        {
            return _product.GetAll().Select(x => new ProductViewModel()
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                MemberName = x.Creator.MemberName,
                GameName = x.GameCategory.GameName,
                ProductImg = x.CreatorImg
            }).ToList();
        }

        public IEnumerable<ServerViewModel>GetAllServer()
        {
            var result = new ServerViewModel();
            var ServerAll = _server.GetAll().Select(s => new server 
            {
                ServerId = s.ServerId,
                ServerName = s.ServerName
            }).ToList();
            result.ServerAll = ServerAll;
            yield return result;
        }

        public IEnumerable<LanguageViewModel> GetAllLanguage()
        {
            var result = new LanguageViewModel();
            var LanguageAll = _language.GetAll().Select(L => new language
            {
                LanguageId = L.LanguageId,
                LanguageName = L.LanguageName
            }).ToList();
            result.LanguageAll = LanguageAll;
            yield return result;
        }

        public IEnumerable<GameViewModel> GetAllGame()
        {
            var result = new GameViewModel();
            var GameAll = _game.GetAll().Select(g => new game
            {
                GameId = g.GameCategoryId,
                GameName = g.GameName
            }).ToList();
            result.GameAll = GameAll;
            yield return result;
        }

        public IEnumerable<StyleViewModel> GetAllStyle()
        {
            var result = new StyleViewModel();
            var StyleAll = _style.GetAll().Select(s => new style
            {
                StyleId = s.StyleId,
                StyleName = s.StyleName
            }).ToList();
            result.StyleAll = StyleAll;
            yield return result;
        }

        public IEnumerable<ProductDetailsViewModel>GetProductDetails(int id)
        {
            var porduct = _product.GetAll().Where(p => p.ProductId == id);

            return porduct.Select(x => new ProductDetailsViewModel()
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                CreatorId = x.Creator.MemberId,
                CreatorName = x.Creator.MemberName,
                GameCategory = x.GameCategory.GameName,
                Server = x.ProductServers.FirstOrDefault(y => y.ProductId == x.ProductId) == null ? null : x.ProductServers.First(y => y.ProductId == x.ProductId).Server.ServerName,
                Level = x.Rank.RankName,
                CreatorImg = x.CreatorImg,
                Language = x.Creator.Language.LanguageName,
                Introduction = x.Introduction,
                Style = x.ProductStyles.FirstOrDefault(y => y.ProductId == x.ProductId) == null ? null:x.ProductStyles.First(y => y.ProductId == x.ProductId).Style.StyleName
            }).ToList();
        }

        public void DeleteProduct(ProductViewModel requset)
        {
            var target = _product.GetAll().FirstOrDefault(x => x.ProductId == requset.ProductId);

            _product.Delete(target);

            _product.SaveChanges();
        }

        public void UpdateProduct(ProductViewModel request)
        {
            var target = _product.GetAll().FirstOrDefault(x => x.ProductId == request.ProductId);

            _product.Update(target);

            _product.SaveChanges();
        }

        
    }
}
