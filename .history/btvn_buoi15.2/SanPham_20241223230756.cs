public class SanPham
{
    public string MaSanPham { get; set; }
    public string TenSanPham { get; set; }
    public double GiaGoc { get; set; }

    // Constructor mặc định
    public SanPham() { }

    // Constructor với 3 tham số
    public SanPham(string maSanPham, string tenSanPham, double giaGoc)
    {
        MaSanPham = maSanPham;
        TenSanPham = tenSanPham;
        GiaGoc = giaGoc;
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Mã sản phẩm: {MaSanPham}, Tên sản phẩm: {TenSanPham}, Giá gốc: {GiaGoc}");
    }

    public virtual double TinhGiaBan()
    {
        return GiaGoc;
    }
}
