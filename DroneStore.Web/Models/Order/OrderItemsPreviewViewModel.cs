using System.Collections.Generic;
using System.Linq;

namespace DroneStore.Web.Models.Order
{
	public class OrderItemsPreviewViewModel
	{
		public OrderItemsPreviewViewModel()
		{
			Items = new List<OrderItemViewModel>();
		}

		public ICollection<OrderItemViewModel> Items { get; set; }

		public int Count => Items.Sum(i => i.Quantity);

		public decimal SubTotal =>
			Items.Sum(i => i.UnitPrice * i.Quantity);

		public decimal Discount { get; set; }

		public decimal Total =>
			Items.Sum(i => i.UnitPrice * i.Quantity);
	}
}
