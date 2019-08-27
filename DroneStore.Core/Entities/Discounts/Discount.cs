using System;

namespace DroneStore.Core.Entities.Discounts
{
    public class Discount
	{
		public int Id { get; set; }
		public DateTime StartDateInUtc { get; set; }
		public DateTime ExpireDateInUtc { get; set; }
		public decimal OldValue { get; set; }
		public decimal NewValue { get; set; }
	}
}
