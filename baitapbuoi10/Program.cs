using bai10_DataAccess.DALIpml;
using bai10_DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapbuoi10
{
    public class Program
    {
        static void Main(string[] args)
        {
            Room newroom = new Room
            {
                RoomNumber = 3,
                RoomType = "love",
                Price = 2000,
                IsAvailable = false
            };
            Booking newbooking = new Booking
            {
                BookingId = 1,
                CheckInDate = Convert.ToDateTime("21/05/2024"),
                CheckOutDate = Convert.ToDateTime("30/05/2024"),
                IsCancelled = false,
                IsConfirmed = false,
                Room = newroom,
                TotalAmount = 18000
            };
            ReturnData result = new ReturnData();
            HotelManager hotelManager = new HotelManager();
            Roommanager roommanager = new Roommanager();
            Bookingmanager bookingmanager = new Bookingmanager();
            Console.WriteLine("----------------MenuHotel----------------");
            Console.WriteLine("1.Quản lý danh sách phòng ");
            Console.WriteLine("2.Quản lý thông tin đặt phòng của khách hàng");
            Console.WriteLine("3.Tính năng đặt phòng và thanh toán.");
            Console.WriteLine("4.Tính năng xác nhận và hủy đặt phòng.");
            Console.WriteLine("5.Tính năng xem lịch sử đặt phòng của khách hàng.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Nhập lựa chọn của bạn");
            int choice = Convert.ToInt32(Console.ReadLine());
            int ChoiceManager;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("chọn tính năng quản lý phòng:");
                    Console.WriteLine("1.thêm phòng");
                    Console.WriteLine("2.xóa phòng");
                    Console.WriteLine("3.update phòng");
                    ChoiceManager = Convert.ToInt32(Console.ReadLine());
                    switch (ChoiceManager)
                    {
                        case 1:
                            Console.WriteLine("Nhập phòng cần thêm!");
                            Room roomAdd = new Room();
                            Console.WriteLine("Nhap so phong!");
                            roomAdd.RoomNumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Nhap kieu phong");
                            roomAdd.RoomType = Console.ReadLine();
                            Console.WriteLine("Nhap gia phong");
                            roomAdd.Price = Convert.ToInt32(Console.ReadLine());
                            result = roommanager.Addroom(roomAdd);
                            Console.WriteLine(result.ReturnMsg);
                            break;
                        case 2:
                            Console.WriteLine("Nhap roomnuber can xoa:");
                            int RoomIdDelete = Convert.ToInt32(Console.ReadLine());
                            result = roommanager.DeleteRoom(RoomIdDelete);
                            Console.WriteLine(result.ReturnMsg);
                            break;
                        case 3:
                            Console.WriteLine("Nhập so phong can Update");
                            int RoomNumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Nhap kieu phong");
                            string RoomType = Console.ReadLine();
                            Console.WriteLine("Nhap gia phong");
                            double Price = Convert.ToDouble(Console.ReadLine());
                            result = roommanager.UpdateRoom(RoomNumber, RoomType, Price);
                            Console.WriteLine(result.ReturnMsg);
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ!");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("chọn tính năng quản lý đăt phòng:");
                    Console.WriteLine("1.thêm Booking");
                    Console.WriteLine("2.xóa booking");
                    Console.WriteLine("3.update booking");
                    ChoiceManager = Convert.ToInt32(Console.ReadLine());
                    switch (ChoiceManager)
                    {
                        case 1:
                            result = bookingmanager.AddBooking(newbooking);
                            Console.WriteLine(result.ReturnMsg);
                            break;
                        case 2:
                            Console.WriteLine("Nhap BookingId can xoa:");
                            int BookingIdDelete = Convert.ToInt32(Console.ReadLine());
                            result = bookingmanager.DeleteBooking(BookingIdDelete);
                            Console.WriteLine(result.ReturnMsg);
                            break;
                        case 3:
                            Console.WriteLine("Nhập BookingID can Update");
                            int BookingID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Nhap ngay checkin");
                            DateTime Checkin = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Nhap ngay checkout");
                            DateTime Checkout = Convert.ToDateTime(Console.ReadLine());
                            result = bookingmanager.UpdateBooking(BookingID, Checkin, Checkout);
                            Console.WriteLine(result.ReturnMsg);
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ!");
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("chọn tính năng đặt phòng hoặc thanh toán:");
                    Console.WriteLine("1.Đặt phòng");
                    Console.WriteLine("2.Thanh toán");

                    ChoiceManager = Convert.ToInt32(Console.ReadLine());
                    switch (ChoiceManager)
                    {
                        case 1:
                            Console.WriteLine("Nhập Roomnuber can book");
                            int BookingID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Nhap ngay checkin");
                            DateTime Checkin = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Nhap ngay checkout");
                            DateTime Checkout = Convert.ToDateTime(Console.ReadLine());
                            result = hotelManager.BookRoom(BookingID, Checkin, Checkout);
                            Console.WriteLine(result.ReturnMsg);
                            break;
                        case 2:
                            Console.WriteLine("nhap BookingId can thanh toan");
                            int BooKingIdPay = Convert.ToInt32(Console.ReadLine());
                            result = bookingmanager.PayForBooking(BooKingIdPay);
                            Console.WriteLine(result.ReturnMsg);
                            break;
                        default:
                            Console.WriteLine("lua chon khong hop le");
                            break;
                    }
                    break;
                case 4:
                    Console.WriteLine("chọn tính năng xác nhận hoặc hủy đặt phòng:");
                    Console.WriteLine("1.xác nhận phòng");
                    Console.WriteLine("2.hủy đặt phòng");
                    ChoiceManager = Convert.ToInt32(Console.ReadLine());
                    switch (ChoiceManager)
                    {
                        case 1:
                            Console.WriteLine("nhập booking Id cần xác nhận:");
                            int bookingID= Convert.ToInt32(Console.ReadLine());
                            result=bookingmanager.ConfirmBooking(bookingID);
                            Console.WriteLine(result.ReturnMsg);
                            break;
                        case 2:
                            Console.WriteLine("Nhập booking Id cần hủy:");
                            int _bookingID=Convert.ToInt32(Console.ReadLine());
                            result=bookingmanager.CancelBooking(_bookingID);
                            Console.WriteLine(result.ReturnMsg); 
                         break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ!");
                            break;
                    }break;
                case 5:
                    Console.WriteLine("Nhập tên khách hàng :");
                    string Name= Console.ReadLine();
                    List<Booking> bookingNameCustomer = new List<Booking>();
                    bookingNameCustomer=bookingmanager.GetBookingListCustomer(Name);
                    Console.WriteLine("Danh sách lịch sử đặt phòng của khách hàng:");
                    foreach (var i in bookingNameCustomer)
                    {
                        Console.WriteLine(i);
                    }
                    break;   
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
            Console.ReadKey();
        }
    }
}
