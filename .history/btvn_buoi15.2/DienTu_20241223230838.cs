public class DienTu : SanPham
{
    public double BaoHanh { get; set; }

    public DienTu(string maSanPham, string tenSanPham, double giaGoc, double baoHanh)
        : base(maSanPham, tenSanPham, giaGoc)
    {
        BaoHanh = baoHanh;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Thuế bảo hành: {BaoHanh}");
    }

    public override double TinhGiaBan()
    {
        return GiaGoc + BaoHanh; // Ví dụ tính giá bán với bảo hành
    }
}
