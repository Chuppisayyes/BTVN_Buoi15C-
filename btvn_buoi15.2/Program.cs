using System;

class Program
{
    static void Main(string[] args)
    {
        QuanLySanPham qlSanPham = new QuanLySanPham();
        qlSanPham.DocDuLieuTuFile();

        while (true)
        {
            Console.WriteLine("\n--- Hệ thống quản lý bán hàng ---");
            Console.WriteLine("1. Thêm sản phẩm");
            Console.WriteLine("2. Hiển thị danh sách sản phẩm");
            Console.WriteLine("3. Tính tổng doanh thu");
            Console.WriteLine("4. Xóa sản phẩm");
            Console.WriteLine("5. Thoát");
            Console.Write("Vui lòng chọn chức năng: ");
            int chucNang = int.Parse(Console.ReadLine());

            switch (chucNang)
            {
                case 1:
                    qlSanPham.ThemSanPham();
                    break;
                case 2:
                    qlSanPham.HienThiDanhSachSanPham();
                    break;
                case 3:
                    qlSanPham.TinhTongDoanhThu();
                    break;
                case 4:
                    qlSanPham.XoaSanPham();
                    break;
                case 5:
                    qlSanPham.LuuDuLieuVaoFile();
                    return;
                default:
                    Console.WriteLine("Chức năng không hợp lệ.");
                    break;
            }
        }
    }
}
