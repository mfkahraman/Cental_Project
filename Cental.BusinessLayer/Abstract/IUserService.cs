using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IUserService
    {
        public Task<AppUser> GetCurrentUserAsync(ClaimsPrincipal user);
        Task UpdateAsync(AppUser user);
    }
}
