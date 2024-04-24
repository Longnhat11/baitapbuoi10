using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai10_DataAccess.DTO
{
    public class Room
    {
        public int RoomNumber  { get; set; }
        public bool IsAvailable { get; set; }
        public string RoomType { get; set; }
        public double Price { get; set; }
    }
}
