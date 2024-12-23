using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace QuanLySanPham
{
    public class QuanLySanPham
    {
        private List<SanPham> danhSachSanPham;
        private const string filePath = "danhSachSanPham.json";

        public QuanLySanPham()
        {
            danhSachSanPham = new List<SanPham>();
            DocDuLieuTuFile();
        }

        public void ThemSanPham()
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

        public void HienThiSanPham()
        {
            Console.WriteLine("\nDanh sách sản phẩm:");
            foreach (var sp in danhSachSanPham)
            {
                sp.HienThiThongTin();
            }
        }

        public void TinhTongDoanhThu()
        {
            double tongDoanhThu = 0;
            foreach (var sp in danhSachSanPham)
            {
                tongDoanhThu += sp.TinhGiaBan();
            }
            Console.WriteLine($"Tổng doanh thu dự kiến: {tongDoanhThu}");
        }

        public void XoaSanPham()
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

        public void DocDuLieuTuFile()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(filePath);
                    var sanPhams = JsonSerializer.Deserialize<List<JsonSanPham>>(jsonData);

                    foreach (var item in sanPhams)
                    {
                        switch (item.Loai)
                        {
                            case "DienTu":
                                danhSachSanPham.Add(new DienTu(item.MaSanPham, item.TenSanPham, item.GiaGoc, item.PhuThu));
                                break;
                            case "ThoiTrang":
                                danhSachSanPham.Add(new ThoiTrang(item.MaSanPham, item.TenSanPham, item.GiaGoc, item.PhuThu));
                                break;
                            case "ThucPham":
                                danhSachSanPham.Add(new ThucPham(item.MaSanPham, item.TenSanPham, item.GiaGoc, item.PhuThu));
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
                }
            }
        }

        public void LuuDuLieuXuongFile()
        {
            var sanPhams = new List<JsonSanPham>();

            foreach (var sp in danhSachSanPham)
            {
                string loai = sp.GetType().Name;
                double phuThu = 0;

                if (sp is DienTu) phuThu = ((DienTu)sp).BaoHanh;
                else if (sp is ThoiTrang) phuThu = ((ThoiTrang)sp).GiamGia;
                else if (sp is ThucPham) phuThu = ((ThucPham)sp).PhiVanChuyen;

                sanPhams.Add(new JsonSanPham
                {
                    Loai = loai,
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham,
                    GiaGoc = sp.GiaGoc,
                    PhuThu = phuThu
                });
            }

            try
            {
                string jsonData = JsonSerializer.Serialize(sanPhams, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonData);
                Console.WriteLine("Dữ liệu đã được lưu!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu file: {ex.Message}");
            }
        }
    }
}
