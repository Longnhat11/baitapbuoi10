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
    public class HotelManager : DAL.IHotelManagementSystem
    {
        Roommanager roommanager = new Roommanager();
        Bookingmanager bookingmanager = new Bookingmanager();
        public ReturnData BookRoom(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            ReturnData result = new ReturnData();
            try
            {
                //kiểm tra dữ liệu đầu vào
                if (roomNumber <= 0) {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu đầu vào không hợp lệ";
                    return result;
                }
                //Kiểm tra CheckIN Checkout có hợp lệ hay không
                DateTime DateTimeNow = DateTime.Now;
                if (DateTime.Compare(checkIn, DateTimeNow) > 0
                    || DateTime.Compare(checkOut, DateTimeNow) > 0
                    || DateTime.Compare(checkOut, checkIn) > 0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu đầu vào không hợp lệ!";
                    return result;
                }
                //kiểm tra roomNumber có tồn tại hay không 
                var rooms = roommanager.GetRoom(roomNumber);
                if (rooms == null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "phòng không tồn tại!";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
            var _room = roommanager.GetRoom(roomNumber);
            Booking booking = new Booking
            {
                Room = _room,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                TotalAmount = (checkOut - checkIn).TotalDays * _room.Price
            };
            bookingmanager.AddBooking(booking);
            _room.IsAvailable = false;
            result.ReturnCode = 1;
            result.ReturnMsg = "Đã bookrom phòng thành công";
            return result;
        }

       
    }
}
