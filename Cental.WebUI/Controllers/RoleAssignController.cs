using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();

            var userDtoList = new List<ResultUserDto>();
            foreach (var user in users)
            {
                var dto = new ResultUserDto();

                dto.Roles = await userManager.GetRolesAsync(user);
                dto.Id = user.Id;
                dto.FirstName = user.FirstName;
                dto.LastName = user.LastName;
                dto.Email = user.Email;
                dto.UserName = user.UserName;

                userDtoList.Add(dto);
            }

            return View(userDtoList);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            ViewBag.FullName = string.Join(" ",user.FirstName, user.LastName);
            var roles = await roleManager.Roles.ToListAsync();

            var userRoles = await userManager.GetRolesAsync(user);

            var assignRoleDtoList = new List<AssignRoleDto>();

            foreach (var item in roles)
            {
                var model = new AssignRoleDto();
                model.UserId = user.Id;
                model.RoleName = item.Name;
                model.RoleId = item.Id;
                model.RoleExist = userRoles.Contains(item.Name);

                assignRoleDtoList.Add(model);
            }

            return View(assignRoleDtoList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleList)
        {
            var userId = assignRoleList.Select(x => x.UserId).FirstOrDefault();

            var user = await userManager.FindByIdAsync(userId.ToString());

            foreach (var item in assignRoleList)
            {
                if (item.RoleExist)
                    await userManager.AddToRoleAsync(user, item.RoleName);
                else
                    await userManager.RemoveFromRoleAsync(user, item.RoleName);
            }

            return RedirectToAction("Index");
        }
    }
}
