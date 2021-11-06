using EPalBack.DataModels;
using EPalBack.Repositories;
using EPalBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.Services
{
    public class OrderService
    {
        //private readonly Repository<OrderStatus> _orderstatus;
        private readonly Repository<Member> _member;
        private readonly Repository<Order> _order;

        public OrderService(Repository<Order>order, Repository<Member> member/*, Repository<OrderStatus> orderstaus*/)
        {
            _order = order;
            _member = member;
            //_orderstatus = orderstaus;
        }
      
        public IEnumerable<OrderViewModel>GetAllOrder()
        {
           
            return _order.GetAll().Select(x => new OrderViewModel()
            {
                OrderId = x.OrderId,
                CustomerId = x.CustomerId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                OrderDate = Convert.ToDateTime(x.OrderDate).Date.ToString("D"),
                OrderStatusId = x.OrderStatusId,
                //OrderStatusIdCreator =x.OrderStatusIdCreator,
                MemberName =x.Customer.MemberName,
                OrderStatusName = x.OrderStatus.OrderStatusName
            }).ToList();

        }

        public IEnumerable<OrderViewModel>GetUpaidOrder()
        {
            var porduct = _order.GetAll().Where(p => p.OrderStatusId == 1 ||p.OrderStatusId==2);
            return porduct.Select(x => new OrderViewModel()
            {

                OrderId = x.OrderId,
                CustomerId = x.CustomerId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                OrderDate = Convert.ToDateTime(x.OrderDate).Date.ToString("D"),
                OrderStatusId = x.OrderStatusId,
                //OrderStatusIdCreator =x.OrderStatusIdCreator,
                MemberName = x.Customer.MemberName,
                OrderStatusName = x.OrderStatus.OrderStatusName
            }).ToList();
            
        }

        public IEnumerable<OrderViewModel> GetalreadyOrder()
        {
            var porduct = _order.GetAll().Where(p => p.OrderStatusId == 3 || p.OrderStatusId == 4 || p.OrderStatusId == 5 
            ||p.OrderStatusId==6
            );
            return porduct.Select(x => new OrderViewModel()
            {

                OrderId = x.OrderId,
                CustomerId = x.CustomerId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                OrderDate = Convert.ToDateTime(x.OrderDate).Date.ToString("D"),
                OrderStatusId = x.OrderStatusId,
                //OrderStatusIdCreator =x.OrderStatusIdCreator,
                MemberName = x.Customer.MemberName,
                OrderStatusName = x.OrderStatus.OrderStatusName
            }).ToList();

        }





    }


}
