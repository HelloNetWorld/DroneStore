using DroneStore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DroneStore.Web.Components
{
	public class WishList : ViewComponent
	{
		private readonly IWishListViewModelService _wishlistService;

		public WishList(IWishListViewModelService wishlistservice)
		{
			_wishlistService = wishlistservice;
		}

		public IViewComponentResult Invoke()
		{
			ViewData["WishList"] = _wishlistService.WishList.Items.Count;
			return View();
		}
	}
}