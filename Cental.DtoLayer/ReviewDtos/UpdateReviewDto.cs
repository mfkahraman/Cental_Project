using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.ReviewDtos
{
    public class UpdateReviewDto
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public int CarId { get; set; }
    }
}
