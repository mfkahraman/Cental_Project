using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultServicesComponent(IServiceService serviceManager) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var services = serviceManager.TGetAll().TakeLast(6).ToList();
            return View(services);
        }
    }
}
