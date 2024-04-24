using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai10_DataAccess.DTO
{
    public class Booking
    {
        public int BookingId { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCancelled { get; set; }
        public double TotalAmount { get; set; }
        public string namecustomer {  get; set; }
    }
}
