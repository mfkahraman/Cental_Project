using AutoMapper;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Mappings
{
    public class ReviewMapping : Profile
    {
        public ReviewMapping()
        {
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>().ReverseMap();
            CreateMap<Review, ResultReviewDto>();
        }
    }
}
