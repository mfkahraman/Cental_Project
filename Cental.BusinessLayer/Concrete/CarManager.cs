using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class CarManager (ICarDal _carDal): ICarService
    {

        public void TCreate(Car entity)
        {
            _carDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _carDal.Delete(id);
        }

        public List<Car> TGetAll()
        {
            var values=_carDal.GetAll();
            return values;

        }

        public Car TGetById(int id)
        {
            var car = _carDal.GetById(id);
            return car;
        }

        public List<Car> TGetCarsWithBrands()
        {
            return _carDal.GetCarsWithBrands();
        }

        public void TUpdate(Car entity)
        {
            _carDal.Update(entity);
        }
    }
}
