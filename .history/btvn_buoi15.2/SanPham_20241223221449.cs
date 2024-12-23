using System;

namespace QuanLyBanHang
{
    public abstract class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double GiaGoc { get; set; }

        protected SanPham(string maSanPham, string tenSanPham, double giaGoc)
        {
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            GiaGoc = giaGoc;
        }

        public abstract double TinhGiaBan();

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Mã SP: {MaSanPham}, Tên SP: {TenSanPham}, Giá gốc: {GiaGoc}");
        }

        public abstract string LayLoaiSanPham();
    }
}
