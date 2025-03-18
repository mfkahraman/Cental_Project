using Cental.DtoLayer.BookingDtos;
using Cental.DtoLayer.FeatureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IFeatureService
    {
        List<ResultFeatureDto> TGetAll();
        ResultFeatureDto TGetById(int id);
        void TDelete(int id);
        void TCreate(CreateFeatureDto dto);
        void TUpdate(UpdateFeatureDto dto);

    }
}
