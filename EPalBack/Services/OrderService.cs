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
        private readonly Repository<Order> _repository;

        public OrderService(Repository<Order> repository, Repository<Member> member/*, Repository<OrderStatus> orderstaus*/)
        {
            _repository = repository;
            _member = member;
            //_orderstatus = orderstaus;
        }
      
        public IEnumerable<OrderViewModel>GetAllOrder()
        {
            
            return _repository.GetAll().Select(x => new OrderViewModel()
            {
                OrderId = x.OrderId,
                CustomerId = x.CustomerId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice*x.Quantity,
                OrderDate = Convert.ToDateTime(x.OrderDate).Date.ToString("D"),
                OrderStatusId = x.OrderStatusId,
                OrderStatusIdCreator =x.OrderStatusIdCreator,
                MemberName =x.Customer.MemberName,
                OrderStatusName = x.OrderStatus.OrderStatusName

            }).ToList();

        }



    }


}
