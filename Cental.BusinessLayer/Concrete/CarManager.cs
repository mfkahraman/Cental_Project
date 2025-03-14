using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.DtoLayer.CarDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class CarManager (ICarDal carDal, IMapper mapper): ICarService
    {
        public void TCreate(CreateCarDto dto)
        {
            var entity = mapper.Map<Car>(dto);
            carDal.Create(entity);
        }

        public void TDelete(int id)
        {
            carDal.Delete(id);
        }

        public List<ResultCarDto> TGetAll()
        {
            var entities = carDal.GetAll();
            var dtos = mapper.Map<List<ResultCarDto>>(entities);
            return dtos;
        }

        public ResultCarDto TGetById(int id)
        {
            var entity = carDal.GetById(id);
            return mapper.Map<ResultCarDto>(entity);
        }

        public void TUpdate(UpdateCarDto dto)
        {
            var entity = mapper.Map<Car>(dto);
            carDal.Update(entity);
        }


        List<ResultCarDto> ICarService.TGetCarsWithBrands()
        {
            var entities = carDal.GetCarsWithBrands();
            return mapper.Map<List<ResultCarDto>>(entities);
        }
    }
}
