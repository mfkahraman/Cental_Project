using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.DtoLayer.CarDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class CarManager (ICarDal carDal): ICarService
    {
        public void TCreate(CreateCarDto dto)
        {
            var entity = dto.Adapt<Car>();
            carDal.Create(entity);
        }

        public void TDelete(int id)
        {
            carDal.Delete(id);
        }

        public List<ResultCarDto> TGetAll()
        {
            var entities = carDal.GetAll();
            return entities.Adapt<List<ResultCarDto>>();
        }

        public ResultCarDto TGetById(int id)
        {
            var entity = carDal.GetById(id);
            return entity.Adapt<ResultCarDto>();
        }

        public void TUpdate(UpdateCarDto dto)
        {
            var entity = dto.Adapt<Car>();
            carDal.Update(entity);
        }


        List<ResultCarDto> ICarService.TGetCarsWithBrands()
        {
            var entities = carDal.GetCarsWithBrands();
            return entities.Adapt<List<ResultCarDto>>();
        }
    }
}
