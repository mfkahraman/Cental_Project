using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            await signInManager.SignOutAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto model, string? returnUrl)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View(model);
            }

            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            var userRoles = await userManager.GetRolesAsync(user);

            if (userRoles.Contains("Admin"))
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            else if (userRoles.Contains("Manager"))
            {
                return RedirectToAction("Index", "MySocial", new {area="Manager"});
            }

            else if (userRoles.Contains("User"))
            {
                return RedirectToAction("Index", "Booking", new {area="User"});

            }

            return RedirectToAction("Index", "Default");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
