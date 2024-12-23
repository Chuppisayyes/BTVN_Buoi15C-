using System;

namespace PaymentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            LichSuGiaoDich lichSu = new LichSuGiaoDich();

            while (true)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Thanh toán bằng tiền mặt");
                Console.WriteLine("2. Thanh toán bằng thẻ");
                Console.WriteLine("3. Thanh toán online");
                Console.WriteLine("4. Xem lịch sử giao dịch");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();

                IThanhToan thanhToan = null;
                double soTien = 0;

                switch (choice)
                {
                    case "1":
                        thanhToan = new ThanhToanTienMat();
                        break;
                    case "2":
                        thanhToan = new ThanhToanBangThe();
                        break;
                    case "3":
                        thanhToan = new ThanhToanOnline();
                        break;
                    case "4":
                        lichSu.XemLichSu();
                        continue;
                    case "5":
                        Console.WriteLine("Thoát chương trình.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        continue;
                }

                Console.Write("Nhập số tiền cần thanh toán: ");
                if (double.TryParse(Console.ReadLine(), out soTien))
                {
                    if (thanhToan != null && thanhToan.ThanhToan(soTien))
                    {
                        lichSu.ThemGiaoDich($"Thanh toán {soTien} VND thành công bằng {thanhToan.GetType().Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Số tiền không hợp lệ.");
                }
            }
        }
    }
}
