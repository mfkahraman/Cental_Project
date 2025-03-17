using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultBookingController(IBookingService bookingService, IUserService userService) : Controller
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
            return View();
        }


        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto dto)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "Kiralama talebi oluşturmak için giriş yapmalısınız. Sizi giriş sayfasına yönlendiriyorum." });
            }

            if (currentUser == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }

            dto.UserId = currentUser.Id;
            dto.Status = "Onay Bekliyor";
            dto.IsCancel = false;
            bookingService.TCreate(dto);

            return Json(new { success = true, message = "Kiralama talebiniz başarıyla oluşturuldu!" });
        }



    }
}
