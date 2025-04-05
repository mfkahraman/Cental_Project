using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class FeatureService(IFeatureDal featureDal, IMapper mapper) : IFeatureService
    {
        public void TCreate(CreateFeatureDto dto)
        {
            var feature = mapper.Map<Feature>(dto);
            featureDal.Create(feature);
        }

        public void TDelete(int id)
        {
            featureDal.Delete(id);
        }

        public List<ResultServiceDto> TGetAll()
        {
            var features = featureDal.GetAll();
            return mapper.Map<List<ResultServiceDto>>(features);
        }

        public ResultServiceDto TGetById(int id)
        {
            var feature = featureDal.GetById(id);
            return mapper.Map<ResultServiceDto>(feature);
        }

        public void TUpdate(UpdateFeatureDto dto)
        {
            var feature = mapper.Map<Feature>(dto);
            featureDal.Update(feature);
        }
    }
}
