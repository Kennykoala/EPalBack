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
                OrderStatusName = x.OrderStatus.OrderStatusName,
                OrderConfirmation =x.OrderConfirmation
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
                OrderStatusName = x.OrderStatus.OrderStatusName,
                OrderConfirmation = x.OrderConfirmation
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
                OrderStatusName = x.OrderStatus.OrderStatusName,
                OrderConfirmation = x.OrderConfirmation
            }).ToList();
        }




        public void UpdateOrder(OrderViewModel request)
        {
            var target = _order.GetAll().FirstOrDefault(x => x.CustomerId == request.CustomerId);
            {
                target.Quantity = request.Quantity;
                target.DesiredStartTime = request.DesiredStartTime;

                _order.Update(target);
                _order.SaveChanges();

            }
        }

        public IEnumerable<OrderViewModel>GetOrderDetails(int id)
        {
            var order = _order.GetAll().Where(o => o.OrderId == id);

            return order.Select(x => new OrderViewModel()
            {
                ProductId =x.ProductId,
                UnitPrice =x.UnitPrice,
                DesiredStartTime =x.DesiredStartTime,
                OrderDate = Convert.ToDateTime(x.OrderDate).Date.ToString("D"),
                OrderStatusId = x.OrderStatusId,
                OrderConfirmation = x.OrderConfirmation


            }).ToList();




        }





    }


}
