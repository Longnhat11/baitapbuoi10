using bai10_DataAccess.DAL;
using bai10_DataAccess.DTO;
using baitapbuoi10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai10_DataAccess.DALIpml
{
    public class Bookingmanager:bai10_DataAccess.DAL.IBookingManager
    {
        List<Booking> Bookinglist = new List<Booking>();
        public ReturnData AddBooking(Booking booking)
        {
            var result = new ReturnData();
            try
            {
                // kiểm tra dữ liệu đầu vào
                if (booking == null
                    || booking.BookingId <= 0
                    || booking.Room == null
                    || booking.TotalAmount <= 0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";
                    return result;
                }
                // kiểm tra ngày vào và trả có hợp lệ hay không
                DateTime DateTimeNow = DateTime.Now;
                if (DateTime.Compare(booking.CheckInDate, DateTimeNow) > 0
                    || DateTime.Compare(booking.CheckOutDate, DateTimeNow) > 0
                    || DateTime.Compare(booking.CheckOutDate, booking.CheckInDate) > 0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu đầu vào không hợp lệ!";
                    return result;
                }
                // kiểm tra booking ID có trùng không
                var bookings = Bookinglist.Where(s => s.BookingId == booking.BookingId).FirstOrDefault();
                if (bookings != null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Booking đã tồn tại!";
                    return result;
                }
                //kiểm tra tên khách hàng có hợp lệ hay không
                if(booking.namecustomer == null
                    ||checkInput.ContainsNumber(booking.namecustomer)
                    ||checkInput.CheckIsNullOrWhiteSpace(booking.namecustomer)
                    ||checkInput.CheckContainSpecialChar(booking.namecustomer))
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Tên khách hàng không hợp lệ!";
                    return result;
                }
            }
            catch (Exception ex)
            {

                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
            Bookinglist.Add(booking);
            result.ReturnCode = 1;
            result.ReturnMsg = "Đã thêm Booking thành công!";
            return result;
        }
        public ReturnData CancelBooking(int bookingId)
        {
            ReturnData result = new ReturnData();
            try
            {
                //kiểm tra booking ID cần xóa có hợp lệ hay không
                if (bookingId <= 0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                //kiểm tra booking ID có tồn tại hay không
                var bookings = Bookinglist.Where(s => s.BookingId == bookingId).FirstOrDefault();
                if (bookings == null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Booking không tồn tại!";
                    return result;
                }
                //Kiểm tra booking đã confirm chưa
                if (bookings.IsConfirmed == true)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "booking đã confirm không thể hủy !";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
            var booking = Bookinglist.Find(b => b.BookingId == bookingId);
            if (booking != null)
            {
                booking.IsCancelled = true;
                booking.TotalAmount = 0;
            }
            result.ReturnCode = 1;
            result.ReturnMsg = "Đã huỷ booking thành công!";
            return result;
        }

        public ReturnData ConfirmBooking(int bookingId)
        {
            ReturnData result = new ReturnData();
            try
            {
                //kiểm tra booking ID cần confirm có hợp lệ hay không
                if (bookingId <= 0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                //kiểm tra booking ID có tồn tại hay không
                var bookings = Bookinglist.Where(s => s.BookingId == bookingId).FirstOrDefault();
                if (bookings == null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Booking không tồn tại!";
                    return result;
                }
                //Kiểm tra booking đã hủy hay chưa.
                if (bookings.IsCancelled == true)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Booking đã hủy không thể confirm !";
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
            var booking = Bookinglist.Find(b => b.BookingId == bookingId);
            if (booking != null)
            {
                booking.IsConfirmed = true;
            }
            result.ReturnCode = 1;
            result.ReturnMsg = "Đã Confirm booking thành công!";
            return result;
        }

        public ReturnData DeleteBooking(int bookingId)
        {
            ReturnData result = new ReturnData();
            try
            {
                //Kiểm tra dữ liệu đầu vào
                if (bookingId <= 0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "BookingID cần xóa không hợp lệ!";
                    return result;
                }
                //Kiểm tra bookingID có tồn tại không
                var bookings = Bookinglist.Where(s => s.BookingId == bookingId).FirstOrDefault();
                if (bookings == null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Booking không tồn tại!";
                    return result;
                }
                //Kiểm tra booking đã cofirm hay chưa
                if (bookings.IsConfirmed == true)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "booking đã confirm không thể xóa!";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
            Bookinglist.RemoveAll(b => b.BookingId == bookingId);
            result.ReturnCode = 1;
            result.ReturnMsg = "Đã xóa thành công booking có ID: " + bookingId;
            return result;
        }

        public Booking GetBooking(int bookingId)
        {
            var bookings = Bookinglist.Where(s => s.BookingId == bookingId).FirstOrDefault();
            return bookings == null ? null : bookings;
        }

        public List<Booking> GetBookingListCustomer(string namecustomer )
        {
            //Kiểm tra dữ liệu đầu vào
            if(namecustomer == null
                || checkInput.ContainsNumber(namecustomer)
                    || checkInput.CheckIsNullOrWhiteSpace(namecustomer)
                    || checkInput.CheckContainSpecialChar(namecustomer))
            {
                Console.WriteLine("Dữ liệu đầu vào không hợp lệ");
                return null;
            }
            List<Booking> bookingGetNameCustomer = new List<Booking>();
            foreach (var i in Bookinglist)
            {

                if (i.namecustomer == namecustomer)
                {
                    bookingGetNameCustomer.Add(i);
                }
            }
            return bookingGetNameCustomer;
        }
        public ReturnData UpdateBooking(int bookingId, DateTime newCheckIn, DateTime newCheckOut)
        {
            ReturnData result = new ReturnData();
            try
            {
                //Kiểm tra dữ liệu đầu vào
                if(bookingId <=0) {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu đầu vào không hợp lệ!";
                    return result;
                }
                //kiểm tra newCheckIn và newCheckOut có hợp lệ hay không
                DateTime DateTimeNow = DateTime.Now;
                if (DateTime.Compare(newCheckIn, DateTimeNow) > 0
                    || DateTime.Compare(newCheckOut, DateTimeNow) > 0
                    || DateTime.Compare(newCheckOut, newCheckIn) > 0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu đầu vào không hợp lệ!";
                    return result;
                }
                //kiểm tra booking ID có tồn tại hay không
                var bookings = Bookinglist.Where(s => s.BookingId == bookingId).FirstOrDefault();
                if (bookings == null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Booking không tồn tại!";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
            foreach (var b in Bookinglist)
            {
                if(b.BookingId==bookingId)
                {
                    b.BookingId = bookingId;
                    b.CheckInDate = newCheckIn;
                    b.CheckOutDate = newCheckOut;
                }
            }
            result.ReturnCode = 1;
            result.ReturnMsg = "UpdateBooking thành công!";
            return result;
        }
        public ReturnData PayForBooking(int bookingId)
        {
            var result = new ReturnData();
            try
            {
                //kiểm tra dữ liệu đầu vào
                if (bookingId <= 0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu đầu vào không hợp lệ!";
                    return result;
                }
                //Kiểm tra booking Id có tồn tại hay không
                Booking _booking = GetBooking(bookingId);
                if (_booking == null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Booking Id không tồn tại.";
                    return result;
                }
                //Kiểm tra booking đã hủy hay chưa
                if (_booking.IsCancelled == true)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "booking đã hủy!";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
            Booking bookingPay = GetBooking(bookingId);
            if (bookingPay.TotalAmount != (bookingPay.Room.Price * (DateTime.Compare(bookingPay.CheckOutDate, bookingPay.CheckInDate))))
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Tổng tiền không hợp lệ";
                return result;
            }
            else
            {
                foreach(var i in Bookinglist)
                {
                    if(i.BookingId == bookingId)
                    {
                        i.IsConfirmed = true;
                        i.TotalAmount = 0;
                    }
                }
                result.ReturnCode = 1;
                result.ReturnMsg = "Đã thanh toán thành công";
                return result;
            }
        }
    }
}
