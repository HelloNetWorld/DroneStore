using System.Collections.Generic;
using DroneStore.Core.Entities.Orders;

namespace DroneStore.Web.Areas.Admin.Models
{
    public class OrderDetailsViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
