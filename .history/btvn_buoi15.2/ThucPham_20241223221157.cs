namespace QuanLyBanHang
{
    public class ThucPham : SanPham
    {
        private const double PhiVanChuyen = 0.05; // 5% phí vận chuyển

        public ThucPham(string maSanPham, string tenSanPham, double giaGoc)
            : base(maSanPham, tenSanPham, giaGoc)
        {
        }

        public override double TinhGiaBan()
        {
            return GiaGoc + (GiaGoc * PhiVanChuyen);
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Giá bán (đã cộng phí vận chuyển): {TinhGiaBan()}");
        }
    }
}
