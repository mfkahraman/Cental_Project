using AutoMapper;
using Cental.DtoLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Mappings
{
    public class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, ResultBrandDto>();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
        }
    }
}
