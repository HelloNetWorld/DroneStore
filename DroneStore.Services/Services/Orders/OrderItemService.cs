using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using DroneStore.Core.Entities.Orders;
using DroneStore.Data;

namespace DroneStore.Services.Services.Orders
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRepository<OrderItem> _orderRep;

        public OrderItemService(IRepository<OrderItem> orderRep)
        {
            _orderRep = orderRep;
        }

        public void Delete(OrderItem orderItem)
        {
            Guard.Against.Null(orderItem, nameof(orderItem));

            _orderRep.Delete(orderItem);
        }

        public OrderItem GetById(int orderId)
        {
            return _orderRep.GetById(orderId);
        }

        public IEnumerable<OrderItem> GetAll() =>
            _orderRep.EntitiesReadOnly;

        public void Insert(OrderItem orderItem)
        {
            Guard.Against.Null(orderItem, nameof(orderItem));

            _orderRep.Insert(orderItem);
        }

        public void Update(OrderItem orderItem)
        {
            Guard.Against.Null(orderItem, nameof(orderItem));

            _orderRep.Update(orderItem);
        }

        public IEnumerable<OrderItem> GetOrderItemsByOrderId(int orderId) =>
            _orderRep.EntitiesReadOnly.Where(oi => oi.OrderId == orderId);
    }
}
