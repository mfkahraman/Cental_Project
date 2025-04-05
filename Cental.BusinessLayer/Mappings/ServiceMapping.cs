using AutoMapper;
using Cental.DtoLayer.ServiceDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Mappings
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
            CreateMap<Service, ResultServiceDto>();
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();
        }
    }
}
