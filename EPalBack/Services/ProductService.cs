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
        private readonly Repository<Product> _repository;

        public ProductService(Repository<Product> repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProductViewModel>GetAllProduct()
        {
            return _repository.GetAll().Select(x => new ProductViewModel()
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                MemberName = x.Creator.MemberName,
                //MemberId = x.Creator.MemberId,
                GameName = x.GameCategory.GameName,

            }).ToList();
        }

        public IEnumerable<ProductDetailsViewModel>GetProductDetails(int id)
        {
            var porduct = _repository.GetAll().Where(p => p.ProductId == id);

            return porduct.Select(x => new ProductDetailsViewModel()
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
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

        public void DeleteProduct(ProductViewModel requst)
        {
            var target = _repository.GetAll().FirstOrDefault(x => x.ProductId == requst.ProductId);

            _repository.Delete(target);

            _repository.SaveChanges();
        }

        public void UpdateProduct(ProductViewModel request)
        {
            var target = _repository.GetAll().FirstOrDefault(x => x.ProductId == request.ProductId);

            _repository.Update(target);

            _repository.SaveChanges();
        }

        
    }
}
