using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class BookingController(IBookingService bookingService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBooking (CreateBookingDto dto)
        {
            dto.Status = "Onay Bekliyor";
            dto.IsCancel = false;
            bookingService.TCreate(dto);
            TempData["SuccessMessage"] = "Kiralama talebiniz başarıyla oluşturuldu. Talebinizi inceledikteb sonra size bilgi vereceğiz. Taleplerim sekmesinden kontrol edebilirsiniz";
            return RedirectToAction("Index", "Default", new { area = "" });

        }
    }
}
