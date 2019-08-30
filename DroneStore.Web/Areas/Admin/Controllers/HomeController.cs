using DroneStore.Web.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IAdminViewModelService _adminViewModelService;

        public HomeController(IAdminViewModelService adminViewModelService) =>
            _adminViewModelService = adminViewModelService;

        public IActionResult Index()
        {
            var model = _adminViewModelService.PrepareDashboard();
            return View(model);
        }
    }
}