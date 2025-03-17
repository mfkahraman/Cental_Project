using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class BookingController(IBookingService bookingService, IUserService userService, IMapper mapper) : Controller
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
            var booking = bookingService.TGetById(id);
            booking.Status = "Kullanıcı tarafından iptal edildi";
            bookingService.TUpdate(mapper.Map<UpdateBookingDto>(booking));
            return RedirectToAction("Index");
        }


    }
}
