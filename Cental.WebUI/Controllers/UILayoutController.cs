using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class UILayoutController : Controller
    {
        public IActionResult UILayout()
        {
            return View();
        }
    }
}
