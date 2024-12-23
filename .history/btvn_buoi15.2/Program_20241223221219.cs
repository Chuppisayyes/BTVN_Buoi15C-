using System;

namespace QuanLyBanHang
{
    class Program
    {
        static void Main(string[] args)
        {
            QuanLySanPham quanLySanPham = new QuanLySanPham();

            while (true)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Thêm sản phẩm");
                Console.WriteLine("2. Hiển thị danh sách sản phẩm");
                Console.WriteLine("3. Tính tổng doanh thu");
                Console.WriteLine("4. Xóa sản phẩm");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Nhập loại sản phẩm (DienTu, ThoiTrang, ThucPham): ");
                        string loai = Console.ReadLine();
                        Console.Write("Nhập mã sản phẩm: ");
                        string maSP = Console.ReadLine();
                        Console.Write("Nhập tên sản phẩm: ");
                        string tenSP = Console.ReadLine();
                        Console.Write("Nhập giá gốc: ");
                        double giaGoc = double.Parse(Console.ReadLine());

                        SanPham sanPham = loai switch
                        {
                            "DienTu" => new DienTu(maSP, tenSP, giaGoc),
                            "ThoiTrang" => new ThoiTrang(maSP, tenSP, giaGoc),
                            "ThucPham" => new ThucPham(maSP, tenSP, giaGoc),
                            _ => null
                        };

                        if (sanPham != null)
                        {
                            quanLySanPham.ThemSanPham(sanPham);
                        }
                        else
                        {
                            Console.WriteLine("Loại sản phẩm không hợp lệ.");
                        }
                        break;

                    case "2":
                        quanLySanPham.HienThiDanhSach();
                        break;

                    case "3":
                        quanLySanPham.TinhTongDoanhThu();
                        break;

                    case "4":
                        Console.Write("Nhập mã sản phẩm cần xóa: ");
                        string maCanXoa = Console.ReadLine();
                        quanLySanPham.XoaSanPham(maCanXoa);
                        break;

                    case "5":
                        Console.WriteLine("Thoát chương trình.");
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }
    }
}
