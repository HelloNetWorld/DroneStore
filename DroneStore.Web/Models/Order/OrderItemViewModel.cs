using System;

namespace DroneStore.Web.Models.Order
{
    public class OrderItemViewModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal =>
            UnitPrice * Quantity;
        public DateTime CreationDate { get; set; }
    }
}
