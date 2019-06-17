using System.Collections.Generic;
using System.Linq;

namespace DroneStore.Web.Models.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            Lines = new List<ShoppingCartLineViewModel>();
        }

        public ICollection<ShoppingCartLineViewModel> Lines { get; set; }

        public decimal SubTotal => Lines.Sum(x => x.Price * x.Quantity);

		public decimal Discount =>
			Lines.Sum(x => x.DiscountValue * x.Quantity);

        public decimal Total => Lines.Sum(x => x.Price * x.Quantity);

        public string BackUrl { get; set; }
    }
}
