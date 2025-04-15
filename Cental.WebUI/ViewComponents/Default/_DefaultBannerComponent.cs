using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultBannerComponent:  ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
