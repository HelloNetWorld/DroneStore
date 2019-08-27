using System;
using System.Collections.Generic;
using System.ComponentModel;
using DroneStore.Web.Infrastructure;

namespace DroneStore.Web.Models.Order
{
    public class OrderViewModel : IErrors
    {
        public OrderViewModel()
        {
            Errors = new List<string>();
        }

        public DateTime CreationDate { get; set; }

        public OrderItemsPreviewViewModel ItemsPreview { get; set; }

        public string PaymentMethod { get; set; }

        [DisplayName("Address")]
        public string Address1 { get; set; }
        [DisplayName("Address (Optional)")]
        public string Address2 { get; set; }
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Phone Number (Optional)")]
        public string PhoneNumber2 { get; set; }
        [DisplayName("Email")]
        public string CustomerEmail { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public ICollection<string> Errors { get; set; }
    }
}
