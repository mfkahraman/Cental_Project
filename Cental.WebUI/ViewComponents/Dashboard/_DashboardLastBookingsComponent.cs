using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLastBookingsComponent(IBookingService bookingService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var bookings = bookingService.TGetAll().Take(6).ToList();
            return View(bookings);
        }
    }
}
