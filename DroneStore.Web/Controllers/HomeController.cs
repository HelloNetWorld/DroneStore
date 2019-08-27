using System.Diagnostics;
using DroneStore.Services.Catalog;
using DroneStore.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
    {
        private readonly ICatalogService _catalogService;

        public HomeController(ICatalogService catalogService) =>
            _catalogService = catalogService;

        public IActionResult Index() => View();

        public IActionResult AboutUs() => View();

        public IActionResult ContactUs() => View();

        public IActionResult Privacy() => View();

        public IActionResult OrdersAndReturns() => View();

        public IActionResult Conditions() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
