using System;

public class ThoiTrang : SanPham
{
    public double GiamGia { get; set; }
    public ThoiTrang() 
    {
        LoaiSanPham = "ThoiTrang";
    }
    public override double TinhGiaBan()
    {
        return GiaGoc - GiamGia;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"(Giảm giá: {GiamGia})");
    }
}
