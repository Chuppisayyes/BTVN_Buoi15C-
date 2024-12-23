using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class QuanLySanPham
{
    private List<SanPham> danhSachSanPham = new List<SanPham>();
    private const string filePath = "sanpham.json";

    public void ThemSanPham()
    {
        Console.WriteLine("Chọn loại sản phẩm: 1. Điện tử  2. Thời trang  3. Thực phẩm");
        if (!int.TryParse(Console.ReadLine(), out int loai) || loai < 1 || loai > 3)
        {
            Console.WriteLine("Loại sản phẩm không hợp lệ.");
            return;
        }

        Console.Write("Nhập mã sản phẩm: ");
        string maSP = Console.ReadLine();
        Console.Write("Nhập tên sản phẩm: ");
        string tenSP = Console.ReadLine();
        Console.Write("Nhập giá gốc: ");
        if (!double.TryParse(Console.ReadLine(), out double giaGoc))
        {
            Console.WriteLine("Giá gốc không hợp lệ.");
            return;
        }

        SanPham sanPham = loai switch
        {
            1 => new DienTu(),
            2 => new ThoiTrang(),
            3 => new ThucPham(),
            _ => null
        };

        sanPham.MaSanPham = maSP;
        sanPham.TenSanPham = tenSP;
        sanPham.GiaGoc = giaGoc;

        if (sanPham is DienTu dienTu)
        {
            Console.Write("Nhập thuế bảo hành: ");
            dienTu.BaoHanh = double.Parse(Console.ReadLine());
        }
        else if (sanPham is ThoiTrang thoiTrang)
        {
            Console.Write("Nhập giảm giá: ");
            thoiTrang.GiamGia = double.Parse(Console.ReadLine());
        }
        else if (sanPham is ThucPham thucPham)
        {
            Console.Write("Nhập phí vận chuyển: ");
            thucPham.PhiVanChuyen = double.Parse(Console.ReadLine());
        }

        danhSachSanPham.Add(sanPham);
        Console.WriteLine("Thêm sản phẩm thành công.");
    }

    public void HienThiDanhSachSanPham()
    {
        if (danhSachSanPham.Count == 0)
        {
            Console.WriteLine("Danh sách sản phẩm trống.");
            return;
        }

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

        Console.WriteLine($"Tổng doanh thu dự kiến: {tongDoanhThu} VNĐ");
    }

    public void XoaSanPham()
    {
        Console.Write("Nhập mã sản phẩm cần xóa: ");
        string maSP = Console.ReadLine();

        var spXoa = danhSachSanPham.Find(sp => sp.MaSanPham == maSP);
        if (spXoa != null)
        {
            danhSachSanPham.Remove(spXoa);
            Console.WriteLine("Xóa sản phẩm thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sản phẩm.");
        }
    }

    public void LuuDuLieuVaoFile()
    {
        var json = JsonConvert.SerializeObject(danhSachSanPham, Formatting.Indented);
        File.WriteAllText(filePath, json);
        Console.WriteLine("Dữ liệu đã được lưu.");
    }

    public void DocDuLieuTuFile()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            danhSachSanPham = JsonConvert.DeserializeObject<List<SanPham>>(json) ?? new List<SanPham>();
        }
    }
}
