using DroneStore.Web.Models.ShoppingCart;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Components
{
    public class CartTotal : ViewComponent
    {
        public IViewComponentResult Invoke(ShoppingCartViewModel model) =>
            View(model);
    }
}
