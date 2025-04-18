using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DtoLayer.BookingDtos;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Identity.Client;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles ="User")]
    public class BookingController(IBookingService bookingService, IUserService userService, IReviewService reviewService) : Controller
    {
        protected AppUser? currentUser;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (User.Identity.IsAuthenticated)
            {
                currentUser = await userService.GetCurrentUserAsync(User);

                // If the user exists in Identity but not in the database
                if (currentUser == null)
                {
                    context.Result = RedirectToAction("Index", "Login", new { area = "" });
                    return;
                }
            }

            await next();
        }

        public IActionResult Index()
        {
            var bookings = bookingService.TGetAll().Where(x=> x.UserId == currentUser.Id).ToList();
            return View(bookings);
        }


        public IActionResult CancelBooking(int id)
        {
            bookingService.TCancelByUser(id);
            return RedirectToAction("Index");
        }

        public IActionResult ApprovedBookings()
        {
            var bookings = bookingService.TGetAll().Where(x => x.UserId == currentUser.Id && x.Status == "Onaylandı").ToList();
            return View(bookings);
        }

        [HttpPost]
        public IActionResult AddReview(CreateReviewDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Geçersiz değerlendirme verisi.";
                return RedirectToAction("ApprovedBookings");
            }

            reviewService.TCreate(dto);

            TempData["Success"] = "Yorum başarıyla eklendi!";
            return RedirectToAction("ApprovedBookings");
        }



    }
}
