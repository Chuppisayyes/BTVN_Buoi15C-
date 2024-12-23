using System;
using System.Collections.Generic;

namespace QuanLyBanHang
{
    public class QuanLySanPham
    {
        private List<SanPham> danhSachSanPham = new List<SanPham>();

        public void ThemSanPham(SanPham sanPham)
        {
            danhSachSanPham.Add(sanPham);
            Console.WriteLine("Sản phẩm đã được thêm vào danh sách.");
        }

        public void HienThiDanhSach()
        {
            Console.WriteLine("\n--- Danh sách sản phẩm ---");
            foreach (var sanPham in danhSachSanPham)
            {
                sanPham.HienThiThongTin();
                Console.WriteLine();
            }
        }

        public void TinhTongDoanhThu()
        {
            double tongDoanhThu = 0;
            foreach (var sanPham in danhSachSanPham)
            {
                tongDoanhThu += sanPham.TinhGiaBan();
            }

            Console.WriteLine($"Tổng doanh thu dự kiến: {tongDoanhThu}");
        }

        public void XoaSanPham(string maSanPham)
        {
            var sanPham = danhSachSanPham.Find(sp => sp.MaSanPham == maSanPham);
            if (sanPham != null)
            {
                danhSachSanPham.Remove(sanPham);
                Console.WriteLine("Sản phẩm đã được xóa.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm với mã này.");
            }
        }
    }
}
