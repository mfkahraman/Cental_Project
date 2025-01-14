using AutoMapper;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class BannerMapping: Profile
    {
        public BannerMapping()
        {
            //ReverseMap tersine de maple demek
            CreateMap<Banner, ResultBannerDto>().ReverseMap();
            CreateMap<Banner, CreateBannerDto>().ReverseMap();
            CreateMap<Banner, UpdateBannerDto>().ReverseMap();
        }
    }
}
