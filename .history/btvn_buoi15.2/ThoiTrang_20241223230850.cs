public class ThoiTrang : SanPham
{
    public double GiamGia { get; set; }

    // Constructor với 4 tham số, gọi constructor của lớp cha với 3 tham số
    public ThoiTrang(string maSanPham, string tenSanPham, double giaGoc, double giamGia)
        : base(maSanPham, tenSanPham, giaGoc)
    {
        GiamGia = giamGia;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Giảm giá: {GiamGia}");
    }

    public override double TinhGiaBan()
    {
        return GiaGoc - GiamGia; // Ví dụ tính giá bán với giảm giá
    }
}