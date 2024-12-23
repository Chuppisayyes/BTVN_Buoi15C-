public class ThucPham : SanPham
{
    public double PhiVanChuyen { get; set; }

    public ThucPham(string maSanPham, string tenSanPham, double giaGoc, double phiVanChuyen)
        : base(maSanPham, tenSanPham, giaGoc)
    {
        PhiVanChuyen = phiVanChuyen;
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
