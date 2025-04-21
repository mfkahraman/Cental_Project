using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Extensions;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandController(IBrandService _brandService) : Controller
    {
        public IActionResult Index(int page = 1, int pageSize = 8)
        {
            var values = _brandService.TGetAll().ToPagedList(page, pageSize);
            return View(values);
        }

        public IActionResult DeleteBrand(int id)
        {
            _brandService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBrand(Brand model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _brandService.TCreate(model);
            return RedirectToAction("Index");
        }
    }
}
