using System;

public abstract class SanPham
{
    public string MaSanPham { get; set; }
    public string TenSanPham { get; set; }
    public double GiaGoc { get; set; }

    public abstract double TinhGiaBan();

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Mã: {MaSanPham}, Tên: {TenSanPham}, Giá gốc: {GiaGoc}, Giá bán: {TinhGiaBan()}");
    }
}
