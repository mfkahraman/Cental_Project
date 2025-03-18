using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BookingController(IBookingService bookingService, IUserService userService) : Controller
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
            var bookings = bookingService.TGetAll();
            return View(bookings);
        }


        public IActionResult AcceptBooking(int id)
        {
            bookingService.TAcceptBooking(id);
            return RedirectToAction("Index");
        }

        public IActionResult DeclineBooking(int id)
        {
            bookingService.TDeclineBooking(id);
            return RedirectToAction("Index");
        }


    }
}

