using DroneStore.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Controllers
{
	[AllowAnonymous]
	public class WishListController : Controller
    {
		public readonly IWishListViewModelService _wishListViewModelService;

		public WishListController(IWishListViewModelService wishListViewModelService) =>
            _wishListViewModelService = wishListViewModelService;

        public IActionResult Index() => View(_wishListViewModelService.WishList);

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(int itemId)
		{
			_wishListViewModelService.Add(itemId);
			return View(nameof(Index), _wishListViewModelService.WishList);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Remove(int itemId)
		{
			_wishListViewModelService.Remove(itemId);
			return View(nameof(Index), _wishListViewModelService.WishList);
		}
    }
}