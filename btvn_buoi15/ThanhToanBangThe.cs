namespace PaymentSystem
{
    public class ThanhToanBangThe : IThanhToan
    {
        private const string PinCode = "9999";

        public bool ThanhToan(double soTien)
        {
            Console.Write("Nhập mã PIN: ");
            string pin = Console.ReadLine();

            if (pin == PinCode)
            {
                Console.WriteLine($"Thanh toán bằng thẻ: {soTien} VND. Giao dịch thành công!");
                return true;
            }
            else
            {
                Console.WriteLine("Mã PIN không đúng. Giao dịch thất bại!");
                return false;
            }
        }
    }
}
