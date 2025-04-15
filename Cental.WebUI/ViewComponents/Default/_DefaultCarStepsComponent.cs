using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultCarStepsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
