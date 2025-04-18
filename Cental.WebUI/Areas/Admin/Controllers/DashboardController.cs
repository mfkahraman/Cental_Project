using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController(IMessageService messageService,
                                    UserManager<AppUser> userManager,
                                    IBrandService brandService,
                                    IBookingService bookingService,
                                    ICarService carService,
                                    IReviewService reviewService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.UserCount = (await userManager.Users.ToListAsync()).Count;
            ViewBag.MessageCount = messageService.TGetAll().Count;
            ViewBag.BrandCount = brandService.TGetAll().Count;
            ViewBag.BookingCount = bookingService.TGetAll().Count;
            ViewBag.CarCount = carService.TGetAll().Count;
            ViewBag.ReviewCount = reviewService.TGetAll().Count;

            return View();
        }
    }
}
