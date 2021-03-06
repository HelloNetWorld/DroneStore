﻿using System.Collections.Generic;
using DroneStore.Web.Models.ShoppingCart;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Components
{
    public class CartLines : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<ShoppingCartLineViewModel> model) =>
            View(model);
    }
}
