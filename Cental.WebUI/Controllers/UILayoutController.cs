using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult UILayout()
        {
            return View();
        }
    }
}
