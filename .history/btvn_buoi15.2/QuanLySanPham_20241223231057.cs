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
        string inputLoai = Console.ReadLine();
        int loai = 0;
        if (!int.TryParse(inputLoai, out loai) || loai < 1 || loai > 3)
        {
            Console.WriteLine("Loại sản phẩm không hợp lệ.");
            return;
        }

        Console.Write("Nhập mã sản phẩm: ");
        string maSP = Console.ReadLine();
        Console.Write("Nhập tên sản phẩm: ");
        string tenSP = Console.ReadLine();

        Console.Write("Nhập giá gốc: ");
        string inputGiaGoc = Console.ReadLine();
        double giaGoc;
        if (!double.TryParse(inputGiaGoc, out giaGoc))
        {
            Console.WriteLine("Giá gốc không hợp lệ.");
            return;
        }

        SanPham sanPham = null;

        switch (loai)
        {
            case 1:
                Console.Write("Nhập thuế bảo hành: ");
                string inputBaoHanh = Console.ReadLine();
                double baoHanh;
                if (!double.TryParse(inputBaoHanh, out baoHanh))
                {
                    Console.WriteLine("Thuế bảo hành không hợp lệ.");
                    return;
                }
                sanPham = new DienTu(maSP, tenSP, giaGoc, baoHanh);
                break;

            case 2:
                Console.Write("Nhập giảm giá: ");
                string inputGiamGia = Console.ReadLine();
                double giamGia;
                if (!double.TryParse(inputGiamGia, out giamGia))
                {
                    Console.WriteLine("Giảm giá không hợp lệ.");
                    return;
                }
                sanPham = new ThoiTrang(maSP, tenSP, giaGoc, giamGia);
                break;

            case 3:
                Console.Write("Nhập phí vận chuyển: ");
                string inputPhiVanChuyen = Console.ReadLine();
                double phiVanChuyen;
                if (!double.TryParse(inputPhiVanChuyen, out phiVanChuyen))
                {
                    Console.WriteLine("Phí vận chuyển không hợp lệ.");
                    return;
                }
                // Khởi tạo đối tượng ThucPham với đủ tham số
                sanPham = new ThucPham(maSP, tenSP, giaGoc, phiVanChuyen);
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
            var tempList = JsonConvert.DeserializeObject<List<SanPham>>(json);
            danhSachSanPham.Clear();

            foreach (var item in tempList)
            {
                if (item.LoaiSanPham == "DienTu")
                {
                    var dienTu = JsonConvert.DeserializeObject<DienTu>(item.ToString());
                    danhSachSanPham.Add(dienTu);
                }
                else if (item.LoaiSanPham == "ThoiTrang")
                {
                    var thoiTrang = JsonConvert.DeserializeObject<ThoiTrang>(item.ToString());
                    danhSachSanPham.Add(thoiTrang);
                }
                else if (item.LoaiSanPham == "ThucPham")
                {
                    var thucPham = JsonConvert.DeserializeObject<ThucPham>(item.ToString());
                    danhSachSanPham.Add(thucPham);
                }
                else
                {
                    Console.WriteLine("Không xác định được loại sản phẩm.");
                }
            }
        }
        else
        {
            Console.WriteLine("Không tìm thấy file dữ liệu.");
        }
    }


}
