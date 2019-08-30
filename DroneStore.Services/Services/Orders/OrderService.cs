using System.Collections.Generic;
using Ardalis.GuardClauses;
using DroneStore.Core.Entities.Orders;
using DroneStore.Data;

namespace DroneStore.Services.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRep;

        public OrderService(IRepository<Order> orderRep) =>
            _orderRep = orderRep;

        public void Delete(Order order)
        {
            Guard.Against.Null(order, nameof(order));

            _orderRep.Delete(order);
        }

        public Order GetById(int orderId) =>
            _orderRep.GetById(orderId);


        public IEnumerable<Order> GetAll() => 
            _orderRep.EntitiesReadOnly;

        public void Insert(Order order)
        {
            Guard.Against.Null(order, nameof(order));

            _orderRep.Insert(order);
        }

        public void Update(Order order)
        {
            Guard.Against.Null(order, nameof(order));

            _orderRep.Update(order);
        }
    }
}
