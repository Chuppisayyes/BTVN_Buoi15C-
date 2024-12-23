using System;

namespace QuanLyBanHang
{
    public class DienTu : SanPham
    {
        public DienTu(string maSanPham, string tenSanPham, double giaGoc) : base(maSanPham, tenSanPham, giaGoc) { }

        public override double TinhGiaBan()
        {
            return GiaGoc + GiaGoc * 0.1; // Cộng thêm 10% thuế
        }

        public override string LayLoaiSanPham()
        {
            return "DienTu";
        }
    }
}
