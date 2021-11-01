using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.ViewModels;
using EPalBack.Repositories;
using EPalBack.DataModels;

namespace EPalBack.Services
{
    public class DashBoardService
    {
        private readonly Repository<Product> _repository;
        private readonly Repository<Member> _repository1;
        private readonly Repository<Order> _repository2;
        private readonly Repository<CommentDetail> _repository3;

        public DashBoardService(Repository<Product> repository,Repository<Member> repository1,Repository<Order> repository2,Repository<CommentDetail> repository3)
        {
            _repository = repository;
            _repository1 = repository1;
            _repository2 = repository2;
            _repository3 = repository3;
        }

        public IEnumerable<DashBoardViewModel>GetAllCount()
        {
            var result = new DashBoardViewModel();

            result.ProductTotal = _repository.GetAll().Count();
            result.OrderTotal = _repository2.GetAll().Count();
            result.MemberTotal = _repository1.GetAll().Count();
            result.CommentTotal = _repository3.GetAll().Count();
            yield return result;
        }
    }
}
