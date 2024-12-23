using System;

    public class ThoiTrang : SanPham
    {
        public double GiamGia { get; set; }

        public ThoiTrang(string maSanPham, string tenSanPham, double giaGoc, double giamGia)
            : base(maSanPham, tenSanPham, giaGoc)
        {
            GiamGia = giamGia;
        }

        public override double TinhGiaBan()
        {
            return GiaGoc - GiamGia;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"(Giảm giá: {GiamGia})");
        }
    }
}
