using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    public class AdminLayout : Controller
    {
        public IActionResult LayoutAdmin()
        {
            return View();
        }
    }
}
