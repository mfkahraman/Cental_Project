using Cental.BusinessLayer.Abstract;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultCarReservationComponent : ViewComponent
    {
        private readonly ICarService _carService;

        public _DefaultCarReservationComponent(ICarService carService)
        {
            _carService = carService;
        }

        public IViewComponentResult InvokeAsync()
        {
            ViewBag.Cars = _carService.TGetAll();
            return View();
        }
    }
}
