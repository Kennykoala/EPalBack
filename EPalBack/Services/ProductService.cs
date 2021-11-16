using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.ViewModels;
using EPalBack.Repositories;
using EPalBack.DataModels;
using EPalBack.Services.Interface;
using EPalBack.Helpers;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Distributed;
using System.Reflection;
using System.Diagnostics;

namespace EPalBack.Services
{
    public class ProductService : IProductService
    {
        private readonly Repository<Order> _order;
        private readonly Repository<Product> _product;
        private readonly Repository<Server> _server;
        private readonly Repository<Style> _style;
        private readonly Repository<GameCategory> _game;
        private readonly Repository<Language> _language;
        private readonly Repository<Member> _member;
        private readonly Repository<ProductServer> _productserver;
        private readonly Repository<ProductStyle> _productstyle;
        //private readonly IProductRepository _iProductRepository;
        private readonly IDistributedCache _redisCache;

        public ProductService(
            Repository<Product> product, 
            Repository<Order> order, 
            /*IProductRepository iProductRepository,*/ 
            Repository<Server> server, 
            Repository<Style> style, 
            Repository<GameCategory> game, 
            Repository<Language> language,
            Repository<Member>member,
            Repository<ProductServer> productserver,
            Repository<ProductStyle>productstyle, 
            IDistributedCache cache)
        {
            _order = order;
            _product = product;
            _server = server;
            _style = style;
            _language = language;
            _game = game;
            _member = member;
            _productserver = productserver;
            _productstyle = productstyle;
            _redisCache = cache;
            //_iProductRepository = iProductRepository;
        }
        //public ProductViewModel GetMostPopular(int topMax)
        //{
        //    var result = new ProductViewModel();
        //    var productpopular = _product.GetAll<Product>();

        //}

        public IEnumerable<ProductViewModel> GetMostPopular(int topMax)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // RedisKey 由參數組合產生，降低資料庫讀取次數。
            var redisKey = $"{MethodBase.GetCurrentMethod().Name}_{topMax}";  
            var result = _redisCache.GetString(redisKey);
            if (!string.IsNullOrEmpty(result))
            {
                stopWatch.Stop();
                TimeSpan tse = stopWatch.Elapsed;
                // Format and display the TimeSpan value.
                string elapsedTimes = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    tse.Hours, tse.Minutes, tse.Seconds,
                    tse.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTimes);
                return JsonConvert.DeserializeObject<IEnumerable<ProductViewModel>>(result);
            }
            var order = _order.GetAll()
                              .GroupBy(x => x.ProductId)
                              .Select(x => new ProductViewModel()
                              {
                                  ProductId = x.Key,
                                  ProductQty = x.Sum(x => x.Quantity),
                                  
                              })
                              .OrderByDescending(x => x.ProductQty)
                              .Take(topMax)
                              .ToList();
            order.ForEach(orderItem =>
            {
                //first一定要找到
                var productItem = _product.GetAll().First(x => x.ProductId == orderItem.ProductId);
                var memberItem = _member.GetAll().First(x=>x.MemberId ==productItem.CreatorId);
              //  var gameItem = _game.Get(productItem.GameCategoryId);
                //var memberItem=_member.GetAll().Where(x=>x.MemberId==productItem.CreatorId);

                orderItem.UnitPrice = productItem.UnitPrice;
                orderItem.MemberName = memberItem.MemberName;
              //  orderItem.GameName = gameItem.GameName;
                orderItem.ProductImg = productItem.CreatorImg;
            });

            //現在有沒有陪完 瞬間巨量搓資料庫
            var options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1));
            _redisCache.SetString(redisKey, JsonConvert.SerializeObject(order), options);

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            return order;
         
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
                CreatorImg = x.CreatorImg,
                Introduction = x.Introduction,
                StyleId = x.ProductStyles.FirstOrDefault(s => s.ProductId == x.ProductId).StyleId,
                LanguageId = (int)x.Creator.LanguageId,
                GameCategoryId = x.GameCategoryId,
                ServerId = x.ProductServers.FirstOrDefault(y => y.ProductId == x.ProductId).ServerId
            }).ToList();
        }

        public void DeleteProduct(ProductDetailsViewModel requset)
        {
            var target = _product.GetAll().FirstOrDefault(x => x.ProductId == requset.ProductId);

            _product.Delete(target);

            _product.SaveChanges();
        }

        public void UpdateProduct(ProductDetailsViewModel request)
        {
            var product = _product.GetAll().FirstOrDefault(x => x.ProductId == request.ProductId);
            var member = _member.GetAll().FirstOrDefault(x => x.MemberId == request.CreatorId);
            var game = _game.GetAll().FirstOrDefault(x => x.GameCategoryId == request.GameCategoryId);
            var language = _language.GetAll().FirstOrDefault(x => x.LanguageId == request.LanguageId);
            var productserver = _productserver.GetAll().FirstOrDefault(x => x.ProductId == request.ProductId);
            var prodcutstyle = _productstyle.GetAll().FirstOrDefault(x => x.ProductId == request.ProductId);

            prodcutstyle.StyleId = request.StyleId;
            productserver.ServerId = request.ServerId;
            member.LanguageId = request.LanguageId;
            member.MemberName = request.CreatorName;
            product.Introduction = request.Introduction;
            product.UnitPrice = request.UnitPrice;
            product.GameCategoryId = request.GameCategoryId;

            _product.Update(product);
            _member.Update(member);
            _productserver.Update(productserver);
            _productstyle.Update(prodcutstyle);

            _member.SaveChanges();
            _productserver.SaveChanges();
            _productstyle.SaveChanges();
            _product.SaveChanges();
        }

        public void UpdateProductSalesStatus(ProductStatusViewModel request)
        {
            var product = _product.GetAll().FirstOrDefault(x => x.ProductId == request.ProductId);

            product.ProductStatus = request.SaleStatus;

            _product.Update(product);

            _product.SaveChanges();
        }

        public IEnumerable<ProductViewModel> GetProductByOnSale()
        {
            return _product.GetAll().Where(x=>x.ProductStatus == true).Select(x => new ProductViewModel()
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                MemberName = x.Creator.MemberName,
                GameName = x.GameCategory.GameName,
                ProductImg = x.CreatorImg
            }).ToList();
        }

        public IEnumerable<ProductViewModel> GetProductByNonSale()
        {
            return _product.GetAll().Where(x => x.ProductStatus == false).Select(x => new ProductViewModel()
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                MemberName = x.Creator.MemberName,
                GameName = x.GameCategory.GameName,
                ProductImg = x.CreatorImg
            }).ToList();
        }

        public List<ProductViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> GetRecommend(int topMax)
        {
            throw new NotImplementedException();
        }
    }
}
