using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.MessageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController(IMessageService messageService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(CreateMessageDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Lütfen form alanlarını doğru şekilde doldurun.");
            }

            model.IsRead = false;
            model.MessageDate = DateTime.Now;
            messageService.TCreate(model);

            return Ok();
        }
    }
}
