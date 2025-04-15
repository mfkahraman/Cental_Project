using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultTestimonialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
