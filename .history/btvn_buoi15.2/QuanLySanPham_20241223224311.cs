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
        int loai = int.Parse(Console.ReadLine());
        SanPham sanPham = null;

        Console.Write("Nhập mã sản phẩm: ");
        string maSP = Console.ReadLine();
        Console.Write("Nhập tên sản phẩm: ");
        string tenSP = Console.ReadLine();
        Console.Write("Nhập giá gốc: ");
        double giaGoc = double.Parse(Console.ReadLine());

        switch (loai)
        {
            case 1:
                sanPham = new DienTu { aSanPham = maSP, TenSanPham = tenSP, GiaGoc = giaGoc };
                Console.Write("Nhập thuế bảo hành: ");
                ((DienTu)sanPham).BaoHanh = double.Parse(Console.ReadLine());
                break;
            case 2:
                sanPham = new ThoiTrang { maSanPham = maSP, TenSanPham = tenSP, GiaGoc = giaGoc };
                Console.Write("Nhập giảm giá: ");
                ((ThoiTrang)sanPham).GiamGia = double.Parse(Console.ReadLine());
                break;
            case 3:
                sanPham = new ThucPham { maSanPham = maSP, tenSanPham = tenSP, GiaGoc = giaGoc };
                Console.Write("Nhập phí vận chuyển: ");
                ((ThucPham)sanPham).PhiVanChuyen = double.Parse(Console.ReadLine());
                break;
            default:
                Console.WriteLine("Loại sản phẩm không hợp lệ.");
                return;
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
            Console.WriteLine(sp.HienThiThongTin());
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
