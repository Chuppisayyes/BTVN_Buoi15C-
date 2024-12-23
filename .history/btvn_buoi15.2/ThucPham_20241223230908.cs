public class ThucPham : SanPham
{
    public double PhiVanChuyen { get; set; }

    public ThucPham(string maSanPham, string tenSanPham, double giaGoc, double phiVanChuyen)
        : base(maSanPham, tenSanPham, giaGoc)
    {
        PhiVanChuyen = phiVanChuyen;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Phí vận chuyển: {PhiVanChuyen}");
    }

    public override double TinhGiaBan()
    {
        return GiaGoc + PhiVanChuyen; // Ví dụ tính giá bán với phí vận chuyển
    }
}