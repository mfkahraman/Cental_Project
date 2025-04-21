using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BannerController(IBannerService _bannerService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var values = _bannerService.TGetAll();

            var banners = _mapper.Map<List<ResultBannerDto>>(values);

            return View(banners);
        }

        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBanner(CreateBannerDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var banner = _mapper.Map<Banner>(model);
            _bannerService.TCreate(banner);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBanner(int id)
        {
            _bannerService.TDelete(id);
            return RedirectToAction("Index");
        }

    }
}
