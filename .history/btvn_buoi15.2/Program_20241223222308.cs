using System;

namespace QuanLySanPham
{
    class Program
    {
        static void Main(string[] args)
        {
            QuanLySanPham quanLySanPham = new QuanLySanPham();

            int choice;
            do
            {
                Console.WriteLine("\n--- QUẢN LÝ SẢN PHẨM ---");
                Console.WriteLine("1. Thêm sản phẩm");
                Console.WriteLine("2. Hiển thị danh sách sản phẩm");
                Console.WriteLine("3. Tính tổng doanh thu dự kiến");
                Console.WriteLine("4. Xóa sản phẩm theo mã");
                Console.WriteLine("5. Lưu và thoát");
                Console.Write("Chọn: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: quanLySanPham.ThemSanPham(); break;
                    case 2: quanLySanPham.HienThiSanPham(); break;
                    case 3: quanLySanPham.TinhTongDoanhThu(); break;
                    case 4: quanLySanPham.XoaSanPham(); break;
                    case 5: quanLySanPham.LuuDuLieuXuongFile(); break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
            } while (choice != 5);
        }
    }
}
