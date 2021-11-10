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
            //var FirstDayofMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //當月第一天
        
            var orderFebruarytotaldata = new DateTime(2021, 1, 31).AddMonths(1);
            var orderMarchtotaldata = new DateTime(2021, 2, 28).AddMonths(1).AddDays(4);
            var orderApriltotaldata = new DateTime(2021, 3, 31).AddMonths(1);
            var orderMaytotaldata = new DateTime(2021, 4, 30).AddMonths(1).AddDays(2);
            var orderJunetotaldata = new DateTime(2021, 5, 31).AddMonths(1);
            var orderJulytotaldata = new DateTime(2021, 6, 30).AddMonths(1).AddDays(2);
            var orderAugusttotaldata = new DateTime(2021, 7, 31).AddMonths(1);
            var orderSeptembertotaldata = new DateTime(2021, 8, 31).AddMonths(1);
            var orderOctoberrtotaldata = new DateTime(2021, 9, 30).AddMonths(1).AddDays(2);
            var orderNovembertotaldata = new DateTime(2021, 10, 31).AddMonths(1);
            var orderDecembertotaldata = new DateTime(2021, 11, 30).AddMonths(1).AddDays(1);
            var orderJanuarytotaldata = new DateTime(2021, 12, 31).AddMonths(1);

            ////取得今年的第一天
            //var FirstDatofYear = new DateTime(DateTime.Now.Year, 1, 1);
            ////取得今天
            //var Today = DateTime.Now;
           
            result.orderJanuarytotal = _order.GetAll().Where(x => x.OrderDate <= orderJanuarytotaldata && x.OrderDate >= orderDecembertotaldata && x.OrderStatusId==3)
                .Select(x => x.Quantity * x.UnitPrice).Sum();
            result.orderFebruarytotal = _order.GetAll().Where(x => x.OrderDate <= orderFebruarytotaldata && x.OrderStatusId == 3)
              .Select(x => x.Quantity * x.UnitPrice).Sum();
            result.orderMarchtotal = _order.GetAll().Where(x => x.OrderDate <= orderMarchtotaldata && x.OrderStatusId == 3)
              .Select(x => x.Quantity * x.UnitPrice).Sum();
            result.orderApriltotal = _order.GetAll().Where(x => x.OrderDate <= orderApriltotaldata && x.OrderStatusId == 3)
              .Select(x => x.Quantity * x.UnitPrice).Sum();
            result.orderMaytotal = _order.GetAll().Where(x => x.OrderDate <= orderMaytotaldata && x.OrderStatusId == 3)
              .Select(x => x.Quantity * x.UnitPrice).Sum();
            result.orderJunetotal = _order.GetAll().Where(x => x.OrderDate <= orderJunetotaldata && x.OrderStatusId == 3)
              .Select(x => x.Quantity * x.UnitPrice).Sum();
            result.orderJulytotal = _order.GetAll().Where(x => x.OrderDate <= orderJulytotaldata && x.OrderStatusId == 3)
              .Select(x => x.Quantity * x.UnitPrice).Sum();
            result.orderAugusttotal = _order.GetAll().Where(x => x.OrderDate <= orderAugusttotaldata && x.OrderStatusId == 3)
              .Select(x => x.Quantity * x.UnitPrice).Sum();
            result.orderSeptembertotal = _order.GetAll().Where(x => x.OrderDate <= orderSeptembertotaldata && x.OrderStatusId == 3)
              .Select(x => x.Quantity * x.UnitPrice).Sum();
            result.orderOctoberrtotal = _order.GetAll().Where(x => x.OrderDate <= orderOctoberrtotaldata && x.OrderStatusId == 3)
              .Select(x => x.Quantity * x.UnitPrice).Sum();
            result.orderNovembertotal = _order.GetAll().Where(x => x.OrderDate <= orderNovembertotaldata && x.OrderDate > orderOctoberrtotaldata && x.OrderStatusId == 3)
              .Select(x => x.Quantity * x.UnitPrice).Sum();
            result.orderDecembertotal = _order.GetAll().Where(x => x.OrderDate < orderDecembertotaldata && x.OrderDate > orderNovembertotaldata && x.OrderStatusId == 3)
              .Select(x => x.Quantity * x.UnitPrice).Sum();


            //result.OrderMonthTotal = _order.GetAll().Where(x => x.OrderDate >= FirstDayofMonth && x.OrderDate <= Today).Count() ;

          //  result.orderSeptembertotal = _order.GetAll().Where(x => x.OrderDate  <= orderSeptembertotaldata).Select(x => x.Quantity * x.UnitPrice).Sum();

            //result.OrderYearTotal = _order.GetAll().Where(x => x.OrderDate >= FirstDatofYear && x.OrderDate <= Today).Count();
            //result.EarningsMonthTotal = _order.GetAll().Where(x => x.OrderDate >= FirstDayofMonth && x.OrderDate <= Today).Select(x => x.Quantity * x.UnitPrice).Sum();
            //result.EarningsYearTotal= _order.GetAll().Where(x => x.OrderDate >= FirstDatofYear && x.OrderDate <= Today).Select(x => x.Quantity * x.UnitPrice).Sum();
            //result.ProductTotal = _product.GetAll().Count();
            //result.MemberTotal = _member.GetAll().Count();
            //result.OrderTotal = _order.GetAll().Count();
            //result.CommentTotal = _comment.GetAll().Count();
            

            yield return result;
        }
  

        public IEnumerable<MainCategoryPieViewModel> GetMainCategoryPie()
        {
            var result = new MainCategoryPieViewModel();



            yield return result;
        }
    }
}
