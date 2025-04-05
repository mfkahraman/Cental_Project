using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultVehiclesComponent(ICarService carService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cars = carService.TGetAll().ToList();
            return View(cars);
        }

    }
}
