using AutoMapper;
using Cental.DtoLayer.CarDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Mappings
{
    class CarMapping : Profile
    {
        public CarMapping()
        {
            CreateMap<Car, CreateCarDto>().ReverseMap();
            CreateMap<Car, UpdateCarDto>().ReverseMap();
            CreateMap<Car, ResultCarDto>();
            //CreateMap<Car, ResultCarDto>().ForMember(dest => dest.BrandName, o => o.MapFrom(src => src.Brand.BrandName));
        }
    }
}