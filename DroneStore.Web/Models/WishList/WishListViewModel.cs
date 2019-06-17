using System.Collections.Generic;

namespace DroneStore.Web.Models.WishList
{
	public class WishListViewModel
	{
		public WishListViewModel() => 
			Items = new List<WishListItem>();

		public IList<WishListItem> Items { get; }
	}
}
