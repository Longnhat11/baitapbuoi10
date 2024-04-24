using bai10_DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai10_DataAccess.DAL
{
    public interface IBookingManager
    {
        ReturnData AddBooking(Booking booking);
        ReturnData DeleteBooking(int bookingId);
        ReturnData UpdateBooking(int bookingId, DateTime newCheckIn, DateTime newCheckOut);
        ReturnData ConfirmBooking(int bookingId);
        ReturnData CancelBooking(int bookingId);
        Booking GetBooking(int bookingId);
        ReturnData PayForBooking(int bookingId);
        List<Booking> GetBookingListCustomer(string namecustomer);
    }
}
