using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace QuanLyBanHang
{
    public class QuanLySanPham
    {
        private List<SanPham> danhSachSanPham = new List<SanPham>();
        private const string FileName = "danhSachSanPham.json";

        public QuanLySanPham()
        {
            DocDuLieuTuFile();
        }

        public void ThemSanPham(SanPham sanPham)
        {
            danhSachSanPham.Add(sanPham);
            Console.WriteLine("Sản phẩm đã được thêm vào danh sách.");
            LuuDuLieuXuongFile();
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
                LuuDuLieuXuongFile();
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm với mã này.");
            }
        }

        private void LuuDuLieuXuongFile()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(danhSachSanPham, options);
                File.WriteAllText(FileName, json);
                Console.WriteLine("Dữ liệu đã được lưu xuống file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu file: {ex.Message}");
            }
        }

        private void DocDuLieuTuFile()
        {
            if (File.Exists(FileName))
            {
                try
                {
                    var json = File.ReadAllText(FileName);
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    danhSachSanPham = JsonSerializer.Deserialize<List<SanPham>>(json, options);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
                }
            }
        }
    }
}
