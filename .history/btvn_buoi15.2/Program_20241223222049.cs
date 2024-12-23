using System;
using System.Collections.Generic;
using System.IO;

namespace QuanLySanPham
{
    class Program
    {
        static List<SanPham> danhSachSanPham = new List<SanPham>();
        const string filePath = "danhSachSanPham.txt";

        static void Main(string[] args)
        {
            DocDuLieuTuFile();

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
                    case 1: ThemSanPham(); break;
                    case 2: HienThiSanPham(); break;
                    case 3: TinhTongDoanhThu(); break;
                    case 4: XoaSanPham(); break;
                    case 5: LuuDuLieuXuongFile(); break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
            } while (choice != 5);
        }

        static void ThemSanPham()
        {
            Console.WriteLine("Chọn loại sản phẩm: 1-Điện tử, 2-Thời trang, 3-Thực phẩm");
            int loai = int.Parse(Console.ReadLine());

            Console.Write("Mã sản phẩm: ");
            string ma = Console.ReadLine();
            Console.Write("Tên sản phẩm: ");
            string ten = Console.ReadLine();
            Console.Write("Giá gốc: ");
            double gia = double.Parse(Console.ReadLine());

            switch (loai)
            {
                case 1:
                    Console.Write("Chi phí bảo hành: ");
                    double baoHanh = double.Parse(Console.ReadLine());
                    danhSachSanPham.Add(new DienTu(ma, ten, gia, baoHanh));
                    break;
                case 2:
                    Console.Write("Giảm giá: ");
                    double giamGia = double.Parse(Console.ReadLine());
                    danhSachSanPham.Add(new ThoiTrang(ma, ten, gia, giamGia));
                    break;
                case 3:
                    Console.Write("Phí vận chuyển: ");
                    double phiVanChuyen = double.Parse(Console.ReadLine());
                    danhSachSanPham.Add(new ThucPham(ma, ten, gia, phiVanChuyen));
                    break;
                default:
                    Console.WriteLine("Loại sản phẩm không hợp lệ!");
                    break;
            }
        }

        static void HienThiSanPham()
        {
            Console.WriteLine("\nDanh sách sản phẩm:");
            foreach (var sp in danhSachSanPham)
            {
                sp.HienThiThongTin();
            }
        }

        static void TinhTongDoanhThu()
        {
            double tongDoanhThu = 0;
            foreach (var sp in danhSachSanPham)
            {
                tongDoanhThu += sp.TinhGiaBan();
            }
            Console.WriteLine($"Tổng doanh thu dự kiến: {tongDoanhThu}");
        }

        static void XoaSanPham()
        {
            Console.Write("Nhập mã sản phẩm cần xóa: ");
            string ma = Console.ReadLine();
            var sp = danhSachSanPham.Find(x => x.MaSanPham == ma);

            if (sp != null)
            {
                danhSachSanPham.Remove(sp);
                Console.WriteLine("Xóa sản phẩm thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm!");
            }
        }

        static void DocDuLieuTuFile()
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    string loai = parts[0];
                    string ma = parts[1];
                    string ten = parts[2];
                    double gia = double.Parse(parts[3]);
                    double phuThu = double.Parse(parts[4]);

                    if (loai == "DienTu")
                        danhSachSanPham.Add(new DienTu(ma, ten, gia, phuThu));
                    else if (loai == "ThoiTrang")
                        danhSachSanPham.Add(new ThoiTrang(ma, ten, gia, phuThu));
                    else if (loai == "ThucPham")
                        danhSachSanPham.Add(new ThucPham(ma, ten, gia, phuThu));
                }
            }
        }

        static void LuuDuLieuXuongFile()
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var sp in danhSachSanPham)
                {
                    string loai
