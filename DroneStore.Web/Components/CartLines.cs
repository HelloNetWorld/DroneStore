using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DroneStore.Web.Models.ShoppingCart;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Components
{
    public class CartLines : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<ShoppingCartLineViewModel> model)
        {
            return View(model);
        }
    }
}
