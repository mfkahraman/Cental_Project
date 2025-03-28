﻿using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    //.NET 8 ie gelen primary constructor özelliği ile aşağıdaki şekilde constructor oluşturabiliyoruz
    public class AdminBannerController(IBannerService _bannerService, IMapper _mapper) : Controller
    {
        /*
        private readonly IBannerService _bannerService;
        private readonly IMapper mapper;

        public AdminBannerController(IBannerService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            this.mapper = mapper;
        }
        */

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
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var banner = _mapper.Map<Banner>(model);
            _bannerService.TCreate(banner);
            return RedirectToAction("Index");
        }
    }
}
