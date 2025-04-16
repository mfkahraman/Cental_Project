using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.UserDtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; } // Identity User ID
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ProfileImage { get; set; }
    }
}
