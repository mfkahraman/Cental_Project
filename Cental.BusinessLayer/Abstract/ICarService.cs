using Cental.DtoLayer.CarDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface ICarService
    {
        public List<ResultCarDto> TGetCarsWithBrands();
        List<ResultCarDto> TGetAll();
        ResultCarDto TGetById(int id);
        void TDelete(int id);
        void TCreate(CreateCarDto dto);
        void TUpdate(UpdateCarDto dto);
    }
}
