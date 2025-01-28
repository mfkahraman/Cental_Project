using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Cental.WebUI.Controllers
{
    [Authorize]
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AdminAboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var values = _aboutService.TGetAll();

            var result = values.Select(x => new ResultAboutDto
            {
                AboutId = x.AboutId,
                Mission = x.Mission,
                Vision = x.Vision,
            }).ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto model)
        {
            _aboutService.TCreate(new About
            {
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                JobTitle = model.JobTitle,
                Mission = model.Mission,
                NameSurname = model.NameSurname,
                ProfilePicUrl = model.ProfilePicUrl,
                StartYear = model.StartYear,
                Vision = model.Vision,
            });

            return RedirectToAction("Index");
        }

        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateAbout(int id)
        {
            var model = _aboutService.TGetById(id);

            var about = new UpdateAboutDto
            {
                AboutId = model.AboutId,
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                JobTitle = model.JobTitle,
                Mission = model.Mission,
                NameSurname = model.NameSurname,
                ProfilePicUrl = model.ProfilePicUrl,
                StartYear = model.StartYear,
                Vision = model.Vision,
            };

            return View(about);
        }

        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutDto model)
        {
            var about = new About
            {
                AboutId = model.AboutId,
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                JobTitle = model.JobTitle,
                Mission = model.Mission,
                NameSurname = model.NameSurname,
                ProfilePicUrl = model.ProfilePicUrl,
                StartYear = model.StartYear,
                Vision = model.Vision,
            };
            _aboutService.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}
