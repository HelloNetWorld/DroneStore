using System;
using System.Collections.Generic;
using DroneStore.Web.Infrastructure;

namespace DroneStore.Web.Areas.Admin.Models
{
    public class DiscountViewModel : IErrors
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int DiscountId { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public DateTime ExpireDate { get; set; }

        public ICollection<string> Errors { get; set; } = new List<string>();
    }
}
