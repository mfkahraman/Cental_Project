using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Booking : BaseEntity
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public string PickupLocation { get; set; }

        [Required]
        public string DropoffLocation { get; set; }

        [Required]
        public DateTime PickupDate { get; set; }

        [Required]
        public DateTime DropoffDate { get; set; }

        public string? Status { get; set; }
        public bool? IsCancel { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

    }
}
