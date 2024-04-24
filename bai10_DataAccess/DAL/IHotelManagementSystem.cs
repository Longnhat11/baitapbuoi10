using bai10_DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai10_DataAccess.DAL
{
    public interface IHotelManagementSystem
    {
        ReturnData BookRoom(int roomNumber, DateTime checkIn, DateTime checkOut);
    }
}
