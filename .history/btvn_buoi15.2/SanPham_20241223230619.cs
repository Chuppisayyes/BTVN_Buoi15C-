public abstract class SanPham
{
    public string MaSanPham { get; set; }
    public string TenSanPham { get; set; }
    public double GiaGoc { get; set; }
    public abstract string LoaiSanPham { get; } 

    public abstract double TinhGiaBan();
    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Mã sản phẩm: {MaSanPham}, Tên sản phẩm: {TenSanPham}, Giá gốc: {GiaGoc}");
    }
}
