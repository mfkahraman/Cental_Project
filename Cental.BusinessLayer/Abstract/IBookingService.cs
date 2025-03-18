using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IBookingService
    {
        List<ResultBookingDto> TGetAll();
        ResultBookingDto TGetById(int id);
        void TDelete(int id);
        void TCreate(CreateBookingDto dto);
        void TUpdate(UpdateBookingDto dto);
        void TCancelByUser(int id);
        void TAcceptBooking(int id);
        void TDeclineBooking(int id);
    }
}
