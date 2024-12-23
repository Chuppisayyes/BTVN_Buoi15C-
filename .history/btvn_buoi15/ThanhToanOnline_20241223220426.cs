namespace PaymentSystem
{
    public class ThanhToanOnline : IThanhToan
    {
        private const string OtpCode = "1234";

        public bool ThanhToan(double soTien)
        {
            Console.Write("Nhập mã OTP: ");
            string otp = Console.ReadLine();

            if (otp == OtpCode)
            {
                Console.WriteLine($"Thanh toán online: {soTien} VND. Giao dịch thành công!");
                return true;
            }
            else
            {
                Console.WriteLine("Mã OTP không đúng. Giao dịch thất bại!");
                return false;
            }
        }
    }
}
