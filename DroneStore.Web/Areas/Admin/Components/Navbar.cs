using System.Security.Claims;
using DroneStore.Web.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Areas.Admin.Components
{
    public class Navbar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public Navbar(UserManager<AppUser> userManager) =>
            _userManager = userManager;

        public IViewComponentResult Invoke()
        {
            var userName = _userManager.GetUserName((ClaimsPrincipal) User);
            return View((object)userName);
        }
    }
}
