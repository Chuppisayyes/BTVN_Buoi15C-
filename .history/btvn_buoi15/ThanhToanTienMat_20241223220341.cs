namespace PaymentSystem
{
    public class ThanhToanTienMat : IThanhToan
    {
        public bool ThanhToan(double soTien)
        {
            Console.WriteLine($"Thanh toán tiền mặt: {soTien} VND. Giao dịch thành công!");
            return true;
        }
    }
}
