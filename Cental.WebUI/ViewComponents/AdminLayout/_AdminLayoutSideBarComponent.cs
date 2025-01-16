using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.AdminLayout
{
    public class _AdminLayoutSideBarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
