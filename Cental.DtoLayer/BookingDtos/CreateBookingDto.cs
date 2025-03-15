using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.BookingDtos
{
    public class CreateBookingDto
    {
        public string PickupLocation { get; set; }

        public string DropoffLocation { get; set; }

        public DateTime PickupDate { get; set; }

        public DateTime DropoffDate { get; set; }

        public string? Status { get; set; }
        public bool? IsCancel { get; set; }

        public int CarId { get; set; }
    }
}
