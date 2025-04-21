using Cental.DtoLayer.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.CarDtos
{
    public class CreateCarDto
    {
        public string ModelName { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int SeatCount { get; set; }
        public int Kilometer { get; set; }
        public int BrandId { get; set; }
        public string ImageUrl { get; set; }

        public GasTypes GasType { get; set; }
        public GearTypes GearType { get; set; }
        public Transmissions Transmission { get; set; }

        public IFormFile ImageFile { get; set; }   
    }

}
