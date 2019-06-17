using DroneStore.Web.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Components
{
    public class OrderItemsPreview : ViewComponent
    {
        public IViewComponentResult Invoke(OrderItemsPreviewViewModel model)
        {
            return View(model);
        }
    }
}
