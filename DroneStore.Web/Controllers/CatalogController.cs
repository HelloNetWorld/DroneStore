using DroneStore.Web.Models;
using DroneStore.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Controllers
{
	[AllowAnonymous]
    public class CatalogController : Controller
    {
        private readonly ICatalogViewModelService _catalogViewModelService;

        public CatalogController(ICatalogViewModelService catalogViewModelService) =>
            _catalogViewModelService = catalogViewModelService;

        public IActionResult Index() => View(_catalogViewModelService.GetCatalogModel());

        public IActionResult Catalog(int? currentPage, int? itemsPerPage, 
            string currentBrand, SortBy? sortBy)
        {
            var model = _catalogViewModelService
                .GetItems(currentPage, itemsPerPage, currentBrand, sortBy);
            return View("Index", model);
        }
    }
}