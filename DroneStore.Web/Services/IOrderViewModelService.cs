using DroneStore.Web.Models.Order;

namespace DroneStore.Web.Services
{
    public interface IOrderViewModelService
    {
        OrderViewModel PrepareSessionCartOrder();
        int AddOrder(OrderViewModel order);
        void RemoveOrder(int orderId);
    }
}
