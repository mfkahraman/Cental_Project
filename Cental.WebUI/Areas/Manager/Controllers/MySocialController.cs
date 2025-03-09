using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class MySocialController(IUserSocialService _userSocialService, IMapper mapper, UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _userSocialService.TGetSocialsByUserId(user.Id);
            var userSocial = mapper.Map<List<ResultUserSocialDto>>(values);
            return View(userSocial);
        }

        [HttpGet]
        public IActionResult CreateSocial()
        {
            return View();
        }
        //Eklerken social medya adını combobox yap, seçilen comboboxa göre iconu controllerdan ata.
        //fab fa-facebook-f, fab fa-twitter, fab fa-instagram, fab fa-linkedin-in
        //ekstra lazım olursa fab fa-youtube, fab fa-github
        [HttpPost]
        public async Task<IActionResult> CreateSocial(CreateUserSocialDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var newSocial = mapper.Map<UserSocial>(model);
            newSocial.UserId = user.Id;
            _userSocialService.TCreate(newSocial);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocial(int id)
        {
            _userSocialService.TDelete(id);
            return RedirectToAction("Index");
        }


    }
}
