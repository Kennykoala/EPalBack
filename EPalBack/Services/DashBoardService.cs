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
        private readonly Repository<Product> _product;
        private readonly Repository<Member> _member;
        private readonly Repository<Order> _order;
        private readonly Repository<CommentDetail> _comment;

        public DashBoardService(Repository<Product> repository,Repository<Member> repository1,Repository<Order> repository2,Repository<CommentDetail> repository3)
        {
            _product = repository;
            _member = repository1;
            _order = repository2;
            _comment = repository3;
        }

        public IEnumerable<DashBoardViewModel>GetAllCount()
        {
            var result = new DashBoardViewModel();

            //取得這個月的第一天
            var FirstDayofMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            //取得今年的第一天
            var FirstDatofYear = new DateTime(DateTime.Now.Year, 1, 1);
            //取得今天
            var Today = DateTime.Now;

            result.OrderMonthTotal = _order.GetAll().Where(x => x.OrderDate >= FirstDayofMonth && x.OrderDate <= Today).Count() ;
            result.OrderYearTotal = _order.GetAll().Where(x => x.OrderDate >= FirstDatofYear && x.OrderDate <= Today).Count();
            result.EarningsMonthTotal = _order.GetAll().Where(x => x.OrderDate >= FirstDayofMonth && x.OrderDate <= Today).Select(x => x.Quantity * x.UnitPrice).Sum();
            result.EarningsYearTotal= _order.GetAll().Where(x => x.OrderDate >= FirstDatofYear && x.OrderDate <= Today).Select(x => x.Quantity * x.UnitPrice).Sum();
            result.ProductTotal = _product.GetAll().Count();
            result.MemberTotal = _member.GetAll().Count();
            result.OrderTotal = _order.GetAll().Count();
            result.CommentTotal = _comment.GetAll().Count();
            

            yield return result;
        }
    }
}
