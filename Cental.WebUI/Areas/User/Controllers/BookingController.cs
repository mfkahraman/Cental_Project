using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class BookingController(IBookingService bookingService, UserManager<AppUser> userManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "Kiralama talebi oluşturmak için giriş yapmalısınız. Sizi giriş sayfasına yönlendiriyorum." });
            }

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }

            dto.UserId = user.Id;
            dto.Status = "Onay Bekliyor";
            dto.IsCancel = false;
            bookingService.TCreate(dto);

            return Json(new { success = true, message = "Kiralama talebiniz başarıyla oluşturuldu!" });
        }




    }
}
