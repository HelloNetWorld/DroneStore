using System;

namespace DroneStore.Core.Entities.Orders
{
	public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreationDate { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
