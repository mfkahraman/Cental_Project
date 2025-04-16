using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileController(IUserService userService, IImageService imageService) : Controller
    {
        protected AppUser? currentUser;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (User.Identity.IsAuthenticated)
            {
                currentUser = await userService.GetCurrentUserAsync(User);

                if (currentUser == null)
                {
                    context.Result = RedirectToAction("Index", "Login", new { area = "" });
                    return;
                }
            }

            await next();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dto = new UpdateUserDto
            {
                Id = currentUser.Id,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email,
                PhoneNumber = currentUser.PhoneNumber,
                ImageUrl = currentUser.ImageUrl
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateUserDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            // Image upload handling
            if (dto.ProfileImage != null && dto.ProfileImage.Length > 0)
            {
                // Delete old image if exists
                if (!string.IsNullOrEmpty(currentUser.ImageUrl))
                    await imageService.DeleteImageAsync(currentUser.ImageUrl);

                // Save new image
                string newImageUrl = await imageService.SaveImageAsync(dto.ProfileImage, "userimages");

                currentUser.ImageUrl = newImageUrl;
            }

            currentUser.FirstName = dto.FirstName;
            currentUser.LastName = dto.LastName;
            currentUser.Email = dto.Email;
            currentUser.PhoneNumber = dto.PhoneNumber;

            await userService.UpdateAsync(currentUser);
            ViewBag.Message = "Bilgileriniz başarıyla güncellendi.";

            dto.ImageUrl = currentUser.ImageUrl;
            return View(dto);
        }
    }
}
