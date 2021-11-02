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

        private readonly Repository<Order> _repository;

        public OrderService(Repository<Order> repository)
        {
            _repository = repository;
        }

        public IEnumerable<OrderViewModel>GetAllOrder()
        {
            return _repository.GetAll().Select(x => new OrderViewModel()
            {
                OrderId = x.OrderId,
                CustomerId = x.CustomerId,
                ProductId = x.ProductId,
                TotalPrice = x.Quantity * x.UnitPrice,
                OrderDate = x.OrderDate,
                OrderStatusId = x.OrderStatusId,
               
            }).ToList();

        }



    }


}
