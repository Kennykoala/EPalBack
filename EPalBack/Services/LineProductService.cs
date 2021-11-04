using EPalBack.DataModels;
using EPalBack.Repositories;
using EPalBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.Services
{
    public class LineProductService
    {

        private readonly Repository<Product> _repository;

        public LineProductService(Repository<Product> repository)
        {
            _repository = repository;
        }

        public IEnumerable<LineProductViewModel> GetAllProduct()
        {
            return _repository.GetAll().Select(x => new LineProductViewModel()
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                MemberName = x.Creator.MemberName,
                GameName = x.GameCategory.GameName,
                Server = x.ProductServers.FirstOrDefault(y => y.ProductId == x.ProductId) == null ? null : x.ProductServers.First(y => y.ProductId == x.ProductId).Server.ServerName,
                Level = x.Rank.RankName,
                Position = x.ProductPositions.FirstOrDefault(y => y.ProductId == x.ProductId) == null ? null : x.ProductPositions.First(y => y.ProductId == x.ProductId).Position.PositionName,
                CreatorImg = x.CreatorImg,
                gender = x.Creator.Gender
                //gender = (genderenum)x.Creator.Gender
            }).ToList();
        }


    }
}
