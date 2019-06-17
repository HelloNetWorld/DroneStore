using System.Collections.Generic;
using DroneStore.Core.Entities.Orders;

namespace DroneStore.Services.Services.Orders
{
    public interface IOrderService
    {
        void Delete(Order order);
        Order GetById(int orderId);
        IEnumerable<Order> GetAll();
        void Insert(Order order);
        void Update(Order order);
    }
}
