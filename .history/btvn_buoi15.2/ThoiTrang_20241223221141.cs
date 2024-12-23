namespace QuanLyBanHang
{
    public class ThoiTrang : SanPham
    {
        private const double GiamGia = 0.2; // 20% giảm giá theo mùa

        public ThoiTrang(string maSanPham, string tenSanPham, double giaGoc)
            : base(maSanPham, tenSanPham, giaGoc)
        {
        }

        public override double TinhGiaBan()
        {
            return GiaGoc - (GiaGoc * GiamGia);
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Giá bán (sau khi giảm giá): {TinhGiaBan()}");
        }
    }
}
