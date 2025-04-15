using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.ReviewDtos
{
    public class CreateReviewDto
    {
        public int Rating { get; set; }
        public int CarId { get; set; }
    }
}
