using System.Collections.Generic;
using DroneStore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Components
{
    public class ProductSummary : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<CatalogItemViewModel> model)
        {
            return View(model);
        }
    }
}
