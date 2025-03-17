using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.Controllers
{
    public class UserLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
