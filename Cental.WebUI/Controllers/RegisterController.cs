using AutoMapper;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    //Because we installed the Identity package, we need to inject the UserManager class into the controller which has user related operations.
    public class RegisterController(UserManager<AppUser> userManager, IMapper mapper) : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDto model)
        {
            var user = mapper.Map<AppUser>(model);

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            //The password needs to have at least 1 uppercase letter, 1 lowercase letter, 1 number, 1 non-alphanumeric character, and be at least 6 characters long.
            //Otherwise, the result will contain an error message.
            var result = await userManager.CreateAsync(user, model.Password);
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return View(model);
            }

            return RedirectToAction("Index", "Login");
        }
    }
}
