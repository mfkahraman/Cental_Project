using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class ServiceManager(IServiceDal serviceDal, IMapper mapper) : IServiceService
    {
        public void TCreate(CreateServiceDto dto)
        {
            var service = mapper.Map<Service>(dto);
            serviceDal.Create(service);
        }

        public void TDelete(int id)
        {
            serviceDal.Delete(id);
        }

        public List<ResultServiceDto> TGetAll()
        {
            var service = serviceDal.GetAll();
            return mapper.Map<List<ResultServiceDto>>(service);
        }

        public ResultServiceDto TGetById(int id)
        {
            var service = serviceDal.GetById(id);
            return mapper.Map<ResultServiceDto>(service);
        }

        public void TUpdate(UpdateServiceDto dto)
        {
            var service = mapper.Map<Service>(dto);
            serviceDal.Update(service);
        }
    }
}
