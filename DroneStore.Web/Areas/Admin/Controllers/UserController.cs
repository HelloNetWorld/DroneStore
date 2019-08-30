using System;
using System.Threading.Tasks;
using DroneStore.Web.Areas.Admin.Models;
using DroneStore.Web.Areas.Admin.Services;
using DroneStore.Web.Areas.Admin.Validators;
using DroneStore.Web.Extensions;
using DroneStore.Web.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DroneStore.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAdminViewModelService _adminService;

        public UserController(UserManager<AppUser> userManager,
            IAdminViewModelService adminService)
        {
            _userManager = userManager;
            _adminService = adminService;
        }

        // GET: User
        public IActionResult Index()
        {
            var model = _adminService.GetUsers();
            return View(model);
        }

        // GET: User/Edit/id
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Roles = string.Join(", ", roles),
                UserName = user.UserName
            };

            return View(model);
        }

        // POST: User/Edit/EditUserViewModel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel input)
        {
            var errorView = this.Validate(input, new EditUserValidator());

            var user = await _userManager.FindByIdAsync(input.Id);
            if (user == null)
            {
                return RedirectToAction("Error", "Home");
            }

            await _userManager.SetEmailAsync(user, input.Email);
            await _userManager.SetUserNameAsync(user, input.UserName);

            var roles = input.Roles.Split(new string[] { ", " }, StringSplitOptions.None);
            foreach(var role in roles)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: User/Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Error", "Home");
        }
    }
}