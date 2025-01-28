﻿using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminProfileController(UserManager<AppUser> userManager, IImageService imageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            //Adapt is using for mapping from Mapsters library
            var profileEditDto = user.Adapt<ProfileEditDto>();

            return View(profileEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProfileEditDto model)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var isPasswordTrue = await userManager.CheckPasswordAsync(user, model.CurrentPassword);
           
            if(isPasswordTrue)
            {
                if(model.ImageFile != null)
                { 
                    model.ImageUrl = await imageService.SaveImageAsync(model.ImageFile);
                }

                var updatedUser = model.Adapt<AppUser>();

                var result = await userManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","AdminAbout");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);

            }

            ModelState.AddModelError("", "Şifreniz yanlış");
            return View(model);

        }
    }
}
