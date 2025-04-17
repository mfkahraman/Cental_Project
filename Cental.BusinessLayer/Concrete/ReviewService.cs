using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class ReviewService(IMapper mapper, IReviewDal reviewDal) : IReviewService
    {
        public void TCreate(CreateReviewDto dto)
        {
            var review = mapper.Map<Review>(dto);
            reviewDal.Create(review);
        }

        public void TDelete(int id)
        {
            reviewDal.Delete(id);
        }

        public List<ResultReviewDto> TGetAll()
        {
            var reviews = reviewDal.GetAll();
            return mapper.Map<List<ResultReviewDto>>(reviews);
        }

        public ResultReviewDto TGetById(int id)
        {
            var review = reviewDal.GetById(id);
            return mapper.Map<ResultReviewDto>(review);
        }

        public void TUpdate(UpdateReviewDto dto)
        {
            var review = mapper.Map<Review>(dto);
            reviewDal.Update(review);
        }
    }
}
