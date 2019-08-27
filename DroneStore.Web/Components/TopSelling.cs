using System.Linq;
using DroneStore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using MoreLinq;

namespace DroneStore.Web.Components
{
    public class TopSelling : ViewComponent
    {
        private readonly IHomeViewModelService _homeViewModelService;
        private readonly ICatalogViewModelService _catalogViewModelService;

        public TopSelling(IHomeViewModelService homeViewModelService,
            ICatalogViewModelService catalogViewModelService)
        {
            _homeViewModelService = homeViewModelService;
            _catalogViewModelService = catalogViewModelService;
        }

        public IViewComponentResult Invoke()
        {
            var model = _homeViewModelService.TopSellingItems;
            if (model.Count() < 8)
            {
                model = _catalogViewModelService.GetAllItems
                    .Shuffle()
                    .Take(8);
            }

            return View(model);
        }
    }
}
