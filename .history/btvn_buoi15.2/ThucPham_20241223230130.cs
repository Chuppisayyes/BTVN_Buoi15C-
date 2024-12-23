using System;

public class ThucPham : SanPham
{
    public double PhiVanChuyen { get; set; }
    public ThucPham() 
    {
        LoaiSanPham = "ThucPham";
    }
    public override double TinhGiaBan()
    {
        return GiaGoc + PhiVanChuyen;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"(Phí vận chuyển: {PhiVanChuyen})");
    }
}
