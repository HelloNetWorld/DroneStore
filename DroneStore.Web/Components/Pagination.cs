using DroneStore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Components
{
    public class Pagination : ViewComponent
    {
        public IViewComponentResult Invoke(CatalogFilterViewModel model)
        {
            return View(model);
        }
    }
}
