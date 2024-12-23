using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class QuanLySanPham
{
    private List<SanPham> danhSachSanPham = new List<SanPham>();
    private const string filePath = "sanpham.json";

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
