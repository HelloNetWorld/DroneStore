using System.Security.Claims;
using DroneStore.Web.Areas.Admin.Models;
using DroneStore.Web.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Areas.Admin.Components
{
    public class Sidebar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public Sidebar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var user = (ClaimsPrincipal)User;
            var appUser = _userManager.GetUserAsync(user).Result;

            var model = new SidebarViewModel
            {
                Email = appUser.Email,
                UserName = appUser.UserName
            };

            return View(model);
        }
    }
}
