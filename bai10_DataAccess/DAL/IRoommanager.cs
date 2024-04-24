using bai10_DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai10_DataAccess.DAL
{
    public interface IRoommanager
    {
        ReturnData Addroom(Room room);
        ReturnData DeleteRoom(int roomNumber);
        Room GetRoom(int roomNumber);
        ReturnData UpdateRoom(int roomNumber, string newRoomType, double newPrice);
    }
}
