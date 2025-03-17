using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Cental.EntityLayer.Entities;
using Cental.BusinessLayer.Abstract;

public class UserService(UserManager<AppUser> userManager) : IUserService
{
    public async Task<AppUser> GetCurrentUserAsync(ClaimsPrincipal user)
    {
        if (user.Identity.IsAuthenticated)
        {
            return await userManager.FindByNameAsync(user.Identity.Name);
        }

        return null;
    }
}
