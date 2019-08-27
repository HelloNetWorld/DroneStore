using System;

namespace DroneStore.Web.Models.Discount
{
	public class DiscountViewModel
	{
		public decimal OldPrice { get; set; }
		public decimal NewPrice { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime ExpireDate { get; set; }
		public int DiscountId { get; set; }
		public int ItemId { get; set; }

		public bool IsExpired => DateTime.UtcNow > ExpireDate;
	}
}
