using DroneStore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DroneStore.Web.Components
{
    public class NavBarCart : ViewComponent
    {
        private readonly IShoppingCartViewModelService _shoppingCartService;

        public NavBarCart(IShoppingCartViewModelService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IViewComponentResult Invoke()
        {
            ViewData["ItemsInCart"] = _shoppingCartService.Cart.Lines.Sum(cl => cl.Quantity);
			return View();
        }
    }
}
