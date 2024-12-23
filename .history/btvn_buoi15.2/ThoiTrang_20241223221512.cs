using System;

namespace QuanLyBanHang
{
    public class ThoiTrang : SanPham
    {
        public ThoiTrang(string maSanPham, string tenSanPham, double giaGoc) : base(maSanPham, tenSanPham, giaGoc) { }

        public override double TinhGiaBan()
        {
            return GiaGoc - GiaGoc * 0.2; // Giảm giá 20%
        }

        public override string LayLoaiSanPham()
        {
            return "ThoiTrang";
        }
    }
}
