using Cental.DtoLayer.FeatureDtos;
using Cental.DtoLayer.ReviewDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IReviewService
    {
        List<ResultReviewDto> TGetAll();
        ResultReviewDto TGetById(int id);
        void TDelete(int id);
        void TCreate(CreateReviewDto dto);
        void TUpdate(UpdateReviewDto dto);
    }
}