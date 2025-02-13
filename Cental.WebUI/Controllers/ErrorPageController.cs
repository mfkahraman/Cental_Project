using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public IActionResult NotFound404()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
