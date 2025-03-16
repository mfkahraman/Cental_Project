using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.BookingDtos
{
    public class ResultBookingDto
    {
        public int BookingId { get; set; }

        public string PickupLocation { get; set; }

        public string DropoffLocation { get; set; }

        public DateTime PickupDate { get; set; }

        public DateTime DropoffDate { get; set; }

        public string? Status { get; set; }
        public bool? IsCancel { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
    }
}
