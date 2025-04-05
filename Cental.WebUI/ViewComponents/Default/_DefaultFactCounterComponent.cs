using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultFactCounterComponent(UserManager<AppUser> userManager, ICarService carService, IBookingService bookingService, IBrandService brandService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int userCount = await userManager.Users.CountAsync();
            ViewBag.UserCount = 198 * userCount;
            int carCount = carService.TGetAll().Count();
            ViewBag.CarCount = 28 * carCount;
            int carCenterCount = bookingService.TGetAll().Where(x => x.IsCancel == false).Count();
            ViewBag.CarCenterCount = 27 * carCenterCount;
            int brandCount = brandService.TGetAll().Count();
            ViewBag.BrandCount = 9 * brandCount;
            return View();
        }
    }
}
