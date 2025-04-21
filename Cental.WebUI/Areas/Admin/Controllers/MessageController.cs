using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MessageController(IMessageService messageService) : Controller
    {
        public IActionResult Index()
        {
            var messages = messageService.TGetAll();
            return View(messages);
        }

        public IActionResult MarkAsRead(int id)
        {
            messageService.TMarkAsRead(id);
            return RedirectToAction("Index");
        }
    }
}
