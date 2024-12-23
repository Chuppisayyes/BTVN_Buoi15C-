using System;

public class DienTu : SanPham
{
    public double BaoHanh { get; set; }

    public override double TinhGiaBan()
    {
        return GiaGoc + BaoHanh;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"(Bảo hành: {BaoHanh})");
    }
}
