using DroneStore.Web.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Components
{
    public class OrderDetails : ViewComponent
    {
        public IViewComponentResult Invoke(OrderViewModel model)
        {
            return View(model);
        }
    }
}
