using DroneStore.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Controllers
{
	[AllowAnonymous]
	public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartViewModelService _cartService;

        public ShoppingCartController(IShoppingCartViewModelService cartService) =>
            _cartService = cartService;

        public IActionResult Index(string backUrl)
        {
            var model = _cartService.Cart;
            model.BackUrl = backUrl;
            return View(model);
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult AddToCart(int itemId, int quantity, string backUrl)
        {
             _cartService.AddToCard(itemId, quantity, backUrl);
            return View("Index", _cartService.Cart);
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult RemoveFromCart(int itemId, int quantity)
        {
            _cartService.RemoveFromCard(itemId, quantity, "/Catalog");
            return View("Index", _cartService.Cart);
        }

        public IActionResult Clear()
        {
            _cartService.Clear();
            return View("Index", _cartService.Cart);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ChangeQuantity(int itemId, int quantity)
		{
			_cartService.ChangeQuantity(itemId, quantity, "/Catalog");
			return View("Index", _cartService.Cart);
		}
	}
}