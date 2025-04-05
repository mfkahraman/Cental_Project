using Cental.DtoLayer.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IServiceService
    {
        List<ResultServiceDto> TGetAll();
        ResultServiceDto TGetById(int id);
        void TDelete(int id);
        void TCreate(CreateServiceDto dto);
        void TUpdate(UpdateServiceDto dto);
    }
}
