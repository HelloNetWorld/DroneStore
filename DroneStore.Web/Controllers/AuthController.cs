using DroneStore.Web.Identity;
using DroneStore.Web.Models.Identity;
using DroneStore.Web.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DroneStore.Web.Controllers
{
	public class AuthController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AuthController(UserManager<AppUser> userManager,
			SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[AllowAnonymous]
		public IActionResult Login(string returnUrl)
		{
			ViewBag.returnUrl = returnUrl;
			return View("Login-register-forms");
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel login, string returnUrl)
		{
			var validator = new LoginValidator();
			var validationResult = validator.Validate(login);

			if (validationResult.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(login.Email);
				if (user != null)
				{
					await _signInManager.SignOutAsync();
					var result = await _signInManager
						.PasswordSignInAsync(user, login.Password, login.RememberMe, false);
					if (result.Succeeded)
					{
						return Redirect(returnUrl ?? Url.Action("Index", "Home"));
					}
				}

				validationResult.Errors
					.Add(new ValidationFailure(nameof(LoginViewModel.Email), "Invalid user or password"));
			}

			var model = new MultiFormViewModel();
			foreach (var error in validationResult.Errors)
			{
				model.ValidationErrors.Add(error.ToString());
			}

			return View("Login-register-forms", model);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel register)
		{
			var validator = new RegisterValidator();
			var validationResult = validator.Validate(register);

			if (validationResult.IsValid)
			{
				var user = new AppUser
				{
					UserName = register.Name,
					Email = register.Email
				};

				var result = await _userManager
					.CreateAsync(user, register.Password);

				if (result.Succeeded)
				{
					return View("Success", user.UserName);
				}
				else
				{
					foreach (var error in result.Errors)
					{
						validationResult.Errors
							.Add(new ValidationFailure(error.Code, error.Description));
					}
				}
			}

			var model = new MultiFormViewModel();
			foreach (var error in validationResult.Errors)
			{
				model.ValidationErrors.Add(error.ToString());
			}

			return View("Login-register-forms", model);
		}

		public Task LogInExternal(string name)
		{
			var authenticationProperties = new AuthenticationProperties
			{
				RedirectUri = Url.Action(nameof(RegisterExternal))
			};

			return HttpContext.ChallengeAsync(name, authenticationProperties);
		}

		public async Task<IActionResult> RegisterExternal()
		{
			var info = await _signInManager.GetExternalLoginInfoAsync();
			if (info == null)
			{
				return RedirectToAction(nameof(Login));
			}

			var result = await _signInManager
				.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);

			if (result.Succeeded)
			{
				return View("Success", info.LoginProvider);
			}
			else
			{
				var user = new AppUser
				{
					Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
					UserName = info.Principal.FindFirst(ClaimTypes.Email).Value
				};

				var identityResult = await _userManager.CreateAsync(user);
				if (identityResult.Succeeded)
				{
					identityResult = await _userManager.AddLoginAsync(user, info);
					if (identityResult.Succeeded)
					{
						await _signInManager.SignInAsync(user, false);
						return View("Success", user.UserName);
					}
				}
				return AccessDenied(null);
			}
		}

		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		[AllowAnonymous]
		public IActionResult AccessDenied(string returnUrl)
		{
			return View();
		}
	}
}