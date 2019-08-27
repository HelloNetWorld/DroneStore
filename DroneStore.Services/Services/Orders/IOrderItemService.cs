using System.Collections.Generic;
using DroneStore.Core.Entities.Orders;

namespace DroneStore.Services.Services.Orders
{
    public interface IOrderItemService
    {
        void Delete(OrderItem order);
        OrderItem GetById(int orderId);
        IEnumerable<OrderItem> GetAll();
        void Insert(OrderItem order);
        void Update(OrderItem order);
        IEnumerable<OrderItem> GetOrderItemsByOrderId(int orderId);
    }
}
