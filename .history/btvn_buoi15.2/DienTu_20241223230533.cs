public class DienTu : SanPham
{
    public double BaoHanh { get; set; }
    public override string LoaiSanPham => "DienTu";  // Thêm thuộc tính này

    public DienTu(string maSanPham, string tenSanPham, double giaGoc, double baoHanh)
        : base(maSanPham, tenSanPham, giaGoc)
    {
        BaoHanh = baoHanh;
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
