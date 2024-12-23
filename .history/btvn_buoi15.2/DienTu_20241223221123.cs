namespace QuanLyBanHang
{
    public class DienTu : SanPham
    {
        private const double ThueBaoHanh = 0.1; // 10% thuế bảo hành

        public DienTu(string maSanPham, string tenSanPham, double giaGoc)
            : base(maSanPham, tenSanPham, giaGoc)
        {
        }

        public override double TinhGiaBan()
        {
            return GiaGoc + (GiaGoc * ThueBaoHanh);
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Giá bán (đã cộng thuế bảo hành): {TinhGiaBan()}");
        }
    }
}
