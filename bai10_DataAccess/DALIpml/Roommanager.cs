using bai10_DataAccess.DTO;
using baitapbuoi10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai10_DataAccess.DALIpml
{
    public class Roommanager:bai10_DataAccess.DAL.IRoommanager
    {
        List<Room> Roomlist = new List<Room>();
        public ReturnData Addroom(Room room)
        {
            var result = new ReturnData();
            try
            {
                //kiểm tra dữ liệu đầu vào.
                if (room == null
                    || room.RoomNumber <= 0
                    || room.IsAvailable == true
                    || room.Price <= 0
                    || room.RoomType!=null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ.";
                    return result;
                }
                //Kiểm tra roomtype có hợp lệ hay không
                if(checkInput.CheckIsNullOrWhiteSpace(room.RoomType)
                    ||checkInput.CheckContainSpecialChar(room.RoomType))
                {
                    result.ReturnCode= -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ.";
                    return result;
                }
                // kiểm tra Roomnumber có trùng không
                var rooms = Roomlist.Where(s => s.RoomNumber == room.RoomNumber).FirstOrDefault();
                if (rooms != null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "phòng đã tồn tại!";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
            Roomlist.Add(room);
            result.ReturnCode = 1;
            result.ReturnMsg = "Đã thêm phòng thành công!";
            return result;
        }
        public ReturnData DeleteRoom(int roomNumber)
        {
            ReturnData result = new ReturnData();
            try
            {
                //Kiểm tra dữ liệu đầu vào
                if (roomNumber <= 0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                //Kiểm tra rooNumber có tồn tại hay không
                var rooms = Roomlist.Where(s => s.RoomNumber == roomNumber).FirstOrDefault();
                if (rooms != null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "phòng đã tồn tại!";
                    return result;
                }
                //Kiểm tra phòng đã được đặt hay chưa
                if (rooms.IsAvailable == true)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Phòng đã được đặt không thể xóa!";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
            // Xóa phòng khỏi danh sách
            Roomlist.RemoveAll(r => r.RoomNumber == roomNumber);
            result.ReturnCode = 1;
            result.ReturnMsg = "Đã xóa phòng thành công!";
            return result;
        }

        public  Room GetRoom(int roomNumber)
        {
            if(roomNumber <= 0)
            {  return null; }
            var rooms = Roomlist.Where(s => s.RoomNumber == roomNumber).FirstOrDefault();
            return rooms;
        }

        public ReturnData UpdateRoom(int roomNumber, string newRoomType, double newPrice)
        {
            ReturnData result =new ReturnData();
            try
            {
                //Kiểm tra dữ liệu đầu vào
                if (roomNumber <= 0
                    || newRoomType==null
                    || newPrice<=0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ.";
                    return result;
                }
                //kiểm tra newRoomtype có hợp lệ hay không
                if (checkInput.CheckIsNullOrWhiteSpace(newRoomType)
                    || checkInput.CheckContainSpecialChar(newRoomType))
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ.";
                    return result;
                }
                //kiểm tra roomNumber có tồn tại hay không
                var rooms = Roomlist.Where(s => s.RoomNumber == roomNumber).FirstOrDefault();
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
            foreach (var b in Roomlist)
            {
                if (b.RoomNumber==roomNumber)
                {
                    b.RoomNumber = roomNumber;
                    b.RoomType = newRoomType;
                    b.Price= newPrice;
                }
            }
            result.ReturnCode = 1;
            result.ReturnMsg = "UpdateRoom thành công!";
            return result;
        }
    }
}
