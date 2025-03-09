using AutoMapper;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultManagerComponent(UserManager<AppUser> userManager, IMapper mapper) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var managers = await userManager.GetUsersInRoleAsync("Manager");
            var dto = mapper.Map<List<ResultUserDto>>(managers);
            return View(dto.TakeLast(4).ToList());
        }
    }
}
