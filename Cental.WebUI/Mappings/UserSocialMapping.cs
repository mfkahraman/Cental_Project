using AutoMapper;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class UserSocialMapping : Profile
    {
        public UserSocialMapping()
        {
            CreateMap<UserSocial, ResultUserSocialDto>().ReverseMap();
            CreateMap<UserSocial, CreateUserSocialDto>().ReverseMap();
            CreateMap<UserSocial, UpdateUserSocialDto>().ReverseMap();
        }
    }
}
