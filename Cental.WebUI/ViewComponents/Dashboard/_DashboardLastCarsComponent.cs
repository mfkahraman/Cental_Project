using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLastCarsComponent(ICarService carService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cars = carService.TGetAll().Take(6).ToList();
            return View(cars);
        }
    }
}
