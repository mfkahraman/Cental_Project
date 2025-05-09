﻿using Cental.DtoLayer.BrandDtos;
using Cental.DtoLayer.ReviewDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.CarDtos
{
    public class ResultCarDto
    {
        public int CarId { get; set; }
        public string? ModelName { get; set; }
        public string? ImageUrl { get; set; }
        public int SeatCount { get; set; }
        public string? GasType { get; set; }
        public int Year { get; set; }
        public string? Transmission { get; set; }
        public string? GearType { get; set; }
        public int Kilometer { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }

        public ResultBrandDto Brand { get; set; }
        public List<ResultReviewDto>? Reviews { get; set; }

    }
}
