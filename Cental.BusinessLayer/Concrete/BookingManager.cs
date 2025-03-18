using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    class BookingManager( IBookingDal bookingDal) : IBookingService
    {
        public void TAcceptBooking(int id)
        {
            var booking = bookingDal.GetById(id);
            booking.Status = "Onaylandı";
            bookingDal.Update(booking);
        }

        public void TCancelByUser(int id)
        {
            var booking = bookingDal.GetById(id);
            if (booking != null)
            {
                booking.Status = "Kullanıcı tarafından iptal edildi";
                booking.IsCancel = true;
                bookingDal.Update(booking);
            }
        }

        public void TCreate(CreateBookingDto dto)
        {
            var entity = dto.Adapt<Booking>();
            bookingDal.Create(entity);
        }

        public void TDeclineBooking(int id)
        {
            var booking = bookingDal.GetById(id);
            booking.Status = "Reddedildi";
            bookingDal.Update(booking);
        }

        public void TDelete(int id)
        {
            bookingDal.Delete(id);
        }

        public List<ResultBookingDto> TGetAll()
        {
            var bookings = bookingDal.GetAll();
            return bookings.Adapt<List<ResultBookingDto>>();
        }

        public ResultBookingDto TGetById(int id)
        {
            var booking = bookingDal.GetById(id);
            return booking.Adapt<ResultBookingDto>();
        }

        public void TUpdate(UpdateBookingDto dto)
        {
            var entity = dto.Adapt<Booking>();
            bookingDal.Update(entity);
        }
    }
}
