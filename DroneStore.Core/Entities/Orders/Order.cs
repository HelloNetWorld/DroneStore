using System;
using System.Collections.Generic;

namespace DroneStore.Core.Entities.Orders
{
    public class Order
    {
        public int OrderId { get; set; }

        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime? PaidDate { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public decimal OrderSubTotal { get; set; }
        public decimal OrderDiscount { get; set; }
        public decimal OrderTotal { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string CustomerEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
