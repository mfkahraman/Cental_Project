using Cental.DtoLayer.RoleDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController(RoleManager<AppRole> roleManager) : Controller
    {
        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();

            var dto = roles.Adapt<List<ResultRoleDto>>();
            return View(dto);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto model)
        {
            var role = model.Adapt<AppRole>();

            var result = await roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(model);
                }
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                return NotFound();
            }
            var result = await roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateRole(int id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                return NotFound();
            }
            var updateDto = role.Adapt<UpdateRoleDto>();
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto model)
        {
            var role = model.Adapt<AppRole>();
            var result = await roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(model);
                }
            }
            return RedirectToAction("Index");
        }


    }
}
