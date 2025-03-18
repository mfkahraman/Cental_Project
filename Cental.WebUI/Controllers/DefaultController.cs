using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cental.WebUI.Controllers
{
    public class DefaultController(UserManager<AppUser> userManager, IUserService userService) : Controller
    {
        protected AppUser? currentUser;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (User.Identity.IsAuthenticated)
            {
                currentUser = await userService.GetCurrentUserAsync(User);

                if (currentUser == null)
                {
                    context.Result = RedirectToAction("Index", "Login", new { area = "" });
                    return;
                }
            }

            await next();
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.IsAuthanticated = User.Identity.IsAuthenticated;
            return View();
        }

        //public async Task<IActionResult> RedirectUserToProfile()
        //{
        //    if (currentUser == null)
        //    {
        //        return RedirectToAction("Index", "Login", new { area = "" });
        //    }

        //    var userRoles = await userManager.GetRolesAsync(currentUser);

        //    if (userRoles.Count == 0)
        //    {
        //        TempData["Error"] = "Kullanıcının rolü bulunamadı";
        //        return RedirectToAction("Index", "Default"); // Redirect if user has no role
        //    }
                    
        //    return userRoles[0] switch
        //    {
        //        "Admin" => RedirectToAction("Index", "AdminAbout"),
        //        "Manager" => RedirectToAction("Index", "MySocial", new { area = "Manager" }),
        //        "User" => RedirectToAction("Index", "Default"), // Change if needed
        //        _ => RedirectToAction("Index", "Default") // Fallback redirection
        //    };
        //}




    }
}
