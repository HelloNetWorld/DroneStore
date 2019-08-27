using DroneStore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Components
{
    public class SortBy : ViewComponent
    {
        public IViewComponentResult Invoke(CatalogFilterViewModel model) =>
            View(model);
    }
}
