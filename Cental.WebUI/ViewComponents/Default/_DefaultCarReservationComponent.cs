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

        public IViewComponentResult Invoke()
        {
            var values = _carService.TGetCarsWithBrands();
            return View(values);
        }
    }
}
