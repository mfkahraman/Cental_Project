using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Cental.DtoLayer.Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList.Extensions;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CarController(ICarService _carService,
                            IMapper _mapper,
                               IBrandService _brandService,
                               IImageService imageService) : Controller
    {
        private void GetValuesInDropDown()
        {
            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();
            ViewBag.transmissions = GetEnumValues.GetEnums<Transmissions>();
            ViewBag.brands = (from x in _brandService.TGetAll()
                              select new SelectListItem
                              {
                                  Text = x.BrandName,
                                  Value = x.BrandId.ToString()
                              }).ToList();
        }

        public IActionResult Index(int page = 1, int pageSize = 8)
        {
            var values = _carService.TGetAll().ToPagedList(page, pageSize);
            return View(values);
        }

        public IActionResult CreateCar()
        {
            GetValuesInDropDown();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto model)
        {
            GetValuesInDropDown();

            if (model.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(model.ImageFile, "cars");
                model.ImageUrl = imagePath;
            }

            _carService.TCreate(model);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCar(int id)
        {
            var car = _carService.TGetById(id);
            if (car != null)
            {
                _carService.TDelete(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}
