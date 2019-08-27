using DroneStore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Components
{
    public class FilterByBrand : ViewComponent
    {
        public IViewComponentResult Invoke(FilterByBrandViewModel model) => View(model);
    }
}