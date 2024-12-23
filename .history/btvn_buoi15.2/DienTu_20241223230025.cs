public class DienTu : SanPham
{
    public double BaoHanh { get; set; }

    public DienTu() 
    {
        LoaiSanPham = "DienTu";
    }

    public DienTu(string maSanPham, string tenSanPham, double giaGoc, double baoHanh)
        : base(maSanPham, tenSanPham, giaGoc)
    {
        BaoHanh = baoHanh;
        LoaiSanPham = "DienTu";
    }

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
